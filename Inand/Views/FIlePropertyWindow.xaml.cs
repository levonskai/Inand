using Inand.Models;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Inand.Views
{
    public partial class FIlePropertyWindow : Window, INotifyPropertyChanged
    {
        private MountedModel Mounted { get; set; }


        private string? _fileName;
        public string? FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                NotifyPropertyChanged();
            }
        }

        private char? _drive;
        public char? Drive
        {
            get => _drive;
            set
            {
                _drive = value;
                NotifyPropertyChanged();
            }
        }

        private long _fileSize;
        public long FileSize
        {
            get => _fileSize;
            set
            {
                _fileSize = value;
                NotifyPropertyChanged();
            }
        }

        private int? _fileCount;
        public int? FileCount
        {
            get => _fileCount;
            set
            {
                _fileCount = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        public FIlePropertyWindow()
        {
            InitializeComponent();
        }

        public FIlePropertyWindow(MountedModel mounted)
        {
            InitializeComponent();
            Mounted = mounted;


            Title = $"Property Wizard - {mounted.Drive}:\\";


            FileName = mounted.FolderName;
            Drive = mounted.Drive;
            FileCount = Directory.GetFiles(mounted.FolderName, "*", SearchOption.AllDirectories).Length;

            FileSize = DirSize(new DirectoryInfo(mounted.FolderName));
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void win_Loaded(object sender, RoutedEventArgs e)
        {
            Interop.DeleteCloseAndIcon(this);
        }

        public static long DirSize(DirectoryInfo dir)
        {
            return dir.GetFiles().Sum(fi => fi.Length) + dir.GetDirectories().Sum(di => DirSize(di));
        }
    }
}
