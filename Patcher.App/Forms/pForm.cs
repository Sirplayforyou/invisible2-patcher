using Patcher.App.Source_files;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patcher.App
{
    public partial class pForm : Form
    {
        public pForm()
        {
            InitializeComponent();
            Globals.pForm = this;

            // Setze das Formular in den Borderless-Modus
         //   this.FormBorderStyle = FormBorderStyle.None;

            // Setze eine benutzerdefinierte Größe, wenn nötig
       //     this.ClientSize = new Size(800, 600);
        }

        private async void pForm_Shown(object sender, EventArgs e)
        {
            if (Common.IsGameRunning())
            {
                Common.EnableStart();
            }
            else
            {
                await Networking.CheckNetwork();
            }
        }
/*
        private void pForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Ermöglicht das Verschieben des Formulars
            if (e.Button == MouseButtons.Left)
            {
                // Verwendet eine API-Funktion, um das Formular zu verschieben
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        public static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool ReleaseCapture();

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        }
*/

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Versuch, die config.exe zu starten
                System.Diagnostics.Process.Start("config.exe");
            }
            catch (Exception ex)
            {
                // Zeige eine Fehlermeldung, wenn ein Fehler auftritt
                MessageBox.Show("Die config.exe konnte nicht gestartet werden. Bitte stellen Sie sicher, dass die Datei vorhanden ist.",
                                "Fehler beim Start",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void Start_Click(object sender, EventArgs e)
        {
            Starter.Start();
        }

        private void pForm_Load(object sender, EventArgs e)
        {
            // Standardmäßig den Settings-Button deaktivieren
            settingsButton.Enabled = false;

            // Pfad der config.exe (relative oder absolut)
            string configPath = Path.Combine(Application.StartupPath, "config.exe");

            // Überprüfen, ob die Datei existiert
            if (File.Exists(configPath))
            {
                // Wenn gefunden, den Button aktivieren
                settingsButton.Enabled = true;

            }
        }
    }
}
