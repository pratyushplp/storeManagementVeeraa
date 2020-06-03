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
            DataTable data = new DataTable();
            try
            {
                string sql = @"Select product_type,remaining_unit,total_cost_per_unit,selling_price FROM ProductTable";
                SqlCommand cmd = new SqlCommand(sql, DbClass.con);
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

    }
}
