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
    public partial class EditRequest : Form
    {
        int requestID;
        public EditRequest(DataGridViewSelectedRowCollection request)
        {
            InitializeComponent();
            requestID = (int)request[0].Cells[0].Value;
            RequestTitle.Text = request[0].Cells[1].Value.ToString();
            RequestDesc.Text = request[0].Cells[3].Value.ToString();
            RequestStartDate.Text = request[0].Cells[4].Value.ToString();
            RequestEndDate.Text = request[0].Cells[5].Value.ToString();
            RecComm.DataSource = var.controllerObj.SelectCommittees();
            RecComm.ValueMember = "ID";
            RecComm.DisplayMember = "Name";
            string RecCommiteeName = request[0].Cells[2].Value.ToString();
            int index=RecComm.FindString(RecCommiteeName);
            //RecComm.SelectedValue =(Int32)request[0].Cells[0].Value;
            RecComm.SelectedIndex = index;

        }

        private void RecComm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EditRequest_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Desc = RequestDesc.Text;
            string Title = RequestTitle.Text;
            string StartDate = RequestStartDate.Value.ToString("yyyy-MM-dd");
            string EndDate = RequestEndDate.Value.ToString("yyyy-MM-dd");
            int RecCommID = (int)RecComm.SelectedValue;
            var.controllerObj.EditRequest(requestID, Title, Desc, StartDate, EndDate, RecCommID);
        }

        private void RequestStartDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
