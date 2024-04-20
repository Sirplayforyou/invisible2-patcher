using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace Patcher.App
{
    public static class AdminFunctions
    {
        // Methode zur Überprüfung, ob das Programm mit Administratorrechten gestartet wurde
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        // Methode zum Neustart des Programms mit Administratorrechten
        public static void RestartWithAdminRights()
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas";
            try
            {
                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Die Anwendung konnte nicht mit Administratorrechten gestartet werden.");
            }
            Application.Exit();
        }
    }
}
