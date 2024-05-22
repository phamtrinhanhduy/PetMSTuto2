using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PetMSTuto
{
    public partial class Login : Form
    {
        static public string userAccountName;
        static public string type;
        public Login()
        {
            InitializeComponent();
            NoteLbl.Visible = false;
            PasswordTb.UseSystemPasswordChar = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UsernameTb.Clear();
            PasswordTb.Clear();
            NoteLbl.Text = "";  
        }
        private void ShowPassChk_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassChk.Checked) PasswordTb.UseSystemPasswordChar = false;
            else PasswordTb.UseSystemPasswordChar = true;
        }
        private void SaveInfoChk_CheckedChanged(object sender, EventArgs e)
        {
            if (UsernameTb.Text != "" && PasswordTb.Text != "")
            {
                if (SaveInfoChk.Checked == true)
                {
                    string users = UsernameTb.Text;
                    string pwd = PasswordTb.Text;
                    Properties.Settings.Default.username = users;
                    Properties.Settings.Default.password = pwd;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTb.Text == "" || PasswordTb.Text == "")
            {
                NoteLbl.Visible = true;
                NoteLbl.Text = "Vui lòng điền đầy đủ thông tin !";
            }
            else
            {
                bool flag = false;
                string tk = UsernameTb.Text.Trim();
                string mk = PasswordTb.Text.Trim();

                using (var context = new PetShopDbDataContext())
                {
                    var user = context.UserTbls.FirstOrDefault(u => u.UserAcc == tk && u.UserPass == mk);

                    if (user != null)
                    {
                        flag = true;
                        UsernameTb.ResetText();
                        PasswordTb.ResetText();
                        type = user.UserType;
                        userAccountName = user.UserName;
                    }
                }

                if (!flag)
                {
                    NoteLbl.Text = "Tài khoản hoặc mật khẩu không đúng!";
                    NoteLbl.Visible = true;
                }
                else
                {
                    SoundPlayer spButtonSound = new SoundPlayer();
                    spButtonSound.SoundLocation = "SoundBtn.wav";
                    spButtonSound.Play();
                    Homes Obj = new Homes();
                    Obj.Show();
                    this.Hide();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            UsernameTb.Text = Properties.Settings.Default.username;
            PasswordTb.Text = Properties.Settings.Default.password;
            if(Properties.Settings.Default.username != "")
            {
                SaveInfoChk.Checked = true;
            }
        }
    }
}
