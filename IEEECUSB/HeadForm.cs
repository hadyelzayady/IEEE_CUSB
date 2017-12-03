﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IEEECUSB
{
    public partial class HeadForm : Form
    {
        string Task_ID = "";
        public HeadForm()
        {
            InitializeComponent();
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void HeadForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            
        }

        private void button36_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = SentReqList.SelectedRows;
            if (selected != null)
            {
                new ViewRequest(selected).ShowDialog();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            new AddRequest().Show();
        }

        private void homeHeader_Pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ieeeCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            eventDetails_GridView.DataSource= var.controllerObj.SelectEvents(ieeeCalendar.SelectionRange.Start);
            eventDetails_GridView.Refresh();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void headTabControl_Click(object sender, EventArgs e)
        {

            if (headTabControl.SelectedTab == headTabControl.TabPages["requestsTab"])
            {
                ReceivedReqList.DataSource = var.controllerObj.SelectReceivedRequests();
                if (ReceivedReqList.RowCount != 0)
                    ReceivedReqList.Columns[0].Visible = false;
                SentReqList.DataSource = var.controllerObj.SelectSentRequests();
                if (SentReqList.RowCount != 0)
                    SentReqList.Columns[0].Visible = false;
                ReceivedReqList.Refresh();
                SentReqList.Refresh();
            }
            else if (headTabControl.SelectedTab == headTabControl.TabPages["calendarTab"])
            {
                eventDetails_GridView.DataSource = var.controllerObj.SelectEvents(ieeeCalendar.SelectionRange.Start);
                eventDetails_GridView.Refresh();
            }

            else if (headTabControl.SelectedTab == headTabControl.TabPages["tasksTab"])
            {
                dataGridView4.DataSource = var.controllerObj.Committee_Tasks();
                dataGridView4.Refresh();
            }

            else if (headTabControl.SelectedTab == headTabControl.TabPages["myTasksTab"])
            {
                dataGridView3.DataSource = var.controllerObj.Member_Tasks(3);
                dataGridView3.Refresh();


            }
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void calendarHeader_Pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void SentReqList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AcceptRequest(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = ReceivedReqList.SelectedRows;
            if (selected.Count != 0)
            {
                int id = (int)selected[0].Cells[0].Value;
                if (var.controllerObj.UpdateRequestStatus(id, Status.Accepted) == 1)
                {
                    Refresh(1);
                }
            }
        }

        private void RejectRequest(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = ReceivedReqList.SelectedRows;
            if (selected != null)
            {
                int id = (int)selected[0].Cells[0].Value;
                if (var.controllerObj.UpdateRequestStatus(id, Status.Rejected) == 1)
                {
                    Refresh(1);
                }
            }
        }
        private void Refresh(int rec=0,int sen=0)
        {
            if(rec==1)
            {
                ReceivedReqList.DataSource = var.controllerObj.SelectReceivedRequests();
                if (ReceivedReqList.RowCount != 0)
                    ReceivedReqList.Columns[0].Visible = false;
                ReceivedReqList.Refresh();
            }
            if(sen==1)
            {
                SentReqList.DataSource = var.controllerObj.SelectSentRequests();
                if (SentReqList.RowCount != 0)
                    SentReqList.Columns[0].Visible = false;
                SentReqList.Refresh();
            }

        }

        private void SubmitRequest(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = ReceivedReqList.SelectedRows;
            if (selected != null)
            {
                new SubmitRequest(selected).ShowDialog();
            }
        }

        private void DeleteRequest(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = SentReqList.SelectedRows;
            if (selected.Count != 0)
            {
                var.controllerObj.DeleteRequest((int)selected[0].Cells[0].Value);
                Refresh(0, 1);
            }
        }

        private void EditRequest(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = SentReqList.SelectedRows;
            if (selected.Count != 0)
            {
                new EditRequest(selected).ShowDialog();
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Refresh(1, 1);
        }

        private void ReceivedReqList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

         private void button7_Click(object sender, EventArgs e)
        {
            AddTask T = new AddTask();
        }

         private void button4_Click(object sender, EventArgs e)
         {
             int x = Convert.ToInt32(Task_ID);
             SubmitTask T = new SubmitTask(x);
             T.Show();
             Task_ID = "";

         }

         private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             int rowIndex = e.RowIndex;
             Task_ID = dataGridView3.Rows[rowIndex].Cells[1].Value.ToString();
         }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
