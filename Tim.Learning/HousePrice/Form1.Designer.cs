namespace HousePrice
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuyUnitPrice = new System.Windows.Forms.TextBox();
            this.txtSellUnitPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalArea = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuyTotalPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSellTotalPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTaxYy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTaxGrsd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTaxQs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTaxTdzz = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTaxYhs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMl = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalTax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtJl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始计算税收及毛利";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "购买单价";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "卖出单价";
            // 
            // txtBuyUnitPrice
            // 
            this.txtBuyUnitPrice.Location = new System.Drawing.Point(122, 57);
            this.txtBuyUnitPrice.Name = "txtBuyUnitPrice";
            this.txtBuyUnitPrice.Size = new System.Drawing.Size(100, 21);
            this.txtBuyUnitPrice.TabIndex = 2;
            // 
            // txtSellUnitPrice
            // 
            this.txtSellUnitPrice.Location = new System.Drawing.Point(316, 57);
            this.txtSellUnitPrice.Name = "txtSellUnitPrice";
            this.txtSellUnitPrice.Size = new System.Drawing.Size(100, 21);
            this.txtSellUnitPrice.TabIndex = 2;
            this.txtSellUnitPrice.TextChanged += new System.EventHandler(this.txtSellUnitPrice_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "总面积";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtTotalArea
            // 
            this.txtTotalArea.Location = new System.Drawing.Point(122, 24);
            this.txtTotalArea.Name = "txtTotalArea";
            this.txtTotalArea.Size = new System.Drawing.Size(100, 21);
            this.txtTotalArea.TabIndex = 2;
            this.txtTotalArea.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(45, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "购买总价";
            // 
            // txtBuyTotalPrice
            // 
            this.txtBuyTotalPrice.Enabled = false;
            this.txtBuyTotalPrice.Location = new System.Drawing.Point(122, 92);
            this.txtBuyTotalPrice.Name = "txtBuyTotalPrice";
            this.txtBuyTotalPrice.Size = new System.Drawing.Size(100, 21);
            this.txtBuyTotalPrice.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(244, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "卖出总价";
            // 
            // txtSellTotalPrice
            // 
            this.txtSellTotalPrice.Enabled = false;
            this.txtSellTotalPrice.Location = new System.Drawing.Point(316, 92);
            this.txtSellTotalPrice.Name = "txtSellTotalPrice";
            this.txtSellTotalPrice.Size = new System.Drawing.Size(100, 21);
            this.txtSellTotalPrice.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(27, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "营业税：差额*5.6%";
            // 
            // txtTaxYy
            // 
            this.txtTaxYy.Enabled = false;
            this.txtTaxYy.Location = new System.Drawing.Point(158, 18);
            this.txtTaxYy.Name = "txtTaxYy";
            this.txtTaxYy.Size = new System.Drawing.Size(100, 21);
            this.txtTaxYy.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(280, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "个人所得税：差额*20%";
            // 
            // txtTaxGrsd
            // 
            this.txtTaxGrsd.Enabled = false;
            this.txtTaxGrsd.Location = new System.Drawing.Point(429, 18);
            this.txtTaxGrsd.Name = "txtTaxGrsd";
            this.txtTaxGrsd.Size = new System.Drawing.Size(100, 21);
            this.txtTaxGrsd.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(51, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "契税：全额*3%";
            // 
            // txtTaxQs
            // 
            this.txtTaxQs.Enabled = false;
            this.txtTaxQs.Location = new System.Drawing.Point(158, 53);
            this.txtTaxQs.Name = "txtTaxQs";
            this.txtTaxQs.Size = new System.Drawing.Size(100, 21);
            this.txtTaxQs.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(280, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "土地增值税：差额*30%";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtTaxTdzz
            // 
            this.txtTaxTdzz.Enabled = false;
            this.txtTaxTdzz.Location = new System.Drawing.Point(429, 50);
            this.txtTaxTdzz.Name = "txtTaxTdzz";
            this.txtTaxTdzz.Size = new System.Drawing.Size(100, 21);
            this.txtTaxTdzz.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(27, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "印花税：全额*0.1%";
            // 
            // txtTaxYhs
            // 
            this.txtTaxYhs.Enabled = false;
            this.txtTaxYhs.Location = new System.Drawing.Point(158, 88);
            this.txtTaxYhs.Name = "txtTaxYhs";
            this.txtTaxYhs.Size = new System.Drawing.Size(100, 21);
            this.txtTaxYhs.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(69, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "毛利";
            // 
            // txtMl
            // 
            this.txtMl.Enabled = false;
            this.txtMl.Location = new System.Drawing.Point(122, 126);
            this.txtMl.Name = "txtMl";
            this.txtMl.Size = new System.Drawing.Size(100, 21);
            this.txtMl.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(256, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "总税收";
            // 
            // txtTotalTax
            // 
            this.txtTotalTax.Enabled = false;
            this.txtTotalTax.Location = new System.Drawing.Point(316, 126);
            this.txtTotalTax.Name = "txtTotalTax";
            this.txtTotalTax.Size = new System.Drawing.Size(100, 21);
            this.txtTotalTax.TabIndex = 2;
            this.txtTotalTax.TextChanged += new System.EventHandler(this.txtTotalTax_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Location = new System.Drawing.Point(471, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "净利";
            // 
            // txtJl
            // 
            this.txtJl.Enabled = false;
            this.txtJl.Location = new System.Drawing.Point(506, 126);
            this.txtJl.Name = "txtJl";
            this.txtJl.Size = new System.Drawing.Size(100, 21);
            this.txtJl.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTaxQs);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtTaxYhs);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtTaxYy);
            this.panel1.Controls.Add(this.txtTaxGrsd);
            this.panel1.Controls.Add(this.txtTaxTdzz);
            this.panel1.Location = new System.Drawing.Point(46, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 128);
            this.panel1.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Location = new System.Drawing.Point(46, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "税收明细";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 349);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtSellUnitPrice);
            this.Controls.Add(this.txtTotalArea);
            this.Controls.Add(this.txtSellTotalPrice);
            this.Controls.Add(this.txtJl);
            this.Controls.Add(this.txtTotalTax);
            this.Controls.Add(this.txtMl);
            this.Controls.Add(this.txtBuyTotalPrice);
            this.Controls.Add(this.txtBuyUnitPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "公寓交易计算器";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuyUnitPrice;
        private System.Windows.Forms.TextBox txtSellUnitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuyTotalPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSellTotalPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTaxYy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTaxGrsd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTaxQs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTaxTdzz;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTaxYhs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalTax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtJl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
    }
}

