using Entities.Dtos;
using Entities.Models;
using DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.RequestParameters;

namespace DataAccess.Contracts
{
    public interface IPhoneRepository : IRepositoryBase<Phone>
    {
        IQueryable<Phone> FindAllPhone(bool trackChanges);
        IQueryable<Phone> FindAllPhoneWithBrand(PhoneRequestParameters requestParameters,bool trackChanges);
        IQueryable<Phone> FindPhonesWithBrandForHome(PhoneRequestParameters requestParameters);
        IQueryable<Phone> FindAllPhoneWithBrandForHome(PhoneRequestParameters requestParameters);
        IQueryable<Phone> RandomPhonesForRelatedItem(int id,int randomPhoneNumber);
        Phone? GetOnePhone(int id, bool trackChanges);
        Phone? GetOnePhoneWithSlug(string slug);
        void AddRating(int phoneId, double rating);
        void CreatePhone(Phone phone);
        void DeletePhone(Phone phone);
        void UpdatePhone(Phone phone);
    }
}
