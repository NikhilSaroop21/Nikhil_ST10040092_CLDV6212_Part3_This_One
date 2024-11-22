using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Nikhil_ST10040092_CLDV6212_Part3.Models
{
    public class FileModel
    {
        public int Id { get; set; } // Making sure there is a primary key for the database is available
        
        [Required]
        public string Name { get; set; }
        
        public long Size { get; set; }
        
        public DateTimeOffset? LastModified { get; set; }
        
        [Display(Name = "Upload File")]
        [NotMapped]
        public IFormFile UploadedFile { get; set; }  // New property to for storing the uploaded file temporarily

        public string DisplaySize
        {
            get
            {
                if (Size >= 1024 * 1024)
                    return $"{Size / 1024 / 1024} MB";
                if (Size >= 1024)
                    return $"{Size / 1024} KB";
                return $"{Size} Bytes";
            }
        }
    }
}
// code attribution // W3schools // https://www.w3schools.com/cs/index.php

// code attribution //Microsoft //https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started

// code attribution //Microsoft //https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-dotnet-get-started?tabs=azure-ad

// code attribution //Bootswatch //https://bootswatch.com/
