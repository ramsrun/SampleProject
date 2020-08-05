using System;
using System.Collections.Generic;
using System.Text;

namespace AeriSample.Data.Entity
{
    public class ProductCostHistory
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  decimal StandardCost { get; set; }

    }
}
