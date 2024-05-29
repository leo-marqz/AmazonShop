

using System.Collections.Generic;
using AmazonShop.Domain.Models.System;

namespace Domain.Models.System
{
    public class Permission
    {
        public Permission()
        {
            var usr = UserRole.Admin.Text();
        }
        public UserRole Role { get; set; }
        public List<string> Permissions { get; set; }
    }
}