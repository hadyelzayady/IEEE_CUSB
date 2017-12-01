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
        private Controller controllerObj;
        private int requestID;
        public SubmitRequest(DataGridViewSelectedRowCollection request)
        {
            InitializeComponent();
            controllerObj = new Controller();
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
            string progressDesc = progressTextBox.Text;
            int progressPerc;
            int.TryParse(ProgressPerc.Text, out progressPerc);
            if (int.TryParse(ProgressPerc.Text, out progressPerc))
            {

                if (controllerObj.MemeberSubmitRequest(requestID, progressDesc, progressPerc) == 1)
                {
                    //show success

                    return;
                }
                //error
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
    }
}
