using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace IEEECUSB
{
    public enum Status { Accepted, Rejected, Submitted };
    public enum Position { Member, Head, ViceHead, Supervisor, Officer, None };
    public enum ErrorType { NotRegistered, LoginFailed, Other, NoErrors };
    public class Controller
    {
        private DBManager dbMan; // A Reference of type DBManager 
        private GoogleMail mailAccount;
        private FTPManager ftpMan;
        // (Initially NULL; NO DBManager Object is created yet)
        public int UserID = 58;
        public int CommitteeID = 1;
        public int Season = 0;
        public string JobPosition = "";
        public int SectionID = -1;
        internal ErrorType Login(GoogleMail MailAccount)
        {
            /* This function logins and returns the user id */
            ErrorType functionReturn = ErrorType.NoErrors;

            string query = "SELECT Name, ID FROM Volunteer WHERE Mail = '" + MailAccount.MailAddress.Address + "'";
            DataTable returnData = dbMan.ExecuteReader(query);

            if (returnData != null)
            {
                UserID = Convert.ToInt32(returnData.Rows[0]["ID"].ToString());
                string Name = returnData.Rows[0]["Name"].ToString();
                mailAccount = new GoogleMail(MailAccount.MailAddress.Address, MailAccount.MailPassword, Name);

                if (!mailAccount.testAuthentication())
                {
                    functionReturn = ErrorType.LoginFailed;
                    mailAccount = null;
                }
                else
                {
                    functionReturn = ErrorType.NoErrors;

                }
            }
            else
            {
                functionReturn = ErrorType.NotRegistered;
            }

            return functionReturn;
        }
        internal Position DetermineVolunteerPosition()
        {
            Position returnPosition = Position.Member;

            string query = "SELECT Name, Job_Title, Committee_ID, Season FROM Volunteer WHERE ID='" + UserID.ToString() + "' AND Mail = '" + mailAccount.MailAddress.Address + "'";
            DataTable returnData = dbMan.ExecuteReader(query);

            if (returnData != null)
            {
                CommitteeID = Convert.ToInt32(returnData.Rows[0]["Committee_ID"].ToString());
                Season = Convert.ToInt32(returnData.Rows[0]["Season"].ToString());
                JobPosition = returnData.Rows[0]["Job_Title"].ToString();
                
            }

            if (JobPosition == "Member")
            {
                returnPosition = Position.Member;
            }
            else if (JobPosition == "Head")
            {
                returnPosition = Position.Head;
            }
            else if (JobPosition == "Vice")
            {
                returnPosition = Position.ViceHead;
            }
            else if (JobPosition == "Supervisor")
            {
                query = "SELECT ID FROM Section WHERE Supervisor_ID=" + UserID+ ";";
                returnData = dbMan.ExecuteReader(query);
                returnPosition = Position.Supervisor;
                if (returnData != null)
                {
                    //SectionID = Convert.ToInt32(returnData.Rows[0]["ID"].ToString());
                    SectionID = -1; 
                }
                else
                {
                    returnPosition = Position.None;
                }
            }
            else if (JobPosition == "Officer")
            {
                returnPosition = Position.Officer;
                SectionID = -1;
            }
            else
            {
                returnPosition = Position.None;
            }
            return returnPosition;
        }
        internal ErrorType AdminLogin(string LoginUser, string LoginPass)
        {
            string query = $"SELECT * FROM Admin WHERE Username='{LoginUser}' AND Password='{LoginPass}'";
            DataTable ret = dbMan.ExecuteReader(query);
            if (ret == null)
            {
                return ErrorType.LoginFailed;
            }
            else
            {
                return ErrorType.NoErrors;
            }
        }

        internal DataTable SelectCommMember()
        {
            string query = "SELECT ID, Name, Responsibility_Description From Volunteer where Committee_ID=" + CommitteeID + ";";
            return dbMan.ExecuteReader(query);
        }
        internal object GetEvaluation()
        {
            string query = $"SELECT Evaluation_Percentage From Volunteer where ID={UserID}";
            return dbMan.ExecuteScalar(query);
        }
        internal string GetCommitteeFolderPath()
        {
            string Path = "";

            string query = "SELECT Season, Name, Section_ID FROM Committee WHERE ID='" + CommitteeID.ToString() + "'";
            DataTable returnData = dbMan.ExecuteReader(query);

            if (returnData != null)
            {
                string SectionName = "";
                string Season = returnData.Rows[0]["Season"].ToString();
                string CommiteeName = returnData.Rows[0]["Name"].ToString();
                string SectionID = returnData.Rows[0]["Section_ID"].ToString();
                //MessageBox.Show(SectionName + Season + CommiteeName + SectionID);
                query = "SELECT Name FROM Section WHERE ID='" + SectionID + "'";
                returnData = dbMan.ExecuteReader(query);

                if (returnData != null)
                {
                    SectionName = returnData.Rows[0]["Name"].ToString();
                    //MessageBox.Show(SectionName);
                    Path = Season + "/" + SectionName + "/" + CommiteeName + "/";
                }
            }
            //MessageBox.Show(Path);
            return Path;
        }
        internal bool UploadFile(string LocalFilePath, string ServerDestinationPath, string DestFileName, string FileType, string FileDescription)
        {
            string query = $"INSERT INTO File(Title, Description, Type, Writer_ID, Committee_ID, Committee_Season, URL) Values('{DestFileName}', '{FileDescription}','{FileType}', '{UserID.ToString()}', '{CommitteeID}', '{Season}', '{ServerDestinationPath + "/" + DestFileName + FileType}')";
            bool Ret = ftpMan.uploadFile(LocalFilePath, ServerDestinationPath + DestFileName + FileType);
            if (Ret)
            {
                dbMan.ExecuteNonQuery(query);
            }
            return Ret;
        }
        internal bool DownloadFile(string LocalFilePath, string ServerLocationPath)
        {
            return ftpMan.downloadFile(LocalFilePath, ServerLocationPath);
        }
        internal DataTable GetCommitteeFiles()
        {
            string query = $"SELECT Name, Title As 'File Title', Description, Type, URL FROM File, Volunteer WHERE Volunteer.ID=Writer_ID AND File.Committee_ID='{CommitteeID.ToString()}'";
            return dbMan.ExecuteReader(query);
        }
        internal DataTable GetDBTablesList()
        {
            string query = "SHOW TABLES";
            return dbMan.ExecuteReader(query);
        }
        internal DataTable GetTableData(string TableName)
        {
            string query = "SELECT * FROM " + TableName + ";";
            return dbMan.ExecuteReader(query);
        }
        internal int AddCommittee(string CommitteeName, string HeadID, string ViceHeadID, string SeasonNumber, string SectionID)
        {
            string query = "";
            if (HeadID == "" && ViceHeadID == "")
            {
                query = $"INSERT INTO Committee(Season, Name, Section_ID) Values('{SeasonNumber}', '{CommitteeName}', '{SectionID}')";
            }
            else if (HeadID != "" && ViceHeadID == "")
            {
                query = $"INSERT INTO Committee(Season, Name, Section_ID, Head_ID) Values('{SeasonNumber}', '{CommitteeName}', '{SectionID}', '{HeadID}')";
            }
            else if (HeadID != "" && ViceHeadID != "")
            {
                query = $"INSERT INTO Committee(Season, Name, Section_ID, Head_ID, Vice_ID) Values('{SeasonNumber}', '{CommitteeName}', '{SectionID}', '{HeadID}', '{ViceHeadID}')";
            }
            return dbMan.ExecuteNonQuery(query);
        }
        internal DataTable GetSectionID(string SeasonNumber, string SectionName)
        {
            string query = $"SELECT ID FROM Section WHERE Season='{SeasonNumber}' AND Name='{SectionName}'";
            return dbMan.ExecuteReader(query);
        }
        internal DataTable GetAvailableSeasons()
        {
            string query = "SELECT Season_no FROM Season";
            return dbMan.ExecuteReader(query);
        }
        internal DataTable GetAvailableSections(string Season)
        {
            string query = "SELECT Season, ID, Name FROM Section WHERE Season='" + Season + "'";
            return dbMan.ExecuteReader(query);
        }
        internal int AddSeason(string SeasonNumber, string ChairID, string ViceID, string TreasurerID, string SecretaryID)
        {
            if (SeasonNumber == "")
            {
                return 0;
            }
            string query = $"SELECT Season_no FROM Season WHERE Season_no='{SeasonNumber}'";
            DataTable D = dbMan.ExecuteReader(query);
            if (D != null)
            {
                return 0;
            }

            if (ChairID == "" && ViceID == "" && TreasurerID == "" && SecretaryID == "")
            {
                query = $"INSERT INTO Season(Season_no) Values('{SeasonNumber}')";
            }
            else if (ChairID != "" && ViceID == "" && TreasurerID == "" && SecretaryID == "")
            {
                query = $"INSERT INTO Season(Season_no, Chairman_ID) Values('{SeasonNumber}', '{ChairID}')";
            }
            else if (ChairID != "" && ViceID != "" && TreasurerID == "" && SecretaryID == "")
            {
                query = $"INSERT INTO Season(Season_no, Chairman_ID, ViceChairMan_ID) Values('{SeasonNumber}', '{ChairID}', '{ViceID}')";
            }
            else if (ChairID != "" && ViceID != "" && TreasurerID != "" && SecretaryID == "")
            {
                query = $"INSERT INTO Season(Season_no, Chairman_ID, ViceChairMan_ID, Treasurer_ID) Values('{SeasonNumber}', '{ChairID}', '{ViceID}', '{TreasurerID}')";
            }
            else if (ChairID != "" && ViceID != "" && TreasurerID != "" && SecretaryID != "")
            {
                query = $"INSERT INTO Season(Season_no, Chairman_ID, ViceChairMan_ID, Treasurer_ID, Secertary_ID) Values('{SeasonNumber}', '{ChairID}', '{ViceID}', '{TreasurerID}', '{SecretaryID}')";
            }

            return dbMan.ExecuteNonQuery(query);
        }
        internal int AddSection(string SectionName, string SeasonNumber, string SupervisorID, string SecDesc)
        {
            if (SectionName == "" || SeasonNumber == "")
            {
                return 0;
            }
            string query = $"SELECT * FROM Section WHERE Season='{SeasonNumber}' AND Name='{SectionName}'";
            if (dbMan.ExecuteReader(query) != null)
            {
                return 0;
            }

            if (SupervisorID == "" && SecDesc != "")
            {
                query = $"INSERT INTO Section(Season, Name, Description) VALUES('{SeasonNumber}',{SectionName}', '{SecDesc}')";
            }
            else if ((SupervisorID != "" && SecDesc != ""))
            {
                query = $"INSERT INTO Section(Season, Name, Description, Supervisor_ID) VALUES('{SeasonNumber}',{SectionName}', '{SecDesc}', '{SupervisorID}')";
            }
            else if (SupervisorID != "" && SecDesc == "")
            {
                query = $"INSERT INTO Section(Season, Name, Supervisor_ID) VALUES('{SeasonNumber}',{SectionName}', '{SupervisorID}')";
            }
            return dbMan.ExecuteNonQuery(query);
        }

        internal DataTable SelectCommMembers()
        {
            string query = "SELECT * From Volunteer where Committee_ID=" + CommitteeID + ";";
            return dbMan.ExecuteReader(query);
        }
        internal DataTable SelectAllCommittees()
        {
            string query = "SELECT Committee.ID, Committee.Name From Committee ";
            return dbMan.ExecuteReader(query);
        }
        internal DataTable SelectAllWorkshops()
        {
            string query = "SELECT Workshop.ID, Workshop.Name From Workshop ";
            return dbMan.ExecuteReader(query);
        }
        internal int UpdateEvent(int id, string title, string desc, string sdate, string edate)
        {
            string query = $"update  Event set Title='{title}',Description='{desc}',Start_Date='{sdate}',End_Date='{edate}' where ID={id}";
            return dbMan.ExecuteNonQuery(query);
        }
        internal DataTable SearchParticHistByID(int id)
        {
            string query = $"SELECT * From Participant left outer join Participant_Workshop_Enrolled on ID=Participant_ID " +
                $"left outer join Workshop on Workshop.ID=Workshop_ID  where Participant.ID={id} order by Workshop.Committee_Season";
            return dbMan.ExecuteReader(query);
        }
        internal DataTable SearchParticHistByName(string name)
        {
            string query = $"SELECT * From Participant left outer join Participant_Workshop_Enrolled on ID=Participant_ID " +
                $"left outer join Workshop on Workshop.ID=Workshop_ID  where Name Like %{name}% order by Workshop.Committee_Season";
            return dbMan.ExecuteReader(query);
        }
        internal int MemeberUpdateRequest(int requestID, object progressDesc, object progressPerc)
        {
            string query = $"UPDATE Request SET Progress_Description ='{ progressDesc}' , Progress_Percentage={ progressPerc }where ID={ requestID }";
            return dbMan.ExecuteNonQuery(query);
        }
        internal DataTable SelectMemberDetails(int ID)
        {
            string query = $"SELECT * From Volunteer where ID={ID};";
            return dbMan.ExecuteReader(query);
        }
        internal DataTable SelectSectionCommittees()
        {
            string query = "SELECT Committee.ID, Committee.Name From Committee join Section on Section.ID=Section_ID where Supervisor_ID=" + UserID + ";";
            return dbMan.ExecuteReader(query);
        }
        internal int UpdateParticipant(int ID, string name, string Phone, string Mail, string College, string Depart, string University, string GradYear)
        {
            string query = $"update  Participant set Name='{name}',Mobile='{Phone}',Mail='{Mail}',College='{College}',University='{University}',Department='{Depart}',Graduation_Year='{GradYear}' where ID={ID}";
            return dbMan.ExecuteNonQuery(query);
        }
        internal int InsertParticipant(string Name, string NID, int? workshopid, string phone = null, string mail = null, string college = null, string depart = null, string university = null, string gradyear = null)
        {
            string workshop = (workshopid != null) ? ",Workshop_ID" : "";
            string query = $"INSERT INTO Participant (Name,National_ID,Mobile,Mail,College,University,Department,Graduation_Year) Values ('{Name}','{NID}'" +
                $",'{phone}','{mail}','{college}','{university}','{depart}','{gradyear}');";
            //if (workshopid != null)
            //    query += $"insert into Participant_Workshop_Enrolled (Workshop_ID,Participant_ID) values ({workshopid},SELECT LAST_INSERT_ID());";
            return dbMan.ExecuteNonQuery(query);
        }

        internal int UpdateVolunteer(int Volunteer_ID, string Name, int? Committee_ID, string phone = null, string mail = null, string college = null, string depart = null, string university = null, string gradyear = null)
        {
            string query = $"update  Volunteer set Name='{Name}',Committee_ID={Committee_ID},Mobile='{phone}',Mail='{mail}',College='{college}',University='{university}',Department='{depart}',Graduation_Year='{gradyear}' where ID={Volunteer_ID}";
            return dbMan.ExecuteNonQuery(query);
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
            string query = "SELECT * From Volunteer where ID='" + id + "';";
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
            string query = "SELECT ID, Name, Responsibility_Description From Volunteer where Committee_ID=" + CommitteeID + " and ID like '%" + iD + "%';";
            return dbMan.ExecuteReader(query);
        }

        public Controller()
        {
            dbMan = new DBManager(); // Create the DBManager Object
            ftpMan = new FTPManager("ftp://ftp.ieeecusb.org", "IEEECUSBPortal@ieeecusb.org", "123456789");
        }
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        //checks the username/password and returns the priviledges associated with this user
        //Returns 0 in case of error
       
        internal object SelectMemberNotif()
        {
            string query = "SELECT Volunteer.Name ,Task.Title , Task.Start_Date,Task.End_Date Task.Description  from" +
                " Task join TaskRecievers on Task.ID=Task_ID join Volunteer on Assigner_ID=Volunteer.ID" +
                " where Task where Status IS NULL and Reciever_ID=" + UserID + ";";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SelectCommittees()
        {
            string query = $"SELECT ID, Name From Committee where ID !={CommitteeID};";
            return dbMan.ExecuteReader(query);
        }

        internal int InsertEvent(string title, string description, string sdate, string edate)
        {
            string query = $"INSERT INTO Event (Title,Description,Committee_ID,Start_Date,End_Date) Values ('{title}','{description}',{CommitteeID},'{sdate}','{edate}')";
            return dbMan.ExecuteNonQuery(query);
        }

        internal int MemeberSubmitRequest(int requestID, string progressDesc, int progressPerc)
        {
            string query = $"UPDATE Request SET Status ='" + Status.Submitted + "',Progress_Description ='" + progressDesc + "' , Progress_Percentage=" + progressPerc + " where ID=" + requestID + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectReceivedRequests()
        {

            string query = $"SELECT Request.ID,Title,CommitteeR.Name as 'Recieved Committee' , CommitteeS.Name as 'Sender Committee' , Description ,Request.Start_date ,Request.End_date ,Priority,Status FROM Request join Committee as CommitteeS on CommitteeS.ID = Sender_Comm_ID " +
                $"join Committee as CommitteeR  on  CommitteeR.ID = Reciever_Comm_ID where Reciever_Comm_ID = " + CommitteeID + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectSentRequests()
        {

            string query = $"SELECT Request.ID,Title,CommitteeR.Name as 'Recieved Committee' , CommitteeS.Name as 'Sender Committee' , Description ,Request.Start_date ,Request.End_date ,Priority,Status FROM Request join Committee as CommitteeR on CommitteeR.ID = Reciever_Comm_ID " +
                $"join Committee as CommitteeS  on  CommitteeS.ID = Sender_Comm_ID where Sender_Comm_ID = " + CommitteeID + ";";
            return dbMan.ExecuteReader(query);
        }
        public int InsertRequest(string Title, string Desc, string Start_Date, string End_Date, int Reciever_Comm_ID)
        {
            string query = "INSERT INTO Request (Title, Reciever_Comm_ID,Description,Start_Date,End_Date, Sender_Comm_ID) Values ('" + Title + "'," + Reciever_Comm_ID + ",'" + Desc + "','" + Start_Date + "','" + End_Date + "'," + CommitteeID + ")";
            return dbMan.ExecuteNonQuery(query);
        }
        internal int EditRequest(int requestID, string Title, string Description, string Start_Date, string End_Date, int Reciever_Comm_ID)
        {
            string today = DateTime.Today.ToString("yyyy-mm-dd");
            string query = $"UPDATE Request SET Status =NULL,Title='" + Title + "',Description='" + Description + "',Start_Date='" + Start_Date + "',End_Date='" + End_Date + "',Creation_Date='" + today + "',Reciever_Comm_ID=" + Reciever_Comm_ID + ",Sender_Comm_ID=" + CommitteeID + " where ID=" + requestID + "";
            return dbMan.ExecuteNonQuery(query);
        }

        internal object SelectHeadNotif()
        {
            string query = "SELECT Volunteer.Name ,Task.Title , Task.Start_Date,Task.End_Date ,Task.Description  from" +
                 " Task join TaskRecievers on Task.ID=Task_ID join Volunteer on Assigner_ID=Volunteer.ID" +
                " where TaskRecievers.Status IS NULL and Reciever_ID=" + UserID + " UNION " +
                "select Committee.Name,Request.Title,Request.Start_Date,Request.End_Date,Request.Description FROM " +
                "Request join Committee on Request.ID = Sender_Comm_ID " +
                "where Reciever_Comm_ID= " + CommitteeID + ";";
            return dbMan.ExecuteReader(query);
        }

        internal DataTable SelectEvents(DateTime date)
        {
            string query = $"SELECT Event.ID,Event.Title,Event.Description,Event.Start_Date,Event.End_Date,Committee.Name as 'Committee Name' FROM Event join Committee on Event.Committee_ID =Committee.ID where Committee.ID=" + CommitteeID + " AND '" + date.ToString("yyyy-MM-dd") + "' between Event.Start_Date and Event.End_Date ;";
            return dbMan.ExecuteReader(query);
        }


        public int InsertVolunteer(string Name, string NID, int? Committee_ID, string phone = null, string mail = null, string college = null, string depart = null, string university = null, string gradyear = null)
        {
            string comm = (Committee_ID != null) ? ",Committee_ID" : "";
            string query = $"INSERT INTO Volunteer (Name" + comm + $",Mobile,National_ID,Mail,College,University,Department,Graduation_Year) Values ('{Name}'";
            if (Committee_ID != null)
                query += "," + Committee_ID;
            query += $",'{phone}','{NID}','{mail}','{college}','{university}','{depart}','{gradyear}')";
            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertCommittee(int Season, string Name)
        {
            string query = $"INSERT INTO Committee (Season, Name) Values (" + Season + ",'" + Name + "')";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateRequestStatus(int Request_ID, Status status)
        {
            string query = $"UPDATE Request SET Status ='" + status + "' where ID=" + Request_ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable Reciever_Request()
        {
            string query = "SELECT Committee.Name , Request.Title  FROM Request join Committee on Request.Sender_Comm_ID=Committee.ID  Where Request.Reciever_Comm_ID=" + CommitteeID + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Sender_Request(int Committee_ID)
        {
            string query = "SELECT Committee.Name , Request.Title , Request.Description , Request.Priority , Request.Start_Date, Request.Deadline_Date FROM Request, Committee  Where Request.Sender_Comm_ID=" + Committee_ID + " , Committee.ID = Request.Reciever_Comm_ID; ";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Member_Notification()
        {
            string query = "SELECT Description FROM Notification join Volunteer on  Notification.Vol_ID = Volunteer.ID Where (Vol_ID ='" + UserID + "') ; ";
            return dbMan.ExecuteReader(query);
        }

        public int InsertNotification(string Description, string Type, DateTime Date, int Vol_ID)
        {
            string query = $"INSERT INTO Notification (Description, Type, Creation_Date, Vol_ID) Values ('" + Description + "','" + Type + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Vol_ID + "')";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable Committee_Tasks(int Committee_ID)
        {
            //string query = $"SELECT Volunteer.Name, Task.Title , TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date " +
            //    "FROM Task join TaskRecievers on Task_ID=Task.ID " +
            //    "join Volunteer on Volunteer.ID=Reciever_ID " +
            //    "where Volunteer.Committee_ID = '" + Committee_ID + "';";
            //return dbMan.ExecuteReader(query);
            string query = $"SELECT Task.Description,Reciever.Name as 'Reciever',Assigner.Name as 'Assigner', Task.Title , TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date " +
               "FROM Task join TaskRecievers on Task_ID=Task.ID " +
               "join Volunteer as Reciever on Reciever.ID=Reciever_ID join Volunteer as Assigner on Assigner.ID =Task.Assigner_ID " +
               "where Reciever.Committee_ID = " + Committee_ID + " order by Assigner.ID;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Committee_Tasks()
        {
            //string query = $"SELECT Volunteer.Name, Task.Title , TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date " +
            //    "FROM Task join TaskRecievers on Task_ID=Task.ID " +
            //    "join Volunteer on Volunteer.ID=Reciever_ID " +
            //    "where Volunteer.Committee_ID = '" + CommitteeID + "';";
            //return dbMan.ExecuteReader(query);
            string query = $"SELECT Task.ID,Task.Description,Reciever.Name as 'Reciever',Assigner.Name as 'Assigner', Task.Title , TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date " +
               "FROM Task join TaskRecievers on Task_ID=Task.ID " +
               "join Volunteer as Reciever on Reciever.ID=Reciever_ID join Volunteer as Assigner on Assigner.ID =Task.Assigner_ID " +
               "where Reciever.Committee_ID = " + CommitteeID + " order by Assigner.ID;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable CommTask(int Committee_ID)
        {
            string query = "SELECT Task.ID , Task.Title ,Volunteer.Name as Assigner, Task.Start_Date, Task.Deadline_Date , Task.Description FROM Task join Volunteer on Volunteer.ID = Task.Assigner_ID WHERE Task.Committee_ID ='" + Committee_ID + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable CommTask()
        {
            string query = "SELECT Task.ID , Task.Title ,Volunteer.Name as Assigner, Task.Start_Date, Task.Deadline_Date , Task.Description FROM Task join Volunteer on Volunteer.ID = Task.Assigner_ID WHERE Task.Committee_ID ='" + CommitteeID + "';";
            return dbMan.ExecuteReader(query);
        }
        internal int DeleteTask(int Task_ID)
        {
            string query = $"DELETE FROM Task WHERE ID='" + Task_ID + "';";
            return dbMan.ExecuteNonQuery(query);
        }


        internal int DeleteRequest(int Request_ID)
        {
            string query = $"DELETE FROM Request WHERE ID='" + Request_ID + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        internal int DeleteEvent(int EventID)
        {
            string query = $"DELETE FROM Event WHERE ID={EventID};";
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


        public int InsertTask(string Title, string description, DateTime Start_Date, DateTime Deadline)
        {
            string query = "INSERT INTO Task (Title,Description , Assigner_ID,Committee_ID , Creation_Date , Start_Date , Deadline_Date) Values ('" + Title + "','" + description + "','" + UserID + "','" + CommitteeID + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Start_Date.ToString("yyyy-MM-dd") + "','" + Deadline.ToString("yyyy-MM-dd") + "')";
            return dbMan.ExecuteNonQuery(query);
        }

        public int EditTask(string Title, string description, DateTime Start_Date, DateTime Deadline)
        {
            string query = "Update Task (Title,Description , Assigner_ID,Committee_ID , Creation_Date , Start_Date , Deadline_Date) Values ('" + Title + "','" + description + "','" + UserID + "','" + CommitteeID + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Start_Date.ToString("yyyy-MM-dd") + "','" + Deadline.ToString("yyyy-MM-dd") + "')";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertTaskReciever(int Task_ID, int Member_ID)
        {
            string query = "INSERT INTO TaskRecievers (Task_ID, Reciever_ID) Values ('" + Task_ID + "','" + Member_ID + "')";
            return dbMan.ExecuteNonQuery(query);
        }


        public int UpdateTask(int Task_ID, int Progress_Percentage, string Progress_Description)
        {
            string query = $"UPDATE TaskRecievers SET  Progress_Percentage='" + Progress_Percentage + "' AND Progress_Description='" + Progress_Description + "'  where Task_ID='" + Task_ID + "' AND Reciever_ID='" + UserID + "'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateTaskStatus(int Task_ID, Status status)
        {
            string query = $"UPDATE TaskRecievers SET Status ='" + status + "' where Task_ID='" + Task_ID + "' AND Reciever_ID='" + UserID + "'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int SubmitTask(int Task_ID)
        {
            string query = "UPDATE TaskRecievers SET Status ='Submitted',Submission_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where Task_ID='" + Task_ID + "' AND Reciever_ID='" + UserID + "'";
            return dbMan.ExecuteNonQuery(query);
        }


        public DataTable Member_Tasks()
        {
            string query = "SELECT Task.ID , Volunteer.Name , Task.Title ,  TaskRecievers.Progress_Description , Task.Start_Date, Task.Deadline_Date,TaskRecievers.Status FROM Task,Volunteer,TaskRecievers Where TaskRecievers.Reciever_ID =" + UserID + " AND Task.Assigner_ID = Volunteer.ID AND TaskRecievers.Task_ID = Task.ID AND TaskRecievers.Status = 'Accepted' ; ";
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


        public DataTable Committee_Members(int Committee_ID)
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
        public DataTable Committee_Members()
        {
            if (CommitteeID == 101 || CommitteeID == 100)
            {
                string query = "SELECT ID , Name FROM Volunteer Where Job_Title = 'Head' OR Job_Title = 'Supervisor' ; ";
                return dbMan.ExecuteReader(query);
            }
            else
            {
                string query = "SELECT ID , Name FROM Volunteer Where Committee_ID ='" + CommitteeID + "'; ";
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

        public DataTable Committee(int Committee_ID)
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
        public DataTable Committee()
        {

            if (CommitteeID == 100)
            {
                string query = "SELECT ID , Name , Evaluation_Percentage FROM Volunteer Where Job_Title <> 'Officer'; ";
                return dbMan.ExecuteReader(query);
            }
            else if (CommitteeID == 101)
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
            string query = $"INSERT INTO SessionInstructor (Workshop_ID, Vol_ID) Values ('" + Workshop_ID + "','" + Member_ID + "')";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable CountVolunteer_Enrolled(int Workshop_ID)
        {
            string query = "SELECT Count(*) FROM Volunteer_Workshop_Enrolled where Workshop_ID=" + Workshop_ID + ";";
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

        public int InsertAttender_Vol(int Workshop_ID, int Session_No, int Attender_ID)
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
                string query = "INSERT INTO MahmoudMorsy.Update (Description, Type , Volunteer_ID , Section_ID , Committee_ID , Committee_Season, End_Date) Values ('" + Description + "', 'Officer' ,'" + UserID + "','" + SectionID + "','" + CommitteeID + "',2017,'" + DateTime.Now.AddDays(7).ToString("yyyy-MM-dd") + "')";
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
                string query = "SELECT Description From MahmoudMorsy.Update Where End_Date > '" + y.ToString("yyyy-MM-dd") + "';";
                return dbMan.ExecuteReader(query);
            }
            else if (CommitteeID == 101)
            {
                string query = "SELECT Description From MahmoudMorsy.Update Where (Section_ID = '" + SectionID + "' AND End_Date > '" + y.ToString("yyyy-MM-dd") + "');";
                return dbMan.ExecuteReader(query);
            }
            else
            {
                string off = "Officer";
                string sup = "Supervisor";
                string query = "SELECT Description From MahmoudMorsy.Update Where (Committee_ID = '" + CommitteeID + "' AND End_Date > '" + y.ToString("yyyy-MM-dd") + "') OR (Type = '" + off + "' AND End_Date > '" + y.ToString("yyyy-MM-dd") + "') OR (Type = '" + sup + "' AND Section_ID = '" + SectionID + "' AND End_Date > '" + y.ToString("yyyy-MM-dd") + "');";
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
            string query = "UPDATE Volunteer SET Last_Login='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where ID='" + UserID + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable Helping_Committee_Member()
        {

            string query = "SELECT Helping_Comm_ID FROM Volunteer  WHERE ID ='" + UserID + "' ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Count_Member_Sub(int Member_ID)
        {
            string query = "SELECT COUNT(Task_ID) FROM TaskRecievers  WHERE Reciever_ID ='" + Member_ID + "' AND Status='Submitted';";
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

        public int Evaluation(double x, int ID)
        {
            string query = "UPDATE Volunteer SET Evaluation_Percentage= '" + x + "' where ID ='" + ID + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable Section_Task()
        {
                string query = "SELECT Task.ID , Task.Title , Task.Start_Date, Task.Description, Task.Deadline_Date  FROM Task,Committee,Section,Volunteer Where Volunteer.ID = Section.Supervisor_ID AND Committee.Section_ID = Section.ID AND Task.Committee_ID = Committee.ID AND Volunteer.ID='" + UserID + "';";
                return dbMan.ExecuteReader(query);
        }
    }
}

