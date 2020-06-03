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
    public partial class ReturnOptionsView : Window
    {
        public ReturnOptionsView()
        {
            InitializeComponent();
        }

        private void BtnReturnItems_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is ReturnView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                ReturnView returnView = new ReturnView();
                returnView.Show();
                returnView.Activate();

            }

        }

        private void BtnReturnHistory_Click(object sender, RoutedEventArgs e)
        {
            bool isOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is ReturnHistoryView)
                {
                    isOpen = true;
                    w.Activate();
                }

            }
            if (!isOpen) // ie if the window is not opened yet
            {

                ReturnHistoryView returnView = new ReturnHistoryView();
                returnView.Show();
                returnView.Activate();

            }
        }
    }
}
