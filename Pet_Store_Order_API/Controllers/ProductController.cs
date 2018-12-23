using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pet_Store_Order_API.Models;

namespace Pet_Store_Order_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly List<Items> products;
        /*
         * static HttpClient client = new HttpClient();
         * 
         * 
         * public ProductController()
         * {
         * }
         * 
         * //GET list of products 
         * public IEnumerable<string> GetAllProducts()
         * {
         *  string url = "https://petstoreapp.azurewebsites.net/api/products";
         *  string products = null;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<string>();
            }
            return products;
         * 
         }
         */


    }
}