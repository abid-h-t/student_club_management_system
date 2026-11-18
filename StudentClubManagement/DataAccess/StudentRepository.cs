using System;
using System.Data;
using StudentClubManagement.Models;

namespace StudentClubManagement.DataAccess
{
    /// <summary>Data access for the Students table (stored procedures sp_Student_*).</summary>
    public class StudentRepository
    {
        /// <summary>Lists all students ordered by name.</summary>
        public DataTable GetAll()
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Student_GetAll");
        }

        /// <summary>Loads one student, or null when the ID no longer exists.</summary>
        public Student GetById(int studentId)
        {
            DataTable table = DBHelper.ExecuteDataTable("dbo.sp_Student_GetByID",
                DBHelper.Param("@StudentID", studentId));

            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        /// <summary>Finds students whose name, email, phone or department contains the keyword.</summary>
        public DataTable Search(string keyword)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Student_Search",
                DBHelper.Param("@Keyword", keyword));
        }

        /// <summary>Adds a student and returns the new StudentID.</summary>
        public int Insert(Student student)
        {
            object newId = DBHelper.ExecuteScalar("dbo.sp_Student_Insert",
                DBHelper.Param("@FirstName", student.FirstName),
                DBHelper.Param("@LastName", student.LastName),
                DBHelper.Param("@Email", student.Email),
                DBHelper.Param("@Phone", student.Phone),
                DBHelper.Param("@Department", student.Department),
                DBHelper.Param("@YearOfStudy", student.YearOfStudy));

            return Convert.ToInt32(newId);
        }

        /// <summary>Saves changes to a student; returns the rows updated (1).</summary>
        public int Update(Student student)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Student_Update",
                DBHelper.Param("@StudentID", student.StudentID),
                DBHelper.Param("@FirstName", student.FirstName),
                DBHelper.Param("@LastName", student.LastName),
                DBHelper.Param("@Email", student.Email),
                DBHelper.Param("@Phone", student.Phone),
                DBHelper.Param("@Department", student.Department),
                DBHelper.Param("@YearOfStudy", student.YearOfStudy));
        }

        /// <summary>Deletes a student. The procedure refuses if they have memberships or registrations.</summary>
        public int Delete(int studentId)
        {
            return DBHelper.ExecuteNonQuery("dbo.sp_Student_Delete",
                DBHelper.Param("@StudentID", studentId));
        }

        /// <summary>Converts a result row into a Student object.</summary>
        private static Student Map(DataRow row)
        {
            return new Student
            {
                StudentID = Convert.ToInt32(row["StudentID"]),
                FirstName = row["FirstName"] as string,
                LastName = row["LastName"] as string,
                Email = row["Email"] as string,
                Phone = row["Phone"] as string,
                Department = row["Department"] as string,
                YearOfStudy = Convert.ToInt32(row["YearOfStudy"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };
        }
    }
}
