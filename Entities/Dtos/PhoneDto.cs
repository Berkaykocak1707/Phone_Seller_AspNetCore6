using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.Dtos
{
    public record PhoneDto
    {
        public int PhoneID
        {
            get; init;
        }
        public int BrandID
        {
            get; init;
        }

        [Required]
        [StringLength(100)]
        public string PhoneName
        {
            get; init;
        }

        [Required]
        [StringLength(100)]
        public string PhoneSlug
        {
            get; set;
        }

        [Required]
        [StringLength(50)]
        public string PhoneCode
        {
            get; set;
        }

        public string PhonePhotoUrl
        {
            get; set;
        }

        public string PhoneDetail
        {
            get; init;
        }

        public int PhoneStock
        {
            get; init;
        }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PhonePrice
        {
            get; init;
        }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PhoneOldPrice
        {
            get; init;
        }

        public int? PhoneRating
        {
            get; init;
        }

        public int? PhoneRatingCountUser
        {
            get; init;
        }
        public int PhoneStar
        {
            get
            {
                if (PhoneRating.HasValue && PhoneRatingCountUser.HasValue && PhoneRatingCountUser.Value != 0)
                {
                    return PhoneRating.Value / PhoneRatingCountUser.Value;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool PhoneOnSale
        {
            get; init;
        } = true;

        public bool PhoneIsActive
        {
            get; init;
        } = true;
        public virtual Brand? Brand
        {
            get; set;
        }
        public virtual PhoneRating? Rating
        {
            get; set;
        }

    }
}
