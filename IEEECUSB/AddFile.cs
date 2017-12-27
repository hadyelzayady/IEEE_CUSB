using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace IEEECUSB
{
    public partial class AddFile : Form
    {
        public AddFile()
        {
            InitializeComponent();
        }
        string FilePath = "";
        private void BrowseFile_Click(object sender, EventArgs e)
        {
            FilePath = new FileManager().GetFilePath();
        }

        private void UploadFile_Click(object sender, EventArgs e)
        {
            bool Return = false;
            if (FileTitle.Text == "")
            {
                MessageBox.Show("Please Write a File Title");
            }
            if (FilePath != "")
            {
                string FileExt = Path.GetExtension(FilePath);
                Return = var.controllerObj.UploadFile(FilePath, FileTitle.Text, FileExt, FileDescription.Text);
            }
            if (Return == false)
            {
                MessageBox.Show("An Error Occurred!");
            }
            else
            {
                MessageBox.Show("You file is uploaded successfully!");
            }
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
