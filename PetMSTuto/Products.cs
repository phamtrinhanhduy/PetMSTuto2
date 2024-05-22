using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetMSTuto
{
    public partial class Products : Form
    {
        private TimeSpan remainingTime;

        public Products()
        {
            InitializeComponent();
            UserAccountLbl.Text = Login.userAccountName;
            TypeLbl.Text = Login.type;
            ProductDGV.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            ProductDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            DisplayProducts();
            remainingTime = TimeSpan.FromHours(24);

            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Interval = 1000;
            timer1.Elapsed += timer1_Elapsed;
            timer1.Start();
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
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)// Dem nguoc so ngay con lai trong thang
        {
            if (progress.IsHandleCreated)
            {
                progress.Invoke((MethodInvoker)delegate
                {
                    DateTime today = DateTime.Today;
                    DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month), 23, 59, 59);
                    TimeSpan remainingTime = endOfMonth - today;

                    int remainingDays = remainingTime.Days;
                    progress.Text = "Còn " + remainingDays.ToString() + " Ngày";
                    progress.Maximum = DateTime.DaysInMonth(today.Year, today.Month);
                    double percentage = (DateTime.DaysInMonth(today.Year, today.Month) - remainingDays) / (double)DateTime.DaysInMonth(today.Year, today.Month) * 100;
                    progress.Value = DateTime.DaysInMonth(today.Year, today.Month) - remainingDays;

                    if (remainingTime.TotalSeconds <= 0)
                    {
                        ((System.Timers.Timer)sender).Stop();
                    }
                });
            }
        }

        private void Clear()
        {
            PrNameTb.Text = "";
            CatCb.SelectedIndex = 0;
            QtyTb.Text = "";
            PriceTb.Text = "";
        }
        int Key = 0;

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PrNameTb.Text == "" || CatCb.SelectedIndex == -1 || QtyTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Thiếu Thông Tin");
            }
            else
            {
                try
                {
                    using (var context = new PetShopDbDataContext())
                    {
                        var newProduct = new ProductTbl
                        {
                            PrName = PrNameTb.Text,
                            PrCat = CatCb.Text,
                            PrQty = int.Parse(QtyTb.Text),
                            PrPrice = int.Parse(PriceTb.Text),
                        };

                        context.ProductTbls.InsertOnSubmit(newProduct);
                        context.SubmitChanges();
                    }

                    MessageBox.Show("Vật nuôi/Thức ăn/Vật dụng đã được thêm !");
                    DisplayProducts();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PrNameTb.Text = ProductDGV.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.Text = ProductDGV.SelectedRows[0].Cells[2].Value.ToString();
            QtyTb.Text = ProductDGV.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = ProductDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (PrNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Vui lòng chọn Vật nuôi/Thức ăn/Vật dụng cần xóa");
            }
            else
            {
                try
                {
                    using (var context = new PetShopDbDataContext())
                    {
                        var productToDelete = context.ProductTbls.FirstOrDefault(pr => pr.PrId == Key);

                        if (productToDelete != null)
                        {
                            context.ProductTbls.DeleteOnSubmit(productToDelete);
                            context.SubmitChanges();
                            MessageBox.Show("Vật nuôi/Thức ăn/Vật dụng đã được xóa");
                            DisplayProducts();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Vật nuôi/Thức ăn/Vật dụng không tồn tại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PrNameTb.Text == "" || CatCb.SelectedIndex == -1 || QtyTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Thiếu Thông Tin");
            }
            else
            {
                try
                {
                    using (var context = new PetShopDbDataContext())
                    {
                        var productToUpdate = context.ProductTbls.FirstOrDefault(pr => pr.PrId == Key);

                        if (productToUpdate != null)
                        {
                            productToUpdate.PrName = PrNameTb.Text;
                            productToUpdate.PrCat = CatCb.Text;
                            productToUpdate.PrQty = int.Parse(QtyTb.Text);
                            productToUpdate.PrPrice = int.Parse(PriceTb.Text);

                            context.SubmitChanges();
                            MessageBox.Show("Thông tin Vật nuôi/Thức ăn/Vật dụng đã được cập nhật");
                            DisplayProducts();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Vật nuôi/Thức ăn/Vật dụng không tồn tại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SearchTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            string namePr= SearchTb.Text;
            if (namePr == "") DisplayProducts();
            else
            {
                PetShopDbDataContext db = new PetShopDbDataContext();
                ProductDGV.DataSource = db.ProductTbls.Where(p => p.PrName.Contains(namePr)).ToList()
                    .Select((p, index) => new { p.PrId, p.PrName, p.PrCat, p.PrQty, p.PrPrice }).OrderBy(p => p.PrName)
                    .ToList();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
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

        private void label7_Click_1(object sender, EventArgs e)
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

        private void DisplayProducts()
        {
            using (var context = new PetShopDbDataContext())
            {
                var prs = from pr in context.ProductTbls
                          select pr;
                ProductDGV.DataSource = prs.ToList();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchTb.Clear();
            DisplayProducts();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }
    }
}
