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
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private static readonly Regex _regex = new Regex("[0-9.]+");

        ProductDAL productData = new ProductDAL();
        Product product = new Product();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable productDataTable = productData.Select();
            dgvProducts.ItemsSource = productDataTable.DefaultView;
        }

        public void clear()
        {
            txtProductType.Text = "";
            txtBrandCode.Text = "";
            txtProductCode.Text = "";
            txtDeliveryAgent.Text = "";
            txtVendor.Text = "";
            txtUnitPriceINR.Text = "";
            txtUnitPriceNPR.Text = "";
            txtTotalUnitIn.Text = "";
            txtCarrierCharge.Text = "";
            txtTotalCost.Text = "";
            txtSellingPrice.Text = "";
            txtRemainingUnit.Text = "";

        }

        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }


        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            // get all the values from product
            product.productType = txtProductType.Text;
            product.brandCode = txtBrandCode.Text;
            product.productCode = txtProductCode.Text;
            product.deliveryAgent = txtDeliveryAgent.Text;
            product.vendor = txtVendor.Text;
            product.unitPriceINR = float.Parse(txtUnitPriceINR.Text);
            product.unitPriceNPR = float.Parse(txtUnitPriceNPR.Text);
            product.totalUnitIn = float.Parse(txtRemainingUnit.Text);
            product.remainingUnit = float.Parse(txtTotalUnitIn.Text);
            product.carrierChargePerUnit = float.Parse(txtCarrierCharge.Text);
            product.totalCostPerUnit = float.Parse(txtTotalCost.Text);
            product.sellingPrice = float.Parse(txtSellingPrice.Text);
            product.addedDate = DateTime.Now;
            product.remainingUnit = float.Parse(txtRemainingUnit.Text);

            //bool success = productData.insert(product);

            Task<bool> task = new Task<bool>(() => productData.insert(product));
            task.Start();
            bool success = await task;
            if (success == true)
            {
                MessageBox.Show("Product Added Successfully");
                clear();
                DataTable productDataTable = productData.Select();
                //NOTE this part is confusing, in wpf no datagridview present like in winforms so use the following method
                dgvProducts.ItemsSource = productDataTable.DefaultView;


            }

            else
            {
                MessageBox.Show("Failed to Add Product!");
            }


        }


        // double click the row in datagrid, and the corresponding textbox are filled
        private void DataGridRowHeader_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            clear();
            DataRowView row = (DataRowView)dgvProducts.SelectedItems[0];
            txtProductType.Text = row["product_type"].ToString();
            txtBrandCode.Text = row["brand_code"].ToString();
            txtProductCode.Text = row["product_code"].ToString();
            txtDeliveryAgent.Text = row["delivery_agent"].ToString();
            txtVendor.Text = row["vendor"].ToString();
            txtUnitPriceINR.Text = row["unit_price_INR"].ToString();
            txtUnitPriceNPR.Text = row["unit_price_NPR"].ToString();
            txtTotalUnitIn.Text = row["total_unit_in"].ToString();
            txtRemainingUnit.Text = row["remaining_unit"].ToString();
            txtCarrierCharge.Text = row["carrier_charge_unit"].ToString();
            txtTotalCost.Text = row["total_cost_per_unit"].ToString();
            txtSellingPrice.Text = row["selling_price"].ToString();
            txtId.Text = row["Id"].ToString();
        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to update this product?", "Return Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                product.productType = txtProductType.Text;
                product.brandCode = txtBrandCode.Text;
                product.productCode = txtProductCode.Text;
                product.deliveryAgent = txtDeliveryAgent.Text;
                product.vendor = txtVendor.Text;
                product.unitPriceINR = float.Parse(txtUnitPriceINR.Text);
                product.unitPriceNPR = float.Parse(txtUnitPriceNPR.Text);
                product.totalUnitIn = float.Parse(txtTotalUnitIn.Text);
                product.remainingUnit = float.Parse(txtRemainingUnit.Text);
                product.carrierChargePerUnit = float.Parse(txtCarrierCharge.Text);
                product.totalCostPerUnit = float.Parse(txtTotalCost.Text);
                product.sellingPrice = float.Parse(txtSellingPrice.Text);
                product.remainingUnit = float.Parse(txtRemainingUnit.Text);
                product.Id = int.Parse(txtId.Text);

                //bool success = productData.update(product);

                Task<bool> task = new Task<bool>(() => productData.update(product));
                task.Start();
                bool success = await task;

                if (success == true)
                {
                    MessageBox.Show("Product Updated Successfully");
                    clear();
                    DataTable productDataTable = productData.Select();
                    //NOTE this part is confusing, in wpf no datagridview present like in winforms so use the following method
                    dgvProducts.ItemsSource = productDataTable.DefaultView;


                }

                else
                {
                    MessageBox.Show("Failed to Update Product!");
                }

            }

        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this product?", "Return Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                product.productCode = txtProductCode.Text;
                product.Id = int.Parse(txtId.Text);
                Task<bool> task = new Task<bool>(() => productData.delete(product));
                task.Start();
                bool success = await task;

                if (success == true)
                {
                    MessageBox.Show("Product deleted Successfully");
                    clear();
                    DataTable productDataTable = productData.Select();
                    //NOTE: this part is confusing, in wpf no datagridview present like in winforms so use the following method
                    dgvProducts.ItemsSource = productDataTable.DefaultView;

                }

                else
                {
                    MessageBox.Show("Failed to delete Product!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
 

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtSearch.Text;
            if (keyword != null && keyword != "")
            {
                DataTable dt = productData.search(keyword);
                dgvProducts.ItemsSource = dt.DefaultView;


            }

            else
            {
                DataTable dt = productData.Select();
                dgvProducts.ItemsSource = dt.DefaultView;


            }




        }

        private void TxtUnitPriceINR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TxtUnitPriceNPR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

        }

        private void TxtTotalCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

        }

        private void TxtCarrierCharge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

        }

        private void TxtRemainingUnit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

        }

        private void TxtTotalUnitIn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

        }

        private void TxtSellingPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

        }

        private void TxtUnitPriceINR_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtUnitPriceINR.Text;
            if (keyword != "" && keyword != null)
            {
                txtUnitPriceNPR.Text = ((float.Parse(txtUnitPriceINR.Text)) * 1.6).ToString();
            }
        }

        private void TxtCarrierCharge_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword1 = txtUnitPriceNPR.Text;
            string keyword2 = txtCarrierCharge.Text;


            if (keyword1 != "" && keyword1 != null && keyword2 != "" && keyword2 != null)
            {
                txtTotalCost.Text = (float.Parse(keyword1) + float.Parse(keyword2)).ToString();
            }
        }
    }
}
