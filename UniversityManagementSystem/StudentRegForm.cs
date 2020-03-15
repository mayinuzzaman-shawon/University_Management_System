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
    public partial class StudentRegForm : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public StudentRegForm()
        {
            InitializeComponent();
        }

        private void StudentRegForm_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            txtSearch.Text = txtID.Text = "";//at first make them empty

            ddlSRCourse.DataSource = context.Courses.ToList(); //to show data from database
            ddlSRCourse.DisplayMember = "course_name";
            ddlSRCourse.SelectedItem = null;

            ddlSRSec.DataSource = context.Sections.ToList(); //to show data from database
            ddlSRSec.DisplayMember = "SectionName";
            ddlSRSec.SelectedItem = null;

            this.LoadDetails();
        }

        private void LoadDetails() //method for showing data on left side
        {
            var studentRegistrations = context.StudentRegistrations.ToList(); //means select * from Departments & .ToList or executing query

            if (txtSearch.Text != "")
            {
                 studentRegistrations = studentRegistrations.Where(d => d.SRCourseNM.Contains(txtSearch.Text)).ToList();
            }

            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = studentRegistrations.ToList();



            dgvDetails.Refresh();

            if (studentRegistrations.Count > 0)
            {
                this.LoadData(studentRegistrations.First().ID);
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
            ddlSRCourse.SelectedItem = null;
            ddlSRSec.SelectedItem = null;
            dgvDetails.ClearSelection();
        }

        private void LoadData(int id)
        {
            //this code snippet is for load user data upon clicking rows & shows on right side boxes
            var studentRegistration = context.StudentRegistrations.FirstOrDefault(d => d.ID == id);

            if (studentRegistration == null)
            {
                this.New();
                return;
            }

            txtID.Text = studentRegistration.ID.ToString();

            ddlSRCourse.SelectedItem = studentRegistration.Course;
            ddlSRSec.SelectedItem = studentRegistration.Section;
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

                var studentRegistration = context.StudentRegistrations.FirstOrDefault(d => d.ID == id);

                if (studentRegistration == null)
                {
                    this.Init();
                    return;
                }

                context.StudentRegistrations.Remove(studentRegistration); // this line cause execution of delete button on a row
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
            try
            {
                if (ddlSRCourse.SelectedItem == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Course");
                    return;
                }

                if (ddlSRSec.SelectedItem == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Section");
                    return;
                }

                var course = (Course)ddlSRCourse.SelectedItem;

                var section = (Section)ddlSRSec.SelectedItem;

                StudentRegistration student; // null reference,bcoz don't know whether to do new or update

                if (txtID.Text == "")
                {
                    student = new StudentRegistration();
                    context.StudentRegistrations.Add(student);
                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    student = context.StudentRegistrations.FirstOrDefault(d => d.ID == id);

                    if (student == null)
                    {
                        this.Init();
                        return;
                    }
                }


                student.SRCourse = course.ID;
                student.SRSec = section.ID;

                context.SaveChanges();//for saving changes in database (e.g.,saving,updating)
                this.LoadDetails();//for showing whole data on leftside
                this.LoadData(student.ID);//for showing current row data on right side

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
