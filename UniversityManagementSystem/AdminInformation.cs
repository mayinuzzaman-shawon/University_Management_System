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
    public partial class AdminInformation : Form
    {

        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        public AdminInformation()
        {
            InitializeComponent();
        }

        private void AdminInformation_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            txtSearch.Text = txtID.Text = txtName.Text = txtPass.Text = txtEmail.Text = "";//at first make them empty
            dtpDOB.Text = DateTime.Now.ToString();
            ddlUType.SelectedItem = null;
            this.LoadDetails();
        }

        private void LoadDetails() //method for showing data on left side
        {
            var adminInfos = context.AdminInfoes.ToList(); //means select * from Departments & .ToList or executing query

            if (txtSearch.Text != "")
            {
                adminInfos = adminInfos.Where(d => d.AdminName.Contains(txtSearch.Text)).ToList();
            }

            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = adminInfos.ToList();


            dgvDetails.Refresh();

            if (adminInfos.Count > 0)
            {
                this.LoadData(adminInfos.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void New()
        {
            //New button operation
            txtSearch.Text = txtID.Text = txtName.Text = txtPass.Text = txtEmail.Text = "";
            dtpDOB.Text = DateTime.Now.ToString();
            ddlUType.SelectedItem = null;
            dgvDetails.ClearSelection();
        }

        private void LoadData(int id)
        {
            //this code snippet is for load user data upon clicking rows & shows on right side boxes
            var adminInfo = context.AdminInfoes.FirstOrDefault(d => d.ID == id);

            if (adminInfo == null)
            {
                this.New();
                return;
            }

            txtID.Text = adminInfo.ID.ToString();
            txtName.Text = adminInfo.AdminName;
            txtPass.Text = adminInfo.AdminPass.ToString();
            txtEmail.Text = adminInfo.Email;
            dtpDOB.Text = adminInfo.DOB.ToString();
            ddlUType.Text = adminInfo.UserType.ToString();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.LoadDetails();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //delete operation
            if (txtID.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please, select a row first");
                return;
            }

            int id = Int32.Parse(txtID.Text);

            var adminInfo = context.AdminInfoes.FirstOrDefault(d => d.ID == id);

            if (adminInfo == null)
            {
                this.Init();
                return;
            }

            context.AdminInfoes.Remove(adminInfo); // this line cause execution of delete button on a row
            context.SaveChanges(); // permanantly saved the changed data after deletion in database
            this.LoadDetails(); // for refresh on left side
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //refresh operation
            this.Init();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //save operation
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Name");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Email");
                return;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Password");
                return;
            }
            //if (string.IsNullOrEmpty(dtpDOB.Text))
            //{
            //    MetroFramework.MetroMessageBox.Show(this, "Invalid Email");
            //    return;
            //}
            if (string.IsNullOrEmpty(ddlUType.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Define a User Type");
                return;
            }


            try
            {
                //int credit = Int32.Parse(txtCredit.Text);

                AdminInfo admin; // null reference,bcoz don't know whether to do new or update

                if (txtID.Text == "")
                {
                    admin = new AdminInfo();
                    context.AdminInfoes.Add(admin);
                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    admin = context.AdminInfoes.FirstOrDefault(d => d.ID == id);

                    if (admin == null)
                    {
                        this.Init();
                        return;
                    }
                }


                admin.AdminName = txtName.Text;
                admin.AdminPass = txtPass.Text.ToString();
                admin.Email = txtEmail.Text.ToString();
                admin.UserType = ddlUType.SelectedItem.ToString();
                admin.DOB = Convert.ToDateTime(dtpDOB.Text);



                context.SaveChanges();//for saving changes in database (e.g.,saving,updating)
                this.LoadDetails();//for showing whole data on right side
                this.LoadData(admin.ID);//for showing current row data on right side

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
    }
}
