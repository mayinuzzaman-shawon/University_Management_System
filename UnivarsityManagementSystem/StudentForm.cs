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
    public partial class StudentForm : MetroFramework.Forms.MetroForm
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void gradeUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentGradeShowForm mf = new StudentGradeShowForm();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void noticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentNoticeForm mf = new StudentNoticeForm();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void courseRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentOfferedCourseForm mf = new StudentOfferedCourseForm();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentRegForm mf = new StudentRegForm();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            lblSWelcome.Text = "Welcome, " + LoginHelper.StudentInfo.StudentName;
        }

       

        private void slogoutBtn_Click(object sender, EventArgs e)
        {
            LoginHelper.StudentInfo = null;
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }
    }
}
