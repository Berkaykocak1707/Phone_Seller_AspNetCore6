using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class PhoneRepositoryExtension
    {
        public static IQueryable<Phone> FilteredByBrandID(this IQueryable<Phone> phones,int? brandID)
        {
            if (brandID is null)
                return phones;
            else
                return phones.Where(prd => prd.BrandID.Equals(brandID));
        }
        public static IQueryable<Phone> ToPaginate(this IQueryable<Phone> phones,
            int pageNumber, int pageSize)
        {
            return phones
                .Skip(((pageNumber - 1) * pageSize))
                .Take(pageSize);
        }
        public static IQueryable<Phone> FindInclude(this IQueryable<Phone> phones,  params Expression<Func<Phone, object>>[] includes)
        {
            if (includes != null)
               return phones = includes.Aggregate(phones, (current, include) => current.Include(include));
            else   
               return phones;
        }
        public static IQueryable<Phone> FindAllByCondition(this IQueryable<Phone> phones, Func<Phone, bool> condition = null)
        {

            if (condition != null)
            {
                phones = phones.Where(condition).AsQueryable();
            }

            return phones;
        }

    }
}
