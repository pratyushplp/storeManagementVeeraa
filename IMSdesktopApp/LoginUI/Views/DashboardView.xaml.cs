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

namespace LoginUI.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        private void ButtonPopUp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }





        private void BtnInventory_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is ProductView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {
                ProductView productView = new ProductView();
                productView.Show();
                productView.Activate();

            }

        }

        private void BtnBillOption_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is BillOptionsView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                BillOptionsView billOptionView = new BillOptionsView();
                //transactionView.Topmost = false;
                billOptionView.Show();
                billOptionView.Activate();

            }

        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is ReportView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                ReportView reportView = new ReportView();
                reportView.Show();
                reportView.Activate();

            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is ReturnOptionsView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                ReturnOptionsView returnView = new ReturnOptionsView();
                returnView.Show();
                returnView.Activate();

            }

        }

        private void BtnCreditCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is CreditCustomerOptionsView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                CreditCustomerOptionsView creditCustomerOptionsView  = new CreditCustomerOptionsView();
                creditCustomerOptionsView.Show();
                creditCustomerOptionsView.Activate();

            }
        }

        private void btnLoadToDb_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is ExcelToDbView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                ExcelToDbView excelToDb = new ExcelToDbView();
                excelToDb.Show();
                excelToDb.Activate();

            }

        }

        private void btnSyncBackupRestore_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is SyncBackupAndRestoreView)
                {
                    isOpen = true;
                    w.Activate();
                }
            }
            if (!isOpen) // ie if the window is not opened yet
            {
                SyncBackupAndRestoreView syncBackupAndRestoreView = new SyncBackupAndRestoreView();
                syncBackupAndRestoreView.Show();
                syncBackupAndRestoreView.Activate();
            }
        }
    }
}
