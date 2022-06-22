using BInand;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Inand.Views
{
    public partial class FileCheckWindow : Window, INotifyPropertyChanged
    {
        #region Private Field
        private FileLoadingWindow? _loadingWin;
        private BackgroundWorker _worker = new();
        private readonly OpenFileDialog _dialog = new()
        {
            Title = "Select File",
            Filter = "All files (*.*)|*.*|IRL files (*.irl)|*.irl",
        };
        #endregion


        #region Property Filed
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
        #endregion


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public FileCheckWindow()
        {
            InitializeComponent();

            _worker.DoWork += Check_DoWork;
            _worker.RunWorkerCompleted += Check_Completed;
        }


        #region Worker
        private void Check_Completed(object? sender, RunWorkerCompletedEventArgs e)
        {
            _loadingWin?.Close();

            var code = (int)(e.Result ?? 1);
            if (code != 0)
            {
                MessageBox.Show("An error occurred while checking. Probable causes of the error:" +
                                "\n  + Broken file." +
                                "\n  + Invalid password." +
                                "\n  + File isn't container" +
                                "\n  + Drive empty" +
                                "\n\nCheck the Reasons given and Try Again.",
                                "File Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("The File is Complete and Can be (Mounted/Dismounted).",
                                "Information",
                                MessageBoxButton.OK,
                                MessageBoxImage.Asterisk);
                Close();
            }
        }
        private void Check_DoWork(object? sender, DoWorkEventArgs e)
        {
            e.Result = FileHelper.Check(FileName, Password);
        }
        #endregion


        #region Event
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (FileName.Length == 0 || Password.Length == 0)
            {
                MessageBox.Show("All Fields must be Filled. Fill in Fields and Try Again.",
                                "Input Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else if (!File.Exists(FileName))
            {
                MessageBox.Show("The specified Path isn't File. Check the file Path and Try Again.",
                                "File Error",
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
        #endregion


        #region Other
        private void win_Loaded(object sender, RoutedEventArgs e)
        {
            Interop.DeleteCloseAndIcon(this);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = ((PasswordBox)sender).Password;
        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            var result = _dialog.ShowDialog();
            if (result.HasValue ? result.Value : false)
            {
                FileName = _dialog.FileName;
            }
        }
        #endregion
    }
}
