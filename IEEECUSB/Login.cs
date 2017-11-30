using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace IEEECUSB
{
    public partial class Login : Form
    {
        public int IDOfCurrentUser;
        private Controller controllerObj;
        public Login()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
        }
        private bool CheckPassword_Hash(string password)
        {
            const string salt = "r4Nd0m_5A1t";  //They are concatenated to the password to protects against rainbow table attacks.
            HashAlgorithm algorithm = new SHA256Managed();
            string passwordandsalt = password + salt;
            string hashed = Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordandsalt)));
            return hashed == "w+0fHMgNFl7jSDJ7WpvRfIQLzfflSi9pPNdiQg+v4/E="; 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            new HeadForm().ShowDialog();
            
            this.Close();
        }

    }
}
