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
    public partial class StudentNoticeForm : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();


        public StudentNoticeForm()
        {
            InitializeComponent();
        }

        private void StudentNoticeForm_Load(object sender, EventArgs e)
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
            var teacherNoticeInfos = context.TeacherNoticeInfoes.ToList(); //means select * from Departments & .ToList or executing query

            if (txtSearch.Text != "")
            {
                teacherNoticeInfos = teacherNoticeInfos.Where(d => d.TNCourseNM.Contains(txtSearch.Text)).ToList();
            }

            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = teacherNoticeInfos.ToList();
           

            dgvDetails.Refresh();

           
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //search
            this.LoadDetails();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            this.Init();
        }
    }
}
