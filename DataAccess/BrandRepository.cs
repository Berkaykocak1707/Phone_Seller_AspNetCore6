using DataAccess.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public sealed class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateBrand(Brand brand) => Create(brand);

        public void DeleteBrand(Brand brand) => Delete(brand);

        public IQueryable<Brand> FindAllBrands(bool trackChanges) => FindAll(trackChanges);

        public Brand? GetOneBrand(int id, bool trackChanges) => FindByCondition(b => b.BrandID.Equals(id), trackChanges);

        public void UpdateBrand(Brand brand) => Update(brand);
    }
}
