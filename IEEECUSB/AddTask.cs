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
                name = row["name"].ToString();
                checkedListBox1.Items.Insert(i, name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                DataTable dt = var.controllerObj.Committee_Members();
                var.controllerObj.InsertTask(textBox1.Text, textBox2.Text, 1 , 1);
                int maxValue = Convert.ToInt32(var.controllerObj.MaxTaskID().ToString());
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        string str = checkedListBox1.GetItemText(i);
                        int Rec_ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        var.controllerObj.InsertTaskReciever(maxValue, Rec_ID);
                    }
                }
            }

        }

    }
}
