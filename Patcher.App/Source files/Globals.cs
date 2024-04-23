using System.Collections.Generic;

namespace Patcher.App.Source_files
{
    class Globals
    {
        public static string ServerURL      = "http://demo.alpha02.eu/tests/patch/Metin2_client";
        public static string ServerURL2     = "http://demo.alpha02.eu/tests/patch/patchlist/";
        public static string PatchlistName  = "patchlist.txt";
        public static string BinaryName     = "metin2client.exe";

        public static pForm pForm;

        public static List<File>    Files    = new List<File>();
        public static List<string>  OldFiles = new List<string>();

        public static long FullSize;
        public static long CompleteSize;

        public struct File
        {
            public string Name;
            public string Hash;
            public long   Size;
        }
    }
}
