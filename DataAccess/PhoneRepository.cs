using DataAccess.Contracts;
using DataAccess.Extensions;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public sealed class PhoneRepository : RepositoryBase<Phone>, IPhoneRepository
    {
        public PhoneRepository(RepositoryContext context) : base(context)
        {
        }

        public void AddRating(int phoneId, double rating)
        {
            var phone = GetOnePhone(phoneId, false);
            phone.PhoneRating += rating;
            phone.PhoneRatingCountUser += 1;
            UpdatePhone(phone);
        }

        public void CreatePhone(Phone phone) => Create(phone);

        public void DeletePhone(Phone phone) => Delete(phone);

        public IQueryable<Phone> FindAllPhone(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Phone> FindAllPhoneWithBrand(PhoneRequestParameters requestParameters, bool trackChanges)
        {
            return FindInclude(trackChanges, b => b.Brand)
                   .ToPaginate(requestParameters.PageNumber, requestParameters.PageSize);
        }

        public IQueryable<Phone> FindAllPhoneWithBrandForHome(PhoneRequestParameters requestParameters)
        {
            return _context.Phones
                            .FindAllByCondition(stock => stock.PhoneStock > 0)
                            .FindInclude(b => b.Brand)
                            .FilteredByBrandID(requestParameters.BrandID)
                            .ToPaginate(requestParameters.PageNumber, requestParameters.PageSize);
        }

        public IQueryable<Phone> FindPhonesWithBrandForHome(PhoneRequestParameters requestParameters)
        {
            return FindAllByCondition(true,b => b.BrandID.Equals(requestParameters.BrandID));
        }

        public Phone? GetOnePhone(int id, bool trackChanges) => FindByCondition(p => p.PhoneID.Equals(id), trackChanges);

        public Phone? GetOnePhoneWithSlug(string slug)
        {
            return FindByCondition(p => p.PhoneSlug.Equals(slug),false);
        }

        public IQueryable<Phone> RandomPhonesForRelatedItem(int id,int randomPhoneNumber)
        {
            return _context.Phones
                   .FindAllByCondition(stock => stock.PhoneStock > 0)
                   .Where(phone => phone.PhoneID != id)
                   .OrderBy(x => Guid.NewGuid())
                   .Take(randomPhoneNumber);
        }

        public void UpdatePhone(Phone phone) => Update(phone);
    }
}
