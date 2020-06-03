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
    /// Interaction logic for CreditCustomerOptionsView.xaml
    /// </summary>
    public partial class CreditCustomerOptionsView : Window
    {
        public CreditCustomerOptionsView()
        {
            InitializeComponent();
        }

        private void BtnUpdateCreditBalance_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is CreditCustomerView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                CreditCustomerView creditCustomerView = new CreditCustomerView();
                creditCustomerView.Show();
                creditCustomerView.Activate();

            }

        }

        private void BtnUpdateCreditCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is UpdateCreditCustomerView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                UpdateCreditCustomerView updateCreditCustomerView = new UpdateCreditCustomerView();
                updateCreditCustomerView.Show();
                updateCreditCustomerView.Activate();

            }

        }
    }
}
