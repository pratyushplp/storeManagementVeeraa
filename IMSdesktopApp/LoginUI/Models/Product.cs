using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUI.Models
{
    class Product
    {
        public String productType { get; set; }
        public String brandCode { get; set; }
        public String productCode { get; set; }
        public String deliveryAgent { get; set; }
        public String vendor { get; set; }
        public float unitPriceINR { get; set; }
        public float unitPriceNPR { get; set; }
        public float totalUnitIn { get; set; }
        public float remainingUnit { get; set; }
        public float carrierChargePerUnit { get; set; }
        public float totalCostPerUnit { get; set; }
        public float sellingPrice { get; set; }
        public int Id { get; set; }
        public DateTime addedDate { get; set; }

    }


}
