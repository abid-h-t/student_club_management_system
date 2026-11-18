/* =====================================================================
   Student Club Management System - database script
   Target : Microsoft SQL Server (Express / LocalDB), database StudentClubDB

   Run this whole file in SSMS (F5) or with:
       sqlcmd -S .\SQLEXPRESS -E -C -i StudentClubDB.sql

   The script is RE-RUNNABLE: it drops StudentClubDB if it already exists
   and rebuilds it from scratch (tables, constraints, stored procedures and
   sample data).  WARNING: re-running it erases any data you added.

   Custom error numbers raised by the stored procedures (shown by the app):
       50001  invalid / missing input
       50002  record not found
       50003  duplicate record
       50004  delete blocked because related records exist
       50005  business rule violated (inactive club, event full, ...)
       50006  login failed
   ===================================================================== */

USE master;
GO

IF DB_ID(N'StudentClubDB') IS NOT NULL
BEGIN
    ALTER DATABASE StudentClubDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE StudentClubDB;
END
GO

CREATE DATABASE StudentClubDB;
GO

USE StudentClubDB;
GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

/* =====================================================================
   1. TABLES
   ===================================================================== */

CREATE TABLE dbo.Students
(
    StudentID   INT IDENTITY(1,1) NOT NULL,
    FirstName   NVARCHAR(50)  NOT NULL,
    LastName    NVARCHAR(50)  NOT NULL,
    Email       NVARCHAR(100) NOT NULL,
    Phone       NVARCHAR(20)  NULL,
    Department  NVARCHAR(100) NOT NULL,
    YearOfStudy TINYINT       NOT NULL,
    CreatedAt   DATETIME2(0)  NOT NULL CONSTRAINT DF_Students_CreatedAt DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_Students           PRIMARY KEY (StudentID),
    CONSTRAINT UQ_Students_Email     UNIQUE (Email),
    CONSTRAINT CK_Students_FirstName CHECK (LEN(LTRIM(RTRIM(FirstName))) > 0),
    CONSTRAINT CK_Students_LastName  CHECK (LEN(LTRIM(RTRIM(LastName))) > 0),
    CONSTRAINT CK_Students_Email     CHECK (Email LIKE N'_%@_%._%' AND Email NOT LIKE N'% %'),
    CONSTRAINT CK_Students_Year      CHECK (YearOfStudy BETWEEN 1 AND 6)
);
GO

CREATE TABLE dbo.Clubs
(
    ClubID      INT IDENTITY(1,1) NOT NULL,
    ClubName    NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Category    NVARCHAR(50)  NOT NULL,
    AdvisorName NVARCHAR(100) NULL,
    FoundedDate DATE          NOT NULL,
    IsActive    BIT           NOT NULL CONSTRAINT DF_Clubs_IsActive  DEFAULT (1),
    CreatedAt   DATETIME2(0)  NOT NULL CONSTRAINT DF_Clubs_CreatedAt DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_Clubs          PRIMARY KEY (ClubID),
    CONSTRAINT UQ_Clubs_ClubName UNIQUE (ClubName),
    CONSTRAINT CK_Clubs_ClubName CHECK (LEN(LTRIM(RTRIM(ClubName))) > 0),
    CONSTRAINT CK_Clubs_Founded  CHECK (FoundedDate >= '19000101')
);
GO

CREATE TABLE dbo.Memberships
(
    MembershipID INT IDENTITY(1,1) NOT NULL,
    StudentID    INT          NOT NULL,
    ClubID       INT          NOT NULL,
    Role         NVARCHAR(20) NOT NULL CONSTRAINT DF_Memberships_Role     DEFAULT (N'Member'),
    JoinDate     DATE         NOT NULL CONSTRAINT DF_Memberships_JoinDate DEFAULT (CAST(SYSDATETIME() AS DATE)),
    Status       NVARCHAR(10) NOT NULL CONSTRAINT DF_Memberships_Status   DEFAULT (N'Active'),
    CONSTRAINT PK_Memberships             PRIMARY KEY (MembershipID),
    CONSTRAINT FK_Memberships_Students    FOREIGN KEY (StudentID) REFERENCES dbo.Students (StudentID),
    CONSTRAINT FK_Memberships_Clubs       FOREIGN KEY (ClubID)    REFERENCES dbo.Clubs (ClubID),
    -- a student can join the same club only once
    CONSTRAINT UQ_Memberships_StudentClub UNIQUE (StudentID, ClubID),
    CONSTRAINT CK_Memberships_Role        CHECK (Role IN (N'Member', N'President', N'Vice President', N'Secretary', N'Treasurer')),
    CONSTRAINT CK_Memberships_Status      CHECK (Status IN (N'Active', N'Inactive'))
);
GO

CREATE TABLE dbo.Events
(
    EventID     INT IDENTITY(1,1) NOT NULL,
    ClubID      INT           NOT NULL,
    EventName   NVARCHAR(100) NOT NULL,
    EventDate   DATETIME2(0)  NOT NULL,
    Location    NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Capacity    INT           NOT NULL,
    CONSTRAINT PK_Events            PRIMARY KEY (EventID),
    CONSTRAINT FK_Events_Clubs      FOREIGN KEY (ClubID) REFERENCES dbo.Clubs (ClubID),
    CONSTRAINT UQ_Events_ClubNameDate UNIQUE (ClubID, EventName, EventDate),
    CONSTRAINT CK_Events_EventName  CHECK (LEN(LTRIM(RTRIM(EventName))) > 0),
    CONSTRAINT CK_Events_Capacity   CHECK (Capacity > 0)
);
GO

CREATE TABLE dbo.EventAttendance
(
    AttendanceID INT IDENTITY(1,1) NOT NULL,
    EventID      INT NOT NULL,
    StudentID    INT NOT NULL,
    Attended     BIT NOT NULL CONSTRAINT DF_EventAttendance_Attended DEFAULT (0),
    CONSTRAINT PK_EventAttendance              PRIMARY KEY (AttendanceID),
    CONSTRAINT FK_EventAttendance_Events       FOREIGN KEY (EventID)   REFERENCES dbo.Events (EventID),
    CONSTRAINT FK_EventAttendance_Students     FOREIGN KEY (StudentID) REFERENCES dbo.Students (StudentID),
    -- a student can register for the same event only once
    CONSTRAINT UQ_EventAttendance_EventStudent UNIQUE (EventID, StudentID)
);
GO

CREATE TABLE dbo.Users
(
    UserID       INT IDENTITY(1,1) NOT NULL,
    Username     NVARCHAR(50) NOT NULL,
    PasswordHash CHAR(64)     NOT NULL,   -- SHA-256 as 64 hex characters, never plain text
    Role         NVARCHAR(10) NOT NULL CONSTRAINT DF_Users_Role DEFAULT (N'Staff'),
    CONSTRAINT PK_Users          PRIMARY KEY (UserID),
    CONSTRAINT UQ_Users_Username UNIQUE (Username),
    CONSTRAINT CK_Users_Hash     CHECK (LEN(PasswordHash) = 64),
    CONSTRAINT CK_Users_Role     CHECK (Role IN (N'Admin', N'Staff'))
);
GO

-- Supporting indexes on the foreign keys that are not already covered by a UNIQUE constraint
CREATE INDEX IX_Memberships_ClubID        ON dbo.Memberships (ClubID);
CREATE INDEX IX_Events_ClubID_EventDate   ON dbo.Events (ClubID, EventDate);
CREATE INDEX IX_EventAttendance_StudentID ON dbo.EventAttendance (StudentID);
GO

/* =====================================================================
   2. STORED PROCEDURES - STUDENTS
   ===================================================================== */

-- Adds a student. Returns the new StudentID as a one-row result set.
CREATE PROCEDURE dbo.sp_Student_Insert
    @FirstName   NVARCHAR(50),
    @LastName    NVARCHAR(50),
    @Email       NVARCHAR(100),
    @Phone       NVARCHAR(20) = NULL,
    @Department  NVARCHAR(100),
    @YearOfStudy INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        SET @FirstName  = NULLIF(LTRIM(RTRIM(@FirstName)), N'');
        SET @LastName   = NULLIF(LTRIM(RTRIM(@LastName)), N'');
        SET @Email      = NULLIF(LTRIM(RTRIM(@Email)), N'');
        SET @Phone      = NULLIF(LTRIM(RTRIM(@Phone)), N'');
        SET @Department = NULLIF(LTRIM(RTRIM(@Department)), N'');

        IF @FirstName IS NULL  THROW 50001, N'First name is required.', 1;
        IF @LastName IS NULL   THROW 50001, N'Last name is required.', 1;
        IF @Email IS NULL      THROW 50001, N'Email is required.', 1;
        IF @Email NOT LIKE N'_%@_%._%' OR @Email LIKE N'% %' OR @Email LIKE N'%@%@%'
            THROW 50001, N'Email address is not in a valid format (example: name@university.edu).', 1;
        IF @Department IS NULL THROW 50001, N'Department is required.', 1;
        IF @YearOfStudy IS NULL OR @YearOfStudy NOT BETWEEN 1 AND 6
            THROW 50001, N'Year of study must be between 1 and 6.', 1;

        IF EXISTS (SELECT 1 FROM dbo.Students WHERE Email = @Email)
            THROW 50003, N'Another student is already registered with this email address.', 1;

        INSERT INTO dbo.Students (FirstName, LastName, Email, Phone, Department, YearOfStudy)
        VALUES (@FirstName, @LastName, @Email, @Phone, @Department, @YearOfStudy);

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS StudentID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Updates a student. RETURN value = rows updated (1).
CREATE PROCEDURE dbo.sp_Student_Update
    @StudentID   INT,
    @FirstName   NVARCHAR(50),
    @LastName    NVARCHAR(50),
    @Email       NVARCHAR(100),
    @Phone       NVARCHAR(20) = NULL,
    @Department  NVARCHAR(100),
    @YearOfStudy INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT;
    BEGIN TRY
        SET @FirstName  = NULLIF(LTRIM(RTRIM(@FirstName)), N'');
        SET @LastName   = NULLIF(LTRIM(RTRIM(@LastName)), N'');
        SET @Email      = NULLIF(LTRIM(RTRIM(@Email)), N'');
        SET @Phone      = NULLIF(LTRIM(RTRIM(@Phone)), N'');
        SET @Department = NULLIF(LTRIM(RTRIM(@Department)), N'');

        IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE StudentID = @StudentID)
            THROW 50002, N'Student not found. It may have been deleted by another user.', 1;

        IF @FirstName IS NULL  THROW 50001, N'First name is required.', 1;
        IF @LastName IS NULL   THROW 50001, N'Last name is required.', 1;
        IF @Email IS NULL      THROW 50001, N'Email is required.', 1;
        IF @Email NOT LIKE N'_%@_%._%' OR @Email LIKE N'% %' OR @Email LIKE N'%@%@%'
            THROW 50001, N'Email address is not in a valid format (example: name@university.edu).', 1;
        IF @Department IS NULL THROW 50001, N'Department is required.', 1;
        IF @YearOfStudy IS NULL OR @YearOfStudy NOT BETWEEN 1 AND 6
            THROW 50001, N'Year of study must be between 1 and 6.', 1;

        IF EXISTS (SELECT 1 FROM dbo.Students WHERE Email = @Email AND StudentID <> @StudentID)
            THROW 50003, N'Another student is already registered with this email address.', 1;

        UPDATE dbo.Students
        SET FirstName = @FirstName, LastName = @LastName, Email = @Email,
            Phone = @Phone, Department = @Department, YearOfStudy = @YearOfStudy
        WHERE StudentID = @StudentID;

        SET @Rows = @@ROWCOUNT;
        RETURN @Rows;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Deletes a student. Blocked while the student still has memberships or
-- event registrations (delete policy: block, never cascade).
CREATE PROCEDURE dbo.sp_Student_Delete
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT, @Memberships INT, @Registrations INT, @Msg NVARCHAR(400);
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.Students WITH (UPDLOCK, HOLDLOCK) WHERE StudentID = @StudentID)
            THROW 50002, N'Student not found. It may have already been deleted.', 1;

        SELECT @Memberships   = COUNT(*) FROM dbo.Memberships     WHERE StudentID = @StudentID;
        SELECT @Registrations = COUNT(*) FROM dbo.EventAttendance WHERE StudentID = @StudentID;

        IF @Memberships > 0 OR @Registrations > 0
        BEGIN
            SET @Msg = CONCAT(N'This student cannot be deleted because they still have ',
                              @Memberships, N' club membership(s) and ', @Registrations,
                              N' event registration(s). Remove those records first.');
            THROW 50004, @Msg, 1;
        END

        DELETE FROM dbo.Students WHERE StudentID = @StudentID;
        SET @Rows = @@ROWCOUNT;

        COMMIT TRANSACTION;
        RETURN @Rows;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Lists every student.
CREATE PROCEDURE dbo.sp_Student_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT StudentID, FirstName, LastName, Email, Phone, Department, YearOfStudy, CreatedAt
    FROM dbo.Students
    ORDER BY LastName, FirstName;
END
GO

-- Returns one student (zero rows when the ID does not exist).
CREATE PROCEDURE dbo.sp_Student_GetByID
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT StudentID, FirstName, LastName, Email, Phone, Department, YearOfStudy, CreatedAt
    FROM dbo.Students
    WHERE StudentID = @StudentID;
END
GO

-- Searches students by name, email, phone or department. Empty keyword = all.
CREATE PROCEDURE dbo.sp_Student_Search
    @Keyword NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Pattern NVARCHAR(102) = N'%' + LTRIM(RTRIM(ISNULL(@Keyword, N''))) + N'%';

    SELECT StudentID, FirstName, LastName, Email, Phone, Department, YearOfStudy, CreatedAt
    FROM dbo.Students
    WHERE FirstName LIKE @Pattern
       OR LastName LIKE @Pattern
       OR FirstName + N' ' + LastName LIKE @Pattern
       OR Email LIKE @Pattern
       OR ISNULL(Phone, N'') LIKE @Pattern
       OR Department LIKE @Pattern
    ORDER BY LastName, FirstName;
END
GO

/* =====================================================================
   3. STORED PROCEDURES - CLUBS
   ===================================================================== */

-- Adds a club. Returns the new ClubID as a one-row result set.
CREATE PROCEDURE dbo.sp_Club_Insert
    @ClubName    NVARCHAR(100),
    @Description NVARCHAR(500) = NULL,
    @Category    NVARCHAR(50),
    @AdvisorName NVARCHAR(100) = NULL,
    @FoundedDate DATE,
    @IsActive    BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        SET @ClubName    = NULLIF(LTRIM(RTRIM(@ClubName)), N'');
        SET @Description = NULLIF(LTRIM(RTRIM(@Description)), N'');
        SET @Category    = NULLIF(LTRIM(RTRIM(@Category)), N'');
        SET @AdvisorName = NULLIF(LTRIM(RTRIM(@AdvisorName)), N'');
        SET @IsActive    = ISNULL(@IsActive, 1);

        IF @ClubName IS NULL    THROW 50001, N'Club name is required.', 1;
        IF @Category IS NULL    THROW 50001, N'Category is required.', 1;
        IF @FoundedDate IS NULL THROW 50001, N'Founded date is required.', 1;
        IF @FoundedDate < '19000101' OR @FoundedDate > CAST(SYSDATETIME() AS DATE)
            THROW 50001, N'Founded date cannot be in the future (or before 1900).', 1;

        IF EXISTS (SELECT 1 FROM dbo.Clubs WHERE ClubName = @ClubName)
            THROW 50003, N'A club with this name already exists.', 1;

        INSERT INTO dbo.Clubs (ClubName, Description, Category, AdvisorName, FoundedDate, IsActive)
        VALUES (@ClubName, @Description, @Category, @AdvisorName, @FoundedDate, @IsActive);

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS ClubID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Updates a club. When an active club is switched to inactive, all of its
-- Active memberships are set to Inactive in the same transaction.
-- RETURN value = rows updated in Clubs (1).
CREATE PROCEDURE dbo.sp_Club_Update
    @ClubID      INT,
    @ClubName    NVARCHAR(100),
    @Description NVARCHAR(500) = NULL,
    @Category    NVARCHAR(50),
    @AdvisorName NVARCHAR(100) = NULL,
    @FoundedDate DATE,
    @IsActive    BIT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT, @WasActive BIT;
    BEGIN TRY
        SET @ClubName    = NULLIF(LTRIM(RTRIM(@ClubName)), N'');
        SET @Description = NULLIF(LTRIM(RTRIM(@Description)), N'');
        SET @Category    = NULLIF(LTRIM(RTRIM(@Category)), N'');
        SET @AdvisorName = NULLIF(LTRIM(RTRIM(@AdvisorName)), N'');

        IF @ClubName IS NULL    THROW 50001, N'Club name is required.', 1;
        IF @Category IS NULL    THROW 50001, N'Category is required.', 1;
        IF @FoundedDate IS NULL THROW 50001, N'Founded date is required.', 1;
        IF @FoundedDate < '19000101' OR @FoundedDate > CAST(SYSDATETIME() AS DATE)
            THROW 50001, N'Founded date cannot be in the future (or before 1900).', 1;
        IF @IsActive IS NULL    THROW 50001, N'The active flag is required.', 1;

        BEGIN TRANSACTION;

        SELECT @WasActive = IsActive
        FROM dbo.Clubs WITH (UPDLOCK, HOLDLOCK)
        WHERE ClubID = @ClubID;

        IF @WasActive IS NULL
            THROW 50002, N'Club not found. It may have been deleted by another user.', 1;

        IF EXISTS (SELECT 1 FROM dbo.Clubs WHERE ClubName = @ClubName AND ClubID <> @ClubID)
            THROW 50003, N'A club with this name already exists.', 1;

        UPDATE dbo.Clubs
        SET ClubName = @ClubName, Description = @Description, Category = @Category,
            AdvisorName = @AdvisorName, FoundedDate = @FoundedDate, IsActive = @IsActive
        WHERE ClubID = @ClubID;

        SET @Rows = @@ROWCOUNT;

        -- second write of the transaction: deactivating a club deactivates its memberships
        IF @WasActive = 1 AND @IsActive = 0
            UPDATE dbo.Memberships
            SET Status = N'Inactive'
            WHERE ClubID = @ClubID AND Status = N'Active';

        COMMIT TRANSACTION;
        RETURN @Rows;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Deletes a club. Blocked while the club still has memberships or events
-- (delete policy: block, never cascade). Use IsActive = 0 to retire a club.
CREATE PROCEDURE dbo.sp_Club_Delete
    @ClubID INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT, @Memberships INT, @Events INT, @Msg NVARCHAR(400);
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.Clubs WITH (UPDLOCK, HOLDLOCK) WHERE ClubID = @ClubID)
            THROW 50002, N'Club not found. It may have already been deleted.', 1;

        SELECT @Memberships = COUNT(*) FROM dbo.Memberships WHERE ClubID = @ClubID;
        SELECT @Events      = COUNT(*) FROM dbo.Events      WHERE ClubID = @ClubID;

        IF @Memberships > 0 OR @Events > 0
        BEGIN
            SET @Msg = CONCAT(N'This club cannot be deleted because it still has ',
                              @Memberships, N' membership(s) and ', @Events,
                              N' event(s). Remove those records first, or untick "Active" to retire the club instead.');
            THROW 50004, @Msg, 1;
        END

        DELETE FROM dbo.Clubs WHERE ClubID = @ClubID;
        SET @Rows = @@ROWCOUNT;

        COMMIT TRANSACTION;
        RETURN @Rows;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Lists clubs. @ActiveOnly = 1 hides inactive clubs.
CREATE PROCEDURE dbo.sp_Club_GetAll
    @ActiveOnly BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ClubID, ClubName, Category, AdvisorName, FoundedDate, IsActive, Description, CreatedAt
    FROM dbo.Clubs
    WHERE ISNULL(@ActiveOnly, 0) = 0 OR IsActive = 1
    ORDER BY ClubName;
END
GO

-- Returns one club (zero rows when the ID does not exist).
CREATE PROCEDURE dbo.sp_Club_GetByID
    @ClubID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ClubID, ClubName, Category, AdvisorName, FoundedDate, IsActive, Description, CreatedAt
    FROM dbo.Clubs
    WHERE ClubID = @ClubID;
END
GO

-- Searches clubs by name, category, advisor or description. Empty keyword = all.
CREATE PROCEDURE dbo.sp_Club_Search
    @Keyword NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Pattern NVARCHAR(102) = N'%' + LTRIM(RTRIM(ISNULL(@Keyword, N''))) + N'%';

    SELECT ClubID, ClubName, Category, AdvisorName, FoundedDate, IsActive, Description, CreatedAt
    FROM dbo.Clubs
    WHERE ClubName LIKE @Pattern
       OR Category LIKE @Pattern
       OR ISNULL(AdvisorName, N'') LIKE @Pattern
       OR ISNULL(Description, N'') LIKE @Pattern
    ORDER BY ClubName;
END
GO

/* =====================================================================
   4. STORED PROCEDURES - MEMBERSHIPS
   All membership result sets share the same columns so the app can bind
   any of them to the same grid.
   ===================================================================== */

-- Generic insert (all columns). Returns the new MembershipID as a result set.
CREATE PROCEDURE dbo.sp_Membership_Insert
    @StudentID INT,
    @ClubID    INT,
    @Role      NVARCHAR(20) = N'Member',
    @JoinDate  DATE = NULL,
    @Status    NVARCHAR(10) = N'Active'
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Msg NVARCHAR(400);
    BEGIN TRY
        SET @Role     = ISNULL(NULLIF(LTRIM(RTRIM(@Role)), N''), N'Member');
        SET @Status   = ISNULL(NULLIF(LTRIM(RTRIM(@Status)), N''), N'Active');
        SET @JoinDate = ISNULL(@JoinDate, CAST(SYSDATETIME() AS DATE));

        IF @Role NOT IN (N'Member', N'President', N'Vice President', N'Secretary', N'Treasurer')
            THROW 50001, N'Role must be Member, President, Vice President, Secretary or Treasurer.', 1;
        IF @Status NOT IN (N'Active', N'Inactive')
            THROW 50001, N'Status must be Active or Inactive.', 1;
        IF @JoinDate > CAST(SYSDATETIME() AS DATE)
            THROW 50001, N'Join date cannot be in the future.', 1;

        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE StudentID = @StudentID)
            THROW 50002, N'Student not found.', 1;
        IF NOT EXISTS (SELECT 1 FROM dbo.Clubs WHERE ClubID = @ClubID)
            THROW 50002, N'Club not found.', 1;

        IF EXISTS (SELECT 1 FROM dbo.Memberships WITH (UPDLOCK, HOLDLOCK)
                   WHERE StudentID = @StudentID AND ClubID = @ClubID)
            THROW 50003, N'This student is already a member of this club.', 1;

        -- each officer role can be held by only one active member per club
        IF @Role <> N'Member' AND @Status = N'Active'
           AND EXISTS (SELECT 1 FROM dbo.Memberships WITH (UPDLOCK, HOLDLOCK)
                       WHERE ClubID = @ClubID AND Role = @Role AND Status = N'Active')
        BEGIN
            SET @Msg = CONCAT(N'This club already has an active ', @Role, N'. Change that member''s role first.');
            THROW 50005, @Msg, 1;
        END

        INSERT INTO dbo.Memberships (StudentID, ClubID, Role, JoinDate, Status)
        VALUES (@StudentID, @ClubID, @Role, @JoinDate, @Status);

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS MembershipID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Changes the role and/or status of a membership. RETURN value = rows updated (1).
CREATE PROCEDURE dbo.sp_Membership_Update
    @MembershipID INT,
    @Role         NVARCHAR(20),
    @Status       NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT, @ClubID INT, @ClubActive BIT, @Msg NVARCHAR(400);
    BEGIN TRY
        SET @Role   = NULLIF(LTRIM(RTRIM(@Role)), N'');
        SET @Status = NULLIF(LTRIM(RTRIM(@Status)), N'');

        IF @Role IS NULL OR @Role NOT IN (N'Member', N'President', N'Vice President', N'Secretary', N'Treasurer')
            THROW 50001, N'Role must be Member, President, Vice President, Secretary or Treasurer.', 1;
        IF @Status IS NULL OR @Status NOT IN (N'Active', N'Inactive')
            THROW 50001, N'Status must be Active or Inactive.', 1;

        BEGIN TRANSACTION;

        SELECT @ClubID = m.ClubID, @ClubActive = c.IsActive
        FROM dbo.Memberships m WITH (UPDLOCK, HOLDLOCK)
        JOIN dbo.Clubs c ON c.ClubID = m.ClubID
        WHERE m.MembershipID = @MembershipID;

        IF @ClubID IS NULL
            THROW 50002, N'Membership not found. It may have been removed by another user.', 1;

        IF @Status = N'Active' AND @ClubActive = 0
            THROW 50005, N'A membership cannot be Active while its club is inactive. Reactivate the club first.', 1;

        -- each officer role can be held by only one active member per club
        IF @Role <> N'Member' AND @Status = N'Active'
           AND EXISTS (SELECT 1 FROM dbo.Memberships WITH (UPDLOCK, HOLDLOCK)
                       WHERE ClubID = @ClubID AND Role = @Role AND Status = N'Active'
                         AND MembershipID <> @MembershipID)
        BEGIN
            SET @Msg = CONCAT(N'This club already has an active ', @Role, N'. Change that member''s role first.');
            THROW 50005, @Msg, 1;
        END

        UPDATE dbo.Memberships
        SET Role = @Role, Status = @Status
        WHERE MembershipID = @MembershipID;

        SET @Rows = @@ROWCOUNT;

        COMMIT TRANSACTION;
        RETURN @Rows;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Removes a student from a club. RETURN value = rows deleted (1).
CREATE PROCEDURE dbo.sp_Membership_Delete
    @MembershipID INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT;
    BEGIN TRY
        DELETE FROM dbo.Memberships WHERE MembershipID = @MembershipID;
        SET @Rows = @@ROWCOUNT;

        IF @Rows = 0
            THROW 50002, N'Membership not found. It may have already been removed.', 1;

        RETURN @Rows;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Lists every membership with student and club names.
CREATE PROCEDURE dbo.sp_Membership_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.MembershipID, m.StudentID, s.FirstName + N' ' + s.LastName AS StudentName, s.Email,
           m.ClubID, c.ClubName, m.Role, m.JoinDate, m.Status
    FROM dbo.Memberships m
    JOIN dbo.Students s ON s.StudentID = m.StudentID
    JOIN dbo.Clubs    c ON c.ClubID    = m.ClubID
    ORDER BY c.ClubName, s.LastName, s.FirstName;
END
GO

-- Returns one membership (zero rows when the ID does not exist).
CREATE PROCEDURE dbo.sp_Membership_GetByID
    @MembershipID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.MembershipID, m.StudentID, s.FirstName + N' ' + s.LastName AS StudentName, s.Email,
           m.ClubID, c.ClubName, m.Role, m.JoinDate, m.Status
    FROM dbo.Memberships m
    JOIN dbo.Students s ON s.StudentID = m.StudentID
    JOIN dbo.Clubs    c ON c.ClubID    = m.ClubID
    WHERE m.MembershipID = @MembershipID;
END
GO

-- Searches memberships by student name, email, club name, role or status.
CREATE PROCEDURE dbo.sp_Membership_Search
    @Keyword NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Pattern NVARCHAR(102) = N'%' + LTRIM(RTRIM(ISNULL(@Keyword, N''))) + N'%';

    SELECT m.MembershipID, m.StudentID, s.FirstName + N' ' + s.LastName AS StudentName, s.Email,
           m.ClubID, c.ClubName, m.Role, m.JoinDate, m.Status
    FROM dbo.Memberships m
    JOIN dbo.Students s ON s.StudentID = m.StudentID
    JOIN dbo.Clubs    c ON c.ClubID    = m.ClubID
    WHERE s.FirstName + N' ' + s.LastName LIKE @Pattern
       OR s.Email LIKE @Pattern
       OR c.ClubName LIKE @Pattern
       OR m.Role LIKE @Pattern
       OR m.Status LIKE @Pattern
    ORDER BY c.ClubName, s.LastName, s.FirstName;
END
GO

-- Business procedure used by the Memberships form: adds a student to a club
-- as an Active member joining today. Rejects duplicates and inactive clubs.
-- Returns the new MembershipID as a result set.
CREATE PROCEDURE dbo.sp_Membership_AddStudentToClub
    @StudentID INT,
    @ClubID    INT,
    @Role      NVARCHAR(20) = N'Member'
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ClubActive BIT, @ClubName NVARCHAR(100), @Msg NVARCHAR(400);
    BEGIN TRY
        SET @Role = ISNULL(NULLIF(LTRIM(RTRIM(@Role)), N''), N'Member');

        IF @StudentID IS NULL THROW 50001, N'Please choose a student.', 1;
        IF @ClubID IS NULL    THROW 50001, N'Please choose a club.', 1;
        IF @Role NOT IN (N'Member', N'President', N'Vice President', N'Secretary', N'Treasurer')
            THROW 50001, N'Role must be Member, President, Vice President, Secretary or Treasurer.', 1;

        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE StudentID = @StudentID)
            THROW 50002, N'Student not found.', 1;

        SELECT @ClubActive = IsActive, @ClubName = ClubName
        FROM dbo.Clubs WITH (UPDLOCK, HOLDLOCK)
        WHERE ClubID = @ClubID;

        IF @ClubActive IS NULL
            THROW 50002, N'Club not found.', 1;

        IF @ClubActive = 0
        BEGIN
            SET @Msg = CONCAT(N'"', @ClubName, N'" is inactive, so new members cannot be added to it.');
            THROW 50005, @Msg, 1;
        END

        IF EXISTS (SELECT 1 FROM dbo.Memberships WITH (UPDLOCK, HOLDLOCK)
                   WHERE StudentID = @StudentID AND ClubID = @ClubID)
        BEGIN
            SET @Msg = CONCAT(N'This student is already a member of "', @ClubName,
                              N'". Change the status of the existing membership instead of adding it again.');
            THROW 50003, @Msg, 1;
        END

        -- each officer role can be held by only one active member per club
        IF @Role <> N'Member'
           AND EXISTS (SELECT 1 FROM dbo.Memberships WITH (UPDLOCK, HOLDLOCK)
                       WHERE ClubID = @ClubID AND Role = @Role AND Status = N'Active')
        BEGIN
            SET @Msg = CONCAT(N'This club already has an active ', @Role, N'. Change that member''s role first.');
            THROW 50005, @Msg, 1;
        END

        INSERT INTO dbo.Memberships (StudentID, ClubID, Role, JoinDate, Status)
        VALUES (@StudentID, @ClubID, @Role, CAST(SYSDATETIME() AS DATE), N'Active');

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS MembershipID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Lists the members of one club.
CREATE PROCEDURE dbo.sp_Membership_GetMembersByClub
    @ClubID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.MembershipID, m.StudentID, s.FirstName + N' ' + s.LastName AS StudentName, s.Email,
           m.ClubID, c.ClubName, m.Role, m.JoinDate, m.Status
    FROM dbo.Memberships m
    JOIN dbo.Students s ON s.StudentID = m.StudentID
    JOIN dbo.Clubs    c ON c.ClubID    = m.ClubID
    WHERE m.ClubID = @ClubID
    ORDER BY CASE m.Role WHEN N'President' THEN 1 WHEN N'Vice President' THEN 2
                         WHEN N'Secretary' THEN 3 WHEN N'Treasurer' THEN 4 ELSE 5 END,
             s.LastName, s.FirstName;
END
GO

-- Lists the clubs one student belongs to.
CREATE PROCEDURE dbo.sp_Membership_GetClubsByStudent
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.MembershipID, m.StudentID, s.FirstName + N' ' + s.LastName AS StudentName, s.Email,
           m.ClubID, c.ClubName, m.Role, m.JoinDate, m.Status
    FROM dbo.Memberships m
    JOIN dbo.Students s ON s.StudentID = m.StudentID
    JOIN dbo.Clubs    c ON c.ClubID    = m.ClubID
    WHERE m.StudentID = @StudentID
    ORDER BY c.ClubName;
END
GO

/* =====================================================================
   5. STORED PROCEDURES - EVENTS AND ATTENDANCE
   All event result sets share the same columns (including RegisteredCount).
   ===================================================================== */

-- Creates an event for an active club. Returns the new EventID as a result set.
CREATE PROCEDURE dbo.sp_Event_Insert
    @ClubID      INT,
    @EventName   NVARCHAR(100),
    @EventDate   DATETIME2(0),
    @Location    NVARCHAR(100),
    @Description NVARCHAR(500) = NULL,
    @Capacity    INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ClubActive BIT;
    BEGIN TRY
        SET @EventName   = NULLIF(LTRIM(RTRIM(@EventName)), N'');
        SET @Location    = NULLIF(LTRIM(RTRIM(@Location)), N'');
        SET @Description = NULLIF(LTRIM(RTRIM(@Description)), N'');

        IF @ClubID IS NULL    THROW 50001, N'Please choose the club that organises the event.', 1;
        IF @EventName IS NULL THROW 50001, N'Event name is required.', 1;
        IF @EventDate IS NULL THROW 50001, N'Event date is required.', 1;
        IF @EventDate < SYSDATETIME()
            THROW 50001, N'A new event must be scheduled in the future.', 1;
        IF @Location IS NULL  THROW 50001, N'Location is required.', 1;
        IF @Capacity IS NULL OR @Capacity < 1 OR @Capacity > 100000
            THROW 50001, N'Capacity must be a whole number between 1 and 100000.', 1;

        SELECT @ClubActive = IsActive FROM dbo.Clubs WHERE ClubID = @ClubID;

        IF @ClubActive IS NULL
            THROW 50002, N'Club not found.', 1;
        IF @ClubActive = 0
            THROW 50005, N'Events cannot be created for an inactive club.', 1;

        IF EXISTS (SELECT 1 FROM dbo.Events
                   WHERE ClubID = @ClubID AND EventName = @EventName AND EventDate = @EventDate)
            THROW 50003, N'This club already has an event with the same name at the same date and time.', 1;

        INSERT INTO dbo.Events (ClubID, EventName, EventDate, Location, Description, Capacity)
        VALUES (@ClubID, @EventName, @EventDate, @Location, @Description, @Capacity);

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS EventID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Updates an event. Capacity cannot drop below the number of students already
-- registered, and the date cannot be moved into the past.
-- RETURN value = rows updated (1).
CREATE PROCEDURE dbo.sp_Event_Update
    @EventID     INT,
    @ClubID      INT,
    @EventName   NVARCHAR(100),
    @EventDate   DATETIME2(0),
    @Location    NVARCHAR(100),
    @Description NVARCHAR(500) = NULL,
    @Capacity    INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT, @OldDate DATETIME2(0), @OldClubID INT, @ClubActive BIT,
            @Registered INT, @Msg NVARCHAR(400);
    BEGIN TRY
        SET @EventName   = NULLIF(LTRIM(RTRIM(@EventName)), N'');
        SET @Location    = NULLIF(LTRIM(RTRIM(@Location)), N'');
        SET @Description = NULLIF(LTRIM(RTRIM(@Description)), N'');

        IF @ClubID IS NULL    THROW 50001, N'Please choose the club that organises the event.', 1;
        IF @EventName IS NULL THROW 50001, N'Event name is required.', 1;
        IF @EventDate IS NULL THROW 50001, N'Event date is required.', 1;
        IF @Location IS NULL  THROW 50001, N'Location is required.', 1;
        IF @Capacity IS NULL OR @Capacity < 1 OR @Capacity > 100000
            THROW 50001, N'Capacity must be a whole number between 1 and 100000.', 1;

        BEGIN TRANSACTION;

        SELECT @OldDate = EventDate, @OldClubID = ClubID
        FROM dbo.Events WITH (UPDLOCK, HOLDLOCK)
        WHERE EventID = @EventID;

        IF @OldDate IS NULL
            THROW 50002, N'Event not found. It may have been deleted by another user.', 1;

        IF @EventDate <> @OldDate AND @EventDate < SYSDATETIME()
            THROW 50001, N'An event cannot be moved to a date in the past.', 1;

        SELECT @ClubActive = IsActive FROM dbo.Clubs WHERE ClubID = @ClubID;

        IF @ClubActive IS NULL
            THROW 50002, N'Club not found.', 1;
        IF @ClubActive = 0 AND @ClubID <> @OldClubID
            THROW 50005, N'An event cannot be moved to an inactive club.', 1;

        IF EXISTS (SELECT 1 FROM dbo.Events
                   WHERE ClubID = @ClubID AND EventName = @EventName AND EventDate = @EventDate
                     AND EventID <> @EventID)
            THROW 50003, N'This club already has an event with the same name at the same date and time.', 1;

        SELECT @Registered = COUNT(*) FROM dbo.EventAttendance WHERE EventID = @EventID;

        IF @Capacity < @Registered
        BEGIN
            SET @Msg = CONCAT(N'Capacity cannot be lower than the ', @Registered,
                              N' student(s) already registered for this event.');
            THROW 50005, @Msg, 1;
        END

        UPDATE dbo.Events
        SET ClubID = @ClubID, EventName = @EventName, EventDate = @EventDate,
            Location = @Location, Description = @Description, Capacity = @Capacity
        WHERE EventID = @EventID;

        SET @Rows = @@ROWCOUNT;

        COMMIT TRANSACTION;
        RETURN @Rows;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Deletes an event. Blocked while students are still registered for it
-- (delete policy: block, never cascade).
CREATE PROCEDURE dbo.sp_Event_Delete
    @EventID INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT, @Registered INT, @Msg NVARCHAR(400);
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.Events WITH (UPDLOCK, HOLDLOCK) WHERE EventID = @EventID)
            THROW 50002, N'Event not found. It may have already been deleted.', 1;

        SELECT @Registered = COUNT(*) FROM dbo.EventAttendance WHERE EventID = @EventID;

        IF @Registered > 0
        BEGIN
            SET @Msg = CONCAT(N'This event cannot be deleted because ', @Registered,
                              N' student(s) are registered for it. Unregister them first.');
            THROW 50004, @Msg, 1;
        END

        DELETE FROM dbo.Events WHERE EventID = @EventID;
        SET @Rows = @@ROWCOUNT;

        COMMIT TRANSACTION;
        RETURN @Rows;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Lists every event with its club name and registration count.
CREATE PROCEDURE dbo.sp_Event_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT e.EventID, e.ClubID, c.ClubName, e.EventName, e.EventDate, e.Location, e.Capacity,
           (SELECT COUNT(*) FROM dbo.EventAttendance a WHERE a.EventID = e.EventID) AS RegisteredCount,
           e.Description
    FROM dbo.Events e
    JOIN dbo.Clubs c ON c.ClubID = e.ClubID
    ORDER BY e.EventDate DESC, e.EventName;
END
GO

-- Returns one event (zero rows when the ID does not exist).
CREATE PROCEDURE dbo.sp_Event_GetByID
    @EventID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT e.EventID, e.ClubID, c.ClubName, e.EventName, e.EventDate, e.Location, e.Capacity,
           (SELECT COUNT(*) FROM dbo.EventAttendance a WHERE a.EventID = e.EventID) AS RegisteredCount,
           e.Description
    FROM dbo.Events e
    JOIN dbo.Clubs c ON c.ClubID = e.ClubID
    WHERE e.EventID = @EventID;
END
GO

-- Lists the events of one club.
CREATE PROCEDURE dbo.sp_Event_GetByClub
    @ClubID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT e.EventID, e.ClubID, c.ClubName, e.EventName, e.EventDate, e.Location, e.Capacity,
           (SELECT COUNT(*) FROM dbo.EventAttendance a WHERE a.EventID = e.EventID) AS RegisteredCount,
           e.Description
    FROM dbo.Events e
    JOIN dbo.Clubs c ON c.ClubID = e.ClubID
    WHERE e.ClubID = @ClubID
    ORDER BY e.EventDate DESC, e.EventName;
END
GO

-- Searches events by name, location, description or club name,
-- optionally limited to one club (@ClubID NULL = every club).
CREATE PROCEDURE dbo.sp_Event_Search
    @Keyword NVARCHAR(100) = NULL,
    @ClubID  INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Pattern NVARCHAR(102) = N'%' + LTRIM(RTRIM(ISNULL(@Keyword, N''))) + N'%';

    SELECT e.EventID, e.ClubID, c.ClubName, e.EventName, e.EventDate, e.Location, e.Capacity,
           (SELECT COUNT(*) FROM dbo.EventAttendance a WHERE a.EventID = e.EventID) AS RegisteredCount,
           e.Description
    FROM dbo.Events e
    JOIN dbo.Clubs c ON c.ClubID = e.ClubID
    WHERE (@ClubID IS NULL OR e.ClubID = @ClubID)
      AND (e.EventName LIKE @Pattern
           OR e.Location LIKE @Pattern
           OR ISNULL(e.Description, N'') LIKE @Pattern
           OR c.ClubName LIKE @Pattern)
    ORDER BY e.EventDate DESC, e.EventName;
END
GO

-- Registers a student for an event. Enforces: event still upcoming, no
-- duplicate registration, capacity not exceeded. The event row is locked
-- for the duration of the transaction so two users cannot take the last seat.
-- Returns the new AttendanceID as a result set.
CREATE PROCEDURE dbo.sp_Event_RegisterStudent
    @EventID   INT,
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Capacity INT, @EventDate DATETIME2(0), @EventName NVARCHAR(100),
            @Registered INT, @Msg NVARCHAR(400);
    BEGIN TRY
        IF @EventID IS NULL   THROW 50001, N'Please select an event.', 1;
        IF @StudentID IS NULL THROW 50001, N'Please choose a student.', 1;

        BEGIN TRANSACTION;

        SELECT @Capacity = Capacity, @EventDate = EventDate, @EventName = EventName
        FROM dbo.Events WITH (UPDLOCK, HOLDLOCK)
        WHERE EventID = @EventID;

        IF @Capacity IS NULL
            THROW 50002, N'Event not found.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE StudentID = @StudentID)
            THROW 50002, N'Student not found.', 1;

        IF @EventDate < SYSDATETIME()
            THROW 50005, N'This event has already taken place, so registration is closed.', 1;

        IF EXISTS (SELECT 1 FROM dbo.EventAttendance WHERE EventID = @EventID AND StudentID = @StudentID)
            THROW 50003, N'This student is already registered for this event.', 1;

        SELECT @Registered = COUNT(*) FROM dbo.EventAttendance WHERE EventID = @EventID;

        IF @Registered >= @Capacity
        BEGIN
            SET @Msg = CONCAT(N'"', @EventName, N'" is full (', @Registered, N' of ', @Capacity,
                              N' places taken). No more students can be registered.');
            THROW 50005, @Msg, 1;
        END

        INSERT INTO dbo.EventAttendance (EventID, StudentID, Attended)
        VALUES (@EventID, @StudentID, 0);

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS AttendanceID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Removes a student's registration from an event. RETURN value = rows deleted (1).
CREATE PROCEDURE dbo.sp_Event_UnregisterStudent
    @EventID   INT,
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT;
    BEGIN TRY
        DELETE FROM dbo.EventAttendance
        WHERE EventID = @EventID AND StudentID = @StudentID;

        SET @Rows = @@ROWCOUNT;

        IF @Rows = 0
            THROW 50002, N'This student is not registered for this event.', 1;

        RETURN @Rows;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Marks a registered student as attended (1) or not attended (0).
-- RETURN value = rows updated (1).
CREATE PROCEDURE dbo.sp_Event_MarkAttendance
    @EventID   INT,
    @StudentID INT,
    @Attended  BIT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Rows INT;
    BEGIN TRY
        IF @Attended IS NULL
            THROW 50001, N'The attended flag is required.', 1;

        UPDATE dbo.EventAttendance
        SET Attended = @Attended
        WHERE EventID = @EventID AND StudentID = @StudentID;

        SET @Rows = @@ROWCOUNT;

        IF @Rows = 0
            THROW 50002, N'This student is not registered for this event, so attendance cannot be marked.', 1;

        RETURN @Rows;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Lists the students registered for one event.
CREATE PROCEDURE dbo.sp_Event_GetAttendees
    @EventID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT a.AttendanceID, a.EventID, a.StudentID,
           s.FirstName + N' ' + s.LastName AS StudentName, s.Email, s.Department, a.Attended
    FROM dbo.EventAttendance a
    JOIN dbo.Students s ON s.StudentID = a.StudentID
    WHERE a.EventID = @EventID
    ORDER BY s.LastName, s.FirstName;
END
GO

/* =====================================================================
   6. STORED PROCEDURES - LOGIN, REPORT, DASHBOARD
   ===================================================================== */

-- Validates a username and SHA-256 password hash (64 hex characters).
-- Returns the user row on success; raises 50006 on failure.
CREATE PROCEDURE dbo.sp_User_Login
    @Username     NVARCHAR(50),
    @PasswordHash CHAR(64)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        SET @Username = NULLIF(LTRIM(RTRIM(@Username)), N'');

        IF @Username IS NULL
            THROW 50001, N'Username is required.', 1;
        IF @PasswordHash IS NULL OR LEN(@PasswordHash) <> 64
            THROW 50001, N'Password is required.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.Users
                       WHERE Username = @Username AND PasswordHash = UPPER(@PasswordHash))
            THROW 50006, N'Invalid username or password.', 1;

        SELECT UserID, Username, Role
        FROM dbo.Users
        WHERE Username = @Username AND PasswordHash = UPPER(@PasswordHash);
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- One row per club: member counts, event counts and the next upcoming event.
CREATE PROCEDURE dbo.sp_Report_ClubSummary
    @ActiveOnly BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Now DATETIME2(0) = SYSDATETIME();

    SELECT c.ClubID, c.ClubName, c.Category, c.AdvisorName, c.IsActive,
           (SELECT COUNT(*) FROM dbo.Memberships m
             WHERE m.ClubID = c.ClubID AND m.Status = N'Active')              AS ActiveMembers,
           (SELECT COUNT(*) FROM dbo.Memberships m WHERE m.ClubID = c.ClubID) AS TotalMembers,
           (SELECT COUNT(*) FROM dbo.Events e WHERE e.ClubID = c.ClubID)      AS TotalEvents,
           (SELECT COUNT(*) FROM dbo.Events e
             WHERE e.ClubID = c.ClubID AND e.EventDate >= @Now)               AS UpcomingEvents,
           (SELECT TOP (1) e.EventName FROM dbo.Events e
             WHERE e.ClubID = c.ClubID AND e.EventDate >= @Now
             ORDER BY e.EventDate)                                            AS NextEventName,
           (SELECT MIN(e.EventDate) FROM dbo.Events e
             WHERE e.ClubID = c.ClubID AND e.EventDate >= @Now)               AS NextEventDate
    FROM dbo.Clubs c
    WHERE ISNULL(@ActiveOnly, 0) = 0 OR c.IsActive = 1
    ORDER BY c.ClubName;
END
GO

-- One row with the totals shown on the dashboard.
CREATE PROCEDURE dbo.sp_Dashboard_GetStats
AS
BEGIN
    SET NOCOUNT ON;
    SELECT (SELECT COUNT(*) FROM dbo.Students)                                AS TotalStudents,
           (SELECT COUNT(*) FROM dbo.Clubs)                                   AS TotalClubs,
           (SELECT COUNT(*) FROM dbo.Clubs WHERE IsActive = 1)                AS ActiveClubs,
           (SELECT COUNT(*) FROM dbo.Memberships WHERE Status = N'Active')    AS ActiveMemberships,
           (SELECT COUNT(*) FROM dbo.Events WHERE EventDate >= SYSDATETIME()) AS UpcomingEvents;
END
GO

/* =====================================================================
   7. SAMPLE DATA
   Event dates are calculated from the day the script is run, so there are
   always both past and upcoming events.
   ===================================================================== */
SET NOCOUNT ON;

-- Login accounts. Passwords are stored only as SHA-256 hashes.
--   admin / admin123   (Admin)
--   staff / staff123   (Staff)
INSERT INTO dbo.Users (Username, PasswordHash, Role) VALUES
(N'admin', CONVERT(CHAR(64), HASHBYTES('SHA2_256', CAST('admin123' AS VARCHAR(100))), 2), N'Admin'),
(N'staff', CONVERT(CHAR(64), HASHBYTES('SHA2_256', CAST('staff123' AS VARCHAR(100))), 2), N'Staff');

INSERT INTO dbo.Students (FirstName, LastName, Email, Phone, Department, YearOfStudy) VALUES
(N'Aisha',   N'Rahman',   N'aisha.rahman@university.edu',   N'555-0101', N'Computer Science',        2),  -- 1
(N'Daniel',  N'Okafor',   N'daniel.okafor@university.edu',  N'555-0102', N'Electrical Engineering',  3),  -- 2
(N'Mei',     N'Tanaka',   N'mei.tanaka@university.edu',     N'555-0103', N'Fine Arts',               1),  -- 3
(N'Lucas',   N'Fernandez',N'lucas.fernandez@university.edu',N'555-0104', N'Business Administration', 4),  -- 4
(N'Priya',   N'Nair',     N'priya.nair@university.edu',     N'555-0105', N'Computer Science',        3),  -- 5
(N'Omar',    N'Haddad',   N'omar.haddad@university.edu',    NULL,        N'Mathematics',             2),  -- 6
(N'Sofia',   N'Kowalski', N'sofia.kowalski@university.edu', N'555-0107', N'English Literature',      1),  -- 7
(N'Ethan',   N'Brooks',   N'ethan.brooks@university.edu',   N'555-0108', N'Mechanical Engineering',  2),  -- 8
(N'Hana',    N'Yilmaz',   N'hana.yilmaz@university.edu',    N'555-0109', N'Physics',                 4),  -- 9
(N'Noah',    N'Mensah',   N'noah.mensah@university.edu',    NULL,        N'Computer Science',        1),  -- 10
(N'Zara',    N'Ahmed',    N'zara.ahmed@university.edu',     N'555-0111', N'Business Administration', 3),  -- 11
(N'Tomas',   N'Novak',    N'tomas.novak@university.edu',    N'555-0112', N'Fine Arts',               2);  -- 12

INSERT INTO dbo.Clubs (ClubName, Description, Category, AdvisorName, FoundedDate, IsActive) VALUES
(N'Robotics Club',       N'Designs and builds robots for regional competitions.',  N'Technology', N'Dr. Helen Park',     '2015-09-01', 1),  -- 1
(N'Programming Society', N'Weekly coding sessions, hackathons and tech talks.',     N'Technology', N'Dr. Samuel Osei',    '2012-02-15', 1),  -- 2
(N'Drama Society',       N'Stages two productions every academic year.',            N'Arts',       N'Ms. Clara Bennett',  '2008-10-20', 1),  -- 3
(N'Chess Club',          N'Casual play, coaching and inter-university tournaments.',N'Games',      N'Mr. Viktor Petrov',  '2010-03-05', 1),  -- 4
(N'Photography Club',    N'Photo walks, editing workshops and exhibitions.',        N'Arts',       N'Ms. Amara Diallo',   '2018-01-12', 1),  -- 5
(N'Film Appreciation Club', N'Screenings and discussions (currently not running).', N'Arts',       NULL,                  '2016-11-03', 0);  -- 6 (inactive)

INSERT INTO dbo.Memberships (StudentID, ClubID, Role, JoinDate, Status) VALUES
-- Robotics Club
(1,  1, N'President',      '2024-09-10', N'Active'),
(2,  1, N'Vice President', '2024-09-12', N'Active'),
(8,  1, N'Treasurer',      '2025-02-01', N'Active'),
(10, 1, N'Member',         '2025-09-15', N'Active'),
-- Programming Society
(5,  2, N'President',      '2023-10-01', N'Active'),
(1,  2, N'Secretary',      '2024-10-05', N'Active'),
(6,  2, N'Member',         '2025-01-20', N'Active'),
(10, 2, N'Member',         '2025-09-18', N'Active'),
(9,  2, N'Member',         '2023-10-10', N'Inactive'),
-- Drama Society
(7,  3, N'President',      '2025-09-05', N'Active'),
(3,  3, N'Member',         '2025-09-07', N'Active'),
(12, 3, N'Secretary',      '2024-09-20', N'Active'),
-- Chess Club
(6,  4, N'President',      '2024-03-11', N'Active'),
(9,  4, N'Member',         '2022-10-02', N'Active'),
(4,  4, N'Member',         '2023-02-14', N'Active'),
-- Photography Club
(3,  5, N'President',      '2025-09-09', N'Active'),
(12, 5, N'Member',         '2024-10-01', N'Active'),
(11, 5, N'Treasurer',      '2024-10-03', N'Active'),
-- Film Appreciation Club (inactive club -> inactive memberships)
(7,  6, N'Member',         '2024-11-10', N'Inactive'),
(4,  6, N'Member',         '2022-11-15', N'Inactive');

DECLARE @Today DATETIME2(0) = CAST(CAST(SYSDATETIME() AS DATE) AS DATETIME2(0));

INSERT INTO dbo.Events (ClubID, EventName, EventDate, Location, Description, Capacity) VALUES
(1, N'Robot Building Workshop', DATEADD(HOUR, 14, DATEADD(DAY,   7, @Today)), N'Engineering Lab 2',   N'Hands-on introduction to building a line-following robot.', 30),  -- 1 upcoming
(1, N'Arduino Starter Lab',     DATEADD(HOUR, 16, DATEADD(DAY,  12, @Today)), N'Engineering Lab 1',   N'Small-group lab - only three places available.',             3),  -- 2 upcoming, nearly full
(2, N'Autumn Hackathon',        DATEADD(HOUR,  9, DATEADD(DAY,  21, @Today)), N'Innovation Hub',      N'24-hour team coding challenge with prizes.',                 60),  -- 3 upcoming
(3, N'Open Auditions',          DATEADD(HOUR, 17, DATEADD(DAY,  10, @Today)), N'Main Theatre',        N'Auditions for the winter production.',                       40),  -- 4 upcoming
(4, N'Rapid Chess Tournament',  DATEADD(HOUR, 10, DATEADD(DAY,  14, @Today)), N'Student Union Room B',N'Five-round Swiss tournament, 15 minutes per player.',        16),  -- 5 upcoming
(2, N'Welcome Tech Talk',       DATEADD(HOUR, 18, DATEADD(DAY, -30, @Today)), N'Lecture Hall A',      N'Introduction to the society and its projects.',             100),  -- 6 past
(5, N'Campus Photo Walk',       DATEADD(HOUR, 15, DATEADD(DAY, -10, @Today)), N'Main Quad',           N'Guided walk practising composition and lighting.',           20);  -- 7 past

INSERT INTO dbo.EventAttendance (EventID, StudentID, Attended) VALUES
-- Robot Building Workshop (upcoming)
(1, 1, 0), (1, 2, 0), (1, 10, 0), (1, 8, 0),
-- Arduino Starter Lab (upcoming, capacity 3, two places taken)
(2, 2, 0), (2, 10, 0),
-- Autumn Hackathon (upcoming)
(3, 5, 0), (3, 1, 0), (3, 6, 0),
-- Rapid Chess Tournament (upcoming)
(5, 6, 0), (5, 9, 0), (5, 4, 0),
-- Welcome Tech Talk (past, attendance recorded)
(6, 5, 1), (6, 1, 1), (6, 6, 0), (6, 10, 1), (6, 9, 1),
-- Campus Photo Walk (past, attendance recorded)
(7, 3, 1), (7, 12, 1), (7, 11, 0);
GO

/* =====================================================================
   8. SUMMARY (shown in the Messages tab so you can confirm the script ran)
   ===================================================================== */
SET NOCOUNT ON;
SELECT 'Students' AS TableName, COUNT(*) AS [Rows] FROM dbo.Students
UNION ALL SELECT 'Clubs',           COUNT(*) FROM dbo.Clubs
UNION ALL SELECT 'Memberships',     COUNT(*) FROM dbo.Memberships
UNION ALL SELECT 'Events',          COUNT(*) FROM dbo.Events
UNION ALL SELECT 'EventAttendance', COUNT(*) FROM dbo.EventAttendance
UNION ALL SELECT 'Users',           COUNT(*) FROM dbo.Users;

SELECT COUNT(*) AS StoredProcedures FROM sys.procedures WHERE name LIKE N'sp[_]%';

PRINT 'StudentClubDB created successfully. Default login: admin / admin123';
GO
