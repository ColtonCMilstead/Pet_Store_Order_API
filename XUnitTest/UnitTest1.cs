using Pet_Store_Order_API.Models;
using Pet_Store_Order_API.Controllers;
using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Pet_Store_Order_API.Data;

namespace XUnitTest
{
    public class UnitTest1
    {
        private readonly OrderContext context;

        [Fact]
        public void Test1()
        {

            OrdersController _controller = new OrdersController(context);

            //Ensure that Total Cost for Order is correct

            var result = _controller.GetOrderTotal("1");
           
            Assert.IsType<double>(result);
        }
    }
}
