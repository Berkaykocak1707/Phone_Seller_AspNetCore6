using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IPhoneService
    {
        IEnumerable<PhoneDto> GetAllPhones();
        IEnumerable<PhoneDto> FindAllPhoneWithBrand(PhoneRequestParameters requestParameters, bool trackChanges);
        IEnumerable<PhoneDto> FindPhonesWithBrandForHome(PhoneRequestParameters requestParameters);
        IEnumerable<PhoneDto> FindAllPhoneWithBrandForHome(PhoneRequestParameters requestParameters);
        IEnumerable<PhoneDto> RandomPhonesForRelatedItem(int id, int randomPhoneNumber);
        PhoneDto GetPhoneById(int id);
        public PhoneDto? GetOnePhoneWithSlug(string slug);
        PhoneDtoForUpdate GetPhoneByIdForUpdate(int id);
        PhoneDto CreatePhone(PhoneDtoForCreation phoneDto);
        string AddRating(int phoneId, int orderId, double rating);
        void UpdatePhone(int id, PhoneDtoForUpdate phoneUpdateDto);
        void DeletePhone(int id);
    }
}
