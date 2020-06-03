using LoginUI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginUI.Data
{
    class TransactionDetailDAL
    {
        public bool insert(TransactionDetail transactionDetail)
        {
            bool IsSuccess = false;
            

            try
            {
                string sql = @"Insert into TransactionDetail (product_code,unit_selling_price,quantity,total_selling_price,bill_number,product_type) 
                            VALUES(@product_code,
                                    @unit_selling_price,
                                    @quantity,
                                    @total_selling_price,
                                    @bill_number,
                                    @product_type)";

                SqlCommand cmd = new SqlCommand(sql,DbClass.con);

                cmd.Parameters.AddWithValue("@product_code", transactionDetail.productCode);
                cmd.Parameters.AddWithValue("@unit_selling_price", transactionDetail.unitSellingPrice);
                cmd.Parameters.AddWithValue("@quantity", transactionDetail.quantity);
                cmd.Parameters.AddWithValue("@total_selling_price", transactionDetail.totalSellingPrice);
                cmd.Parameters.AddWithValue("@bill_number", transactionDetail.billNumber);
                cmd.Parameters.AddWithValue("@product_type", transactionDetail.productType ?? "");



                DbClass.openConnection();
                int rows = cmd.ExecuteNonQuery();
                if( rows > 0)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
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

            return IsSuccess;
        }

    }
}
