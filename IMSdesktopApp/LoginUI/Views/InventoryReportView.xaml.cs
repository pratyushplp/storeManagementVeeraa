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

        private async void BtnSpecificInventorySearch_Click(object sender, RoutedEventArgs e)
        {
            ReportViewer.Reset();
            if (txtProductCodeSearch != null)
            {
                string value = txtProductCodeSearch.Text;
                DataTable dt = await  Task.Run( () => SearchReport(value));
                ReportDataSource ds = new ReportDataSource("InventoryDataSet", dt);

                ReportViewer.LocalReport.DataSources.Add(ds);
                ReportViewer.LocalReport.ReportEmbeddedResource = "LoginUI.Report.InventoryReport.rdlc";
                ReportViewer.RefreshReport();
            }
        }

        private async void btnAllInventorySearch_Click(object sender, RoutedEventArgs e)
        {
            ReportViewer.Reset();
            //DataTable dt = reportDAL.SearchInventoryStock();
            DataTable dt = await Task.Run(() => SearchReport(string.Empty));
            ReportDataSource ds = new ReportDataSource("InventoryDataSet", dt);

            ReportViewer.LocalReport.DataSources.Add(ds);
            ReportViewer.LocalReport.ReportEmbeddedResource = "LoginUI.Report.InventoryReport.rdlc";
            ReportViewer.RefreshReport();

        }

        private DataTable SearchReport(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return reportDAL.SearchInventoryStock();
            }
            else
            {
                return reportDAL.SearchSpecificInventoryStock(value);
            }
        }
    }
}
