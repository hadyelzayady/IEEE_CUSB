using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IEEECUSB
{
    public partial class ChangeAdminPW : Form
    {
        public ChangeAdminPW()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (newPass.Text != confirmNewPass.Text)
            {
                MessageBox.Show("New Passwords don't match!");
                return;
            }
            else
            {
                bool ret = var.controllerObj.ChangeAdminPassword(oldPass.Text, newPass.Text);
                if (ret)
                {
                    MessageBox.Show("Password is changed successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FtpLink.Text == "" || FtpUser.Text == "" || oldFtpUser.Text == "" || FtpPass.Text == "")
            {
                MessageBox.Show("Please Fill all fields!");
                return;
            }
            else
            {
                bool ret = var.controllerObj.ChangeFTPAccount(FtpLink.Text, FtpUser.Text, FtpPass.Text, oldFtpUser.Text);
                if (ret == true)
                {
                    MessageBox.Show("FTP Account is changed successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An Error Occured!");
                }
            }
        }
    }
}
