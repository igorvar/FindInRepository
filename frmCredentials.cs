using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FIR
{
    public partial class frmCredentials : Form
    {
        private frmCredentials()
        {
            InitializeComponent();
        }
        public frmCredentials(string UserName, string Password):this()
        {
            //this.UserName = UserName;
            txtPassword.Text = Password;
            txtUser.Text = UserName;
        }
        string userName;
        public string UserName { get{return userName;} /*set;*/ }

        string password;
        public string Password { get { return password; } /*set;*/ }

        private void btnOk_Click(object sender, EventArgs e)
        {
            password = txtPassword.Text;
            userName = txtUser.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
