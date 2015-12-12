using Helenium.Tools;
using Helenium.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace Helenium.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var lang = ConfigurationManager.AppSettings.Get("Language");
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            if (!(SecurityHelpers.UserInSystemRole(System.Security.Principal.WindowsBuiltInRole.Administrator) ||
                SecurityHelpers.UserInSystemRole(System.Security.Principal.WindowsBuiltInRole.User)))
            {
                MessageBox.Show(null, Resources.Resources.AccessDenied, Resources.Resources.Permissionsneeded, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
