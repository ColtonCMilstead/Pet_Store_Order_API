using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Store_Order_API.Models
{
    public class Items
    {
        [Key]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }

        public double Cost
        {
            get
            {
                return ProductPrice * Quantity;
            }
        }
            
    }
}

