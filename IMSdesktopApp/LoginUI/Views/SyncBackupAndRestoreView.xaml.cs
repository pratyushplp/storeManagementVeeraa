using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GoogleDriveAPILibrary;

namespace LoginUI.Views
{
    /// <summary>
    /// Interaction logic for SyncBackupAndRestoreView.xaml
    /// </summary>
    public partial class SyncBackupAndRestoreView : Window
    {
        public SyncBackupAndRestoreView()
        {
            InitializeComponent();
        }


        private void BtnSyncDbToDrive_Click(object sender, RoutedEventArgs e)
        {
            string directoryPath = "C:\\VeeraaDatabaseBackup";
            var directory = new DirectoryInfo(directoryPath);
            //Note : To get the most recent files
            var myFile = directory.GetFiles()
                         .OrderByDescending(f => f.LastWriteTime)
                         .First().ToString();
            string filePath = System.IO.Path.Combine(directoryPath, myFile);

            MessageBox.Show("The latest database backup file inside 'C:\\VeeraaDatabaseBackup' folder will be uploaded to Google Drive. The process may take a while.", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);

           string clientId = "123";
           string clientSecret = "123";

           bool result = GoogleDriveRepo.UploadFile(GoogleDriveRepo.GetService(clientId, clientSecret), filePath);
           if(result == true)
            {
                MessageBox.Show("File Uploaded successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("File Could Not Be Uploaded!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void BtnBackupAndRestoreDb_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
