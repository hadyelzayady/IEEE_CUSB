using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IEEECUSB
{
    class FileManager
    {

        public string GetFilePath()
        {
            string Path = "";
            OpenFileDialog D = new OpenFileDialog();
            D.Title = "Choose Upload File Location | IEEE CUSB Portal";
            DialogResult R = D.ShowDialog();
            if (R == DialogResult.OK)
            {
                Path = D.FileName;
            }
            return Path;
        }
        public string ChooseFileSavePath(string InitialFileName)
        {
            string Path = "";
            SaveFileDialog D = new SaveFileDialog();
            D.Title = "Choose a Location to Download File | IEEE CUSB Portal";
            D.FileName = InitialFileName;
            DialogResult R = D.ShowDialog();
            if (R == DialogResult.OK)
            {
                Path = D.FileName;
            }
            return Path;
        }
    }
}
