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
    public partial class LoginForm : Form
    {
        UserLogic userLogic = new UserLogic();
        public LoginForm()
        {
            InitializeComponent();
             FormClosing += LoginForm_FormClosing;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userLogic.UserLogin(textBox1.Text, textBox2.Text) == true)
            {
                this.DialogResult = DialogResult.OK;
                //this.Hide();
                //MainForm mainForm = new MainForm();
                //mainForm.Show();
            }
            else
            {
                MessageBox.Show("Wrong data","Wrong data",MessageBoxButtons.OK);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
