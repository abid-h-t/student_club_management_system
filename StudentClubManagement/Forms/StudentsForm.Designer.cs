namespace StudentClubManagement.Forms
{
    partial class StudentsForm
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.lblStudentClubs = new System.Windows.Forms.Label();
            this.dgvStudentClubs = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentClubs)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.grpDetails);
            this.pnlContent.Controls.Add(this.pnlSearch);
            this.pnlContent.Controls.Add(this.dgvStudents);
            this.pnlContent.Controls.Add(this.lblStudentClubs);
            this.pnlContent.Controls.Add(this.dgvStudentClubs);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 46);
            this.pnlContent.Size = new System.Drawing.Size(960, 676);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.TabIndex = 0;
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpDetails.Controls.Add(this.lblStudentId);
            this.grpDetails.Controls.Add(this.txtStudentId);
            this.grpDetails.Controls.Add(this.lblFirstName);
            this.grpDetails.Controls.Add(this.txtFirstName);
            this.grpDetails.Controls.Add(this.lblLastName);
            this.grpDetails.Controls.Add(this.txtLastName);
            this.grpDetails.Controls.Add(this.lblYear);
            this.grpDetails.Controls.Add(this.nudYear);
            this.grpDetails.Controls.Add(this.lblEmail);
            this.grpDetails.Controls.Add(this.txtEmail);
            this.grpDetails.Controls.Add(this.lblPhone);
            this.grpDetails.Controls.Add(this.txtPhone);
            this.grpDetails.Controls.Add(this.lblDepartment);
            this.grpDetails.Controls.Add(this.cboDepartment);
            this.grpDetails.Controls.Add(this.btnAdd);
            this.grpDetails.Controls.Add(this.btnUpdate);
            this.grpDetails.Controls.Add(this.btnDelete);
            this.grpDetails.Controls.Add(this.btnClear);
            this.grpDetails.Location = new System.Drawing.Point(16, 12);
            this.grpDetails.Size = new System.Drawing.Size(928, 196);
            this.grpDetails.Text = "Student Details  (* = required)";
            this.grpDetails.TabStop = false;
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.TabIndex = 0;
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStudentId.Location = new System.Drawing.Point(16, 31);
            this.lblStudentId.Size = new System.Drawing.Size(72, 15);
            this.lblStudentId.Text = "Student ID:";
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.TabIndex = 0;
            // 
            // txtStudentId
            // 
            this.txtStudentId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStudentId.Location = new System.Drawing.Point(112, 28);
            this.txtStudentId.ReadOnly = true;
            this.txtStudentId.TabStop = false;
            this.txtStudentId.Size = new System.Drawing.Size(100, 23);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblFirstName.Location = new System.Drawing.Point(16, 63);
            this.lblFirstName.Size = new System.Drawing.Size(84, 15);
            this.lblFirstName.Text = "First Name: *";
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            this.txtFirstName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFirstName.Location = new System.Drawing.Point(112, 60);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Size = new System.Drawing.Size(250, 23);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblLastName.Location = new System.Drawing.Point(16, 95);
            this.lblLastName.Size = new System.Drawing.Size(78, 15);
            this.lblLastName.Text = "Last Name: *";
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLastName.Location = new System.Drawing.Point(112, 92);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Size = new System.Drawing.Size(250, 23);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.TabIndex = 5;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblYear.Location = new System.Drawing.Point(16, 127);
            this.lblYear.Size = new System.Drawing.Size(103, 15);
            this.lblYear.Text = "Year of Study: *";
            this.lblYear.Name = "lblYear";
            this.lblYear.TabIndex = 6;
            // 
            // nudYear
            // 
            this.nudYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nudYear.Location = new System.Drawing.Point(112, 124);
            this.nudYear.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudYear.Size = new System.Drawing.Size(70, 23);
            this.nudYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblEmail.Location = new System.Drawing.Point(392, 31);
            this.lblEmail.Size = new System.Drawing.Size(53, 15);
            this.lblEmail.Text = "Email: *";
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEmail.Location = new System.Drawing.Point(480, 28);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Size = new System.Drawing.Size(260, 23);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TabIndex = 9;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPhone.Location = new System.Drawing.Point(392, 63);
            this.lblPhone.Size = new System.Drawing.Size(41, 15);
            this.lblPhone.Text = "Phone:";
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.TabIndex = 10;
            // 
            // txtPhone
            // 
            this.txtPhone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPhone.Location = new System.Drawing.Point(480, 60);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Size = new System.Drawing.Size(260, 23);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.TabIndex = 11;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDepartment.Location = new System.Drawing.Point(392, 95);
            this.lblDepartment.Size = new System.Drawing.Size(84, 15);
            this.lblDepartment.Text = "Department: *";
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.TabIndex = 12;
            // 
            // cboDepartment
            // 
            this.cboDepartment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Items.AddRange(new object[] {
            "Business Administration",
            "Computer Science",
            "Electrical Engineering",
            "English Literature",
            "Fine Arts",
            "Mathematics",
            "Mechanical Engineering",
            "Physics"});
            this.cboDepartment.Location = new System.Drawing.Point(480, 92);
            this.cboDepartment.MaxLength = 100;
            this.cboDepartment.Size = new System.Drawing.Size(260, 23);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.Location = new System.Drawing.Point(772, 24);
            this.btnAdd.Size = new System.Drawing.Size(140, 34);
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdate.Location = new System.Drawing.Point(772, 64);
            this.btnUpdate.Size = new System.Drawing.Size(140, 34);
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnDelete.Location = new System.Drawing.Point(772, 104);
            this.btnDelete.Size = new System.Drawing.Size(140, 34);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnClear.Location = new System.Drawing.Point(772, 144);
            this.btnClear.Size = new System.Drawing.Size(140, 34);
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 17;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnShowAll);
            this.pnlSearch.Controls.Add(this.lblCount);
            this.pnlSearch.Location = new System.Drawing.Point(16, 218);
            this.pnlSearch.Size = new System.Drawing.Size(928, 40);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSearch.Location = new System.Drawing.Point(0, 12);
            this.lblSearch.Size = new System.Drawing.Size(47, 15);
            this.lblSearch.Text = "Search:";
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSearch.Location = new System.Drawing.Point(56, 9);
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.Location = new System.Drawing.Point(366, 7);
            this.btnSearch.Size = new System.Drawing.Size(96, 28);
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnShowAll.Location = new System.Drawing.Point(470, 7);
            this.btnShowAll.Size = new System.Drawing.Size(96, 28);
            this.btnShowAll.Text = "Show A&ll";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCount.Location = new System.Drawing.Point(628, 12);
            this.lblCount.Size = new System.Drawing.Size(300, 15);
            this.lblCount.Text = "0 students";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblCount.Name = "lblCount";
            this.lblCount.TabIndex = 4;
            // 
            // dgvStudents
            // 
            this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(16, 264);
            this.dgvStudents.Size = new System.Drawing.Size(928, 240);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.TabIndex = 2;
            this.dgvStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellClick);
            // 
            // lblStudentClubs
            // 
            this.lblStudentClubs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStudentClubs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudentClubs.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStudentClubs.Location = new System.Drawing.Point(16, 516);
            this.lblStudentClubs.Size = new System.Drawing.Size(928, 18);
            this.lblStudentClubs.Text = "Club memberships of the selected student:";
            this.lblStudentClubs.Name = "lblStudentClubs";
            this.lblStudentClubs.TabIndex = 3;
            // 
            // dgvStudentClubs
            // 
            this.dgvStudentClubs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudentClubs.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudentClubs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentClubs.Location = new System.Drawing.Point(16, 540);
            this.dgvStudentClubs.Size = new System.Drawing.Size(928, 120);
            this.dgvStudentClubs.TabStop = false;
            this.dgvStudentClubs.Name = "dgvStudentClubs";
            this.dgvStudentClubs.TabIndex = 4;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(960, 46);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(14, 14);
            this.lblTitle.Size = new System.Drawing.Size(53, 25);
            this.lblTitle.Text = "Students";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            // 
            // StudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 722);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(976, 658);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Students";
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "StudentsForm";
            this.Load += new System.EventHandler(this.StudentsForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentClubs)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Label lblStudentClubs;
        private System.Windows.Forms.DataGridView dgvStudentClubs;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
    }
}
