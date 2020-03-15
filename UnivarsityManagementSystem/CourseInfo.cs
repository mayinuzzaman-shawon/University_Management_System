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
    public partial class CourseInfo : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public CourseInfo()
        {
            InitializeComponent();
        }

        private void CourseInfo_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            txtSearch.Text = txtID.Text = txtName.Text = txtCredit.Text = "";//at first make them empty
            this.LoadDetails();
        }

        private void LoadDetails() //method for showing data on left side
        {
            var courses = context.Courses.ToList(); //means select * from Departments & .ToList or executing query

            if (txtSearch.Text != "")
            {
                courses = courses.Where(d => d.course_name.Contains(txtSearch.Text)).ToList();
            }

            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = courses.ToList();
            /*dgvDetails.ClearSelection();
            dgvDetails.Refresh();
            dgvDetails.ClearSelection();
            this.New();*/

            dgvDetails.Refresh();

            if (courses.Count > 0)
            {
                this.LoadData(courses.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void New()
        {
            //New button operation
            txtID.Text = txtName.Text = txtCredit.Text = "";
            dgvDetails.ClearSelection();
        }

        private void LoadData(int id)
        {
            //this code snippet is for load user data upon clicking rows & shows on right side boxes
            var course = context.Courses.FirstOrDefault(d => d.ID == id);

            if (course == null)
            {
                this.New();
                return;
            }

            txtID.Text = course.ID.ToString();
            txtName.Text = course.course_name;
            txtCredit.Text = course.course_credit.ToString();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //new operation
            this.New();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //delete operation
            if (txtID.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please, select a row first");
                return;
            }

            int id = Int32.Parse(txtID.Text);

            var course = context.Courses.FirstOrDefault(d => d.ID == id);

            if (course == null)
            {
                this.Init();
                return;
            }

            context.Courses.Remove(course); // this line cause execution of delete button on a row
            context.SaveChanges(); // permanantly saved the changed data after deletion in database
            this.LoadDetails(); // for refresh on left side
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

            //refresh operation
            this.Init();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            //search
            this.LoadDetails();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            //save operation
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Course Name");
                return;
            }

            if (string.IsNullOrEmpty(txtCredit.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Credit");
                return;
            }

            try
            {
                int credit = Int32.Parse(txtCredit.Text);

                Course course; // null reference,bcoz don't know whether to do new or update

                if (txtID.Text == "")
                {
                    course = new Course();
                    context.Courses.Add(course);
                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    course = context.Courses.FirstOrDefault(d => d.ID == id);

                    if (course == null)
                    {
                        this.Init();
                        return;
                    }
                }

                course.course_name = txtName.Text;
                course.course_credit = credit;

                context.SaveChanges();//for saving changes in database (e.g.,saving,updating)
                this.LoadDetails();//for showing whole data on left side
                this.LoadData(course.ID);//for showing current row data on right side

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
                // MessageBox.Show(ex.Message);
               // MessageBox.Show(ex.InnerException.ToString());
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
