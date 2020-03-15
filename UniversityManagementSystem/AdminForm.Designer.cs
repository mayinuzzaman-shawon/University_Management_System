namespace UnivarsityManagementSystem
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAWelcome = new MetroFramework.Controls.MetroLabel();
            this.alogoutBtn = new MetroFramework.Controls.MetroButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 84);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(769, 350);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminInformationToolStripMenuItem,
            this.teacherInformationToolStripMenuItem,
            this.studentInformationToolStripMenuItem,
            this.courseInformationToolStripMenuItem,
            this.sectionInformationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(769, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminInformationToolStripMenuItem
            // 
            this.adminInformationToolStripMenuItem.Name = "adminInformationToolStripMenuItem";
            this.adminInformationToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.adminInformationToolStripMenuItem.Text = "Admin Information";
            this.adminInformationToolStripMenuItem.Click += new System.EventHandler(this.adminInformationToolStripMenuItem_Click);
            // 
            // teacherInformationToolStripMenuItem
            // 
            this.teacherInformationToolStripMenuItem.Name = "teacherInformationToolStripMenuItem";
            this.teacherInformationToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.teacherInformationToolStripMenuItem.Text = "Teacher Information";
            this.teacherInformationToolStripMenuItem.Click += new System.EventHandler(this.teacherInformationToolStripMenuItem_Click);
            // 
            // studentInformationToolStripMenuItem
            // 
            this.studentInformationToolStripMenuItem.Name = "studentInformationToolStripMenuItem";
            this.studentInformationToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.studentInformationToolStripMenuItem.Text = "Student Information";
            this.studentInformationToolStripMenuItem.Click += new System.EventHandler(this.studentInformationToolStripMenuItem_Click);
            // 
            // courseInformationToolStripMenuItem
            // 
            this.courseInformationToolStripMenuItem.Name = "courseInformationToolStripMenuItem";
            this.courseInformationToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.courseInformationToolStripMenuItem.Text = "Course Information";
            this.courseInformationToolStripMenuItem.Click += new System.EventHandler(this.courseInformationToolStripMenuItem_Click);
            // 
            // sectionInformationToolStripMenuItem
            // 
            this.sectionInformationToolStripMenuItem.Name = "sectionInformationToolStripMenuItem";
            this.sectionInformationToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.sectionInformationToolStripMenuItem.Text = "Section Information";
            this.sectionInformationToolStripMenuItem.Click += new System.EventHandler(this.sectionInformationToolStripMenuItem_Click);
            // 
            // lblAWelcome
            // 
            this.lblAWelcome.AutoSize = true;
            this.lblAWelcome.Location = new System.Drawing.Point(317, 21);
            this.lblAWelcome.Name = "lblAWelcome";
            this.lblAWelcome.Size = new System.Drawing.Size(64, 19);
            this.lblAWelcome.TabIndex = 3;
            this.lblAWelcome.Text = "Welcome";
            // 
            // alogoutBtn
            // 
            this.alogoutBtn.Location = new System.Drawing.Point(587, 21);
            this.alogoutBtn.Name = "alogoutBtn";
            this.alogoutBtn.Size = new System.Drawing.Size(75, 23);
            this.alogoutBtn.TabIndex = 4;
            this.alogoutBtn.Text = "Log Out";
            this.alogoutBtn.UseSelectable = true;
            this.alogoutBtn.Click += new System.EventHandler(this.alogoutBtn_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 454);
            this.Controls.Add(this.alogoutBtn);
            this.Controls.Add(this.lblAWelcome);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "Admin Form";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teacherInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionInformationToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel lblAWelcome;
        private MetroFramework.Controls.MetroButton alogoutBtn;
    }
}