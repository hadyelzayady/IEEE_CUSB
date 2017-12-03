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
    public partial class ViewTask : Form
    {
        int ID;
        public ViewTask(int Task_ID)
        {
            InitializeComponent();
            ID = Task_ID;
        }

        private void ViewTask_Load(object sender, EventArgs e)
        {
            DataTable dt = var.controllerObj.GetTask(ID);
            string Title = dt.Rows[0]["Title"].ToString();
            textBox1.Text = Title;
            string Start_Date = dt.Rows[0]["Start_Date"].ToString();
            textBox3.Text = Start_Date;
            string Deadline_Date = dt.Rows[0]["Deadline_Date"].ToString();
            textBox4.Text = Deadline_Date;
            string Description = dt.Rows[0]["Description"].ToString();
            textBox2.Text = Description;
            DataTable dt1 = var.controllerObj.GetTaskRecievers(ID);
            int numRows = dt1.Rows.Count;
            string name;

            foreach (DataRow row in dt1.Rows)
            {
                name = row["name"].ToString();
                listBox1.Items.Add(name);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            SubmitTask V = new SubmitTask(ID);
            V.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
