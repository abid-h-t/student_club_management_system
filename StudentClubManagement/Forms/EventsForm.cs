using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentClubManagement.DataAccess;
using StudentClubManagement.Models;
using StudentClubManagement.Utilities;

namespace StudentClubManagement.Forms
{
    /// <summary>
    /// Create, edit and delete club events, register students for an event
    /// and mark their attendance.
    /// </summary>
    public partial class EventsForm : Form
    {
        private readonly ClubRepository _clubs = new ClubRepository();
        private readonly StudentRepository _students = new StudentRepository();
        private readonly EventRepository _events = new EventRepository();

        private int _selectedEventId;          // 0 = none, i.e. "new event" mode
        private DateTime _selectedEventDate;   // original date of the loaded event
        private bool _loading;                 // true while combo boxes are being filled

        public EventsForm()
        {
            InitializeComponent();
            UiHelper.ConfigureGrid(dgvEvents);
            UiHelper.ConfigureGrid(dgvAttendees);
        }

        private void EventsForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            ClearFields();
            RefreshEvents();
        }

        // ------------------------------------------------------------------
        // Loading
        // ------------------------------------------------------------------

        /// <summary>
        /// Fills the club filter, the club list for the details box
        /// (sp_Club_GetAll) and the student list (sp_Student_GetAll).
        /// </summary>
        private void LoadComboBoxes()
        {
            _loading = true;
            try
            {
                // Details box: every club; inactive ones are labelled
                DataTable clubs = _clubs.GetAll();
                clubs.Columns.Add("Display", typeof(string), "ClubName + IIF(IsActive, '', '  (inactive)')");
                cboClub.DisplayMember = "Display";
                cboClub.ValueMember = "ClubID";
                cboClub.DataSource = clubs;

                // Filter: the same clubs plus an "(All clubs)" entry with ID 0
                DataTable filter = new DataTable();
                filter.Columns.Add("ClubID", typeof(int));
                filter.Columns.Add("Display", typeof(string));
                filter.Rows.Add(0, "(All clubs)");
                foreach (DataRow club in clubs.Rows)
                {
                    filter.Rows.Add(club["ClubID"], club["Display"]);
                }

                cboFilterClub.DisplayMember = "Display";
                cboFilterClub.ValueMember = "ClubID";
                cboFilterClub.DataSource = filter;

                DataTable students = _students.GetAll();
                students.Columns.Add("Display", typeof(string), "LastName + ', ' + FirstName + '  (' + Email + ')'");
                cboStudent.DisplayMember = "Display";
                cboStudent.ValueMember = "StudentID";
                cboStudent.DataSource = students;
                ResetCombo(cboStudent);
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
            finally
            {
                _loading = false;
            }
        }

        /// <summary>Clears the selection of a data-bound combo box.</summary>
        private static void ResetCombo(ComboBox combo)
        {
            combo.SelectedIndex = -1;
            combo.SelectedIndex = -1; // set twice: a data-bound combo ignores the first reset
        }

        /// <summary>Returns the ID behind the selected combo item, or 0 when nothing is selected.</summary>
        private static int GetSelectedId(ComboBox combo)
        {
            return combo.SelectedIndex >= 0 && combo.SelectedValue is int ? (int)combo.SelectedValue : 0;
        }

        /// <summary>
        /// Reloads the events grid using the club filter and the search box:
        /// no filter -> sp_Event_GetAll, club only -> sp_Event_GetByClub,
        /// search text (with or without club) -> sp_Event_Search.
        /// </summary>
        private void RefreshEvents()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                int clubId = GetSelectedId(cboFilterClub);
                DataTable table;

                if (keyword.Length > 0)
                {
                    table = _events.Search(keyword, clubId == 0 ? (int?)null : clubId);
                }
                else if (clubId != 0)
                {
                    table = _events.GetByClub(clubId);
                }
                else
                {
                    table = _events.GetAll();
                }

                dgvEvents.DataSource = table;
                UiHelper.HideColumns(dgvEvents, "ClubID", "Description");
                UiHelper.SetColumnWeight(dgvEvents, 55, "EventID", "Capacity");
                UiHelper.SetColumnWeight(dgvEvents, 150, "EventName");
                if (dgvEvents.Columns.Contains("EventDate"))
                {
                    dgvEvents.Columns["EventDate"].DefaultCellStyle.Format = "dd MMM yyyy  HH:mm";
                }

                lblCount.Text = table.Rows.Count + (table.Rows.Count == 1 ? " event" : " events");

                // Keep the current event highlighted if it is still listed
                if (_selectedEventId != 0)
                {
                    UiHelper.SelectRowById(dgvEvents, "EventID", _selectedEventId);
                }
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>Reloads the attendee grid for the selected event (sp_Event_GetAttendees).</summary>
        private void RefreshAttendees()
        {
            if (_selectedEventId == 0)
            {
                dgvAttendees.DataSource = null;
                lblSelectedEvent.Text = "Click an event in the list to manage its registrations";
                return;
            }

            DataTable attendees = _events.GetAttendees(_selectedEventId);
            dgvAttendees.DataSource = attendees;
            UiHelper.HideColumns(dgvAttendees, "AttendanceID", "EventID", "StudentID");
            UiHelper.SetColumnWeight(dgvAttendees, 150, "Email");
            UiHelper.SetColumnWeight(dgvAttendees, 60, "Attended");

            int capacity;
            int.TryParse(txtCapacity.Text, out capacity);
            lblSelectedEvent.Text = txtEventName.Text + "  -  " + attendees.Rows.Count + " of " +
                                    capacity + " places taken";
        }

        /// <summary>
        /// Clicking an event row loads it (sp_Event_GetByID) into the details
        /// box and lists its registered students.
        /// </summary>
        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return; // header row
            }

            try
            {
                int eventId = Convert.ToInt32(dgvEvents.Rows[e.RowIndex].Cells["EventID"].Value);
                LoadEvent(eventId);
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>Loads one event into the fields and refreshes its attendee list.</summary>
        private void LoadEvent(int eventId)
        {
            Event ev = _events.GetById(eventId);

            if (ev == null)
            {
                UiHelper.ShowWarning("This event no longer exists. The list will be refreshed.");
                ClearFields();
                RefreshEvents();
                return;
            }

            _selectedEventId = ev.EventID;
            _selectedEventDate = ev.EventDate;

            txtEventId.Text = ev.EventID.ToString();
            cboClub.SelectedValue = ev.ClubID;
            txtEventName.Text = ev.EventName;
            dtpEventDate.Value = ev.EventDate;
            txtLocation.Text = ev.Location;
            txtCapacity.Text = ev.Capacity.ToString();
            txtDescription.Text = ev.Description ?? string.Empty;

            RefreshAttendees();
        }

        // ------------------------------------------------------------------
        // Validation
        // ------------------------------------------------------------------

        /// <summary>
        /// Checks the fields before any database call: club, name and
        /// location are required; capacity must be a whole number from 1 to
        /// 100000; a new event (or a changed date) cannot be in the past.
        /// Returns null when something is invalid.
        /// </summary>
        private Event ReadAndValidateFields(bool isNew)
        {
            int clubId = GetSelectedId(cboClub);
            if (clubId == 0)
            {
                UiHelper.ShowValidation("Choose the club that organises the event.", cboClub);
                return null;
            }

            if (Validator.IsBlank(txtEventName.Text))
            {
                UiHelper.ShowValidation("Event name is required.", txtEventName);
                return null;
            }

            // Seconds are dropped so the value matches what the picker shows
            DateTime picked = dtpEventDate.Value;
            DateTime eventDate = new DateTime(picked.Year, picked.Month, picked.Day, picked.Hour, picked.Minute, 0);

            bool dateChanged = isNew || eventDate != _selectedEventDate;
            if (dateChanged && eventDate <= DateTime.Now)
            {
                UiHelper.ShowValidation(isNew
                    ? "A new event must be scheduled in the future. Choose a later date and time."
                    : "An event cannot be moved to a date in the past.", dtpEventDate);
                return null;
            }

            if (Validator.IsBlank(txtLocation.Text))
            {
                UiHelper.ShowValidation("Location is required.", txtLocation);
                return null;
            }

            int capacity;
            if (!Validator.TryParseIntInRange(txtCapacity.Text, 1, 100000, out capacity))
            {
                UiHelper.ShowValidation("Capacity must be a whole number between 1 and 100000.", txtCapacity);
                return null;
            }

            return new Event
            {
                EventID = _selectedEventId,
                ClubID = clubId,
                EventName = txtEventName.Text.Trim(),
                EventDate = eventDate,
                Location = txtLocation.Text.Trim(),
                Capacity = capacity,
                Description = txtDescription.Text.Trim()
            };
        }

        // ------------------------------------------------------------------
        // Event buttons
        // ------------------------------------------------------------------

        /// <summary>Add: validate, call sp_Event_Insert, then select the new event.</summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Event ev = ReadAndValidateFields(true);
            if (ev == null)
            {
                return;
            }

            try
            {
                int newId = _events.Insert(ev);
                UiHelper.ShowInfo("Event \"" + ev.EventName + "\" was created with ID " + newId + ".");

                _selectedEventId = newId;
                RefreshEvents();
                LoadEvent(newId); // ready for registrations straight away
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex); // e.g. 50005: inactive club
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>Update: needs a selected event, validates, then calls sp_Event_Update.</summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == 0)
            {
                UiHelper.ShowWarning("Click an event in the list first, then change its details and press Update.");
                return;
            }

            Event ev = ReadAndValidateFields(false);
            if (ev == null)
            {
                return;
            }

            try
            {
                _events.Update(ev);
                UiHelper.ShowInfo("Event \"" + ev.EventName + "\" was updated.");
                RefreshEvents();
                LoadEvent(ev.EventID);
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex); // e.g. 50005: capacity below registrations
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>
        /// Delete: needs a selected event and a confirmation, then calls
        /// sp_Event_Delete (which refuses while students are registered).
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == 0)
            {
                UiHelper.ShowWarning("Click an event in the list first, then press Delete.");
                return;
            }

            if (!UiHelper.Confirm("Delete the event \"" + txtEventName.Text + "\"?\n\nThis cannot be undone."))
            {
                return;
            }

            try
            {
                _events.Delete(_selectedEventId);
                UiHelper.ShowInfo("The event was deleted.");
                ClearFields();
                RefreshEvents();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex); // e.g. 50004: students still registered
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>Empties the details box and the attendee list ("new event" mode).</summary>
        private void ClearFields()
        {
            _selectedEventId = 0;
            _selectedEventDate = DateTime.MinValue;

            txtEventId.Text = "(new)";
            ResetCombo(cboClub);
            txtEventName.Clear();
            dtpEventDate.Value = DateTime.Today.AddDays(7).AddHours(18); // a sensible default: next week, 18:00
            txtLocation.Clear();
            txtCapacity.Clear();
            txtDescription.Clear();

            // Pre-select the filtered club so adding an event for it is quicker
            int filterClubId = GetSelectedId(cboFilterClub);
            if (filterClubId != 0)
            {
                cboClub.SelectedValue = filterClubId;
            }

            dgvEvents.ClearSelection();
            RefreshAttendees();
        }

        // ------------------------------------------------------------------
        // Filter and search
        // ------------------------------------------------------------------

        private void cboFilterClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading)
            {
                return;
            }

            ClearFields();
            RefreshEvents();
        }

        /// <summary>Search: runs sp_Event_Search (within the chosen club, if any).</summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Validator.IsBlank(txtSearch.Text))
            {
                UiHelper.ShowValidation("Type part of an event name, location, description or club name to search for.", txtSearch);
                return;
            }

            RefreshEvents();
        }

        /// <summary>Show All: clears the search box and the club filter.</summary>
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            if (cboFilterClub.Items.Count > 0 && cboFilterClub.SelectedIndex != 0)
            {
                cboFilterClub.SelectedIndex = 0; // triggers a refresh through SelectedIndexChanged
            }
            else
            {
                RefreshEvents();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, EventArgs.Empty);
            }
        }

        // ------------------------------------------------------------------
        // Registration and attendance buttons
        // ------------------------------------------------------------------

        /// <summary>
        /// Register Student: needs a selected event and student, then calls
        /// sp_Event_RegisterStudent, which enforces capacity and no duplicates.
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == 0)
            {
                UiHelper.ShowWarning("Click an event in the list first.");
                return;
            }

            int studentId = GetSelectedId(cboStudent);
            if (studentId == 0)
            {
                UiHelper.ShowValidation("Choose the student to register.", cboStudent);
                return;
            }

            try
            {
                _events.RegisterStudent(_selectedEventId, studentId);
                UiHelper.ShowInfo("The student was registered for \"" + txtEventName.Text + "\".");
                ResetCombo(cboStudent);
                RefreshEvents();     // the Registered Count column changes
                RefreshAttendees();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex); // 50003 already registered, 50005 event full / already held
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>Returns the StudentID of the highlighted attendee row, or 0 when none is selected.</summary>
        private int GetSelectedAttendeeStudentId()
        {
            if (_selectedEventId == 0)
            {
                UiHelper.ShowWarning("Click an event in the list first.");
                return 0;
            }

            if (dgvAttendees.SelectedRows.Count == 0)
            {
                UiHelper.ShowWarning("Click a registered student in the attendance list first.");
                return 0;
            }

            return Convert.ToInt32(dgvAttendees.SelectedRows[0].Cells["StudentID"].Value);
        }

        private void btnMarkAttended_Click(object sender, EventArgs e)
        {
            MarkAttendance(true);
        }

        private void btnMarkAbsent_Click(object sender, EventArgs e)
        {
            MarkAttendance(false);
        }

        /// <summary>Mark Attended / Not Attended: calls sp_Event_MarkAttendance for the selected student.</summary>
        private void MarkAttendance(bool attended)
        {
            int studentId = GetSelectedAttendeeStudentId();
            if (studentId == 0)
            {
                return;
            }

            try
            {
                _events.MarkAttendance(_selectedEventId, studentId, attended);
                RefreshAttendees();
                UiHelper.SelectRowById(dgvAttendees, "StudentID", studentId);
                UiHelper.ShowInfo(attended ? "Attendance recorded: the student attended."
                                           : "Attendance recorded: the student did not attend.");
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>Unregister: confirms, then calls sp_Event_UnregisterStudent for the selected student.</summary>
        private void btnUnregister_Click(object sender, EventArgs e)
        {
            int studentId = GetSelectedAttendeeStudentId();
            if (studentId == 0)
            {
                return;
            }

            string studentName = Convert.ToString(dgvAttendees.SelectedRows[0].Cells["StudentName"].Value);
            if (!UiHelper.Confirm("Remove " + studentName + " from \"" + txtEventName.Text + "\"?"))
            {
                return;
            }

            try
            {
                _events.UnregisterStudent(_selectedEventId, studentId);
                UiHelper.ShowInfo(studentName + " was unregistered from the event.");
                RefreshEvents();
                RefreshAttendees();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }
    }
}
