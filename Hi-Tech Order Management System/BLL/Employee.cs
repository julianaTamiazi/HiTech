using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Tech_System.DAL;

namespace Hi_Tech_System.BLL
{
    public class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;
        private string phoneNumber;
        private string email;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }

        public void SaveEmployee(Employee employee)
        {
            EmployeeDB.SaveRecord(employee);

        }

        public void UpdateEmployee(Employee employee)
        {
            EmployeeDB.UpdateRecord(employee);

        }

        public void DeleteEmployee(Employee employee)
        {
            EmployeeDB.DeleteRecord(employee);

        }

        public List<Employee> ListEmployee()
        {
            return EmployeeDB.ListRecord();
        }

        public List<Employee> SearchEmployee(string data)
        {
            return EmployeeDB.SearchRecord(data);

        }

        public List<Employee> SearchEmployee(int data)
        {
            return EmployeeDB.SearchRecord(data);

        }


    }
}

