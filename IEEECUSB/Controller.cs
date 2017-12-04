﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace IEEECUSB
{
    public enum Status { Accepted, Rejected, Submitted };
    public class Controller
    {
        private DBManager dbMan; // A Reference of type DBManager 

        internal DataTable SelectCommMember()
        {
            string query = $"SELECT ID, Name, Responsibility_Description From Volunteer where Committee_ID="+CommitteeID+";";
            return dbMan.ExecuteReader(query);
        }

        // (Initially NULL; NO DBManager Object is created yet)
        public int UserID=2;

        internal object SelectHeadUpdates()
        {
            string query = "SELECT Volunteer.Name ,Task.Title , Task.Start_Date,Task.End_Date ,Task.Description  from" +
            " Task join TaskRecievers on Task.ID=Task_ID join Volunteer on Assigner_ID=Volunteer.ID" +
            " where Task.Status IS NULL and Reciever_ID=" + UserID + " UNION " +
            "select Committee.Name,Request.Title,Request.Start_Date,Request.End_Date,Request.Description FROM " +
            "Request join Committee on Request.ID = Sender_Comm_ID " +
            "where Reciever_Comm_ID= " + CommitteeID + ";";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SearchVoluntHistByName(string name)
        {
            string query = "SELECT * From Volunteer where Name Like '%" + name + "%';";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SearchVoluntHistByID(int id)
        {
            string query = "SELECT * From Volunteer where ID="+id+";";
            return dbMan.ExecuteReader(query);
        }

        internal object SearchInCommByName(string searchFor)
        {
            string query = "SELECT ID, Name, Responsibility_Description From Volunteer where Committee_ID=" + CommitteeID + " and Name like '%" + searchFor + "%';";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SearchInCommByID(int iD)
        {
            string query = "SELECT ID, Name, Responsibility_Description From Volunteer where Committee_ID=" + CommitteeID + " and ID like '%"+iD+"%';";
            return dbMan.ExecuteReader(query);
        }

        public int CommitteeID=2;
        public Controller()
        {
            dbMan = new DBManager(); // Create the DBManager Object
        }
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        //checks the username/password and returns the priviledges associated with this user
        //Returns 0 in case of error
        public DataTable Login(string username, string password)
        {
            //Query the DB to check for username/password
            string query = "SELECT ID ,Committee_ID from Volunteer where Mail = "+username+" and password="+password+" limit 1;";            
            DataTable p = dbMan.ExecuteReader(query);
            //UserID=p
            return p;
        }

        internal object SelectMemberNotif()
        {
            string query = "SELECT Volunteer.Name ,Task.Title , Task.Start_Date,Task.End_Date Task.Description  from" +
                " Task join TaskRecievers on Task.ID=Task_ID join Volunteer on Assigner_ID=Volunteer.ID" +
                " where Task where Status IS NULL and Reciever_ID="+UserID+";";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SelectCommittees()
        {
            string query = $"SELECT ID, Name From Committee;";
            return dbMan.ExecuteReader(query);
        }

        internal int InsertEvent(string title, int CommitteeID)
        {
            string query = $"INSERT INTO Event (Title,Committee_ID) Values ('"+title+"',{CommitteeID})";
            return dbMan.ExecuteNonQuery(query);
        }

        internal int MemeberSubmitRequest(int requestID, string progressDesc, int progressPerc)
        {
            string query = $"UPDATE Request SET Status ='"+Status.Submitted+"',Progress_Description ='"+progressDesc+"' , Progress_Percentage="+progressPerc+" where ID="+requestID+"";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectReceivedRequests()
        {

            string query = $"SELECT Request.ID,Title , Committee.Name as 'Sender Committee' , Description , DATE_FORMAT(Request.Start_date,'%Y-%m-%d') ,DATE_FORMAT(Request.End_date,'%Y-%m-%d') ,Priority,Status FROM Request join Committee on Committee.ID = Sender_Comm_ID  where Reciever_Comm_ID = "+CommitteeID+";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectSentRequests()
        {

            string query = $"SELECT Request.ID,Title , Committee.Name as 'Received Committee' , Description ,DATE_FORMAT(Request.Start_date,'%Y-%m-%d') ,DATE_FORMAT(Request.End_date,'%Y-%m-%d') ,Priority,Status FROM Request join Committee on Committee.ID = Reciever_Comm_ID  where Sender_Comm_ID = "+CommitteeID+";";
            return dbMan.ExecuteReader(query);
        }
        public int InsertRequest(string Title,string Desc,string Start_Date,string End_Date, int Reciever_Comm_ID)
        {
            string query = "INSERT INTO Request (Title, Reciever_Comm_ID,Description,Start_Date,End_Date, Sender_Comm_ID) Values ('"+Title+"',"+Reciever_Comm_ID+",'"+Desc+"','"+Start_Date+"','"+End_Date+"',"+CommitteeID+")";
            return dbMan.ExecuteNonQuery(query);
        }
        internal int EditRequest(int requestID, string Title, string Description, string Start_Date, string End_Date, int Reciever_Comm_ID)
        {
            string today = DateTime.Today.ToString("yyyy-mm-dd");
            string query = $"UPDATE Request SET Status =NULL,Title='"+Title+"',Description='"+Description+"',Start_Date='"+Start_Date+"',End_Date='"+End_Date+"',Creation_Date='"+today+"',Reciever_Comm_ID="+Reciever_Comm_ID+",Sender_Comm_ID="+CommitteeID+" where ID="+requestID+"";
            return dbMan.ExecuteNonQuery(query);
        }

        internal object SelectHeadNotif()
        {
            string query = "SELECT Volunteer.Name ,Task.Title , Task.Start_Date,Task.End_Date ,Task.Description  from" +
                 " Task join TaskRecievers on Task.ID=Task_ID join Volunteer on Assigner_ID=Volunteer.ID" +
                " where Task.Status IS NULL and Reciever_ID=" + UserID + " UNION " +
                "select Committee.Name,Request.Title,Request.Start_Date,Request.End_Date,Request.Description FROM " +
                "Request join Committee on Request.ID = Sender_Comm_ID " +
                "where Reciever_Comm_ID= "+CommitteeID+";";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SelectEvents(DateTime date)
        {
            string query = $"SELECT Title FROM Event join Committee on Event.ID =Committee.ID where Committee.ID="+CommitteeID+" AND '"+date.ToString("yyyy-MM-dd")+"' between Event.Start_Date and Event.End_Date ;";
            return dbMan.ExecuteReader(query);
        }

        public int InsertVolunteer(string Name,int Committee_ID )
        {
            string query = $"INSERT INTO Volunteer (Name,Committee_ID) Values ('"+Name+"',"+Committee_ID+")";
            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertCommittee(int Season,string Name)
        {
            string query = $"INSERT INTO Committee (Season, Name) Values ("+Season+",'"+Name+"')";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateRequestStatus(int Request_ID,Status status)
        {
            string query = $"UPDATE Request SET Status ='"+status+"' where ID="+Request_ID+";";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable Reciever_Request()
        {
            string query = "SELECT Committee.Name , Request.Title  FROM Request join Committee on Request.Sender_Comm_ID=Committee.ID  Where Request.Reciever_Comm_ID=" + CommitteeID +";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Sender_Request(int Committee_ID)
        {
            string query = "SELECT Committee.Name , Request.Title , Request.Description , Request.Priority , Request.Start_Date, Request.Deadline_Date FROM Request, Committee  Where Request.Sender_Comm_ID=" + Committee_ID + " , Committee.ID = Request.Reciever_Comm_ID; ";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Member_Notification(int Member_ID)
        {
            string query = "SELECT Descriptoin, Type FROM Notification Where Vol_ID =" + Member_ID + " and Task.Assigner_ID = Volunteer.ID ; ";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Committee_Tasks()
        {
            string query = $"SELECT Volunteer.Name, Task.Title , TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date " +
                "FROM Task join TaskRecievers on Task_ID=Task.ID " +
                "join Volunteer on Volunteer.ID=Reciever_ID " +
                $"where Volunteer.Committee_ID = "+CommitteeID+";";
            return dbMan.ExecuteReader(query);
        }

        internal int DeleteRequest(int Request_ID)
        {
            string query = $"DELETE FROM Request WHERE ID="+Request_ID+";";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable Committee_File(int Committee_ID)
        {
            string query = "SELECT Title , Description , Version, Opened , Type FROM File Where Committee_ID =" + Committee_ID + "; ";
            return dbMan.ExecuteReader(query);
        }
        //
        public DataTable GetTask(int Task_ID)
        {
            string query = "SELECT * FROM Task Where ID =" + Task_ID + "; ";
            return dbMan.ExecuteReader(query);
        }

         public DataTable GetTaskRecievers(int Task_ID)
        {
            string query = "SELECT Volunteer.Name FROM TaskRecievers join Volunteer on Volunteer.ID = TaskRecievers.Reciever_ID Where TaskRecievers.Task_ID =" + Task_ID + ";";
            return dbMan.ExecuteReader(query);
        }

         public int InsertTask(string Title, int Sender_ID,int Committee_ID)
        {
            string query = $"INSERT INTO Task (Title, Assigner_ID,Committee_ID) Values ("+Title+","+Sender_ID+","+Committee_ID+")";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertTaskReciever(int Task_ID , int Member_ID)
        {
            string query = $"INSERT INTO TaskRecievers (Task_ID, Reciever_ID,Season) Values ("+Task_ID+","+Member_ID+",2017)";
            return dbMan.ExecuteNonQuery(query); 
        }

        public int UpdateTask(int Task_ID,int Progress_Percentage, string Progress_Description , int Volunteer_ID)
        {
            string query = $"UPDATE TaskRecievers SET  Progress_Percentage='"+Progress_Percentage+"' AND Progress_Description='"+Progress_Description+"'  where Task_ID="+Task_ID+" AND Reciever_ID='"+Volunteer_ID+"'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateTaskStatus(int Task_ID, int Volunteer_ID ,Status status)
        {
            string query = $"UPDATE TaskRecievers SET Status ='"+status+"' where Task_ID="+Task_ID+" AND Reciever_ID='"+Volunteer_ID+"'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int SubmitTask(int Task_ID, int Volunteer_ID)
        {
            DateTime dateTimeVariable = DateTime.Now;
            string date = dateTimeVariable.ToString("yyyy-MM-dd H:mm:ss");
            string query = $"UPDATE TaskRecievers SET Status ='"+Status.Submitted+"' where Task_ID="+Task_ID+" AND Reciever_ID='"+Volunteer_ID+"'";
            return dbMan.ExecuteNonQuery(query);
        }

         public DataTable Member_Tasks()
        {
            string query = "SELECT Volunteer.Name , Task.ID , Task.Title ,  TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date FROM Task,Volunteer,TaskRecievers Where TaskRecievers.Reciever_ID =" + UserID + " AND Task.Assigner_ID = Volunteer.ID AND  TaskRecievers.Task_ID = Task.ID ; ";
            return dbMan.ExecuteReader(query);
        }

         public DataTable Committee_Members()
        {
            string query = "SELECT Name FROM Volunteer Where Committee_ID =" + CommitteeID + "; ";
            return dbMan.ExecuteReader(query);
        }

    }
}
