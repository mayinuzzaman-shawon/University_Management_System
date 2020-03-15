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
    public partial class StudentGrade : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public StudentGrade()
        {
            InitializeComponent();
        }

        private void StudentGrade_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
           //var uc = context.UserInfoes.ToList();
            txtSearch.Text  = txtID.Text= txtMid.Text=txtFinal.Text=txtTotal.Text="";//at first make them empty
           // cmbSec.SelectedItem = null;

            cmbCourse.DataSource = context.TeacherRegistrations.ToList(); //to show data from database
           cmbCourse.DisplayMember = "TRCourse";//to show data of "Title" column
            cmbCourse.SelectedItem = null;

          
            ddlName.DataSource = context.StudentInfoes.ToList();
            ddlName.DisplayMember = "StudentName";
            ddlName.SelectedItem = null;

            this.LoadDetails();
        }

        private void LoadDetails() //method for showing data on left side
        {
            var sectionStudents = context.SectionStudents.ToList(); //means select * from Departments & .ToList or executing query

            if (txtSearch.Text != "")
            {
              sectionStudents = sectionStudents.Where(d => d.SSNM.Contains(txtSearch.Text)).ToList();
            }

            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = sectionStudents.ToList();
            

            dgvDetails.Refresh();

            if (sectionStudents.Count > 0)
            {
                this.LoadData(sectionStudents.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void New()
        {
            //New button operation
            txtSearch.Text =txtID.Text= txtMid.Text = txtFinal.Text = txtTotal.Text = "";//at first make them empty
           // cmbSec.SelectedItem = null;

            cmbCourse.SelectedItem = null;
           
          
            ddlName.SelectedItem = null;
            dgvDetails.ClearSelection();
        }

        private void LoadData(int id)
        {
            //this code snippet is for load user data upon clicking rows & shows on right side boxes
            var section = context.SectionStudents.FirstOrDefault(d => d.ID == id);

            if (section == null)
            {
                this.New();
                return;
            }

           
            //cmbSec.SelectedItem = section.SectID.ToString();
            cmbCourse.SelectedItem = section.TeacherRegistration;
            txtID.Text = section.ID.ToString();
            txtMid.Text = section.MidTerm.ToString();
            txtFinal.Text = section.FinalTerm.ToString();
            txtTotal.Text = section.Total.ToString();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            this.LoadDetails();
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "Please, select a row first");
                    return;
                }

               int id = Int32.Parse(txtID.Text);

                var sectionStudent = context.SectionStudents.FirstOrDefault(d => d.ID == id);

                if (sectionStudent == null)
                {
                    this.Init();
                    return;
                }

                context.SectionStudents.Remove(sectionStudent); // this line cause execution of delete button on a row
                context.SaveChanges(); // permanantly saved the changed data after deletion in database
                this.LoadDetails(); // for refresh on left side
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            this.Init();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //save operation
            if (string.IsNullOrEmpty(txtTotal.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Total Marks");
                return;
            }
            if (string.IsNullOrEmpty(txtMid.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Mid Term Marks");
                return;
            }
            if (string.IsNullOrEmpty(txtFinal.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Final Term Marks");
                return;
            }

            try
            {
               // int id = Int32.Parse(txtID.Text);
                int mid = Int32.Parse(txtMid.Text);
                int final = Int32.Parse(txtFinal.Text);
                int total = Int32.Parse(txtTotal.Text);
                

                if (cmbCourse.SelectedItem == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Course");
                    return;
                }

                //if (cmbSec.SelectedItem == null)
                //{
                //    MetroFramework.MetroMessageBox.Show(this, "Invalid Section");
                //    return;
                //}

                if (txtID.Text == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid ID");
                    return;
                }

                if (ddlName.SelectedItem == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Name");
                    return;
                }

                //var  userID= (UserInfo)ddlID.SelectedItem;
                //var userName = (UserInfo)ddlName.SelectedItem;
               
                var courseid = (TeacherRegistration)cmbCourse.SelectedItem;

                var studentid = (StudentInfo)ddlName.SelectedItem;

                SectionStudent sectionStudent; // null reference,bcoz don't know whether to do new or update

                if (txtID.Text == "")
                {
                    sectionStudent = new SectionStudent();
                    context.SectionStudents.Add(sectionStudent);
                }
                else
                {
                    int ids = Int32.Parse(txtID.Text);
                    sectionStudent = context.SectionStudents.FirstOrDefault(d => d.ID == ids);

                    if (sectionStudent == null)
                    {
                        this.Init();
                        return;
                    }
                }

                //sectionStudent.ID = userID.ID;
                sectionStudent.SecStudentName = studentid.ID;
                //sectionStudent.sec
                sectionStudent.CouID = courseid.ID;
                sectionStudent.MidTerm = mid;
                sectionStudent.FinalTerm = final;
                sectionStudent.Total = total;
               // sectionStudent.SectID = cmbSec.SelectedItem.ToString();


                context.SaveChanges();//for saving changes in database (e.g.,saving,updating)
                this.LoadDetails();//for showing whole data on leftside
                this.LoadData(sectionStudent.ID);//for showing current row data on right side

                dgvDetails.ClearSelection();

                //bcoz of following code snippet, both data and rows will be selected at the same time
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    string ids = dgvDetails.Rows[i].Cells[0].Value.ToString();

                    if (ids == txtID.Text)
                    {
                        dgvDetails.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // MetroFramework.MetroMessageBox.Show(this, ex.Message);
                MessageBox.Show(ex.InnerException.ToString());
                //MessageBox.Show(ex.Message);
            }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }
    }
}
