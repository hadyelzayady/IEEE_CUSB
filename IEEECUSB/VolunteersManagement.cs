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
            CommsComb.DataSource = var.controllerObj.SelectAllCommittees();
            CommsComb.ValueMember = "ID";
            CommsComb.DisplayMember = "Name";
            CommsComb2.DataSource =CommsComb.DataSource;
            CommsComb2.ValueMember = "ID";
            CommsComb2.DisplayMember = "Name";
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = viewTab;
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
                    IDLabel.Text = Volunteer.Rows[0]["ID"].ToString();
                    int CommID = (int)Volunteer.Rows[0]["Committee_ID"];
                    CommsComb2.SelectedValue = CommID;
                    CommL.Text = CommsComb2.GetItemText(CommsComb2.SelectedItem);
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

        private void FirstNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(FirstNameBox.Text.Length <3 || MiddleNameBox.Text.Length <3 || LastNameBox.Text.Length <3)
            {
                MessageBox.Show("enter valid name ,min 3 chars for each part");
                return;
            }
            string name = FirstNameBox.Text.Replace(" ", string.Empty) + " " + MiddleNameBox.Text.Replace(" ", string.Empty) + " " + LastNameBox.Text.Replace(" ", string.Empty);
            int NID;
            int temp;
            if(NIDBox.Text!="" && !int.TryParse(NIDBox.Text,out NID) && NIDBox.Text.Length!=14 || MobileBox.Text != "" && !int.TryParse(MobileBox.Text,out temp) && MobileBox.Text.Length != 11)
            {
                MessageBox.Show("please enter valid phone and national id");
                return;
            }
            int? commid = (int?)CommsComb.SelectedValue;
            if (var.controllerObj.InsertVolunteer(name,commid, MobileBox.Text, EmailBox.Text, CollegeBox.Text, DepartBox.Text, UniversityBox.Text, GradYearPicker.Value.Year.ToString()) == 1)
                MessageBox.Show("vulnteer added");
            else
                MessageBox.Show("Sorry Error happend try again");
        }

        private void CommsComb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = editTab;
            CollegeBox2.Text =CollegeL.Text;
            DepartBox2.Text = DepL.Text;
            CommsComb2.SelectedIndex = CommsComb2.FindString(CommL.Text);
            //GradYear2.Value="2k";//todo set grad year
            UniversityBox2.Text = UniversityL.Text;
            PhoneBox2.Text = PhoneL.Text;
            MailBox2.Text = EmailL.Text;
            IDLabel2.Text = IDLabel.Text;
            char[] delimiterChars = { ' '};
            string[] nameparts = NameL.Text.Split(delimiterChars);
            FirstNameBox2.Text = NameL.Text.Split(delimiterChars)[0];
            MiddleNameBox2.Text = NameL.Text.Split(delimiterChars)[1];
            LastNameBox2.Text = NameL.Text.Split(delimiterChars)[2];
        }

        private void GradYear2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string name = FirstNameBox2.Text.Replace(" ", string.Empty) + " "+ MiddleNameBox2.Text.Replace(" ",string.Empty)+" " + LastNameBox2.Text.Replace(" ", string.Empty);
            int NID;
            int temp;
            if (NIDBox2.Text != "" && !int.TryParse(NIDBox2.Text, out NID) && NIDBox2.Text.Length != 14 || PhoneBox2.Text != "" && !int.TryParse(PhoneBox2.Text, out temp) && PhoneBox2.Text.Length!=11)
            {
                MessageBox.Show("please enter valid phone and national id");
                return;
            }
            int? commid = (int?)CommsComb2.SelectedValue;
            if (var.controllerObj.UpdateVolunteer(int.Parse(IDLabel2.Text),name, commid, MobileBox.Text, EmailBox.Text, CollegeBox.Text, DepartBox.Text, UniversityBox.Text, GradYearPicker.Value.Year.ToString()) == 1)
                MessageBox.Show("vulnteer updated");
        }
    }
}
