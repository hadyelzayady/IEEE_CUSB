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
    public partial class AddEvent : Form
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Today || dateTimePicker1.Value.Subtract(dateTimePicker2.Value).Days >= 1)
            {
                MessageBox.Show("enter valid dates");
            }
            else
            {
                string desc = DescBox.Text;
                string title = TitleBox.Text;
                string Sdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string Edate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                if(title.Length <4)
                {
                    MessageBox.Show("enter title greater than 4 chars");
                    return;
                }
                else if (var.controllerObj.InsertEvent(title, desc, Sdate, Edate) == 1)
                {
                    MessageBox.Show("Event added successfully");
                    this.Close();
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
