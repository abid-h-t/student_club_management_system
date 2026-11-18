using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StudentClubManagement.Utilities
{
    /// <summary>Message boxes, error display and grid set-up shared by all forms.</summary>
    public static class UiHelper
    {
        public const string AppTitle = "Student Club Management";

        /// <summary>
        /// Error numbers from 50000 upwards are raised on purpose by the stored
        /// procedures (THROW 5000x) and carry a message written for the user.
        /// </summary>
        private const int FirstCustomErrorNumber = 50000;

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>Asks a Yes/No question (No is the default button).</summary>
        public static bool Confirm(string question)
        {
            return MessageBox.Show(question, AppTitle, MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        /// <summary>Shows a validation message and puts the cursor in the offending control.</summary>
        public static void ShowValidation(string message, Control control)
        {
            ShowWarning(message);
            if (control != null && control.CanFocus)
            {
                control.Focus();
            }
        }

        /// <summary>
        /// Turns a SqlException into a message for the user:
        /// business-rule errors show the procedure's own text, constraint and
        /// connection problems get a plain-language explanation.
        /// </summary>
        public static void ShowSqlError(SqlException ex)
        {
            if (ex.Number >= FirstCustomErrorNumber)
            {
                ShowWarning(ex.Message); // message written in the stored procedure
                return;
            }

            switch (ex.Number)
            {
                case 2601:
                case 2627: // unique index / unique constraint
                    ShowWarning("This record already exists (a value that must be unique is duplicated).");
                    break;

                case 547: // foreign key or check constraint
                    ShowWarning("The database rejected this change because it conflicts with related records or a data rule.\n\nDetails: " + ex.Message);
                    break;

                case -2: // command timeout
                    ShowError("The database took too long to respond. Please try again.");
                    break;

                case -1:
                case 2:
                case 53:
                case 258:
                case 4060:
                case 18456: // server not found / database missing / login failed
                    ShowError("Could not connect to the database.\n\n" +
                              "Check that SQL Server is running, that the StudentClubDB.sql script has been run, " +
                              "and that the connection string in the application's .config file is correct.\n\n" +
                              "Details: " + ex.Message);
                    break;

                case 2812: // stored procedure missing
                    ShowError("A stored procedure is missing from the database. Re-run the StudentClubDB.sql script.\n\nDetails: " + ex.Message);
                    break;

                default:
                    ShowError("A database error occurred (error " + ex.Number + ").\n\nDetails: " + ex.Message);
                    break;
            }
        }

        /// <summary>Shows any non-database exception without crashing the application.</summary>
        public static void ShowUnexpectedError(Exception ex)
        {
            SqlException sqlException = ex as SqlException;
            if (sqlException != null)
            {
                ShowSqlError(sqlException);
                return;
            }

            ShowError("An unexpected error occurred.\n\nDetails: " + ex.Message);
        }

        /// <summary>
        /// Applies the standard read-only, full-row-select look to a grid and
        /// tidies it every time new data is bound to it.
        /// </summary>
        public static void ConfigureGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ApplyGridTheme(grid);
            grid.DataBindingComplete += Grid_DataBindingComplete;
        }

        /// <summary>
        /// Simple white grid look: default (white) background with blue,
        /// bold column header text - the same blue as the form text.
        /// </summary>
        private static void ApplyGridTheme(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false; // otherwise Windows ignores the header text colour

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 30;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.RoyalBlue;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.RoyalBlue;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // Data rows keep normal black text, even when the grid sits inside
            // a group box whose text is blue.
            grid.DefaultCellStyle.ForeColor = SystemColors.ControlText;

            grid.RowTemplate.Height = 26;
        }

        /// <summary>
        /// After binding: turn column names such as "ClubName" into headers
        /// such as "Club Name" and clear the automatic first-row selection.
        /// </summary>
        private static void Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.HeaderText = Regex.Replace(column.Name, "(?<=[a-z])(?=[A-Z])", " ");
            }

            grid.ClearSelection();
        }

        /// <summary>Hides columns (for example internal IDs) if they exist in the grid.</summary>
        public static void HideColumns(DataGridView grid, params string[] columnNames)
        {
            foreach (string name in columnNames)
            {
                if (grid.Columns.Contains(name))
                {
                    grid.Columns[name].Visible = false;
                }
            }
        }

        /// <summary>
        /// Makes the named columns wider than the others. Columns share the
        /// grid width in proportion to their weight (the default is 100).
        /// </summary>
        public static void SetColumnWeight(DataGridView grid, float weight, params string[] columnNames)
        {
            foreach (string name in columnNames)
            {
                if (grid.Columns.Contains(name))
                {
                    grid.Columns[name].FillWeight = weight;
                }
            }
        }

        /// <summary>
        /// Re-selects the row whose key column holds the given ID (used after
        /// a grid refresh). Returns false when the row is no longer listed.
        /// </summary>
        public static bool SelectRowById(DataGridView grid, string keyColumn, int id)
        {
            if (!grid.Columns.Contains(keyColumn))
            {
                return false;
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (Convert.ToInt32(row.Cells[keyColumn].Value) == id)
                {
                    row.Selected = true;
                    return true;
                }
            }

            return false;
        }
    }
}
