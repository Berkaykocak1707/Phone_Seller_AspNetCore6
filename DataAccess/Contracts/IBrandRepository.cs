using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IBrandRepository : IRepositoryBase<Brand>
    {
        IQueryable<Brand> FindAllBrands(bool trackChanges);
        Brand? GetOneBrand(int id, bool trackChanges);
        void CreateBrand(Brand brand);
        void DeleteBrand(Brand brand);
        void UpdateBrand(Brand brand);
    }
}
