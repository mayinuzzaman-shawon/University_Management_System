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
    public partial class TeacherRegForm : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public TeacherRegForm()
        {
            InitializeComponent();
        }

        private void TeacherRegForm_Load(object sender, EventArgs e)
        {
            this.Init();
        }


        private void Init()
        {
            txtSearch.Text = txtID.Text= "";//at first make them empty

            ddlTRCourse.DataSource = context.Courses.ToList(); //to show data from database
            ddlTRCourse.DisplayMember = "course_name";
            ddlTRCourse.SelectedItem = null;

            ddlTRSec.DataSource = context.Sections.ToList(); //to show data from database
            ddlTRSec.DisplayMember = "SectionName";
            ddlTRSec.SelectedItem = null;

            this.LoadDetails();
        }

        private void LoadDetails() //method for showing data on left side
        {
            var teacherRegistrations = context.TeacherRegistrations.ToList(); //means select * from Departments & .ToList or executing query

            if (txtSearch.Text != "")
            {
                teacherRegistrations = teacherRegistrations.Where(d => d.TRCourse.Contains(txtSearch.Text)).ToList();
            }

            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = teacherRegistrations.ToList();
          
            

            dgvDetails.Refresh();

            if (teacherRegistrations.Count > 0)
            {
                this.LoadData(teacherRegistrations.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void New()
        {
            //New button operation
            txtID.Text = "";
            ddlTRCourse.SelectedItem = null;
            ddlTRSec.SelectedItem = null;
            dgvDetails.ClearSelection();
        }

        private void LoadData(int id)
        {
            //this code snippet is for load user data upon clicking rows & shows on right side boxes
            var teacherRegistration = context.TeacherRegistrations.FirstOrDefault(d => d.ID == id);

            if (teacherRegistration == null)
            {
                this.New();
                return;
            }

            txtID.Text = teacherRegistration.ID.ToString();

            //ddlTRCourse.SelectedItem = null;
            ddlTRCourse.SelectedItem = teacherRegistration.Course;
            ddlTRSec.SelectedItem = teacherRegistration.Section;
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

                var teacherRegistration = context.TeacherRegistrations.FirstOrDefault(d => d.ID == id);

                if (teacherRegistration == null)
                {
                    this.Init();
                    return;
                }

                context.TeacherRegistrations.Remove(teacherRegistration); // this line cause execution of delete button on a row
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            this.LoadDetails();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            //save operation
            //if (string.IsNullOrEmpty(ddlTRCourse.SelectedItem.ToString()))
            //{
            //    MetroFramework.MetroMessageBox.Show(this, "Invalid Course");
            //    return;
            //}

            try
            {
                if (ddlTRCourse.SelectedItem == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Course");
                    return;
                }

                if (ddlTRSec.SelectedItem == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Section");
                    return;
                }

                var course = (Course)ddlTRCourse.SelectedItem;

                var section = (Section)ddlTRSec.SelectedItem;

                TeacherRegistration teacher; // null reference,bcoz don't know whether to do new or update

                if (txtID.Text == "")
                {
                    teacher = new TeacherRegistration();
                    context.TeacherRegistrations.Add(teacher);
                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    teacher = context.TeacherRegistrations.FirstOrDefault(d => d.ID == id);

                    if (teacher == null)
                    {
                        this.Init();
                        return;
                    }
                }

              
                teacher.TRCourseID = course.ID;
                teacher.TRSecID = section.ID;

                context.SaveChanges();//for saving changes in database (e.g.,saving,updating)
                this.LoadDetails();//for showing whole data on leftside
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
                string id = dgvDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }
    }
}
