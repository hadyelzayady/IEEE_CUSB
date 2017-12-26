using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.Mail;
namespace IEEECUSB
{
    public partial class Login : Form
    {
        public int IDOfCurrentUser;
        public Login()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Email != "" && Properties.Settings.Default.Password != "")
            {
                mailAddress.Text = Properties.Settings.Default.Email;
                mailPassword.Text = Properties.Settings.Default.Password;
                Remember.Checked = true;
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (mailAddress.Text == "" || mailPassword.Text == "")
            {
                MessageBox.Show("You can't leave Email or Password Empty!, Please Fill Them!");
                return;
            }
            if (mailAddress.Text == "admin" || mailAddress.Text == "Admin")
            {
                ErrorType ret = var.controllerObj.AdminLogin(mailAddress.Text, mailPassword.Text);
                if (ret == ErrorType.LoginFailed)
                {
                    MessageBox.Show("Login Failed!");
                    return;
                }
                else if (ret == ErrorType.NoErrors)
                {
                    new AdminPanel().Show();
                    this.Hide();
                }
            }
            else
            {
                try
                {
                    MailAddress Mail = new MailAddress(mailAddress.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a valid E-Mail Format");
                    return;
                }
                ErrorType E = var.controllerObj.Login(new GoogleMail(mailAddress.Text, mailPassword.Text, ""));
                if (E == ErrorType.NotRegistered)
                {
                    MessageBox.Show("This E-mail is not registered on IEEE CUSB Portal!");
                }
                else if (E == ErrorType.LoginFailed)
                {
                    MessageBox.Show("The E-mail or Password is incorrect");
                }
                else if (E == ErrorType.NoErrors)
                {
                    if (Remember.Checked)
                    {
                        Properties.Settings.Default.Email = mailAddress.Text;
                        Properties.Settings.Default.Password = mailPassword.Text;
                    }
                    Position P = var.controllerObj.DetermineVolunteerPosition();
                    if (P == Position.Member)
                    {
                        new MemberForm().Show();
                        this.Hide();
                    }
                    else if (P == Position.Head || P == Position.ViceHead)
                    {
                        new HeadForm().Show();
                        this.Hide();
                    }
                    else if (P == Position.Supervisor)
                    {
                        new SupervisorForm().Show();
                        this.Hide();
                    }
                    else if (P == Position.Officer)
                    {
                        new OfficersForm().Show();
                        //this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("An Unkown Error Occured!");
                    }
                }
            }

        }
    }
}
