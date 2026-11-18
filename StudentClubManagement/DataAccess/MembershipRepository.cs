using System;
using System.Data;
using StudentClubManagement.Models;

namespace StudentClubManagement.DataAccess
{
    /// <summary>Data access for the Memberships table (stored procedures sp_Membership_*).</summary>
    public class MembershipRepository
    {
        /// <summary>Lists every membership with student and club names.</summary>
        public DataTable GetAll()
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Membership_GetAll");
        }

        /// <summary>Loads one membership, or null when the ID no longer exists.</summary>
        public Membership GetById(int membershipId)
        {
            DataTable table = DBHelper.ExecuteDataTable("dbo.sp_Membership_GetByID",
                DBHelper.Param("@MembershipID", membershipId));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        /// <summary>Finds memberships by student name, email, club name, role or status.</summary>
        public DataTable Search(string keyword)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Membership_Search",
                DBHelper.Param("@Keyword", keyword));
        }

        /// <summary>Lists the members of one club (officers first).</summary>
        public DataTable GetMembersByClub(int clubId)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Membership_GetMembersByClub",
                DBHelper.Param("@ClubID", clubId));
        }

        /// <summary>Lists the clubs one student belongs to.</summary>
        public DataTable GetClubsByStudent(int studentId)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Membership_GetClubsByStudent",
                DBHelper.Param("@StudentID", studentId));
        }

        /// <summary>
        /// Business operation used by the Memberships form: adds a student to
        /// a club as an Active member from today. The procedure rejects
        /// duplicates and inactive clubs. Returns the new MembershipID.
        /// </summary>
        public int AddStudentToClub(int studentId, int clubId, string role)
        {
            object newId = DBHelper.ExecuteScalar("dbo.sp_Membership_AddStudentToClub",
                DBHelper.Param("@StudentID", studentId),
                DBHelper.Param("@ClubID", clubId),
                DBHelper.Param("@Role", role));

            return Convert.ToInt32(newId);
        }

        /// <summary>
        /// Generic insert with every column (for example to back-date a join
        /// date). Returns the new MembershipID.
        /// </summary>
        public int Insert(Membership membership)
        {
            object newId = DBHelper.ExecuteScalar("dbo.sp_Membership_Insert",
                DBHelper.Param("@StudentID", membership.StudentID),
                DBHelper.Param("@ClubID", membership.ClubID),
                DBHelper.Param("@Role", membership.Role),
                DBHelper.Param("@JoinDate", membership.JoinDate.Date),
                DBHelper.Param("@Status", membership.Status));

            return Convert.ToInt32(newId);
        }

        /// <summary>Changes the role and status of a membership; returns the rows updated (1).</summary>
        public int Update(int membershipId, string role, string status)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Membership_Update",
                DBHelper.Param("@MembershipID", membershipId),
                DBHelper.Param("@Role", role),
                DBHelper.Param("@Status", status));
        }

        /// <summary>Removes a student from a club; returns the rows deleted (1).</summary>
        public int Delete(int membershipId)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Membership_Delete",
                DBHelper.Param("@MembershipID", membershipId));
        }

        /// <summary>Converts a result row into a Membership object.</summary>
        private static Membership Map(DataRow row)
        {
            return new Membership
            {
                MembershipID = Convert.ToInt32(row["MembershipID"]),
                StudentID = Convert.ToInt32(row["StudentID"]),
                ClubID = Convert.ToInt32(row["ClubID"]),
                Role = row["Role"] as string,
                JoinDate = Convert.ToDateTime(row["JoinDate"]),
                Status = row["Status"] as string,
                StudentName = row["StudentName"] as string,
                ClubName = row["ClubName"] as string
            };
        }
    }
}
