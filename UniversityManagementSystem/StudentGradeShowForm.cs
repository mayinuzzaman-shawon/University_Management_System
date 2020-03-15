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
    public partial class StudentGradeShowForm : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public StudentGradeShowForm()
        {
            InitializeComponent();
        }

        private void StudentGradeShowForm_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            //var uc = context.UserInfoes.ToList();
            txtSearch.Text =  "";//at first make them empty
                                                                                           // cmbSec.SelectedItem = null;

            //cmbCourse.DataSource = context.TeacherRegistrations.ToList(); //to show data from database
            //cmbCourse.DisplayMember = "TRCourse";//to show data of "Title" column
            //cmbCourse.SelectedItem = null;


            //ddlName.DataSource = context.StudentInfoes.ToList();
            //ddlName.DisplayMember = "StudentName";
            //ddlName.SelectedItem = null;

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

            
        }

       

        

        

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            this.Init();
        }

        private void SearchBtn_Click_1(object sender, EventArgs e)
        {
            this.LoadDetails();
        }
    }
}
