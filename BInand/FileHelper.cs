using System.Diagnostics;

namespace BInand
{
    public static class FileHelper
    {
        public const string ExecuteName = "7Z.EXE";

        public static int New(string fileName, string sourceName, string password)
        {
            var procInfo = new ProcessStartInfo()
            {
                FileName = ExecuteName,
                Arguments = $"a \"{fileName}\" \"{sourceName}\" -p\"{password}\" -mhe -m0=lzma2 -mx=0",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            var proc = Process.Start(procInfo);
            proc.WaitForExit();

            return proc.ExitCode;
        }

        public static int Check(string fileName, string password)
        {
            var procInfo = new ProcessStartInfo()
            {
                FileName = ExecuteName,
                Arguments = $"l \"{fileName}\" -p\"{ password }\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            var proc = Process.Start(procInfo);
            proc.WaitForExit();

            return proc.ExitCode;
        }

        public static int Pack(string fileName, string folderName, string password, CompressionMethod method, CompressionLevel level)
        {
            var procInfo = new ProcessStartInfo()
            {
                FileName = ExecuteName,
                Arguments = $"a \"{fileName}\" \"{folderName}/*\" -p\"{password}\" -mhe -m0={method} -mx={(int)level}",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            var proc = Process.Start(procInfo);
            proc.WaitForExit();

            return proc.ExitCode;
        }

        public static int Unpack(string fileName, string destName, string password)
        {
            var procInfo = new ProcessStartInfo()
            {
                FileName = ExecuteName,
                Arguments = $"x -y \"{fileName}\" -o\"{destName}\" -p\"{password}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            var proc = Process.Start(procInfo);
            proc.WaitForExit();

            return proc.ExitCode;
        }
    }
}
