using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        public int OrderId
        {
            get; set;
        }
        public string UserId
        {
            get; set;
        }
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        public String? Name
        {
            get; set;
        }

        public String? Line1
        {
            get; set;
        }
        public String? Line2
        {
            get; set;
        }
        public String? Line3
        {
            get; set;
        }
        public String? City
        {
            get; set;
        }
        public bool GiftWrap
        {
            get; set;
        }
        public bool Shipped
        {
            get; set;
        }
        public DateTime OrderedAt { get; set; }
        public virtual CustomUser? CustomUser
        {
            get; set; 
        }
    }
}
