using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Phone
    {
        public int PhoneID
        {
            get; set;
        }

        public int BrandID
        {
            get; set;
        }

        public string PhoneName
        {
            get; set;
        }

        public string PhoneSlug
        {
            get; set;
        }

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
            get; set;
        }

        public int PhoneStock
        {
            get; set;
        }

        public decimal PhonePrice
        {
            get; set;
        }

        public decimal? PhoneOldPrice
        {
            get; set;
        }

        public double PhoneRating
        {
            get; set;
        }

        public int PhoneRatingCountUser
        {
            get; set;
        }

        public int PhoneStar
        {
            get; set;
        }

        public bool PhoneOnSale
        {
            get; set;
        } = true;

        public bool PhoneIsActive
        {
            get; set;
        } = true;

        public virtual Brand? Brand
        {
            get; set;
        }
    }
}
