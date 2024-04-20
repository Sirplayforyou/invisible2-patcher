using System;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patcher.App.Source_files
{
    class Networking
    {
        public static async Task CheckNetwork()
        {
            try
            {
                Common.ChangeStatus(Texts.Keys.CONNECTING);

                using (WebClient client = new WebClient())
                {
                    await client.OpenReadTaskAsync(Globals.ServerURL);
                }

                await ListDownloader.DownloadList();
            }
            catch
            {
                MessageBox.Show(Texts.GetText(Texts.Keys.NONETWORK));
                Application.Exit();
            }
        }
    }
}
