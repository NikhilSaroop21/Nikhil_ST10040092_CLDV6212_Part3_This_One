using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nikhil_ST10040092_CLDV6212_Part3.Models;

namespace Nikhil_ST10040092_CLDV6212_Part3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
    }
}
