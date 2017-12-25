using System;
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

        // (Initially NULL; NO DBManager Object is created yet)
        public const int UserID = 53;
        public const int SectionID = -1;
        public const int CommitteeID = 100;

        internal DataTable SelectCommMember()
        {
            string query = "SELECT ID, Name, Responsibility_Description From Volunteer where Committee_ID="+CommitteeID+";";
            return dbMan.ExecuteReader(query);
        }


        internal DataTable SelectSectionCommittees()
        {
            string query = "SELECT Committee.ID, Committee.Name From Committee join Section on Section.ID=Section_ID where Supervisor_ID=" + UserID + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectCommittee()
        {
            string query = "SELECT Committee.ID, Committee.Name From Committee Where Section_ID <> -1;";
            return dbMan.ExecuteReader(query);
        }

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

        internal DataTable CommRequests(int CommID)
        {
            string query = "select Request.Title,Request.Priority,Request.Description,Request.Start_Date,Request.Deadline_Date,SC.Name as 'Sender Committee',RC.Name as 'Reciever Committee' From Request" +
                " join Committee as SC on Request.Sender_Comm_ID=SC.ID join Committee as RC on Request.Reciever_Comm_ID=RC.ID where Sender_Comm_ID=" + CommID + " or Reciever_Comm_ID=" + CommID + ";";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SearchVoluntHistByName(string name)
        {
            string query = "SELECT * From Volunteer where Name Like '%" + name + "%';";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SearchVoluntHistByID(int id)
        {
            string query = "SELECT * From Volunteer where ID='"+id+"';";
            return dbMan.ExecuteReader(query);
        }

        internal object SearchInCommByName(string searchFor)
        {
            string query = "SELECT ID, Name, Responsibility_Description From Volunteer where Committee_ID='" + CommitteeID + "' and Name like '%" + searchFor + "%';";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SupervisorCommsRequests()
        {
            string query = "SELECT * from Request join Committee on Committee.ID=Request.Sender_Comm_ID join Section on Section.ID=Section_ID " +
                "where Section.Supervisor_ID=" + UserID + " union " +
                "SELECT * from Request join Committee on Committee.ID=Request.Reciever_Comm_ID join Section on Section.ID=Section_ID " +
                "where Section.Supervisor_ID=" + UserID + ";";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SearchInCommByID(int iD)
        {
            string query = "SELECT ID, Name, Responsibility_Description From Volunteer where Committee_ID=" + CommitteeID + " and ID like '%"+iD+"%';";
            return dbMan.ExecuteReader(query);
        }

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

        public DataTable Member_Notification()
        {
            string query = "SELECT Descriptoin FROM Notification join Volunteer on Notificatoin.Vol_ID = Volunteer.ID Where (Vol_ID ='" + UserID + "' AND Notificatoin.Creation_Date < Volunteer.Last_Login) ; ";
            return dbMan.ExecuteReader(query);
        }

        public int InsertNotification(string Description, string Type, DateTime Date, int Vol_ID)
        {
            string query = $"INSERT INTO Notification (Description, Type, Creation_Date, Vol_ID) Values ('"+Description+"','"+Type+"','"+DateTime.Now.ToString("yyyy-MM-dd")+"','"+Vol_ID+"')";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable Committee_Tasks(int Committee_ID = CommitteeID)
        {
            string query = $"SELECT Volunteer.Name, Task.Title , TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date " +
                "FROM Task join TaskRecievers on Task_ID=Task.ID " +
                "join Volunteer on Volunteer.ID=Reciever_ID " +
                "where Volunteer.Committee_ID = '" + Committee_ID + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable CommTask(int Committee_ID = CommitteeID)
        {
            string query = "SELECT Task.ID , Task.Title ,Volunteer.Name as Assigner, Task.Start_Date, Task.Deadline_Date , Task.Description FROM Task join Volunteer on Volunteer.ID = Task.Assigner_ID WHERE Task.Committee_ID ='" + Committee_ID +"';";
            return dbMan.ExecuteReader(query);
        }


        internal int DeleteTask(int Task_ID)
        {
            string query = $"DELETE FROM Task WHERE ID='" + Task_ID + "';";
            return dbMan.ExecuteNonQuery(query);
        }


        internal int DeleteRequest(int Request_ID)
        {
            string query = $"DELETE FROM Request WHERE ID='"+Request_ID+"';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable Committee_File(int Committee_ID)
        {
            string query = "SELECT Title , Description , Version, Opened , Type FROM File Where Committee_ID ='" + Committee_ID + "'; ";
            return dbMan.ExecuteReader(query);
        }
        //
        public DataTable GetTask(int Task_ID)
        {
            string query = "SELECT * FROM Task Where ID ='" + Task_ID + "';";
            return dbMan.ExecuteReader(query);
        }


        public DataTable GetTaskRecievers(int Task_ID)
        {
            string query = "SELECT Volunteer.Name FROM TaskRecievers join Volunteer on Volunteer.ID = TaskRecievers.Reciever_ID Where TaskRecievers.Task_ID ='" + Task_ID + "';";
            return dbMan.ExecuteReader(query);
        }


        public int InsertTask(string Title,string description ,DateTime Start_Date , DateTime Deadline)
        {
            string query = "INSERT INTO Task (Title,Description , Assigner_ID,Committee_ID , Creation_Date , Start_Date , Deadline_Date) Values ('" + Title + "','" + description + "','" + UserID + "','" + CommitteeID + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Start_Date.ToString("yyyy-MM-dd") + "','" + Deadline.ToString("yyyy-MM-dd") + "')";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertTaskReciever(int Task_ID, int Member_ID)
        {
            string query = "INSERT INTO TaskRecievers (Task_ID, Reciever_ID) Values ('"+ Task_ID +"','"+ Member_ID+"')";
            return dbMan.ExecuteNonQuery(query);
        }


        public int UpdateTask(int Task_ID, int Progress_Percentage, string Progress_Description)
        {
            string query = $"UPDATE TaskRecievers SET  Progress_Percentage='" + Progress_Percentage + "' AND Progress_Description='" + Progress_Description + "'  where Task_ID='" + Task_ID + "' AND Reciever_ID='" + UserID + "'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateTaskStatus(int Task_ID,Status status)
        {
            string query = $"UPDATE TaskRecievers SET Status ='"+status+"' where Task_ID='"+Task_ID+"' AND Reciever_ID='"+ UserID +"'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int SubmitTask(int Task_ID)
        {
            string query = "UPDATE TaskRecievers SET Status ='Submitted',Submission_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where Task_ID='" + Task_ID + "' AND Reciever_ID='" + UserID + "'";
            return dbMan.ExecuteNonQuery(query);
        }


        public DataTable Member_Tasks()
        {
            string query = "SELECT Task.ID , Volunteer.Name , Task.Title ,  TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date FROM Task,Volunteer,TaskRecievers Where TaskRecievers.Reciever_ID =" + UserID + " AND Task.Assigner_ID = Volunteer.ID AND TaskRecievers.Task_ID = Task.ID AND TaskRecievers.Status = 'Accepted' ; ";
            return dbMan.ExecuteReader(query);
        }


        public int Edit_Task(int Task_ID, string Title, string Description, int Sender_ID, int Committee_ID)
        {
            string query = $"UPDATE Task SET  Title='" + Title + "' AND Description ='" + Description + "' AND Assigner_ID='" + UserID + "' AND Committee_ID='" + CommitteeID + "'  where Task_ID=" + Task_ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable GetTaskRecieversID(int Task_ID)
        {
            string query = "SELECT Reciever_ID FROM TaskRecievers Where TaskRecievers.Task_ID =" + Task_ID + ";";
            return dbMan.ExecuteReader(query);
        }


        public int DeleteTaskRec(int Task_ID)
        {
            string query = "DELETE FROM TaskRecievers WHERE Task_ID = '" + Task_ID + "';";
            return dbMan.ExecuteNonQuery(query);
        }


        public DataTable Committee_Members(int Committee_ID = CommitteeID)
        {
            if (Committee_ID == 101 || Committee_ID == 100)
            {
                string query = "SELECT ID , Name FROM Volunteer Where Job_Title = 'Head' OR Job_Title = 'Supervisor' ; ";
                return dbMan.ExecuteReader(query);
            }
            else
            {
                string query = "SELECT ID , Name FROM Volunteer Where Committee_ID ='" + Committee_ID + "'; ";
                return dbMan.ExecuteReader(query);
            }
        }

        public DataTable Workshops_Members()
        {
            if (CommitteeID == 100)
            {
                string query = "SELECT ID , Name FROM Volunteer; ";
                return dbMan.ExecuteReader(query);
            }
            else if (CommitteeID == 101)
            {
                string query = "SELECT ID , Name FROM Volunteer; ";
                return dbMan.ExecuteReader(query);
            }
            else
            {
                string query = "SELECT ID , Name FROM Volunteer Where Committee_ID ='" + CommitteeID + "'; ";
                return dbMan.ExecuteReader(query);
            }
        }

        public DataTable Committee(int Committee_ID = CommitteeID)
        {

            if (Committee_ID == 100)
            {
                string query = "SELECT ID , Name , Evaluation_Percentage FROM Volunteer Where Job_Title <> 'Officer'; ";
                return dbMan.ExecuteReader(query);
            }
            else if (Committee_ID == 101)
            {
                string query = "SELECT ID , Name , Evaluation_Percentage FROM Volunteer Where Job_Title <> 'Officer' AND Job_Title <> 'Supervisor'; ";
                return dbMan.ExecuteReader(query);
            }
            else
            {
                string query = "SELECT ID , Name , Evaluation_Percentage FROM Volunteer Where Job_Title <> 'Officer' AND Job_Title <> 'Supervisor'; ";
                return dbMan.ExecuteReader(query);
            }
        }

        public DataTable MaxTaskID()
        {

            string query = "SELECT MAX(ID) FROM Task;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Committee_Workshop()
        {
            if (CommitteeID == 101)
            {
                string query = "SELECT Workshop.ID , Workshop.Name , Workshop.Outline , Workshop.Type, Workshop.Expected_Sessions , Workshop.Start_Date , Workshop.End_Date FROM Workshop,Committee,Section,Volunteer Where Volunteer.ID = Section.Supervisor_ID AND Committee.Section_ID = Section.ID AND Workshop.Committee_ID = Committee.ID AND Volunteer.ID='" + UserID + "';; ";
                return dbMan.ExecuteReader(query);
            }
            else if (CommitteeID == 100)
            {
                string query = "SELECT * FROM Workshop; ";
                return dbMan.ExecuteReader(query);
            }
            else
            {
                string query = "SELECT * FROM Workshop Where Committee_ID ='" + CommitteeID + "'; ";
                return dbMan.ExecuteReader(query);
            }
        }

        public DataTable GetWorkshop(int ID)
        {
            string query = "SELECT * FROM Workshop Where ID ='" + ID + "'; ";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetWorkshopIns(int Workshop_ID)
        {
            string query = "SELECT Volunteer.Name FROM SessionInstructor join Volunteer on Volunteer.ID = SessionInstructor.Vol_ID Where SessionInstructor.Workshop_ID ='" + Workshop_ID + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetWorkshopSessions(int Workshop_ID)
        {
            string query = "SELECT * FROM Session Where Session.Workshop_ID ='" + Workshop_ID + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetSession(int Workshop_ID, int no)
        {
            string query = "SELECT * FROM Session Where Session.Workshop_ID ='" + Workshop_ID + "' AND Session.Number ='" + no + "' ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SessionCount(int Workshop_ID)
        {
            string query = "SELECT Count(*) FROM Session Where Session.Workshop_ID ='" + Workshop_ID + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Vol_Session_Count(int Workshop_ID, int no)
        {
            string query = "SELECT COUNT(*) FROM Volunteer_Session_Attend Where Workshop_ID ='" + Workshop_ID + "' AND Session_Number ='" + no + "' ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Part_Session_SessionCount(int Workshop_ID, int no)
        {
            string query = "SELECT COUNT(*) FROM Participant_Session_Attend Where Workshop_ID ='" + Workshop_ID + "' AND Session_Number ='" + no + "' ;";
            return dbMan.ExecuteReader(query);
        }

        public int InsertWorkshop(string Name, string Outline, int Type, DateTime Start_Date, DateTime End_Date, int Session_No)
        {
            string query = $"INSERT INTO Workshop (Name , Outline , Type , Start_Date , End_Date , Expected_Sessions , Committee_ID , Committee_Season) Values ('" + Name + "','" + Outline + "','" + Type + "','" + Start_Date.ToString("yyyy-MM-dd") + "','" + End_Date.ToString("yyyy-MM-dd") + "','" + Session_No + "','" + CommitteeID + "',2017)";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable MaxWorkshopID()
        {
            string query = "SELECT MAX(ID) FROM Workshop;";
            return dbMan.ExecuteReader(query);
        }

        public int InsertSessionIns(int Workshop_ID, int Member_ID)
        {
            string query = $"INSERT INTO SessionInstructor (Workshop_ID, Vol_ID) Values (" + Workshop_ID + "," + Member_ID + ")";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable CountVolunteer_Enrolled(int Workshop_ID)
        {
            string query = "SELECT Count(*) FROM Volunteer_Workshop_Enrolled where Workshop_ID="+ Workshop_ID + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable CountParticipant_Enrolled(int Workshop_ID)
        {
            string query = "SELECT Count(*) FROM Participant_Workshop_Enrolled where Workshop_ID=" + Workshop_ID + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Participant_Enrolled(int Workshop_ID)
        {
            string query = "SELECT Participant.ID,Patricipant.Name  FROM Participant_Workshop_Enrolled join Participant on Participant.ID=Participant_Workshop_Enrolled.Participant_ID where Participant_Workshop_Enrolled.Workshop_ID=" + Workshop_ID + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Volunteer_Enrolled(int Workshop_ID)
        {
            string query = "SELECT Volunteer.ID , Volunteer.Name  FROM Volunteer_Workshop_Enrolled join Volunteer on Volunteer.ID = Volunteer_Workshop_Enrolled.Volunteer_ID where Volunteer_Workshop_Enrolled.Workshop_ID=" + Workshop_ID + ";";
            return dbMan.ExecuteReader(query);
        }

        public int InsertAttender_Vol(int Workshop_ID, int Session_No , int Attender_ID)
        {
            string query = $"INSERT INTO Volunteer_Session_Attend (Workshop_ID, Session_Number, Attender_ID) Values (" + Workshop_ID + "," + Session_No + "," + Attender_ID + ")";
            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertAttender_Part(int Workshop_ID, int Session_No, int Attender_ID)
        {
            string query = $"INSERT INTO Participant_Session_Attend (Workshop_ID, Session_Number, Attender_ID) Values (" + Workshop_ID + "," + Session_No + "," + Attender_ID + ")";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertUpdate(string Description)
        {
            if (CommitteeID == 100)
            {
                string query = "INSERT INTO MahmoudMorsy.Update (Description, Type , Volunteer_ID , Section_ID , Committee_ID , Committee_Season, End_Date) Values ('" + Description + "', 'Officer' ,'" + UserID + "','" + SectionID + "','" + CommitteeID + "',2017,'"+ DateTime.Now.AddDays(7).ToString("yyyy-MM-dd") + "')";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (CommitteeID == 101)
            {
                string query = "INSERT INTO MahmoudMorsy.Update (Description, Type , Volunteer_ID , Section_ID , Committee_ID , Committee_Season, End_Date) Values ('" + Description + "','Supervisor' ,'" + UserID + "','" + SectionID + "','" + CommitteeID + "',2017,'" + DateTime.Now.AddDays(7).ToString("yyyy-MM-dd") + "')";
                return dbMan.ExecuteNonQuery(query);
            }
            else
            {
                string query = "INSERT INTO MahmoudMorsy.Update (Description, Type , Volunteer_ID , Section_ID , Committee_ID , Committee_Season, End_Date) Values ('" + Description + "',' Head ','" + UserID + "','" + SectionID + "','" + CommitteeID + "',2017,'" + DateTime.Now.AddDays(7).ToString("yyyy-MM-dd") + "')";
                return dbMan.ExecuteNonQuery(query);
            }
        }

        public DataTable Member_Updates()
        {
            DateTime y = DateTime.Now;
            if (CommitteeID == 100)
            {
                string query = "SELECT Description From Update Where End_Date > '" + y.ToString("yyyy-MM-dd") + "';";
                return dbMan.ExecuteReader(query);
            }
            else if (CommitteeID == 101)
            {
                string query = "SELECT Description From Update Where (Section_ID = '"+ SectionID + "' AND End_Date > '" + y.ToString("yyyy-MM-dd") + "');";
                return dbMan.ExecuteReader(query);
            }
            else
            {
                string off = "Officer";
                string sup = "Supervisor";
                string query = "SELECT Description From Update Where (Committee_ID = '" + CommitteeID + "' AND End_Date > '" + y.ToString("yyyy-MM-dd") + "') OR (Type = '" + off + "' AND End_Date > '" + y.ToString("yyyy-MM-dd") + "') OR (Type = '" + sup + "' AND Section_ID = '" + SectionID + "' AND End_Date > '" + y.ToString("yyyy-MM-dd") + "');";
                return dbMan.ExecuteReader(query);
            }
        }

        public DataTable HighBoard_Tasks()
        {
            string head = "Head";
            string sup = "Supervisor";
            string query = "SELECT Task.ID ,Volunteer.Name , Task.Title , TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date FROM Task ,TaskRecievers ,Volunteer  WHERE Volunteer.ID=TaskRecievers.Reciever_ID AND TaskRecievers.Task_ID=Task.ID AND (Volunteer.Job_Title = '" + head + "' OR '" + sup + "') ;";
            return dbMan.ExecuteReader(query);
        }


        public int Last_Login()
        {
            string query = "UPDATE Volunteer SET Last_Login='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where ID='"+ UserID + "';";
            return dbMan.ExecuteNonQuery(query);           
        }

        public DataTable Helping_Committee_Member()
        {
           
            string query = "SELECT Helping_Comm_ID FROM Volunteer  WHERE ID ='"+UserID+"' ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Count_Member_Sub(int Member_ID)
        { 
            string query = "SELECT COUNT(Task_ID) FROM TaskRecievers  WHERE Reciever_ID ='"+ Member_ID + "' AND Status='Submitted';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Count_Member_Accept(int Member_ID)
        {
            string query = "SELECT COUNT(Task_ID) FROM TaskRecievers  WHERE Reciever_ID ='" + Member_ID + "' AND Status='Accepted';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Count_Member_Rejected(int Member_ID)
        {
            string query = "SELECT COUNT(Task_ID) FROM TaskRecievers  WHERE Reciever_ID ='" + Member_ID + "' AND Status='Rejected';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Count_Member_Total(int Member_ID)
        {
            string query = "SELECT COUNT(Task_ID) FROM TaskRecievers  WHERE Reciever_ID ='" + Member_ID + "';";
            return dbMan.ExecuteReader(query);
        }

        public int Evaluation(double x , int ID)
        {
            string query = "UPDATE Volunteer SET Evaluation_Percentage= '"+ x +"' where ID ='"+ ID +"';";
            return dbMan.ExecuteNonQuery(query);
        }

    }
}
