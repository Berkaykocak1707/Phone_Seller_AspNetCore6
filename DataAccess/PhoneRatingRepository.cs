using DataAccess.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PhoneRatingRepository : RepositoryBase<PhoneRating>, IPhoneRatingRepository
    {
        public PhoneRatingRepository(RepositoryContext context) : base(context)
        {
        }

        public bool IsRated(int OrderId, int PhoneId)
        {
           return _context.PhoneRatings.Any(pr => pr.OrderId == OrderId && pr.PhoneId == PhoneId);
        }

        public void RateIt(int OrderId, int PhoneId)
        {
            var phoneRating = _context.PhoneRatings
            .FirstOrDefault(pr => pr.OrderId == OrderId && pr.PhoneId == PhoneId);
            if (phoneRating != null)
            {
                phoneRating.IsRated = true;
                _context.SaveChanges();
            }
            else
            {
                var newPhoneRating = new PhoneRating
                {
                    OrderId = OrderId,
                    PhoneId = PhoneId,
                    IsRated = true
                };

                _context.PhoneRatings.Add(newPhoneRating);

                _context.SaveChanges();
            }
        }
    }
}
