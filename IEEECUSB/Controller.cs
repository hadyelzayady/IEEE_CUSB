using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace IEEECUSB
{
    public class Controller
    {
        private DBManager dbMan; // A Reference of type DBManager 
                                 // (Initially NULL; NO DBManager Object is created yet)
        public int UserID;
        public int CommitteeID;
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
            string query = $"SELECT ID ,Committee_ID from Volunteer where Mail = '{username}' and password={password} limit 1;";            
            DataTable p = dbMan.ExecuteReader(query);
            //UserID=p
            return p;
        }



        public DataTable SelectAllEmp()
        {
            
            string query = "SELECT * FROM Employee;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectReceivedRequests()
        {

            string query = $"SELECT * FROM Request join Committee on Reciever_Comm_ID = {CommitteeID};";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectSentRequests()
        {

            string query = $"SELECT * FROM Request join Committee on Sender_Comm_ID = {CommitteeID};";
            return dbMan.ExecuteReader(query);
        }
        public int InsertRequest(string Title, int Reciever_Comm_ID, int Sender_Comm_ID)
        {
            string query = $"INSERT INTO Request (Title, Reciever_Comm_ID, Sender_Comm_ID) Values ({Title},{Reciever_Comm_ID},{Sender_Comm_ID})";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertTask(string Title, int Reciever_ID, int Sender_ID,int Committee_ID)
        {
            string query = $"INSERT INTO Task (Title, Reciever_ID, Assigner_ID,Committee_ID) Values ({Title},{Reciever_ID},{Sender_ID},{Committee_ID})";
            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertVolunteer(string Name )
        {
            string query = $"INSERT INTO Volunteer (Name) Values ({Name})";
            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertCommittee(int Season,string Name)
        {
            string query = $"INSERT INTO Committee (Season, ID, Name) Values ({Season},{Name})";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateEmployee(int ssn, string fname, char minit, string lname, DateTime bdate, String address, String sex, int salary, int dno, int? super_ssn)
        {
            string query = "UPDATE Employee SET "+
                "Fname='" + fname + "'," +
                "Minit='" + minit + "'," +
                "Lname='" + lname + "'," +
                "Bdate='" + bdate.ToString("yyyy-MM-dd") + "'," +
                "Address='" + address + "'," +
                "Sex='" + sex + "'," +
                "Salary=" + salary + "," +
                "Dno=" + dno + "," +
                "Super_SSN=" + (super_ssn==null?"NULL":super_ssn.ToString()) + "" +
                " WHERE SSN = " + ssn;
            return dbMan.ExecuteNonQuery(query);
        }


        public int DeleteEmployee(int ssn)
        {
            string query = "DELETE FROM Employee WHERE SSN=" + ssn;
            return dbMan.ExecuteNonQuery(query);
        }
    }
}
