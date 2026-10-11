using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        // ==========================================
        // KHU VỰC CHỈNH SỬA THÔNG TIN NHÓM THỰC HIỆN
        // ==========================================
        private string groupTitle = "THÔNG TIN NHÓM THỰC HIỆN";
        private string subjectName = "Lập trình Windows (.NET Framework)";
        private string projectName = "Game Lật Thẻ (Memory Card Game)";
        private string member1 = "1. Sỳ Gia Hân - 51.01.104.024";
        private string member2 = "2. Nguyễn Cao Ngọc - 51.01.104.032";
        private string member3 = "3. Hồ Thanh Hải - 51.01.104.021";
        private string member4 = "4. Bùi Long Nhật - 51.01.104.064";

        // Khai báo biến game 
        private Game game;
        private List<Button> cardButtons;
        private int firstIndex = -1;
        private List<bool> matchedCards;
        private Timer messageTimer;
        private Timer flipBackTimer;
        private int wrongFirstIndex = -1;
        private int wrongSecondIndex = -1;
        private bool isBusy = false; // Khóa click khi đang xử lý lật/đóng thẻ để tránh lag

        // Lưu trữ hình ảnh thẻ bài và hình nền
        private Dictionary<int, Image> cardImages = new Dictionary<int, Image>();
        private Image bgImage = null;

        // Khởi tạo game
        private int remainingSeconds = 0;
        private int totalTimePlayed = 0;
        private bool isSoundOn = true;
        private bool isPaused = false;
        private int highScore = 0;
        private string historyFilePath = Path.Combine(Application.StartupPath, "history.txt");

        // Cờ kiểm tra đang có ván chơi dở dang hay không
        private bool isGameInProgress = false;

        // Bật DoubleBuffering cho toàn bộ Form và Controls để chống nhấp nháy 100%
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED: vẽ mượt mà, khử nhấp nháy hoàn toàn
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this.WindowState = FormWindowState.Maximized;
            this.Shown += Form1_Shown;
            this.Resize += Form1_Resize;
            this.FormClosing += Form1_FormClosing;

            try
            {
                SoundManager.Initialize();
                LoadGameResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi nạp tài nguyên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Khởi tạo các thành phần
            game = new Game(1);
            cardButtons = new List<Button>();
            matchedCards = new List<bool>();

            // Timer thông báo
            messageTimer = new Timer();
            messageTimer.Interval = 700;
            messageTimer.Tick += MessageTimer_Tick;

            // Timer lật lại ô sai (giữ 500ms vừa đủ để người chơi nhìn và nhớ)
            flipBackTimer = new Timer();
            flipBackTimer.Interval = 500;
            flipBackTimer.Tick += FlipBackTimer_Tick;

            remainingSeconds = game.TimeLimit;
            totalTimePlayed = 0;
            LoadHighScore();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SoundManager.StopBgm();
            }
            catch
            {
            }
        }

        private void LoadGameResources()
        {
            try
            {
                string resFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
                string nenPath = Path.Combine(resFolder, "nen.png");
                if (File.Exists(nenPath))
                {
                    bgImage = Image.FromFile(nenPath);
                    this.BackgroundImage = bgImage;
                    this.BackgroundImageLayout = ImageLayout.Stretch;

                    pnlMenu.BackColor = Color.Transparent;
                    pnlMenuButtons.BackColor = Color.Transparent;
                }

                // Nạp 10 hình lật (1.png -> 10.png)
                for (int i = 1; i <= 10; i++)
                {
                    string imgPath = Path.Combine(resFolder, i + ".png");
                    if (File.Exists(imgPath))
                    {
                        cardImages[i] = Image.FromFile(imgPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message, "Lỗi hình ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CenterMenuControls();
            AlignGameControlButtons();
            CreateMenuButtons();

            pnlResult.Left = (this.ClientSize.Width - pnlResult.Width) / 2;
            pnlResult.Top = (this.ClientSize.Height - pnlResult.Height) / 2;

            // Ban đầu ở màn hình chính, ẩn các nút chơi game
            SetGameControlsVisible(false);

            // Phát nhạc nền
            if (isSoundOn)
            {
                SoundManager.PlayBgm();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterMenuControls();
            AlignGameControlButtons();

            if (pnlResult.Visible)
            {
                pnlResult.Left = (this.ClientSize.Width - pnlResult.Width) / 2;
                pnlResult.Top = (this.ClientSize.Height - pnlResult.Height) / 2;
            }

            if (pnlHistory.Visible)
            {
                pnlHistory.Left = (this.ClientSize.Width - pnlHistory.Width) / 2;
                pnlHistory.Top = (this.ClientSize.Height - pnlHistory.Height) / 2;
            }
        }

        // Căn giữa tiêu đề và hàng nút ở màn hình chính
        private void CenterMenuControls()
        {
            try
            {
                lblGameTitle.Left = (this.ClientSize.Width - lblGameTitle.Width) / 2;
                lblGameTitle.Top = (int)(this.ClientSize.Height * 0.25);

                pnlMenuButtons.Left = (this.ClientSize.Width - pnlMenuButtons.Width) / 2;
                pnlMenuButtons.Top = lblGameTitle.Bottom + 40;

                btnMenuSound.Left = this.ClientSize.Width - btnMenuSound.Width - 40;
                btnMenuSound.Top = 30;
            }
            catch
            {
            }
        }

        // Căn thẳng hàng 5 nút góc phải trong màn chơi: Home, Loa, Pause, ?, Restart
        private void AlignGameControlButtons()
        {
            try
            {
                int rightMargin = 40;
                int startTop = 90;
                int buttonGap = 20;
                int buttonSize = 90;

                Button[] sideButtons = new Button[] { btnHome, btnSound, btnPause, btnHelp, btnRestart };
                int currentTop = startTop;

                for (int i = 0; i < sideButtons.Length; i++)
                {
                    Button btn = sideButtons[i];
                    btn.Size = new Size(buttonSize, buttonSize);
                    btn.Left = this.ClientSize.Width - buttonSize - rightMargin;
                    btn.Top = currentTop;
                    btn.Region = CreateCircleRegion(buttonSize);
                    currentTop += buttonSize + buttonGap;
                }

                lblTime.Left = this.ClientSize.Width - lblTime.Width - 40;
                lblTime.Top = 20;
            }
            catch
            {
            }
        }

        private void SetGameControlsVisible(bool visible)
        {
            lblLevel.Visible = visible;
            lblScore.Visible = visible;
            lblTime.Visible = visible;
            btnHome.Visible = visible;
            btnSound.Visible = visible;
            btnPause.Visible = visible;
            btnHelp.Visible = visible;
            btnRestart.Visible = visible;

            // Ẩn/Hiện đồng loạt tất cả các thẻ bài (giữ nguyên vị trí và trạng thái lật)
            foreach (Button btn in cardButtons)
            {
                btn.Visible = visible;
            }
        }

        private void CreateMenuButtons()
        {
            try
            {
                btnMenuSound.Region = CreateCircleRegion(btnMenuSound.Width);
            }
            catch
            {
            }
        }

        private Region CreateCircleRegion(int size)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, size, size);
            return new Region(path);
        }

        private void gameTimerDesign_Tick(object sender, EventArgs e)
        {
            try
            {
                remainingSeconds--;
                totalTimePlayed++;

                int minutes = remainingSeconds / 60;
                int seconds = remainingSeconds % 60;

                lblTime.Text = "Thời gian: "
                    + minutes.ToString("00")
                    + ":"
                    + seconds.ToString("00");

                if (remainingSeconds <= 0)
                {
                    gameTimerDesign.Stop();
                    isGameInProgress = false;
                    ShowResult(false);
                }
            }
            catch (Exception)
            {
            }
        }

        // Tạo các ô bài trong chế độ Batch (SuspendLayout để tuyệt đối không nhấp nháy)
        private void CreateCards()
        {
            this.SuspendLayout();

            lblLevel.Text = "Level: " + game.Level;

            int columns;
            if (game.Level == 1)
            {
                columns = 2;
            }
            else if (game.Level <= 8)
            {
                columns = 4;
            }
            else
            {
                columns = 5;
            }

            int rows = (game.Cards.Count + columns - 1) / columns;
            int margin = 50;
            int gap = 20;
            int sidePanelWidth = 160;

            int availableWidth = this.ClientSize.Width - margin * 2 - sidePanelWidth;
            int availableHeight = this.ClientSize.Height - 110 - margin;

            int cardSize = Math.Min(
                (availableWidth - gap * (columns - 1)) / columns,
                (availableHeight - gap * (rows - 1)) / rows
            );

            int totalGridWidth = columns * cardSize + (columns - 1) * gap;
            int startX = margin + (availableWidth - totalGridWidth) / 2;

            for (int i = 0; i < game.Cards.Count; i++)
            {
                Button button = new Button();
                button.Width = cardSize;
                button.Height = cardSize;
                button.Font = new Font("Times New Roman", 32, FontStyle.Bold);
                button.BackColor = Color.LightSteelBlue;
                button.BackgroundImageLayout = ImageLayout.Zoom;
                button.Cursor = Cursors.Hand;
                button.TabStop = false;

                button.Left = startX + (i % columns) * (cardSize + gap);
                button.Top = 90 + (i / columns) * (cardSize + gap);

                button.Text = "?";
                button.Image = null;

                button.Click += Card_Click;

                cardButtons.Add(button);
                matchedCards.Add(false);
                this.Controls.Add(button);
            }

            this.ResumeLayout(true);
        }

        // Chuyển sang Level tiếp theo
        private void NextLevel()
        {
            if (game.Level >= 10)
            {
                isGameInProgress = false;
                ShowMessage("Chúc mừng bạn đã hoàn thành tất cả level!");
                return;
            }

            this.SuspendLayout();
            foreach (Button button in cardButtons)
            {
                this.Controls.Remove(button);
                button.Dispose();
            }
            cardButtons.Clear();
            matchedCards.Clear();
            this.ResumeLayout(true);

            game = new Game(game.Level + 1, game.Score);

            if (game.Level == 6)
            {
                gameTimerDesign.Stop();

                MessageBox.Show(
                    "Từ Level 6 trở đi:\n\n" +
                    "• Đúng liên tiếp: điểm tăng theo Combo.\n" +
                    "• Cặp đúng đầu tiên: +1 điểm.\n" +
                    "• Cặp tiếp theo: +2 điểm.\n" +
                    "• Cặp tiếp theo nữa: +3 điểm...\n" +
                    "• Nếu sai: -1 điểm và Combo trở về 0.",
                    "Luật mới - Level 6",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            remainingSeconds = game.TimeLimit;

            lblTime.Text = "Thời gian: "
                + (remainingSeconds / 60).ToString("00")
                + ":"
                + (remainingSeconds % 60).ToString("00");

            gameTimerDesign.Start();

            firstIndex = -1;
            isBusy = false;

            CreateCards();
        }

        private void ShowMessage(string message)
        {
            lblMessage.Text = message;

            if (message == "Chúc mừng bạn đã hoàn thành tất cả level!")
            {
                messageTimer.Interval = 5000;
            }
            else
            {
                messageTimer.Interval = 700;
            }

            messageTimer.Stop();
            messageTimer.Start();
        }

        private void ShowResult(bool isWin)
        {
            try
            {
                lblResult.Text = isWin ? "🏆 CHIẾN THẮNG!" : "HẾT GIỜ!";
                lblScoreResult.Text = "Tổng điểm: " + game.Score;

                int minutes = totalTimePlayed / 60;
                int seconds = totalTimePlayed % 60;

                lblTimeResult.Text = "Thời gian chơi: "
                    + minutes.ToString("00")
                    + ":"
                    + seconds.ToString("00");

                if (game.Score > highScore)
                {
                    highScore = game.Score;
                    try
                    {
                        string filePath = Path.Combine(Application.StartupPath, "highscore.txt");
                        File.WriteAllText(filePath, highScore.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi ghi highscore: " + ex.Message);
                    }
                }

                SaveHistory();

                lblHighScore.Text = "Kỷ lục: " + highScore;
                pnlResult.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị kết quả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveHistory()
        {
            try
            {
                List<string> history = new List<string>();
                if (File.Exists(historyFilePath))
                {
                    history.AddRange(File.ReadAllLines(historyFilePath));
                }
                string newRecord = "Điểm: "
                    + game.Score
                    + " | Thời gian: "
                    + (totalTimePlayed / 60).ToString("00")
                    + ":"
                    + (totalTimePlayed % 60).ToString("00");

                history.Add(newRecord);
                history = history
                    .OrderByDescending(x =>
                    {
                        try
                        {
                            int scoreStart = x.IndexOf(": ") + 2;
                            int scoreEnd = x.IndexOf(" |");
                            return int.Parse(x.Substring(scoreStart, scoreEnd - scoreStart));
                        }
                        catch
                        {
                            return 0;
                        }
                    })
                    .ThenBy(x =>
                    {
                        try
                        {
                            int timeStart = x.LastIndexOf(": ") + 2;
                            string[] time = x.Substring(timeStart).Split(':');
                            int minutes = int.Parse(time[0]);
                            int seconds = int.Parse(time[1]);
                            return minutes * 60 + seconds;
                        }
                        catch
                        {
                            return int.MaxValue;
                        }
                    })
                    .ToList();

                File.WriteAllLines(historyFilePath, history);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ghi lịch sử: " + ex.Message);
            }
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            messageTimer.Stop();
        }

        // Lật lại hai ô sai sau đúng 500ms (Không dùng timer thu nhỏ giật lag, đổi hình trực tiếp)
        private void FlipBackTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (wrongFirstIndex != -1 && wrongSecondIndex != -1)
                {
                    Button b1 = cardButtons[wrongFirstIndex];
                    Button b2 = cardButtons[wrongSecondIndex];

                    b1.Text = "?";
                    b1.Image = null;
                    b1.BackColor = Color.LightSteelBlue;

                    b2.Text = "?";
                    b2.Image = null;
                    b2.BackColor = Color.LightSteelBlue;
                }
            }
            catch
            {
            }
            finally
            {
                wrongFirstIndex = -1;
                wrongSecondIndex = -1;
                flipBackTimer.Stop();
                isBusy = false; // Mở khóa cho người chơi chọn tiếp
            }
        }

        private Image GetCardImage(int cardNumber)
        {
            if (cardImages.ContainsKey(cardNumber))
            {
                return cardImages[cardNumber];
            }
            return null;
        }

        // Xử lý khi người chơi chọn ô: Mượt mà, dứt khoát, không lag
        private void Card_Click(object sender, EventArgs e)
        {
            try
            {
                // Nếu đang chờ đóng 2 ô sai thì không nhận bấm mới
                if (isBusy || flipBackTimer.Enabled)
                {
                    return;
                }

                Button button = (Button)sender;
                int index = cardButtons.IndexOf(button);

                if (index < 0 || matchedCards[index] || index == firstIndex)
                {
                    return;
                }

                // Phát âm thanh khi lật thẻ
                SoundManager.PlayFlip();

                int cardValue = game.Cards[index];
                Image cardImg = GetCardImage(cardValue);

                // LẬT Ô THỨ NHẤT: Đổi ngay lập tức sang hình thẻ
                if (firstIndex == -1)
                {
                    firstIndex = index;
                    button.Text = "";
                    button.Image = cardImg;
                    button.BackColor = Color.White;
                    return;
                }

                // LẬT Ô THỨ HAI
                int currentFirstIndex = firstIndex;
                firstIndex = -1;
                isBusy = true; // Khóa tạm thời để kiểm tra

                button.Text = "";
                button.Image = cardImg;
                button.BackColor = Color.White;

                // Kiểm tra 2 ô có khớp nhau không
                bool isMatch = game.CheckMatch(currentFirstIndex, index);

                if (isMatch)
                {
                    SoundManager.PlayCorrect();

                    lblScore.Text = "Điểm: " + game.Score;

                    if (game.Level >= 6)
                    {
                        lblCombo.Text = "Combo: " + game.Combo;
                    }

                    matchedCards[currentFirstIndex] = true;
                    matchedCards[index] = true;
                    isBusy = false; // Mở khóa ngay lập tức để chơi tiếp

                    if (game.IsLevelComplete())
                    {
                        lblCombo.Text = "";
                        lblMessage.ForeColor = Color.Red;
                        ShowMessage("Hoàn thành màn " + game.Level + "!");

                        if (game.Level < 10)
                        {
                            NextLevel();
                        }
                        else
                        {
                            gameTimerDesign.Stop();
                            isGameInProgress = false;
                            lblMessage.ForeColor = Color.Red;
                            ShowResult(true);
                        }
                    }
                }
                else
                {
                    SoundManager.PlayWrong();

                    lblScore.Text = "Điểm: " + game.Score;
                    lblCombo.Text = "";

                    wrongFirstIndex = currentFirstIndex;
                    wrongSecondIndex = index;

                    // Giữ đúng 0.5s để ghi nhớ rồi tự động úp lại
                    flipBackTimer.Stop();
                    flipBackTimer.Start();
                }
            }
            catch (Exception ex)
            {
                isBusy = false;
                MessageBox.Show("Có lỗi khi chọn thẻ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hướng dẫn chơi
        private void ShowGameGuide()
        {
            MessageBox.Show(
                "HƯỚNG DẪN CÁCH CHƠI\n\n" +
                "• Bấm chuột vào 2 thẻ để lật hình.\n" +
                "• Nếu 2 thẻ có hình giống nhau: Ghép thành công và được cộng điểm.\n" +
                "• Nếu 2 thẻ khác hình: Thẻ sẽ tự động úp lại sau 0.5 giây để bạn ghi nhớ.\n\n" +

                "LUẬT TÍNH ĐIỂM\n\n" +
                "• Level 1–5: Mỗi cặp đúng được +1 điểm, lật sai không bị trừ điểm.\n" +
                "• Level 6–10: Bắt đầu tính Combo:\n" +
                "  - Đoán đúng liên tiếp: Cặp 1 được +1, cặp 2 được +2, cặp 3 được +3...\n" +
                "  - Nếu đoán sai: Bị trừ 1 điểm và Combo trở về 0.\n\n" +

                "CÁC PHÍM CHỨC NĂNG TRONG MÀN CHƠI\n\n" +
                "• Nút 🏠 (Ngôi nhà): Trở về Màn hình chính (Lưu lại tiến trình hiện tại).\n" +
                "• Nút 🔊 / 🔇: Bật / Tắt toàn bộ âm thanh và nhạc nền.\n" +
                "• Nút Ⅱ / ▶: Tạm dừng / Tiếp tục chơi.\n" +
                "• Nút ?: Xem lại hướng dẫn chơi.\n" +
                "• Nút ↻: Chơi lại từ đầu.",
                "Hướng dẫn chơi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Giới thiệu nhóm và thông tin thực hiện
        private void ShowAboutInfo()
        {
            MessageBox.Show(
                groupTitle + "\n\n" +
                "• Môn học: " + subjectName + "\n" +
                "• Tên đề tài: " + projectName + "\n\n" +
                "DANH SÁCH THÀNH VIÊN:\n" +
                member1 + "\n" +
                member2 + "\n" +
                member3 + "\n" +
                member4,
                "Giới thiệu nhóm thực hiện",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void BtnMenuGuide_Click(object sender, EventArgs e)
        {
            ShowGameGuide();
        }

        private void BtnMenuAbout_Click(object sender, EventArgs e)
        {
            ShowAboutInfo();
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            ShowGameGuide();
        }

        // Bấm nút Ngôi nhà 🏠: Thoát thẳng về Menu chính ngay lập tức, không hỏi hộp thoại, LƯU LẠI TIẾN TRÌNH
        private void BtnHome_Click(object sender, EventArgs e)
        {
            ReturnToHomeMenu();
        }

        private void ReturnToHomeMenu()
        {
            try
            {
                // Tạm dừng timer đếm ngược nhưng GIỮ NGUYÊN trạng thái thẻ và thời gian còn lại
                gameTimerDesign.Stop();

                // Nếu đang có 2 thẻ sai mở dở thì lập tức úp lại ngay
                if (flipBackTimer.Enabled)
                {
                    FlipBackTimer_Tick(null, null);
                }

                // Ẩn bảng kết quả / lịch sử
                pnlResult.Visible = false;
                pnlHistory.Visible = false;

                // Ẩn bàn cờ và các nút game (Không xóa các nút Button, chỉ ẩn đi để lưu tiến trình)
                SetGameControlsVisible(false);

                // Đổi nút bấm ngoài Menu thành "TIẾP TỤC CHƠI" nếu ván đang dở dang
                if (isGameInProgress)
                {
                    btnPlay.Text = "TIẾP TỤC CHƠI";
                }
                else
                {
                    btnPlay.Text = "VÀO GAME";
                }

                // Hiện màn hình chính
                pnlMenu.Visible = true;
                CenterMenuControls();
            }
            catch
            {
            }
        }

        private void BtnSound_Click(object sender, EventArgs e)
        {
            try
            {
                isSoundOn = !isSoundOn;
                SoundManager.IsMuted = !isSoundOn;

                string soundIcon = isSoundOn ? "🔊" : "🔇";
                btnSound.Text = soundIcon;
                btnMenuSound.Text = soundIcon;

                if (isSoundOn)
                {
                    SoundManager.PlayBgm();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi chuyển âm thanh: " + ex.Message);
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnPause = (Button)sender;
                isPaused = !isPaused;

                if (isPaused)
                {
                    gameTimerDesign.Stop();
                    btnPause.Text = "▶";
                    SoundManager.PauseBgm();
                }
                else
                {
                    gameTimerDesign.Start();
                    btnPause.Text = "Ⅱ";
                    if (isSoundOn) SoundManager.ResumeBgm();
                }
            }
            catch
            {
            }
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn chắc chắn muốn chơi lại từ đầu?",
                "Xác nhận chơi lại",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel)
            {
                return;
            }

            RestartGame();
        }

        private void RestartGame()
        {
            try
            {
                gameTimerDesign.Stop();
                flipBackTimer.Stop();
                messageTimer.Stop();

                game = new Game(1, 0);

                remainingSeconds = game.TimeLimit;
                totalTimePlayed = 0;

                firstIndex = -1;
                wrongFirstIndex = -1;
                wrongSecondIndex = -1;
                isPaused = false;
                isBusy = false;
                isGameInProgress = true;

                this.SuspendLayout();
                foreach (Button button in cardButtons)
                {
                    this.Controls.Remove(button);
                    button.Dispose();
                }
                cardButtons.Clear();
                matchedCards.Clear();
                this.ResumeLayout(true);

                lblMessage.Text = "";
                lblCombo.Text = "";
                lblScore.Text = "Điểm: 0";

                lblTime.Text = "Thời gian: "
                    + (remainingSeconds / 60).ToString("00")
                    + ":"
                    + (remainingSeconds % 60).ToString("00");

                btnPause.Text = "Ⅱ";

                CreateCards();
                gameTimerDesign.Start();

                if (isSoundOn)
                {
                    SoundManager.PlayBgm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi động lại: " + ex.Message);
            }
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            pnlResult.Visible = false;
            RestartGame();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ReturnToHomeMenu();
        }

        private void LoadHighScore()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "highscore.txt");
                if (File.Exists(filePath))
                {
                    string text = File.ReadAllText(filePath);
                    int.TryParse(text, out highScore);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi đọc highscore: " + ex.Message);
            }
        }

        // Bấm "VÀO GAME" hoặc "TIẾP TỤC CHƠI"
        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                pnlMenu.Visible = false;
                pnlHistory.Visible = false;

                SetGameControlsVisible(true);
                AlignGameControlButtons();

                if (!isGameInProgress)
                {
                    // Nếu là ván mới: tạo mới bàn chơi
                    isGameInProgress = true;
                    RestartGame();
                }
                else
                {
                    // Nếu là TIẾP TỤC VÁN ĐANG CHƠI: Giữ nguyên bàn cờ, tiếp tục đếm giờ
                    gameTimerDesign.Start();
                }

                if (isSoundOn)
                {
                    SoundManager.PlayBgm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi vào game: " + ex.Message);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                lstHistory.Items.Clear();

                if (File.Exists(historyFilePath))
                {
                    string[] lines = File.ReadAllLines(historyFilePath);
                    foreach (string line in lines)
                    {
                        lstHistory.Items.Add(line);
                    }
                }

                pnlMenu.Visible = false;
                SetGameControlsVisible(false);

                pnlHistory.Left = (this.ClientSize.Width - pnlHistory.Width) / 2;
                pnlHistory.Top = (this.ClientSize.Height - pnlHistory.Height) / 2;

                pnlHistory.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị lịch sử: " + ex.Message);
            }
        }

        private void btnCloseHistory_Click(object sender, EventArgs e)
        {
            pnlHistory.Visible = false;
            pnlMenu.Visible = true;
        }

        private void pnlHistory_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
