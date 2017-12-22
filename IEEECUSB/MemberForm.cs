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
                updatesData_GridView.DataSource = var.controllerObj.SelectMemberNotif();
                updatesData_GridView.Refresh();
            }
        }

        private void updatesData_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
