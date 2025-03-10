using Microsoft.AspNetCore.Identity;
using MyAuthApp.Models.Orders;

namespace MyAuthApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
