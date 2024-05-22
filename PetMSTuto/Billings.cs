using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections;
using System.Data.Linq;
using System.Text.RegularExpressions;

namespace PetMSTuto
{
    public partial class Billings : Form
    {
        int count = 0;
        int CustVouncher;
        int Total;
        static public string AfterVouncher;
        static public string Vouncher;
        double percent;
        private readonly PetShopDbDataContext db;
        public Billings()
        {
            InitializeComponent();
            db = new PetShopDbDataContext();
            db.ExecuteCommand("DELETE FROM InvoiceTbl");
            db.ExecuteCommand("DBCC CHECKIDENT (InvoiceTbl, RESEED, 0)");
            db.SubmitChanges();
            UserAccountLbl.Text = Login.userAccountName;
            TypeLbl.Text = Login.type;
            ProductsDGV.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            ProductsDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            BillDGV.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            BillDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            GetCustomers();
            DisplayProducts();
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
        private void DisplayInvoices()
        {
            var dshd = db.InvoiceTbls.Select(x => new
            {
                x.INum,
                x.PrName,
                x.PrQty,
                x.PrPrice,
                x.Tamt,
            });
            BillDGV.DataSource = dshd;
        }
        private void GetCustomers()
        {
            using (var context = new PetShopDbDataContext())
            {
                var query = from customer in context.CustomerTbls
                            select customer.CustId;

                List<int> custIds = query.ToList();
                CustIdCb.ValueMember = "CustId";
                CustIdCb.DataSource = custIds;
            }

        }

        private void GetCustName()
        {
            using (var context = new PetShopDbDataContext())
            {
                int selectedCustId = (int)CustIdCb.SelectedValue;
                var customer = context.CustomerTbls.FirstOrDefault(c => c.CustId == selectedCustId);

                if (customer != null)
                {
                    CustNameTb.Text = customer.CustName;
                }
            }
        }
        private void GetCustType()
        {
            using (var context = new PetShopDbDataContext())
            {
                int selectedCustType = (int)CustIdCb.SelectedValue;
                var customer = context.CustomerTbls.FirstOrDefault(c => c.CustId == selectedCustType);

                if (customer != null)
                {
                    CustTypeTb.Text = customer.CustType;
                }
            }
        }
        private void UpdateStock()
        {
            try
            {
                int NewQty = Stock - Convert.ToInt32(QtyTb.Text);

                using (var context = new PetShopDbDataContext())
                {
                    var product = context.ProductTbls.FirstOrDefault(p => p.PrId == Key);
                    if (product != null)
                    {
                        product.PrQty = NewQty;
                        context.SubmitChanges();
                        DisplayProducts();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm để cập nhật");
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int GrdTotal = 0;

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void InsertBill()
        {
            try
            {
                using (var context = new PetShopDbDataContext())
                {
                    int custId = Convert.ToInt32(CustIdCb.SelectedValue);
                    var newBill = new BillTbl
                    {
                        BDate = DateTime.Today.Date,
                        CustId = custId,
                        CustName = CustNameTb.Text,
                        Amt = Total
                    };

                    context.BillTbls.InsertOnSubmit(newBill);
                    context.SubmitChanges();
                }
                //Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (QtyTb.Text == "" || CustNameTb.Text == "" || PrNameTb.Text == "" || QtyTb.Text == "" || PrPriceTb.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
            else if (Convert.ToInt32(QtyTb.Text) <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
            }
            else if (Convert.ToInt32(QtyTb.Text) > Stock)
            {
                MessageBox.Show("Số lượng không còn đủ trong cửa hàng!");
            }
            else
            {
                count++;
                int total = Convert.ToInt32(QtyTb.Text) * Convert.ToInt32(PrPriceTb.Text);
                try
                {
                    using (var context = new PetShopDbDataContext())
                    {
                        var newBill = new InvoiceTbl
                        {
                            PrName = PrNameTb.Text,
                            PrQty = int.Parse(QtyTb.Text),
                            PrPrice = int.Parse(PrPriceTb.Text),
                            Tamt = total,
                        };
                        GrdTotal = GrdTotal + total;
                        TotalLbl.Text = GrdTotal.ToString() + " VND";
                        if (DateTime.Now.Month == 5)
                        {
                            VounTb.Text = (CustVouncher + 5).ToString() + " %";
                            Vouncher = (CustVouncher + 5).ToString() + " %";
                            AfterVounTb.Text = (GrdTotal * (100 - (CustVouncher + 5)) / 100).ToString() + " VND";
                            AfterVouncher = (GrdTotal * (100 - (CustVouncher + 5)) / 100).ToString() + " VND";
                            Total = GrdTotal * (100 - (CustVouncher + 5)) / 100;
                        }
                        else// Het uu dai thang 5 thi bo khuyen mai 5%
                        {
                            VounTb.Text = CustVouncher.ToString() + " %";
                            Vouncher = CustVouncher.ToString() + " %";
                            AfterVounTb.Text = (GrdTotal * (100 - (CustVouncher)) / 100).ToString() + " VND";
                            AfterVouncher = (GrdTotal * (100 - (CustVouncher)) / 100).ToString() + " VND";
                            Total = GrdTotal * (100 - (CustVouncher)) / 100;
                        }
                        UpdateStock();
                        //Reset();
                        //Khong sai reset vi can giu lai ten khach hang neu mua tiep
                        PrNameTb.Text = "";
                        QtyTb.Text = "";
                        //CustNameTb.Text = "";
                        PrPriceTb.Text = "";
                        Stock = 0;
                        Key = 0;
                        context.InvoiceTbls.InsertOnSubmit(newBill);
                        context.SubmitChanges();
                    }

                    MessageBox.Show("Đã thêm vào hóa đơn");
                    DisplayInvoices();
                    //Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void CustIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustName();
            GetCustType();
            if(CustTypeTb.Text == "Đồng")
            {
                CustVouncher = 0;
            }
            else if (CustTypeTb.Text == "Bạc")
            {
                CustVouncher = 3;
            }
            else if (CustTypeTb.Text == "Vàng")
            {
                CustVouncher = 5;
            }
            else
            {
                CustVouncher = 10;
            }
        }
        int Key = 0, Stock = 0;
        private void PrintBtn_Click_1(object sender, EventArgs e)
        {
            if (count > 0) // Kiem tra xem trong hoa don co thong tin hay chua
            {
                PrintInvoice Obj = new PrintInvoice();
                Obj.Show();
                PetShopDbDataContext db = new PetShopDbDataContext();
                db.ExecuteCommand("DELETE FROM InvoiceTbl");
                db.ExecuteCommand("DBCC CHECKIDENT (InvoiceTbl, RESEED, 0)");
                db.SubmitChanges();
                DisplayInvoices();
                InsertBill();
                GrdTotal = 0;
                TotalLbl.Text = "";
                AfterVounTb.Text = "";
                VounTb.Text = "";
                CustNameTb.Text = "";
                CustTypeTb.Text = "";
                count = 0;
            }
            else
            {
                MessageBox.Show("Thiếu thông tin để in hóa đơn!");
            }
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
        private void SearchTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            string namePr = SearchTb.Text;
            if (namePr == "") DisplayProducts();
            else
            {
                PetShopDbDataContext db = new PetShopDbDataContext();
                ProductsDGV.DataSource = db.ProductTbls.Where(p => p.PrName.Contains(namePr)).ToList()
                    .Select((p, index) => new { p.PrId, p.PrName, p.PrCat, p.PrQty, p.PrPrice }).OrderBy(p => p.PrName)
                    .ToList();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DisplayProducts();
            SearchTb.Clear();
        }

        private void DisplayProducts()
        {
            using (var context = new PetShopDbDataContext())
            {
                var prs = from pr in context.ProductTbls
                            select pr;
                ProductsDGV.DataSource = prs.ToList();
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }

        private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PrNameTb.Text = ProductsDGV.SelectedRows[0].Cells[1].Value.ToString();
            Stock = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[3].Value.ToString());
            PrPriceTb.Text = ProductsDGV.SelectedRows[0].Cells[4].Value.ToString();
            if(PrNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Reset()
        {
            PrNameTb.Text = "";
            QtyTb.Text = "";
            CustNameTb.Text = "";
            PrPriceTb.Text = "";
            CustTypeTb.Text = "";
            Stock = 0;
            Key = 0;
        }
    }
}
