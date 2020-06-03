using System;
using System.Collections.Generic;
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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LoginUI.Data;
using System.Security.Cryptography;
using System.IO;

namespace LoginUI.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        
        public LoginView()
        {
            InitializeComponent();
        }

        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            DbClass.openConnection();
            DataTable loginDataTable = new DataTable();
            
            String encryptString = DbClass.Encrypt(txtPassword.Password.ToString());
            //sql data adapter to hold the value from database tempororily
            SqlDataAdapter da = new SqlDataAdapter(@"Select * from AdminUser where UserName = '" + txtUserName.Text + "' AND EncryptPassword = '" + encryptString + "'",DbClass.con);
            da.Fill(loginDataTable);
            if(loginDataTable.Rows.Count == 1)   
            {
                this.Hide();
                LoginUI.Views.DashboardView dashboard = new DashboardView();
                dashboard.Show();
                //MainWindow main = new MainWindow();
                //main.Show();

            }

            else
            {
                MessageBox.Show("Invalid Username & Password!", "Error",MessageBoxButton.OK, MessageBoxImage.Error);

            }         
            DbClass.closeConnection();

        }

        // Code for Encryption:





    }
}
