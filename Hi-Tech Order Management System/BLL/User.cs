using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Tech_System.DAL;

namespace Hi_Tech_System.BLL
{
    public class User
    {
        private int employeeId;
        private string jobTitle;
        private string userName;
        private string password;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }

        public void SaveUser(User user)
        {
            UserDB.SaveRecord(user);

        }

        public void UpdateUser(User user)
        {
            UserDB.UpdateRecord(user);

        }

        public void DeleteUser(User user)
        {
            UserDB.DeleteRecord(user);

        }

        public List<User> ListUser()
        {
            return UserDB.ListRecord();
        }

        public List<User> SearchUser(string data)
        {
            return UserDB.SearchRecord(data);

        }

        public List<User> SearchUser(int data)
        {
            return UserDB.SearchRecord(data);

        }

        public bool ValidUser(string name, string password, string jobTitle)
        {
            return UserDB.GetUser(name, password, jobTitle);
        }
    }
}
