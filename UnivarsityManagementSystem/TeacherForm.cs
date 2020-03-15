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
    public partial class TeacherForm : MetroFramework.Forms.MetroForm
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            lblTWelcome.Text = "Welcome, " + LoginHelper.TeacherInfo.TeacherName;
        }

        private void gradeUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentGrade mf = new StudentGrade();
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
            TeacherNoticeForm mf = new TeacherNoticeForm();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void offeredCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherOfferedCoursesForm mf = new TeacherOfferedCoursesForm();
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
            TeacherRegForm mf = new TeacherRegForm();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void tlogoutBtn_Click(object sender, EventArgs e)
        {

            LoginHelper.TeacherInfo = null;
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }
    }
}
