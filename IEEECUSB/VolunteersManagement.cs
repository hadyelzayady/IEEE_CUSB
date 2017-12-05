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
    public partial class VolunteersManagement : Form
    {
        public VolunteersManagement()
        {
            InitializeComponent();
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchText = searchBox.Text;
            if (searchText!=null)
            {
                
                int id;
                DataTable Volunteer = null;
                if (int.TryParse(searchText, out id))
                {
                    Volunteer = var.controllerObj.SearchVoluntHistByID(id);
                }
                else
                    Volunteer = var.controllerObj.SearchVoluntHistByName(searchText);
                if (Volunteer != null)
                {
                    NameL.Text = Volunteer.Rows[0]["Name"].ToString();
                    IDL.Text = Volunteer.Rows[0]["ID"].ToString();
                    SSNL.Text = Volunteer.Rows[0]["National_ID"].ToString();
                    PhoneL.Text = Volunteer.Rows[0]["Mobile"].ToString();
                    EmailL.Text = Volunteer.Rows[0]["Mail"].ToString();
                    VolunteeringSeasonsL.Text = "";
                    foreach (DataRow row in Volunteer.Rows)
                    {
                        VolunteeringSeasonsL.Text += row["Committee_Season"].ToString() + "/";
                        JobL.Text = Volunteer.Rows[0]["Job_Title"].ToString()+"/";
                    }

                }
            }

        }

        private void VolunteeringSeasonsL_Click(object sender, EventArgs e)
        {

        }
    }
}
