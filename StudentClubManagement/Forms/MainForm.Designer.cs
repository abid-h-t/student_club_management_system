namespace StudentClubManagement.Forms
{
    partial class MainForm
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
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.pnlStudents = new System.Windows.Forms.Panel();
            this.lblStudentsValue = new System.Windows.Forms.Label();
            this.lblStudentsCaption = new System.Windows.Forms.Label();
            this.pnlClubs = new System.Windows.Forms.Panel();
            this.lblClubsValue = new System.Windows.Forms.Label();
            this.lblClubsCaption = new System.Windows.Forms.Label();
            this.pnlActiveClubs = new System.Windows.Forms.Panel();
            this.lblActiveClubsValue = new System.Windows.Forms.Label();
            this.lblActiveClubsCaption = new System.Windows.Forms.Label();
            this.pnlMemberships = new System.Windows.Forms.Panel();
            this.lblMembershipsValue = new System.Windows.Forms.Label();
            this.lblMembershipsCaption = new System.Windows.Forms.Label();
            this.pnlUpcoming = new System.Windows.Forms.Panel();
            this.lblUpcomingValue = new System.Windows.Forms.Label();
            this.lblUpcomingCaption = new System.Windows.Forms.Label();
            this.grpManage = new System.Windows.Forms.GroupBox();
            this.btnClubs = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnMemberships = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlContent.SuspendLayout();
            this.grpStats.SuspendLayout();
            this.pnlStudents.SuspendLayout();
            this.pnlClubs.SuspendLayout();
            this.pnlActiveClubs.SuspendLayout();
            this.pnlMemberships.SuspendLayout();
            this.pnlUpcoming.SuspendLayout();
            this.grpManage.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.grpStats);
            this.pnlContent.Controls.Add(this.grpManage);
            this.pnlContent.Controls.Add(this.btnRefresh);
            this.pnlContent.Controls.Add(this.btnLogout);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 50);
            this.pnlContent.Size = new System.Drawing.Size(896, 378);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.TabIndex = 0;
            // 
            // grpStats
            // 
            this.grpStats.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpStats.Controls.Add(this.pnlStudents);
            this.grpStats.Controls.Add(this.pnlClubs);
            this.grpStats.Controls.Add(this.pnlActiveClubs);
            this.grpStats.Controls.Add(this.pnlMemberships);
            this.grpStats.Controls.Add(this.pnlUpcoming);
            this.grpStats.Location = new System.Drawing.Point(16, 12);
            this.grpStats.Size = new System.Drawing.Size(864, 150);
            this.grpStats.Text = "Statistics";
            this.grpStats.TabStop = false;
            this.grpStats.Name = "grpStats";
            this.grpStats.TabIndex = 0;
            // 
            // pnlStudents
            // 
            this.pnlStudents.BackColor = System.Drawing.Color.White;
            this.pnlStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStudents.Controls.Add(this.lblStudentsValue);
            this.pnlStudents.Controls.Add(this.lblStudentsCaption);
            this.pnlStudents.Location = new System.Drawing.Point(16, 28);
            this.pnlStudents.Size = new System.Drawing.Size(156, 104);
            this.pnlStudents.Name = "pnlStudents";
            this.pnlStudents.TabIndex = 0;
            // 
            // lblStudentsValue
            // 
            this.lblStudentsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStudentsValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStudentsValue.Location = new System.Drawing.Point(0, 12);
            this.lblStudentsValue.Size = new System.Drawing.Size(154, 48);
            this.lblStudentsValue.Text = "-";
            this.lblStudentsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStudentsValue.Name = "lblStudentsValue";
            this.lblStudentsValue.TabIndex = 0;
            // 
            // lblStudentsCaption
            // 
            this.lblStudentsCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStudentsCaption.Location = new System.Drawing.Point(0, 66);
            this.lblStudentsCaption.Size = new System.Drawing.Size(154, 22);
            this.lblStudentsCaption.Text = "Students";
            this.lblStudentsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStudentsCaption.Name = "lblStudentsCaption";
            this.lblStudentsCaption.TabIndex = 1;
            // 
            // pnlClubs
            // 
            this.pnlClubs.BackColor = System.Drawing.Color.White;
            this.pnlClubs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClubs.Controls.Add(this.lblClubsValue);
            this.pnlClubs.Controls.Add(this.lblClubsCaption);
            this.pnlClubs.Location = new System.Drawing.Point(184, 28);
            this.pnlClubs.Size = new System.Drawing.Size(156, 104);
            this.pnlClubs.Name = "pnlClubs";
            this.pnlClubs.TabIndex = 1;
            // 
            // lblClubsValue
            // 
            this.lblClubsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblClubsValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblClubsValue.Location = new System.Drawing.Point(0, 12);
            this.lblClubsValue.Size = new System.Drawing.Size(154, 48);
            this.lblClubsValue.Text = "-";
            this.lblClubsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClubsValue.Name = "lblClubsValue";
            this.lblClubsValue.TabIndex = 0;
            // 
            // lblClubsCaption
            // 
            this.lblClubsCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblClubsCaption.Location = new System.Drawing.Point(0, 66);
            this.lblClubsCaption.Size = new System.Drawing.Size(154, 22);
            this.lblClubsCaption.Text = "Clubs (total)";
            this.lblClubsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClubsCaption.Name = "lblClubsCaption";
            this.lblClubsCaption.TabIndex = 1;
            // 
            // pnlActiveClubs
            // 
            this.pnlActiveClubs.BackColor = System.Drawing.Color.White;
            this.pnlActiveClubs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActiveClubs.Controls.Add(this.lblActiveClubsValue);
            this.pnlActiveClubs.Controls.Add(this.lblActiveClubsCaption);
            this.pnlActiveClubs.Location = new System.Drawing.Point(352, 28);
            this.pnlActiveClubs.Size = new System.Drawing.Size(156, 104);
            this.pnlActiveClubs.Name = "pnlActiveClubs";
            this.pnlActiveClubs.TabIndex = 2;
            // 
            // lblActiveClubsValue
            // 
            this.lblActiveClubsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblActiveClubsValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblActiveClubsValue.Location = new System.Drawing.Point(0, 12);
            this.lblActiveClubsValue.Size = new System.Drawing.Size(154, 48);
            this.lblActiveClubsValue.Text = "-";
            this.lblActiveClubsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblActiveClubsValue.Name = "lblActiveClubsValue";
            this.lblActiveClubsValue.TabIndex = 0;
            // 
            // lblActiveClubsCaption
            // 
            this.lblActiveClubsCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblActiveClubsCaption.Location = new System.Drawing.Point(0, 66);
            this.lblActiveClubsCaption.Size = new System.Drawing.Size(154, 22);
            this.lblActiveClubsCaption.Text = "Active Clubs";
            this.lblActiveClubsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblActiveClubsCaption.Name = "lblActiveClubsCaption";
            this.lblActiveClubsCaption.TabIndex = 1;
            // 
            // pnlMemberships
            // 
            this.pnlMemberships.BackColor = System.Drawing.Color.White;
            this.pnlMemberships.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMemberships.Controls.Add(this.lblMembershipsValue);
            this.pnlMemberships.Controls.Add(this.lblMembershipsCaption);
            this.pnlMemberships.Location = new System.Drawing.Point(520, 28);
            this.pnlMemberships.Size = new System.Drawing.Size(156, 104);
            this.pnlMemberships.Name = "pnlMemberships";
            this.pnlMemberships.TabIndex = 3;
            // 
            // lblMembershipsValue
            // 
            this.lblMembershipsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblMembershipsValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMembershipsValue.Location = new System.Drawing.Point(0, 12);
            this.lblMembershipsValue.Size = new System.Drawing.Size(154, 48);
            this.lblMembershipsValue.Text = "-";
            this.lblMembershipsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMembershipsValue.Name = "lblMembershipsValue";
            this.lblMembershipsValue.TabIndex = 0;
            // 
            // lblMembershipsCaption
            // 
            this.lblMembershipsCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMembershipsCaption.Location = new System.Drawing.Point(0, 66);
            this.lblMembershipsCaption.Size = new System.Drawing.Size(154, 22);
            this.lblMembershipsCaption.Text = "Active Memberships";
            this.lblMembershipsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMembershipsCaption.Name = "lblMembershipsCaption";
            this.lblMembershipsCaption.TabIndex = 1;
            // 
            // pnlUpcoming
            // 
            this.pnlUpcoming.BackColor = System.Drawing.Color.White;
            this.pnlUpcoming.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpcoming.Controls.Add(this.lblUpcomingValue);
            this.pnlUpcoming.Controls.Add(this.lblUpcomingCaption);
            this.pnlUpcoming.Location = new System.Drawing.Point(688, 28);
            this.pnlUpcoming.Size = new System.Drawing.Size(156, 104);
            this.pnlUpcoming.Name = "pnlUpcoming";
            this.pnlUpcoming.TabIndex = 4;
            // 
            // lblUpcomingValue
            // 
            this.lblUpcomingValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblUpcomingValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUpcomingValue.Location = new System.Drawing.Point(0, 12);
            this.lblUpcomingValue.Size = new System.Drawing.Size(154, 48);
            this.lblUpcomingValue.Text = "-";
            this.lblUpcomingValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUpcomingValue.Name = "lblUpcomingValue";
            this.lblUpcomingValue.TabIndex = 0;
            // 
            // lblUpcomingCaption
            // 
            this.lblUpcomingCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUpcomingCaption.Location = new System.Drawing.Point(0, 66);
            this.lblUpcomingCaption.Size = new System.Drawing.Size(154, 22);
            this.lblUpcomingCaption.Text = "Upcoming Events";
            this.lblUpcomingCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUpcomingCaption.Name = "lblUpcomingCaption";
            this.lblUpcomingCaption.TabIndex = 1;
            // 
            // grpManage
            // 
            this.grpManage.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpManage.Controls.Add(this.btnClubs);
            this.grpManage.Controls.Add(this.btnStudents);
            this.grpManage.Controls.Add(this.btnMemberships);
            this.grpManage.Controls.Add(this.btnEvents);
            this.grpManage.Controls.Add(this.btnReports);
            this.grpManage.Location = new System.Drawing.Point(16, 174);
            this.grpManage.Size = new System.Drawing.Size(864, 104);
            this.grpManage.Text = "Open a screen";
            this.grpManage.TabStop = false;
            this.grpManage.Name = "grpManage";
            this.grpManage.TabIndex = 1;
            // 
            // btnClubs
            // 
            this.btnClubs.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnClubs.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnClubs.Location = new System.Drawing.Point(16, 28);
            this.btnClubs.Size = new System.Drawing.Size(156, 56);
            this.btnClubs.Text = "&Clubs";
            this.btnClubs.UseVisualStyleBackColor = true;
            this.btnClubs.Name = "btnClubs";
            this.btnClubs.TabIndex = 0;
            this.btnClubs.Click += new System.EventHandler(this.btnClubs_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnStudents.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnStudents.Location = new System.Drawing.Point(184, 28);
            this.btnStudents.Size = new System.Drawing.Size(156, 56);
            this.btnStudents.Text = "&Students";
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.TabIndex = 1;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnMemberships
            // 
            this.btnMemberships.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnMemberships.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnMemberships.Location = new System.Drawing.Point(352, 28);
            this.btnMemberships.Size = new System.Drawing.Size(156, 56);
            this.btnMemberships.Text = "&Memberships";
            this.btnMemberships.UseVisualStyleBackColor = true;
            this.btnMemberships.Name = "btnMemberships";
            this.btnMemberships.TabIndex = 2;
            this.btnMemberships.Click += new System.EventHandler(this.btnMemberships_Click);
            // 
            // btnEvents
            // 
            this.btnEvents.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnEvents.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnEvents.Location = new System.Drawing.Point(520, 28);
            this.btnEvents.Size = new System.Drawing.Size(156, 56);
            this.btnEvents.Text = "&Events";
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.TabIndex = 3;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnReports.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnReports.Location = new System.Drawing.Point(688, 28);
            this.btnReports.Size = new System.Drawing.Size(156, 56);
            this.btnReports.Text = "&Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Name = "btnReports";
            this.btnReports.TabIndex = 4;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRefresh.Location = new System.Drawing.Point(16, 292);
            this.btnRefresh.Size = new System.Drawing.Size(170, 32);
            this.btnRefresh.Text = "Refresh Statistics";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLogout.Location = new System.Drawing.Point(194, 292);
            this.btnLogout.Size = new System.Drawing.Size(120, 32);
            this.btnLogout.Text = "&Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(896, 50);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblHeader.Location = new System.Drawing.Point(14, 14);
            this.lblHeader.Size = new System.Drawing.Size(59, 25);
            this.lblHeader.Text = "Dashboard";
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Size = new System.Drawing.Size(896, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(896, 450);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Club Management System";
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.grpStats.ResumeLayout(false);
            this.grpStats.PerformLayout();
            this.pnlStudents.ResumeLayout(false);
            this.pnlStudents.PerformLayout();
            this.pnlClubs.ResumeLayout(false);
            this.pnlClubs.PerformLayout();
            this.pnlActiveClubs.ResumeLayout(false);
            this.pnlActiveClubs.PerformLayout();
            this.pnlMemberships.ResumeLayout(false);
            this.pnlMemberships.PerformLayout();
            this.pnlUpcoming.ResumeLayout(false);
            this.pnlUpcoming.PerformLayout();
            this.grpManage.ResumeLayout(false);
            this.grpManage.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grpStats;
        private System.Windows.Forms.Panel pnlStudents;
        private System.Windows.Forms.Label lblStudentsValue;
        private System.Windows.Forms.Label lblStudentsCaption;
        private System.Windows.Forms.Panel pnlClubs;
        private System.Windows.Forms.Label lblClubsValue;
        private System.Windows.Forms.Label lblClubsCaption;
        private System.Windows.Forms.Panel pnlActiveClubs;
        private System.Windows.Forms.Label lblActiveClubsValue;
        private System.Windows.Forms.Label lblActiveClubsCaption;
        private System.Windows.Forms.Panel pnlMemberships;
        private System.Windows.Forms.Label lblMembershipsValue;
        private System.Windows.Forms.Label lblMembershipsCaption;
        private System.Windows.Forms.Panel pnlUpcoming;
        private System.Windows.Forms.Label lblUpcomingValue;
        private System.Windows.Forms.Label lblUpcomingCaption;
        private System.Windows.Forms.GroupBox grpManage;
        private System.Windows.Forms.Button btnClubs;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnMemberships;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
