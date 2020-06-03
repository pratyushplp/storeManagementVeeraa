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
using LoginUI.Data;
using Microsoft.Reporting.WinForms;

namespace LoginUI.Views
{
    /// <summary>
    /// Interaction logic for InventoryReportView.xaml
    /// </summary>
    public partial class InventoryReportView : Window
    {
        ReportDAL reportDAL = new ReportDAL();
        public InventoryReportView()
        {
            InitializeComponent();
        }

        private void BtnSpecificInventorySearch_Click(object sender, RoutedEventArgs e)
        {
            ReportViewer.Reset();
            if (txtProductCodeSearch != null)
            {
                string value = txtProductCodeSearch.Text;
                DataTable dt = reportDAL.SearchSpecificInventoryStock(value);
                ReportDataSource ds = new ReportDataSource("InventoryDataSet", dt);

                ReportViewer.LocalReport.DataSources.Add(ds);
                ReportViewer.LocalReport.ReportEmbeddedResource = "LoginUI.Report.InventoryReport.rdlc";
                ReportViewer.RefreshReport();
            }
        }

        private void btnAllInventorySearch_Click(object sender, RoutedEventArgs e)
        {
            ReportViewer.Reset();
            DataTable dt = reportDAL.SearchInventoryStock();
            ReportDataSource ds = new ReportDataSource("InventoryDataSet", dt);

            ReportViewer.LocalReport.DataSources.Add(ds);
            ReportViewer.LocalReport.ReportEmbeddedResource = "LoginUI.Report.InventoryReport.rdlc";
            ReportViewer.RefreshReport();

        }
    }
}
