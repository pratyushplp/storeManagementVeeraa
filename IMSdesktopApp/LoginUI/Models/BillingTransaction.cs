using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUI.Models
{
    class BillingTransaction
    {
        public int Id { get; set; }
        public string customerType { get; set; }
        public string customerName { get; set; }
        public string customerId { get; set; }
        public int billNumber { get; set; } 
        public DateTime transactionDate { get; set; }
        public float totalAmount { get; set; }
        public float discount { get; set; }
        public float VAT { get; set; }
        public string paymentMethod { get; set; }
        public string bankName { get; set; }
        public float totalQty { get; set; }


        public DataTable transactionDetail { get; set; }


    }
}
