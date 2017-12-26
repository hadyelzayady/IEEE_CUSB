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
    public partial class SubmitRequest : Form
    {
        private int requestID;
        public SubmitRequest(DataGridViewSelectedRowCollection request)
        {
            InitializeComponent();
            requestID = (int)request[0].Cells[0].Value;
            RequestTitle.Text = request[0].Cells[1].Value.ToString();
            RequestingComm.Text = request[0].Cells[2].Value.ToString();
            RequestStartDate.Text = request[0].Cells[4].Value.ToString();
            RequestEndDate.Text = request[0].Cells[5].Value.ToString();

        }

        private void SubmitRequest_Load(object sender, EventArgs e)
        {
        }

        private void UpdateRequest(object sender, EventArgs e)
        {
            string progressDesc = ProgressDesc.Text;
            int progressPerc;
            if (int.TryParse(ProgressPerc.Text, out progressPerc))
            {

                if (var.controllerObj.MemeberSubmitRequest(requestID, progressDesc, progressPerc) == 1)
                {
                    //show success
                    MessageBox.Show("Request Submitted Successfully");
                    return;
                }
                //error
                MessageBox.Show("error in submitting request");
                return;
            }

            MessageBox.Show("enter integer value");
            return;
        }

        private void progressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string progressDesc = ProgressDesc.Text;
            int progressPerc;
            if (int.TryParse(ProgressPerc.Text, out progressPerc))
            {

                if (var.controllerObj.MemeberUpdateRequest(requestID, progressDesc, progressPerc) == 1)
                {
                    //show success
                    MessageBox.Show("Request Updated Successfully");
                    return;
                }
                //error
                MessageBox.Show("error in Updating request");
                return;
            }

            MessageBox.Show("enter progress percent value");
        }
    }
}
