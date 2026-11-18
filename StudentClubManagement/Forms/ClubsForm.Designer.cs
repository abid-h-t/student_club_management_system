namespace StudentClubManagement.Forms
{
    partial class ClubsForm
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
            this.lblClubId = new System.Windows.Forms.Label();
            this.txtClubId = new System.Windows.Forms.TextBox();
            this.lblClubName = new System.Windows.Forms.Label();
            this.txtClubName = new System.Windows.Forms.TextBox();
            this.lblFounded = new System.Windows.Forms.Label();
            this.dtpFounded = new System.Windows.Forms.DateTimePicker();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblAdvisor = new System.Windows.Forms.Label();
            this.txtAdvisor = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
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
            this.dgvClubs = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClubs)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.grpDetails);
            this.pnlContent.Controls.Add(this.pnlSearch);
            this.pnlContent.Controls.Add(this.dgvClubs);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 46);
            this.pnlContent.Size = new System.Drawing.Size(960, 576);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.TabIndex = 0;
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpDetails.Controls.Add(this.lblClubId);
            this.grpDetails.Controls.Add(this.txtClubId);
            this.grpDetails.Controls.Add(this.lblClubName);
            this.grpDetails.Controls.Add(this.txtClubName);
            this.grpDetails.Controls.Add(this.lblFounded);
            this.grpDetails.Controls.Add(this.dtpFounded);
            this.grpDetails.Controls.Add(this.lblCategory);
            this.grpDetails.Controls.Add(this.cboCategory);
            this.grpDetails.Controls.Add(this.lblAdvisor);
            this.grpDetails.Controls.Add(this.txtAdvisor);
            this.grpDetails.Controls.Add(this.chkIsActive);
            this.grpDetails.Controls.Add(this.lblDescription);
            this.grpDetails.Controls.Add(this.txtDescription);
            this.grpDetails.Controls.Add(this.btnAdd);
            this.grpDetails.Controls.Add(this.btnUpdate);
            this.grpDetails.Controls.Add(this.btnDelete);
            this.grpDetails.Controls.Add(this.btnClear);
            this.grpDetails.Location = new System.Drawing.Point(16, 12);
            this.grpDetails.Size = new System.Drawing.Size(928, 200);
            this.grpDetails.Text = "Club Details  (* = required)";
            this.grpDetails.TabStop = false;
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.TabIndex = 0;
            // 
            // lblClubId
            // 
            this.lblClubId.AutoSize = true;
            this.lblClubId.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblClubId.Location = new System.Drawing.Point(16, 31);
            this.lblClubId.Size = new System.Drawing.Size(53, 15);
            this.lblClubId.Text = "Club ID:";
            this.lblClubId.Name = "lblClubId";
            this.lblClubId.TabIndex = 0;
            // 
            // txtClubId
            // 
            this.txtClubId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtClubId.Location = new System.Drawing.Point(112, 28);
            this.txtClubId.ReadOnly = true;
            this.txtClubId.TabStop = false;
            this.txtClubId.Size = new System.Drawing.Size(100, 23);
            this.txtClubId.Name = "txtClubId";
            this.txtClubId.TabIndex = 1;
            // 
            // lblClubName
            // 
            this.lblClubName.AutoSize = true;
            this.lblClubName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblClubName.Location = new System.Drawing.Point(16, 63);
            this.lblClubName.Size = new System.Drawing.Size(78, 15);
            this.lblClubName.Text = "Club Name: *";
            this.lblClubName.Name = "lblClubName";
            this.lblClubName.TabIndex = 2;
            // 
            // txtClubName
            // 
            this.txtClubName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtClubName.Location = new System.Drawing.Point(112, 60);
            this.txtClubName.MaxLength = 100;
            this.txtClubName.Size = new System.Drawing.Size(250, 23);
            this.txtClubName.Name = "txtClubName";
            this.txtClubName.TabIndex = 3;
            // 
            // lblFounded
            // 
            this.lblFounded.AutoSize = true;
            this.lblFounded.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblFounded.Location = new System.Drawing.Point(16, 95);
            this.lblFounded.Size = new System.Drawing.Size(66, 15);
            this.lblFounded.Text = "Founded: *";
            this.lblFounded.Name = "lblFounded";
            this.lblFounded.TabIndex = 4;
            // 
            // dtpFounded
            // 
            this.dtpFounded.CustomFormat = "dd MMM yyyy";
            this.dtpFounded.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFounded.Location = new System.Drawing.Point(112, 92);
            this.dtpFounded.Size = new System.Drawing.Size(150, 23);
            this.dtpFounded.Name = "dtpFounded";
            this.dtpFounded.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCategory.Location = new System.Drawing.Point(392, 31);
            this.lblCategory.Size = new System.Drawing.Size(72, 15);
            this.lblCategory.Text = "Category: *";
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.TabIndex = 6;
            // 
            // cboCategory
            // 
            this.cboCategory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "Academic",
            "Arts",
            "Community Service",
            "Cultural",
            "Games",
            "Sports",
            "Technology"});
            this.cboCategory.Location = new System.Drawing.Point(480, 28);
            this.cboCategory.MaxLength = 50;
            this.cboCategory.Size = new System.Drawing.Size(260, 23);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.TabIndex = 7;
            // 
            // lblAdvisor
            // 
            this.lblAdvisor.AutoSize = true;
            this.lblAdvisor.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAdvisor.Location = new System.Drawing.Point(392, 63);
            this.lblAdvisor.Size = new System.Drawing.Size(53, 15);
            this.lblAdvisor.Text = "Advisor:";
            this.lblAdvisor.Name = "lblAdvisor";
            this.lblAdvisor.TabIndex = 8;
            // 
            // txtAdvisor
            // 
            this.txtAdvisor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAdvisor.Location = new System.Drawing.Point(480, 60);
            this.txtAdvisor.MaxLength = 100;
            this.txtAdvisor.Size = new System.Drawing.Size(260, 23);
            this.txtAdvisor.Name = "txtAdvisor";
            this.txtAdvisor.TabIndex = 9;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkIsActive.Location = new System.Drawing.Point(480, 94);
            this.chkIsActive.Size = new System.Drawing.Size(110, 19);
            this.chkIsActive.Text = "Club is active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.TabIndex = 10;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDescription.Location = new System.Drawing.Point(16, 127);
            this.lblDescription.Size = new System.Drawing.Size(78, 15);
            this.lblDescription.Text = "Description:";
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.TabIndex = 11;
            // 
            // txtDescription
            // 
            this.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescription.Location = new System.Drawing.Point(112, 124);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(628, 60);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.TabIndex = 12;
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
            this.btnAdd.TabIndex = 13;
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
            this.btnUpdate.TabIndex = 14;
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
            this.btnDelete.TabIndex = 15;
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
            this.btnClear.TabIndex = 16;
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
            this.pnlSearch.Location = new System.Drawing.Point(16, 222);
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
            this.lblCount.Text = "0 clubs";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblCount.Name = "lblCount";
            this.lblCount.TabIndex = 4;
            // 
            // dgvClubs
            // 
            this.dgvClubs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClubs.BackgroundColor = System.Drawing.Color.White;
            this.dgvClubs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClubs.Location = new System.Drawing.Point(16, 268);
            this.dgvClubs.Size = new System.Drawing.Size(928, 292);
            this.dgvClubs.Name = "dgvClubs";
            this.dgvClubs.TabIndex = 2;
            this.dgvClubs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClubs_CellClick);
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
            this.lblTitle.Size = new System.Drawing.Size(35, 25);
            this.lblTitle.Text = "Clubs";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            // 
            // ClubsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 622);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(976, 538);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clubs";
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ClubsForm";
            this.Load += new System.EventHandler(this.ClubsForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClubs)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblClubId;
        private System.Windows.Forms.TextBox txtClubId;
        private System.Windows.Forms.Label lblClubName;
        private System.Windows.Forms.TextBox txtClubName;
        private System.Windows.Forms.Label lblFounded;
        private System.Windows.Forms.DateTimePicker dtpFounded;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblAdvisor;
        private System.Windows.Forms.TextBox txtAdvisor;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
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
        private System.Windows.Forms.DataGridView dgvClubs;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
    }
}
