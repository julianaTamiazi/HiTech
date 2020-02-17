using Hi_Tech_System.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Tech_System.DAL
{
    public class UserDB
    {
        public static void SaveRecord(User user)
        {

            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            string sqlInsert = "INSERT into Users(EmployeeId,JobTitle,UserName,Password) "
                + " VALUES(@EId,@JobTitle,@name,@Password)";
            cmd.CommandText = sqlInsert;
            cmd.Parameters.AddWithValue("@EId", user.EmployeeId);
            cmd.Parameters.AddWithValue("@JobTitle", user.JobTitle);
            cmd.Parameters.AddWithValue("@Name", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);


            cmd.ExecuteNonQuery();
            connDB.Close();

        }

        public static List<User> ListRecord()
        {
            List<User> listUser = new List<User>();
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            User anUser;
            cmd.CommandText = "SELECT * FROM Users ";
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                anUser = new User();
                anUser.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                anUser.JobTitle = dr["JobTitle"].ToString();
                anUser.UserName = dr["UserName"].ToString();
                anUser.Password = dr["Password"].ToString();


                listUser.Add(anUser);
            }


            connDB.Close();

            return listUser;


        }
        public static void UpdateRecord(User user)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;

            string sqlInsert = "UPDATE Users " +
                               "SET EmployeeId = @EId, JobTitle = @JobTitle, " +
                               "UserName = @Name, Password = @Password " +
                               "WHERE EmployeeId = @EId";
            cmd.CommandText = sqlInsert;
            cmd.Parameters.AddWithValue("@EId", user.EmployeeId);
            cmd.Parameters.AddWithValue("@JobTitle", user.JobTitle);
            cmd.Parameters.AddWithValue("@Name", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);


            cmd.ExecuteNonQuery();
            connDB.Close();


        }

        public static void DeleteRecord(User user)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;

            string sqlInsert = "DELETE FROM Users " +
                               "WHERE (EmployeeId = @EId)";
            cmd.CommandText = sqlInsert;
            cmd.Parameters.AddWithValue("@EId", user.EmployeeId);

            cmd.ExecuteNonQuery();
            connDB.Close();

        }

        public static List<User> SearchRecord(string data)
        {
            List<User> listUser = new List<User>();
            User anUser;
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Users " +
                              "WHERE UserName = '" + data + "'" + " OR " +
                              "Password = '" + data + "'";

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                anUser = new User();
                anUser.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                anUser.JobTitle = dr["JobTitle"].ToString();
                anUser.UserName = dr["UserName"].ToString();
                anUser.Password = dr["Password"].ToString();


                listUser.Add(anUser);
            }

            connDB.Close();
            return listUser;
        }

        public static List<User> SearchRecord(int data)
        {
            List<User> listUser = new List<User>();
            User anUser;
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();

            string sqlInsert = "SELECT * FROM Users " +
                              "Where EmployeeId = " + data + " OR " +
                              "UserName = '" + data + "'" + " OR " +
                              "Password = '" + data + "'";
            cmd.Connection = connDB;
            cmd.CommandText = sqlInsert;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                anUser = new User();
                anUser.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                anUser.JobTitle = dr["JobTitle"].ToString();
                anUser.UserName = dr["UserName"].ToString();
                anUser.Password = dr["Password"].ToString();


                listUser.Add(anUser);
            }

            connDB.Close();
            return listUser;
        }

        public static bool GetUser(string name, string password, string jobTitle)
        {

            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;

            string sqlInsert = "SELECT * FROM Users WHERE UserName=@name " +
                                "AND PASSWORD=@password " + 
                                "AND JobTitle = @jobTitle";
            cmd.CommandText = sqlInsert;


            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@jobTitle", jobTitle);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }

    }
}
