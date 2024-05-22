using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetMSTuto
{
    public partial class Homes : Form
    {
        public Homes()
        {
            InitializeComponent();
            UserAccountLbl.Text = Login.userAccountName;
            TypeLbl.Text = Login.type;
            CountDogs();
            CountCats();
            CustomerOTM();
            CountBirds();
            CountRabbits();
            if (TypeLbl.Text == "Nhân Viên")
            {
                AccP.Visible = false;
                HisP.Visible = false;
                ExP.Location = new Point(35, 458);
            }
            else
            {
                Color customColor = Color.FromArgb(255, 32, 100);
                this.BackColor = customColor;
            }
        }
        private void CountDogs()
        {
            using (var context = new PetShopDbDataContext())
            {
                var totalDogQty = (from product in context.ProductTbls
                                   where product.PrCat == "Chó"
                                   select (int?)product.PrQty).Sum() ?? 0;

                DogsLbl.Text = totalDogQty.ToString();
            }
        }
        private void CountCats()
        {
            using (var context = new PetShopDbDataContext())
            {
                var totalCatQty = (from product in context.ProductTbls
                                   where product.PrCat == "Mèo"
                                   select (int?)product.PrQty).Sum() ?? 0;

                CatsLbl.Text = totalCatQty.ToString();
            }
        }
        private void CountRabbits()
        {
            using (var context = new PetShopDbDataContext())
            {
                var totalCatQty = (from product in context.ProductTbls
                                   where product.PrCat == "Thỏ"
                                   select (int?)product.PrQty).Sum() ?? 0;

                RabbitsLbl.Text = totalCatQty.ToString();
            }
        }
        private void CountBirds()
        {
            using (var context = new PetShopDbDataContext())
            {
                var totalBirdQty = (from product in context.ProductTbls
                                    where product.PrCat == "Chim"
                                    select (int?)product.PrQty).Sum() ?? 0;

                BirdsLbl.Text = totalBirdQty.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Products Obj = new Products();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Billings Obj = new Billings();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            HistoryBills Obj = new HistoryBills();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminOnly Obj = new AdminOnly();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CustomerOTM()
        {
            using (var db = new PetShopDbDataContext())
            {
                var custOfTheMonth =
                    from bill in db.BillTbls
                    group bill by new { bill.CustId, bill.CustName } into custGroup
                    orderby custGroup.Sum(b => b.Amt) descending
                    select new
                    {
                        CustName = custGroup.Key.CustName,
                        TotalAmount = custGroup.Sum(b => b.Amt)
                    };
                var topCustomer = custOfTheMonth.FirstOrDefault();

                if (topCustomer != null)
                {
                    CustOTM.Text = topCustomer.CustName;
                }
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }
    }
}
