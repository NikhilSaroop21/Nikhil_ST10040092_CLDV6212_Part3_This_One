
// Imports necessary namespaces for ASP.NET Core MVC, logging, and diagnostics

using Microsoft.AspNetCore.Mvc;
using Nikhil_ST10040092_CLDV6212_Part3.Models;
using System.Diagnostics;

namespace Nikhil_ST10040092_CLDV6212_Part3.Controllers
{    //The  Controller for handling home page requests and error logging

    public class HomeController : Controller
    {        // Dependency injection for the ILogger service to log application events

        private readonly ILogger<HomeController> _logger;
        // Constructor to initialize the ILogger instance for logging purposes

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Action to render the home page (GET: Home/Index)

        public IActionResult Index()
        {
            return View();
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
// code attribution // W3schools // https://www.w3schools.com/cs/index.php

// code attribution //Microsoft //https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started

// code attribution //Microsoft //https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-dotnet-get-started?tabs=azure-ad

// code attribution //Bootswatch //https://bootswatch.com/
