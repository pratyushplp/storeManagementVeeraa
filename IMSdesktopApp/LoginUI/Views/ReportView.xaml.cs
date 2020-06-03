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
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : Window
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void BtnInventoryReport_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            // to make sure that only one window is opened 
            foreach(Window w in Application.Current.Windows)
            {
                if(w is InventoryReportView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if(!isOpen)
            {
                InventoryReportView inventoryReport = new InventoryReportView();
                inventoryReport.Show();
                inventoryReport.Activate();

            }


        }
        private void btnCashSalesReport_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            // to make sure that only one window is opened 
            foreach (Window w in Application.Current.Windows)
            {
                if (w is CashSalesReportView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen)
            {
                CashSalesReportView cashSalesReportView = new CashSalesReportView();
                cashSalesReportView.Show();
                cashSalesReportView.Activate();

            }

        }



        private void btnProductSalesReport_Click(object sender, RoutedEventArgs e)
        {

            bool isOpen = false;
            // to make sure that only one window is opened 
            foreach (Window w in Application.Current.Windows)
            {
                if (w is ProductSalesReportView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen)
            {
                ProductSalesReportView productSalesReport = new ProductSalesReportView();
                productSalesReport.Show();
                productSalesReport.Activate();

            }

        }

    
    }
}
