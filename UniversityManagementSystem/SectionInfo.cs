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
    public partial class SectionInfo : Form
    {
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public SectionInfo()
        {
            InitializeComponent();
        }


        private void Init()
        {
            txtSearch.Text = txtID.Text = txtName.Text =  "";//at first make them empty
            listBox1.DataSource = context.Courses.ToList(); //to show data from database
            listBox1.DisplayMember = "course_name";
            listBox1.SelectedItem = null;

            this.LoadDetails();
        }

        private void LoadDetails()
        {
            var sections = context.Sections.ToList();

            if (txtSearch.Text != "")
            {

                sections = sections.Where(b => b.SectionName.Contains(txtSearch.Text) ).ToList();
            }

            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = sections.ToList();


            dgvDetails.Refresh();

            if (sections.Count > 0)
            {
                this.LoadData(sections.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void New()
        {
            //New button operation
            txtSearch.Text = txtID.Text = txtName.Text = "";
            listBox1.SelectedItem = null;
            dgvDetails.ClearSelection();
        }

        private void LoadData(int id)
        {
            //this code snippet is for load user data upon clicking rows & shows on right side boxes
            var section = context.Sections.FirstOrDefault(d => d.ID == id);

            if (section == null)
            {
                this.New();
                return;
            }

            txtID.Text = section.ID.ToString();
            txtName.Text = section.SectionName;
           
            listBox1.SelectedItem = section.Course;
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
                MetroFramework.MetroMessageBox.Show(this, "Invalid Name");
                return;
            }

            if (string.IsNullOrEmpty(listBox1.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Section Name");
                return;
            }

            try
            {
                if (listBox1.SelectedItem == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Course");
                    return;
                }

                var course = (Course)listBox1.SelectedItem;

                Section section; // null reference,bcoz don't know whether to do new or update

                if (txtID.Text == "")
                {
                    section = new Section();
                    context.Sections.Add(section);
                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    section = context.Sections.FirstOrDefault(d => d.ID == id);

                    if (section == null)
                    {
                        this.Init();
                        return;
                    }
                }

                section.SectionName = txtName.Text;
                section.CourseID = course.ID;

                context.SaveChanges();//for saving changes in database (e.g.,saving,updating)
                this.LoadDetails();//for showing whole data on left side
                this.LoadData(section.ID);//for showing current row data on right side

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
                string id = dgvDetails.Rows[e.RowIndex].Cells[0].Value.ToString(); //shows rows number upon clicking a row
                this.LoadData(Int32.Parse(id));
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
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

            var section = context.Sections.FirstOrDefault(d => d.ID == id);

            if (section == null)
            {
                this.Init();
                return;
            }

            context.Sections.Remove(section); // this line cause execution of delete button on a row
            context.SaveChanges(); // permanantly saved the changed data after deletion in database
            this.LoadDetails(); // for refresh on left side
        }

        private void SectionInfo_Load(object sender, EventArgs e)
        {
            this.Init();
        }
    }
}
