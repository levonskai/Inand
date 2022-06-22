using BInand;
using Inand.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Inand.Views
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();

            RefreshMountedList();
        }


        #region GENERAL
        private MountedModel? _selectedMount;
        public MountedModel? SelectedMount
        {
            get => _selectedMount;
            set
            {
                _selectedMount = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<MountedModel> MountedList { get; set; } = new();

        private void RefreshMountedList()
        {
            MountedList.Clear();
            SelectedMount = null;

            foreach (var m in MountHelper.GetMountedList())
            {
                MountedList.Add(new MountedModel { Drive = m.Key, FolderName = m.Value });
            }
        }

        private void Mount_Click(object sender, RoutedEventArgs e)
        {
            new FileMountingWindow().ShowDialog();

            RefreshMountedList();
        }

        private void Dismount_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMount == null)
            {
                MessageBox.Show("The Drive for dismounting isn't Specified. Select a Drive and Try Again.",
                                "Input Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                new FileDismountingWindow(SelectedMount).ShowDialog();
                RefreshMountedList();
            }
        }

        private void Property_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMount == null)
            {
                MessageBox.Show("The Drive for dismounting isn't Specified. Select a Drive and Try Again.",
                                "Input Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                new FIlePropertyWindow(SelectedMount).ShowDialog();
                RefreshMountedList();
            }
        }

        private void RefreshList_Click(object sender, RoutedEventArgs e)
        {
            RefreshMountedList();
        }
        #endregion


        #region TOOLS
        private void New_Click(object sender, RoutedEventArgs e)
        {
            new FileCreationWindow().ShowDialog();
        }

        private void ClearFolder_Click(object sender, RoutedEventArgs e)
        {
            var mounted = MountHelper.GetMountedList();
            var dirs = Directory.GetDirectories(Argv.RootName);

            foreach (var dir in dirs)
            {
                if (!mounted.ContainsValue(Path.GetFullPath(dir)))
                {
                    Directory.Delete(dir, true);
                }
            }

            MessageBox.Show("Unused Folders have been Cleaned and Deleted.",
                            "Information",
                            MessageBoxButton.OK,
                            MessageBoxImage.Asterisk);
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            new FileCheckWindow().ShowDialog();
        }

        private void Connection_Click(object sender, RoutedEventArgs e)
        {
            foreach (var m in MountHelper.GetMountedList())
            {
                if (!Directory.Exists($"{(int)m.Key}://"))
                {
                    MountHelper.Remove(m.Key);
                }
            }

            MessageBox.Show("All virtual Drives with Broken connection have been Dismounted.",
                            "Information",
                            MessageBoxButton.OK,
                            MessageBoxImage.Asterisk);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Decompress_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region ABOUT
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("EXPLORER.EXE", "https://github.com/levonskai/Inand");
        }
        #endregion
    }
}
