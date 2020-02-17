using Hi_Tech_Order_Management_System;
using Hi_Tech_System.BLL;
using Hi_Tech_System.DAL;
using Hi_Tech_System.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;
using Customer = Hi_Tech_System.BLL.Customer;
using Employee = Hi_Tech_System.BLL.Employee;
using User = Hi_Tech_System.BLL.User;
using System.IO;

namespace Hi_Tech_System
{
    public partial class HiTechSystemForm : Form
    {
        List<Employee> listEmployee = new List<Employee>();
        List<Customer> listCustomer = new List<Customer>();


        SqlDataAdapter da;
        DataSet dsHiTechDistributionDB;
        DataTable dtCustomers;

        HiTechDistributionDBEntities db = new HiTechDistributionDBEntities();
        Category aCategory = new Category();
        Author anAuthor = new Author();
        Supplier aSupplier = new Supplier();
        Product aProduct = new Product();
        AProduct anAProduct = new AProduct();
        Customer aCustomer = new Customer();
        Order anOrder = new Order();
        Order_lines anOLine = new Order_lines();
        Employee anEmployee = new Employee();
        List<Employee> listEmployeeDB = new List<Employee>();
        List<Customer> listCustomerDB = new List<Customer>();

        int units;
        public HiTechSystemForm(int access)
        {
            InitializeComponent();
            EnableTabs(access);
        }
        private void EnableTabs(int access)
        {
            tabControlHiTech.TabPages.Clear();
            switch (access)
            {
                case 1: // MisManager
                    if (access == 1)
                    {
                        tabControlHiTech.TabPages.Add(tabPageEmployee);
                        tabControlHiTech.TabPages.Add(tabPageUser);
                    }
                    break;
                case 2:// SalesManager
                    if (access == 2)
                    {
                        tabControlHiTech.TabPages.Add(tabPageOrder);
                        tabControlHiTech.TabPages.Add(tabPageOrderReport);
                    }
                    break;
                case 3: // Inventory Controller 
                    if (access == 3)
                    {
                        tabControlHiTech.TabPages.Add(tabPageProduct);
                        tabControlHiTech.TabPages.Add(tabPageCategory);
                        tabControlHiTech.TabPages.Add(tabPageAuthor);
                    }
                    break;
                case 4: // Order Clerk
                    if (access == 4)
                    {
                        tabControlHiTech.TabPages.Add(tabPageOrder);
                        tabControlHiTech.TabPages.Add(tabPageOrderReport);
                    }
                    break;
                case 5: // Accountant
                    if (access == 5)
                    {
                        tabControlHiTech.TabPages.Add(tabPageInvoice);
                    }
                    break;
                case 6: // Mr.Cao
                    if (access == 6)
                    {
                        tabControlHiTech.TabPages.Add(tabPageEmployee);
                        tabControlHiTech.TabPages.Add(tabPageUser);
                        tabControlHiTech.TabPages.Add(tabPageCustomer);
                        tabControlHiTech.TabPages.Add(tabPageProduct);
                        tabControlHiTech.TabPages.Add(tabPageCategory);
                        tabControlHiTech.TabPages.Add(tabPageAuthor);
                        tabControlHiTech.TabPages.Add(tabPageSupplier);
                        tabControlHiTech.TabPages.Add(tabPageOrder);
                        tabControlHiTech.TabPages.Add(tabPageOrderReport);
                        tabControlHiTech.TabPages.Add(tabPageInvoice);
                    }
                    break;
            }
        }
        private void HiTechSystemForm_Load(object sender, EventArgs e)
        {
            dsHiTechDistributionDB = UtilityDB.InitializeDataSet();
            dtCustomers = dsHiTechDistributionDB.Tables["Customers"];
            textBoxEId.Text = Convert.ToString(EmployeeDB.GetRecord());

        }

        //Customer
        private void buttonSaveC_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();
            aCustomer.CustomerId = Convert.ToInt32(textBoxCId.Text.Trim());

            if (textBoxCName.Text != "")
            {
                aCustomer.Name = textBoxCName.Text.Trim();
            }
            else
            {
                MessageBox.Show("Client Name is empty");
                textBoxCName.Focus();
                return;
            }

            if (textBoxNo.Text != "")
            {
                aCustomer.StreetNo = Convert.ToInt32(textBoxNo.Text.Trim());
            }
            else
            {
                MessageBox.Show("Street No. is empty");
                textBoxNo.Focus();
                return;
            }

            if (textBoxStreet.Text != "")
            {
                aCustomer.StreetName = textBoxStreet.Text.Trim();
            }
            else
            {
                MessageBox.Show("Street Name is empty");
                textBoxStreet.Focus();
                return;
            }

            if (textBoxPCode.Text != "")
            {
                aCustomer.PostalCode = textBoxPCode.Text.Trim();
            }
            else
            {
                MessageBox.Show("Postal Code is empty");
                textBoxPCode.Focus();
                return;
            }

            if (comboBoxCity.SelectedIndex != -1)
            {
                aCustomer.City = comboBoxCity.Text.Trim();
            }
            else
            {
                MessageBox.Show("City is empty");
                comboBoxCity.Focus();
                return;
            }

            if (maskedTextBoxCPN.Text != "")
            {
                aCustomer.PhoneNumber = maskedTextBoxCPN.Text.Trim();
            }
            else
            {
                MessageBox.Show("Phone Number is empty");
                textBoxCredit.Focus();
                return;
            }

            if (maskedTextBoxFN.Text != "")
            {
                aCustomer.FaxNumber = maskedTextBoxFN.Text.Trim();
            }
            else
            {
                MessageBox.Show("Fax Number is empty");
                textBoxCredit.Focus();
                return;
            }

            if (textBoxCredit.Text != "")
            {
                aCustomer.Credit = Convert.ToInt32(textBoxCredit.Text.Trim());
            }
            else
            {
                MessageBox.Show("Credit is empty");
                textBoxCredit.Focus();
                return;
            }

            dtCustomers.Rows.Add(aCustomer.CustomerId, aCustomer.Name, aCustomer.StreetNo, aCustomer.StreetName, aCustomer.PostalCode, aCustomer.City, aCustomer.PhoneNumber, aCustomer.FaxNumber, aCustomer.Credit);

            UtilityDB.UpdateDBTable("Customers");
            MessageBox.Show("Record Saved");

        }
        private void buttonDeleteC_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to delete the record?",
               "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                int searchId = Convert.ToInt32(textBoxCId.Text);
                DataRow drCustomer = dtCustomers.Rows.Find(searchId);
                drCustomer.Delete();
                UtilityDB.UpdateDBTable("Customers");
                MessageBox.Show("Record Deleted");
            }
            else
            {
                MessageBox.Show("Record NOT Deleted");

            }
        }
        private void buttonUpdateC_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to update the record?",
                "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                int searchId = Convert.ToInt32(textBoxCId.Text);
                DataRow drCustomer = dtCustomers.Rows.Find(searchId);
                if (drCustomer != null)
                {

                    drCustomer["CustomerId"] = Convert.ToInt32(textBoxCId.Text.Trim());

                    if (textBoxCName.Text != "")
                    {
                        drCustomer["Name"] = textBoxCName.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Client Name is empty");
                        textBoxCName.Focus();
                        return;
                    }

                    if (textBoxNo.Text != "")
                    {
                        drCustomer["StreetNo"] = textBoxNo.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Street No. is empty");
                        textBoxNo.Focus();
                        return;
                    }

                    if (textBoxStreet.Text != "")
                    {
                        drCustomer["StreetName"] = textBoxStreet.Text.Trim();

                    }
                    else
                    {
                        MessageBox.Show("Street Name is empty");
                        textBoxStreet.Focus();
                        return;
                    }


                    drCustomer["City"] = comboBoxCity.Text.Trim();

                    if (textBoxPCode.Text != "")
                    {
                        drCustomer["PostalCode"] = textBoxPCode.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Postal Code is empty");
                        textBoxPCode.Focus();
                        return;
                    }

                    drCustomer["PhoneNumber"] = maskedTextBoxCPN.Text.Trim();
                    drCustomer["FaxNumber"] = maskedTextBoxFN.Text.Trim();

                    if (textBoxCredit.Text != "")
                    {
                        drCustomer["Credit"] = Convert.ToInt32(textBoxCredit.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show("Client Credit is empty");
                        textBoxCredit.Focus();
                        return;
                    }

                    UtilityDB.UpdateDBTable("Customers");
                    MessageBox.Show("Record Updated");

                }
                else
                {
                    MessageBox.Show("Customer not found");
                }
            }
            else
            {
                MessageBox.Show("Record NOT Updated");
                listViewUser.Items.Clear();

            }
        }
        private void buttonListC_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("SELECT * FROM Customers", UtilityDB.ConnectDB());
            da.Fill(dsHiTechDistributionDB.Tables["Customers"]);
            dataGridViewCustomer.DataSource = dsHiTechDistributionDB.Tables["Customers"];
        }
        private void buttonSearchC_Click(object sender, EventArgs e)
        {
            int index = comboBoxSearchC.SelectedIndex;

            if (index == 0)
            {
                int searchId = Convert.ToInt32(textBoxSearchC.Text.Trim());
                DataRow drCustomer = dtCustomers.Rows.Find(searchId);
                if (Validation.IsValidId(textBoxSearchC.Text, 1))
                {
                    if (drCustomer != null)
                    {
                        textBoxCId.Text = drCustomer["CustomerId"].ToString();
                        textBoxCName.Text = drCustomer["Name"].ToString();
                        textBoxNo.Text = drCustomer["StreetNo"].ToString();
                        textBoxStreet.Text = drCustomer["StreetName"].ToString();
                        comboBoxCity.Text = drCustomer["City"].ToString();
                        textBoxPCode.Text = drCustomer["PostalCode"].ToString();
                        maskedTextBoxCPN.Text = drCustomer["PhoneNumber"].ToString();
                        maskedTextBoxFN.Text = drCustomer["FaxNumber"].ToString();
                        textBoxCredit.Text = drCustomer["Credit"].ToString();
                        comboBoxSearchC.SelectedIndex = -1;
                        textBoxSearchC.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Customer not found");
                        textBoxSearchC.Clear();
                        textBoxSearchC.Focus();

                    }
                }
                else
                {
                    MessageBox.Show("Id must be 1 digit", "Invalid Id");
                    textBoxSearchC.Clear();
                    textBoxSearchC.Focus();
                    return;
                }

            }
            else if (index == 1)
            {
                string searchName = "Name = " + textBoxSearchC.Text.Trim() + "";
                
                DataRow drCustomer = dtCustomers.Rows.Find(searchName);
                if (drCustomer != null)
                {
                    textBoxCId.Text = drCustomer["CustomerId"].ToString();
                    textBoxCName.Text = drCustomer["Name"].ToString();
                    textBoxNo.Text = drCustomer["StreetNo"].ToString();
                    textBoxStreet.Text = drCustomer["StreetName"].ToString();
                    comboBoxCity.Text = drCustomer["City"].ToString();
                    textBoxPCode.Text = drCustomer["PostalCode"].ToString();
                    maskedTextBoxCPN.Text = drCustomer["PhoneNumber"].ToString();
                    maskedTextBoxFN.Text = drCustomer["FaxNumber"].ToString();
                    textBoxCredit.Text = drCustomer["Credit"].ToString();
                }
                else
                {
                    MessageBox.Show("Customer not found");
                    textBoxSearchC.Clear();
                    textBoxSearchC.Focus();

                }
            }
        }

        //Employee
        private void buttonSaveE_Click(object sender, EventArgs e)
        {
            Employee anEmployee = new Employee();

            if (Validation.IsDuplicatedEId(Convert.ToInt32(textBoxEId.Text.Trim())))
            {
                anEmployee.EmployeeId = Convert.ToInt32(textBoxEId.Text.Trim());
            }
            else
            {
                listViewEmployee.Items.Clear();
                return;
            }

            if (comboBoxJT.SelectedIndex != -1)
            {
                anEmployee.JobTitle = comboBoxJT.Text;
            }
            else
            {
                MessageBox.Show("JobTitle is empty.", "Select an option!");
                comboBoxJT.Focus();
                return;
            }


            if (Validation.IsValidText(textBoxFN.Text.Trim()))
            {
                anEmployee.FirstName = textBoxFN.Text.Trim();
            }
            else
            {
                textBoxFN.Clear();
                textBoxFN.Focus();
                return;
            }

            if (Validation.IsValidText(textBoxLN.Text.Trim()))
            {
                anEmployee.LastName = textBoxLN.Text;
            }
            else
            {
                textBoxLN.Clear();
                textBoxLN.Focus();
                return;
            }

            if (maskedTextBoxPN.Text != "")
            {
                anEmployee.PhoneNumber = maskedTextBoxPN.Text.Trim();
            }
            else
            {
                MessageBox.Show("Phone Number is empty.");
                maskedTextBoxPN.Focus();
                return;
            }

            if (textBoxE.Text != "")
            {
                anEmployee.Email = textBoxE.Text.Trim();
            }
            else
            {
                MessageBox.Show("Email is empty.");
                textBoxE.Focus();
                return;
            }

            
            anEmployee.SaveEmployee(anEmployee);
            MessageBox.Show("Record Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult question = MessageBox.Show(("Do you want to register an user acces to the employee: \n" + anEmployee.EmployeeId + " - " +
                            anEmployee.FirstName + " " + anEmployee.LastName + "?"), "Register User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (question == DialogResult.Yes)
            {
                tabControlHiTech.SelectTab(tabPageUser);
                comboBoxEmployee.Text = textBoxEId.Text;
                textBoxFN.Text = "";
                textBoxLN.Text = "";
                maskedTextBoxPN.Text = "";
                textBoxE.Text = "";
            }
            ButtonListE_Click(sender, e);
        }
        private void ButtonListE_Click(object sender, EventArgs e)
        {
            Employee anEmployee = new Employee();
            List<Employee> listEmployee = anEmployee.ListEmployee();
            listViewEmployee.Items.Clear();

            foreach (Employee item in listEmployee)
            {
                ListViewItem element = new ListViewItem(item.EmployeeId.ToString());
                element.SubItems.Add(item.FirstName);
                element.SubItems.Add(item.LastName);
                element.SubItems.Add(item.JobTitle);
                element.SubItems.Add(item.PhoneNumber);
                element.SubItems.Add(item.Email);
                listViewEmployee.Items.Add(element);
            }

            textBoxFN.Text = "";
            textBoxLN.Text = "";
            maskedTextBoxPN.Text = "";
            textBoxE.Text = "";
        }
        private void buttonUpdateE_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to update the record?",
                "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                Employee anEmployee = new Employee();

                anEmployee.EmployeeId = Convert.ToInt32(textBoxEId.Text);
                anEmployee.FirstName = textBoxFN.Text;
                anEmployee.LastName = textBoxLN.Text;
                anEmployee.JobTitle = comboBoxJT.Text;
                anEmployee.PhoneNumber = maskedTextBoxPN.Text;
                anEmployee.Email = textBoxE.Text;
                anEmployee.UpdateEmployee(anEmployee);
                MessageBox.Show("Record Updated");
                ButtonListE_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Record NOT Updated");
                listViewEmployee.Items.Clear();
            }

            textBoxFN.Text = "";
            textBoxLN.Text = "";
            maskedTextBoxPN.Text = "";
            textBoxE.Text = "";
            textBoxEId.Text = Convert.ToString(EmployeeDB.GetRecord());
            textBoxEId.Enabled = true;
        }
        private void buttonDeleteE_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to delete the record?",
                "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                Employee anEmployee = new Employee();

                anEmployee.EmployeeId = Convert.ToInt32(textBoxEId.Text);
                anEmployee.FirstName = textBoxFN.Text;
                anEmployee.LastName = textBoxLN.Text;
                anEmployee.JobTitle = comboBoxJT.Text;
                anEmployee.PhoneNumber = maskedTextBoxPN.Text;
                anEmployee.Email = textBoxE.Text;
                anEmployee.DeleteEmployee(anEmployee);
                MessageBox.Show("Record Deleted");
                ButtonListE_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Record NOT Deleted");
                listViewEmployee.Items.Clear();

            }

            textBoxFN.Text = "";
            textBoxLN.Text = "";
            maskedTextBoxPN.Text = "";
            textBoxE.Text = "";
            textBoxEId.Text = Convert.ToString(EmployeeDB.GetRecord());
            textBoxEId.Enabled = true;

        }
        private void buttonSearchE_Click(object sender, EventArgs e)
        {
            listViewEmployee.Items.Clear();
            string data = textBoxSearchE.Text;
            Employee anEmployee = new Employee();

            int index = comboBoxSearchE.SelectedIndex;


            if (index == 0)
            {
                if (Validation.IsValidNumber(data))
                {
                    if (Validation.IsValidId(textBoxSearchE.Text, 4))
                    {
                        int dataId = Convert.ToInt32(textBoxSearchE.Text);
                        List<Employee> listEmployee = anEmployee.SearchEmployee(dataId);
                        if (listEmployee.Count == 0)
                        {
                            MessageBox.Show("Record not found");
                            textBoxSearchE.Clear();
                            textBoxSearchE.Focus();
                        }
                        foreach (Employee emp in listEmployee)
                        {
                            ListViewItem element = new ListViewItem(emp.EmployeeId.ToString());
                            element.SubItems.Add(emp.FirstName);
                            element.SubItems.Add(emp.LastName);
                            element.SubItems.Add(emp.JobTitle);
                            element.SubItems.Add(emp.PhoneNumber);
                            element.SubItems.Add(emp.Email);
                            listViewEmployee.Items.Add(element);
                            textBoxSearchE.Clear();
                            comboBoxSearchE.SelectedIndex = -1;
                            comboBoxSearchE.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Id must be 4 digits", "Invalid Id");
                        textBoxSearchE.Clear();
                        textBoxSearchE.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Id must be only numbers", "Invalid Id");
                    textBoxSearchE.Clear();
                    textBoxSearchE.Focus();
                    return;
                }
            }
            else if (index == 1)
            {
                if (Validation.IsValidText(textBoxSearchE.Text))
                {
                    listViewEmployee.Items.Clear();
                    List<Employee> listEmployee = anEmployee.SearchEmployee(data);
                    if (listEmployee.Count == 0)
                    {
                        MessageBox.Show("Record not found");
                        textBoxSearchE.Clear();
                        textBoxSearchE.Focus();
                    }
                    foreach (Employee emp in listEmployee)
                    {
                        ListEmployee(emp);
                    }
                }
                else
                {
                    MessageBox.Show("First Name must be only letter", "Invalid Name");
                    textBoxSearchE.Clear();
                    textBoxSearchE.Focus();
                    return;
                }
            }
            else if (index == 2)
            {
                if (Validation.IsValidText(textBoxSearchE.Text))
                {
                    listViewEmployee.Items.Clear();
                    List<Employee> listEmployee = anEmployee.SearchEmployee(data);
                    if (listEmployee.Count == 0)
                    {
                        MessageBox.Show("Record not found");
                        textBoxSearchE.Clear();
                        textBoxSearchE.Focus();
                    }
                    foreach (Employee emp in listEmployee)
                    {
                        ListEmployee(emp);
                    }
                }
                else
                {
                    MessageBox.Show("Last Name must be only letter", "Invalid Name");
                    textBoxSearchE.Clear();
                    textBoxSearchE.Focus();
                    return;
                }
            }
        }
        /// <summary>
        /// List all searched Employees under specified criteria
        /// </summary>
        /// <param name="emp"></param>
        private void ListEmployee(Employee emp)
        {
            ListViewItem element = new ListViewItem(emp.EmployeeId.ToString());
            element.SubItems.Add(emp.FirstName);
            element.SubItems.Add(emp.LastName);
            element.SubItems.Add(emp.JobTitle);
            element.SubItems.Add(emp.PhoneNumber);
            element.SubItems.Add(emp.Email);
            listViewEmployee.Items.Add(element);
            textBoxSearchE.Clear();
            comboBoxSearchE.SelectedIndex = -1;
            comboBoxSearchE.Focus();
        }
        private void listViewEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEmployee.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewEmployee.SelectedItems[0];
                Employee anEmployee = EmployeeDB.GetEmployee(item.Text);
                if (anEmployee != null)
                {
                    textBoxEId.Text = Convert.ToString(anEmployee.EmployeeId);
                    textBoxFN.Text = anEmployee.FirstName;
                    textBoxLN.Text = anEmployee.LastName;
                    maskedTextBoxPN.Text = anEmployee.PhoneNumber;
                    textBoxE.Text = anEmployee.Email;
                    comboBoxJT.SelectedItem = anEmployee.JobTitle;
                    textBoxEId.Enabled = false;
                }
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exit == DialogResult.Yes)
            {
                MessageBox.Show("Thank You!");
                Close();
            }
        }

        //User
        private void buttonSaveU_Click(object sender, EventArgs e)
        {
            User anUser = new User();

            if (comboBoxEmployee.SelectedIndex != -1)
            {

                if (Validation.IsDuplicatedUId(Convert.ToInt32(comboBoxEmployee.Text)))
                {
                    anUser.EmployeeId = Convert.ToInt32(comboBoxEmployee.Text);
                }
                else
                {
                    comboBoxEmployee.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("Employee ID is empty.", "Select an option!");
                comboBoxEmployee.Focus();
                return;
            }



            if (Validation.IsValidSize(textBoxUser.Text, 7))
            {
                anUser.UserName = textBoxUser.Text;
            }
            else
            {
                MessageBox.Show("User Name should be 7 characters.", "Invalid user name!");
                textBoxUser.Clear();
                textBoxUser.Focus();
                return;

            }

            if (Validation.IsValidSize(textBoxPassword.Text, 7))
            {
                anUser.Password = textBoxPassword.Text;
            }
            else
            {
                MessageBox.Show("Password should be 7 characters.", "Invalid password!");
                textBoxPassword.Clear();
                textBoxPassword.Focus();
                return;
            }

            anUser.JobTitle = textBoxJTitle.Text;
            anUser.SaveUser(anUser);
            MessageBox.Show("Record Saved");

            buttonListU_Click(sender, e);
        }
        private void buttonListU_Click(object sender, EventArgs e)
        {
            User anUser = new User();
            List<User> listUser = anUser.ListUser();
            listViewUser.Items.Clear();

            foreach (User item in listUser)
            {
                ListViewItem element = new ListViewItem(item.EmployeeId.ToString());
                element.SubItems.Add(item.JobTitle);
                element.SubItems.Add(item.UserName);
                element.SubItems.Add(item.Password);

                listViewUser.Items.Add(element);
            }
        }
        private void buttonUpdateU_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to update the record?",
                "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                User anUser = new User();


                anUser.EmployeeId = Convert.ToInt32(comboBoxEmployee.Text);
                anUser.JobTitle = textBoxJTitle.Text;

                if (Validation.IsValidSize(textBoxUser.Text, 7))
                {
                    anUser.UserName = textBoxUser.Text.Trim();
                }
                else
                {
                    MessageBox.Show("User Name should be 7 characters.", "Invalid user name!");
                    textBoxUser.Clear();
                    textBoxUser.Focus();
                    return;

                }

                if (Validation.IsValidSize(textBoxPassword.Text, 7))
                {
                    anUser.Password = textBoxPassword.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Password should be 7 characters.", "Invalid password!");
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                    return;
                }

                anUser.UpdateUser(anUser);
                MessageBox.Show("Record Updated");
                listViewUser.Items.Clear();
            }
            else
            {
                MessageBox.Show("Record NOT Updated");
                listViewUser.Items.Clear();
            }

            buttonListU_Click(sender, e);
            textBoxUser.Text = "";
            textBoxPassword.Text = "";
            comboBoxEmployee.Enabled = true;
        }
        private void buttonDeleteU_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to delete the record?",
               "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                User anUser = new User();

                anUser.EmployeeId = Convert.ToInt32(comboBoxEmployee.Text);
                anUser.JobTitle = textBoxJTitle.Text;
                anUser.UserName = textBoxUser.Text;
                anUser.Password = textBoxPassword.Text;

                anUser.DeleteUser(anUser);
                MessageBox.Show("Record Deleted");
                listViewUser.Items.Clear();
            }
            else
            {
                MessageBox.Show("Record NOT Deleted");
                listViewUser.Items.Clear();

            }
            buttonListU_Click(sender, e);
            textBoxUser.Text = "";
            textBoxPassword.Text = "";
            comboBoxEmployee.Enabled = true;
        }
        private void buttonSearchU_Click(object sender, EventArgs e)
        {
            listViewUser.Items.Clear();
            string data = textBoxSearchU.Text;
            User anUser = new User();

            int index = comboBoxSearchU.SelectedIndex;

            if (index == 0)
            {
                if (Validation.IsValidNumber(data))
                {
                    if (Validation.IsValidId(textBoxSearchU.Text, 4))
                    {
                        int dataId = Convert.ToInt32(textBoxSearchU.Text);
                        List<User> listUser = anUser.SearchUser(dataId);
                        if (listUser.Count == 0)
                        {
                            MessageBox.Show("Record not found");
                            textBoxSearchU.Clear();
                            textBoxSearchU.Focus();
                        }
                        foreach (User user in listUser)
                        {
                            ListUser(user);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Id should be 4 number.", "Invalid Id!");
                        textBoxSearchU.Clear();
                        textBoxSearchU.Focus();
                        return;
                    }
                }
            }
            else if (index == 1)
            {
                if (Validation.IsValidSize(textBoxSearchU.Text, 7))
                {
                    List<User> listUser = anUser.SearchUser(data);
                    if (listUser.Count == 0)
                    {
                        MessageBox.Show("Record not found");
                        textBoxSearchU.Clear();
                        textBoxSearchU.Focus();
                    }
                    foreach (User user in listUser)
                    {
                        ListUser(user);
                    }
                }
                else
                {
                    MessageBox.Show("UserName should be 7 characters.", "Invalid UserName!");
                    textBoxSearchU.Clear();
                    textBoxSearchU.Focus();
                    return;
                }

            }
        }
        /// <summary>
        /// List users under searched criteria
        /// </summary>
        /// <param name="user"></param>
        private void ListUser(User user)
        {
            ListViewItem element = new ListViewItem(user.EmployeeId.ToString());
            element.SubItems.Add(user.JobTitle);
            element.SubItems.Add(user.UserName);
            element.SubItems.Add(user.Password);
            listViewUser.Items.Add(element);

            textBoxSearchU.Clear();
            comboBoxSearchU.SelectedIndex = -1;
            comboBoxSearchU.Focus();
        }
        private void listViewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = listViewUser.FocusedItem.Index;

            User anUser = new User();
            List<User> listUser = anUser.ListUser();

            comboBoxEmployee.Text = Convert.ToString(listUser[index].EmployeeId);
            textBoxJTitle.Text = listUser[index].JobTitle;
            textBoxUser.Text = listUser[index].UserName;
            textBoxPassword.Text = Convert.ToString(listUser[index].Password);
            comboBoxEmployee.Enabled = false;
        }
        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee anEmployee = listEmployee.Find(emp => emp.EmployeeId == Convert.ToInt32(comboBoxEmployee.Text));
            textBoxJTitle.Text = anEmployee.JobTitle;
        }
        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category aCategory = db.Categories.Find(Convert.ToInt32(comboBoxCategory.Text));
            textBoxCategory.Text = aCategory.CategoryName;
        }
        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier aSupplier = db.Suppliers.Find(Convert.ToInt32(comboBoxSupplier.Text));
            textBoxSName.Text = aSupplier.Name;
        }
        private void comboBoxAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Author anAuthor = db.Authors.Find(Convert.ToInt32(comboBoxAuthor.Text));
            textBoxAFName.Text = anAuthor.FirstName;
            textBoxALName.Text = anAuthor.LastName;
        }
        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product aProduct = db.Products.Find(comboBoxProduct.Text);
            textBoxPOTitle.Text = aProduct.Title;
            textBoxPOPrice.Text = Convert.ToString(aProduct.Price);
            textBoxQoh.Text = Convert.ToString(aProduct.Quantity);
        }

        //Category
        private void buttonSaveCt_Click(object sender, EventArgs e)
        {
            if (Validation.IsValidId(textBoxCtId.Text, 2))
            {
                if (Validation.IsDuplicatedCtId(Convert.ToInt32(textBoxCtId.Text)))
                {
                    aCategory.CategoryId = Convert.ToInt32(textBoxCtId.Text.Trim());
                }
                else
                {
                    textBoxCtId.Clear();
                    textBoxCtId.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Id must be 2 digits", "Invalid Id");
                textBoxCtId.Clear();
                textBoxCtId.Focus();
                return;
            }

            if (Validation.IsValidText(textBoxCtName.Text))
            {
                aCategory.CategoryName = textBoxCtName.Text.Trim();
            }
            else
            {
                textBoxCtName.Clear();
                textBoxCtName.Focus();
                return;
            }

            db.Categories.Add(aCategory);
            db.SaveChanges();
            MessageBox.Show("Record Saved");
            buttonListCt_Click(sender, e);

        }
        private void buttonUpdateCt_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to update the record?",
                "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {

                aCategory.CategoryId = Convert.ToInt32(textBoxCtId.Text.Trim());

                if (Validation.IsValidText(textBoxCtName.Text))
                {
                    aCategory.CategoryName = textBoxCtName.Text.Trim();
                }
                else
                {
                    textBoxCtName.Clear();                    textBoxCtName.Focus();
                    return;
                }

                db.Categories.AddOrUpdate(aCategory);
                db.SaveChanges();
                MessageBox.Show("Record Updated");
                textBoxCtId.Enabled = true;
                textBoxCtId.Text = "";
                textBoxCtName.Text = "";
                buttonListCt_Click(sender, e);
            }
        }
        private void buttonDeleteCt_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to delete the record?",
            "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                aCategory.CategoryId = Convert.ToInt32(textBoxCtId.Text.Trim());
                aCategory.CategoryName = textBoxCtName.Text.Trim();

                db.Categories.Remove(aCategory);
                db.SaveChanges();
                MessageBox.Show("Record Deleted");
                textBoxCtId.Enabled = true;
                textBoxCtId.Text = "";
                textBoxCtName.Text = "";
                buttonListCt_Click(sender, e);
            }
        }
        private void buttonListCt_Click(object sender, EventArgs e)
        {
            var listCategory = from category in db.Categories select category;
            listViewCategory.Items.Clear();
            foreach (var item in listCategory)
            {
                ListViewItem element = new ListViewItem(Convert.ToString(item.CategoryId));
                element.SubItems.Add(item.CategoryName);
                listViewCategory.Items.Add(element);
            }
        }
        private void buttonSearchCt_Click(object sender, EventArgs e)
        {
            int index = comboBoxSearchCt.SelectedIndex;

            if (index == 0)
            {
                int searchId = Convert.ToInt32(textBoxSearchCt.Text.Trim());
                aCategory = db.Categories.Find(searchId);

                if (Validation.IsValidId(textBoxSearchCt.Text, 2))
                {

                    if (aCategory != null)
                    {

                        textBoxCtId.Text = aCategory.CategoryId.ToString();
                        textBoxCtName.Text = aCategory.CategoryName;

                        comboBoxSearchCt.SelectedIndex = -1;
                        textBoxSearchCt.Clear();
                        textBoxCtId.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found");
                        textBoxSearchCt.Clear();
                        textBoxSearchCt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Id must be 4 digits", "Invalid Id");
                    textBoxSearchCt.Clear();
                    textBoxSearchCt.Focus();
                }

            }
            else if (index == 1)
            {
                var listCategory = db.Categories.Where(category => category.CategoryName == textBoxSearchCt.Text).ToList<Category>();
                if (Validation.IsValidText(textBoxSearchCt.Text))
                {
                    if (listCategory.Count != 0)
                    {
                        listViewCategory.Items.Clear();
                        foreach (var item in listCategory)
                        {
                            ListViewItem element = new ListViewItem(Convert.ToString(item.CategoryId));
                            element.SubItems.Add(item.CategoryName);
                            listViewCategory.Items.Add(element);
                            comboBoxSearchCt.SelectedIndex = -1;
                            textBoxSearchCt.Clear();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Record Not Found");
                        textBoxSearchCt.Clear();
                        textBoxSearchCt.Focus();
                    }

                }
                else
                {
                    textBoxSearchCt.Clear();
                    textBoxSearchCt.Focus();
                }
            }
        }

        //Author
        private void buttonSaveA_Click(object sender, EventArgs e)
        {
            
            if (Validation.IsValidId(textBoxAId.Text, 3))
            {
                if (Validation.IsDuplicatedAId(Convert.ToInt32(textBoxAId.Text)))
                {
                    anAuthor.AuthorId = Convert.ToInt32(textBoxAId.Text.Trim());
                }
                else
                {
                    textBoxAId.Clear();
                    textBoxAId.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Id must be 3 digits", "Invalid Id");
                textBoxAId.Clear();
                textBoxAId.Focus();
                return;
            }

            if (Validation.IsValidText(textBoxAFN.Text))
            {
                anAuthor.FirstName = textBoxAFN.Text.Trim();
            }
            else
            {
                textBoxAFN.Clear();
                textBoxAFN.Focus();
                return;
            }

            if (Validation.IsValidText(textBoxALN.Text))
            {
                anAuthor.LastName = textBoxALN.Text.Trim();
            }
            else
            {
                textBoxALN.Clear();
                textBoxALN.Focus();
                return;
            }

            if (textBoxAE.Text != "")
            {
                anAuthor.Email = textBoxAE.Text.Trim();
            }
            else
            {
                MessageBox.Show("Author email is empty!");
                textBoxAE.Focus();
                return;
            }

           
            db.Authors.Add(anAuthor);
            db.SaveChanges();
            MessageBox.Show("Record Saved");
            buttonListA_Click(sender, e);
        }
        private void buttonListA_Click(object sender, EventArgs e)
        {
            var listAuthor = from author in db.Authors select author;
            listViewAuthor.Items.Clear();
            foreach (var item in listAuthor)
            {
                ListViewItem element = new ListViewItem(Convert.ToString(item.AuthorId));
                element.SubItems.Add(item.FirstName);
                element.SubItems.Add(item.LastName);
                element.SubItems.Add(item.Email);
                listViewAuthor.Items.Add(element);
            }
            textBoxAId.Text = "";
            textBoxAFN.Text = "";
            textBoxALN.Text = "";
            textBoxAE.Text = "";
        }
        private void buttonUpdateA_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to update the record?",
                "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {

                anAuthor.AuthorId = Convert.ToInt32(textBoxAId.Text.Trim());
               
                if (Validation.IsValidText(textBoxAFN.Text))
                {
                    anAuthor.FirstName = textBoxAFN.Text.Trim();
                }
                else
                {
                    textBoxAFN.Clear();
                    textBoxAFN.Focus();
                    return;
                }
               
                

                if (Validation.IsValidText(textBoxALN.Text))
                {
                    anAuthor.LastName = textBoxALN.Text.Trim();
                }
                else
                {
                    textBoxALN.Clear();
                    textBoxALN.Focus();
                    return;
                }

                if (textBoxAE.Text != "")
                {
                    anAuthor.Email = textBoxAE.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Author email is empty!");
                    textBoxAE.Focus();
                    return;
                }

                db.Authors.AddOrUpdate(anAuthor);
                db.SaveChanges();
                MessageBox.Show("Record Updated");
                textBoxAId.Enabled = true;
                textBoxAId.Text = "";
                textBoxAFN.Text = "";
                textBoxALN.Text = "";
                textBoxAE.Text = "";
                buttonListA_Click(sender, e);
            }
        }
        private void buttonDeleteA_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to delete the record?",
            "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                anAuthor.AuthorId = Convert.ToInt32(textBoxAId.Text.Trim());
                anAuthor.FirstName = textBoxAFN.Text.Trim();
                anAuthor.LastName = textBoxALN.Text.Trim();
                anAuthor.Email = textBoxAE.Text.Trim();

                db.Authors.Remove(anAuthor);
                db.SaveChanges();
                MessageBox.Show("Record Deleted");
                textBoxAId.Enabled = true;
                textBoxAId.Text = "";
                textBoxAFN.Text = "";
                textBoxALN.Text = "";
                textBoxAE.Text = "";
                buttonListA_Click(sender, e);
            }
        }
        private void buttonSearchA_Click(object sender, EventArgs e)
        {
            int index = comboBoxSearchA.SelectedIndex;

            if (index == 0)
            {
                int searchId = Convert.ToInt32(textBoxSearchA.Text.Trim());
                anAuthor = db.Authors.Find(searchId);

                if (Validation.IsValidId(textBoxSearchA.Text, 3))
                {

                    if (anAuthor != null)
                    {

                        textBoxAId.Text = anAuthor.AuthorId.ToString();
                        textBoxAFN.Text = anAuthor.FirstName;
                        textBoxAFN.Text = anAuthor.LastName;
                        textBoxAE.Text = anAuthor.Email;

                        comboBoxSearchA.SelectedIndex = -1;
                        textBoxSearchA.Clear();
                        textBoxAId.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found");
                        textBoxSearchA.Clear();
                        textBoxSearchA.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Id must be 3 digits", "Invalid Id");
                    textBoxSearchCt.Clear();
                    textBoxSearchCt.Focus();
                }

            }
            else if (index == 1)
            {
                var listAuthor = db.Authors.Where(author => author.FirstName == textBoxSearchA.Text).ToList<Author>();
                if (Validation.IsValidText(textBoxSearchA.Text))
                {
                    listViewAuthor.Items.Clear();
                    if (listAuthor.Count != 0)
                    {
                        foreach (var item in listAuthor)
                        {
                            ListViewItem element = new ListViewItem(Convert.ToString(item.AuthorId));
                            element.SubItems.Add(item.FirstName);
                            element.SubItems.Add(item.LastName);
                            element.SubItems.Add(item.Email);
                            listViewAuthor.Items.Add(element);
                            comboBoxSearchA.SelectedIndex = -1;
                            textBoxSearchA.Clear();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Record Not Found");
                        textBoxSearchA.Clear();
                        textBoxSearchA.Focus();
                    }

                }
                else
                {
                    textBoxSearchA.Clear();
                    textBoxSearchA.Focus();
                }
            }
            else if (index == 2)
            {
                var listAuthor = db.Authors.Where(author => author.LastName == textBoxSearchA.Text).ToList<Author>();
                if (Validation.IsValidText(textBoxSearchA.Text))
                {
                    listViewAuthor.Items.Clear();
                    if (listAuthor.Count != 0)
                    {
                        foreach (var item in listAuthor)
                        {
                            ListViewItem element = new ListViewItem(Convert.ToString(item.AuthorId));
                            element.SubItems.Add(item.FirstName);
                            element.SubItems.Add(item.LastName);
                            element.SubItems.Add(item.Email);
                            listViewAuthor.Items.Add(element);
                            comboBoxSearchA.SelectedIndex = -1;
                            textBoxSearchA.Clear();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Record Not Found");
                        textBoxSearchA.Clear();
                        textBoxSearchA.Focus();
                    }
                }
                else
                {
                    textBoxSearchA.Clear();
                    textBoxSearchA.Focus();
                }
            }
        }

        //Supplier
        private void buttonSaveS_Click(object sender, EventArgs e)
        {
            if (textBoxSN.Text != "")
            {
                aSupplier.Name = textBoxSN.Text.Trim();
            }
            else
            {
                MessageBox.Show("Supplier Name is empty!");
                textBoxSN.Focus();
                return;
            }
            if (Validation.IsValidId(textBoxSId.Text, 2))
            {
                if (Validation.IsDuplicatedSId(Convert.ToInt32(textBoxSId.Text)))
                {
                    aSupplier.SupplierId = Convert.ToInt32(textBoxSId.Text.Trim());
                }
                else
                {
                    textBoxSId.Clear();
                    textBoxSId.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Id must be 2 digits", "Invalid Id");
                textBoxSId.Clear();
                textBoxSId.Focus();
                return;
            }


            aSupplier.Name = textBoxSN.Text.Trim();

            db.Suppliers.Add(aSupplier);
            db.SaveChanges();
            MessageBox.Show("Record Saved");
            buttonListS_Click(sender, e);


        }
        private void buttonListS_Click(object sender, EventArgs e)
        {
            var listSupplier = from supplier in db.Suppliers select supplier;
            listViewSupplier.Items.Clear();
            foreach (var item in listSupplier)
            {
                ListViewItem element = new ListViewItem(Convert.ToString(item.SupplierId));
                element.SubItems.Add(item.Name);
                listViewSupplier.Items.Add(element);
            }
            textBoxSId.Text = "";
            textBoxSN.Text = "";
        }
        private void buttonUpdateS_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to update the record?",
                "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                aSupplier.SupplierId = Convert.ToInt32(textBoxSId.Text.Trim());
                if (textBoxSN.Text != "")
                {
                    aSupplier.Name = textBoxSN.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Supplier Name is empty!");
                    textBoxSN.Focus();
                    return;
                }


                db.Suppliers.AddOrUpdate(aSupplier);
                db.SaveChanges();
                MessageBox.Show("Record Updated");
                textBoxSId.Enabled = true;
                textBoxSId.Text = "";
                textBoxSN.Text = "";
                buttonListS_Click(sender, e);
            }
        }
        private void buttonDeleteS_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to delete the record?",
            "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                aSupplier.SupplierId = Convert.ToInt32(textBoxSId.Text.Trim());
                aSupplier.Name = textBoxSN.Text.Trim();

                db.Suppliers.Remove(aSupplier);
                db.SaveChanges();
                MessageBox.Show("Record Deleted");
                textBoxSId.Enabled = true;
                textBoxSId.Text = "";
                textBoxSN.Text = "";
                buttonListS_Click(sender, e);
            }
        }
        private void buttonSearchS_Click(object sender, EventArgs e)
        {
            int index = comboBoxSearchS.SelectedIndex;

            if (index == 0)
            {
                int searchId = Convert.ToInt32(textBoxSearchS.Text.Trim());
                aSupplier = db.Suppliers.Find(searchId);

                if (Validation.IsValidId(textBoxSearchS.Text, 2))
                {

                    if (aSupplier != null)
                    {

                        textBoxSId.Text = aSupplier.SupplierId.ToString();
                        textBoxSN.Text = aSupplier.Name;

                        comboBoxSearchS.SelectedIndex = -1;
                        textBoxSearchS.Clear();
                        textBoxSId.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found");
                        textBoxSearchS.Clear();
                        textBoxSearchS.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Id must be 2 digits", "Invalid Id");
                    textBoxSearchS.Clear();
                    textBoxSearchS.Focus();
                }

            }
            else if (index == 1)
            {
                var listSupplier = db.Suppliers.Where(supplier => supplier.Name == textBoxSearchS.Text).ToList<Supplier>();
                if (listSupplier.Count != 0)
                {
                    listViewSupplier.Items.Clear();
                    foreach (var item in listSupplier)
                    {
                        ListViewItem element = new ListViewItem(Convert.ToString(item.SupplierId));
                        element.SubItems.Add(item.Name);
                        listViewSupplier.Items.Add(element);
                    }
                    comboBoxSearchS.SelectedIndex = -1;
                    textBoxSearchS.Clear();
                }
                else
                {
                    MessageBox.Show("Record Not Found");
                    textBoxSearchS.Clear();
                    textBoxSearchS.Focus();
                }

            }
        }

        //Product
        private void buttonSaveP_Click(object sender, EventArgs e)
        {
            Product aProduct = new Product();

            if (Validation.IsValidSize(maskedTextBoxISBN.Text, 13))
            {
                if (Validation.IsDuplicatedPId(maskedTextBoxISBN.Text))
                {
                    aProduct.ISBN = maskedTextBoxISBN.Text.Trim();
                }
                else
                {
                    maskedTextBoxISBN.Clear();
                    maskedTextBoxISBN.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("ISBN must be 13 digits", "Invalid ISBN");
                maskedTextBoxISBN.Clear();
                maskedTextBoxISBN.Focus();
                return;
            }

            if (textBoxPTitle.Text != "")
            {
                aProduct.Title = textBoxPTitle.Text.Trim();
            }
            else
            {
                MessageBox.Show("Title is empty!");
                textBoxPTitle.Focus();
                return;
            }

            if (comboBoxCategory.SelectedIndex != -1)
            {
                aProduct.CategoryId = Convert.ToInt32(comboBoxCategory.Text);
            }
            else
            {
                MessageBox.Show("Category is empty!");
                comboBoxCategory.Focus();
                return;
            }

            if (comboBoxYear.SelectedIndex != -1)
            {
                aProduct.YearPublished = Convert.ToInt32(comboBoxYear.Text);
            }
            else
            {
                MessageBox.Show("YearPublished is empty!");
                comboBoxYear.Focus();
                return;
            }

            if (comboBoxSupplier.SelectedIndex != -1)
            {
                aProduct.SuppliedId = Convert.ToInt32(comboBoxSupplier.Text);
            }
            else
            {
                MessageBox.Show("SupplierId is empty!");
                comboBoxSupplier.Focus();
                return;
            }

            if (textBoxQuantity.Text != "")
            {
                aProduct.Quantity = Convert.ToInt32(textBoxQuantity.Text.Trim());
            }
            else
            {
                MessageBox.Show("Quantity is empty!");
                textBoxQuantity.Focus();
                return;
            }

            if (textBoxPrice.Text != "")
            {
                aProduct.Price = Convert.ToDouble(textBoxPrice.Text.Trim());
            }
            else
            {
                MessageBox.Show("Price is empty!");
                textBoxPrice.Focus();
                return;
            }


            db.Products.Add(aProduct);
            db.SaveChanges();
            MessageBox.Show("Record Saved");
            DialogResult Result = MessageBox.Show("Do you want to include an author to this book?",
                "RELATED AUTHOR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {

                comboBoxAuthor.Focus();
                maskedTextBoxISBN.Enabled = false;

                buttonListP_Click(sender, e);
            }

            maskedTextBoxISBN.Enabled = true;
            buttonListP_Click(sender, e);

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AProduct anAproduct = new AProduct();

            string searchId = maskedTextBoxISBN.Text.Trim();
            aProduct = db.Products.Find(searchId);

            if (aProduct != null)
            {
                if (Validation.IsDuplicatedAPId(maskedTextBoxISBN.Text, Convert.ToInt32(comboBoxAuthor.Text)))
                {
                    anAproduct.ISBN = maskedTextBoxISBN.Text.Trim();
                    anAproduct.AuthorId = Convert.ToInt32(comboBoxAuthor.Text);
                }
                else
                {

                    comboBoxAuthor.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("ISBN NOT found. The product must be salved before include an author");
                maskedTextBoxISBN.Focus();
                return;
            }

            db.AProducts.Add(anAproduct);
            db.SaveChanges();
            MessageBox.Show("Record Saved");
            DialogResult Result = MessageBox.Show("Do you want to include another author to this book?",
                "RELATED AUTHOR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {

                comboBoxAuthor.Focus();
                maskedTextBoxISBN.Enabled = false;

                buttonListP_Click(sender, e);
            }

            maskedTextBoxISBN.Enabled = true;

        }
        
        private void buttonListP_Click(object sender, EventArgs e)
        {
            var listProduct = from product in db.Products select product;
            listViewProduct.Items.Clear();
            foreach (var item in listProduct)
            {
                ListViewItem element = new ListViewItem(item.ISBN);
                element.SubItems.Add(item.Title);
                element.SubItems.Add(Convert.ToString(item.CategoryId));
                element.SubItems.Add(Convert.ToString(item.YearPublished));
                element.SubItems.Add(Convert.ToString(item.Price));
                element.SubItems.Add(Convert.ToString(item.Quantity));
                element.SubItems.Add(Convert.ToString(item.Quantity * item.Price));


                listViewProduct.Items.Add(element);
            }
        }
        private void buttonUpdateP_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to update the record?",
                "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                aProduct.ISBN = maskedTextBoxISBN.Text.Trim();

                if (textBoxPTitle.Text != "")
                {
                    aProduct.Title = textBoxPTitle.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Product title is empty!");
                    textBoxPTitle.Focus();
                    return;
                }

                aProduct.CategoryId = Convert.ToInt32(comboBoxCategory.Text);

                if (textBoxPrice.Text != "")
                {
                    aProduct.Price = Convert.ToDouble(textBoxPrice.Text.Trim());

                }
                else
                {
                    MessageBox.Show("Product Price is empty!");
                    textBoxPrice.Focus();
                    return;
                }

                aProduct.YearPublished = Convert.ToInt32(comboBoxYear.Text);

                if (textBoxQuantity.Text != "")
                {
                    aProduct.Quantity = Convert.ToInt32(textBoxQuantity.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Product Quantity is empty!");
                    textBoxQuantity.Focus();
                    return;
                }

                aProduct.SuppliedId = Convert.ToInt32(comboBoxSupplier.Text);

                db.Products.AddOrUpdate(aProduct);
                db.SaveChanges();
                MessageBox.Show("Record Updated");
                maskedTextBoxISBN.Enabled = true;

                buttonListP_Click(sender, e);
            }
        }
        private void buttonDeleteP_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to delete the record?",
            "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                aProduct.ISBN = maskedTextBoxISBN.Text.Trim();
                aProduct.Title = textBoxPTitle.Text;
                aProduct.CategoryId = Convert.ToInt32(comboBoxCategory.Text);
                aProduct.Price = Convert.ToDouble(textBoxPrice.Text);
                aProduct.YearPublished = Convert.ToInt32(comboBoxYear.Text);
                aProduct.Quantity = Convert.ToInt32(textBoxQuantity.Text);
                aProduct.SuppliedId = Convert.ToInt32(comboBoxSupplier.Text);

                var listAProduct = db.AProducts.Where(p => p.ISBN == aProduct.ISBN).ToList();
                foreach (var item in listAProduct)
                {
                    db.AProducts.Remove(item);
                }

                db.Products.Remove(aProduct);
                db.SaveChanges();
                MessageBox.Show("Record Deleted");
                maskedTextBoxISBN.Enabled = true;

                buttonListP_Click(sender, e);
            }
        }
        private void buttonSearchP_Click(object sender, EventArgs e)
        {
            int index = comboBoxSearchP.SelectedIndex;

            if (index == 0)
            {
                string searchId = textBoxSearchP.Text.Trim();
                aProduct = db.Products.Find(searchId);

                if (Validation.IsValidSize(textBoxSearchP.Text, 13))
                {

                    if (aProduct != null)
                    {

                        maskedTextBoxISBN.Text = aProduct.ISBN;
                        textBoxPTitle.Text = aProduct.Title;
                        comboBoxCategory.Text = aProduct.CategoryId.ToString();
                        textBoxPrice.Text = aProduct.Price.ToString();
                        comboBoxYear.Text = aProduct.YearPublished.ToString();
                        textBoxQuantity.Text = aProduct.Quantity.ToString();
                        comboBoxSupplier.Text = aProduct.SuppliedId.ToString();

                        comboBoxSearchP.SelectedIndex = -1;
                        textBoxSearchP.Clear();
                        maskedTextBoxISBN.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found");
                        textBoxSearchS.Clear();
                        textBoxSearchS.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ISBN must be 13 digits", "Invalid ISBN");
                    textBoxSearchS.Clear();
                    textBoxSearchS.Focus();
                }

            }
            else if (index == 1)
            {
                listViewProduct.Items.Clear();
                var listProduct = db.Products.Where(product => product.Title == textBoxSearchP.Text).ToList<Product>();
                if (listProduct.Count != 0)
                {
                    foreach (var item in listProduct)
                    {
                        ListViewItem element = new ListViewItem(item.ISBN);
                        element.SubItems.Add(item.Title);
                        element.SubItems.Add(Convert.ToString(item.CategoryId));
                        element.SubItems.Add(Convert.ToString(item.Price));
                        element.SubItems.Add(Convert.ToString(item.YearPublished));
                        element.SubItems.Add(Convert.ToString(item.Quantity));
                        element.SubItems.Add(Convert.ToString(item.SuppliedId));
                        listViewProduct.Items.Add(element);
                    }
                    textBoxSearchP.Clear();

                }
                else
                {
                    MessageBox.Show("Record Not Found");
                    textBoxSearchS.Clear();
                    textBoxSearchS.Focus();
                }

            }
        }
        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow drCustomer = dtCustomers.Rows.Find(Convert.ToInt32(comboBoxCustomer.Text));
            textBoxCOName.Text = drCustomer["Name"].ToString();
            textBoxCOCredit.Text = drCustomer["Credit"].ToString();
        }
        private void comboBoxEId_SelectedIndexChanged(object sender, EventArgs e)
        {
            listEmployee = anEmployee.ListEmployee();
            anEmployee = listEmployee.Find(emp => emp.EmployeeId == Convert.ToInt32(comboBoxEId.Text));
            if (listEmployee.Count > 0)
            {
                textBoxEFN.Text = anEmployee.FirstName;
                textBoxELN.Text = anEmployee.LastName;
            }
            else
            {
                MessageBox.Show(comboBoxEId.Text);
            }
        }

        //Order
        
        private void buttonAddOL_Click(object sender, EventArgs e)
        {
            if (Validation.IsDuplicatedOPId(Convert.ToInt32(textBoxOId.Text.Trim()), comboBoxProduct.Text))
            {
                Order anOrder = new Order();
                anOrder.OrderId = Convert.ToInt32(textBoxOId.Text.Trim());
                if (comboBoxEId.SelectedIndex != -1)
                {
                    anOrder.EmployeeId = Convert.ToInt32(comboBoxEId.Text);
                }
                else
                {
                    MessageBox.Show("Employee Id is empty");
                    comboBoxEId.Focus();
                    return;
                }

                if (comboBoxCustomer.SelectedIndex != -1)
                {
                    anOrder.CustomerId = Convert.ToInt32(comboBoxCustomer.Text);
                }
                else
                {
                    MessageBox.Show("Customer Id is empty");
                    comboBoxCustomer.Focus();
                    return;
                }

                anOrder.OrderDate = Convert.ToDateTime(dateTimePickerODate.Text);

                if (comboBoxOBy.SelectedIndex != -1)
                {
                    anOrder.OrderBy = comboBoxOBy.Text;
                }
                else
                {
                    MessageBox.Show("OrderBy is empty");
                    comboBoxOBy.Focus();
                    return;
                }

                anOrder.TotalPrice = Convert.ToDouble(textBoxTotal.Text);

                Order_lines anOLine = new Order_lines();
                anOLine.OrderId = anOrder.OrderId;
                anOLine.ISBN = comboBoxProduct.Text;
                anOLine.Title = textBoxPOTitle.Text;
                anOLine.Price = Convert.ToDouble(textBoxPOPrice.Text.Trim());
                anOLine.OrderQuantity = Convert.ToInt32(textBoxPOQuantity.Text.Trim());
                anOLine.SubTotal = Convert.ToDouble(textBoxSubTotal.Text.Trim());


                aCustomer = GetCustomer(aCustomer);
                int credit = Convert.ToInt32(textBoxCOCredit.Text);
                aCustomer.Credit = credit;

                if (db.Orders.Find(Convert.ToInt32(textBoxOId.Text)) == null)
                {
                    aProduct = db.Products.Find(comboBoxProduct.Text);
                    db.Orders.Add(anOrder);
                    db.Order_lines.Add(anOLine);
                }
                else
                {
                    MessageBox.Show("Added OrderLine");
                    db.Order_lines.Add(anOLine);

                }

                UpdateCustomerCredit(aCustomer.CustomerId, aCustomer.Credit);
                aProduct.Quantity = Convert.ToInt32(textBoxQoh.Text.Trim());
                db.Products.AddOrUpdate(aProduct);
                db.SaveChanges();

                textBoxPOQuantity.Enabled = true;
                textBoxPOQuantity.Text = "";
                buttonListOrderLines_Click(sender, e);

            }
            else
            {

                textBoxOId.Focus();
                return;
            }

            int oid = Convert.ToInt32(textBoxOId.Text);
            var sum = db.Order_lines.Where(s => s.OrderId == oid).Sum(s => s.SubTotal);
            if (sum != 0)
            {
                textBoxTotal.Text = Convert.ToString(sum);
            }
            else
            {
                textBoxTotal.Text = textBoxSubTotal.Text;
            }

        }     
        private void tabControlHiTech_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlHiTech.SelectedTab == tabPageEmployee)
            {

                textBoxEId.Text = Convert.ToString(EmployeeDB.GetRecord());

                listEmployee = anEmployee.ListEmployee();
                foreach (Employee employee in listEmployee)
                {
                    comboBoxEmployee.Items.Add(employee.EmployeeId);
                }
            }
            else if (tabControlHiTech.SelectedTab == tabPageUser)
            {
                comboBoxEmployee.Items.Clear();
                Employee anEmployee = new Employee();


                listEmployee = anEmployee.ListEmployee();
                foreach (Employee employee in listEmployee)
                {
                    comboBoxEmployee.Items.Add(employee.EmployeeId);
                }

            }
            else if (tabControlHiTech.SelectedTab == tabPageCustomer)
            {
                comboBoxCustomer.Items.Clear();
                var nextval = db.Customers.Max(cid => cid.CustomerId);
                textBoxCId.Text = Convert.ToString(nextval + 1);
                var listCustomer = from customer in db.Customers select customer;
                foreach (var item in listCustomer)
                {
                    comboBoxCustomer.Items.Add(item.CustomerId);
                }
            }

            else if (tabControlHiTech.SelectedTab == tabPageAuthor)
            {
                comboBoxAuthor.Items.Clear();
                var listAuthor = from author in db.Authors select author;
                foreach (var item in listAuthor)
                {
                    comboBoxAuthor.Items.Add(item.AuthorId);
                }
            }
            else if (tabControlHiTech.SelectedTab == tabPageProduct)
            {
                comboBoxProduct.Items.Clear();
                comboBoxCategory.Items.Clear();
                comboBoxAuthor.Items.Clear();
                comboBoxSupplier.Items.Clear();

                var listProduct = from product in db.Products select product;
                foreach (var item in listProduct)
                {
                    comboBoxProduct.Items.Add(item.ISBN);
                }
                var listCategory = from category in db.Categories select category;
                foreach (var item in listCategory)
                {
                    comboBoxCategory.Items.Add(item.CategoryId);
                }
                var listAuthor = from author in db.Authors select author;
                foreach (var item in listAuthor)
                {
                    comboBoxAuthor.Items.Add(item.AuthorId);
                }
                var listSupplier = from supplier in db.Suppliers select supplier;
                foreach (var item in listSupplier)
                {
                    comboBoxSupplier.Items.Add(item.SupplierId);
                }
            }
            else if (tabControlHiTech.SelectedTab == tabPageOrder)
            {
                
                comboBoxCustomer.Items.Clear();
                comboBoxEId.Items.Clear();
                comboBoxProduct.Items.Clear();
            
                var listCustomer = from customer in db.Customers select customer;
                foreach (var item in listCustomer)
                {
                    comboBoxCustomer.Items.Add(item.CustomerId);
                }
                var listEmployees = from employee in db.Employees select employee;
                foreach (var item in listEmployees.Where(emp => emp.JobTitle == "Clerk"))
                {
                    comboBoxEId.Items.Add(item.EmployeeId);
                }
                var listProduct = from product in db.Products select product;
                foreach (var item in listProduct)
                {
                    comboBoxProduct.Items.Add(item.ISBN);
                }
            
                var nextval = db.Orders.Max(oid => oid.OrderId);
                textBoxOId.Text = Convert.ToString(nextval + 1);
                
                
            }
            else if (tabControlHiTech.SelectedTab == tabPageOrderReport)
            {
                comboBoxOOEmpId.Items.Clear();

                var listEmployees = from employee in db.Employees select employee;
                foreach (var item in listEmployees.Where(emp => emp.JobTitle == "Clerk"))
                {
                    comboBoxOOEmpId.Items.Add(item.EmployeeId);
                }

            }

        }        
        private void buttonSearchClient_Click(object sender, EventArgs e)
        {
            int index = comboBoxSearhOLCust.SelectedIndex;

            if (index == 0)
            {
                int searchId = Convert.ToInt32(textBoxOLSCustomer.Text.Trim());
                DataRow drCustomer = dtCustomers.Rows.Find(searchId);
                if (drCustomer != null)
                {
                    comboBoxCustomer.Text = drCustomer["CustomerId"].ToString();
                    textBoxCOName.Text = drCustomer["Name"].ToString();
                    textBoxCOCredit.Text = drCustomer["Credit"].ToString();
                    comboBoxSearhOLCust.SelectedIndex = -1;
                    textBoxOLSCustomer.Clear();

                }
                else
                {
                    MessageBox.Show("Customer not found");
                    textBoxOLSCustomer.Clear();
                    textBoxOLSCustomer.Focus();

                }
            }
            else if (index == 1)
            {
                string searchName = textBoxOLSCustomer.Text.Trim();
                DataRow drCustomer = dtCustomers.Rows.Find(searchName);
                if (drCustomer != null)
                {
                    textBoxCId.Text = drCustomer["CustomerId"].ToString();
                    textBoxCOName.Text = drCustomer["Name"].ToString();
                    textBoxCOCredit.Text = drCustomer["Credit"].ToString();
                    comboBoxSearhOLCust.SelectedIndex = -1;
                    textBoxOLSCustomer.Clear();
                }
                else
                {
                    MessageBox.Show("Customer not found");
                    textBoxOLSCustomer.Clear();
                    textBoxOLSCustomer.Focus();
                }
            }
        }       
        private void SaleCredit(int unit, int price, int credit)
        {
            double remCredit = credit - (unit * price);

        }       
        private void buttonListOrder_Click(object sender, EventArgs e)
        {
            tabControlHiTech.SelectTab(tabPageOrderReport);
            labelHitechInfo.Visible = false;
        }
        private void buttonReturnOrder_Click(object sender, EventArgs e)
        {
            tabControlHiTech.SelectTab(tabPageOrder);
            labelHitechInfo.Visible = true;
        }
        private void UpdateCustomerCredit(int custId, double credit)
        {
            DataRow drCustomer = dtCustomers.Rows.Find(custId);
            if (drCustomer != null)
            {
                drCustomer["Credit"] = credit;

                UtilityDB.UpdateDBTable("Customers");
                MessageBox.Show("Record Updated");
            }
        }
        private void buttonListOrderLines_Click(object sender, EventArgs e)
        {
            int oId = Convert.ToInt32(textBoxOId.Text);
            var listOLine = db.Order_lines.Where(ordeLine => ordeLine.OrderId == oId).ToList<Order_lines>();
            //var sum = db.Order_lines.Where(s => s.OrderId == oId).Sum(s => s.SubTotal);
            //textBoxTotal.Text = Convert.ToString(sum);

            if (listOLine.Count > 0)
            {
                listViewOrderLine.Items.Clear();
                foreach (var item in listOLine)
                {
                    ListViewItem element = new ListViewItem(item.ISBN);
                    element.SubItems.Add(item.Title);
                    element.SubItems.Add(Convert.ToString(item.Price));
                    element.SubItems.Add(Convert.ToString(item.OrderQuantity));
                    element.SubItems.Add(Convert.ToString(item.SubTotal));
                    listViewOrderLine.Items.Add(element);
                }
            }
            else
            {
                MessageBox.Show("There is no order registered under this number", "Information");
            }
            
        }
        private void buttonListOReport_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();
            var listOrder = from order in db.Orders select order;

            foreach (var item in listOrder)
            {
                FillListOrder(item, listViewOrder);
            }
        }
        private void FillListOrder(Order item, ListView listView)
        {
            ListViewItem element = new ListViewItem(Convert.ToString(item.OrderId));
            element.SubItems.Add(Convert.ToString(item.EmployeeId));
            element.SubItems.Add(Convert.ToString(item.CustomerId));
            element.SubItems.Add(item.Customer.Name);
            element.SubItems.Add(Convert.ToString(item.OrderDate));
            element.SubItems.Add(Convert.ToString(item.OrderBy));
            element.SubItems.Add(Convert.ToString(item.TotalPrice));
            listView.Items.Add(element);
        }
        private void FillInvoice(Order item, Order_lines oLines, ListView listView)
        {
            ListViewItem element = new ListViewItem(Convert.ToString(item.OrderId));
            element.SubItems.Add(oLines.ISBN);
            element.SubItems.Add(oLines.Title);
            element.SubItems.Add(Convert.ToString(oLines.OrderQuantity));
            element.SubItems.Add(Convert.ToString(oLines.Price));
            element.SubItems.Add(Convert.ToString(oLines.SubTotal));
            element.SubItems.Add(Convert.ToString(item.TotalPrice));
            listView.Items.Add(element);
        }
        private void listViewCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = listViewCategory.FocusedItem.Index;

            var listCategory = (from category in db.Categories select category).ToList<Category>();

            textBoxCtId.Text = Convert.ToString(listCategory[index].CategoryId);
            textBoxCtName.Text = listCategory[index].CategoryName;

            textBoxCtId.Enabled = false;

        }
        private void listViewAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = listViewAuthor.FocusedItem.Index;

            var listAuthor = (from author in db.Authors select author).ToList<Author>();

            textBoxAId.Text = Convert.ToString(listAuthor[index].AuthorId);
            textBoxAFN.Text = listAuthor[index].FirstName;
            textBoxALN.Text = listAuthor[index].LastName;
            textBoxAE.Text = listAuthor[index].Email;

            textBoxAId.Enabled = false;
        }
        private void listViewOrderLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = listViewOrderLine.FocusedItem.Index;
            int oId = Convert.ToInt32(textBoxOId.Text);
            var sum = db.Order_lines.Where(s => s.OrderId == oId).Sum(s => s.SubTotal);

            aCustomer = GetCustomer(aCustomer);
            

            var listOrderLine = (from order_lines in db.Order_lines where order_lines.OrderId == oId select order_lines).ToList<Order_lines>();
            aProduct = db.Products.Find(listOrderLine[index].ISBN);

            comboBoxProduct.Text = listOrderLine[index].ISBN;
            textBoxPOTitle.Text = listOrderLine[index].Title;
            textBoxPOPrice.Text = Convert.ToString(listOrderLine[index].Price);
            textBoxPOQuantity.Text = "";
            textBoxQoh.Text = Convert.ToString(aProduct.Quantity + listOrderLine[index].OrderQuantity);
            textBoxSubTotal.Text = "";
            textBoxTotal.Text = Convert.ToString(sum);
            textBoxCOCredit.Text = Convert.ToString(aCustomer.Credit + listOrderLine[index].SubTotal);
            units = listOrderLine[index].OrderQuantity;
           
        }
        private void buttonSearchOrder_Click(object sender, EventArgs e)
        {
            int index = comboBoxSearchOrder.SelectedIndex;
            int id = Convert.ToInt32(textBoxSearchOrder.Text);
            listViewOrder.Items.Clear();

            switch (index)
            {
                case 0:
                    
                    var listOrders = db.Orders.Where(orders => orders.OrderId == id).ToList<Order>();
                    foreach (var item in listOrders)
                    {
                        FillListOrder(item, listViewOrder);
                    }
                    break;
                case 1:
                    var listClients = db.Orders.Where(clients => clients.CustomerId == id).ToList<Order>();
                    foreach (var item in listClients)
                    {
                        FillListOrder(item, listViewOrder);
                    }
                    break;
                case 2:
                    var listEmps = db.Orders.Where(emps => emps.EmployeeId == id).ToList<Order>();
                    foreach (var item in listEmps)
                    {
                        FillListOrder(item, listViewOrder);
                    }
                    break;
               
            }

        }
        private void listViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewOrder.SelectedItems[0];
                anOrder = db.Orders.Find(Convert.ToInt32(item.Text));
                listEmployee = anEmployee.ListEmployee();
                anEmployee = listEmployee.Find(emp => emp.EmployeeId == anOrder.EmployeeId);
                
                if (anOrder != null)
                {
                    
                    textBoxOOId.Text = Convert.ToString(anOrder.OrderId);
                    comboBoxOOEmpId.SelectedItem = anOrder.EmployeeId;
                    dateTimePickerOODate.Value = Convert.ToDateTime(anOrder.OrderDate);
                    comboBoxOOby.SelectedItem = anOrder.OrderBy;
                    textBoxOEFN.Text = anEmployee.FirstName;
                    textBoxOOLN.Text = anEmployee.LastName;


                }
            }
            //int index;
            //index = listViewOrder.FocusedItem.Index;
            
            


        }
        private void buttonORUpdate_Click(object sender, EventArgs e)
        {
            DialogResult update = MessageBox.Show("Do you want to update the Order "
                                                + textBoxOOId.Text + "?", "Question",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (update == DialogResult.Yes)
            {
                Order anOrder = new Order();
                anOrder = db.Orders.Find(Convert.ToInt32(textBoxOOId.Text));

                anOrder.OrderId = Convert.ToInt32(textBoxOOId.Text);
                anOrder.EmployeeId = Convert.ToInt32(comboBoxOOEmpId.Text);
                anOrder.OrderBy = comboBoxOOby.Text;
                anOrder.OrderDate = Convert.ToDateTime(dateTimePickerOODate.Text);
                

                db.Orders.AddOrUpdate(anOrder);
                db.SaveChanges();
                MessageBox.Show("Order " + textBoxOOId.Text + " updated succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Order not updated.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void comboBoxOOEmpId_SelectedIndexChanged(object sender, EventArgs e)
        {
            listEmployee = anEmployee.ListEmployee();
            anEmployee = listEmployee.Find(emp => emp.EmployeeId == Convert.ToInt32(comboBoxOOEmpId.Text));
            if (listEmployee.Count > 0)
            {
                textBoxOEFN.Text = anEmployee.FirstName;
                textBoxOOLN.Text = anEmployee.LastName;
            }
            else
            {
                MessageBox.Show(comboBoxOOEmpId.Text);
            }


        }
        private void buttonSearchInvoice_Click(object sender, EventArgs e)
        {

            if (textBoxSearchInvoice.Text != "")
            {
                int index = comboBoxSearchInvoice.SelectedIndex;
                int id = Convert.ToInt32(textBoxSearchInvoice.Text);
                switch (index)
                {
                    case 0:
                        listViewInvoice.Items.Clear();
                        var listOrders = db.Orders.Where(orders => orders.OrderId == id).ToList<Order>();
                        if (listOrders.Count !=0)
                        {
                            foreach (var item in listOrders)
                            {
                                var listInvoices = db.Order_lines.Where(oLine => oLine.OrderId == item.OrderId);
                                foreach (var item2 in listInvoices)
                                {
                                    FillInvoice(item, item2, listViewInvoice);
                                }
                                int oid = item.OrderId;
                                var sum = db.Order_lines.Where(s => s.OrderId == oid).Sum(s => s.SubTotal);
                                FillInvoiceLabels(item.CustomerId, sum);
                                buttonSaveInvoice.Enabled = true;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Order Id NOT found");
                            textBoxSearchInvoice.Text = "";
                            textBoxSearchInvoice.Focus();
                            return;
                        }                        
                        break;
                    case 1:
                        listViewInvoice.Items.Clear();
                        var listCustomers = db.Orders.Where(orders => orders.CustomerId == id).ToList<Order>();
                        if (listCustomers.Count !=0)
                        {
                            foreach (var item in listCustomers)
                            {
                                var listInvoices = db.Order_lines.Where(oLine => oLine.OrderId == item.OrderId);
                                foreach (var item2 in listInvoices)
                                {
                                    FillInvoice(item, item2, listViewInvoice);
                                }
                                int oid = item.OrderId;
                                var sum = db.Order_lines.Where(s => s.OrderId == oid).Sum(s => s.SubTotal);
                                FillInvoiceLabels(item.CustomerId, sum);
                                buttonSaveInvoice.Enabled = true;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Customer Id NOT found");
                            textBoxSearchInvoice.Text = "";
                            textBoxSearchInvoice.Focus();
                            return;
                        }
                        break;
                } 
            }
            else
            {
                MessageBox.Show("Please choose a search criteria", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }          
        private void FillInvoiceLabels(int id, double total)
        {
            DataRow drCustomer = dtCustomers.Rows.Find(id);
            if (drCustomer != null)
            {
                labelCNumber.Text = drCustomer["CustomerId"].ToString();
                labelNumber.Text = drCustomer["StreetNo"].ToString();
                labelStreet.Text = drCustomer["StreetName"].ToString();
                labelCity.Text = drCustomer["City"].ToString();
                labelCName.Text = drCustomer["Name"].ToString(); 
                labelPCode.Text = drCustomer["PostalCode"].ToString();
                labelPhone.Text = drCustomer["PhoneNumber"].ToString();
                labelFax.Text = drCustomer["FaxNumber"].ToString();
                labelSubTotal.Text = Convert.ToString(total);
            }

        }
        private void buttonDeleteOrderLine_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to delete the record?",
           "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                anOLine = db.Order_lines.Find(Convert.ToInt32(textBoxOId.Text), comboBoxProduct.Text);
                db.Order_lines.Remove(anOLine);
                db.SaveChanges();
                MessageBox.Show("Record Deleted");
                buttonListOrderLines_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Record NOT Deleted");
            }
        }
        private void buttonUpdateOrderLine_Click(object sender, EventArgs e)
        {
            DialogResult update = MessageBox.Show("Do you want to update the Order Line "
                                                + textBoxOId.Text + "?", "Question",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (update == DialogResult.Yes)
            {
                if (textBoxPOQuantity.Text != "")
                {
                    anOrder = db.Orders.Find(Convert.ToInt32(textBoxOId.Text));
                    anOLine = db.Order_lines.Find(Convert.ToInt32(textBoxOId.Text), comboBoxProduct.Text);
                    anOLine.OrderQuantity = Convert.ToInt32(textBoxPOQuantity.Text);
                    anOLine.SubTotal = Convert.ToDouble(textBoxSubTotal.Text);
                    aProduct = db.Products.Find(comboBoxProduct.Text);
                    aProduct.Quantity = Convert.ToInt32(textBoxQoh.Text.Trim());
                    UpdateCustomerCredit(Convert.ToInt32(comboBoxCustomer.Text), Convert.ToDouble(textBoxCOCredit.Text));

                    db.Orders.AddOrUpdate(anOrder);
                    //OrderLineProductUpdate(anOrder.OrderId, comboBoxProduct.Text, aProduct.Quantity);
                    db.Order_lines.AddOrUpdate(anOLine);
                    db.SaveChanges();
                    MessageBox.Show("The orderline " + textBoxOId.Text + " was updated succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonListOrderLines_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Orderline not updated.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("You must inform the new quantity.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        } 
        private void listViewProduct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int index;
            index = listViewProduct.FocusedItem.Index;

            var listProduct = (from product in db.Products select product).ToList<Product>();

            maskedTextBoxISBN.Text = listProduct[index].ISBN;
            textBoxPTitle.Text = listProduct[index].Title;
            comboBoxCategory.Text = Convert.ToString(listProduct[index].CategoryId);
            textBoxPrice.Text = Convert.ToString(listProduct[index].Price);
            comboBoxYear.Text = Convert.ToString(listProduct[index].YearPublished);
            textBoxQuantity.Text = Convert.ToString(listProduct[index].Quantity);
            comboBoxSupplier.Text = Convert.ToString(listProduct[index].SuppliedId);

            maskedTextBoxISBN.Enabled = false;
        }
        private void buttonORUpdtOLine_Click(object sender, EventArgs e)
        {
            tabControlHiTech.SelectTab(tabPageOrder);
            if (listViewOrder.SelectedItems.Count > 0)
            {
                int index = listViewOrder.FocusedItem.Index;
                var listOrder = (from order in db.Orders select order).ToList<Order>();

                textBoxOId.Text = Convert.ToString(listOrder[index].OrderId);
                comboBoxEId.SelectedItem = listOrder[index].Employee.EmployeeId;
                dateTimePickerODate.Value = listOrder[index].OrderDate;
                comboBoxOBy.SelectedItem = listOrder[index].OrderBy;
                comboBoxCustomer.SelectedItem = listOrder[index].Customer.CustomerId;
                
                buttonListOrderLines_Click(sender, e);
                

            }
        }
        private void listViewSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = listViewSupplier.FocusedItem.Index;

            var listSupplier = (from supplier in db.Suppliers select supplier).ToList<Supplier>();

            textBoxSId.Text = Convert.ToString(listSupplier[index].SupplierId);
            textBoxSName.Text = listSupplier[index].Name;
            textBoxSId.Enabled = false;
        }
        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to delete the record?",
            "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                anOrder = db.Orders.Find(Convert.ToInt32(textBoxOOId.Text));
                var listOrderLine = db.Order_lines.Where(oLine => oLine.OrderId == anOrder.OrderId).ToList();
                foreach (var item in listOrderLine)
                {
                    db.Order_lines.Remove(item);
                }

                db.Orders.Remove(anOrder);
                db.SaveChanges();
                MessageBox.Show("Record Deleted");
                buttonListOReport_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Record NOT Deleted");
            }
        }
        private void textBoxPOQuantity_Leave(object sender, EventArgs e)
        {
            
            
            if (textBoxPOPrice.Text.Trim() != "" && textBoxCOCredit.Text.Trim() != "" && textBoxPOQuantity.Text.Trim() != "")
            {
                double units = Convert.ToDouble(textBoxPOQuantity.Text.Trim());
                double price = Convert.ToDouble(textBoxPOPrice.Text.Trim());
                double qoh = Convert.ToDouble(textBoxQoh.Text.Trim());

                if (units > qoh)
                {
                    DialogResult saleAll = MessageBox.Show("We only have " + qoh + " in our inventory\nDo you want to sale them all?.", 
                                                            "Question.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (saleAll == DialogResult.Yes)
                    {
                        textBoxPOQuantity.Focus();
                        textBoxPOQuantity.Text = Convert.ToString(qoh);
                        buttonAddOL.Focus();
                        
                    }
                    else
                    {
                        textBoxPOQuantity.Focus();
                        textBoxPOQuantity.Text = "";
                        buttonOClear_Click(sender, e);
                        textBoxPOQuantity.Enabled = true;
                    }
                }
                else
                {
                    double total = units * price;
                    double credit = Convert.ToDouble(textBoxCOCredit.Text.Trim());
                    textBoxSubTotal.Text = Convert.ToString(total);
                    textBoxCOCredit.Text = Convert.ToString(credit - total);
                    textBoxQoh.Text = Convert.ToString(qoh - units);
                    textBoxPOQuantity.Enabled = false;
                    if (textBoxTotal.Text == "")
                    {
                        textBoxTotal.Text = Convert.ToString(total);
                    }
                    buttonOClear.Enabled = true;
                    buttonAddOL.Enabled = true;
                }
            }
        }
        private void buttonOClear_Click(object sender, EventArgs e)
        {
            aCustomer = GetCustomer(aCustomer);
            double credit = aCustomer.Credit;
            aProduct = db.Products.Find(comboBoxProduct.Text);

            if (textBoxSubTotal.Text != "")
            {
                double subtotal = Convert.ToDouble(textBoxSubTotal.Text);
                int quantity = Convert.ToInt32(textBoxPOQuantity.Text);
                int qoh = Convert.ToInt32(textBoxQoh.Text);
                int clearQoh = quantity + qoh;
                textBoxQoh.Text = clearQoh.ToString();
            }
            else
            {
                textBoxSubTotal.Text = "";
                textBoxTotal.Text = "";
                textBoxQuantity.Text = "";
                textBoxPOQuantity.Text = "";
                
            }
            textBoxQoh.Text = Convert.ToString(aProduct.Quantity);
            textBoxCOCredit.Text = Convert.ToString(credit);
            buttonOClear.Enabled = false;
            textBoxPOQuantity.ReadOnly = false;
            textBoxPOQuantity.Text = "";
            textBoxPOQuantity.Enabled = true;
            textBoxSubTotal.Text = "";
        }
        private Customer GetCustomer(Customer customer)
        {

            DataRow drCustomer = dtCustomers.Rows.Find(Convert.ToInt32(comboBoxCustomer.Text));
            if (drCustomer != null)
            {
                customer.CustomerId = Convert.ToInt32(drCustomer["CustomerId"]);
                customer.Credit = Convert.ToInt32(drCustomer["Credit"]);
            }

            return customer;
        }

        private void comboBoxOOEmpId_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBoxOOEmpId.Text != "")
            {
                listEmployee = anEmployee.ListEmployee();
                anEmployee = listEmployee.Find(emp => emp.EmployeeId == Convert.ToInt32(comboBoxEId.Text));
                if (listEmployee.Count > 0)
                {
                    textBoxOEFN.Text = anEmployee.FirstName;
                    textBoxOOLN.Text = anEmployee.LastName;
                }

            }
        }

        private void SaveInvoice(int id)
        {
            string filePath = Application.StartupPath + @"\invoice"+ id + ".dat";
            var listOrder = db.Orders.Where(o => o.OrderId == id).ToList();
            var listOrderLines = db.Order_lines.Where(ol => ol.OrderId == id).ToList();
            var sum = db.Order_lines.Where(s => s.OrderId == id).Sum(s => s.SubTotal);

            foreach (Order item in listOrder)
            {
                using (StreamWriter sWriter = new StreamWriter(filePath, true))
                {
                    sWriter.WriteLine("Invoice number: - " + item.OrderId + "\n" +
                                      "Client Name: " + item.Customer.Name + "\n" +
                                      "Address: " + item.Customer.StreetNo + ", " +
                                      item.Customer.StreetName + " - " + item.Customer.PostalCode + "\n" +
                                      "Phone: " + item.Customer.PhoneNumber + " - " + "Fax: " + item.Customer.FaxNumber + "\n\n\n" +
                                      "-----------------------------------------------------------------------------------------\n" +
                                      "------------------------------------------ ITEMS -----------------------------------------" + "\n");
                    foreach (Order_lines ol in listOrderLines)
                    {
                        sWriter.WriteLine("Product: " + ol.ISBN + "\t" + ol.Title + "\t" + ol.Price + "\t" + ol.OrderQuantity + "\t" + ol.SubTotal + 
                            "\n-----------------------------------------------------------------------------------------");
                    }
                    sWriter.WriteLine("\t\t\t\t\t\t\t\t\tTotal: " + sum);
                }

            }

        }

        private void buttonSaveInvoice_Click(object sender, EventArgs e)
        {
            SaveInvoice(Convert.ToInt32(textBoxSearchInvoice.Text));
            MessageBox.Show("Invoice created.");
            buttonSaveInvoice.Enabled = false;
        }
        private void buttonNewOrder_Click(object sender, EventArgs e)
        {
            comboBoxCustomer.Items.Clear();
            comboBoxEId.Items.Clear();
            comboBoxProduct.Items.Clear();
            comboBoxOBy.SelectedIndex = -1;
            textBoxEFN.Text = "";
            textBoxELN.Text = "";
            listViewOrderLine.Items.Clear();
            textBoxCOCredit.Text = "";
            textBoxPOTitle.Text = "";
            textBoxPOPrice.Text = "";
            textBoxPOQuantity.Text = "";
            textBoxQoh.Text = "";
            textBoxSubTotal.Text = "";
            textBoxTotal.Text = "";
            textBoxCOName.Text = "";
            buttonAddOL.Enabled = false;
            


            var listCustomer = from customer in db.Customers select customer;
            foreach (var item in listCustomer)
            {
                comboBoxCustomer.Items.Add(item.CustomerId);
            }
            var listEmployees = from employee in db.Employees select employee;
            foreach (var item in listEmployees.Where(emp => emp.JobTitle == "Clerk"))
            {
                comboBoxEId.Items.Add(item.EmployeeId);
            }
            var listProduct = from product in db.Products select product;
            foreach (var item in listProduct)
            {
                comboBoxProduct.Items.Add(item.ISBN);
            }

            var nextval = db.Orders.Max(oid => oid.OrderId);
            textBoxOId.Text = Convert.ToString(nextval + 1);
        }
    }

}
