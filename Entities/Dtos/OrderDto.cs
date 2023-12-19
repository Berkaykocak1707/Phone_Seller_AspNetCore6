using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record OrderDto
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

        [Required(ErrorMessage = "Name is required.")]
        public String? Name
        {
            get; init;
        }

        [Required(ErrorMessage = "Line1 is required.")]
        public String? Line1
        {
            get; init;
        }
        public String? Line2
        {
            get; init;
        }
        public String? Line3
        {
            get; init;
        }
        public String? City
        {
            get; init;
        }
        public bool GiftWrap
        {
            get; init;
        }
        public bool Shipped
        {
            get; init;
        }
        public DateTime OrderedAt { get; init; } = DateTime.Now;
        public virtual CustomUser? CustomUser
        {
        get; set; }
        public virtual PhoneRating? Rating
        {
            get; set;
        }
    }
}
