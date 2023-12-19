using AutoMapper;
using Business.Contracts;
using DataAccess;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PhoneManager : IPhoneService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PhoneManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<PhoneDto> GetAllPhones()
        {
            var phones = _repositoryManager.Phone.FindAllPhone(trackChanges: false).ToList();
            var phonesDto = _mapper.Map<IEnumerable<PhoneDto>>(phones);
            return phonesDto;
        }
        public IEnumerable<PhoneDto> FindAllPhoneWithBrand(PhoneRequestParameters requestParameters, bool trackChanges)
        {
            var phoneEntity = _repositoryManager.Phone.FindAllPhoneWithBrand(requestParameters,trackChanges).ToList();
            var phoneDto = _mapper.Map<IEnumerable<PhoneDto>>(phoneEntity);
            return phoneDto;
        }
        public IEnumerable<PhoneDto> FindAllPhoneWithBrandForHome(PhoneRequestParameters requestParameters)
        {
            var phoneEntity = _repositoryManager.Phone.FindAllPhoneWithBrandForHome(requestParameters);
            var phoneDto = _mapper.Map<IEnumerable<PhoneDto>>(phoneEntity);
            return phoneDto;
        }
        public IEnumerable<PhoneDto> FindPhonesWithBrandForHome(PhoneRequestParameters requestParameters)
        {
            var phoneEntity = _repositoryManager.Phone.FindPhonesWithBrandForHome(requestParameters);
            var phoneDto = _mapper.Map<IEnumerable<PhoneDto>>(phoneEntity);
            return phoneDto;
        }
        public PhoneDto GetPhoneById(int id)
        {
            var phone = _repositoryManager.Phone.GetOnePhone(id, trackChanges: false);
            var phoneDto = _mapper.Map<PhoneDto>(phone);
            return phoneDto;
        }
        public PhoneDto? GetOnePhoneWithSlug(string slug)
        {
            var phone = _repositoryManager.Phone.GetOnePhoneWithSlug(slug);
            var phoneDto = _mapper.Map<PhoneDto>(phone);
            return phoneDto;
        }
        public PhoneDtoForUpdate GetPhoneByIdForUpdate(int id)
        {
            var phone = _repositoryManager.Phone.GetOnePhone(id, trackChanges: false);
            var phoneDto = _mapper.Map<PhoneDtoForUpdate>(phone);
            return phoneDto;
        }
        public PhoneDto CreatePhone(PhoneDtoForCreation phoneDto)
        {
            var phoneEntity = _mapper.Map<Phone>(phoneDto);
            _repositoryManager.Phone.CreatePhone(phoneEntity);
            _repositoryManager.Save();

            var phoneToReturn = _mapper.Map<PhoneDto>(phoneEntity);
            return phoneToReturn;
        }

        public void UpdatePhone(int id, PhoneDtoForUpdate phoneDto)
        {
            var phoneEntity = _repositoryManager.Phone.GetOnePhone(id, trackChanges: true);
            _mapper.Map(phoneDto, phoneEntity);
            _repositoryManager.Save();
        }

        public void DeletePhone(int id)
        {
            var phoneEntity = _repositoryManager.Phone.GetOnePhone(id, trackChanges: false);
            _repositoryManager.Phone.DeletePhone(phoneEntity);
            _repositoryManager.Save();
        }

        public string AddRating(int phoneId, int orderId, double rating)
        {
            var Rated = _repositoryManager.phoneRatingRepository.IsRated(orderId,phoneId);
            if (Rated is true)
            {
                return "This phone is rated";
            }
            else
            {
                _repositoryManager.Phone.AddRating(phoneId,rating);
                _repositoryManager.phoneRatingRepository.RateIt(orderId, phoneId);
            }
            return "Thank you for rating!";
        }

        public IEnumerable<PhoneDto> RandomPhonesForRelatedItem(int id, int randomPhoneNumber)
        {
            var phone = _repositoryManager.Phone.RandomPhonesForRelatedItem(id,randomPhoneNumber);
            var phoneDto = _mapper.Map<IEnumerable<PhoneDto>>(phone);
            return phoneDto;
        }
    }

}
