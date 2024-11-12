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