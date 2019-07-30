namespace WinSecond
{
    partial class DiscountResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscountResult));
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.lbMsg = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pbResult
            // 
            this.pbResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbResult.Image = ((System.Drawing.Image)(resources.GetObject("pbResult.Image")));
            this.pbResult.Location = new System.Drawing.Point(1, -1);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(629, 405);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResult.TabIndex = 0;
            this.pbResult.TabStop = false;
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.Location = new System.Drawing.Point(161, 182);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(309, 27);
            this.lbMsg.TabIndex = 1;
            this.lbMsg.Text = "喝杯草本茶，运气满满！";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(255, 273);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 54);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "再来一次";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.Location = new System.Drawing.Point(272, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(82, 27);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "00.00";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiscountResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 403);
            this.ControlBox = false;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.pbResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiscountResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiscountResult";
            this.Load += new System.EventHandler(this.DiscountResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbTime;
    }
}