using LoginUI.Data;
using LoginUI.Models;
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
    /// Interaction logic for UpdateCreditCustomerView.xaml
    /// </summary>
    public partial class UpdateCreditCustomerView : Window
    {
        public UpdateCreditCustomerView()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        CreditCustomerDAL creditCustomerDAL = new CreditCustomerDAL();
        private static readonly Regex _regex = new Regex("[0-9.+-]+");

        int customerId;        //Note: while deleting or updating a customer , customer_id is used as a primary key


        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }

        public void clear()
        {
            txtCreditAmount.Text = "";
            txtCustomerName.Text = "";
            txtPhoneNumber.Text = "";
            customerId = 0;
        }

        private void TxtQty_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void customerShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable temp = new DataTable();
            temp = creditCustomerDAL.ShowAll();
            dgvCreditCustomer.ItemsSource = temp.DefaultView;
        }

        private void customerSearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable temp = new DataTable();
            temp = creditCustomerDAL.Search(txtSearch.Text);
            if (temp.Rows.Count == 0)
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
            customerId = Int32.Parse( row["Id"]?.ToString() );
            txtCreditAmount.Text = row["credit_amount"]?.ToString()?? "0";
            txtPhoneNumber.Text = row["phone_number"]?.ToString() ?? "";

        }

        private void btnAdd_Button_Click(object sender, RoutedEventArgs e)
        {
            CreditCustomer creditCustomer = new CreditCustomer();

            creditCustomer.customerName = txtCustomerName.Text;
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text)) creditCustomer.phoneNumber = "";
            else creditCustomer.phoneNumber = txtPhoneNumber.Text;
            if (string.IsNullOrWhiteSpace(txtCreditAmount.Text)) creditCustomer.creditAmount = 0;
            else creditCustomer.creditAmount = float.Parse(txtCreditAmount.Text);
            creditCustomer.addedDate = DateTime.Now;

            if(string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Customer Name is a Mandotory field! Please enter the customer name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool success = false;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Add Credit Customer Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                success=creditCustomerDAL.AddCreditCustomer(creditCustomer);
                if(success == true)
                {
                    clear();
                    MessageBox.Show("Credit Customer Added Successfully");

                }

                else
                {
                    MessageBox.Show("Failed To Add Credit Customer!");

                }
            }

        }

        private void btnDelete_Button_Click(object sender, RoutedEventArgs e)
        {
            // to make sure that delete operation can only be completed after selecting a row from the data grid view
            if (customerId == 0)
            {
                MessageBox.Show("Please search and select the customer to be deleted first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool success = false;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Credit Customer Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                success=creditCustomerDAL.DeleteCreditCustomer(customerId);
                if (success == true)
                {
                    clear();
                    MessageBox.Show("Credit Customer Deleted Successfully");

                }

                else
                {
                    MessageBox.Show("Failed To delete Credit Customer!");

                }
            }

        }


    }
}
