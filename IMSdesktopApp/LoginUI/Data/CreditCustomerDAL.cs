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
    class CreditCustomerDAL
    {
        #region Select credit customer using their name or customer ID ,NOTE: while adding and deleting a customer active flag is used, if 1 then present if 0 then deleted, this is done to keep track of deleted customers
        public DataTable Search(string input)

        {
            DataTable temp = new DataTable();

            string sql = @"select customer_id as 'Id', customer_name ,credit_amount,phone_number,added_date as 'joined_date'  from creditCustomer where 
                            ( customer_name like '%"+input+ @"%' or 
                            customer_id like '"+ input + @"') and active = '1'";

            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            
            try
            {
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

        #region update credit balance for credit customer
        public bool UpdateCredit(float amount, int Id)
        {
            bool success = false;

            string sql = @"update CreditCustomer set credit_amount = credit_amount + @amount where customer_id =@id and active ='1' ";

            SqlCommand cmd = new SqlCommand(sql,DbClass.con);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@id", Id);

            try
            {
                DbClass.openConnection();
                int rows=cmd.ExecuteNonQuery();
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
                MessageBox.Show(ex.Message,"Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            finally
            {
                DbClass.closeConnection();

            }


            return success;

        }
        #endregion

        #region Show all credit customers

        public DataTable ShowAll()

        {
            DataTable temp = new DataTable();

            string sql = @"select customer_id as 'Id', customer_name ,credit_amount,phone_number,added_date as 'joined_date'  from creditCustomer where 
                           active = '1'";

            SqlCommand cmd = new SqlCommand(sql, DbClass.con);

            try
            {
                DbClass.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(temp);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Credit Customer not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                DbClass.closeConnection();
            }

            return temp;
        }

        #endregion

        #region add credit customer   ,NOTE: while adding and deleting a customer active flag is used, if 1 then present if 0 then deleted, this is done to keep track of deleted customers
        public bool AddCreditCustomer(CreditCustomer creditCustomer)
        {
            bool success = false;


            string sql = @"insert into CreditCustomer(customer_name,phone_number,credit_amount,added_date,active) values (@fullName,@phoneNumber,@creditAmount,@addedDate,1) ";

            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            cmd.Parameters.AddWithValue("@fullName", creditCustomer.customerName);
            cmd.Parameters.AddWithValue("@phoneNumber", creditCustomer.phoneNumber);
            cmd.Parameters.AddWithValue("@creditAmount", creditCustomer.creditAmount);
            cmd.Parameters.AddWithValue("@addedDate", creditCustomer.addedDate);


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

        #region delete credit customer   ,NOTE: while adding and deleting a customer active flag is used, if 1 then present if 0 then deleted, this is done to keep track of deleted customers
        public bool DeleteCreditCustomer(int Id)
        {
            bool success = false;

            string sql = @"update CreditCustomer set active= 0 where customer_id= @Id ";

            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            cmd.Parameters.AddWithValue("@Id", Id);

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

        #region Validate if customer is present or not using credit customer name and Id
        public bool IsCrCustomerPresent(string customerName, int customerId)
        {
            bool success = false;
            string sql = @"select COUNT(*) from CreditCustomer where customer_name= @customerName and 
                           customer_id = @customerId and
                           active = 1";
            SqlCommand cmd = new SqlCommand(sql, DbClass.con);
            cmd.Parameters.AddWithValue("@customerName", customerName);
            cmd.Parameters.AddWithValue("@customerId", customerId);



            try
            {
                DbClass.openConnection();
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    if (int.Parse(obj.ToString()) == 1) success = true;

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

    }
}
