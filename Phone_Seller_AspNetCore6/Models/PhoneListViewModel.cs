using Entities.Dtos;
using Phone_Seller_AspNetCore6.Models;

namespace Phone_Seller_AspNetCore6.Models
{
    public class PhoneListViewModel
    {
        public IEnumerable<PhoneDto>? Phones
        {
            get; set; 
        } = Enumerable.Empty<PhoneDto>();
        public Pagination? Pagination
        {
            get; set;
        } = new();
        public int TotalCount => Phones.Count();
    }
}
