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
                var.controllerObj.DeleteEvent((int)selected[0].Cells["ID"].Value);
        }
    }
}
