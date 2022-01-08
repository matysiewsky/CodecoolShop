using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(), SupplierDaoMemory.GetInstance());
        }

        // public IActionResult Index()
        // {
        //     var products = ProductService.GetProductsForCategory(1);
        //     return View(products.ToList());
        // }
        
        
        
        public IActionResult Index(string sortBy="category", int id=1)
        {
            var products = ProductService.GetProductsBy(sortBy, id);
            var categories = ProductService.GetCategories();
            var suppliers = ProductService.GetSuppliers();
            ViewModel model = new ViewModel(products.ToList(), categories.ToList(), suppliers.ToList());
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
