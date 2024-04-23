using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patcher.App.Source_files
{
    class ListDownloader
    {
        public static async Task DownloadList()
        {
            try
            {
                Common.ChangeStatus(Texts.Keys.LISTDOWNLOAD);

                using (WebClient webClient = new WebClient())
                {
                    using (Stream stream = await webClient.OpenReadTaskAsync(Globals.ServerURL2 + Globals.PatchlistName))
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            while (!streamReader.EndOfStream)
                            {
                                ListProcessor.AddFile(await streamReader.ReadLineAsync());
                            }
                        }
                    }
                }

                await FileChecker.CheckFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Herunterladen der Liste: " + ex.Message);
            }
        }
    }
}
