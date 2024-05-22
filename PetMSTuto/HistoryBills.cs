using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PetMSTuto
{
    public partial class HistoryBills : Form
    {
        private readonly PetShopDbDataContext db;
        public HistoryBills()
        {
            InitializeComponent();
            db = new PetShopDbDataContext();
            UserAccountLbl.Text = Login.userAccountName;
            TypeLbl.Text = Login.type;
            TransactionsDGV.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            TransactionsDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            DisplayTransactions();
            DisplayAllTrans();
            DisplayAllAmt();
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
        private void DisplayAllAmt()
        {
            using (var context = new PetShopDbDataContext())
            {
                var transactions = context.BillTbls.ToList();
                Dictionary<string, decimal> monthlyRevenue = new Dictionary<string, decimal>();
                foreach (var transaction in transactions)
                {
                    string month = transaction.BDate.Month.ToString();
                    if (!monthlyRevenue.ContainsKey(month))
                    {
                        monthlyRevenue.Add(month, 0);
                    }
                    monthlyRevenue[month] += transaction.Amt;
                }
                chartMonth.Series.Add("MonthlyRevenue");
                chartMonth.Series["MonthlyRevenue"].ChartType = SeriesChartType.Column;
                chartMonth.Series["MonthlyRevenue"]["PointWidth"] = "0.1";
                foreach (var item in monthlyRevenue)
                {
                    chartMonth.Series["MonthlyRevenue"].Points.AddXY("Tháng " + item.Key, item.Value);
                }
            }

        }
        private void DisplayAllTrans()
        {
            using (var context = new PetShopDbDataContext())
            {
                var transactions = context.BillTbls.ToList();
                Dictionary<string, int> monthlyTransactions = new Dictionary<string, int>();
                foreach (var transaction in transactions)
                {
                    string month = transaction.BDate.Month.ToString();
                    if (!monthlyTransactions.ContainsKey(month))
                    {
                        monthlyTransactions.Add(month, 0);
                    }
                    monthlyTransactions[month]++;
                }
                chartCountTrans.Series.Add("MonthlyTransactions");
                chartCountTrans.Series["MonthlyTransactions"].ChartType = SeriesChartType.Column;
                chartCountTrans.Series["MonthlyTransactions"]["PointWidth"] = "0.1";
                foreach (var item in monthlyTransactions)
                {
                    chartCountTrans.Series["MonthlyTransactions"].Points.AddXY("Tháng " + item.Key, item.Value);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Billings Obj = new Billings();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {
            Billings Obj = new Billings();
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DisplayTransactions();
            SearchTb.Clear();
        }
        private void SearchTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            string namePr = SearchTb.Text;
            if (namePr == "") DisplayTransactions();
            else
            {
                PetShopDbDataContext db = new PetShopDbDataContext();
                TransactionsDGV.DataSource = db.BillTbls.Where(p => p.CustName.ToString().Contains(namePr)).ToList()
                    .Select((p, index) => new { p.BNum, p.BDate, p.CustId, p.CustName, p.Amt }).OrderBy(p => p.CustName)
                    .ToList();
            }
        }

        private void DisplayTransactions()
        {
            var lshd = db.BillTbls.Select(x => new
            {
                x.BNum,
                x.BDate,
                x.CustId,
                x.CustName,
                x.Amt,
            });
            TransactionsDGV.DataSource = lshd;
        }


        private void PrintBtn_Click(object sender, EventArgs e)
        {
            PrintHistoryBills Obj = new PrintHistoryBills();
            Obj.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }
    }
}