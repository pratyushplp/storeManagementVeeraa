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
    class BillDAL
    {
        #region select bills of given bill number
        public DataTable Search(int billNo)
        {

            string sql = @"Select td.Id,td.bill_number,td.product_code,td.product_type,td.unit_selling_price,td.quantity,td.total_selling_price,t.discount as 'total_bill_discount',t.total_amount as 'total_bill_amount',( ( t.discount / (t.total_amount + t.discount) )*100 ) as 'percentage_discount'
                            from TransactionDetail  td 
                            left join 
                            TransactionTable t
                            on td.bill_number=t.bill_number
                            where  td.bill_number = @bill_number ";
            DataTable billDatatable = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            cmd.Parameters.AddWithValue("@bill_number", billNo);
            // open database connection

            //sql data adapter to hold the value from database tempororily

            try
            {
                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(billDatatable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                DbClass.closeConnection();

            }

            return billDatatable;

        }
        #endregion

        #region update the quantity for the bill(THIS IS USED IN REFUNDAND RETURN ITEMS)
        public bool Update(int billNo, string id,float returnQty,float creditAmount,float returnDiscount)
        {
            bool success = false;
            //NOTE:- transactionDetail table is filtered by ID and transactionTable is filtered by billNo
            string sql = @"update TransactionDetail set total_selling_price=unit_selling_price*(quantity - @returnQty),quantity = quantity - @returnQty where Id= @Id
                           update TransactionTable set total_amount=total_amount - @creditAmount ,discount=discount - @returnDiscount,total_qty=total_qty - @returnQty where bill_number= @billNumber ";

            SqlCommand cmd = new SqlCommand(sql,DbClass.con);
            cmd.Parameters.AddWithValue("@billNumber", billNo);
            cmd.Parameters.AddWithValue("@Id", Int32.Parse(id));
            cmd.Parameters.AddWithValue("@returnQty", returnQty);
            cmd.Parameters.AddWithValue("@creditAmount", creditAmount);
            cmd.Parameters.AddWithValue("@returnDiscount", returnDiscount);
            try
            {
                DbClass.openConnection();
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    success = true;
                }
                else
                {
                    success = false;
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

        #region insert the return item to history return item table to track  the items returned
        public bool histInsert(int billNumber,string productCode, float returnQuantity,float returnAmount)
        {
            bool success = false;
            //id	bill_number	return_quantity	return_amount	return_date

            string sql = @"insert into HistReturnItem(bill_number,product_code,return_quantity,return_amount,return_date) values (@bill_number,@product_code,@return_quantity,@return_amount,@return_date) ";

            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            cmd.Parameters.AddWithValue("@bill_number", billNumber);
            cmd.Parameters.AddWithValue("@product_code", productCode);
            cmd.Parameters.AddWithValue("@return_quantity", returnQuantity);
            cmd.Parameters.AddWithValue("@return_amount", returnAmount);
            cmd.Parameters.AddWithValue("@return_date", DateTime.Now);


            try
            {
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
            catch (Exception ex)

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

        #region public void show history of return items 
        public DataTable ShowHistoryReturn()
        {

            string sql = "Select * from HistReturnItem order by id asc";
            DataTable histReturnDatatable = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            // open database connection

            //sql data adapter to hold the value from database tempororily

            try
            {
                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(histReturnDatatable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                DbClass.closeConnection();

            }

            return histReturnDatatable;

        }
        #endregion
        #region Search Return History
        public DataTable SearchReturnHist(int billNo)
        {

            string sql = @"Select * from HistReturnItem
                            where  bill_number = @bill_number ";
            DataTable billDatatable = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            cmd.Parameters.AddWithValue("@bill_number", billNo);
            // open database connection

            //sql data adapter to hold the value from database tempororily

            try
            {
                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(billDatatable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                DbClass.closeConnection();

            }

            return billDatatable;

        }

        #endregion

    }
}
