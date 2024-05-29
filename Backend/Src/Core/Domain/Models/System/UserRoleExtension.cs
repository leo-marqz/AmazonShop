
namespace AmazonShop.Domain.Models.System
{
    public static class UserRoleExtension
    {
        public static string Text(this UserRole role){

            string userRole = string.Empty;

            switch (role)
            {
                case UserRole.Admin:
                    userRole = "Admin";
                    break;
                case UserRole.Vendor:
                    userRole = "Vendor";
                    break;
                case UserRole.Customer:
                    userRole = "Customer";
                    break;
                case UserRole.Guest:
                    userRole = "Guest";
                    break;
                case UserRole.Moderator:
                    userRole = "Moderator";
                    break;
                case UserRole.SupportAgent:
                    userRole = "SupportAgent";
                    break;
                default:
                    userRole = "Customer";
                    break;
            }

            return userRole;
        }
    }
}