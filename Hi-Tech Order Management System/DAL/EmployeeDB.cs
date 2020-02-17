using Hi_Tech_System.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Tech_System.DAL
{
    public static class EmployeeDB
    {
        public static void SaveRecord(Employee employee)
        {

            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            string sqlInsert = "INSERT into Employees(EmployeeId,FirstName,LastName,JobTitle,PhoneNumber,Email) "
                + " VALUES(@EId,@FirstName,@LastName,@JobTitle,@PhoneNumber,@Email)";
            cmd.CommandText = sqlInsert;
            cmd.Parameters.AddWithValue("@EId", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", employee.Email);

            cmd.ExecuteNonQuery();
            connDB.Close();

        }

        public static List<Employee> ListRecord()
        {
            List<Employee> listEmployee = new List<Employee>();
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            Employee anEmployee;
            cmd.CommandText = "SELECT * FROM Employees ";
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                anEmployee = new Employee();
                anEmployee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                anEmployee.FirstName = dr["FirstName"].ToString();
                anEmployee.LastName = dr["LastName"].ToString();
                anEmployee.JobTitle = dr["JobTitle"].ToString();
                anEmployee.PhoneNumber = dr["PhoneNumber"].ToString();
                anEmployee.Email = dr["Email"].ToString();

                listEmployee.Add(anEmployee);
            }


            connDB.Close();

            return listEmployee;


        }
        public static void UpdateRecord(Employee employee)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;


            string sqlInsert = "UPDATE Employees " +
                               "SET EmployeeId = @EId, FirstName = @FirstName, LastName = @LastName, JobTitle = @JobTitle, PhoneNumber = @PN, Email = @Email WHERE EmployeeId = @EId";
            cmd.CommandText = sqlInsert;
            cmd.Parameters.AddWithValue("@EId", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            cmd.Parameters.AddWithValue("@PN", employee.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", employee.Email);

            cmd.ExecuteNonQuery();
            connDB.Close();


        }

        public static void DeleteRecord(Employee employee)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;

            string sqlInsert = "DELETE FROM Employees " +
                               "WHERE (EmployeeId = @EId)";
            cmd.CommandText = sqlInsert;
            cmd.Parameters.AddWithValue("@EId", employee.EmployeeId);

            cmd.ExecuteNonQuery();
            connDB.Close();

        }

        public static List<Employee> SearchRecord(string data)
        {
            List<Employee> listEmployee = new List<Employee>();
            Employee anEmployee;
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Employees " +
                              "WHERE FirstName = '" + data + "'" + " OR " +
                              "LastName = '" + data + "'";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                anEmployee = new Employee();
                anEmployee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                anEmployee.FirstName = dr["FirstName"].ToString();
                anEmployee.LastName = dr["LastName"].ToString();
                anEmployee.JobTitle = dr["JobTitle"].ToString();
                anEmployee.PhoneNumber = dr["PhoneNumber"].ToString();
                anEmployee.Email = dr["Email"].ToString();

                listEmployee.Add(anEmployee);
            }

            connDB.Close();
            return listEmployee;
        }

        public static List<Employee> SearchRecord(int data)
        {
            List<Employee> listEmployee = new List<Employee>();
            Employee anEmployee;
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Employees " +
                              "Where EmployeeId = " + data + " OR " +
                              "FirstName = '" + data + "'" + " OR " +
                              "LastName = '" + data + "'";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                anEmployee = new Employee();
                anEmployee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                anEmployee.FirstName = dr["FirstName"].ToString();
                anEmployee.LastName = dr["LastName"].ToString();
                anEmployee.JobTitle = dr["JobTitle"].ToString();
                anEmployee.PhoneNumber = dr["PhoneNumber"].ToString();
                anEmployee.Email = dr["Email"].ToString();

                listEmployee.Add(anEmployee);
            }

            connDB.Close();
            return listEmployee;
        }

        public static int GetRecord()
        {
            int id;
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT max(employeeId) as TempId from Employees ";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                id = Convert.ToInt32(dr["TempId"]) + 1;
            }
            else
            {
                id = 1001;
            }


            connDB.Close();
            return id;

        }

        public static Employee GetEmployee(string input)
        {
            Employee anEmployee = null;

            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT EmployeeId, FirstName, LastName, JobTitle, PhoneNumber, Email" + " " +
                                "FROM Employees" + " " +
                                "WHERE EmployeeId = " + input + ";";
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            anEmployee = new Employee();
            anEmployee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            anEmployee.FirstName = dr["FirstName"].ToString();
            anEmployee.LastName = dr["LastName"].ToString();
            anEmployee.JobTitle = dr["JobTitle"].ToString();
            anEmployee.PhoneNumber = dr["PhoneNumber"].ToString();
            anEmployee.Email = dr["Email"].ToString();

            connDB.Close();

            return anEmployee;
        }

    }
}
