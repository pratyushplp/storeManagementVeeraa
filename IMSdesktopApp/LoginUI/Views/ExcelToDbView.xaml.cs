using ExcelDataReader;
using LoginUI.Data;
using LoginUI.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace LoginUI.Views
{
    /// <summary>
    /// Interaction logic for ExcelToDbView.xaml
    /// </summary>
    public partial class ExcelToDbView : Window
    {

        ProductDAL productDAL = new ProductDAL();

        DataTableCollection tablesToInsert;
        List<string> columnNamesExcel = new List<string>();
        DataTable tempProductTable = new DataTable();

        public ExcelToDbView()
        {
            InitializeComponent();
        }

        //public DataTable InitializeDataBaseSchema()
        //{
        //    return productDAL.SelectSchema().Clone();
        //}


        private void cmbSheet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable dt = tablesToInsert[cmbSheet.SelectedItem.ToString()];
            dgvExcelToDb.ItemsSource = dt.DefaultView;
            columnNamesExcel.Clear();
            foreach(DataColumn dc in dt.Columns)
            {
                //only add the non empty columns
                if( dc != null && !string.IsNullOrWhiteSpace(dc.ToString()) )
                {
                    columnNamesExcel.Add(dc.ToString());
                }
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook| *.xlsx| Excel 97-2003 Workbook| *.xls" };
            if (openFileDialog.ShowDialog() == true)
            {
                txtFileName.Text = openFileDialog.FileName;

                try
                {
                    using (FileStream fileStream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(fileStream))
                        {
                            var result = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });

                            tablesToInsert = result.Tables;
                            cmbSheet.Items.Clear();
                            foreach (DataTable dt in result.Tables)
                            {
                                cmbSheet.Items.Add(dt.TableName);
                            }

                        }
                    }
                }

                catch(Exception ex)
                {
                    MessageBox.Show("Cannot Open the file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgvExcelToDb.ItemsSource != null)
            {
                tempProductTable = productDAL.BuildProductSchema();

                List<Product> productList = new List<Product>();

                if(tablesToInsert[cmbSheet.SelectedItem.ToString()] !=null && tablesToInsert[cmbSheet.SelectedItem.ToString()].Rows.Count > 0)
                {
                    foreach (DataRow dr in tablesToInsert[cmbSheet.SelectedItem.ToString()].Rows)
                    {
                        //Only take the values where product code is not an empty string
                        //NOTE: product code is present in 5th column of the excel sheet so we are checking columnNamesExcel[4]
                        if (dr[columnNamesExcel[4]] != null && !string.IsNullOrWhiteSpace(dr[columnNamesExcel[4]].ToString()))
                        {
                            DataRow tempProductDr = tempProductTable.NewRow();
                            tempProductDr["product_type"] = dr[columnNamesExcel[0]]?.ToString()?? "";
                            tempProductDr["brand_code"] = dr[columnNamesExcel[1]]?.ToString()?? "";
                            tempProductDr["delivery_agent"] = dr[columnNamesExcel[2]]?.ToString() ?? "";
                            tempProductDr["vendor"] = dr[columnNamesExcel[3]]?.ToString() ?? "";
                            tempProductDr["product_code"] = dr[columnNamesExcel[4]]?.ToString() ?? "";
                            // ternary operator used to fix the problem of converting whitespace or blank values in database
                            tempProductDr["unit_price_INR"] = (dr[columnNamesExcel[5]] != null && !string.IsNullOrWhiteSpace(dr[columnNamesExcel[5]]?.ToString())) ? float.Parse(dr[columnNamesExcel[5]].ToString()) : (float)0;
                            tempProductDr["unit_price_NPR"] = (dr[columnNamesExcel[6]] != null && !string.IsNullOrWhiteSpace(dr[columnNamesExcel[6]]?.ToString())) ? float.Parse(dr[columnNamesExcel[6]].ToString()) : (float)0;
                            tempProductDr["total_unit_in"] = (dr[columnNamesExcel[7]] != null && !string.IsNullOrWhiteSpace(dr[columnNamesExcel[7]]?.ToString())) ? float.Parse(dr[columnNamesExcel[7]].ToString()) : (float)0;
                            tempProductDr["remaining_unit"] = (dr[columnNamesExcel[8]] != null && !string.IsNullOrWhiteSpace(dr[columnNamesExcel[8]]?.ToString())) ? float.Parse(dr[columnNamesExcel[8]].ToString()) : (float)0;
                            tempProductDr["carrier_charge_unit"] = ( dr[columnNamesExcel[9]] != null && !string.IsNullOrWhiteSpace(dr[columnNamesExcel[9]]?.ToString()) ) ? float.Parse(dr[columnNamesExcel[9]].ToString()) : (float)0;
                            tempProductDr["total_cost_per_unit"] = (dr[columnNamesExcel[10]] != null && !string.IsNullOrWhiteSpace(dr[columnNamesExcel[10]]?.ToString())) ? float.Parse(dr[columnNamesExcel[10]].ToString()) : (float)0;
                            tempProductDr["selling_price"] = (dr[columnNamesExcel[11]] != null && !string.IsNullOrWhiteSpace(dr[columnNamesExcel[11]]?.ToString())) ? float.Parse(dr[columnNamesExcel[11]].ToString()) : (float)0;
                            tempProductDr["added_date"] = DateTime.Now;

                            tempProductTable.Rows.Add(tempProductDr);


                            // code commented out below uses Method to make a list of product and add them to DB, not using this method as we are using dataTable schema method, where we create an inmemeory database and 
                            //put values in it directly, the inmemeory database method is used so that we can use the bulk insert method to insert all the data at once

                            //Product product = new Product();
                            //product.productType = dr[columnNamesExcel[0]].ToString();
                            //product.brandCode = dr[columnNamesExcel[1]].ToString();
                            //product.deliveryAgent = dr[columnNamesExcel[2]].ToString();
                            //product.vendor = dr[columnNamesExcel[3]].ToString();
                            //product.productCode = dr[columnNamesExcel[4]].ToString();
                            //product.unitPriceINR = float.Parse(dr[columnNamesExcel[5]].ToString());
                            //product.unitPriceNPR = float.Parse(dr[columnNamesExcel[6]].ToString());
                            //product.totalUnitIn = float.Parse(dr[columnNamesExcel[7]].ToString());
                            //product.remainingUnit = float.Parse(dr[columnNamesExcel[8]].ToString());
                            //product.carrierChargePerUnit = float.Parse(dr[columnNamesExcel[9]].ToString());
                            //product.totalCostPerUnit = float.Parse(dr[columnNamesExcel[10]].ToString());
                            //product.sellingPrice = float.Parse(dr[columnNamesExcel[11]].ToString());
                            //product.addedDate = DateTime.Now;

                            //productList.Add(product);


                        }
                        else
                        {
                            continue;
                        }
                    }
                    //bulk insert to product table
                    if(productDAL.BulkInsertTable(tempProductTable))
                    {
                        MessageBox.Show("Import data from Excel to Database successfull");
                    }

                    else
                    {
                        MessageBox.Show("Could Not Import Data From Excel To Database!. Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                else
                {
                    MessageBox.Show("No data present!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);                    
                }


            }

            columnNamesExcel.Clear();
            tempProductTable.Clear();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}