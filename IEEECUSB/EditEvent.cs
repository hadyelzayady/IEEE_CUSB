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
    public partial class EditEvent : Form
    {
        int EventID;
        public EditEvent(DataGridViewRow selectedEvent)
        {
            InitializeComponent();
            EventID = (int)selectedEvent.Cells["ID"].Value;
            TitleBox.Text = selectedEvent.Cells["Title"].Value.ToString();
            DescBox.Text = selectedEvent.Cells["Description"].Value.ToString();
            dateTimePicker1.Text = selectedEvent.Cells["Start_Date"].Value.ToString();
            dateTimePicker2.Text = selectedEvent.Cells["End_Date"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string edate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            var.controllerObj.UpdateEvent(EventID, TitleBox.Text, DescBox.Text, sdate, edate);
        }
    }
}
