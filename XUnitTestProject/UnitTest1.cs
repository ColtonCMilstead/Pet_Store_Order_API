using Microsoft.AspNetCore.Mvc;
using Pet_Store_Order_API.Controllers;
using Pet_Store_Order_API.Data;
using Pet_Store_Order_API.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        private readonly OrderContext context;

        [Fact]
        public void Test1()
        {

            OrdersController _controller = new OrdersController(context);
            //Enter a new Order 
            Order _order = new Order
            {
                    OrderID = "3",
                    CustomerID = "56984",
                    Items = new List<Items> {
            
                        new Items{ ProductID = "78exggf", Quantity = 1, ProductName="Gold Fish", ProductPrice=11.99 },
                        new Items{ ProductID ="uffhghfj", Quantity = 1, ProductName="Fish Tank", ProductPrice=20.59 },
    
                    }
            };


            //Ensure that Total Cost for Order is correct
            //$32.58 is the Total Cost of the order 

            var result = _controller.PostOrder(_order);
            Assert.Equal(32.58, _order.Total);
        }
    }
}

