using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Brand
    {
        public int BrandID
        {
            get; set;
        }

        public string BrandName
        {
            get; set;
        }

        public string BrandCode
        {
            get; set;
        }

        public virtual ICollection<Phone> Phones
        {
            get; set;
        }
    }
}
