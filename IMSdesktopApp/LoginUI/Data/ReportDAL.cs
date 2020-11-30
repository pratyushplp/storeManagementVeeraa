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
    class ReportDAL
    {
        #region Data Table operation for purchase value report
        public DataTable searchPurchaseTransaction(string startDate,string endDate)
        {
            DataTable data = new DataTable();
            try
            {
                string sql = @"Select product_type,remaining_unit,selling_price FROM ProductTable WHERE product_code = ";
                SqlCommand cmd = new SqlCommand(sql, DbClass.con);
                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                if (data.Rows.Count > 0)
                {
                  

                }
                //else
                //{
                //    // may need to add icon and button like other messagebox
                //    MessageBox.Show("Product not found");
                //}


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


        #region Data Table operation for products inventory report
        public DataTable SearchInventoryStock()
        {
            string sql = @"Select product_code,product_type,remaining_unit,total_cost_per_unit,selling_price FROM ProductTable";
            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            DataTable data = new DataTable();
            try
            {
  
                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                if (data.Rows.Count > 0)
                {
                }
                else
                {
                    // may need to add icon and button like other messagebox
                    MessageBox.Show("Error,no products available");
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

            return data;


        }

        #endregion

        #region Data Table operation for products inventory report with productcode
        public DataTable SearchSpecificInventoryStock(string productCode)
        {
            string sql = @"Select product_code,product_type,remaining_unit,total_cost_per_unit,selling_price FROM ProductTable WHERE product_code = @productCode";
            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            cmd.Parameters.AddWithValue("@productCode", productCode);
            DataTable data = new DataTable();
            try
            {

                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                if (data.Rows.Count > 0)
                {
                }
                else
                {
                    // may need to add icon and button like other messagebox
                    MessageBox.Show("Input product not avaialble!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

            return data;


        }

        #endregion
        #region get generic sales data by date
        public DataTable getCashSalesByDate(DateTime BeginningDate, DateTime EndingDate)
        {
            DataTable data = new DataTable();
            string sql = @"with a as
                            (
	                         select cast(transaction_date as date) as 'trans_date',  sum(total_amount) as cash,0 as sid_credit_card,0 as kumari_credit_card, 0 as credit_amount, sum(total_qty) as sum_total_qty
	                         from TransactionTable
	                         where payment_method = 'Cash'
	                         group by cast(transaction_date as date) 
							 UNION
							 select cast(transaction_date as date) as 'trans_date',  0 as cash,sum(total_amount) as sid_credit_card,0 as kumari_credit_card, 0 as credit_amount, sum(total_qty) as sum_total_qty
	                         from TransactionTable
                             where payment_method = 'Credit Card' and bank_name = 'Siddhartha Bank'
	                         group by cast(transaction_date as date)							 
							 UNION
							 select cast(transaction_date as date) as 'trans_date',0 as cash,0 as sid_credit_card,sum(total_amount) as kumari_credit_card, 0 as credit_amount, sum(total_qty) as sum_total_qty
	                         from TransactionTable
                             where payment_method = 'Credit Card' and bank_name ='Kumari Bank'
	                         group by cast(transaction_date as date)
							 UNION
							 select cast(transaction_date as date) as 'trans_date',  0 as cash,0 as sid_credit_card,0 as kumari_credit_card, sum(total_amount) as credit_amount, sum(total_qty) as sum_total_qty
	                         from TransactionTable
	                         where payment_method = 'Credit'
	                         group by cast(transaction_date as date) 
							 							  
                             )
							 select trans_date,sum(cash) as cash_amt,sum(sid_credit_card)as sid_credit_card_amt,sum(kumari_credit_card) as kumari_credit_card_amt,sum(credit_amount) as credit_amt,(sum(cash)+sum(sid_credit_card)+sum(kumari_credit_card)+sum(credit_amount)) as total_amt, sum(sum_total_qty) as total_qty from a
							 where trans_date BETWEEN CAST(@beginningDate as date) AND CAST(@endingDate as date)
							 group by trans_date";

            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            cmd.Parameters.AddWithValue("@beginningDate", BeginningDate);
            cmd.Parameters.AddWithValue("@endingDate", EndingDate);


            try
            {
               
                DbClass.openConnection();
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                if (data.Rows.Count > 0)
                {
                }
                else
                {
                    // may need to add icon and button like other messagebox
                    MessageBox.Show("Sales Data Not Available!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

            return data;
        }


        #endregion



        #region get detailed sales data by date and product_code
        public DataTable getDetailedSalesByDate(DateTime BeginningDate, DateTime EndingDate)
        {
            DataTable data = new DataTable();
            string sql = @"with a as
                          (
                          select  product_code, unit_selling_price,sum(quantity) as sum_qty
                          from transactionDetail
                          where bill_number in (select bill_number from transactionTable where CAST(transaction_date as date) BETWEEN CAST(@beginningDate as date) AND CAST(@endingDate as date))
                          group by product_code,unit_selling_price
                          ),b as
                          (
                          select MAX(total_cost_per_unit) as cost_per_unit,product_code
                          from  ProductTable
                          where total_unit_in <> remaining_unit --i.e only sold products
                          group by product_code
                          ) 
                          
                          select distinct a.product_code,a.unit_selling_price as selling_price_per_unit,b.cost_per_unit,a.sum_qty
                          from a
                          left join b
                          on a.product_code =b.product_code ";

            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            cmd.Parameters.AddWithValue("@beginningDate", BeginningDate);
            cmd.Parameters.AddWithValue("@endingDate", EndingDate);


            try
            {

                DbClass.openConnection();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                if (data.Rows.Count > 0)
                {
                }
                else
                {
                    // may need to add icon and button like other messagebox
                    MessageBox.Show("Sales Data Not Available!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

            return data;
        }


        #endregion

    }
}
