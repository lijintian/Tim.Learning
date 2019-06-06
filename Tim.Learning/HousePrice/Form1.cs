using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HousePrice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //总面积
            decimal totalArea = Convert.ToDecimal(txtTotalArea.Text);
            //买入单价
            decimal buyUnitPrice = Convert.ToDecimal(txtBuyUnitPrice.Text);
            //卖出单价
            decimal sellUnitPrice = Convert.ToDecimal(txtSellUnitPrice.Text);



            //购买总价
            decimal buyTotalPrice = (buyUnitPrice * totalArea);
            txtBuyTotalPrice.Text = buyTotalPrice.ToString();

            //卖出总价
            decimal sellTotalPrice = (sellUnitPrice * totalArea);
            txtSellTotalPrice.Text = sellTotalPrice.ToString();

            //差额
            decimal balance = sellTotalPrice - buyTotalPrice;

            //营业税：差额*5.6%
            decimal taxYy = balance * (decimal)0.056;
            txtTaxYy.Text = taxYy.ToString();

            //个人所得税：差额*20%
            decimal taxGrsd = balance * (decimal)0.2;
            txtTaxGrsd.Text = taxGrsd.ToString();

            //契税：全额*3%
            decimal taxQs= sellTotalPrice * (decimal)0.03;
            txtTaxQs.Text = taxQs.ToString();

            //土地增值税：差额*30%
            decimal taxTdzz = balance * (decimal)0.3;
            txtTaxTdzz.Text = taxTdzz.ToString();

            //印花税：全额*0.1%
            decimal taxYh = sellTotalPrice * (decimal)0.001;
            txtTaxYhs.Text = taxYh.ToString();
            //毛利
            decimal ml = sellTotalPrice - buyTotalPrice;
            txtMl.Text = ml.ToString();
            //总税
            decimal totalTax = taxYy + taxGrsd + taxQs + taxTdzz + taxYh;
            txtTotalTax.Text = totalTax.ToString();

            //净利=毛利-总税
            decimal jl = ml - totalTax;
            txtJl.Text = jl.ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalTax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSellUnitPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
