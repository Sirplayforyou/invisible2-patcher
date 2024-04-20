using System;
using System.IO;

namespace Patcher.ListCreator
{

    public class RelativePathHelper
    {
        public static string GetRelativePath(string fromPath, string toPath)
        {
            if (string.IsNullOrEmpty(fromPath)) throw new ArgumentNullException(nameof(fromPath));
            if (string.IsNullOrEmpty(toPath)) throw new ArgumentNullException(nameof(toPath));

            Uri fromUri = new Uri(AppendDirectorySeparator(fromPath));
            Uri toUri = new Uri(AppendDirectorySeparator(toPath));

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);

            string relativePath = Uri.UnescapeDataString(relativeUri.ToString());
            relativePath = relativePath.Replace('/', Path.DirectorySeparatorChar);

            return relativePath;
        }

        private static string AppendDirectorySeparator(string path)
        {
            if (path.EndsWith(Path.DirectorySeparatorChar.ToString())) return path;
            return path + Path.DirectorySeparatorChar;
        }
    }
}