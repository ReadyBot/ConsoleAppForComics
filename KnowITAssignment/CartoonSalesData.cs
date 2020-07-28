using System;
using System.Collections.Generic;
using System.Text;

namespace KnowITAssignment
{
    public class CartoonSalesData
    {
        public CartoonSalesData()
        {
            CartoonSalesList = new List<CartoonSales>();
        }
        public List<CartoonSales> CartoonSalesList { get; set; }
    }
    
}
