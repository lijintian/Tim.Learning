using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSecond
{
    public partial class DiscountResult : Form
    {
 
        public decimal currentVal = 0M;
        public decimal target = 10.00M;


        public int startLocationY = 0;

        public DiscountResult()
        {
            InitializeComponent();
        }

        private void DiscountResult_Load(object sender, EventArgs e)
        {
            var startLocationX= this.Location.X;  
            this.Location = new Point(startLocationX, startLocationY);

            if (currentVal < 10)
            {
                this.lbTime.Text ="0"+currentVal.ToString("0.00");
            }
            else
            {
                this.lbTime.Text = currentVal.ToString("0.00");
            }
           

            var discountSettings = System.Configuration.ConfigurationManager.AppSettings["Discounts"];

            var discounts = discountSettings.Split('|');

            var discountInfos = new List<DiscountInfo>();

            foreach (var discount in discounts)
            {
                var devationBegin = discount.Split('$')[0].Split('-')[0];
                var devationEnd = discount.Split('$')[0].Split('-')[1];
                var msgs = discount.Split('$')[1].Split('#').ToList();
                var imgPaths = discount.Split('$')[2].Split('#').ToList();

                discountInfos.Add(new DiscountInfo()
                {
                    DeviationBegin = Convert.ToDecimal(devationBegin),
                    DeviationEnd = Convert.ToDecimal(devationEnd),
                    Msgs=msgs,
                    Imgs= imgPaths
                });

            }

            var deviation = Math.Abs(target-currentVal);

            var curDirect = System.IO.Directory.GetCurrentDirectory();

            var matchDiscountInfo=discountInfos.FirstOrDefault(x => x.DeviationBegin <= deviation && x.DeviationEnd >= deviation);
            if (matchDiscountInfo == null)
            {
                var defaultNoDiscount = System.Configuration.ConfigurationManager.AppSettings["DefaultNoDiscount"];

                var msgs = defaultNoDiscount.Split('$')[0].Split('#').ToList();
                var imgPaths = defaultNoDiscount.Split('$')[1].Split('#').ToList();

                var randomImg = new Random().Next(0, imgPaths.Count);
                var randomMsg = new Random().Next(0, msgs.Count);

                var imgPath = imgPaths.Skip(randomImg).Take(1).FirstOrDefault();
                this.pbResult.Image = new Bitmap(curDirect + imgPath);
                this.lbMsg.Text = msgs.Skip(randomMsg).Take(1).FirstOrDefault();
            }
            else
            {
            

                var randomImg = new Random().Next(0, matchDiscountInfo.Imgs.Count);
                var randomMsg = new Random().Next(0, matchDiscountInfo.Msgs.Count);
                var imgPath = matchDiscountInfo.Imgs.Skip(randomImg).Take(1).FirstOrDefault();

                this.pbResult.Image = new Bitmap(curDirect + imgPath);
                this.lbMsg.Text = matchDiscountInfo.Msgs.Skip(randomMsg).Take(1).FirstOrDefault();
            }
            

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class DiscountInfo
    {
        public decimal DeviationBegin { get; set; }

        public decimal DeviationEnd { get; set; }

        public List<string> Msgs { get; set; }

        public List<string> Imgs { get; set; }
    }
}
