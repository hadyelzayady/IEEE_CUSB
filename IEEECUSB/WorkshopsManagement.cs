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
    public partial class WorkshopsManagement : Form
    {
        public WorkshopsManagement()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView2.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                int y = listBox1.SelectedIndex;
                Attendance T = new Attendance(x,y);
                T.Show();
            }
        }

        private void dataGridView2_SelectionChanged_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView2.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                DataTable dt = var.controllerObj.GetWorkshop(x);
                textBox1.Text = dt.Rows[0]["Name"].ToString();
                textBox3.Text = dt.Rows[0]["Start_Date"].ToString();
                textBox6.Text = dt.Rows[0]["End_Date"].ToString();
                textBox2.Text = dt.Rows[0]["Outline"].ToString();
                textBox8.Text = dt.Rows[0]["Expected_Sessions"].ToString();
                int Type = Convert.ToInt32(dt.Rows[0]["Type"].ToString());
                if (Type == 1)
                {
                    radioButton7.Checked = true;
                }
                else if (Type == 2)
                {
                    radioButton8.Checked = true;
                }
                else
                {
                    radioButton7.Checked = false;
                    radioButton7.Checked = false;
                }

                listBox2.Items.Clear();
                listBox1.Items.Clear();
                dt = var.controllerObj.GetWorkshopSessions(x);
                foreach (DataRow row in dt.Rows)
                {
                    Name = row["Name"].ToString();
                    listBox1.Items.Add(Name);
                }

                textBox11.Text = var.controllerObj.SessionCount(x).ToString();

            }

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
            checkedListBox1.ClearSelected();
        }

        private void WorkshopsManagement_Load_1(object sender, EventArgs e)
        {
            dataGridView2.DataSource = var.controllerObj.Committee_Workshop();
            dataGridView2.Refresh();

            DataTable dt = var.controllerObj.Workshops_Members();
            int numRows = dt.Rows.Count;
            string name;
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                name = row["Name"].ToString();
                checkedListBox1.Items.Insert(i, name);
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = dataGridView2.SelectedRows;
            if (selected.Count != 0)
            {
                int x = (int)selected[0].Cells[0].Value;
                int y = listBox1.SelectedIndex;
                DataTable dt = var.controllerObj.GetWorkshopIns(x);
                int numRows = dt.Rows.Count;
                string Name;

                foreach (DataRow row in dt.Rows)
                {
                    Name = row["Name"].ToString();
                    listBox2.Items.Add(Name);
                }

                dt = var.controllerObj.GetSession(x, y);
                textBox12.Text = dt.Rows[0]["Location"].ToString();
                textBox2.Text = dt.Rows[0]["Description"].ToString();

                int VolNum = Convert.ToInt32(var.controllerObj.Vol_Session_Count(x, y).ToString());
                int PartNum = Convert.ToInt32(var.controllerObj.Part_Session_SessionCount(x, y).ToString());
                int p = VolNum + PartNum;
                textBox5.Text = Convert.ToString(p);

                VolNum = Convert.ToInt32(var.controllerObj.CountVolunteer_Enrolled(x).ToString());
                PartNum = Convert.ToInt32(var.controllerObj.CountParticipant_Enrolled(x).ToString());
                textBox4.Text = Convert.ToString(VolNum + PartNum);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                string Name = textBox9.Text;
                string Outline = textBox10.Text;
                int Type = 0;
                if (radioButton1.Checked == true || radioButton2.Checked == true)
                {
                    Type = 1;
                }
                else if (radioButton3.Checked == true || radioButton4.Checked == true)
                {
                    Type = 2;
                }

                int ExpectedSessionNo = Convert.ToInt32(textBox7.Text);
                DateTime Start_Date = Convert.ToDateTime(dateTimePicker1.Text);
                DateTime End_Date = Convert.ToDateTime(dateTimePicker2.Text);

                DataTable dt = var.controllerObj.Committee_Members();
                var.controllerObj.InsertWorkshop(Name, Outline, Type, Start_Date, End_Date, ExpectedSessionNo);
                DataTable dt3 = var.controllerObj.MaxWorkshopID();
                int maxValue = Convert.ToInt32(dt3.Rows[0]["MAX(ID)"].ToString());
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        int Ins_ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        var.controllerObj.InsertSessionIns(maxValue, Ins_ID);
                    }
                }
            }
        }
    }
}
