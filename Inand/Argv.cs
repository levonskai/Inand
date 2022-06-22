using System;

namespace Inand
{
    public static class Argv
    {
        public static bool DeleteFolder { get; private set; } = true;

        public static string RootName
        {
            get => $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Inand";
        }

        public static string FirstFileName
        {
            get => $"{AppDomain.CurrentDomain.BaseDirectory}/First File.txt";
        }


        public static string GenerateFolderName()
        {
            return $"{RootName}/[{DateTime.Now.Year} {DateTime.Now.Month} {DateTime.Now.Day}] " +
                   $"{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second} ({DateTime.Now.Millisecond})";
        }

    }
}
