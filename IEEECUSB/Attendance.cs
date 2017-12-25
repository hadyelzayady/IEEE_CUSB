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
    public partial class Attendance : Form
    {
        int W_ID;
        int S_No;
        public Attendance(int Workshop_ID,int Session_No)
        {
            InitializeComponent();
            W_ID = Workshop_ID;
            S_No = Session_No;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            DataTable dt = var.controllerObj.Volunteer_Enrolled(W_ID);
            string name;
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                name = row["Name"].ToString();
                checkedListBox1.Items.Insert(i, name);
                i++;
            }

            dt = var.controllerObj.Participant_Enrolled(W_ID);
            i = 0;

            foreach (DataRow row in dt.Rows)
            {
                name = row["Name"].ToString();
                checkedListBox2.Items.Insert(i, name);
                i++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                DataTable dt = var.controllerObj.Volunteer_Enrolled(W_ID);
                int Attender_ID;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        Attender_ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        var.controllerObj.InsertAttender_Vol(W_ID, S_No, Attender_ID);
                    }
                }
            }

            if (checkedListBox2.CheckedItems.Count != 0)
            {
                DataTable dt = var.controllerObj.Participant_Enrolled(W_ID);
                int Attender_ID;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox2.GetItemChecked(i))
                    {
                        Attender_ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        var.controllerObj.InsertAttender_Part(W_ID, S_No, Attender_ID);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
