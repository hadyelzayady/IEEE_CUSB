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
    public partial class EditTask : Form
    {
        int Task_ID;

        public EditTask(int Task_ID1)
        {
            InitializeComponent();
            Task_ID = Task_ID1;
        }

        private void EditTask_Load(object sender, EventArgs e)
        {
            DataTable dt = var.controllerObj.GetTask(Task_ID);
            string Title = dt.Rows[0]["Title"].ToString();
            textBox1.Text = Title;
            DateTime Start_Date = Convert.ToDateTime(dt.Rows[0]["Start_Date"]);
            dateTimePicker1.Value = Start_Date;
            DateTime Deadline_Date = Convert.ToDateTime(dt.Rows[0]["Deadline_Date"]);
            dateTimePicker2.Value = Deadline_Date;
            string Description = dt.Rows[0]["Description"].ToString();
            textBox2.Text = Description;

            DataTable dt3 = var.controllerObj.Committee_Members();
            int numRows = dt3.Rows.Count;
            string name;
            int i = 0;

            foreach (DataRow row in dt3.Rows)
            {
                name = row["name"].ToString();
                checkedListBox1.Items.Insert(i, name);
            }

            DataTable dt1 = var.controllerObj.GetTaskRecieversID(Task_ID);
            numRows = dt3.Rows.Count;
            int ID;

            foreach (DataRow row in dt1.Rows)
            {
                ID = Convert.ToInt32(row["ID"].ToString());
                for (int y = 0; y < numRows; y++)
                {
                    if(ID == Convert.ToInt32(dt3.Rows[y]["ID"].ToString()))
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkedListBox1.CheckedItems.Count!=0)
            {
                var.controllerObj.InsertTask(textBox1.Text, textBox2.Text, 1, 1);
                var.controllerObj.DeleteTaskRec(Task_ID);
                DataTable dt = var.controllerObj.Committee_Members();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        string str = checkedListBox1.GetItemText(i);
                        int Rec_ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        var.controllerObj.InsertTaskReciever(Task_ID, Rec_ID);
                    }
                }



            }
        }
    }
}
