using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Nikhil_ST10040092_CLDV6212_Part3.Models;

namespace Nikhil_ST10040092_CLDV6212_Part3.Areas.Identity.Pages.Account
{
    //This is a Controller to ehich will be Displaying All Users to the Admin Only

    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Account/Index
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userList = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new UserViewModel
                {
                    FirstName = (user as ApplicationUser)?.FirstName,                 // The Assumption that the  FirstName is in your custom User class
                    Email = user.Email,
                    Role = roles.FirstOrDefault() // Going with the assumption  that each user has a single role
                });
            }

            return View(userList);
        }
    }

    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}

// code attribution // W3schools // https://www.w3schools.com/cs/index.php

// code attribution //Microsoft //https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started

// code attribution //Microsoft //https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-dotnet-get-started?tabs=azure-ad

// code attribution //Bootswatch //https://bootswatch.com/
