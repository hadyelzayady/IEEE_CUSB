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
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void AddTask_Load(object sender, EventArgs e)
        {
            DataTable dt = var.controllerObj.Committee_Members();
            int numRows = dt.Rows.Count;
            string name;
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                name = row["Name"].ToString();
                checkedListBox1.Items.Insert(i, name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0 && textBox1.Text != "")
            {
                DataTable dt = var.controllerObj.Committee_Members();
                var.controllerObj.InsertTask(textBox1.Text, textBox2.Text, dateTimePicker1.Value , dateTimePicker2.Value);
                DataTable dt1 = var.controllerObj.MaxTaskID();
                int maxValue = Convert.ToInt32(dt1.Rows[0]["MAX(ID)"].ToString());
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        string str = checkedListBox1.GetItemText(i);
                        int Rec_ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        var.controllerObj.InsertTaskReciever(maxValue, Rec_ID);
                        var.controllerObj.InsertNotification("Kindly check your Tasks, New task has been added!", "New Task", DateTime.Now, Rec_ID);
                    }
                }

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
