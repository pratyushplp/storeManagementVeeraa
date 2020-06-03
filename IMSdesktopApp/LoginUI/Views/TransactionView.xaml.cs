using LoginUI.Data;
using LoginUI.Models;
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
    /// Interaction logic for BillingView.xaml
    /// </summary>
    public partial class TransactionView : Window
    {
        private float subTotal=0;
        private bool checkDiscount = false;
        private string comboBankName="";
        //regular expression to make sure only numerical fields are input
        private static readonly Regex _regex = new Regex("[0-9.]+");
        private float tempDiscount = 0;
        private int creditCustomerId;
        private string creditCustomerName;

        DataTable transactionTable = new DataTable();

        ProductDAL productDal = new ProductDAL();
        TransactionDAL transactionDAL = new TransactionDAL();
        TransactionDetailDAL detailDAL = new TransactionDetailDAL();
        BankInfoDAL bankInfoDAL = new BankInfoDAL();
        CreditCustomerDAL creditCustomerDAL = new CreditCustomerDAL();

 

        public TransactionView()
        {
            InitializeComponent();
        }


        // funcition to clear all the values in data grid
        public void clearProductDetail()
        {
            txtProductCode.Text = "";
            txtProductType.Text ="";
            txtInventoryQty.Text ="0";
            txtPrice.Text = "0";
            txtQty.Text = "0";
        }

        public void clearCalculationDetail()
        {
            txtSubTotal.Text = "0";
            txtDiscount.Text = "0";
            txtVAT.Text = "0";
            txtTotalAmount.Text = "0";
            txtPaidAmount.Text = "0";
            txtReturnAmount.Text = "0";

        }

        public string CheckNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return "0";
            }

            return value;
        }

        public void updateQuantity()
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            transactionTable.Columns.Add("Product Code");
            transactionTable.Columns.Add("Product Type");
            transactionTable.Columns.Add("Quantity",typeof(float));
            transactionTable.Columns.Add("Unit Price");
            transactionTable.Columns.Add("Total Price");
            // currently bill number is string change it to String if required and do the required manipulation below
            // example if xy123-78, manipulate it accordingly to give increasing bill number everytime
            float num= float.Parse( CheckNull(transactionDAL.SearchLatestBillNumber()) );
            // to increase the latest bill number and provide the new one 
            txtBillNo.Text = (++num).ToString();



        }

        private void CheckBill_Checked(object sender, RoutedEventArgs e)
        {
            txtBillNo.IsReadOnly = false;
        }

        private void CheckBill_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBillNo.IsReadOnly = true;
        }


        private void TxtProductCode_TextChanged(object sender, TextChangedEventArgs e)
       {
            Product product = new Product();
            string keyword = txtProductCode.Text;
            if(keyword!="" && keyword!= null)
            {
                product = productDal.searchTransaction(keyword);
                txtInventoryQty.Text = product.remainingUnit.ToString();
                txtProductType.Text = product.productType;
                txtPrice.Text = product.sellingPrice.ToString();
               
                
            }
        }

        private  void addButton_Click(object sender, RoutedEventArgs e)
        {
            string productCode = txtProductCode.Text;
            string productType = txtProductType.Text;
            float inventoryQty = float.Parse(txtInventoryQty.Text);
            float qty = float.Parse(CheckNull(txtQty.Text));
            float price = float.Parse(txtPrice.Text);
            float total = qty * price;
            subTotal = float.Parse(CheckNull(txtSubTotal.Text));

            if (qty <= 0)
            {
                MessageBox.Show("Please enter valid quantity first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                transactionTable.Rows.Clear();
                dgTransaction.Items.Refresh();
                clearProductDetail();
            }
            else
            {

                subTotal = total + subTotal;
                txtSubTotal.Text = subTotal.ToString();
                //main part : the added products are loaded in the transaction table
                transactionTable.Rows.Add(productCode, productType, qty, price, total);
                dgTransaction.ItemsSource = transactionTable.DefaultView;
                txtSubTotal.Text = subTotal.ToString();
                clearProductDetail();
            }


            //if (productType == "")
            //{
            //    MessageBox.Show("Please select the product first.");
            //}
            //else 
            //{
            //subTotal = total + subTotal;
            //txtSubTotal.Text = subTotal.ToString();
            //transactionTable.Rows.Add(productCode,productType,qty,price,total);
            //dgTransaction.ItemsSource = transactionTable.DefaultView;
            //txtSubTotal.Text = subTotal.ToString();
            //clearProductDetail();

            //}


        }



        private void txtDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            // set discount field mandatory

            if (checkDiscount == true)
            {
                float subtotal = float.Parse(txtSubTotal.Text);
                float discount = float.Parse(CheckNull(txtDiscount.Text));
                tempDiscount = (((100 - discount) / 100) * subtotal);
                txtTotalAmount.Text = tempDiscount.ToString();
            }
            else
            {
                float subtotal = float.Parse(txtSubTotal.Text);
                float discount = float.Parse(CheckNull(txtDiscount.Text));
                txtTotalAmount.Text = (subtotal - discount).ToString();
            }

        }

        private void TxtVAT_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtTotalAmount.Text == "")
            {
                MessageBox.Show("Please insert discount % first");
            }
            else
            {
                float subtotal = float.Parse(txtSubTotal.Text);
                float discount = float.Parse(CheckNull(txtDiscount.Text));
                float vat = float.Parse(CheckNull(txtVAT.Text));
                float totalAmount = 0;
                if (checkDiscount == true)
                {
                     totalAmount = ((100 - discount) / 100) * subtotal;
                }
                else
                {
                     totalAmount = subtotal - discount;

                }
                txtTotalAmount.Text = (((vat + 100) / 100) * totalAmount).ToString();
            }
        }

        private void TxtPaidAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            float totalAmount = float.Parse(txtTotalAmount.Text);
            float paidAmount = float.Parse(CheckNull(txtPaidAmount.Text));
            txtReturnAmount.Text = String.Format("{0:0.00}", (paidAmount - totalAmount) ); 

        }

        private  void btnSave_Button_Click(object sender, RoutedEventArgs e)
        {
           int year = int.Parse(datePicker.SelectedDate.Value.Year.ToString());
           int month = int.Parse(datePicker.SelectedDate.Value.Month.ToString());
           int day = int.Parse(datePicker.SelectedDate.Value.Day.ToString());
           int hour = int.Parse(DateTime.Now.Hour.ToString());
           int min = int.Parse(DateTime.Now.Minute.ToString());
           int sec = int.Parse(DateTime.Now.Second.ToString());
           DateTime dt = new DateTime(year,month,day,hour,min,sec);
            // to get payment method
           string paymentMethod = getPaymentMethod();

            //] add null check, not mandatory as already handled before but if possible add
            var value = transactionTable.AsEnumerable().Sum(r => r.Field<float>("Quantity"));

            //var Total = gen.InvoiceDetails.AsEnumerable().Sum(x=>x.Field<int>("TotalPrice"));

            BillingTransaction transaction = new BillingTransaction();
            transaction.totalAmount = float.Parse(CheckNull(txtTotalAmount.Text));


            if(checkDiscount == true)
            {
                transaction.discount = tempDiscount;
            }
            else
            {
                transaction.discount = float.Parse(CheckNull(txtDiscount.Text));
            }

            transaction.VAT = float.Parse(CheckNull(txtVAT.Text));
            transaction.transactionDate = dt;
            transaction.billNumber = int.Parse(txtBillNo.Text);
            //for banking
            transaction.paymentMethod = paymentMethod;
            transaction.bankName = comboBankName;
            transaction.totalQty = value;




            //Restriction: to not allow the transaction to be saved if no products are added
            if (txtSubTotal.Text.Equals("0"))
            {
                MessageBox.Show("Cannot save this transaction, please add products.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                // code to clear all values in datagrid
                transactionTable.Rows.Clear();
                dgTransaction.ItemsSource = null;
                dgTransaction.Items.Refresh();
                return;
            }

            //Restriction: to make bank name compulasary while making credit card payments
            if (transaction.paymentMethod.Equals("Credit Card", StringComparison.InvariantCultureIgnoreCase) && String.IsNullOrEmpty(transaction.bankName))
            {
                MessageBox.Show("Cannot save this transaction, please select the bank name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }


            bool IsSuccess = false;

            //TransactionScope: For transactions, eg all the steps in the transaction should be completed for the transaction to actually happen,
            //so transaction scope makes sure that either all the steps are carried out or non of it are.
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // to update the bank balance ONLY for credit card payment
                    bool incBalance = true;
                    if (transaction.paymentMethod.Equals("Credit Card", StringComparison.InvariantCultureIgnoreCase))
                    {                       
                        incBalance = bankInfoDAL.IncreaseBankBalance(transaction.totalAmount, transaction.bankName);
                    }
                    //to increase the creadit balance of credit customer
                    bool creditBalance= true;
                    if (transaction.paymentMethod.Equals("Credit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        //Popup returns a bool to see if credit credintials are valid or not, then fills creditCustomerName and Id field  
                        bool checkCrCustomer = Popup();

                        //exit if credit customer credintials are wrong
                        if (checkCrCustomer == false) return;

                        creditBalance = creditCustomerDAL.UpdateCredit(transaction.totalAmount, creditCustomerId);
                        transaction.customerName = creditCustomerName;
                        //NOTE customer ID in transactioTable is of string dataType, so convert it to strigng, in credit customer it is of int datatype
                        transaction.customerId = creditCustomerId.ToString();

                    }
                
                    // create boolean value to insert transaction, insert transaction object only after complete objeect is formed
                    bool transIn = transactionDAL.insert(transaction);

                    for (int i = 0; i < transactionTable.Rows.Count; i++)
                    {
                        TransactionDetail transactionDetail = new TransactionDetail();
                        transactionDetail.productCode = transactionTable.Rows[i][0].ToString();
                        transactionDetail.productType = transactionTable.Rows[i][1].ToString();
                        transactionDetail.quantity = float.Parse(transactionTable.Rows[i][2].ToString());
                        transactionDetail.unitSellingPrice = float.Parse(transactionTable.Rows[i][3].ToString());
                        transactionDetail.totalSellingPrice = float.Parse(transactionTable.Rows[i][4].ToString());
                        transactionDetail.billNumber = int.Parse(txtBillNo.Text);

                        //insert transaction into the table
                        bool detailIn = detailDAL.insert(transactionDetail);

                        //decrease product from  ProductTable
                        Product product = new Product();
                        product = productDal.searchTransaction(transactionDetail.productCode);
                        float inventoryQty = product.remainingUnit;

                        bool decreaseQty = transactionDAL.DecreaseProduct(transactionDetail.productCode, transactionDetail.quantity, inventoryQty);
                        if(detailIn== false || decreaseQty == false)
                        {
                            IsSuccess = false;
                            break;
                        }

                        IsSuccess = transIn && detailIn && decreaseQty && incBalance && creditBalance;

                    }

                    if (IsSuccess == true)
                    {
                        // code to clear all the rows from temporary table transactionTable
                        transactionTable.Rows.Clear();

                        // code to clear all values in datagrid
                        dgTransaction.ItemsSource = null;
                        dgTransaction.Items.Refresh();

                        // to clear all the fields in calculation details
                        clearCalculationDetail();

                        // currently bill number is string change it to String if required and do the required manipulation below,  example if xy123-78, manipulate it accordingly to give increasing bill number everytime
                        float num = float.Parse(CheckNull(transactionDAL.SearchLatestBillNumber()));
                        // to increase the latest bill number and provide the new one 
                        txtBillNo.Text = (++num).ToString();

                        scope.Complete();
                        MessageBox.Show("Transaction Completed and Saved Successfully");


                    }

                    else
                    {
                        MessageBox.Show("Transaction Failed");
                    }

                }

         
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);

                }

            }

        }

        private void txtSubTotal_TextChanged(object sender, TextChangedEventArgs e)
        {

            float subtotal = float.Parse(txtSubTotal.Text);
            if (txtDiscount!= null && txtVAT == null && checkDiscount==true)
            {

                float discount = float.Parse(CheckNull(txtDiscount.Text));
                float totalAmount = float.Parse((((100 - discount) / 100) * subtotal).ToString());
                txtTotalAmount.Text = totalAmount.ToString();
            }

            else if (txtDiscount != null && txtVAT != null && checkDiscount == true)
            {

                float discount = float.Parse(CheckNull(txtDiscount.Text));
                float vat = float.Parse(CheckNull(txtVAT.Text));
                float totalAmount = float.Parse((((100 - discount) / 100) * subtotal).ToString());
                txtTotalAmount.Text = (((vat + 100) / 100) * totalAmount).ToString();

            }

            else if (txtDiscount != null && txtVAT == null && checkDiscount == false)
            {

                float discount = float.Parse(CheckNull(txtDiscount.Text));
                float totalAmount = subtotal - discount;
                txtTotalAmount.Text = totalAmount.ToString();
            }

            else if (txtDiscount != null && txtVAT != null && checkDiscount == false)
            {

                float discount = float.Parse(CheckNull(txtDiscount.Text));
                float vat = float.Parse(CheckNull(txtVAT.Text));
                float totalAmount = subtotal - discount;
                txtTotalAmount.Text = (((vat + 100) / 100) * totalAmount).ToString();

            }



            else
            {
                if( txtSubTotal !=null && txtTotalAmount != null)
                {
                    txtTotalAmount.Text = txtSubTotal.Text;
                }
            }


        }


        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }


      

        private void TxtQty_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TxtDiscount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

        }

        private void TxtVAT_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TxtPaidAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void Discount_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The value of Discount entered will be in percentage(%)");
            checkDiscount = true;
        }

        private void Discount_CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            checkDiscount = false;
        }

        private void cmbBank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string paymethod = getPaymentMethod();    
            ComboBoxItem ComboItem = (ComboBoxItem)cmbBank.SelectedItem;
            comboBankName = ComboItem.Content.ToString();

           
        }

        // to get payment method from the radiobox control
        private string getPaymentMethod()
        {
            string payment = "";
            if (CashPayment != null || CCPayment != null || CreditPayment!=null)
            {
                if (CashPayment.IsChecked == true)
                {
                    payment = CashPayment.Content.ToString();
                }
                if (CCPayment.IsChecked == true)
                {
                    payment = CCPayment.Content.ToString();

                }
                if (CreditPayment.IsChecked == true)
                {
                    payment = CreditPayment.Content.ToString();

                }
            }
            return payment;

        }

        private void CCPayment_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBank != null)
            {
                cmbBank.Visibility = Visibility.Visible;
            }
        }

        private void CashPayment_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBank != null)
            {
                cmbBank.Visibility = Visibility.Hidden;
                comboBankName = "";
            }

        }

        private void CreditPayment_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBank != null)
            {
                cmbBank.Visibility = Visibility.Hidden;
                comboBankName = "";
            }
        }


        private bool Popup()
        {
            bool success = false;

            CreditPopUpWindow creditPopUpWindow = new CreditPopUpWindow();
            creditPopUpWindow.ShowDialog();
            creditPopUpWindow.Activate();
            success = creditPopUpWindow.success;
            creditCustomerId = creditPopUpWindow.crCustomerId;
            creditCustomerName = creditPopUpWindow.crCustomerName;
            return success;
        }


    }




}
 

