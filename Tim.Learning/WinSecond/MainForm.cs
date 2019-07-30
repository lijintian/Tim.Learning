using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSecond
{
    public partial class MainForm : Form
    {
        public int t = 0;

        public int blingTimes = 0;
        string hh, mm, ss, ms;

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;

            lbTime .Text = outformat(t);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            t = 0;
            blingTimes = 0;
            timer1.Enabled = false;
            lbTime.Text = "00.00";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var curDirect = System.IO.Directory.GetCurrentDirectory();
            var mainBg = System.Configuration.ConfigurationManager.AppSettings["MainBg"];
            this.pbMain.Image = new Bitmap(curDirect+ @"\Image\mainBg.gif");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.pbMain.Width = this.Width;
            this.pbMain.Height = this.Height;


            this.lbTime.Height = this.Height / 4;
            this.lbTime.Width = this.Width / 8*3;
            var lby = this.Height / 4 - this.lbTime.Height / 2;
            var lbx = this.Width / 2 - this.lbTime.Width / 2;
            this.lbTime.Location = new Point(lbx,lby);
         
            
            var btnWith= this.Width / 8*2;
            var btnHeight= this.Height / 8;

            this.btnStartOrStop.Height = btnHeight;
            this.btnStartOrStop.Width =  btnWith;

            var btnStratY = this.Height / 8 * 5 - this.btnStartOrStop.Height / 2;
            var btnStratX = this.Width / 8 * 2 -10;
            this.btnStartOrStop.Location = new Point(btnStratX, btnStratY);


            this.btnReset.Height = btnHeight;
            this.btnReset.Width = btnWith;

            var btnResetY = this.Height / 8 * 5 - this.btnReset.Height / 2;
            var btnResetX = this.Width / 8 * 4 +10;
            this.btnReset.Location = new Point(btnResetX, btnResetY);
        }

        private void pbMain_Click(object sender, EventArgs e)
        {

        }

        private void timerTimeBling_Tick(object sender, EventArgs e)
        {
            blingTimes++;

            if (this.lbTime.ForeColor == Color.Red)
            {
                this.lbTime.ForeColor = Color.Black;
                this.lbTime.Font = new Font("宋体", 90F, FontStyle.Bold, GraphicsUnit.Point, 134);
       
            }
            else
            {
                this.lbTime.ForeColor = Color.Red;
                this.lbTime.Font = new Font("宋体", 88F, FontStyle.Bold, GraphicsUnit.Point, 134);
            }

            if (blingTimes == 10)
            {
                blingTimes = 0;
                timerTimeBling.Stop();
                #region 打开Result窗口
                var winResult = new DiscountResult();
                winResult.currentVal = Convert.ToDecimal(this.lbTime.Text);


                winResult.startLocationY = this.lbTime.Location.Y + this.lbTime.Height;
                winResult.Show();
                #endregion

                this.lbTime.BackColor = Color.White;
                this.lbTime.ForeColor = Color.Black;
                this.lbTime.Font = new Font("宋体", 90F, FontStyle.Bold, GraphicsUnit.Point, 134);

                this.btnStartOrStop.Enabled = true;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartOrStop_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                timer1.Start();
                btnStartOrStop.Text = "停止";

                //此处判断时间显示结果
            }
            else
            {

                this.btnStartOrStop.Enabled = false;

                btnStartOrStop.Text = "开始";
                timer1.Stop();

                #region 闪烁文字
                timerTimeBling.Enabled = true;
                timerTimeBling.Start();
                #endregion
            }
        }

        public string outformat(int t)//自定义类用来提供给我们自己想要的字符串格式，以及时间的代还运算
        {
            int temp = t / 100;
            int mms = t % 100;
            int h = temp / 3600;
            int m = temp / 60 % 60;
            int s = temp % 60;

            //if (h < 10) hh = "0" + h.ToString(); else hh = h.ToString();
            //if (m < 10) mm = "0" + m.ToString(); else mm = m.ToString();
            if (s < 10) ss = "0" + s.ToString(); else ss = s.ToString();
            if (mms < 10) ms = "0" + mms.ToString(); else ms = mms.ToString();


            return  ss + "." + ms;

            //return hh + ":" + mm + ":" + ss + "." + ms;
        }

    }
}
