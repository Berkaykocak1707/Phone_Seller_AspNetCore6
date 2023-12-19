﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PhoneRating
    {
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
