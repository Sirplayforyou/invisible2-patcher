using System;
using System.Windows.Forms;

namespace Patcher.App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Überprüfe, ob das Programm mit Administratorrechten gestartet wurde \\
            if (!AdminFunctions.IsAdministrator())
            {
                // Wenn nicht, starte das Programm erneut mit erhöhten Rechten \\
                AdminFunctions.RestartWithAdminRights();
                return;
            }
            // Sollte problemlos funktionieren \\

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new pForm());
        }
    }
}
