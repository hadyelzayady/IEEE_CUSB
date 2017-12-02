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
    public partial class ViewRequest : Form
    {
        private Controller controllerObj;
        int requestID;
        public ViewRequest(DataGridViewSelectedRowCollection request)
        {
            InitializeComponent();
            //controllerObj = new Controller();
            //requestID = (int)request[0].Cells[0].Value;
            //RequestTitle.Text = request[0].Cells[1].Value.ToString();
            //RequestingComm.Text = request[0].Cells[2].Value.ToString();
            //RequestStartDate.Text = request[0].Cells[4].Value.ToString();
            //RequestEndDate.Text = request[0].Cells[5].Value.ToString();

            //Committees.DataSource = controllerObj.SelectCommittees();
            //Committees.al = "CountryCode";
            //Committees.DisplayMember = "CountryName";
            //Committees.DataBind();
            //Committees.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ViewRequest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mahmoudMorsyDataSet.Committee' table. You can move, or remove it, as needed.
            // this.committeeTableAdapter.Fill(this.mahmoudMorsyDataSet.Committee);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditRequest_Click(object sender, EventArgs e)
        {
            //controllerObj.EditRequest(requestID, RequestTitle.Text, RequestDesc.Text, RequestStartDate.Value, RequestEndDate.Value, RequestingComm.Text);
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.committeeTableAdapter.Fill(this.mahmoudMorsyDataSet.Committee);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
