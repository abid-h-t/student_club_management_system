# Student Club Management System
The Student Club Management System is a desktop application for running the clubs of a university or college. Staff sign in, keep the lists of students and clubs up to date,  put students into clubs, organize club events, register students for those events and record who attended.

## Features
1. Login = Sign in with a username and password.
2. Dashboard = See live totals (students, clubs, active clubs, active memberships, upcoming events).
3. Clubs = Add, edit, delete and search clubs; mark a club active or inactive.
4. Students = Add, edit, delete, and search students; see which clubs a student belongs to.
5. memberships = Pick a club, see its members, add a student with a role, change the role or status, remove a member.
6. Events = Create, edit and delete events for a club, register students, mark attendance.
7. Reports = Club summary: member count, event count and upcoming events for each club.

## Relationships
1. A student can belong to many clubs and a club has many students.
2. A club organizes many events, each event belongs to one club.
3. A student can register for many events and en events has many students.
4. Users stands alone and is used only login.
