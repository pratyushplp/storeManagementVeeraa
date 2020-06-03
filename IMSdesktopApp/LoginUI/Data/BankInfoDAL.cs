using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginUI.Data
{
    class BankInfoDAL
    {
        #region get the current bank balance of a specific bank
        public float GetCurrentBalance(string bank)
        {
            float value=0;
            try
            {
                string sql = @"Select balance from BankInfo where bank_name = @bankName";
                SqlCommand cmd = new SqlCommand(sql,DbClass.con);
                cmd.Parameters.AddWithValue("@bankName", bank);
                DbClass.openConnection();
                var temp =cmd.ExecuteScalar();
                value = float.Parse(temp.ToString());

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

            finally
            {
                DbClass.closeConnection();
            }


            return value;
        }
        #endregion




        #region increase the bank balance once transaction hasbeen made through credit card 
        public bool IncreaseBankBalance(float amount,string bankName)
        {
            bool success = false;
            try
            {
                string sql = @"Update BankInfo SET balance = @balance WHERE bank_name = @bankName";

                SqlCommand cmd = new SqlCommand(sql, DbClass.con);

                float curBalance = GetCurrentBalance(bankName);
                float incBalance = curBalance + amount;

                cmd.Parameters.AddWithValue("@balance", incBalance);
                cmd.Parameters.AddWithValue("@bankName", bankName);

                DbClass.openConnection();

                int rows=cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    success = true;
                }


            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

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

