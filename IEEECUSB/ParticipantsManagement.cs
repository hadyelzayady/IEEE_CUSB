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
    public partial class ParticipantsManagement : Form
    {
        public ParticipantsManagement()
        {
            InitializeComponent();
            WorkshopsComb.DataSource = var.controllerObj.SelectAllWorkshops();
            WorkshopsComb.ValueMember = "ID";
            WorkshopsComb.DisplayMember = "Name";
            WorkshopsComb2.DataSource = WorkshopsComb.DataSource;
            WorkshopsComb2.ValueMember = "ID";
            WorkshopsComb2.DisplayMember = "Name";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = viewTab;
            string searchText = searchBox.Text;
            if (searchText != null)
            {

                int id;
                DataTable Participant = null;
                if (int.TryParse(searchText, out id))
                {
                    Participant = var.controllerObj.SearchParticHistByID(id);
                }
                else
                    Participant = var.controllerObj.SearchParticHistByName(searchText);
                if (Participant != null)
                {
                    NameL.Text = Participant.Rows[0]["Name"].ToString();
                    IDL.Text = Participant.Rows[0]["ID"].ToString();
                    SSNL.Text = Participant.Rows[0]["National_ID"].ToString();
                    PhoneL.Text = Participant.Rows[0]["Mobile"].ToString();
                    EmailL.Text = Participant.Rows[0]["Mail"].ToString();
                    IDL.Text = Participant.Rows[0]["ID"].ToString();
                    CollegeL.Text = Participant.Rows[0]["College"].ToString();
                    DepL.Text = Participant.Rows[0]["Department"].ToString();
                    int workshopID;
                    if (int.TryParse(Participant.Rows[0]["Workshop_ID"].ToString(), out workshopID))
                    {
                        WorkshopsComb2.SelectedValue = workshopID;
                        WorkshopL.Text = WorkshopsComb2.GetItemText(WorkshopsComb2.SelectedItem);
                    }
                    else
                    {
                        WorkshopL.Text = "";
                    }
                    ParticSeasonsL.Text = "";
                    //foreach (DataRow row in Participant.Rows)
                    //{
                    //    ParticSeasonsL.Text += row["Committee_Season"].ToString() + "/";
                    //}

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = editTab;
            CollegeBox2.Text = CollegeL.Text;
            DepartBox2.Text = DepL.Text;
            WorkshopsComb2.SelectedIndex = WorkshopsComb2.FindString(WorkshopL.Text);
            //GradYear2.Value="2k";//todo set grad year
            UniversityBox2.Text = UniversityL.Text;
            PhoneBox2.Text = PhoneL.Text;
            MailBox2.Text = EmailL.Text;
            ParticIDBox2.Text = IDL.Text;
            char[] delimiterChars = { ' ' };
            string[] nameparts = NameL.Text.Split(delimiterChars);
            FirstNameBox2.Text = NameL.Text.Split(delimiterChars)[0];
            MiddleNameBox2.Text = NameL.Text.Split(delimiterChars)[1];
            LastNameBox2.Text = NameL.Text.Split(delimiterChars)[2];
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WorkshopsComb.DataSource = var.controllerObj.SelectAllWorkshops();
            WorkshopsComb.ValueMember = "ID";
            WorkshopsComb.DisplayMember = "Name";
            WorkshopsComb2.DataSource = WorkshopsComb.DataSource;
            WorkshopsComb2.ValueMember = "ID";
            WorkshopsComb2.DisplayMember = "Name";
        }
    }
}
