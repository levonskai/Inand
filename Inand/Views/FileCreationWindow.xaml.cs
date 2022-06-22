using BInand;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Inand.Views
{
    public partial class FileCreationWindow : Window, INotifyPropertyChanged
    {
        #region Private Field
        public FileLoadingWindow? _loadingWin;
        public BackgroundWorker _worker = new();

        private readonly SaveFileDialog _dialog = new()
        {
            Title = "Specify New File.",
            Filter = "All files (*.*)|*.*|IRL files (*.irl)|*.irl",
        };
        #endregion


        #region Property Field
        private string? _fileName = string.Empty;
        public string? FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                NotifyPropertyChanged();
            }
        }

        private string? _password = string.Empty;
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }
        #endregion


        public FileCreationWindow()
        {
            InitializeComponent();

            _worker.DoWork += Create_DoWork;
            _worker.RunWorkerCompleted += Create_Completed;
        }


        #region Worker
        private void Create_Completed(object? sender, RunWorkerCompletedEventArgs e)
        {
            _loadingWin?.Close();

            var code = (int)e.Result;

            if (code != 0)
            {
                MessageBox.Show("An error occurred while mounting. Probable causes of the error:" +
                                "\n  + Incorrect password;" +
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

        private void Create_DoWork(object? sender, DoWorkEventArgs e)
        {
            e.Result = FileHelper.New(FileName, Argv.FirstFileName, Password);
        }
        #endregion

        
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


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
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                }

                if (Password.Length < 8)
                {
                    var result = MessageBox.Show("The specified password isn't reliable. It is recommended to change password.\nContinue with this password ?",
                                                 "Security Warning",
                                                 MessageBoxButton.YesNo,
                                                 MessageBoxImage.Warning);
                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        _worker.RunWorkerAsync();

                        _loadingWin = new FileLoadingWindow();
                        _loadingWin.ShowDialog();
                    }
                }
                else
                {
                    _worker.RunWorkerAsync();

                    _loadingWin = new FileLoadingWindow();
                    _loadingWin.ShowDialog();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        #region Other
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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = ((PasswordBox)sender).Password;
        }
        #endregion
    }
}
