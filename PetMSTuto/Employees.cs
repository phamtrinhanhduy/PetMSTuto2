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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            DisplayEmployees();
            UserAccountLbl.Text = Login.userAccountName;
            TypeLbl.Text = Login.type;
            EmployeesDGV.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            EmployeesDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            if (TypeLbl.Text == "Nhân Viên")
            {
                EmpNameTb.ReadOnly = true;
                EmpDOB.Enabled = false;
                EmpAddTb.ReadOnly = true;
                EmpPhoneTb.ReadOnly = true;
                SaveBtn.Visible = false;
                EditBtn.Visible = false;
                DeleteBtn.Visible = false;
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


        private void Clear()
        {
            EmpNameTb.Text = "";
            EmpAddTb.Text = "";
            EmpPhoneTb.Text = "";
        }
        int Key = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "" )
            {
                MessageBox.Show("Thiếu Thông Tin");
            }
            else
            {
                try
                {
                    using (var context = new PetShopDbDataContext())
                    {
                        var newEmployee = new EmployeeTbl
                        {
                            EmpName = EmpNameTb.Text,
                            EmpAdd = EmpAddTb.Text,
                            EmpDOB = EmpDOB.Value.Date,
                            EmpPhone = EmpPhoneTb.Text,
                            EmpAcc = "Chưa Cấp",
                        };

                        context.EmployeeTbls.InsertOnSubmit(newEmployee);
                        context.SubmitChanges();
                    }

                    MessageBox.Show("Nhân viên đã được thêm");
                    DisplayEmployees();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void EmployeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeesDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddTb.Text = EmployeesDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpDOB.Text = EmployeesDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhoneTb.Text = EmployeesDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }




        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "" )
            {
                MessageBox.Show("Thiếu Thông Tin");
            }
            else
            {
                try
                {
                    using (var context = new PetShopDbDataContext())
                    {
                        var employeeToUpdate = context.EmployeeTbls.FirstOrDefault(emp => emp.EmpNum == Key);

                        if (employeeToUpdate != null)
                        {
                            employeeToUpdate.EmpName = EmpNameTb.Text;
                            employeeToUpdate.EmpAdd = EmpAddTb.Text;
                            employeeToUpdate.EmpDOB = EmpDOB.Value.Date;
                            employeeToUpdate.EmpPhone = EmpPhoneTb.Text;

                            context.SubmitChanges();
                            MessageBox.Show("Thông tin nhân viên đã được cập nhật");
                            DisplayEmployees();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên không tồn tại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa");
            }
            else
            {
                try
                {
                    using (var context = new PetShopDbDataContext())
                    {
                        var employeeToDelete = context.EmployeeTbls.FirstOrDefault(emp => emp.EmpNum == Key);

                        if (employeeToDelete != null)
                        {
                            context.EmployeeTbls.DeleteOnSubmit(employeeToDelete);
                            context.SubmitChanges();
                            MessageBox.Show("Nhân viên đã được xóa");
                            DisplayEmployees();
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên không tồn tại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void DisplayEmployees()
        {
            using (var context = new PetShopDbDataContext())
            {
                var emps = from emp in context.EmployeeTbls
                           select emp;
                EmployeesDGV.DataSource = emps.ToList();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            SearchTb.Clear();
            DisplayEmployees();
        }
        private void SearchTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            string namePr = SearchTb.Text;
            if (namePr == "") DisplayEmployees();
            else
            {
                PetShopDbDataContext db = new PetShopDbDataContext();
                EmployeesDGV.DataSource = db.EmployeeTbls.Where(p => p.EmpName.Contains(namePr)).ToList()
                    .Select((p, index) => new { p.EmpNum, p.EmpName, p.EmpAdd, p.EmpDOB, p.EmpPhone, p.EmpAcc }).OrderBy(p => p.EmpName)
                    .ToList();
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
