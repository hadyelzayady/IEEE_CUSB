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
    public partial class HeadsHRSystem : Form
    {
        public HeadsHRSystem()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(8);
            dataGridView2.Rows[0].Cells[0].Value = "Number of Assigned Tasks";
            dataGridView2.Rows[0].Cells[1].Value = "12";
            dataGridView2.Rows[1].Cells[0].Value = "Number of Missed Tasks";
            dataGridView2.Rows[1].Cells[1].Value = "1";
            dataGridView2.Rows[2].Cells[0].Value = "Number of Submitted Tasks";
            dataGridView2.Rows[2].Cells[1].Value = "11";

            dataGridView2.Rows[3].Cells[0].Value = "Number of Submitted Tasks After Deadline";
            dataGridView2.Rows[3].Cells[1].Value = "5";
            dataGridView2.Rows[4].Cells[0].Value = "Number of Trainings Attended";
            dataGridView2.Rows[4].Cells[1].Value = "11";
            dataGridView2.Rows[5].Cells[0].Value = "Number of Meetings Attended";
            dataGridView2.Rows[5].Cells[1].Value = "11";

            dataGridView2.Rows[6].Cells[0].Value = "Number of GMs Attended";
            dataGridView2.Rows[6].Cells[1].Value = "11";
            dataGridView2.Rows[7].Cells[0].Value = "Number of Warnings";
            dataGridView2.Rows[7].Cells[1].Value = "11";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
