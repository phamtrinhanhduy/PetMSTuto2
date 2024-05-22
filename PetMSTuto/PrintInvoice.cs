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
    public partial class PrintInvoice : Form
    {
        public PrintInvoice()
        {
            InitializeComponent();
        }

        private void PrintInvoice_Load(object sender, EventArgs e)
        {
            PetShopDbDataContext dbContext = new PetShopDbDataContext();
            var query = from invoice in dbContext.InvoiceTbls
                        select new
                        {
                            invoice.INum,
                            invoice.PrName,
                            invoice.PrQty,
                            invoice.PrPrice,
                            invoice.Tamt
                        };
            DataTable dt = new DataTable();
            dt.Columns.Add("INum");
            dt.Columns.Add("PrName");
            dt.Columns.Add("PrQty");
            dt.Columns.Add("PrPrice");
            dt.Columns.Add("Tamt");
            ReportParameter para1 = new ReportParameter("para1", Login.userAccountName);
            this.reportViewer1.LocalReport.SetParameters(para1);
            if (DateTime.Now.Month == 5)
            {
                ReportParameter para2 = new ReportParameter("para2", Billings.Vouncher);
                this.reportViewer1.LocalReport.SetParameters(para2);
                ReportParameter para3 = new ReportParameter("para3", Billings.AfterVouncher);
                this.reportViewer1.LocalReport.SetParameters(para3);
            }
            else
            {
                ReportParameter para2 = new ReportParameter("para2", Billings.Vouncher);
                this.reportViewer1.LocalReport.SetParameters(para2);
                ReportParameter para3 = new ReportParameter("para3", Billings.AfterVouncher);
                this.reportViewer1.LocalReport.SetParameters(para3);
            }
            foreach (var item in query)
            {
                dt.Rows.Add(item.INum, item.PrName, item.PrQty, item.PrPrice, item.Tamt);
            }
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            this.reportViewer1.RefreshReport();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
