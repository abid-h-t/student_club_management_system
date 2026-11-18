using System;
using System.Windows.Forms;
using StudentClubManagement.Forms;
using StudentClubManagement.Utilities;

namespace StudentClubManagement
{
    internal static class Program
    {
        /// <summary>
        /// Application entry point: shows the login form, then the dashboard.
        /// Logging out of the dashboard returns to the login form.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Safety net: any exception a form did not handle is shown in a
            // message box instead of crashing the application.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) => UiHelper.ShowUnexpectedError(e.Exception);

            while (true)
            {
                using (LoginForm login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        return; // user closed the login form
                    }
                }

                using (MainForm main = new MainForm())
                {
                    Application.Run(main);

                    if (!main.LogoutRequested)
                    {
                        return; // main form closed normally -> exit
                    }
                }

                Session.CurrentUser = null; // logged out -> show login again
            }
        }
    }
}
