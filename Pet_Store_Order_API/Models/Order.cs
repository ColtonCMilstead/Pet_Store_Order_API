using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Store_Order_API.Models
{
    public class Order
    {
        [Key]
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public List<Items> Items { get; set; }

        public double Total
        {
            get
            {   //Iterates through list of Order Product Prices & Quantities and calculates the Total 
                double TotalCost = 0;
                for (var i = 0; i < Items.Count; i++)
                {

                    TotalCost += Items[i].Cost;
                }

                return TotalCost;
            }
        }
    }
}


