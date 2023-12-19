using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _repositoryManager.Order.FindAllOrders();
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public OrderDto GetOrderById(int id)
        {
            var order = _repositoryManager.Order.GetOneOrder(id);
            if (order == null)
            {
                // Handle not found
            }
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public OrderDto CreateOrder(OrderDtoForCreation orderDto)
        {
            var orderEntity = _mapper.Map<Order>(orderDto);
            _repositoryManager.Order.CreateOrder(orderEntity);
            _repositoryManager.Save();

            var order = GetOrderById(orderEntity.OrderId);
            return order;
            //var orderToReturn = _mapper.Map<OrderDtoForCreation>(orderEntity);
            //orderToReturn.OrderId = orderEntity.OrderId;
            //return orderToReturn;
        }

        public void UpdateOrder(int id, OrderDtoForUpdate orderUpdateDto)
        {
            var orderEntity = _repositoryManager.Order.GetOneOrder(id);
            if (orderEntity == null)
            {
                // Handle not found
            }

            _mapper.Map(orderUpdateDto, orderEntity);
            _repositoryManager.Save();
        }

        public void DeleteOrder(int id)
        {
            var orderEntity = _repositoryManager.Order.GetOneOrder(id);
            if (orderEntity == null)
            {
                // Handle not found
            }

            _repositoryManager.Order.DeleteOrder(orderEntity);
            _repositoryManager.Save();
        }

        public void MarkAsShipped(int orderId)
        {
            _repositoryManager.Order.MarkAsShipped(orderId);
            _repositoryManager.Save();
        }

        public Order? GetOneOrderForComplete(int orderId) => _repositoryManager.Order.GetOneOrderForComplete(orderId);

        public IEnumerable<OrderDto> GetOrdersWithParameters(OrderRequestParameters requestParameters)
        {
            var orders = _repositoryManager.Order.GetOrdersWithParameters(requestParameters);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public IEnumerable<OrderDto> FindAllOrdersWithUserId(OrderRequestParameters requestParameters)
        {
            var orders = _repositoryManager.Order.FindAllOrdersWithUserId(requestParameters);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public int OrderCount(string userID)
        {
            return _repositoryManager.Order.OrderCount(userID);
        }
    }


}
