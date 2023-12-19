using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IQueryable<Order> Orders
        {
            get;
        }
        IQueryable<Order> FindAllOrders();
        int OrderCount(string userID);
        IQueryable<Order> FindAllOrdersWithUserId(OrderRequestParameters requestParameters);
        Order? GetOneOrder(int orderId);
        Order? GetOneOrderForComplete(int orderId);
        IQueryable<Order> GetOrdersWithParameters(OrderRequestParameters requestParameters);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
        void MarkAsShipped(int orderId);
    }
}
