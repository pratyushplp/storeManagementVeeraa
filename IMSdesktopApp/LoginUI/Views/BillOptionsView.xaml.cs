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
    /// Interaction logic for ReturnOptionsView.xaml
    /// </summary>
    public partial class BillOptionsView : Window
    {
        public BillOptionsView()
        {
            InitializeComponent();
        }

        private void BtnTransaction_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is TransactionView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                TransactionView transactionView = new TransactionView();
                transactionView.Show();
                transactionView.Activate();

            }

        }

        private void BtnBillHistory_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is HistoryBillView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                HistoryBillView historyView = new HistoryBillView();
                historyView.Show();
                historyView.Activate();

            }
        }
    }
}
