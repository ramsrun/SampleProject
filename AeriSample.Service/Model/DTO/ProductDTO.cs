using System;
using System.Collections.Generic;
using System.Text;

namespace AeriSample.Service.Model.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal PriceList { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}
