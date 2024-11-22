using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nikhil_ST10040092_CLDV6212_Part3.Data;
using Nikhil_ST10040092_CLDV6212_Part3.Models;
using System.IO;

namespace Nikhil_ST10040092_CLDV6212_Part3.Controllers
{

    // The Controller will be Adding Products, Edit Products and Delete Products.

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        //  Product/Create
        public IActionResult Create()
        {
            return View();
        }

        //  Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Save the image file
                    var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }
                    product.ImageUrl = "/images/" + uniqueFileName;
                }

                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //  Product/Index
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        //  Product/IndexAdmin
        public IActionResult Admin()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        //  Product/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //  Product/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product, IFormFile imageFile)
        {
            if (id != product.Product_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Save the new image file
                    var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }
                    product.ImageUrl = "/images/" + uniqueFileName;
                }

                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(product);
        }
    }
}
// code attribution // W3schools // https://www.w3schools.com/cs/index.php

// code attribution //Microsoft //https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started

// code attribution //Microsoft //https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-dotnet-get-started?tabs=azure-ad

// code attribution //Bootswatch //https://bootswatch.com/
