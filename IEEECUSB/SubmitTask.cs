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
    public partial class SubmitTask : Form
    {
        int ID;
        public SubmitTask(int Task_ID)
        {
            InitializeComponent();
            Task_ID = ID;
        }

        private void SubmitTask_Load(object sender, EventArgs e)
        {
            DataTable dt = var.controllerObj.GetTask(ID);
            string Title = dt.Rows[0]["Title"].ToString();
            textBox1.Text = Title;
            string Start_Date = dt.Rows[0]["Start_Date"].ToString();
            textBox3.Text = Start_Date;
            string Deadline_Date = dt.Rows[0]["Deadline_Date"].ToString();
            textBox6.Text = Deadline_Date;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Progress_Percentage = textBox5.Text;
            string Progress_Description = textBox2.Text;
            int x = Convert.ToInt32(Progress_Percentage);
            var.controllerObj.UpdateTask(ID, x, Progress_Description, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Progress_Percentage = textBox5.Text;
            string Progress_Description = textBox2.Text;
            int x = Convert.ToInt32(Progress_Percentage);
            var.controllerObj.UpdateTask(ID, x, Progress_Description, 1);
            Status status = Status.Submitted;
            var.controllerObj.UpdateTaskStatus(ID, 1, status);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewTask V = new ViewTask(ID);
            V.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
