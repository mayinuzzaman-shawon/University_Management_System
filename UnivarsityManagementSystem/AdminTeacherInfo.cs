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
    public partial class AdminTeacherInfo : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public AdminTeacherInfo()
        {
            InitializeComponent();
        }

        private void AdminTeacherInfo_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            txtSearch.Text = txtID.Text = txtName.Text = txtPass.Text = txtEmail.Text = "";//at first make them empty
            dtpDOB.Text = DateTime.Now.ToString();
            ddlUType.SelectedItem = null;
            this.LoadDetails();
        }

        private void LoadDetails() //method for showing data on left side
        {
            var teacherInfos = context.TeacherInfoes.ToList(); //means select * from Departments & .ToList or executing query

            if (txtSearch.Text != "")
            {
                teacherInfos = teacherInfos.Where(d => d.TeacherName.Contains(txtSearch.Text)).ToList();
            }

            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = teacherInfos.ToList();


            dgvDetails.Refresh();

            if (teacherInfos.Count > 0)
            {
                this.LoadData(teacherInfos.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void New()
        {
            //New button operation
            txtSearch.Text = txtID.Text = txtName.Text = txtPass.Text = txtEmail.Text = "";
            dtpDOB.Text = DateTime.Now.ToString();
            ddlUType.SelectedItem = null;
            dgvDetails.ClearSelection();
        }

        private void LoadData(int id)
        {
            //this code snippet is for load user data upon clicking rows & shows on right side boxes
            var teacherInfo = context.TeacherInfoes.FirstOrDefault(d => d.ID == id);

            if (teacherInfo == null)
            {
                this.New();
                return;
            }

            txtID.Text = teacherInfo.ID.ToString();
            txtName.Text = teacherInfo.TeacherName;
            txtPass.Text = teacherInfo.TeacherPass.ToString();
            txtEmail.Text = teacherInfo.Email;
            dtpDOB.Text = teacherInfo.DOB.ToString();
            ddlUType.Text = teacherInfo.UserType.ToString();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.LoadDetails();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //delete operation
            if (txtID.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please, select a row first");
                return;
            }

            int id = Int32.Parse(txtID.Text);

            var userInfo = context.TeacherInfoes.FirstOrDefault(d => d.ID == id);

            if (userInfo == null)
            {
                this.Init();
                return;
            }

            context.TeacherInfoes.Remove(userInfo); // this line cause execution of delete button on a row
            context.SaveChanges(); // permanantly saved the changed data after deletion in database
            this.LoadDetails(); // for refresh on left side
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //refresh operation
            this.Init();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //save operation
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Name");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Email");
                return;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Password");
                return;
            }
            //if (string.IsNullOrEmpty(dtpDOB.Text))
            //{
            //    MetroFramework.MetroMessageBox.Show(this, "Invalid Email");
            //    return;
            //}
            if (string.IsNullOrEmpty(ddlUType.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Define User Type");
                return;
            }


            try
            {
                //int credit = Int32.Parse(txtCredit.Text);

                TeacherInfo teacher; // null reference,bcoz don't know whether to do new or update

                if (txtID.Text == "")
                {
                    teacher = new TeacherInfo();
                    context.TeacherInfoes.Add(teacher);
                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    teacher = context.TeacherInfoes.FirstOrDefault(d => d.ID == id);

                    if (teacher == null)
                    {
                        this.Init();
                        return;
                    }
                }

                
                teacher.TeacherName = txtName.Text;
                teacher.TeacherPass = txtPass.Text.ToString();
                teacher.Email = txtEmail.Text.ToString();
                teacher.UserType = ddlUType.SelectedItem.ToString();
                teacher.DOB = Convert.ToDateTime(dtpDOB.Text);
                


                context.SaveChanges();//for saving changes in database (e.g.,saving,updating)
                this.LoadDetails();//for showing whole data on right side
                this.LoadData(teacher.ID);//for showing current row data on right side

                dgvDetails.ClearSelection();

                //bcoz of following code snippet, both data and rows will be selected at the same time
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    string id = dgvDetails.Rows[i].Cells[0].Value.ToString();

                    if (id == txtID.Text)
                    {
                        dgvDetails.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
                //MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvDetails.Rows[e.RowIndex].Cells[0].Value.ToString(); //shows rows number upon clicking a row
                this.LoadData(Int32.Parse(id));
            }
        }
    }
}
