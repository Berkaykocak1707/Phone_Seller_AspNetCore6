using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CustomUser : IdentityUser
    {
        public string? OrderId
        {
            get; set;
        }
        public virtual ICollection<Order>? Orders
        {
            get; set;
        }
    }
}
