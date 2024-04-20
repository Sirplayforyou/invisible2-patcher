using Patcher.App.Source_files;
using System;
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

        private void Start_Click(object sender, EventArgs e)
        {
            Starter.Start();
        }
    }
}
