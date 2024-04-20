using System;
using System.IO;

namespace Patcher.App.Source_files
{
    public static class Logger
    {
        private static string logFilePath = "patcher_log.txt";

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}
