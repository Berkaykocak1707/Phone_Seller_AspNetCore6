using Entities.Dtos;
using Phone_Seller_AspNetCore6.Models;

namespace Phone_Seller_AspNetCore6.Models
{
    public class OrderListViewModel
    {
        public int? UserId
        {
            get; set; 
        }
        public IEnumerable<OrderDto>? Orders
        {
            get; set; 
        } = Enumerable.Empty<OrderDto>();
        public Pagination? Pagination
        {
            get; set;
        } = new();
        public int TotalCount => Orders.Count();
    }
}
