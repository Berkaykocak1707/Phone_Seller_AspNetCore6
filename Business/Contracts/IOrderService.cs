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
    public interface IOrderService
    {
        Order? GetOneOrderForComplete(int orderId);
        IEnumerable<OrderDto> FindAllOrdersWithUserId(OrderRequestParameters requestParameters);
        IEnumerable<OrderDto> GetOrdersWithParameters(OrderRequestParameters requestParameters);
        int OrderCount(string userID);
        IEnumerable<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int orderId);
        OrderDto CreateOrder(OrderDtoForCreation orderDto);
        void UpdateOrder(int orderId, OrderDtoForUpdate orderUpdateDto);
        void DeleteOrder(int orderId);
        void MarkAsShipped(int orderId);
    }

}
