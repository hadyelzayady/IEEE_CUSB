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
                if (tabControl1.SelectedTab == tabControl1.TabPages["sectionTasksTab"] && CommitteesCombo.Items.Count!=0)
                {
                    dataGridView4.DataSource = var.controllerObj.Section_Task();
                    dataGridView4.Refresh();
                }

            }
            else if (headTabControl.SelectedTab == headTabControl.TabPages["homeTab"])
            {
                updatesData_GridView.DataSource = var.controllerObj.SelectHeadNotif();
                updatesData_GridView.Refresh();
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

        private void IOrequests_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ieeeCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void CommTasksGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = eventDetails_GridView.SelectedRows;
            if (selected.Count != 0)
                if (var.controllerObj.DeleteEvent((int)selected[0].Cells["ID"].Value) == 1)
                {
                    MessageBox.Show("Event deleted successfully");
                }
                else
                {
                    MessageBox.Show("Error ,event not deleted");
                }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = eventDetails_GridView.SelectedRows;
            if (selected.Count != 0)
                new EditEvent(selected[0]).ShowDialog();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            new AddEvent().ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            eventDetails_GridView.DataSource = var.controllerObj.SelectEvents(ieeeCalendar.SelectionRange.Start);
            eventDetails_GridView.Refresh();
            DescL.Text = "";
            DateL.Text = "";
            TitleL.Text = "";
        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CommTasksGrid_SelectionChanged(object sender, EventArgs e)
        {
            if(CommTasksGrid.SelectedRows.Count!=0)
            {
                DataGridViewRow selectedRow = CommTasksGrid.SelectedRows[0];
                FromBox.Text = selectedRow.Cells["Assigner"].Value.ToString();
                foreach (DataGridViewRow row in CommTasksGrid.Rows)
                {
                    if (row.Cells["Assigner"].Value.ToString() == selectedRow.Cells["Assigner"].Value.ToString())
                        ToBox.Text += row.Cells["Reciever"];
                }
                start_dateBox.Text = selectedRow.Cells["Start_Date"].Value.ToString();
                TitleBox.Text = selectedRow.Cells["Title"].Value.ToString();
                DescriptionBox.Text = selectedRow.Cells["Description"].Value.ToString();
            }
        }

        private void eventDetails_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void eventDetails_GridView_SelectionChanged(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection selected = eventDetails_GridView.SelectedRows;
            if (selected.Count != 0)
            {
                DescL.Text = selected[0].Cells["Description"].Value.ToString();
                TitleL.Text = selected[0].Cells["Title"].Value.ToString();
                DateL.Text = selected[0].Cells["Start_Date"].Value.ToString() + " To " + selected[0].Cells["End_Date"].Value.ToString();
                // DescL.Text = selected[0].Cells["DressCode"].Value.ToString();
            }
        }

        private void ieeeCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            eventDetails_GridView.DataSource = var.controllerObj.SelectEvents(ieeeCalendar.SelectionRange.Start);
            if (eventDetails_GridView.RowCount != 0)
                eventDetails_GridView.Columns[0].Visible = false;
            eventDetails_GridView.Refresh();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var.controllerObj.InsertUpdate(textBox9.Text);
            textBox9.Clear();
        }

        private void SupervisorForm_Load(object sender, EventArgs e)
        {
            notificationsData_GridView.DataSource = var.controllerObj.Member_Notification();
            notificationsData_GridView.Refresh();
            updatesData_GridView.DataSource = var.controllerObj.Member_Updates();
            updatesData_GridView.Refresh();

        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            AddTask T = new AddTask();
            T.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView4.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells["ID"].Value;
                new ViewTask(x).ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView4.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                var.controllerObj.DeleteTask(x);
                var.controllerObj.DeleteTaskRec(x);
                dataGridView4.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection selected = dataGridView4.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                new EditTask(x).ShowDialog();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView4.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                DataTable dt = var.controllerObj.GetTaskRecieversID(x);
                int ID;
                foreach (DataRow row in dt.Rows)
                {
                    ID = Convert.ToInt32(row["Reciever_ID"].ToString());
                    var.controllerObj.InsertNotification("Kindly do not forget to do your task", "Task Reminder", DateTime.Now, ID);
                }
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            HeadsHRSystem HR = new HeadsHRSystem();
            HR.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            notificationsData_GridView.DataSource = var.controllerObj.Member_Notification();
            notificationsData_GridView.Refresh();
            updatesData_GridView.DataSource = var.controllerObj.Member_Updates();
            updatesData_GridView.Refresh();
        }
    }
}
