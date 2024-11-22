using System.ComponentModel.DataAnnotations;

namespace Nikhil_ST10040092_CLDV6212_Part3.Models
{

    public class Product
    {

        [Key]
        public int Product_Id { get; set; }
        [Required]
        public string? Product_Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public double Product_Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
// code attribution // W3schools // https://www.w3schools.com/cs/index.php

// code attribution //Microsoft //https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started

// code attribution //Microsoft //https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-dotnet-get-started?tabs=azure-ad

// code attribution //Bootswatch //https://bootswatch.com/
