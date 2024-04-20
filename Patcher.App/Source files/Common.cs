using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Cyclic.Redundancy.Check;

namespace Patcher.App.Source_files
{
    class Common
    {
        public static void ChangeStatus(Texts.Keys Key, params string[] Arguments)
        {
            Globals.pForm.Status.Text = Texts.GetText(Key, Arguments);
        }

        public static void UpdateCompleteProgress(long Value)
        {
            if (Value < 0 || Value > 100)
                return;

            Globals.pForm.completeProgress.Value = Convert.ToInt32(Value);
            Globals.pForm.completeProgressText.Text = Texts.GetText(Texts.Keys.COMPLETEPROGRESS, Value);
        }

        public static void UpdateCurrentProgress(long Value, double Speed)
        {
            if (Value < 0 || Value > 100)
                return;

            Globals.pForm.currentProgress.Value = Convert.ToInt32(Value);
            Globals.pForm.currentProgressText.Text = Texts.GetText(Texts.Keys.CURRENTPROGRESS, Value, Speed.ToString("0.00"));
        }

        public static async Task<string> GetHashAsync(string Name)
        {
            if (string.IsNullOrEmpty(Name) || !File.Exists(Name))
                return string.Empty;

            using (var crc = new CRC())
            using (var fileStream = File.Open(Name, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var hash = await Task.Run(() => BitConverter.ToString(crc.ComputeHash(fileStream)).Replace("-", "").ToLower());
                return hash;
            }
        }


        public static void EnableStart()
        {
            Globals.pForm.Start.Enabled = true;
        }

        public static bool IsGameRunning()
        {
            var processes = System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Globals.BinaryName));
            return processes.Length > 0;
        }
    }
}
