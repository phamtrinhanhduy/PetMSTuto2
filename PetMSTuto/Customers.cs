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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            CustomerType();
            DisplayCustomers();
            UserAccountLbl.Text = Login.userAccountName;
            TypeLbl.Text = Login.type;
            CustomerDGV.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            CustomerDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
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
        void CustomerType() //Dung de dieu chinh loai khach hang
        {
            using (PetShopDbDataContext context = new PetShopDbDataContext())
            {
                var customers = context.CustomerTbls.ToList();

                foreach (var customer in customers)
                {
                    var totalAmount = context.BillTbls
                        .Where(bill => bill.CustId == customer.CustId)
                        .Sum(bill => (decimal?)bill.Amt);
                    if (totalAmount.HasValue)
                    {
                        if (totalAmount.Value < 3000000)
                            customer.CustType = "Đồng";
                        else if (totalAmount.Value >= 3000000 && totalAmount.Value < 8000000)
                            customer.CustType = "Bạc";
                        else if (totalAmount.Value >= 8000000 && totalAmount.Value < 15000000)
                            customer.CustType = "Vàng";
                        else
                            customer.CustType = "Kim Cương";
                    }
                    else
                    {
                        customer.CustType = "Đồng";
                    }
                    context.SubmitChanges();
                }
            }
        }
        private void Clear()
        {
            CustNameTb.Text = "";
            CustAddTb.Text = "";
            CustPhoneTb.Text = "";
        }
        int Key = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "")
            {
                MessageBox.Show("Thiếu Thông Tin");
            }
            else
            {
                try
                {
                    using (var context = new PetShopDbDataContext())
                    {
                        var newCustomer = new CustomerTbl
                        {
                            CustName = CustNameTb.Text,
                            CustAdd = CustAddTb.Text,
                            CustPhone = CustPhoneTb.Text,
                            CustType = "Đồng",
                        };

                        context.CustomerTbls.InsertOnSubmit(newCustomer);
                        context.SubmitChanges();
                    }

                    MessageBox.Show("Khách hàng đã được thêm !");
                    DisplayCustomers();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustNameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustAddTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CustPhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (CustNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        //private void DeleteBtn_Click(object sender, EventArgs e)
        //{ Do khach hang co the ghe lai vao lan sau de mua hang hoac cac
        //thong tin khach hang trong hoa don da duoc luu lai nen khong nen co chuc nang xoa
        //}

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "")
            {
                MessageBox.Show("Thiếu Thông Tin");
            }
            else
            {
                try
                {
                    using (var context = new PetShopDbDataContext())
                    {
                        var customerToUpdate = context.CustomerTbls.FirstOrDefault(cust => cust.CustId == Key);

                        if (customerToUpdate != null)
                        {
                            customerToUpdate.CustName = CustNameTb.Text;
                            customerToUpdate.CustAdd = CustAddTb.Text;
                            customerToUpdate.CustPhone = CustPhoneTb.Text;

                            context.SubmitChanges();
                            MessageBox.Show("Thông tin khách hàng đã được cập nhật");
                            DisplayCustomers();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Khách hàng không tồn tại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Products Obj = new Products();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Billings Obj = new Billings();
            Obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SearchTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            string namePr = SearchTb.Text;
            if (namePr == "") DisplayCustomers();
            else
            {
                PetShopDbDataContext db = new PetShopDbDataContext();
                CustomerDGV.DataSource = db.CustomerTbls.Where(p => p.CustName.Contains(namePr)).ToList()
                    .Select((p, index) => new { p.CustId, p.CustName, p.CustAdd, p.CustPhone,p.CustType}).OrderBy(p => p.CustName)
                    .ToList();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchTb.Clear();
            DisplayCustomers();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Products Obj = new Products();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
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

        private void label5_Click_1(object sender, EventArgs e)
        {
            AdminOnly Obj = new AdminOnly();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DisplayCustomers()
        {
            using (var context = new PetShopDbDataContext())
            {
                var customers = from customer in context.CustomerTbls
                                select customer;
                CustomerDGV.DataSource = customers.ToList();
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
