namespace WinSecond
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStartOrStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTime = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.timerTimeBling = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartOrStop
            // 
            this.btnStartOrStop.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartOrStop.Location = new System.Drawing.Point(307, 316);
            this.btnStartOrStop.Name = "btnStartOrStop";
            this.btnStartOrStop.Size = new System.Drawing.Size(245, 90);
            this.btnStartOrStop.TabIndex = 0;
            this.btnStartOrStop.Text = "开始";
            this.btnStartOrStop.UseVisualStyleBackColor = true;
            this.btnStartOrStop.Click += new System.EventHandler(this.btnStartOrStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("宋体", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTime.Location = new System.Drawing.Point(391, 133);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(350, 120);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "00.00";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(583, 316);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(245, 90);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "清零";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pbMain
            // 
            this.pbMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbMain.ErrorImage = null;
            this.pbMain.Location = new System.Drawing.Point(6, 10);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(1123, 596);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMain.TabIndex = 2;
            this.pbMain.TabStop = false;
            // 
            // timerTimeBling
            // 
            this.timerTimeBling.Interval = 200;
            this.timerTimeBling.Tick += new System.EventHandler(this.timerTimeBling_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1135, 617);
            this.ControlBox = false;
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStartOrStop);
            this.Controls.Add(this.pbMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "10秒活动V1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartOrStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Timer timerTimeBling;
    }
}

