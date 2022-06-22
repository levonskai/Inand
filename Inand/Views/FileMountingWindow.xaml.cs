using BInand;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Inand.Views
{
    public partial class FileMountingWindow : Window, INotifyPropertyChanged
    {
        public FileLoadingWindow _loadingWin;
        public BackgroundWorker _worker = new();

        private readonly OpenFileDialog _dialog = new()
        {
            Title = "Select File",
            Filter = "All files (*.*)|*.*|IRL files (*.irl)|*.irl",
        };


        private string _fileName = string.Empty;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                NotifyPropertyChanged();
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        private char _drive;
        public char Drive
        {
            get => _drive;
            set
            {
                _drive = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<char> DriveList { get; set; } = new ();

        public event PropertyChangedEventHandler? PropertyChanged;


        public FileMountingWindow()
        {
            InitializeComponent();

            RefreshDriveList();

            _worker.DoWork += Mount_DoWork;
            _worker.RunWorkerCompleted += Mount_Completed;
        }

        private void Mount_Completed(object? sender, RunWorkerCompletedEventArgs e)
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
                                "\n  + Broken file." +
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
            }
        }

        private void Mount_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (FileHelper.Check(FileName, Password) == 2)
            {
                e.Result = 56;
            }
            else
            {
                e.Result = BInand.BInand.Mount(FileName, Argv.GenerateFolderName(), Drive, Password);
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
            if (FileName.Length == 0 || Password.Length == 0 || Drive == '\0')
            {
                MessageBox.Show("All Fields must be Filled. Fill in Fields and Try Again.",
                                "Input Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else if (!File.Exists(FileName))
            {
                MessageBox.Show("The specified Path isn't File. Check the file Path and Try Again.",
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

        private void RefreshList_Click(object sender, RoutedEventArgs e)
        {
            RefreshDriveList();
        }

        private void RefreshDriveList()
        {
            DriveList.Clear();

            for (int i = 65; i < 91; i++)
            {
                if (!Directory.Exists($"{(char)i}:/"))
                {
                    DriveList.Add((char)i);
                }
            }

            Drive = DriveList[0];
        }
    }
}
