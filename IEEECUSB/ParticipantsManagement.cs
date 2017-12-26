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
                    UniversityL.Text = Participant.Rows[0]["University"].ToString();
                    DepL.Text = Participant.Rows[0]["Department"].ToString();
                    GraduationL.Text = Participant.Rows[0]["Graduation_Year"].ToString();
                    if(Participant.Rows[0]["Birthdate"].ToString()!="")
                        BirthdateL.Text = Convert.ToDateTime(Participant.Rows[0]["Birthdate"].ToString()).ToShortDateString();
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
                    foreach (DataRow row in Participant.Rows)
                    {
                        ParticSeasonsL.Text += row["Committee_Season"].ToString() + "/";
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = editTab;
            CollegeBox2.Text = CollegeL.Text;
            DepartBox2.Text = DepL.Text;
            NIDBox2.Text = SSNL.Text;

            WorkshopsComb2.SelectedIndex = WorkshopsComb2.FindString(WorkshopL.Text);
            //GradYear2.Value="2k";//todo set grad year
            UniversityBox2.Text = UniversityL.Text;
            PhoneBox2.Text = PhoneL.Text;
            MailBox2.Text = EmailL.Text;
            ParticIDBox2.Text = IDL.Text;
            ParticIDBox2.ReadOnly = true;
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

        private void button8_Click(object sender, EventArgs e)
        {
            string name = FirstNameBox2.Text.Replace(" ", string.Empty) + " " + MiddleNameBox2.Text.Replace(" ", string.Empty) + " " + LastNameBox2.Text.Replace(" ", string.Empty);
            int NID;
            int temp;
            if (NIDBox2.Text != "" && !int.TryParse(NIDBox2.Text, out NID) && NIDBox2.Text.Length != 14 || PhoneBox2.Text != "" && !int.TryParse(PhoneBox2.Text, out temp) && PhoneBox2.Text.Length != 11)
            {
                MessageBox.Show("please enter valid phone and national id");
                return;
            }
            int? commid = (int?)WorkshopsComb2.SelectedValue;
            if (var.controllerObj.UpdateParticipant(int.Parse(ParticIDBox2.Text), name, PhoneBox2.Text, MailBox2.Text, CollegeBox2.Text, DepartBox2.Text, UniversityBox2.Text, GradYearPicker2.Value.Year.ToString()) == 1)
                MessageBox.Show("vulnteer updated");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (FirstNameBox.Text.Length < 3 || MiddleNameBox.Text.Length < 3 || LastNameBox.Text.Length < 3)
            {
                MessageBox.Show("enter valid name ,min 3 chars for each part");
                return;
            }
            string name = FirstNameBox.Text.Replace(" ", string.Empty) + " " + MiddleNameBox.Text.Replace(" ", string.Empty) + " " + LastNameBox.Text.Replace(" ", string.Empty);
            int NID;
            int temp;
            if (NIDBox.Text != "" && !int.TryParse(NIDBox.Text, out NID) && NIDBox.Text.Length != 14 || MobileBox.Text != "" && !int.TryParse(MobileBox.Text, out temp) && MobileBox.Text.Length != 11)
            {
                MessageBox.Show("please enter valid phone and national id");
                return;
            }
            int? workshopid = (int?)WorkshopsComb.SelectedValue;
            if (var.controllerObj.InsertParticipant(name, NIDBox.Text, workshopid, MobileBox.Text, EmailBox.Text, CollegeBox.Text, DepartBox.Text, UniversityBox.Text, GradYearPicker.Value.Year.ToString()) == 1)
                MessageBox.Show("participant added");
            else
                MessageBox.Show("Sorry Error happend try again");
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            string s="";
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == editTab)
            {
                tabControl1.SelectedTab = viewTab;
            }
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
