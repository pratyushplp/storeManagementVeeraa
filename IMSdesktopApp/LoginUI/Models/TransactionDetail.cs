using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUI.Models
{
    class TransactionDetail
    {
        public string productCode { get; set; }
        public string productType { get; set; }

        public float quantity { get; set; }
        public float unitSellingPrice { get; set; }
        public float totalSellingPrice { get; set; }
        public int billNumber { get; set; }


    }
}
