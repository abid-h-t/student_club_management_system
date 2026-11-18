namespace StudentClubManagement.Forms
{
    partial class EventsForm
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
            this.lblFilterClub = new System.Windows.Forms.Label();
            this.cboFilterClub = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblEventId = new System.Windows.Forms.Label();
            this.txtEventId = new System.Windows.Forms.TextBox();
            this.lblClub = new System.Windows.Forms.Label();
            this.cboClub = new System.Windows.Forms.ComboBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpAttendance = new System.Windows.Forms.GroupBox();
            this.lblSelectedEvent = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cboStudent = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.dgvAttendees = new System.Windows.Forms.DataGridView();
            this.btnMarkAttended = new System.Windows.Forms.Button();
            this.btnMarkAbsent = new System.Windows.Forms.Button();
            this.btnUnregister = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.grpDetails.SuspendLayout();
            this.grpAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlFilter);
            this.pnlContent.Controls.Add(this.dgvEvents);
            this.pnlContent.Controls.Add(this.grpDetails);
            this.pnlContent.Controls.Add(this.grpAttendance);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 46);
            this.pnlContent.Size = new System.Drawing.Size(1120, 684);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.Controls.Add(this.lblFilterClub);
            this.pnlFilter.Controls.Add(this.cboFilterClub);
            this.pnlFilter.Controls.Add(this.lblSearch);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.btnShowAll);
            this.pnlFilter.Controls.Add(this.lblCount);
            this.pnlFilter.Location = new System.Drawing.Point(16, 10);
            this.pnlFilter.Size = new System.Drawing.Size(1088, 40);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.TabIndex = 0;
            // 
            // lblFilterClub
            // 
            this.lblFilterClub.AutoSize = true;
            this.lblFilterClub.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblFilterClub.Location = new System.Drawing.Point(0, 12);
            this.lblFilterClub.Size = new System.Drawing.Size(35, 15);
            this.lblFilterClub.Text = "Club:";
            this.lblFilterClub.Name = "lblFilterClub";
            this.lblFilterClub.TabIndex = 0;
            // 
            // cboFilterClub
            // 
            this.cboFilterClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterClub.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboFilterClub.FormattingEnabled = true;
            this.cboFilterClub.Location = new System.Drawing.Point(40, 9);
            this.cboFilterClub.Size = new System.Drawing.Size(260, 23);
            this.cboFilterClub.Name = "cboFilterClub";
            this.cboFilterClub.TabIndex = 1;
            this.cboFilterClub.SelectedIndexChanged += new System.EventHandler(this.cboFilterClub_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSearch.Location = new System.Drawing.Point(324, 12);
            this.lblSearch.Size = new System.Drawing.Size(47, 15);
            this.lblSearch.Text = "Search:";
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSearch.Location = new System.Drawing.Point(378, 9);
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Size = new System.Drawing.Size(230, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TabIndex = 3;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.Location = new System.Drawing.Point(616, 7);
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnShowAll.Location = new System.Drawing.Point(714, 7);
            this.btnShowAll.Size = new System.Drawing.Size(90, 28);
            this.btnShowAll.Text = "Show A&ll";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCount.Location = new System.Drawing.Point(828, 12);
            this.lblCount.Size = new System.Drawing.Size(260, 15);
            this.lblCount.Text = "0 events";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblCount.Name = "lblCount";
            this.lblCount.TabIndex = 6;
            // 
            // dgvEvents
            // 
            this.dgvEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEvents.BackgroundColor = System.Drawing.Color.White;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(16, 58);
            this.dgvEvents.Size = new System.Drawing.Size(1088, 230);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.TabIndex = 1;
            this.dgvEvents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellClick);
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.grpDetails.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpDetails.Controls.Add(this.lblEventId);
            this.grpDetails.Controls.Add(this.txtEventId);
            this.grpDetails.Controls.Add(this.lblClub);
            this.grpDetails.Controls.Add(this.cboClub);
            this.grpDetails.Controls.Add(this.lblEventName);
            this.grpDetails.Controls.Add(this.txtEventName);
            this.grpDetails.Controls.Add(this.lblEventDate);
            this.grpDetails.Controls.Add(this.dtpEventDate);
            this.grpDetails.Controls.Add(this.lblLocation);
            this.grpDetails.Controls.Add(this.txtLocation);
            this.grpDetails.Controls.Add(this.lblCapacity);
            this.grpDetails.Controls.Add(this.txtCapacity);
            this.grpDetails.Controls.Add(this.lblDescription);
            this.grpDetails.Controls.Add(this.txtDescription);
            this.grpDetails.Controls.Add(this.btnAdd);
            this.grpDetails.Controls.Add(this.btnUpdate);
            this.grpDetails.Controls.Add(this.btnDelete);
            this.grpDetails.Controls.Add(this.btnClear);
            this.grpDetails.Location = new System.Drawing.Point(16, 300);
            this.grpDetails.Size = new System.Drawing.Size(528, 368);
            this.grpDetails.Text = "Event Details  (* = required)";
            this.grpDetails.TabStop = false;
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.TabIndex = 2;
            // 
            // lblEventId
            // 
            this.lblEventId.AutoSize = true;
            this.lblEventId.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblEventId.Location = new System.Drawing.Point(16, 37);
            this.lblEventId.Size = new System.Drawing.Size(59, 15);
            this.lblEventId.Text = "Event ID:";
            this.lblEventId.Name = "lblEventId";
            this.lblEventId.TabIndex = 0;
            // 
            // txtEventId
            // 
            this.txtEventId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEventId.Location = new System.Drawing.Point(112, 34);
            this.txtEventId.ReadOnly = true;
            this.txtEventId.TabStop = false;
            this.txtEventId.Size = new System.Drawing.Size(100, 23);
            this.txtEventId.Name = "txtEventId";
            this.txtEventId.TabIndex = 1;
            // 
            // lblClub
            // 
            this.lblClub.AutoSize = true;
            this.lblClub.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblClub.Location = new System.Drawing.Point(16, 69);
            this.lblClub.Size = new System.Drawing.Size(47, 15);
            this.lblClub.Text = "Club: *";
            this.lblClub.Name = "lblClub";
            this.lblClub.TabIndex = 2;
            // 
            // cboClub
            // 
            this.cboClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClub.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboClub.FormattingEnabled = true;
            this.cboClub.Location = new System.Drawing.Point(112, 66);
            this.cboClub.Size = new System.Drawing.Size(400, 23);
            this.cboClub.Name = "cboClub";
            this.cboClub.TabIndex = 3;
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblEventName.Location = new System.Drawing.Point(16, 101);
            this.lblEventName.Size = new System.Drawing.Size(84, 15);
            this.lblEventName.Text = "Event Name: *";
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.TabIndex = 4;
            // 
            // txtEventName
            // 
            this.txtEventName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEventName.Location = new System.Drawing.Point(112, 98);
            this.txtEventName.MaxLength = 100;
            this.txtEventName.Size = new System.Drawing.Size(400, 23);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.TabIndex = 5;
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblEventDate.Location = new System.Drawing.Point(16, 133);
            this.lblEventDate.Size = new System.Drawing.Size(97, 15);
            this.lblEventDate.Text = "Date && Time: *";
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.TabIndex = 6;
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.CustomFormat = "dd MMM yyyy   HH:mm";
            this.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEventDate.Location = new System.Drawing.Point(112, 130);
            this.dtpEventDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.TabIndex = 7;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblLocation.Location = new System.Drawing.Point(16, 165);
            this.lblLocation.Size = new System.Drawing.Size(72, 15);
            this.lblLocation.Text = "Location: *";
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.TabIndex = 8;
            // 
            // txtLocation
            // 
            this.txtLocation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLocation.Location = new System.Drawing.Point(112, 162);
            this.txtLocation.MaxLength = 100;
            this.txtLocation.Size = new System.Drawing.Size(400, 23);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.TabIndex = 9;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCapacity.Location = new System.Drawing.Point(16, 197);
            this.lblCapacity.Size = new System.Drawing.Size(72, 15);
            this.lblCapacity.Text = "Capacity: *";
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.TabIndex = 10;
            // 
            // txtCapacity
            // 
            this.txtCapacity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCapacity.Location = new System.Drawing.Point(112, 194);
            this.txtCapacity.MaxLength = 6;
            this.txtCapacity.Size = new System.Drawing.Size(100, 23);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.TabIndex = 11;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDescription.Location = new System.Drawing.Point(16, 229);
            this.lblDescription.Size = new System.Drawing.Size(78, 15);
            this.lblDescription.Text = "Description:";
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.TabIndex = 12;
            // 
            // txtDescription
            // 
            this.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescription.Location = new System.Drawing.Point(112, 226);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(400, 70);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.Location = new System.Drawing.Point(112, 310);
            this.btnAdd.Size = new System.Drawing.Size(94, 32);
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdate.Location = new System.Drawing.Point(212, 310);
            this.btnUpdate.Size = new System.Drawing.Size(94, 32);
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnDelete.Location = new System.Drawing.Point(312, 310);
            this.btnDelete.Size = new System.Drawing.Size(94, 32);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnClear.Location = new System.Drawing.Point(412, 310);
            this.btnClear.Size = new System.Drawing.Size(100, 32);
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 17;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpAttendance
            // 
            this.grpAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAttendance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpAttendance.Controls.Add(this.lblSelectedEvent);
            this.grpAttendance.Controls.Add(this.lblStudent);
            this.grpAttendance.Controls.Add(this.cboStudent);
            this.grpAttendance.Controls.Add(this.btnRegister);
            this.grpAttendance.Controls.Add(this.dgvAttendees);
            this.grpAttendance.Controls.Add(this.btnMarkAttended);
            this.grpAttendance.Controls.Add(this.btnMarkAbsent);
            this.grpAttendance.Controls.Add(this.btnUnregister);
            this.grpAttendance.Location = new System.Drawing.Point(556, 300);
            this.grpAttendance.Size = new System.Drawing.Size(548, 368);
            this.grpAttendance.Text = "Registrations && Attendance";
            this.grpAttendance.TabStop = false;
            this.grpAttendance.Name = "grpAttendance";
            this.grpAttendance.TabIndex = 3;
            // 
            // lblSelectedEvent
            // 
            this.lblSelectedEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedEvent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedEvent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSelectedEvent.Location = new System.Drawing.Point(16, 28);
            this.lblSelectedEvent.Size = new System.Drawing.Size(516, 18);
            this.lblSelectedEvent.Text = "Click an event in the list to manage its registrations";
            this.lblSelectedEvent.Name = "lblSelectedEvent";
            this.lblSelectedEvent.TabIndex = 0;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStudent.Location = new System.Drawing.Point(16, 63);
            this.lblStudent.Size = new System.Drawing.Size(53, 15);
            this.lblStudent.Text = "Student:";
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.TabIndex = 1;
            // 
            // cboStudent
            // 
            this.cboStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboStudent.FormattingEnabled = true;
            this.cboStudent.Location = new System.Drawing.Point(76, 60);
            this.cboStudent.Size = new System.Drawing.Size(320, 23);
            this.cboStudent.Name = "cboStudent";
            this.cboStudent.TabIndex = 2;
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRegister.Location = new System.Drawing.Point(404, 58);
            this.btnRegister.Size = new System.Drawing.Size(128, 28);
            this.btnRegister.Text = "&Register Student";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // dgvAttendees
            // 
            this.dgvAttendees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAttendees.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendees.Location = new System.Drawing.Point(16, 96);
            this.dgvAttendees.Size = new System.Drawing.Size(516, 204);
            this.dgvAttendees.Name = "dgvAttendees";
            this.dgvAttendees.TabIndex = 4;
            // 
            // btnMarkAttended
            // 
            this.btnMarkAttended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMarkAttended.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnMarkAttended.Location = new System.Drawing.Point(16, 310);
            this.btnMarkAttended.Size = new System.Drawing.Size(140, 32);
            this.btnMarkAttended.Text = "Mark Atte&nded";
            this.btnMarkAttended.UseVisualStyleBackColor = true;
            this.btnMarkAttended.Name = "btnMarkAttended";
            this.btnMarkAttended.TabIndex = 5;
            this.btnMarkAttended.Click += new System.EventHandler(this.btnMarkAttended_Click);
            // 
            // btnMarkAbsent
            // 
            this.btnMarkAbsent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMarkAbsent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnMarkAbsent.Location = new System.Drawing.Point(164, 310);
            this.btnMarkAbsent.Size = new System.Drawing.Size(140, 32);
            this.btnMarkAbsent.Text = "Mark Not Attended";
            this.btnMarkAbsent.UseVisualStyleBackColor = true;
            this.btnMarkAbsent.Name = "btnMarkAbsent";
            this.btnMarkAbsent.TabIndex = 6;
            this.btnMarkAbsent.Click += new System.EventHandler(this.btnMarkAbsent_Click);
            // 
            // btnUnregister
            // 
            this.btnUnregister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnregister.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnUnregister.Location = new System.Drawing.Point(312, 310);
            this.btnUnregister.Size = new System.Drawing.Size(120, 32);
            this.btnUnregister.Text = "Unregister";
            this.btnUnregister.UseVisualStyleBackColor = true;
            this.btnUnregister.Name = "btnUnregister";
            this.btnUnregister.TabIndex = 7;
            this.btnUnregister.Click += new System.EventHandler(this.btnUnregister_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1120, 46);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(14, 14);
            this.lblTitle.Size = new System.Drawing.Size(41, 25);
            this.lblTitle.Text = "Events";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            // 
            // EventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 730);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1136, 769);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Events";
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "EventsForm";
            this.Load += new System.EventHandler(this.EventsForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grpAttendance.ResumeLayout(false);
            this.grpAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterClub;
        private System.Windows.Forms.ComboBox cboFilterClub;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblEventId;
        private System.Windows.Forms.TextBox txtEventId;
        private System.Windows.Forms.Label lblClub;
        private System.Windows.Forms.ComboBox cboClub;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpAttendance;
        private System.Windows.Forms.Label lblSelectedEvent;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.DataGridView dgvAttendees;
        private System.Windows.Forms.Button btnMarkAttended;
        private System.Windows.Forms.Button btnMarkAbsent;
        private System.Windows.Forms.Button btnUnregister;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
    }
}
