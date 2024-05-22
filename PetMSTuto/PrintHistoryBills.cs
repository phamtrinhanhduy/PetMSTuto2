using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetMSTuto
{
    public partial class PrintHistoryBills : Form
    {
        public PrintHistoryBills()
        {
            InitializeComponent();
        }

        private void PrintHistoryBills_Load(object sender, EventArgs e)
        {
            PetShopDbDataContext dbContext = new PetShopDbDataContext();
            var query = from bill in dbContext.BillTbls
                        select new
                        {
                            bill.BNum,
                            BDate = bill.BDate.ToShortDateString(),
                            bill.CustId,
                            bill.CustName,
                            bill.Amt
                        };
            DataTable dt = new DataTable();
            dt.Columns.Add("BNum");
            dt.Columns.Add("BDate");
            dt.Columns.Add("CustId");
            dt.Columns.Add("CustName");
            dt.Columns.Add("Amt");
            ReportParameter rp1 = new ReportParameter("rp1", Login.userAccountName);
            this.reportViewer1.LocalReport.SetParameters(rp1);
            foreach (var item in query)
            {
                dt.Rows.Add(item.BNum, item.BDate, item.CustId, item.CustName, item.Amt);
            }
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ls", dt));
            this.reportViewer1.RefreshReport();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
