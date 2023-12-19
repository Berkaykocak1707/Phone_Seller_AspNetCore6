using DataAccess.Contracts;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phone_Seller_AspNetCore6.Models;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index([FromQuery] OrderRequestParameters requestParameters)
        {
            var orders = _manager.OrderService.GetOrdersWithParameters(requestParameters);
            var pagination = new Pagination()
            {
                CurrentPage = requestParameters.PageNumber,
                ItemsPerPage = requestParameters.PageSize,
                TotalItems = _manager.OrderService.GetAllOrders().Count()
            };
            return View(new OrderListViewModel()
            {
                Orders = orders,
                Pagination = pagination
            });
        }

        private string? OrderListViewModel()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.OrderService.MarkAsShipped(id);
            return RedirectToAction("Index");
        }
    }
}