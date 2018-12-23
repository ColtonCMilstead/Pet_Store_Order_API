using Pet_Store_Order_API.Controllers;
using Pet_Store_Order_API.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Ensure that Total Cost for Order is correct
            //Enter a new Order 
            var new_order = new List<Order>()
            {
                new Order{
                    OrderID = "2",
                    CustomerID = "67891",
                    Items = new List<Items>()
                    {
                        new Items{ProductID = "xxxyy34", Quantity = 2, ProductName="Leash", ProductPrice= 6.99 },
                        new Items{ProductID ="aba55643", Quantity = 1, ProductName="Squeaky Toy", ProductPrice=2.99 }
                    }
                }
            };

           // var controller = new OrdersController();
            //var result = controller.PostOrder(new_order);

           // Assert.Equal(9.98, result.Total);

        }
    }
}
