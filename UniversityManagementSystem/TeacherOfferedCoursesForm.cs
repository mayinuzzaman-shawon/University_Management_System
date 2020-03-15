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
    public partial class TeacherOfferedCoursesForm : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public TeacherOfferedCoursesForm()
        {
            InitializeComponent();
        }

        private void TeacherOfferedCoursesForm_Load(object sender, EventArgs e)
        {
            this.Init();
        }


        private void Init()
        {
            txtSearch.Text = "";//at first make them empty
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

           
        }

       
       

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            //search
            this.LoadDetails();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //refresh button
            this.Init();
        }
    }
}
