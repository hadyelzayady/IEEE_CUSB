﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace IEEECUSB
{
    class FTPManager
    {
        string Path;
        string Username;
        string Password;

        public FTPManager(string FtpAddress, string User, string Pass)
        {
            Path = FtpAddress;
            Username = User;
            Password = Pass;
        }
        public bool uploadFile(string LocalLocation, string LocalFileName, string ServerLocation, string ServerFileName)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(Username, Password);
                    client.UploadFile(Path + "/" + ServerLocation + "/" + ServerFileName, "STOR", LocalLocation + @"\" + LocalFileName);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool uploadFile(string LocalLocation, string ServerLocation)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(Username, Password);
                    client.UploadFile(Path + "/" + ServerLocation, "STOR", LocalLocation);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool downloadFile(string LocalLocation, string LocalFileName, string ServerLocation, string ServerFileName)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(Username, Password);
                    client.DownloadFile(Path + "/" + ServerLocation + "/" + ServerFileName, LocalLocation + @"\" + LocalFileName);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool downloadFile(string LocalLocation, string ServerLocation)
        {
            try
            {
                using (WebClient client = new WebClient())
                {   client.Credentials = new NetworkCredential(Username, Password);
                    client.DownloadFile(Path + "/" + ServerLocation, LocalLocation);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool createDirectory(string ServerLocation, string DirectoryName)
        {
            try
            {
                WebRequest request = WebRequest.Create(Path + "/" + ServerLocation + "/" + DirectoryName);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(Username, Password);
                using (FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<string> listDirectory(string ServerLocation)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(Path);
                ftpRequest.Credentials = new NetworkCredential(Username, Password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
                return directories;
            }
            catch
            {
                return null;
            }
        }

    }
}