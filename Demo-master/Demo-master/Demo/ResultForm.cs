using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class ResultForm : Form
    {
        public ResultForm(bool isWin, int score, int totalTimePlayed)
        {
            InitializeComponent();

            if (isWin)
            {
                lblResult.Text = "🏆 Hoàn thành tất cả các màn!";
            }
            else
            {
                lblResult.Text = "KẾT QUẢ";
            }

            lblScoreResult.Text = "Tổng điểm: " + score;

            int minutes = totalTimePlayed / 60;
            int seconds = totalTimePlayed % 60;

            lblTimeResult.Text = "Thời gian chơi: "
                + minutes.ToString("00")
                + ":"
                + seconds.ToString("00");
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
