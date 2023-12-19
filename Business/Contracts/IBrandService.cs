using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetAllBrands();
        BrandDto GetBrandById(int brandId);
        BrandDtoForUpdate GetBrandByIdForUpdate(int brandId);
        BrandDto CreateBrand(BrandDtoForCreation brandDto);
        void UpdateBrand(int brandId, BrandDtoForUpdate brandUpdateDto);
        void DeleteBrand(int brandId);
    }
}
