using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record PhoneRatingDto
    {
        [Key]
        public int PhoneRatingId
        {
            get; set;
        }
        public int OrderId
        {
            get; set;
        }
        public int PhoneId
        {
            get; set;
        }
        public bool IsRated
        {
            get; set;
        }
    }
}
