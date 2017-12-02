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
    public partial class AddRequest : Form
    {
        private Controller controllerObj;
        public AddRequest()
        {
            InitializeComponent();
            controllerObj = new Controller();
            RecComm.DataSource = controllerObj.SelectCommittees();
            RecComm.ValueMember = "ID";
            RecComm.DisplayMember = "Name";
        }

        private void AddRequest_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void addRequest(object sender, EventArgs e)
        {
            string Desc = requestDesc.Text;
            string Title = requestTitle.Text;
            string StartDate = startDate.Value.ToString("yyyy-MM-dd");
            string EndDate = endDate.Value.ToString("yyyy-MM-dd");
            int RecCommID = (int)RecComm.SelectedValue;
            controllerObj.InsertRequest(Title, Desc,StartDate,EndDate, RecCommID);
        }
    }
}
