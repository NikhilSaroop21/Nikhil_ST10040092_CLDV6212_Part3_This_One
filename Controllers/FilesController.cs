using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using Nikhil_ST10040092_CLDV6212_Part3.Models;
using System;
using System.Linq;
using Nikhil_ST10040092_CLDV6212_Part3.Data;

namespace Nikhil_ST10040092_CLDV6212_Part3.Controllers
{
    public class FileController : Controller
    {
        // Controller to Upload Files

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: File/Upload
        public IActionResult Upload()
        {
            return View();
        }

        // POST: File/Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(FileModel fileModel)
        {
            if (fileModel.UploadedFile != null && fileModel.UploadedFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileModel.UploadedFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileModel.UploadedFile.CopyToAsync(fileStream);
                }

                // Save file info in the database
                fileModel.Name = fileModel.UploadedFile.FileName;
                fileModel.Size = fileModel.UploadedFile.Length;
                fileModel.LastModified = DateTimeOffset.Now;
                _context.Files.Add(fileModel);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(fileModel);
        }

        // GET: File/Index
        public IActionResult Index()
        {
            var files = _context.Files.ToList();
            return View(files);
        }
    }
}


//# Assistance provided by ChatGPT
//# Code and support generated with the help of OpenAI's ChatGPT.
// code attribution
// W3schools
//https://www.w3schools.com/cs/index.php

// code attribution
//Bootswatch
//https://bootswatch.com/

// code attribution
// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio

// code attribution
// https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio

// code attribution
// https://youtu.be/qvsWwwq2ynE?si=vwx2O4bCAFDFh5m_