using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IPhoneRatingRepository : IRepositoryBase<PhoneRating>
    {
        bool IsRated(int OrderId,int PhoneId);
        void RateIt(int OrderId,int PhoneId);
    }
}
