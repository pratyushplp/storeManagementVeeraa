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
    /// Interaction logic for CreditCustomer.xaml
    /// </summary>
    public partial class CreditCustomerView : Window
    {
        public CreditCustomerView()
        {
            InitializeComponent();
        }

        CreditCustomerDAL creditCustomerDAL = new CreditCustomerDAL();

        private static readonly Regex _regex = new Regex("[0-9.+-]+");
        private float creditAmount;

        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TxtQty_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        public void clear()
        {
            txtCreditAmount.Text = "";
            txtCustomerId.Text = "";
            txtCustomerName.Text = "";
            txtIncDescCredit.Text = "";
        }

        private void customerSearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable temp = new DataTable();
            temp = creditCustomerDAL.Search(txtSearch.Text);
            if(temp.Rows.Count == 0)
            {
                MessageBox.Show("Credit Customer not found!");
            }

            dgvCreditCustomer.ItemsSource = temp.DefaultView;

        }


        private void DataGridRowHeader_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            clear();
            DataRowView row = (DataRowView)dgvCreditCustomer.SelectedItems[0];
            txtCustomerName.Text = row["customer_name"].ToString();
            txtCustomerId.Text = row["Id"]?.ToString();
            creditAmount = float.Parse(row["credit_amount"].ToString());

        }


   

        //NOTE: positive balance means the customer owes the shop money, negetive balance means the shop owes the customer money
        private void btnUpdate_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtIncDescCredit.Text) && !string.IsNullOrWhiteSpace(txtCustomerId.Text) )
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Update Credit Balance Confirmation", System.Windows.MessageBoxButton.YesNo);
                float incDescAmount = float.Parse(txtIncDescCredit.Text);
                int id = Int32.Parse(txtCustomerId.Text) ;
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    bool success = creditCustomerDAL.UpdateCredit(incDescAmount, id);
                    if (success == true)
                    {
                        creditAmount = creditAmount + incDescAmount;
                        txtCreditAmount.Text = creditAmount.ToString();
                        MessageBox.Show("Credit balance of customer updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Could Not updater Credit balance of customer!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
            }

            else
            {
                MessageBox.Show("Please Enter the Correct amount to be increased/decreased.");
            }
            //resetting the value of credit amount

        }

    






        //BillDAL billData = new BillDAL();
        //private static readonly Regex _regex = new Regex("[0-9]+");


        //private static bool IsTextAllowed(string text)
        //{
        //    return _regex.IsMatch(text);
        //}


        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //}

        //private void TxtQty_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    e.Handled = !IsTextAllowed(e.Text);

        //}

        //public void clear()
        //{
        //    txtProductCode.Text = "";
        //    txtSoldQty.Text = "";



        //}



        //private void DataGridRowHeader_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    clear();
        //    DataRowView row = (DataRowView)dgvBills.SelectedItems[0];
        //    txtProductCode.Text = row["product_code"].ToString();
        //    txtSoldQty.Text = row["quantity"]?.ToString() ?? ""; // only if row[quantity] is not null ToString() method is called and if null replaced with ""

        //}

        //private void deleteButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void updateButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void searchButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (IsTextAllowed(txtSearch.Text))
        //    {
        //        int billNo = int.Parse(txtSearch.Text);

        //        {
        //            DataTable dt = billData.Search(billNo);
        //            dgvBills.ItemsSource = dt.DefaultView;
        //        }

        //    }

        //    else
        //    {
        //        MessageBox.Show("Enter Valid Bill Number!");
        //    }

        //}

        //private void btnReturn_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (IsTextAllowed(txtReturnQty.Text) && (Int32.Parse(txtReturnQty.Text) > 0) && (Int32.Parse(txtSoldQty.Text) - Int32.Parse(txtReturnQty.Text) >= 0))
        //    {
        //        // increase credit amount then update the quantity if partially returned and remove the row if completely returned
        //        MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to return these items?", "Return Confirmation", System.Windows.MessageBoxButton.YesNo);
        //        if (messageBoxResult == MessageBoxResult.Yes)
        //        {


        //        }

        //    }

        //    else
        //    {
        //        MessageBox.Show("Invalid input on return quantity!");
        //    }
        //}

        //private void btnReturnAll_Button_Click(object sender, RoutedEventArgs e)
        //{

        //}

    }
}
