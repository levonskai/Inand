using System.Collections.Generic;
using System.Diagnostics;

namespace BInand
{
    public static class MountHelper
    {
        public const string ExecuteName = "SUBST.EXE";


        public static Dictionary<char, string> GetMountedList()
        {
            var mounted = new Dictionary<char, string>();

            var start = new ProcessStartInfo
            {
                FileName = ExecuteName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var proc = Process.Start(start);
            proc.WaitForExit();

            foreach (var line in proc.StandardOutput.ReadToEnd().Split('\n'))
            {
                if (line.Length > 0)
                {
                    var path = line[8..];
                    mounted.Add(line[0], path.Remove(path.Length - 1));
                }
            }

            return mounted;
        }

        public static int Add(string path, char drive)
        {
            var procInfo = new ProcessStartInfo
            {
                FileName = ExecuteName,
                Arguments = $"{drive}: \"{path}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden

            };
            var proc = Process.Start(procInfo);
            proc.WaitForExit();

            return proc.ExitCode;
        }

        public static int Remove(char drive)
        {
            var procInfo = new ProcessStartInfo
            {
                FileName = ExecuteName,
                Arguments = $"{drive}: /D",
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
