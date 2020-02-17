using Hi_Tech_System.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hi_Tech_System.GUI
{
    public partial class LoginForm : Form
    {
        int count = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            User anUser = new User();
            int user = 0;
            

            if (anUser.ValidUser(textBoxName.Text, textBoxPassword.Text, "MIS Manager"))
            {
                user = 1;
                OpenFormApplication(user);

            }
            else if (anUser.ValidUser(textBoxName.Text, textBoxPassword.Text, "Sales Manager"))
            {
                user = 2;
                OpenFormApplication(user);
            }
            else if (anUser.ValidUser(textBoxName.Text, textBoxPassword.Text, "Inventory Controller"))
            {
                user = 3;
                OpenFormApplication(user);
            }
            else if (anUser.ValidUser(textBoxName.Text, textBoxPassword.Text, "Clerk"))
            {
                user = 4;
                OpenFormApplication(user);
            }
            else if (anUser.ValidUser(textBoxName.Text, textBoxPassword.Text, "Accountant"))
            {
                user = 5;
                OpenFormApplication(user);
            }
            else if (anUser.ValidUser(textBoxName.Text, textBoxPassword.Text, "God"))
            {
                user = 6;
                OpenFormApplication(user);
            }
            else
            {
                count++;
                if (count > 2)
                {
                    MessageBox.Show("Please, contact the administrator.", "Login Failed!");
                    textBoxName.Text = " ";
                    textBoxPassword.Text = " ";
                    textBoxName.Focus();
                    return;

                }
                MessageBox.Show("User name or password wrong!");
                textBoxName.Text = " ";
                textBoxPassword.Text = " ";
                textBoxName.Focus();


            }
        }

        private void OpenFormApplication(int user)
        {
            HiTechSystemForm myForm = new HiTechSystemForm(user);
            Hide();
            myForm.ShowDialog();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult cancel = MessageBox.Show("Do you want to cancel?", "CANCEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cancel == DialogResult.Yes)
            {
                MessageBox.Show("Thank You!");
                Close();
            }
        }

        
    }
}
