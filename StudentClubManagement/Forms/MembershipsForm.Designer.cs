namespace StudentClubManagement.Forms
{
    partial class MembershipsForm
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblClub = new System.Windows.Forms.Label();
            this.cboClub = new System.Windows.Forms.ComboBox();
            this.btnShowClub = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.grpAdd = new System.Windows.Forms.GroupBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cboStudent = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.lblAddHint = new System.Windows.Forms.Label();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblEditRole = new System.Windows.Forms.Label();
            this.cboEditRole = new System.Windows.Forms.ComboBox();
            this.lblEditStatus = new System.Windows.Forms.Label();
            this.cboEditStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateMember = new System.Windows.Forms.Button();
            this.btnRemoveMember = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.grpAdd.SuspendLayout();
            this.grpEdit.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlFilter);
            this.pnlContent.Controls.Add(this.lblGridTitle);
            this.pnlContent.Controls.Add(this.dgvMembers);
            this.pnlContent.Controls.Add(this.grpAdd);
            this.pnlContent.Controls.Add(this.grpEdit);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 46);
            this.pnlContent.Size = new System.Drawing.Size(1000, 616);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.Controls.Add(this.lblClub);
            this.pnlFilter.Controls.Add(this.cboClub);
            this.pnlFilter.Controls.Add(this.btnShowClub);
            this.pnlFilter.Controls.Add(this.lblSearch);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.btnShowAll);
            this.pnlFilter.Location = new System.Drawing.Point(16, 10);
            this.pnlFilter.Size = new System.Drawing.Size(968, 40);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.TabIndex = 0;
            // 
            // lblClub
            // 
            this.lblClub.AutoSize = true;
            this.lblClub.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblClub.Location = new System.Drawing.Point(0, 12);
            this.lblClub.Size = new System.Drawing.Size(35, 15);
            this.lblClub.Text = "Club:";
            this.lblClub.Name = "lblClub";
            this.lblClub.TabIndex = 0;
            // 
            // cboClub
            // 
            this.cboClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClub.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboClub.FormattingEnabled = true;
            this.cboClub.Location = new System.Drawing.Point(40, 9);
            this.cboClub.Size = new System.Drawing.Size(280, 23);
            this.cboClub.Name = "cboClub";
            this.cboClub.TabIndex = 1;
            this.cboClub.SelectedIndexChanged += new System.EventHandler(this.cboClub_SelectedIndexChanged);
            // 
            // btnShowClub
            // 
            this.btnShowClub.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnShowClub.Location = new System.Drawing.Point(328, 7);
            this.btnShowClub.Size = new System.Drawing.Size(124, 28);
            this.btnShowClub.Text = "Show &Members";
            this.btnShowClub.UseVisualStyleBackColor = true;
            this.btnShowClub.Name = "btnShowClub";
            this.btnShowClub.TabIndex = 2;
            this.btnShowClub.Click += new System.EventHandler(this.btnShowClub_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSearch.Location = new System.Drawing.Point(470, 12);
            this.lblSearch.Size = new System.Drawing.Size(109, 15);
            this.lblSearch.Text = "Search all clubs:";
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSearch.Location = new System.Drawing.Point(572, 9);
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Size = new System.Drawing.Size(160, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TabIndex = 4;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.Location = new System.Drawing.Point(740, 7);
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnShowAll.Location = new System.Drawing.Point(838, 7);
            this.btnShowAll.Size = new System.Drawing.Size(130, 28);
            this.btnShowAll.Text = "A&ll Memberships";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.TabIndex = 6;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblGridTitle.Location = new System.Drawing.Point(16, 60);
            this.lblGridTitle.Size = new System.Drawing.Size(968, 18);
            this.lblGridTitle.Text = "Members";
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.TabIndex = 1;
            // 
            // dgvMembers
            // 
            this.dgvMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(16, 82);
            this.dgvMembers.Size = new System.Drawing.Size(968, 340);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.TabIndex = 2;
            this.dgvMembers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembers_CellClick);
            // 
            // grpAdd
            // 
            this.grpAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpAdd.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpAdd.Controls.Add(this.lblStudent);
            this.grpAdd.Controls.Add(this.cboStudent);
            this.grpAdd.Controls.Add(this.lblRole);
            this.grpAdd.Controls.Add(this.cboRole);
            this.grpAdd.Controls.Add(this.btnAddMember);
            this.grpAdd.Controls.Add(this.lblAddHint);
            this.grpAdd.Location = new System.Drawing.Point(16, 434);
            this.grpAdd.Size = new System.Drawing.Size(476, 166);
            this.grpAdd.Text = "Add a student to the club chosen above";
            this.grpAdd.TabStop = false;
            this.grpAdd.Name = "grpAdd";
            this.grpAdd.TabIndex = 3;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStudent.Location = new System.Drawing.Point(16, 31);
            this.lblStudent.Size = new System.Drawing.Size(66, 15);
            this.lblStudent.Text = "Student: *";
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.TabIndex = 0;
            // 
            // cboStudent
            // 
            this.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboStudent.FormattingEnabled = true;
            this.cboStudent.Location = new System.Drawing.Point(90, 28);
            this.cboStudent.Size = new System.Drawing.Size(370, 23);
            this.cboStudent.Name = "cboStudent";
            this.cboStudent.TabIndex = 1;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblRole.Location = new System.Drawing.Point(16, 66);
            this.lblRole.Size = new System.Drawing.Size(47, 15);
            this.lblRole.Text = "Role: *";
            this.lblRole.Name = "lblRole";
            this.lblRole.TabIndex = 2;
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(90, 63);
            this.cboRole.Size = new System.Drawing.Size(180, 23);
            this.cboRole.Name = "cboRole";
            this.cboRole.TabIndex = 3;
            // 
            // btnAddMember
            // 
            this.btnAddMember.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAddMember.Location = new System.Drawing.Point(90, 104);
            this.btnAddMember.Size = new System.Drawing.Size(180, 34);
            this.btnAddMember.Text = "&Add to Club";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.TabIndex = 4;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // lblAddHint
            // 
            this.lblAddHint.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAddHint.Location = new System.Drawing.Point(284, 104);
            this.lblAddHint.Size = new System.Drawing.Size(176, 36);
            this.lblAddHint.Text = "New members join today with status Active.";
            this.lblAddHint.Name = "lblAddHint";
            this.lblAddHint.TabIndex = 5;
            // 
            // grpEdit
            // 
            this.grpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpEdit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpEdit.Controls.Add(this.lblSelected);
            this.grpEdit.Controls.Add(this.lblEditRole);
            this.grpEdit.Controls.Add(this.cboEditRole);
            this.grpEdit.Controls.Add(this.lblEditStatus);
            this.grpEdit.Controls.Add(this.cboEditStatus);
            this.grpEdit.Controls.Add(this.btnUpdateMember);
            this.grpEdit.Controls.Add(this.btnRemoveMember);
            this.grpEdit.Location = new System.Drawing.Point(508, 434);
            this.grpEdit.Size = new System.Drawing.Size(476, 166);
            this.grpEdit.Text = "Selected membership (click a row in the list)";
            this.grpEdit.TabStop = false;
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.TabIndex = 4;
            // 
            // lblSelected
            // 
            this.lblSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelected.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSelected.Location = new System.Drawing.Point(16, 22);
            this.lblSelected.Size = new System.Drawing.Size(444, 20);
            this.lblSelected.Text = "No membership selected";
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.TabIndex = 0;
            // 
            // lblEditRole
            // 
            this.lblEditRole.AutoSize = true;
            this.lblEditRole.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblEditRole.Location = new System.Drawing.Point(16, 62);
            this.lblEditRole.Size = new System.Drawing.Size(35, 15);
            this.lblEditRole.Text = "Role:";
            this.lblEditRole.Name = "lblEditRole";
            this.lblEditRole.TabIndex = 1;
            // 
            // cboEditRole
            // 
            this.cboEditRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEditRole.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboEditRole.FormattingEnabled = true;
            this.cboEditRole.Location = new System.Drawing.Point(90, 59);
            this.cboEditRole.Size = new System.Drawing.Size(180, 23);
            this.cboEditRole.Name = "cboEditRole";
            this.cboEditRole.TabIndex = 2;
            // 
            // lblEditStatus
            // 
            this.lblEditStatus.AutoSize = true;
            this.lblEditStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblEditStatus.Location = new System.Drawing.Point(16, 100);
            this.lblEditStatus.Size = new System.Drawing.Size(47, 15);
            this.lblEditStatus.Text = "Status:";
            this.lblEditStatus.Name = "lblEditStatus";
            this.lblEditStatus.TabIndex = 3;
            // 
            // cboEditStatus
            // 
            this.cboEditStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEditStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboEditStatus.FormattingEnabled = true;
            this.cboEditStatus.Location = new System.Drawing.Point(90, 97);
            this.cboEditStatus.Size = new System.Drawing.Size(180, 23);
            this.cboEditStatus.Name = "cboEditStatus";
            this.cboEditStatus.TabIndex = 4;
            // 
            // btnUpdateMember
            // 
            this.btnUpdateMember.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdateMember.Location = new System.Drawing.Point(290, 56);
            this.btnUpdateMember.Size = new System.Drawing.Size(170, 32);
            this.btnUpdateMember.Text = "Save &Role / Status";
            this.btnUpdateMember.UseVisualStyleBackColor = true;
            this.btnUpdateMember.Name = "btnUpdateMember";
            this.btnUpdateMember.TabIndex = 5;
            this.btnUpdateMember.Click += new System.EventHandler(this.btnUpdateMember_Click);
            // 
            // btnRemoveMember
            // 
            this.btnRemoveMember.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRemoveMember.Location = new System.Drawing.Point(290, 96);
            this.btnRemoveMember.Size = new System.Drawing.Size(170, 32);
            this.btnRemoveMember.Text = "Re&move from Club";
            this.btnRemoveMember.UseVisualStyleBackColor = true;
            this.btnRemoveMember.Name = "btnRemoveMember";
            this.btnRemoveMember.TabIndex = 6;
            this.btnRemoveMember.Click += new System.EventHandler(this.btnRemoveMember_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1000, 46);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(14, 14);
            this.lblTitle.Size = new System.Drawing.Size(72, 25);
            this.lblTitle.Text = "Memberships";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            // 
            // MembershipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 662);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1016, 578);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Memberships";
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "MembershipsForm";
            this.Load += new System.EventHandler(this.MembershipsForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.grpAdd.ResumeLayout(false);
            this.grpAdd.PerformLayout();
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblClub;
        private System.Windows.Forms.ComboBox cboClub;
        private System.Windows.Forms.Button btnShowClub;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.GroupBox grpAdd;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Label lblAddHint;
        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblEditRole;
        private System.Windows.Forms.ComboBox cboEditRole;
        private System.Windows.Forms.Label lblEditStatus;
        private System.Windows.Forms.ComboBox cboEditStatus;
        private System.Windows.Forms.Button btnUpdateMember;
        private System.Windows.Forms.Button btnRemoveMember;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
    }
}
