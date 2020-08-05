using System;
using System.Collections.Generic;
using System.Text;

namespace AeriSample.Service.Model.DTO
{
    public class ProductCostHistoryDTO
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal StandardCost { get; set; }
    }
}
