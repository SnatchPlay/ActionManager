using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace WinFormAction
{
    public partial class RegisterForm : Form
    {
        public UserLogic userLogic = new UserLogic();
        public RegisterForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Login = textLogin.Text;
            string Password=textpass.Text;
            string Email=textEmail.Text;    
            userLogic.CreateNewUser(Login, Password, Email);
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();   
        }
    }
}
