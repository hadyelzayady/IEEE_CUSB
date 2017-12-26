using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace IEEECUSB
{
    class GoogleMail
    {
        public MailAddress MailAddress;
        public string MailPassword;
        string MailName;
        SmtpClient smtp;
        MailMessage DefaultLoginMsg;
        public GoogleMail(string mailAddress, string mailPassword, string mailName)
        {
            try
            {
                MailAddress = new MailAddress(mailAddress, mailName);
                MailPassword = mailPassword;
                MailName = mailName;
                smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(MailAddress.Address, MailPassword)
                };
                string DefaultLoginMessage = "Dear " + MailName +
                    ", \nThis is an automated message to tell you that you have logged into your account from IEEE CUSB Portal in "
                    + System.DateTime.Now.ToString() + " on Device: [" + Environment.MachineName + " - " + Environment.UserDomainName + " - " + Environment.UserName
                    + "].\n\nBest Regards, \nIEEE CUSB Portal";
                DefaultLoginMsg = new MailMessage(MailAddress.Address, MailAddress.Address, "Logged In From IEEE CUSB Portal", DefaultLoginMessage);
            }
            catch
            {
                
            }
        }
        public bool testAuthentication()
        {
            return sendMessage(DefaultLoginMsg);
        }
        public bool sendMessage(string toAddress, string mailSubject, string mailBody)
        {
            try
            {
                MailMessage message = new MailMessage(MailAddress.Address, toAddress)
                {
                    Subject = mailSubject,
                    Body = mailBody
                };
                smtp.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sendMessage(MailMessage mailMessage)
        {
            try
            {
                smtp.Send(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    };
}
