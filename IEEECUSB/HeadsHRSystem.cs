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
            string searchText = SearchBox.Text;
            if (searchText != null)
            {
                int id;
                DataTable Volunteer = null;
                if (int.TryParse(searchText, out id))
                {
                    Volunteer = var.controllerObj.SearchVoluntHistByID(id);
                }
                else
                    Volunteer = var.controllerObj.SearchVoluntHistByName(searchText);

                if (Volunteer != null)
                {
                    string ID = Volunteer.Rows[0]["ID"].ToString();
                    bool x = false;
                    int i;
                    for (i =0; i < committeeMembers.RowCount; i++)
                    {
                        if (committeeMembers.Rows[i].Cells[0].Value.ToString() == ID)
                        {
                            x = true;
                            break;
                        }
                    }
                    if (x)
                    {
                        committeeMembers.ClearSelection();
                        committeeMembers.Rows[i].Selected = true;                        
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Please check the spelling, Volunteer is not found ", "Something went wrong", MessageBoxButtons.OK);
                        committeeMembers.ClearSelection();
                    }

                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HeadsHRSystem_Load(object sender, EventArgs e)
        {
            committeeMembers.DataSource = var.controllerObj.Committee();
            committeeMembers.Refresh();
            DataTable dt = null;
            int ID;
            int Sub = 0;
            int Acc = 0;
            int Rej = 0;
            int Tot = 0;
            double Eva = 0;
            for (int i = 0; i < committeeMembers.RowCount; i++)
            {
                Sub = 0;
                Acc = 0;
                Rej = 0;
                Tot = 0;
                Eva = 0;
                ID = Convert.ToInt32(committeeMembers.Rows[i].Cells[0].Value.ToString());
                dt = var.controllerObj.Count_Member_Sub(ID);
                if (dt.Rows.Count > 0)
                {
                    Sub = Convert.ToInt32(dt.Rows[0]["COUNT(Task_ID)"].ToString());
                    dt = var.controllerObj.Count_Member_Accept(ID);
                    Acc = Convert.ToInt32(dt.Rows[0]["COUNT(Task_ID)"].ToString());
                    dt = var.controllerObj.Count_Member_Rejected(ID);
                    Rej = Convert.ToInt32(dt.Rows[0]["COUNT(Task_ID)"].ToString());
                    dt = var.controllerObj.Count_Member_Total(ID);
                    Tot = Convert.ToInt32(dt.Rows[0]["COUNT(Task_ID)"].ToString());
                }
                if (Tot != 0)
                {
                    Eva = (Sub / Tot) + (0.5 * Acc / Tot) - (0.5 * Rej / Tot);
                    if (Eva < 0) Eva = 0;
                }
                else Eva = 0;
                Eva = Eva * 100;
                var.controllerObj.Evaluation(Eva, ID);
            }

            committeeMembers.DataSource = var.controllerObj.Committee();
            committeeMembers.Refresh();
            committeeMembers.ClearSelection();
        }

        private void committeeMembers_SelectionChanged(object sender, EventArgs e)
        {
           
            DataGridViewSelectedRowCollection selected = committeeMembers.SelectedRows;
            if (committeeMembers.SelectedRows.Count != 0)
            {
                int ID = Convert.ToInt32(committeeMembers.SelectedRows[0].Cells["ID"].Value.ToString());
                memberDetails.Rows[0].Cells[0].Value = committeeMembers.SelectedRows[0].Cells["ID"].Value.ToString();
                memberDetails.Rows[0].Cells[1].Value = committeeMembers.SelectedRows[0].Cells["Name"].Value.ToString();
                DataTable dt = var.controllerObj.Count_Member_Sub(ID);
                memberDetails.Rows[0].Cells[2].Value = dt.Rows[0]["COUNT(Task_ID)"].ToString();
                dt = var.controllerObj.Count_Member_Accept(ID);
                memberDetails.Rows[0].Cells[3].Value = dt.Rows[0]["COUNT(Task_ID)"].ToString();
                dt = var.controllerObj.Count_Member_Rejected(ID);
                memberDetails.Rows[0].Cells[4].Value = dt.Rows[0]["COUNT(Task_ID)"].ToString();

            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void committeeMembers_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (selectedItem == "Name")
                committeeMembers.Sort(committeeMembers.Columns[1], ListSortDirection.Ascending);
            else if (selectedItem == "ID")
                committeeMembers.Sort(committeeMembers.Columns[0], ListSortDirection.Ascending);
            else if (selectedItem == "Evaluation")
                committeeMembers.Sort(committeeMembers.Columns[2], ListSortDirection.Ascending);
        }
    }
}
