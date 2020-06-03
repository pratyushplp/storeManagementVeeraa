using LoginUI.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
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
    /// Interaction logic for ReturnView.xaml
    /// </summary>
    public partial class ReturnView : Window
    {
        public ReturnView()
        {
            InitializeComponent();
        }

        BillDAL billData = new BillDAL();
        TransactionDAL transactionDAL = new TransactionDAL();

        private static readonly Regex _regex = new Regex("[0-9]+");

        private string id;
        private float unitSellingPrice;
        private float qty;
        private float discountPercent;


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
            txtProductCode.Text = "";
            txtSoldQty.Text = "";
            id = "";
            discountPercent = 0;
            txtCreditAmount.Text = "";
            txtReturnQty.Text = "";

        }



        private void DataGridRowHeader_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            clear();
            DataRowView row = (DataRowView)dgvBills.SelectedItems[0];
            txtProductCode.Text = row["product_code"].ToString();
            txtSoldQty.Text = row["quantity"]?.ToString() ?? ""; // only if row[quantity] is not null ToString() method is called and if null replaced with ""
            id = row["Id"]?.ToString() ?? "";
            discountPercent = float.Parse(row["percentage_discount"]?.ToString())/100;
            unitSellingPrice = float.Parse(row["unit_selling_price"]?.ToString());

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsTextAllowed(txtSearch.Text))
            {
                int billNo = int.Parse(txtSearch.Text);

                {
                    DataTable dt = billData.Search(billNo);
                    dgvBills.ItemsSource = dt.DefaultView;
                }

            }

            else
            {
                MessageBox.Show("Enter Valid Bill Number!");
            }

        }

        private void btnReturn_Button_Click(object sender, RoutedEventArgs e)
        {
            // NOTE :- if productcode is blank then no preoduct is selected so cannot be returned 
            if (txtProductCode.Text == "")
            {
                // If value is not selected from data grid view then we cannot return it even when return button is clicked
                MessageBox.Show("Please select the product to be returned first.");
                return;
            }
            float updatedQty = float.Parse(txtSoldQty.Text) - float.Parse(txtReturnQty.Text);
            // return quantity constraints
            if ( IsTextAllowed(txtReturnQty.Text) && (float.Parse(txtReturnQty.Text) > 0) && (updatedQty) >= 0 )
            {
                // increase credit amount then update the quantity if partially returned and remove the row if completely returned
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to return these items?", "Return Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int billNo = Int32.Parse(txtSearch.Text);
                    //credit amount = unitcost * returnQty - discount % *(unitcost * returnQty) for that item
                    float discountOnReturnItem = discountPercent * (unitSellingPrice * float.Parse(txtReturnQty.Text));// ie discount % *(unitcost * returnQty) part
                    float creditAmount = unitSellingPrice * float.Parse(txtReturnQty.Text) - discountOnReturnItem;
                    //String.Format("{0:0.00}", 123.4567);      // "123.46"

                    txtCreditAmount.Text = String.Format("{0:0.00}", creditAmount);

                    //TransactionScope: For transactions, eg all the steps in the transaction should be completed for the transaction to actually happen,
                    //so transaction scope makes sure that either all the steps are carried out or non of it are.
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (billData.Update(billNo, id, float.Parse(txtReturnQty.Text), creditAmount, discountOnReturnItem))
                        {
                            billData.histInsert(billNo, txtProductCode.Text, float.Parse(txtReturnQty.Text), creditAmount);
                            MessageBox.Show("Product Returned Successfully");
                        }

                        else
                        {
                            MessageBox.Show("Product Could Not Be Returned", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        scope.Complete();

                    }
                }

            }

            else
            {
                MessageBox.Show("Invalid input on return quantity!");
            }
        }

      
    }
}
