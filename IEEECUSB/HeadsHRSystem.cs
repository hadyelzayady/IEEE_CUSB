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
            committeeMembers.DataSource = var.controllerObj.SelectCommMembers();
            if (committeeMembers.RowCount != 0)
            {
                committeeMembers.Columns["ID"].Visible = false;
            }
            committeeMembers.Refresh();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchFor = SearchBox.Text;
            int ID;
            if(int.TryParse(searchFor,out ID))
            {
                committeeMembers.DataSource = var.controllerObj.SearchInCommByID(ID);
            }
            else
                committeeMembers.DataSource = var.controllerObj.SearchInCommByName(searchFor);
            committeeMembers.Refresh();
            //memberDetails.Rows.Add(8);
            //memberDetails.Rows[0].Cells[0].Value = "Number of Assigned Tasks";
            //memberDetails.Rows[0].Cells[1].Value = "12";
            //memberDetails.Rows[1].Cells[0].Value = "Number of Missed Tasks";
            //memberDetails.Rows[1].Cells[1].Value = "1";
            //memberDetails.Rows[2].Cells[0].Value = "Number of Submitted Tasks";
            //memberDetails.Rows[2].Cells[1].Value = "11";

            //memberDetails.Rows[3].Cells[0].Value = "Number of Submitted Tasks After Deadline";
            //memberDetails.Rows[3].Cells[1].Value = "5";
            //memberDetails.Rows[4].Cells[0].Value = "Number of Trainings Attended";
            //memberDetails.Rows[4].Cells[1].Value = "11";
            //memberDetails.Rows[5].Cells[0].Value = "Number of Meetings Attended";
            //memberDetails.Rows[5].Cells[1].Value = "11";

            //memberDetails.Rows[6].Cells[0].Value = "Number of GMs Attended";
            //memberDetails.Rows[6].Cells[1].Value = "11";
            //memberDetails.Rows[7].Cells[0].Value = "Number of Warnings";
            //memberDetails.Rows[7].Cells[1].Value = "11";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void committeeMembers_SelectionChanged(object sender, EventArgs e)
        {
            if (committeeMembers.SelectedRows.Count != 0)
            {
                //DataGridViewRow row = (DataGridViewRow)committeeMembers.SelectedRows[0].Clone();
                //if(memberDetails.Rows.Count!=0)
                //    memberDetails.Rows.Clear();
                //memberDetails.DataSource = committeeMembers.DataSource;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
