using System.Windows;

namespace BInand
{
    public static class BInand
    {
        public static int Mount(string fileName, string folderName, char drive, string password)
        {
            var code = FileHelper.Unpack(fileName, folderName, password);

            return code != 0 ? code : MountHelper.Add(folderName, drive);
        }

        public static int Dismount(string fileName, string folderName, char drive, string password, CompressionMethod method, CompressionLevel level)
        {
            var code = FileHelper.Pack(fileName, folderName, password, method, level);

            return code != 0 ? code : MountHelper.Remove(drive);
        }
    }
}
