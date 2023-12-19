using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CartLine
    {
        public int CartLineID
        {
            get; set;
        }
        public Phone Phone { get; set; } = new();
        public int Quantity
        {
            get; set;
        }
    }
}
