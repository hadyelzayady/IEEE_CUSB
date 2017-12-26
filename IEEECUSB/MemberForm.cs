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
    public partial class MemberForm : Form
    {
        public MemberForm()
        {
            InitializeComponent();
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

          
        }

        private void updatesData_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ieeeCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void eventDetails_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            notificationsData_GridView.DataSource = var.controllerObj.Member_Notification();
            notificationsData_GridView.Refresh();
            updatesData_GridView.DataSource = var.controllerObj.Member_Updates();
            updatesData_GridView.Refresh();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string HREval = var.controllerObj.GetEvaluation().ToString();
            MessageBox.Show("your evaluation is " + HREval);
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

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = var.controllerObj.Member_Tasks();
            dataGridView3.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddFile().ShowDialog();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (filesGrid.SelectedRows.Count != 0)
            {
                string ServerFilePath = filesGrid.SelectedRows[0].Cells["URL"].Value.ToString();
                string FileName = filesGrid.SelectedRows[0].Cells["File Title"].Value.ToString() + filesGrid.SelectedRows[0].Cells["Type"].Value.ToString();
                string LocalFilePath = new FileManager().ChooseFileSavePath(FileName);

                if (LocalFilePath != "")
                    var.controllerObj.DownloadFile(LocalFilePath, ServerFilePath);

            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            eventDetails_GridView.DataSource = var.controllerObj.SelectEvents(ieeeCalendar.SelectionRange.Start);
            eventDetails_GridView.Refresh();
            eventDetails_GridView.ClearSelection();
        }

        private void headTabControl_Click_1(object sender, EventArgs e)
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
            else if (headTabControl.SelectedTab == headTabControl.TabPages["filesTab"])
            {
                filesGrid.DataSource = var.controllerObj.GetCommitteeFiles();
                filesGrid.Refresh();
            }
        }
    }
}