
//using LoginUI.Data;
//CreditPopUpWindow
using LoginUI.Data;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MyPopupWindow.xaml
    /// </summary>
    public partial class CreditPopUpWindow : Window
    {
        public CreditPopUpWindow()
        {
            InitializeComponent();
        }
        private static readonly Regex _regex = new Regex("[0-9]+");
        CreditCustomerDAL creditCustomerDAL = new CreditCustomerDAL();
        public bool success = false;
        public string crCustomerName;
        public int crCustomerId;


        //NOTE: TODO 1) Add CreditPayment as a paymnet method, name its content CREDIT
        // 2) in code behind of transactionView inside function getPaymentMethod() add CreditPayment and likewise
        // 3)for transaction btnSave function inside transactionScope, if(transaction.paymentMethod = credit) update credit balance for that customer, before updating
        // 4) before updating open the popup window , it will ferify if the custome is present or not . If not present return false and return from taht function. else update , update inside transaction view


        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            crCustomerId = int.Parse(txtCrCustomerId.Text);
            crCustomerName = txtCrCustomerName.Text?? ""; 
            success = creditCustomerDAL.IsCrCustomerPresent(crCustomerName, crCustomerId);
            
            if (success == false)
            {
                MessageBox.Show("Customer Not Found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
            }

            Close();

        }
        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }



        private void txtCrCustomerId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

        }
    }
}
