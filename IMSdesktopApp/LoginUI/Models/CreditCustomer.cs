using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUI.Models
{
    class CreditCustomer
    {
        public string customerName { get; set; }
        public string phoneNumber { get; set; }
        public float creditAmount { get; set; }
        public int id { get; set; }
        public DateTime addedDate { get; set; }
    }
}
