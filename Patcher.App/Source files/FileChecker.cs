using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patcher.App.Source_files
{
    class FileChecker
    {
        public static async Task CheckFiles()
        {
            try
            {
                foreach (Globals.File file in Globals.Files)
                {
                    Globals.FullSize += file.Size;

                    string fileName = Path.GetFileName(file.Name);
                    Common.ChangeStatus(Texts.Keys.CHECKFILE, fileName);

                    if (!File.Exists(file.Name) || await Common.GetHashAsync(file.Name) != file.Hash)
                    {
                        Globals.OldFiles.Add(file.Name);
                    }
                    else
                    {
                        Globals.CompleteSize += file.Size;
                    }

                    long currentProgress = Globals.CompleteSize + file.Size;
                    Common.UpdateCompleteProgress(Computer.Compute(Globals.FullSize, currentProgress));
                }

                await DownloadFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Überprüfen der Dateien: " + ex.Message);
            }
        }


        private static async Task DownloadFiles()
        {
            FileDownloader fileDownloader = new FileDownloader();
            foreach (string fileUrl in Globals.OldFiles)
            {
                string url = Path.Combine(Globals.ServerURL, fileUrl);
                string destinationPath = fileUrl;

                await fileDownloader.DownloadFileAsync(url, destinationPath);
            }
        }
    }
}
