using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class OrderRepositoryExtension
    {
        public static IQueryable<Order> ToPaginate(this IQueryable<Order> orders,
            int pageNumber, int pageSize)
        {
            return orders
                .Skip(((pageNumber - 1) * pageSize))
                .Take(pageSize);
        }
        public static IQueryable<Order> FindAllByCondition(this IQueryable<Order> order, Func<Order, bool> condition = null)
        {

            if (condition != null)
            {
                order = order.Where(condition).AsQueryable();
            }

            return order;
        }
        public static Order FindById(this IQueryable<Order> orders, int orderId)
        {
            return orders.FirstOrDefault(order => order.OrderId == orderId);
        }

    }
}
