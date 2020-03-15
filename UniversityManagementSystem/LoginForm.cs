using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnivarsityManagementSystem
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            
            var uc = context.AdminInfoes.FirstOrDefault(u => u.AdminName == txtUserNM.Text && u.AdminPass == txtPass.Text);
            LoginHelper.AdminInfo = uc;
            if (uc == null)
            {
                //MessageBox.Show("Invalid Username or Password ");
                //return;

                var tc = context.TeacherInfoes.FirstOrDefault(u => u.TeacherName == txtUserNM.Text && u.TeacherPass == txtPass.Text);
                LoginHelper.TeacherInfo = tc;
                if (tc == null)
                {
                    //MessageBox.Show("Invalid Username or Password ");
                    //return;
                    var sc = context.StudentInfoes.FirstOrDefault(u => u.StudentName == txtUserNM.Text && u.StudentPass == txtPass.Text);
                    LoginHelper.StudentInfo = sc;
                    if (sc == null)
                    {
                        MessageBox.Show("Invalid Username or Password ");
                        return;
                    }

                    // LoginHelper.UserCredential = uc;

                    if (sc.UserType == "Student")
                    {
                        StudentForm sf = new StudentForm();
                        sf.Show();
                        this.Hide();
                    }
                }

                // LoginHelper.UserCredential = uc;

                else {
                    if (tc.UserType == "Teacher")
                {
                        TeacherForm tf = new TeacherForm();
                        tf.Show();
                        this.Hide();
                    }
                }

            }

            

            else
            {
                if (uc.UserType == "Admin")
                {
                    AdminForm mf = new AdminForm();
                    mf.Show();
                    this.Hide();
                }
            }
           
            
        

            
               
            
        }
    }
}
