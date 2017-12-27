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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();

        }

        private void ChooseTableBtn_Click(object sender, EventArgs e)
        {
            if (TablesList.Text != "")
            {
                try
                {
                    TableGrid.DataSource = var.controllerObj.GetTableData(TablesList.Text);
                    TableGrid.Refresh();
                }
                catch { }
            }
        }

        private void AddCommittee_Click(object sender, EventArgs e)
        {
            if (CommName.Text == "")
            {
                MessageBox.Show("Please Write a Committee Name!");
                return;
            }
            if (CommSeason.Text == "")
            {
                MessageBox.Show("Please Choose a Committee Season!");
                return;
            }
            if (CommSection.Text == "")
            {
                MessageBox.Show("Please Choose a Committee Section!");
                return;
            }
            DataTable SeasonID = var.controllerObj.GetSectionID(CommSeason.Text, CommSection.Text);
            if (SeasonID != null)
            {
                MessageBox.Show(var.controllerObj.AddCommittee(CommName.Text, CommHeadID.Text, CommViceID.Text, CommSeason.Text, SeasonID.Rows[0][0].ToString()).ToString()); ;
            }

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            //Tables List
            List<string> Tables = new List<string>();
            DataTable TablesDB = var.controllerObj.GetDBTablesList();
            for (int i = 0; i < TablesDB.Rows.Count; i++)
            {
                Tables.Add(TablesDB.Rows[i][0].ToString());
            }
            TablesList.DataSource = Tables;
            TablesList.Refresh();

            //Committee Season
            List<string> Seasons = new List<string>();
            DataTable SeasonsDB = var.controllerObj.GetAvailableSeasons();
            for (int i = 0; i < SeasonsDB.Rows.Count; i++)
            {
                Seasons.Add(SeasonsDB.Rows[i][0].ToString());
            }
            try
            {
                CommSection.Items.Clear();
            }
            catch { }
            CommSeason.DataSource = Seasons;
            CommSection.Refresh();

            //Section Seasons
            try
            {
                SecSeason.Items.Clear();
            }
            catch { }
            SecSeason.DataSource = Seasons;
            SecSeason.Refresh();

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            AdminPanel_Load(sender, e);
        }

        private void CommSeason_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CommSeason_MouseClick(object sender, MouseEventArgs e)
        {
            //Committee Sections
            List<string> Sections = new List<string>();
            DataTable SectionsDB = var.controllerObj.GetAvailableSections(CommSeason.Text);
            if (SectionsDB != null)
            {
                for (int i = 0; i < SectionsDB.Rows.Count; i++)
                {
                    Sections.Add(SectionsDB.Rows[i]["Name"].ToString());
                }
                try
                {
                    CommSection.Items.Clear();
                }
                catch { }
                CommSection.DataSource = Sections;
                CommSection.Refresh();
            }
            else
            {

            }

        }

        private void AddSeason_Click(object sender, EventArgs e)
        {
            if (NewSeasonName.Text == "")
            {
                MessageBox.Show("Please write a Season Number!");
                return;
            }
            int ret = var.controllerObj.AddSeason(NewSeasonName.Text, SeasonChairID.Text, SeasonViceID.Text, SeasonTreasurerID.Text, SeasonSecretaryID.Text);
            if (ret == 0)
            {
                MessageBox.Show("An Error Occurred!");

            }
            else
            {
                MessageBox.Show("Season is added successfully!");
            }
        }

        private void AddSection_Click(object sender, EventArgs e)
        {
            if (SecName.Text == "")
            {
                MessageBox.Show("Please write a section name!");
                return;
            }
            if (SecSeason.Text == "")
            {
                MessageBox.Show("Please select a season number!");
                return;
            }
            int ret = var.controllerObj.AddSection(SecName.Text, SecSeason.Text, SecSuperID.Text, SecDescription.Text);

            if (ret == 0)
            {
                MessageBox.Show("An Error Occurred!");
            }
            else
            {
                MessageBox.Show("Section is Added Successfully");
            }

        }

        private void CommSeason_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Committee Sections
            List<string> Sections = new List<string>();
            DataTable SectionsDB = var.controllerObj.GetAvailableSections(CommSeason.Text);
            if (SectionsDB != null)
            {
                for (int i = 0; i < SectionsDB.Rows.Count; i++)
                {
                    Sections.Add(SectionsDB.Rows[i]["Name"].ToString());
                }
                try
                {
                    CommSection.Items.Clear();
                }
                catch { }
                CommSection.DataSource = Sections;
                CommSection.Refresh();
            }
            else
            {

            }
        }

        private void SecSeason_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ChangeAdminPW().ShowDialog();
        }
    }
}
