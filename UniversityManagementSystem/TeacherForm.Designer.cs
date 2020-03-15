﻿namespace UnivarsityManagementSystem
{
    partial class TeacherForm
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
            this.components = new System.ComponentModel.Container();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gradeUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offeredCoursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblTWelcome = new MetroFramework.Controls.MetroLabel();
            this.tlogoutBtn = new MetroFramework.Controls.MetroButton();
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
            this.gradeUploadToolStripMenuItem,
            this.noticeToolStripMenuItem,
            this.offeredCoursesToolStripMenuItem,
            this.courseRegistrationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(769, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gradeUploadToolStripMenuItem
            // 
            this.gradeUploadToolStripMenuItem.Name = "gradeUploadToolStripMenuItem";
            this.gradeUploadToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.gradeUploadToolStripMenuItem.Text = "Grade Upload";
            this.gradeUploadToolStripMenuItem.Click += new System.EventHandler(this.gradeUploadToolStripMenuItem_Click);
            // 
            // noticeToolStripMenuItem
            // 
            this.noticeToolStripMenuItem.Name = "noticeToolStripMenuItem";
            this.noticeToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.noticeToolStripMenuItem.Text = "Notice";
            this.noticeToolStripMenuItem.Click += new System.EventHandler(this.noticeToolStripMenuItem_Click);
            // 
            // offeredCoursesToolStripMenuItem
            // 
            this.offeredCoursesToolStripMenuItem.Name = "offeredCoursesToolStripMenuItem";
            this.offeredCoursesToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.offeredCoursesToolStripMenuItem.Text = "Offered Courses";
            this.offeredCoursesToolStripMenuItem.Click += new System.EventHandler(this.offeredCoursesToolStripMenuItem_Click);
            // 
            // courseRegistrationToolStripMenuItem
            // 
            this.courseRegistrationToolStripMenuItem.Name = "courseRegistrationToolStripMenuItem";
            this.courseRegistrationToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.courseRegistrationToolStripMenuItem.Text = "Course Registration";
            this.courseRegistrationToolStripMenuItem.Click += new System.EventHandler(this.courseRegistrationToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblTWelcome
            // 
            this.lblTWelcome.AutoSize = true;
            this.lblTWelcome.Location = new System.Drawing.Point(301, 25);
            this.lblTWelcome.Name = "lblTWelcome";
            this.lblTWelcome.Size = new System.Drawing.Size(64, 19);
            this.lblTWelcome.TabIndex = 3;
            this.lblTWelcome.Text = "Welcome";
            // 
            // tlogoutBtn
            // 
            this.tlogoutBtn.Location = new System.Drawing.Point(567, 25);
            this.tlogoutBtn.Name = "tlogoutBtn";
            this.tlogoutBtn.Size = new System.Drawing.Size(75, 23);
            this.tlogoutBtn.TabIndex = 4;
            this.tlogoutBtn.Text = "Log Out";
            this.tlogoutBtn.UseSelectable = true;
            this.tlogoutBtn.Click += new System.EventHandler(this.tlogoutBtn_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 454);
            this.Controls.Add(this.tlogoutBtn);
            this.Controls.Add(this.lblTWelcome);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "TeacherForm";
            this.Text = "Teacher Form";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gradeUploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noticeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem offeredCoursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseRegistrationToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel lblTWelcome;
        private MetroFramework.Controls.MetroButton tlogoutBtn;
    }
}