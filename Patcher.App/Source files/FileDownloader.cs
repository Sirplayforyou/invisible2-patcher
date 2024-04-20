using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Patcher.App.Source_files
{
    class FileDownloader
    {
        private int curFile;
        private long lastBytes;
        private long currentBytes;
        private Stopwatch stopWatch = new Stopwatch();
        private string patcherDirectory; // Dynamischer Pfad zum Patcher-Verzeichnis

        public FileDownloader()
        {
            // Setzen des Patcher-Verzeichnis relativ zum aktuellen Arbeitsverzeichnis
            patcherDirectory = Path.Combine(Directory.GetCurrentDirectory());
            Directory.CreateDirectory(patcherDirectory);
        }

        public async Task DownloadFileAsync(string url, string customDestinationPath)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    stopWatch.Start();
                    webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                    webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

                    string fileName = Path.GetFileName(url); // Dateiname extrahieren
                    string destinationPath = Path.Combine(patcherDirectory, fileName);


                    await webClient.DownloadFileTaskAsync(new Uri(url), destinationPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
            }
        }


        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            currentBytes = lastBytes + e.BytesReceived;

            Common.ChangeStatus(Texts.Keys.DOWNLOADFILE, Globals.OldFiles[curFile], Computer.ComputeDownloadSize(e.BytesReceived).ToString("0.00") + " MB ", Computer.ComputeDownloadSize(e.TotalBytesToReceive).ToString("0.00") + " MB");

            Common.UpdateCompleteProgress(Computer.Compute(Globals.CompleteSize, currentBytes));

            Common.UpdateCurrentProgress(e.ProgressPercentage, Computer.ComputeDownloadSpeed(e.BytesReceived, stopWatch));

        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lastBytes = currentBytes;

            Common.UpdateCurrentProgress(100, 0);

            curFile++;

            stopWatch.Reset();


            DownloadNextFile();
        }

        private async Task DownloadNextFile()
        {
            if (curFile < Globals.OldFiles.Count)
            {
                string url = Globals.OldFiles[curFile];
                string fileName = Path.GetFileName(url);
                string destinationPath = Path.Combine(patcherDirectory, fileName);


                await DownloadFileAsync(url, destinationPath);
            }
            else
            {
                Common.ChangeStatus(Texts.Keys.DOWNLOADCOMPLETE);
                Common.EnableStart();
            }
        }
    }
}
