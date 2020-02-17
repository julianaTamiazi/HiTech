using Hi_Tech_Order_Management_System;
using Hi_Tech_System.BLL;
using Hi_Tech_System.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee = Hi_Tech_System.BLL.Employee;
using User = Hi_Tech_System.BLL.User;

namespace Hi_Tech_System.Validator
{
    public class Validation
    {
        public static bool IsValidId(string input, int size)
        {

            if (!Regex.IsMatch(input, @"^\d{" + size + "}$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsValidText(string input)
        {
            if (input == "")
            {
                MessageBox.Show("Field is empty", "Enter some data!");
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!(Char.IsLetter(input[i])) && !(Char.IsWhiteSpace(input[i])))
                {
                    MessageBox.Show("Name must be only letter", "Invalid Name");
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidSize(string input, int size)
        {

            if (!Regex.IsMatch(input, @"^\w{" + size + "}$"))
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        public static bool IsValidNumber(string input)
        {

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsDuplicatedEId(int id)
        {
            Employee anEmployee = new Employee();
            List<Employee> listEmployee = anEmployee.SearchEmployee(id);
            if (listEmployee.Count != 0)
            {
                MessageBox.Show("Duplicated Id");
                return false;
            }
            return true;
        }

        public static bool IsDuplicatedUId(int id)
        {
            User anUser = new User();
            List<User> listUser = anUser.SearchUser(id);
            if (listUser.Count != 0)
            {
                MessageBox.Show("Duplicated Id");
                return false;
            }
            return true;
        }

        public static bool IsDuplicatedCId(int id)
        {
            UtilityDB.InitializeDataSet();
            DataTable dtCustomers = new DataTable();
            DataRow drCustomer = dtCustomers.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["CustomerId"]) == id);
            //DataRow drCustomer = dtCustomers.Rows.Find(id);
            if (drCustomer != null)
            {
                MessageBox.Show("Duplicated Id");
                return false;
            }
            return true;
        }

        public static bool IsDuplicatedCtId(int id)
        {
            HiTechDistributionDBEntities db = new HiTechDistributionDBEntities();
            Category aCategory = new Category();
            aCategory = db.Categories.Find(id);
            if (aCategory != null)
            {
                MessageBox.Show("Duplicated Id");
                return false;
            }
            return true;
        }

        public static bool IsDuplicatedAId(int id)
        {
            HiTechDistributionDBEntities db = new HiTechDistributionDBEntities();
            Author anAuthor = new Author();
            anAuthor = db.Authors.Find(id);
            if (anAuthor != null)
            {
                MessageBox.Show("Duplicated Id");
                return false;
            }
            return true;
        }

        public static bool IsDuplicatedSId(int id)
        {
            HiTechDistributionDBEntities db = new HiTechDistributionDBEntities();
            Supplier aSupplier = new Supplier();
            aSupplier = db.Suppliers.Find(id);
            if (aSupplier != null)
            {
                MessageBox.Show("Duplicated Id");
                return false;
            }
            return true;
        }

        public static bool IsDuplicatedPId(string id)
        {
            HiTechDistributionDBEntities db = new HiTechDistributionDBEntities();
            Product aProduct = new Product();
            aProduct = db.Products.Find(id);
            if (aProduct != null)
            {
                MessageBox.Show("Duplicated ISBN");
                return false;
            }
            return true;
        }

        public static bool IsDuplicatedAPId(string isbn, int id)
        {
            HiTechDistributionDBEntities db = new HiTechDistributionDBEntities();
            AProduct anAProduct = new AProduct();
            anAProduct = db.AProducts.Find(isbn, id);
            if (anAProduct != null)
            {
                MessageBox.Show("Duplicated Product and Author combination");
                return false;
            }
            return true;
        }
        public static bool IsDuplicatedOId(int id)
        {
            HiTechDistributionDBEntities db = new HiTechDistributionDBEntities();
            Order anOrder = new Order();
            anOrder= db.Orders.Find(id);
            if (anOrder != null)
            {
                MessageBox.Show("Duplicated Id");
                return false;
            }
            return true;
        }

        public static bool IsDuplicatedOPId(int id, string isbn)
        {
            HiTechDistributionDBEntities db = new HiTechDistributionDBEntities();
            Order_lines anOLine = new Order_lines();
            anOLine = db.Order_lines.Find(id, isbn);
            if (anOLine != null)
            {
                MessageBox.Show("Duplicated Product and Author combination");
                return false;
            }
            return true;
        }
    }
}
