using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BrandManager : IBrandService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BrandManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<BrandDto> GetAllBrands()
        {
            var brands = _repositoryManager.Brand.FindAllBrands(trackChanges: false).ToList();
            var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandsDto;
        }

        public BrandDto GetBrandById(int id)
        {
            var brand = _repositoryManager.Brand.GetOneBrand(id, trackChanges: false);
            if (brand == null)
            {
                // Handle not found
            }
            var brandDto = _mapper.Map<BrandDto>(brand);
            return brandDto;
        }

        public BrandDto CreateBrand(BrandDtoForCreation brandDto)
        {
            var brandEntity = _mapper.Map<Brand>(brandDto);
            _repositoryManager.Brand.CreateBrand(brandEntity);
            _repositoryManager.Save();

            var brandToReturn = _mapper.Map<BrandDto>(brandEntity);
            return brandToReturn;
        }

        public void UpdateBrand(int id, BrandDtoForUpdate brandUpdateDto)
        {
            var brandEntity = _repositoryManager.Brand.GetOneBrand(id, trackChanges: true);
            if (brandEntity == null)
            {
                // Handle not found
            }

            _mapper.Map(brandUpdateDto, brandEntity);
            _repositoryManager.Save();
        }

        public void DeleteBrand(int id)
        {
            var brandEntity = _repositoryManager.Brand.GetOneBrand(id, trackChanges: false);
            if (brandEntity == null)
            {
                // Handle not found
            }

            _repositoryManager.Brand.DeleteBrand(brandEntity);
            _repositoryManager.Save();
        }

        public BrandDtoForUpdate GetBrandByIdForUpdate(int brandId)
        {
            var brand = _repositoryManager.Brand.GetOneBrand(brandId, true);
            var brandDto = _mapper.Map<BrandDtoForUpdate>(brand);
            return brandDto;
        }
    }
}
