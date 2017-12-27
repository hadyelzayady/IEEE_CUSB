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
    public partial class OfficersForm : Form
    {
        public OfficersForm()
        {
            InitializeComponent();
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void CommitteesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CommitteesCombo.ValueMember != "")
            {
                int CommID = Convert.ToInt32(CommitteesCombo.SelectedValue);
                IOrequests.DataSource = var.controllerObj.CommRequests(CommID);
                IOrequests.Refresh();

                CommTasksGrid.DataSource = var.controllerObj.CommTask(CommID);
                CommTasksGrid.Refresh();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var.controllerObj.InsertUpdate(textBox9.Text);
            textBox9.Clear();
        }

        private void OfficersForm_Load(object sender, EventArgs e)
        {
            notificationsData_GridView.DataSource = var.controllerObj.Member_Notification();
            notificationsData_GridView.Refresh();
            updatesData_GridView.DataSource = var.controllerObj.Member_Updates();
            updatesData_GridView.Refresh();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            new AddEvent().ShowDialog();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = eventDetails_GridView.SelectedRows;
            if (selected.Count != 0)
                new EditEvent(selected[0]).ShowDialog();
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
                notificationsData_GridView.DataSource = var.controllerObj.Member_Notification();
                notificationsData_GridView.Refresh();
                updatesData_GridView.DataSource = var.controllerObj.Member_Updates();
                updatesData_GridView.Refresh();
            }
            else if (headTabControl.SelectedTab == headTabControl.TabPages["committeesAffairs"])
            {
                if (CommitteesCombo.Items.Count == 0)
                {
                    CommitteesCombo.DataSource = var.controllerObj.SelectCommittee();
                    CommitteesCombo.ValueMember = "ID";
                    CommitteesCombo.DisplayMember = "Name";
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["CommsRequests"] && CommitteesCombo.Items.Count != 0)
                {
                    int CommID = (int)CommitteesCombo.SelectedValue;
                    IOrequests.DataSource = var.controllerObj.CommRequests(CommID);
                    DataGridViewSelectedRowCollection selected = IOrequests.SelectedRows;
                }
            }
            else if (headTabControl.SelectedTab == headTabControl.TabPages["highBoardTasksTab"])
            {
                dataGridView4.DataSource = var.controllerObj.HighBoard_Tasks();
                dataGridView4.Refresh();
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (CommitteesCombo.Items.Count == 0)
            {
                CommitteesCombo.DataSource = var.controllerObj.SelectCommittee();
                CommitteesCombo.ValueMember = "ID";
                CommitteesCombo.DisplayMember = "Name";
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["CommsRequests"] && CommitteesCombo.Items.Count != 0)
            {
                int CommID = (int)CommitteesCombo.SelectedValue;
                IOrequests.DataSource = var.controllerObj.CommRequests(CommID);
                IOrequests.Refresh();
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["CommsTasks"] && CommitteesCombo.Items.Count != 0)
            {
                int CommID = (int)CommitteesCombo.SelectedValue;
                CommTasksGrid.DataSource = var.controllerObj.CommTask(CommID);
                CommTasksGrid.Refresh();
                if (CommTasksGrid.RowCount != 0)
                    CommTasksGrid.Columns[0].Visible = false;
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["CommsFiles"] && CommitteesCombo.Items.Count != 0)
            {

            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["MonthlyReport"] && CommitteesCombo.Items.Count != 0)
            {

            }
        }

        private void IOrequests_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = IOrequests.SelectedRows;
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

        private void IOrequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CommTasksGrid_SelectionChanged(object sender, EventArgs e)
        {
            //int CommID = (int)CommitteesCombo.SelectedValue;
            //CommTasksGrid.DataSource = var.controllerObj.CommTask(CommID);
            //CommTasksGrid.Refresh();
            DataGridViewSelectedRowCollection selected = CommTasksGrid.SelectedRows;
            if (selected.Count != 0)
            {
                textBox3.Text = CommTasksGrid.SelectedRows[0].Cells["Assigner"].Value.ToString();
                textBox5.Text = CommTasksGrid.SelectedRows[0].Cells["Start_Date"].Value.ToString();
                textBox4.Text = CommTasksGrid.SelectedRows[0].Cells["Deadline_Date"].Value.ToString();
                textBox18.Text = CommTasksGrid.SelectedRows[0].Cells["Description"].Value.ToString();
                textBox2.Text = CommTasksGrid.SelectedRows[0].Cells["Title"].Value.ToString();

                int id = Convert.ToInt32(CommTasksGrid.SelectedRows[0].Cells["ID"].Value.ToString());
                DataTable dt = var.controllerObj.GetTaskRecievers(id);
                listBox1.Items.Clear();
                string name;
                foreach (DataRow row in dt.Rows)
                {
                    name = row["Name"].ToString();
                    listBox1.Items.Add(name);
                }
            }
            CommTasksGrid.ClearSelection();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView3.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                var.controllerObj.UpdateTaskStatus(x, Status.Accepted);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView3.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                var.controllerObj.UpdateTaskStatus(x, Status.Rejected);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView3.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                new ViewTask(x).ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView3.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                new SubmitTask(x).ShowDialog();
            }
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

        private void button30_Click(object sender, EventArgs e)
        {
            HeadsHRSystem HR = new HeadsHRSystem();
            HR.Show();
        }

        private void button38_Click_1(object sender, EventArgs e)
        {

        }

        private void button37_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = eventDetails_GridView.SelectedRows;
            if (selected.Count != 0)
                new EditEvent(selected[0]).ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void eventDetails_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            eventDetails_GridView.DataSource = var.controllerObj.SelectEvents(ieeeCalendar.SelectionRange.Start);
            eventDetails_GridView.Refresh();
            DescL.Text = "";
            DateL.Text = "";
            TitleL.Text = "";
            eventDetails_GridView.ClearSelection();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            notificationsData_GridView.DataSource = var.controllerObj.Member_Notification();
            notificationsData_GridView.Refresh();
            updatesData_GridView.DataSource = var.controllerObj.Member_Updates();
            updatesData_GridView.Refresh();
        }

        private void VolunteersManagement_Click(object sender, EventArgs e)
        {
            new VolunteersManagement().ShowDialog();
        }

        private void ParticipantsManagement_Click(object sender, EventArgs e)
        {
            new ParticipantsManagement().ShowDialog();
        }
    }
}
       