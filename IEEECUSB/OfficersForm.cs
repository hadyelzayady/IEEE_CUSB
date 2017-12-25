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

        private void ieeeCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void ieeeCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            eventDetails_GridView.DataSource = var.controllerObj.SelectEvents(ieeeCalendar.SelectionRange.Start);
            if (eventDetails_GridView.RowCount != 0)
                eventDetails_GridView.Columns[0].Visible = false;
            eventDetails_GridView.Refresh();
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
                if(var.controllerObj.DeleteEvent((int)selected[0].Cells["ID"].Value)==1)
                {
                    MessageBox.Show("Event deleted successfully");
                }
                else
                {
                    MessageBox.Show("Error ,event not deleted");
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void headTabControl_Click(object sender, EventArgs e)
        {
            if (headTabControl.SelectedTab == headTabControl.TabPages["calendarTab"])
            {
                eventDetails_GridView.DataSource = var.controllerObj.SelectEvents(ieeeCalendar.SelectionRange.Start);
                eventDetails_GridView.Refresh();
            }

        }

        private void CommTasksGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
