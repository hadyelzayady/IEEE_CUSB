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
        public int CheckPassword_Basic(string username, string password)
        {
            //Query the DB to check for username/password
            string query = $"SELECT priv from Users_basic where username = '{username}' and password={password};";            
            object p = dbMan.ExecuteScalar(query);
            if (p == null) return 0;
            else return (int)p;
        }



        public DataTable SelectAllEmp()
        {
            string query = "SELECT * FROM Employee;";
            return dbMan.ExecuteReader(query);
        }


        public int InsertProject(string Pname, int pnumber, string Plocation, int Dnum)
        {
            string query = "INSERT INTO Project (Pname, Pnumber, Plocation, Dnum)" +
                            "Values ('" + Pname + "'," + pnumber + ",'" + Plocation + "'," + Dnum + ");";
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
