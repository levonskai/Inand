using BInand;
using Inand.Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Inand.Views
{
    public partial class FileDismountingWindow : Window, INotifyPropertyChanged
    {
        public MountedModel? Mounted { get; set; }

        public FileLoadingWindow _loadingWin;
        public BackgroundWorker _worker = new();

        private readonly SaveFileDialog _dialog = new()
        {
            Title = "Specify File.",
            Filter = "All files (*.*)|*.*|IRL files (*.irl)|*.irl",
            OverwritePrompt = false,
        };


        private string _fileName = string.Empty;
        public string? FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                NotifyPropertyChanged();
            }
        }

        private string _password = string.Empty;
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        private CompressionMethod _compressionMethod;
        public CompressionMethod CompressionMethod
        {
            get => _compressionMethod;
            set
            {
                _compressionMethod = value;
                NotifyPropertyChanged();
            }
        }

        private CompressionLevel _compressionLevel;
        public CompressionLevel CompressionLevel
        {
            get => _compressionLevel;
            set
            {
                _compressionLevel = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<CompressionMethod> CompressionMethodList { get; set; } = new()
        {
            CompressionMethod.LZMA,
            CompressionMethod.LZMA2,
            CompressionMethod.PPMd,
            CompressionMethod.BZip2
        };

        public ObservableCollection<CompressionLevel> CompressionLevelList { get; set; } = new()
        {
            CompressionLevel.Store,
            CompressionLevel.Fastest,
            CompressionLevel.Fast,
            CompressionLevel.Normal,
            CompressionLevel.Maximum,
            CompressionLevel.Ultra
        };


        public event PropertyChangedEventHandler? PropertyChanged;


        public FileDismountingWindow()
        {
            InitializeComponent();
        }

        public FileDismountingWindow(MountedModel mounted)
        {
            InitializeComponent();

            Title = $"Dismount Wizard - { mounted.Drive }:\\";

            Mounted = mounted;

            _worker.DoWork += Dismount_DoWork;
            _worker.RunWorkerCompleted += Dismount_Completed;
        }


        private void Dismount_Completed(object? sender, RunWorkerCompletedEventArgs e)
        {
            _loadingWin.Close();

            var code = (int)e.Result;
            if (code == 56)
            {
                MessageBox.Show("Invalid Password. Change password and Try Again.",
                                "Security Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else if (code != 0)
            {
                MessageBox.Show("An error occurred while mounting. Probable causes of the error:" +
                                "\n  + Broken file" +
                                "\n  + File isn't container" +
                                "\n  + Drive empty" +
                                "\n\nCheck the Reasons given and Try Again.",
                                "Input Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                Close();
            };
        }

        private void Dismount_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (File.Exists(FileName) && FileHelper.Check(FileName, Password) == 2)
            {
                e.Result = 56;
            }
            else
            {
                e.Result = BInand.BInand.Dismount(FileName, Mounted.FolderName, Mounted.Drive, Password, CompressionMethod, CompressionLevel);

                if ((int)e.Result == 0 && Argv.DeleteFolder)
                {
                    Directory.Delete(Mounted.FolderName, true);
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = (sender as PasswordBox).Password;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (FileName.Length == 0 || Password.Length == 0)
            {
                MessageBox.Show("All Fields must be Filled. Fill in Fields and Try Again.",
                                "Input Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                _worker.RunWorkerAsync();

                _loadingWin = new FileLoadingWindow();
                _loadingWin.ShowDialog();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            if (_dialog.ShowDialog().Value)
            {
                FileName = _dialog.FileName;
            }
        }

        private void win_Loaded(object sender, RoutedEventArgs e)
        {
            Interop.DeleteCloseAndIcon(this);
        }
    }
}
