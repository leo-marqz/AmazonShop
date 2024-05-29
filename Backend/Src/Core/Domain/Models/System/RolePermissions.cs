
using System.Collections.Generic;
using Domain.Models.System;

namespace AmazonShop.Domain.Models.System
{
    public class RolePermissions
    {
        public static List<Permission> GetPermissions()
        {
            return new List<Permission>
            {
                new Permission
                {
                    Role = UserRole.Admin,
                    Permissions = new List<string> { "ManageUsers", "ManageProducts", "ManageCategories", "ViewAllOrders", "ConfigureSystem", "AccessReports" }
                },
                new Permission
                {
                    Role = UserRole.Vendor,
                    Permissions = new List<string> { "AddProduct", "EditProduct", "ViewOwnOrders", "ViewSalesReports", "ManageInventory", "UpdateProfile" }
                },
                new Permission
                {
                    Role = UserRole.Customer,
                    Permissions = new List<string> { "ViewProducts", "PurchaseProducts", "ViewOrderHistory", "LeaveReviews", "ManageProfile", "CreateWishlist" }
                },
                new Permission
                {
                    Role = UserRole.Guest,
                    Permissions = new List<string> { "ViewProducts", "AddToCart", "Register" }
                },
                new Permission
                {
                    Role = UserRole.Moderator,
                    Permissions = new List<string> { "ReviewComments", "ManageReports", "ModerateContent" }
                },
                new Permission
                {
                    Role = UserRole.SupportAgent,
                    Permissions = new List<string> { "ViewTickets", "AssistCustomers", "ResolveAccountIssues" }
                }
            };
        }
    }
}