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
    public partial class SupervisorForm : Form
    {
        public SupervisorForm()
        {
            InitializeComponent();
            CommitteesCombo.DataSource = var.controllerObj.SelectSectionCommittees();
            CommitteesCombo.ValueMember = "ID";
            CommitteesCombo.DisplayMember = "Name";
        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                int CommID = (int)CommitteesCombo.SelectedValue;
                IOrequests.DataSource = var.controllerObj.CommRequests(CommID);
        }

        private void label39_Click(object sender, EventArgs e)
        {


        }

        private void panel38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void headTabControl_Click(object sender, EventArgs e)
        {
            if (headTabControl.SelectedTab == headTabControl.TabPages["calendarTab"])
            {
                eventDetails_GridView.DataSource = var.controllerObj.SelectEvents(ieeeCalendar.SelectionRange.Start);
                eventDetails_GridView.Refresh();
            }

            else if (headTabControl.SelectedTab == headTabControl.TabPages["myTasksTab"])
            {
                dataGridView3.DataSource = var.controllerObj.Member_Tasks();
                dataGridView3.Refresh();
            }
            else if (headTabControl.SelectedTab == headTabControl.TabPages["homeTab"])
            {
                updatesData_GridView.DataSource = var.controllerObj.SelectHeadNotif();
                updatesData_GridView.Refresh();
            }
            else if (headTabControl.SelectedTab == headTabControl.TabPages["committeesAffairs"])
            {
                if (CommitteesCombo.Items.Count == 0)
                {
                    CommitteesCombo.DataSource = var.controllerObj.SelectSectionCommittees();
                    CommitteesCombo.ValueMember = "ID";
                    CommitteesCombo.DisplayMember = "Name";
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["CommsRequests"] && CommitteesCombo.Items.Count!=0)
                {
                    int CommID = (int)CommitteesCombo.SelectedValue;
                    IOrequests.DataSource = var.controllerObj.CommRequests(CommID);
                }

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void IOrequests_Click(object sender, EventArgs e)
        {
        }

        private void IOrequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void IOrequests_SelectionChanged(object sender, EventArgs e)
        {
            if (IOrequests.SelectedRows.Count != 0)
            {
                FromCommitteBox.Text = IOrequests.SelectedRows[0].Cells["Sender Committee"].Value.ToString();
                ToCommitteeBox.Text = IOrequests.SelectedRows[0].Cells["Reciever Committee"].Value.ToString();
                StartDateBox.Text = IOrequests.SelectedRows[0].Cells["Start_Date"].Value.ToString();
                DeadlineDate.Text = IOrequests.SelectedRows[0].Cells["Deadline_Date"].Value.ToString();
                DescriptionBox.Text = IOrequests.SelectedRows[0].Cells["Description"].Value.ToString();
                PriorityBox.Text = IOrequests.SelectedRows[0].Cells["Priority"].Value.ToString();
                RequestTitleBox.Text = IOrequests.SelectedRows[0].Cells["Title"].Value.ToString();
            }

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            int CommID = (int)CommitteesCombo.SelectedValue;

            if (tabControl1.SelectedTab == tabControl1.TabPages["CommsRequests"])
            {
                IOrequests.DataSource = var.controllerObj.CommRequests(CommID);
                IOrequests.Refresh();
            }
            else if(tabControl1.SelectedTab == tabControl1.TabPages["CommsTasks"])
            {
                CommTasksGrid.DataSource = var.controllerObj.Committee_Tasks(CommID);
                CommTasksGrid.Refresh();
            }
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CommitteesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
