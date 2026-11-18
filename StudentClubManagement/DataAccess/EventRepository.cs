using System;
using System.Data;
using StudentClubManagement.Models;

namespace StudentClubManagement.DataAccess
{
    /// <summary>
    /// Data access for the Events and EventAttendance tables
    /// (stored procedures sp_Event_*).
    /// </summary>
    public class EventRepository
    {
        /// <summary>Lists every event with its club name and registration count.</summary>
        public DataTable GetAll()
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Event_GetAll");
        }

        /// <summary>Loads one event, or null when the ID no longer exists.</summary>
        public Event GetById(int eventId)
        {
            DataTable table = DBHelper.ExecuteDataTable("dbo.sp_Event_GetByID",
                DBHelper.Param("@EventID", eventId));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        /// <summary>Lists the events organised by one club.</summary>
        public DataTable GetByClub(int clubId)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Event_GetByClub",
                DBHelper.Param("@ClubID", clubId));
        }

        /// <summary>
        /// Finds events by name, location, description or club name.
        /// Pass a club ID to limit the search to that club, or null for all clubs.
        /// </summary>
        public DataTable Search(string keyword, int? clubId)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Event_Search",
                DBHelper.Param("@Keyword", keyword),
                DBHelper.Param("@ClubID", clubId));
        }

        /// <summary>Creates an event and returns the new EventID.</summary>
        public int Insert(Event ev)
        {
            object newId = DBHelper.ExecuteScalar("dbo.sp_Event_Insert",
                DBHelper.Param("@ClubID", ev.ClubID),
                DBHelper.Param("@EventName", ev.EventName),
                DBHelper.Param("@EventDate", ev.EventDate),
                DBHelper.Param("@Location", ev.Location),
                DBHelper.Param("@Description", ev.Description),
                DBHelper.Param("@Capacity", ev.Capacity));

            return Convert.ToInt32(newId);
        }

        /// <summary>Saves changes to an event; returns the rows updated (1).</summary>
        public int Update(Event ev)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Event_Update",
                DBHelper.Param("@EventID", ev.EventID),
                DBHelper.Param("@ClubID", ev.ClubID),
                DBHelper.Param("@EventName", ev.EventName),
                DBHelper.Param("@EventDate", ev.EventDate),
                DBHelper.Param("@Location", ev.Location),
                DBHelper.Param("@Description", ev.Description),
                DBHelper.Param("@Capacity", ev.Capacity));
        }

        /// <summary>Deletes an event. The procedure refuses while students are registered.</summary>
        public int Delete(int eventId)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Event_Delete",
                DBHelper.Param("@EventID", eventId));
        }

        /// <summary>Lists the students registered for an event.</summary>
        public DataTable GetAttendees(int eventId)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Event_GetAttendees",
                DBHelper.Param("@EventID", eventId));
        }

        /// <summary>
        /// Registers a student for an event. The procedure enforces the
        /// capacity limit and the no-duplicates rule. Returns the new AttendanceID.
        /// </summary>
        public int RegisterStudent(int eventId, int studentId)
        {
            object newId = DBHelper.ExecuteScalar("dbo.sp_Event_RegisterStudent",
                DBHelper.Param("@EventID", eventId),
                DBHelper.Param("@StudentID", studentId));

            return Convert.ToInt32(newId);
        }

        /// <summary>Removes a student's registration; returns the rows deleted (1).</summary>
        public int UnregisterStudent(int eventId, int studentId)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Event_UnregisterStudent",
                DBHelper.Param("@EventID", eventId),
                DBHelper.Param("@StudentID", studentId));
        }

        /// <summary>Marks a registered student as attended or not attended.</summary>
        public int MarkAttendance(int eventId, int studentId, bool attended)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Event_MarkAttendance",
                DBHelper.Param("@EventID", eventId),
                DBHelper.Param("@StudentID", studentId),
                DBHelper.Param("@Attended", attended));
        }

        /// <summary>Converts a result row into an Event object.</summary>
        private static Event Map(DataRow row)
        {
            return new Event
            {
                EventID = Convert.ToInt32(row["EventID"]),
                ClubID = Convert.ToInt32(row["ClubID"]),
                EventName = row["EventName"] as string,
                EventDate = Convert.ToDateTime(row["EventDate"]),
                Location = row["Location"] as string,
                Description = row["Description"] as string,
                Capacity = Convert.ToInt32(row["Capacity"]),
                ClubName = row["ClubName"] as string,
                RegisteredCount = Convert.ToInt32(row["RegisteredCount"])
            };
        }
    }
}
