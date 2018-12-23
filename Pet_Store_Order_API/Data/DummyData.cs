using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pet_Store_Order_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This is a class that stores the Dummy Data into a SQL Database
//The data is intended to mimic the data being recieved and called from the Inventory API
//The HTTP Client calls will be in the Controller classes, but commented out. 

namespace Pet_Store_Order_API.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<OrderContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any items
                if (context.Items != null && context.Items.Any())
                    return;   // DB has already been seeded

                
                var items = GetItems().ToArray();
                context.Items.AddRange(items);
                context.SaveChanges();

                var orderSummary = GetOrders(context).ToArray();
                context.Orders.AddRange(orderSummary);
                context.SaveChanges();
            }
        }

       
        public static List<Items> GetItems()
        {
            List<Items> Items = new List<Items>() {
                new Items{ProductID = "8ed0e6f7", Quantity = 1, ProductName="Dog Food", ProductPrice=12.99 },
                new Items{ProductID ="c0258525", Quantity = 3, ProductName="Cat Food", ProductPrice=10.99 },
                new Items{ProductID = "0a207870", Quantity = 2, ProductName="Fish Food", ProductPrice=5.99 }

            };
            return Items;
        }

        public static List<Order> GetOrders(OrderContext db)
        {
            List<Items> items = new List<Items>(db.Items.Take(3)); //Takes the 3 Items from the Item DB

            List<Order> OrderSums = new List<Order>() {
                new Order {
                    OrderID = "1",
                    CustomerID = "12345",
                    Items = items
                }
          
            };
            return OrderSums;
        }
    }
}
