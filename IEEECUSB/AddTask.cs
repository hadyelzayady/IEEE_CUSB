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
    }
}
