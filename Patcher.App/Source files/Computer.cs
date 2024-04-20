using System.Diagnostics;

namespace Patcher.App.Source_files
{
    class Computer
    {
        public static long Compute(long Size, long FullSize)
        {
            return (Size * 100 / FullSize);
        }

        public static double ComputeDownloadSize(double Size)
        {
            return (Size / 1024d / 1024d);
        }

        public static double ComputeDownloadSpeed(double Size, Stopwatch stopWatch)
        {
            return (Size / 1024d / stopWatch.Elapsed.TotalSeconds);
        }
    }
}
