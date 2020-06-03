using LoginUI.Data;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for GenericReportView.xaml
    /// </summary>
    public partial class CashSalesReportView : Window
    {
        public CashSalesReportView()
        {
            InitializeComponent();
        }

        ReportDAL reportDAL = new ReportDAL();

        private void btnDateSearch_Click(object sender, RoutedEventArgs e)
        {
            ReportViewer.Reset();
            if (DPFrom != null && DPTo != null && DPFrom.SelectedDate != null && DPTo.SelectedDate != null )
            {
                DateTime beginningDate = DPFrom.SelectedDate.Value.Date;
                DateTime endingDate = DPTo.SelectedDate.Value.Date;
                DataTable dt = reportDAL.getCashSalesByDate(beginningDate, endingDate);
                ReportDataSource ds = new ReportDataSource("TransactionDataSet", dt);
              

                ReportViewer.LocalReport.DataSources.Add(ds);
                ReportViewer.LocalReport.ReportEmbeddedResource = "LoginUI.Report.TransactionReport.rdlc";
                ReportViewer.RefreshReport();
            }

            else
            {
                MessageBox.Show("Please select the date");
            }

        }
    }
}
