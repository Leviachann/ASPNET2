
namespace Homework2.Controllers
{
    using Homework2.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product editedProduct)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == editedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = editedProduct.Name;
                existingProduct.Description = editedProduct.Description;
                existingProduct.Price = editedProduct.Price;
                existingProduct.Discount = editedProduct.Discount;
                existingProduct.PictureUrl = editedProduct.PictureUrl;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            newProduct.Id = products.Count + 1; 
            products.Add(newProduct);

            return RedirectToAction("Index");
        }
    }

}
