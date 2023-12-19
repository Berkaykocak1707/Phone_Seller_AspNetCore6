using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record BrandDto
    {
        public int BrandID
        {
            get; init;
        }

        [Required]
        [StringLength(100)]
        public string BrandName
        {
            get; init;
        }

        [Required]
        [StringLength(50)]
        public string BrandCode
        {
            get; init;
        }
        public virtual ICollection<Phone>? Phones
        {
            get; set;
        }
    }
}
