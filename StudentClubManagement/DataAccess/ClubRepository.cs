using System;
using System.Data;
using StudentClubManagement.Models;

namespace StudentClubManagement.DataAccess
{
    /// <summary>Data access for the Clubs table (stored procedures sp_Club_*).</summary>
    public class ClubRepository
    {
        /// <summary>Lists all clubs; pass true to hide inactive clubs.</summary>
        public DataTable GetAll(bool activeOnly = false)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Club_GetAll",
                DBHelper.Param("@ActiveOnly", activeOnly));
        }

        /// <summary>Loads one club, or null when the ID no longer exists.</summary>
        public Club GetById(int clubId)
        {
            DataTable table = DBHelper.ExecuteDataTable("dbo.sp_Club_GetByID",
                DBHelper.Param("@ClubID", clubId));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        /// <summary>Finds clubs whose name, category, advisor or description contains the keyword.</summary>
        public DataTable Search(string keyword)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Club_Search",
                DBHelper.Param("@Keyword", keyword));
        }

        /// <summary>Adds a club and returns the new ClubID.</summary>
        public int Insert(Club club)
        {
            object newId = DBHelper.ExecuteScalar("dbo.sp_Club_Insert",
                DBHelper.Param("@ClubName", club.ClubName),
                DBHelper.Param("@Description", club.Description),
                DBHelper.Param("@Category", club.Category),
                DBHelper.Param("@AdvisorName", club.AdvisorName),
                DBHelper.Param("@FoundedDate", club.FoundedDate.Date),
                DBHelper.Param("@IsActive", club.IsActive));

            return Convert.ToInt32(newId);
        }

        /// <summary>Saves changes to a club; returns the rows updated (1).</summary>
        public int Update(Club club)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Club_Update",
                DBHelper.Param("@ClubID", club.ClubID),
                DBHelper.Param("@ClubName", club.ClubName),
                DBHelper.Param("@Description", club.Description),
                DBHelper.Param("@Category", club.Category),
                DBHelper.Param("@AdvisorName", club.AdvisorName),
                DBHelper.Param("@FoundedDate", club.FoundedDate.Date),
                DBHelper.Param("@IsActive", club.IsActive));
        }

        /// <summary>Deletes a club. The procedure refuses if it has members or events.</summary>
        public int Delete(int clubId)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Club_Delete",
                DBHelper.Param("@ClubID", clubId));
        }

        /// <summary>Converts a result row into a Club object.</summary>
        private static Club Map(DataRow row)
        {
            return new Club
            {
                ClubID = Convert.ToInt32(row["ClubID"]),
                ClubName = row["ClubName"] as string,
                Description = row["Description"] as string,
                Category = row["Category"] as string,
                AdvisorName = row["AdvisorName"] as string,
                FoundedDate = Convert.ToDateTime(row["FoundedDate"]),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };
        }
    }
}
