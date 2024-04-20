using Patcher.App.Source_files;
using System;
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
