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
    public partial class AdminOnly : Form
    {
        public AdminOnly()
        {
            InitializeComponent();
            UserAccountLbl.Text = Login.userAccountName;
            TypeLbl.Text = Login.type;
            UserDGV.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            UserDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            GetUsers();
            DisplayUsers();
            Color customColor = Color.FromArgb(255, 32, 100);
            this.BackColor = customColor;
            UserNameCb.Visible = false;
            UserNameTb.Visible = true;
        }
        private void Clear()
        {
            UserNameTb.Text = "";
            UserAccTb.Text = "";
            UserPassTb.Text = "";
            UserPhoneTb.Text = "";
        }
        int Key = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if ((string)UserTypeCb.SelectedItem == "Admin")
            {
                if (UserAccTb.Text == "" || UserPassTb.Text == "" || UserPhoneTb.Text == "" || UserNameTb.Text == "")
                {
                    MessageBox.Show("Thiếu Thông Tin");
                }
                else
                {
                    try
                    {
                        using (var context = new PetShopDbDataContext())
                        {
                            var newUser = new UserTbl
                            {
                                UserAcc = UserAccTb.Text,
                                UserPass = UserPassTb.Text,
                                UserType = UserTypeCb.Text,
                                UserName = UserNameTb.Text,
                                UserPhone = UserPhoneTb.Text,
                                UserDOB = UserDOBdate.Value.Date,
                            };

                            context.UserTbls.InsertOnSubmit(newUser);
                            context.SubmitChanges();
                        }

                        MessageBox.Show("Tài khoản đã được thêm");
                        DisplayUsers();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else //Nhan Vien
            {
                if (UserAccTb.Text == "" || UserPassTb.Text == "" || UserPhoneTb.Text == "")
                {
                    MessageBox.Show("Thiếu Thông Tin");
                }
                else
                {
                    try
                    {
                        using (var context = new PetShopDbDataContext())
                        {
                            var newUser = new UserTbl
                            {
                                UserAcc = UserAccTb.Text,
                                UserPass = UserPassTb.Text,
                                UserType = UserTypeCb.Text,
                                UserName = UserNameCb.Text,
                                UserPhone = UserPhoneTb.Text,
                                UserDOB = UserDOBdate.Value.Date,
                            };

                            context.UserTbls.InsertOnSubmit(newUser);
                            context.SubmitChanges();
                            var employee = context.EmployeeTbls.FirstOrDefault(emp => emp.EmpName == UserNameCb.Text && emp.EmpAcc == "Chưa Cấp");
                            if (employee != null)
                            {
                                employee.EmpAcc = "Đã Cấp";//Đã cấp tài khoản cho nhân viên
                                context.SubmitChanges();
                            }
                        }

                        MessageBox.Show("Tài khoản đã được thêm");
                        DisplayUsers();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

            

        private void GetUsers()
        {
            using (var context = new PetShopDbDataContext())
            {
                var query = from emp in context.EmployeeTbls
                            where emp.EmpAcc == "Chưa Cấp" // Chỉ hiển thị nhân viên chưa cấp tài khoản
                            select emp.EmpName;

                List<string> empNames = query.ToList();
                UserNameCb.DataSource = empNames;
            }
        }

        private void GetUserInfo()
        {
            using (var context = new PetShopDbDataContext())
            {
                string selected = (string)UserNameCb.SelectedValue;
                var user = context.EmployeeTbls.FirstOrDefault(c => c.EmpName == selected);

                if (user != null)
                {
                    UserPhoneTb.Text = user.EmpPhone;
                    UserDOBdate.Text = user.EmpDOB.ToString();
                }
            }
        }
        private void UserNameCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetUserInfo();
        }
        private void UserTypeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if((string)UserTypeCb.SelectedItem == "Nhân Viên")
            {
                UserNameCb.Visible = true;
                UserNameTb.Visible = false;
                UserPhoneTb.ReadOnly = true;
                UserDOBdate.Enabled = false;
                UserPhoneTb.Clear();
            }
            else
            {
                UserNameCb.Visible = false;
                UserNameTb.Visible = true;
                UserPhoneTb.ReadOnly = false;
                UserDOBdate.Enabled = true;
                UserPhoneTb.Clear();
                UserNameTb.Clear();
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserAccTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UserPassTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            UserTypeCb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            if ((string)UserTypeCb.SelectedItem == "Admin")//Logic
            {
                UserNameCb.Visible = false;
                UserNameTb.Visible = true;
                UserPhoneTb.ReadOnly = false;
                UserDOBdate.Enabled = true;
                UserNameTb.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();
                UserPhoneTb.Text = UserDGV.SelectedRows[0].Cells[5].Value.ToString();
                UserDOBdate.Text = UserDGV.SelectedRows[0].Cells[6].Value.ToString();
                if (UserAccTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            else
            {
                UserNameCb.Visible = true;
                UserNameTb.Visible = false;
                UserPhoneTb.ReadOnly = true;
                UserDOBdate.Enabled = false;
                UserNameCb.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();
                UserPhoneTb.Text = UserDGV.SelectedRows[0].Cells[5].Value.ToString();
                UserDOBdate.Text = UserDGV.SelectedRows[0].Cells[6].Value.ToString();
                if (UserAccTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if ((string)UserTypeCb.SelectedItem == "Admin")
            {
                if (Key == 0)
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần xóa");
                }
                else
                {
                    try
                    {
                        using (var context = new PetShopDbDataContext())
                        {
                            var userToDelete = context.UserTbls.FirstOrDefault(pr => pr.UserID == Key);

                            if (userToDelete != null)
                            {
                                context.UserTbls.DeleteOnSubmit(userToDelete);
                                context.SubmitChanges();
                                MessageBox.Show("Tài khoản đã được xóa");
                                DisplayUsers();
                                Clear();
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản không tồn tại");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else // Cần DK này để nếu như admin trùng tên nhân viên thì ko chỉnh nhầm cột tài khoản bên table employee
            {
                if (Key == 0)
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần xóa");
                }
                else
                {
                    try
                    {
                        using (var context = new PetShopDbDataContext())
                        {
                            var userToDelete = context.UserTbls.FirstOrDefault(pr => pr.UserID == Key);

                            if (userToDelete != null)
                            {
                                context.UserTbls.DeleteOnSubmit(userToDelete);
                                context.SubmitChanges();
                                MessageBox.Show("Tài khoản đã được xóa");
                                DisplayUsers();
                                Clear();
                                var employee = context.EmployeeTbls.FirstOrDefault(emp => emp.EmpName == UserNameCb.Text && emp.EmpAcc == "Đã Cấp");
                                if (employee != null)
                                {
                                    employee.EmpAcc = "Chưa Cấp";//Chỉnh thành “chưa cấp” vì tài khoản đã xóa
                                    context.SubmitChanges();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản không tồn tại");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            HistoryBills Obj = new HistoryBills();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Products Obj = new Products();
            Obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void DisplayUsers()
        {
            using (var context = new PetShopDbDataContext())
            {
                var users = from user in context.UserTbls
                            select user;
                UserDGV.DataSource = users.ToList();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DisplayUsers();
            SearchTb.Clear();
        }
        private void SearchTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            string namePr = SearchTb.Text;
            if (namePr == "") DisplayUsers();
            else
            {
                PetShopDbDataContext db = new PetShopDbDataContext();
                UserDGV.DataSource = db.UserTbls.Where(p => p.UserAcc.Contains(namePr)).ToList()
                    .Select((p, index) => new { p.UserID, p.UserAcc, p.UserPass, p.UserType, p.UserName, p.UserPhone, p.UserDOB }).OrderBy(p => p.UserAcc)
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
