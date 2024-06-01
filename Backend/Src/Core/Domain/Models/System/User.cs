
using Microsoft.AspNetCore.Identity;

namespace AmazonShop.Domain.Models.System
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public bool IsActive { get; set; } = true;
    }
}