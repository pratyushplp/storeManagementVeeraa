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
    class TransactionDAL
    {
        #region method to insert transaction in database
        public bool insert(BillingTransaction transaction)
        {
            bool isSuccess = false;

            
            try
            {
                string sql = @"INSERT INTO TransactionTable ([customer_type],[customer_name],[customer_id],[bill_number],[transaction_date],[total_amount],[discount],[VAT],[payment_method],[bank_name],[total_qty])
                    VALUES (@customer_type,
                    @customer_name,
                    @customer_id,
                    @bill_number,
                    @transaction_date,
                    @total_amount,
                    @discount,
                    @VAT,
                    @paymentMethod,
                    @bankName,
                    @totalQty
                    )";

                // creating sql command to pass the value
                SqlCommand cmd = new SqlCommand(sql, DbClass.con);

                //passing data to parameter
                //NOTE ?? operator gives assigns the value of the right side if the ledt side value is null.
                cmd.Parameters.AddWithValue("@customer_type", transaction.customerType ?? string.Empty);
                cmd.Parameters.AddWithValue("@customer_name", transaction.customerName ?? string.Empty);
                cmd.Parameters.AddWithValue("@customer_id", transaction.customerId ?? string.Empty);
                cmd.Parameters.AddWithValue("@bill_number", transaction.billNumber);
                cmd.Parameters.AddWithValue("@transaction_date", transaction.transactionDate);
                cmd.Parameters.AddWithValue("@total_amount", transaction.totalAmount);
                cmd.Parameters.AddWithValue("@discount", transaction.discount);
                cmd.Parameters.AddWithValue("@VAT", transaction.VAT);
                cmd.Parameters.AddWithValue("@paymentMethod", transaction.paymentMethod);
                cmd.Parameters.AddWithValue("@bankName", transaction.bankName);
                cmd.Parameters.AddWithValue("@totalQty", transaction.totalQty);








                DbClass.openConnection();
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //// ExecuteScalar returns the value of the first column of the first row, if executed successfully the value wont be null
                //object obj = cmd.ExecuteScalar();
                //if (obj != null)
                //{
                //    transactionID = int.Parse(obj.ToString());
                //    isSuccess = true;

                //}

                //else
                //{
                //    isSuccess = false;
                //}

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
                MessageBox.Show("Warning: Check If the bill number is used before, if so enter the correct bill number");


            }

            finally
            {
                DbClass.closeConnection();
            }

            return isSuccess;


        }

        #endregion

        #region select latest bill number
        public string SearchLatestBillNumber()
        {
            string billNo="";

            string sql = @"Select top 1 bill_number from TransactionTable order by transaction_date desc";

            SqlCommand cmd = new SqlCommand(sql,DbClass.con);
            DbClass.openConnection();

            // ExecuteScalar returns the value of the first column of the first row, if executed successfully the value wont be null
            object obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                billNo = obj.ToString();

            }

            else
            {
                billNo = "";
            }

            DbClass.closeConnection();


            return billNo;
        }

        #endregion

        #region  method to update product, NOTE these are in transactionDAL and not in productDAL as these are associated with transactionView
        public bool UpdateQuantity(string productCode, float decQty, float billQty)
        {
            int rowCount = CountRows(productCode);
            bool success = false;
            DataTable productData = new DataTable();
            try
            {
                //---****** COMPLETE PROCESS WORKFLOW ******---
                //check if more than one row is present for that  product code
                // if more than one row is present then get the it with highest remaining item
                // check if the quantity >= or <= than highest remaining item
                // then that determines if we do 1 update or multiple updates
                if (rowCount > 0)
                {
                    productData = GetProductWithHighestRemainingUnits(productCode);
                    if(productData == null )
                    {
                        MessageBox.Show("Unable to update the products table");
                        return false;
                    }

                    DataRow dataRowToUpdate = productData.AsEnumerable().FirstOrDefault();
                    //NOTE: here we have already ordered by remaining items in query so we get the Id with max remaining items
                    int idToUpdate = int.Parse(dataRowToUpdate["Id"].ToString());
                    float highestRemainingUnit = float.Parse(dataRowToUpdate["remaining_unit"].ToString());


                    if (rowCount == 1 || (highestRemainingUnit >= billQty))
                    {
                        string sql = @"UPDATE ProductTable SET remaining_unit = (remaining_unit - @qty )  WHERE product_code = " + "'" + productCode + "'" + " and Id = @id";

                        SqlCommand cmd = new SqlCommand(sql, DbClass.con);

                        cmd.Parameters.AddWithValue("@qty", billQty);
                        cmd.Parameters.AddWithValue("@id", idToUpdate);

                        DbClass.openConnection();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                        }
                    }


                    if (rowCount > 1 && (highestRemainingUnit < billQty))
                    {
                        float qtyToUpdate = 0;
                        float prevBillQty = 0;
                        for (int i = 0; i <= productData.Rows.Count; i++)
                        {
                            idToUpdate = int.Parse(productData.Rows[i]["Id"].ToString());
                            highestRemainingUnit = int.Parse(productData.Rows[i]["remaining_unit"].ToString());

                            billQty = billQty - highestRemainingUnit;
                            qtyToUpdate = billQty >= 0 ? highestRemainingUnit : prevBillQty;
                            


                            string sql = @"UPDATE ProductTable SET remaining_unit = (remaining_unit - @qty )  WHERE product_code = " + "'" + productCode + "'"+" and Id = @id";

                            SqlCommand cmd = new SqlCommand(sql, DbClass.con);

                            cmd.Parameters.AddWithValue("@qty", qtyToUpdate);
                            cmd.Parameters.AddWithValue("@id", idToUpdate);

                            DbClass.openConnection();
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                success = true;
                            }
                            else
                            {
                                success = false;
                            }

                            prevBillQty = billQty;
                            // Break the for loop as necessary rows are updated
                            if (billQty <= 0) break;


                        }

                        

                       
                    }




                }

               

                

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                DbClass.closeConnection();
            }

            

            return success;
        }
        #endregion



        #region Count rows

        public int CountRows(string productCode)
        {
            int rowCount = 0;
            try
            {

                //check if more than one row is present for that  product code
                // if more than one row is present then get the it with highest remaining item
                // check if the quantity >= or <= than highest remaining item
                // then that determines if we do 1 update or multiple updates


                //get it with highest remaining item


                string sql = @"select COUNT(*) from ProductTable where product_code = " + "'" + productCode + "'";
                SqlCommand cmd = new SqlCommand(sql, DbClass.con);
                DbClass.openConnection();
                object obj = cmd.ExecuteScalar();
                rowCount = int.Parse(obj.ToString());

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                DbClass.closeConnection();
            }
            return rowCount;

        }

        #endregion

        #region get Id with highest remaining unit
        public DataTable GetProductWithHighestRemainingUnits(string productCode)
        {
            DataTable data = new DataTable();

            try
            {
                //get highest remaining item
                string sql = "select   * from ProductTable WHERE product_code = " + "'" + productCode + "'" + " order by remaining_unit desc";
                SqlCommand cmd = new SqlCommand(sql, DbClass.con);
                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                DbClass.closeConnection();
            }



            return data;


        }


        #endregion



        #region decrease product while selling
        public bool DecreaseProduct(string productCode, float qty,float inventoryQty)
        {
            bool success = false;

            try
            {


                float decreasedQty = inventoryQty - qty;
                if (decreasedQty >= 0 )
                {


                    success = UpdateQuantity(productCode,decreasedQty,qty);
                }
                else
                {
                    MessageBox.Show("Invalid Quantity Input, Cannot Sell more than the Products Available");
                }


            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            finally
            {
                DbClass.closeConnection();
            }


            return success;

        }
        #endregion

        #region Calclulate discount % for a particular bill number
        public float GetDiscountPercent(int billno)
        {
            string sql = "select discount from TransactionTable where bill_number = '@bill_number' ";
            SqlCommand cmd = new SqlCommand(sql,DbClass.con);
            cmd.Parameters.AddWithValue("@bill_number",billno);
            DbClass.openConnection();
            // ExecuteScalar returns the value of the first column of the first row, if executed successfully the value wont be null
            object obj = cmd.ExecuteScalar();
            

            if(obj == null)
            {
                MessageBox.Show("Discount for the given bill number not found");
                return 0;
            }

            float discountPercent = float.Parse(obj.ToString());

            DbClass.closeConnection();


            return discountPercent;
        }

    }
    #endregion

   


}
