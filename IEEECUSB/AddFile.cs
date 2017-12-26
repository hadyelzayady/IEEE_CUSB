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
            if (FileTitle.Text == "")
            {
                MessageBox.Show("Please Write a File Title");
            }
            if (FilePath != "")
            {
                string DestinationPath = var.controllerObj.GetCommitteeFolderPath();
                string FileExt = Path.GetExtension(FilePath);
                var.controllerObj.UploadFile(FilePath, DestinationPath, FileTitle.Text, FileExt, FileDescription.Text);
            }
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
