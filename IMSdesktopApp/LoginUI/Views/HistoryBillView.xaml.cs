using LoginUI.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ReturnHistoryView.xaml
    /// </summary>
    public partial class HistoryBillView : Window
    {
        public HistoryBillView()
        {
            InitializeComponent();
        }


        BillDAL billData = new BillDAL();

        private static readonly Regex _regex = new Regex("[0-9]+");


        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsTextAllowed(txtSearch.Text))
            {
                int billNo = int.Parse(txtSearch.Text);

                {
                    DataTable dt = billData.SearchHistBills(billNo);
                    dgvBillHistory.ItemsSource = dt.DefaultView;
                }

            }

            else
            {
                MessageBox.Show("Enter Valid Bill Number!");
            }

        }

        private void returnHistShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = billData.ShowBillHistory();
            dgvBillHistory.ItemsSource = dt.DefaultView;
        }

        private void DataGridRowHeader_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        // show all ShowHistoryReturn
    }
}
