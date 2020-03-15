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
    public partial class TeacherNoticeForm : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public TeacherNoticeForm()
        {
            InitializeComponent();
        }

        private void TeacherNoticeForm_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            txtSearch.Text = txtID.Text = rtxtNotice.Text =txtTNSec.Text= "";//at first make them empty

            ddlTNCourse.DataSource = context.TeacherRegistrations.ToList(); //to show data from database
            ddlTNCourse.DisplayMember = "TRCourse";//to show data of "Title" column
            ddlTNCourse.SelectedItem = null;

           

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
            /*dgvDetails.ClearSelection();
            dgvDetails.Refresh();
            dgvDetails.ClearSelection();
            this.New();*/

            dgvDetails.Refresh();

            if (teacherNoticeInfos.Count > 0)
            {
                this.LoadData(teacherNoticeInfos.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void New()
        {
            //New button operation
            txtID.Text = rtxtNotice.Text = "";
            ddlTNCourse.SelectedItem = null;
            txtTNSec.Text = "";
            dgvDetails.ClearSelection();
        }

        private void LoadData(int id)
        {
            //this code snippet is for load user data upon clicking rows & shows on right side boxes
            var teacherNoticeInfo = context.TeacherNoticeInfoes.FirstOrDefault(d => d.ID == id);

            if (teacherNoticeInfo == null)
            {
                this.New();
                return;
            }

            txtID.Text = teacherNoticeInfo.ID.ToString();
            rtxtNotice.Text = teacherNoticeInfo.TNNotice;
            ddlTNCourse.SelectedItem = teacherNoticeInfo.TeacherRegistration;
            txtTNSec.Text = teacherNoticeInfo.TNSec.ToString();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //search
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

                var teacherNoticeInfo = context.TeacherNoticeInfoes.FirstOrDefault(d => d.ID == id);

                if (teacherNoticeInfo == null)
                {
                    this.Init();
                    return;
                }

                context.TeacherNoticeInfoes.Remove(teacherNoticeInfo); // this line cause execution of delete button on a row
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
            if (string.IsNullOrEmpty(rtxtNotice.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Notice");
                return;
            }
            if (string.IsNullOrEmpty(txtTNSec.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Section");
                return;
            }
            try
            {
                if (ddlTNCourse.SelectedItem == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Course");
                    return;
                }

                

                var course = (TeacherRegistration)ddlTNCourse.SelectedItem;
                

                TeacherNoticeInfo teacherNoticeInfo; // null reference,bcoz don't know whether to do new or update

                if (txtID.Text == "")
                {
                    teacherNoticeInfo = new TeacherNoticeInfo();
                    context.TeacherNoticeInfoes.Add(teacherNoticeInfo);
                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    teacherNoticeInfo = context.TeacherNoticeInfoes.FirstOrDefault(d => d.ID == id);

                    if (teacherNoticeInfo == null)
                    {
                        this.Init();
                        return;
                    }
                }

                teacherNoticeInfo.TNNotice = rtxtNotice.Text;
                teacherNoticeInfo.TNSec = txtTNSec.Text;

                teacherNoticeInfo.TNCourse = course.ID;
              
                context.SaveChanges();//for saving changes in database (e.g.,saving,updating)
                this.LoadDetails();//for showing whole data on leftside
                this.LoadData(teacherNoticeInfo.ID);//for showing current row data on right side

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
