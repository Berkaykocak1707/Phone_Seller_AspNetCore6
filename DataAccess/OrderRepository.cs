using AutoMapper;
using DataAccess.Contracts;
using DataAccess.Extensions;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly IMapper _mapper; 
        public OrderRepository(IMapper mapper,RepositoryContext context) : base(context)
        {
            _mapper = mapper;
        }


        public void CreateOrder(Order order)
        {
            var phones = order.Lines.Select(l => _mapper.Map<Phone>(l.Phone)).ToList();
            _context.AttachRange(phones);
            if (order.OrderId == 0)
            {
                _context.Orders.Add(order);
                foreach (var phone in order.Lines)
                {
                    phone.Phone.PhoneStock -= phone.Quantity;
                }
            }
            _context.SaveChanges();
        }

        public void DeleteOrder(Order order) => Delete(order);

        public IQueryable<Order> Orders =>
            _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(cl => cl.Phone)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId);

        public IQueryable<Order> GetOrdersWithParameters(OrderRequestParameters requestParameters)
        {
            var query = _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(cl => cl.Phone)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId)
            .ToPaginate(requestParameters.PageNumber, requestParameters.PageSize);
            return query;
        }
        public IQueryable<Order> FindAllOrdersWithUserId(OrderRequestParameters requestParameters)
        {
            return _context.Orders
                        .Include(o => o.Lines)
                        .ThenInclude(cl => cl.Phone)
                        .FindAllByCondition(u => u.UserId.Equals(requestParameters.UserId))
                        .OrderBy(o => o.Shipped)
                        .ThenByDescending(o => o.OrderId)
                        .ToPaginate(requestParameters.PageNumber,requestParameters.PageSize);
             
        }
        public int OrderCount(string userID)
        {
            return _context.Orders
                    .FindAllByCondition(u => u.UserId.Equals(userID))
                    .Count();
        }
        public Order? GetOneOrder(int orderId)
        {
            return _context.Orders
                .Include(o => o.Lines)
                .ThenInclude(cl => cl.Phone)
                .FindById(orderId);
        }

        public Order? GetOneOrderForComplete(int orderId)
        {
            var Order = _context.Orders
                .Include(o => o.Lines)
                .ThenInclude(cl => cl.Phone)
                .FirstOrDefault(o => o.OrderId == orderId);
            return Order;
        }
        public void UpdateOrder(Order order) => Update(order);

        public void MarkAsShipped(int orderId)
        {
            var order = GetOneOrder(orderId);
            if (order != null)
            {
                order.Shipped = true;
                Update(order);
            }
        }

        public IQueryable<Order> FindAllOrders() => FindAll(false);

        
    }


}
