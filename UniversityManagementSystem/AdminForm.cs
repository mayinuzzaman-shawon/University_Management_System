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
    public partial class AdminForm : MetroFramework.Forms.MetroForm
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            lblAWelcome.Text = "Welcome, " + LoginHelper.AdminInfo.AdminName;
        }

        private void adminInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminInformation mf = new AdminInformation();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void teacherInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminTeacherInfo mf = new AdminTeacherInfo();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void studentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminStudentInfo mf = new AdminStudentInfo();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void courseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseInfo mf = new CourseInfo();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void sectionInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SectionInfo mf = new SectionInfo();
            mf.TopLevel = false;
            mf.AutoScroll = true;
            mf.FormBorderStyle = FormBorderStyle.None;
            mf.Dock = DockStyle.Fill;
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(mf);
            mf.Show();
        }

        private void alogoutBtn_Click(object sender, EventArgs e)
        {
            LoginHelper.AdminInfo = null;
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }
    }
}
