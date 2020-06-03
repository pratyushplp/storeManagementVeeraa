using LoginUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginUI.Data
{
     class ProductDAL
    {
        #region select method for product module.
        public DataTable Select()
        {
            
            string sql = "Select * from productTable order by Id asc";
            DataTable productDatatable = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            // open database connection

            //sql data adapter to hold the value from database tempororily

            try
            {
                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);          
                adapter.Fill(productDatatable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                DbClass.closeConnection();

            }

            return productDatatable;

        }
        #endregion

        #region method to insert product in database
        public bool insert(Product product )
        {
            bool isSuccess = false;
            try
            {
                string sql = @"INSERT INTO productTable (product_type,brand_code,product_code,delivery_agent,vendor,unit_price_INR,unit_price_NPR,total_unit_in,carrier_charge_unit,total_cost_per_unit,selling_price,added_date,remaining_unit)
                    VALUES (@product_type,
                    @brand_code,
                    @product_code,
                    @delivery_agent,
                    @vendor,
                    @unit_price_INR,
                    @unit_price_NPR,
                    @total_unit_in,
                    @carrier_charge_unit,
                    @total_cost_per_unit,
                    @selling_price,
                    @added_date,
                    @remaining_unit
                    )";

                // creating sql command to pass the value
                SqlCommand cmd = new SqlCommand(sql, DbClass.con);

                //passing data to parameter
                cmd.Parameters.AddWithValue("@product_type", product.productType);
                cmd.Parameters.AddWithValue("@brand_code", product.brandCode);
                cmd.Parameters.AddWithValue("@product_code", product.productCode);
                cmd.Parameters.AddWithValue("@delivery_agent", product.deliveryAgent);
                cmd.Parameters.AddWithValue("@vendor", product.vendor);
                cmd.Parameters.AddWithValue("@unit_price_INR", product.unitPriceINR);
                cmd.Parameters.AddWithValue("@unit_price_NPR", product.unitPriceNPR);
                cmd.Parameters.AddWithValue("@total_unit_in", product.totalUnitIn);
                cmd.Parameters.AddWithValue("@carrier_charge_unit", product.carrierChargePerUnit);
                cmd.Parameters.AddWithValue("@total_cost_per_unit", product.totalCostPerUnit);
                cmd.Parameters.AddWithValue("@selling_price", product.sellingPrice);
                cmd.Parameters.AddWithValue("@added_date", product.addedDate);
                cmd.Parameters.AddWithValue("@remaining_unit", product.remainingUnit);



                DbClass.openConnection();
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // ExecuteNonQuery executes the query and returns the affected rows by the command, used for insert,delete,update etc operations.
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    isSuccess = true;

                }

                else
                {
                    isSuccess = false;
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            finally
            {
                DbClass.closeConnection();
            }

            return isSuccess;
            

        }

        #endregion

        #region method to update table in database
        public bool update(Product product)
        {
            bool isSuccess = false;
            try
            {
               
                string sql = @"update  productTable SET product_type = @product_type, 
                    brand_code = @brand_code , 
                    product_code = @product_code , 
                    delivery_agent = @delivery_agent , 
                    vendor = @vendor , 
                     unit_price_INR = @unit_price_INR, 
                    unit_price_NPR = @unit_price_NPR , 
                    total_unit_in = @total_unit_in , 
                    carrier_charge_unit = @carrier_charge_unit, 
                    total_cost_per_unit =@total_cost_per_unit , 
                    selling_price= @selling_price,
                    remaining_unit= @remaining_unit
                     WHERE product_code=@product_code"
                    ;

                SqlCommand cmd = new SqlCommand(sql,DbClass.con);

                cmd.Parameters.AddWithValue("@product_type", product.productType);
                cmd.Parameters.AddWithValue("@brand_code", product.brandCode);
                cmd.Parameters.AddWithValue("@product_code", product.productCode);
                cmd.Parameters.AddWithValue("@delivery_agent", product.deliveryAgent);
                cmd.Parameters.AddWithValue("@vendor", product.vendor);
                cmd.Parameters.AddWithValue("@unit_price_INR", product.unitPriceINR);
                cmd.Parameters.AddWithValue("@unit_price_NPR", product.unitPriceNPR);
                cmd.Parameters.AddWithValue("@total_unit_in", product.totalUnitIn);
                cmd.Parameters.AddWithValue("@carrier_charge_unit", product.carrierChargePerUnit);
                cmd.Parameters.AddWithValue("@total_cost_per_unit", product.totalCostPerUnit);
                cmd.Parameters.AddWithValue("@selling_price", product.sellingPrice);
                cmd.Parameters.AddWithValue("@Id", product.Id);
                cmd.Parameters.AddWithValue("@remaining_unit", product.remainingUnit);


                DbClass.openConnection();

                // ExecuteNonQuery returns the affected rows by the command, used for insert,delete,update etc operations.
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                    
                }

                else
                {
                    isSuccess = false;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                DbClass.closeConnection();

            }
            return isSuccess;
        }
        #endregion

        #region Method to delete the product in database

        public bool delete(Product product)
        {
            bool isSuccess = false;
            try
            {
                string sql = @"DELETE from productTable where product_code=@productCode";
                SqlCommand cmd = new SqlCommand(sql,DbClass.con);
                cmd.Parameters.AddWithValue("@productCode", product.productCode);

                DbClass.openConnection();
                // ExecuteNonQuery returns the affected rows by the command, used for insert,delete,update etc operations.
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;

                }

                else
                {
                    isSuccess = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                DbClass.closeConnection();
            }


            return isSuccess;
        }


        #endregion


        #region search product for product module

        public DataTable search(string keyword)
        {
            DataTable temp = new DataTable();
            try
            {
             string sql = "Select * from ProductTable where  " +
            "product_type like  '%" + keyword + "%' OR " +
            "brand_code like  '%" +keyword+"%' OR "+ 
            "product_code like  '%"+keyword+"%' OR "+
            "delivery_agent like  '%"+keyword+"%' OR "+
            "vendor like  '%"+keyword+"%' OR "+
            "unit_price_INR like  '%"+keyword+"%' OR "+
            "unit_price_NPR like  '%"+keyword+"%' OR " +
            "total_unit_in like  '%"+keyword+"%' OR " +
            "carrier_charge_unit like  '%"+keyword+"%' OR "+
            "total_cost_per_unit like  '%"+keyword+"%' OR " +
            "selling_price like  '%" + keyword+"%' ";





                SqlCommand cmd = new SqlCommand(sql, DbClass.con);


                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(temp);

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                DbClass.closeConnection();
            }

            return temp;
        }

        #endregion

        #region select product in Transaction Module

        public Product searchTransaction(string keyword)
        {
            Product product = new Product();
            DataTable data = new DataTable();
            try
            {
                string sql = @"Select product_type,remaining_unit,selling_price FROM ProductTable WHERE product_code = " + "'"+keyword+"'";
                SqlCommand cmd = new SqlCommand(sql, DbClass.con);
                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                
                if(data.Rows.Count>0)
                {
                    product.productType = data.Rows[0]["product_type"].ToString();
                    product.remainingUnit = float.Parse(data.Rows[0]["remaining_unit"].ToString());
                    product.sellingPrice = float.Parse(data.Rows[0]["selling_price"].ToString());

                }
                //else
                //{
                //    // may need to add icon and button like other messagebox
                //    MessageBox.Show("Product not found");
                //}


            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                DbClass.closeConnection();
            }

            return product;
        }


        #endregion

    }
}

