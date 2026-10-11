namespace Demo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.LinkLabel();
            this.btnSound = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnMenuSound = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.gameTimerDesign = new System.Windows.Forms.Timer(this.components);
            this.lblCombo = new System.Windows.Forms.Label();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.lblTimeResult = new System.Windows.Forms.Label();
            this.lblScoreResult = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblGameTitle = new System.Windows.Forms.Label();
            this.pnlMenuButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnMenuGuide = new System.Windows.Forms.Button();
            this.btnMenuAbout = new System.Windows.Forms.Button();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.btnCloseHistory = new System.Windows.Forms.Button();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlResult.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuButtons.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(500, 20);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 45);
            this.lblMessage.TabIndex = 0;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(260, 20);
            this.lblScore.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(155, 45);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Điểm: 0";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold);
            this.lblLevel.Location = new System.Drawing.Point(40, 20);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(157, 45);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.TabStop = true;
            this.lblLevel.Text = "Level: 1";
            // 
            // btnSound
            // 
            this.btnSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSound.FlatAppearance.BorderSize = 0;
            this.btnSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSound.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSound.Location = new System.Drawing.Point(1420, 220);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(100, 100);
            this.btnSound.TabIndex = 3;
            this.btnSound.Text = "🔊";
            this.btnSound.UseVisualStyleBackColor = true;
            this.btnSound.Click += new System.EventHandler(this.BtnSound_Click);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(1420, 340);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 100);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Ⅱ";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(1420, 460);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 100);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(1420, 580);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(100, 100);
            this.btnRestart.TabIndex = 6;
            this.btnRestart.Text = "↻";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // btnHome
            // 
            this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Location = new System.Drawing.Point(1420, 100);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(100, 100);
            this.btnHome.TabIndex = 21;
            this.btnHome.Text = "🏠";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // btnMenuSound
            // 
            this.btnMenuSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuSound.FlatAppearance.BorderSize = 0;
            this.btnMenuSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSound.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSound.Location = new System.Drawing.Point(1420, 40);
            this.btnMenuSound.Name = "btnMenuSound";
            this.btnMenuSound.Size = new System.Drawing.Size(100, 100);
            this.btnMenuSound.TabIndex = 22;
            this.btnMenuSound.Text = "🔊";
            this.btnMenuSound.UseVisualStyleBackColor = true;
            this.btnMenuSound.Click += new System.EventHandler(this.BtnSound_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(1100, 20);
            this.lblTime.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(299, 45);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "Thời gian: 03:00";
            // 
            // gameTimerDesign
            // 
            this.gameTimerDesign.Interval = 1000;
            this.gameTimerDesign.Tick += new System.EventHandler(this.gameTimerDesign_Tick);
            // 
            // lblCombo
            // 
            this.lblCombo.AutoSize = true;
            this.lblCombo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombo.Location = new System.Drawing.Point(500, 20);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Size = new System.Drawing.Size(0, 45);
            this.lblCombo.TabIndex = 8;
            // 
            // pnlResult
            // 
            this.pnlResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResult.Controls.Add(this.btnExit);
            this.pnlResult.Controls.Add(this.btnPlayAgain);
            this.pnlResult.Controls.Add(this.lblHighScore);
            this.pnlResult.Controls.Add(this.lblTimeResult);
            this.pnlResult.Controls.Add(this.lblScoreResult);
            this.pnlResult.Controls.Add(this.lblResult);
            this.pnlResult.Location = new System.Drawing.Point(500, 300);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(600, 450);
            this.pnlResult.TabIndex = 9;
            this.pnlResult.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(310, 330);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 60);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát game";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Location = new System.Drawing.Point(110, 330);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(180, 60);
            this.btnPlayAgain.TabIndex = 4;
            this.btnPlayAgain.Text = "Chơi lại";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Location = new System.Drawing.Point(170, 230);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(120, 31);
            this.lblHighScore.TabIndex = 3;
            this.lblHighScore.Text = "Kỷ lục: 0";
            // 
            // lblTimeResult
            // 
            this.lblTimeResult.AutoSize = true;
            this.lblTimeResult.Location = new System.Drawing.Point(170, 180);
            this.lblTimeResult.Name = "lblTimeResult";
            this.lblTimeResult.Size = new System.Drawing.Size(265, 31);
            this.lblTimeResult.TabIndex = 2;
            this.lblTimeResult.Text = "Thời gian chơi: 00:00";
            // 
            // lblScoreResult
            // 
            this.lblScoreResult.AutoSize = true;
            this.lblScoreResult.Location = new System.Drawing.Point(170, 130);
            this.lblScoreResult.Name = "lblScoreResult";
            this.lblScoreResult.Size = new System.Drawing.Size(168, 31);
            this.lblScoreResult.TabIndex = 1;
            this.lblScoreResult.Text = "Tổng điểm: 0";
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(50, 30);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(500, 60);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "KẾT QUẢ";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnMenuSound);
            this.pnlMenu.Controls.Add(this.lblGameTitle);
            this.pnlMenu.Controls.Add(this.pnlMenuButtons);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1609, 1055);
            this.pnlMenu.TabIndex = 13;
            this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenu_Paint);
            // 
            // lblGameTitle
            // 
            this.lblGameTitle.Font = new System.Drawing.Font("Times New Roman", 55F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameTitle.Location = new System.Drawing.Point(300, 140);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(1000, 110);
            this.lblGameTitle.TabIndex = 18;
            this.lblGameTitle.Text = "MEMORY GAME";
            this.lblGameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMenuButtons
            // 
            this.pnlMenuButtons.Controls.Add(this.btnPlay);
            this.pnlMenuButtons.Controls.Add(this.btnHistory);
            this.pnlMenuButtons.Controls.Add(this.btnMenuGuide);
            this.pnlMenuButtons.Controls.Add(this.btnMenuAbout);
            this.pnlMenuButtons.Location = new System.Drawing.Point(280, 290);
            this.pnlMenuButtons.Name = "pnlMenuButtons";
            this.pnlMenuButtons.Size = new System.Drawing.Size(1050, 100);
            this.pnlMenuButtons.TabIndex = 20;
            this.pnlMenuButtons.WrapContents = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(5, 5);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(5);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(250, 85);
            this.btnPlay.TabIndex = 18;
            this.btnPlay.Text = "VÀO GAME";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Font = new System.Drawing.Font("Times New Roman", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.Location = new System.Drawing.Point(265, 5);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(5);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(250, 85);
            this.btnHistory.TabIndex = 16;
            this.btnHistory.Text = "LỊCH SỬ KỶ LỤC";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnMenuGuide
            // 
            this.btnMenuGuide.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuGuide.Location = new System.Drawing.Point(525, 5);
            this.btnMenuGuide.Margin = new System.Windows.Forms.Padding(5);
            this.btnMenuGuide.Name = "btnMenuGuide";
            this.btnMenuGuide.Size = new System.Drawing.Size(250, 85);
            this.btnMenuGuide.TabIndex = 19;
            this.btnMenuGuide.Text = "HƯỚNG DẪN";
            this.btnMenuGuide.UseVisualStyleBackColor = true;
            this.btnMenuGuide.Click += new System.EventHandler(this.BtnMenuGuide_Click);
            // 
            // btnMenuAbout
            // 
            this.btnMenuAbout.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAbout.Location = new System.Drawing.Point(785, 5);
            this.btnMenuAbout.Margin = new System.Windows.Forms.Padding(5);
            this.btnMenuAbout.Name = "btnMenuAbout";
            this.btnMenuAbout.Size = new System.Drawing.Size(250, 85);
            this.btnMenuAbout.TabIndex = 20;
            this.btnMenuAbout.Text = "GIỚI THIỆU";
            this.btnMenuAbout.UseVisualStyleBackColor = true;
            this.btnMenuAbout.Click += new System.EventHandler(this.BtnMenuAbout_Click);
            // 
            // pnlHistory
            // 
            this.pnlHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHistory.Controls.Add(this.lstHistory);
            this.pnlHistory.Controls.Add(this.btnCloseHistory);
            this.pnlHistory.Controls.Add(this.lblHistoryTitle);
            this.pnlHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(600, 500);
            this.pnlHistory.TabIndex = 14;
            this.pnlHistory.Visible = false;
            // 
            // lstHistory
            // 
            this.lstHistory.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 26;
            this.lstHistory.Location = new System.Drawing.Point(50, 100);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(500, 264);
            this.lstHistory.TabIndex = 2;
            // 
            // btnCloseHistory
            // 
            this.btnCloseHistory.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseHistory.Location = new System.Drawing.Point(230, 420);
            this.btnCloseHistory.Name = "btnCloseHistory";
            this.btnCloseHistory.Size = new System.Drawing.Size(140, 50);
            this.btnCloseHistory.TabIndex = 1;
            this.btnCloseHistory.Text = "ĐÓNG";
            this.btnCloseHistory.UseVisualStyleBackColor = true;
            this.btnCloseHistory.Click += new System.EventHandler(this.btnCloseHistory_Click);
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoryTitle.Location = new System.Drawing.Point(50, 24);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(500, 60);
            this.lblHistoryTitle.TabIndex = 0;
            this.lblHistoryTitle.Text = "LỊCH SỬ KỶ LỤC";
            this.lblHistoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1609, 1055);
            this.Controls.Add(this.pnlHistory);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.lblCombo);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnSound);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(380, 20);
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.Name = "Form1";
            this.Text = "Memory Game";
            this.pnlResult.ResumeLayout(false);
            this.pnlResult.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenuButtons.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.LinkLabel lblLevel;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSound;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnMenuSound;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer gameTimerDesign;
        private System.Windows.Forms.Label lblCombo;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblScoreResult;
        private System.Windows.Forms.Label lblTimeResult;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.FlowLayoutPanel pnlMenuButtons;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnMenuGuide;
        private System.Windows.Forms.Button btnMenuAbout;
        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Button btnCloseHistory;
        private System.Windows.Forms.ListBox lstHistory;
    }
}
