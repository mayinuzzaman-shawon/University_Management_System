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
    public partial class StudentOfferedCourseForm : Form
    {

        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public StudentOfferedCourseForm()
        {
            InitializeComponent();
        }

        private void StudentOfferedCourseForm_Load(object sender, EventArgs e)
        {
            this.Init();
        }



        private void Init()
        {
            txtSearch.Text =  "";//at first make them empty
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
            

            dgvDetails.Refresh();

            //if (courses.Count > 0)
            //{
            //    this.LoadData(courses.First().ID);
            //}
            //else
            //{
            //    this.New();
            //}
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //refresh button
            this.Init();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            //search
            this.LoadDetails();
        }

        //private void New()
        //{
        //    //New button operation
        //    txtID.Text = txtName.Text = txtCredit.Text = "";
        //    dgvDetails.ClearSelection();
        //}

        //private void LoadData(int id)
        //{
        //    //this code snippet is for load user data upon clicking rows & shows on right side boxes
        //    var course = context.Courses.FirstOrDefault(d => d.ID == id);

        //    if (course == null)
        //    {
        //        this.New();
        //        return;
        //    }

        //    txtID.Text = course.ID.ToString();
        //    txtName.Text = course.course_name;
        //    txtCredit.Text = course.course_credit.ToString();
        //}
    }
}
