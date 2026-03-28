using Microsoft.AspNetCore.Mvc;
using OnlineProduct.Models;
using OnlineProduct.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        // Dummy data (instead of DB)
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 70000, ImageUrl = "https://s.alicdn.com/@sc04/kf/H083f2925426a4a91ba2a32d1bda1f2c7N/14-Inch-New-Ordinateur-Business-Laptop-AMD-Windows-11-Pro-New-Ordinateur-Laptops-Brand-New-WIFI6-BT5-1920-1080-IPS.jpg_300x300.jpg" },
            new Product { Id = 2, Name = "Phone", Description = "Latest smartphone", Price = 30000, ImageUrl = "https://lh3.googleusercontent.com/pAL1E25kbmZVhlcxdXVerjK3heqnYCWoNbKNNDFOLJkjm3-sWTZmFKX05NyIocvwF-pjPI_EzCFq-BPKs0F7D1st-FJHPBguZZz8jH0Gwf78OngObf-k=w1200-rwa-e366-v1" },
            new Product { Id = 3, Name = "Headphones", Description = "Noise cancelling", Price = 5000, ImageUrl = "https://www.urbanears.com/in/en/headphones/" }
        };

        // GET: Product
        public IActionResult Index(string search)
        {
            var filteredProducts = products;

            if (!string.IsNullOrEmpty(search))
            {
                filteredProducts = products
                    .Where(p => p.Name.ToLower().Contains(search.ToLower()))
                    .ToList();
            }

            return View(filteredProducts);
        }

        // GET: Product/Details/1
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}