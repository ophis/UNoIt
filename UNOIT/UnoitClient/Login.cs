using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientBLL;

namespace UnoitClient
{
    public partial class Login : Form
    {
        public event EventHandler Logged;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                lblUsernameCheck.Text = "用户名为空";
                lblUsernameCheck.ForeColor = Color.Red;
                btnLogin.Enabled = false;
            }
            else 
            {
                lblUsernameCheck.Visible = false;
                btnLogin.Enabled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ClientBLL.UnoitServer.LoginStateFlag loginState =
                ClientAgent.Login(txtUsername.Text,txtPassword.Text);
            if (loginState == ClientBLL.UnoitServer.LoginStateFlag.USERSUCCESS)
            {
                ClientAgent.username = txtUsername.Text;
                this.Close();
            }
            else if(loginState == ClientBLL.UnoitServer.LoginStateFlag.ACCOUNTFREEZE){
                MessageBox.Show("账户被冻结", "错误");                
            }
            else if (loginState == ClientBLL.UnoitServer.LoginStateFlag.PASSWORDERROR)
            {
                MessageBox.Show("密码错误", "错误");
            }
        }

        private void txtUsername_MouseEnter(object sender, EventArgs e)
        {
            //txtUsername.BorderStyle = ;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logged(sender, new EventArgs());
            this.Hide();
        }
    }
}
