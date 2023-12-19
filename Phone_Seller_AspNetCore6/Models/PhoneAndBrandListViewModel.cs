using Entities.Dtos;
using Entities.Models;
using Phone_Seller_AspNetCore6.Models;

namespace Phone_Seller_AspNetCore6.Models
{
    public class PhoneAndBrandListViewModel
    {
        public IEnumerable<PhoneDto>? Phones
        {
            get; set;
        } = Enumerable.Empty<PhoneDto>();
        public IEnumerable<BrandDto> Brands
        {
            get; set;
        } = Enumerable.Empty<BrandDto>();
        public Pagination? Pagination
        {
            get; set;
        } = new();
        public PhoneDto? Phone
        {
        get; set; }
        public int TotalCount => Phones.Count();
    }
}