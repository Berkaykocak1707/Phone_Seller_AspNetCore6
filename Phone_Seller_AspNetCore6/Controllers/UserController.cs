using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Phone_Seller_AspNetCore6.Models;
using Services.Contracts;

namespace Phone_Seller_AspNetCore6.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly IServiceManager _manager;

        public UserController(UserManager<CustomUser> userManager, IServiceManager serviceManager)
        {
            _userManager = userManager;
            _manager = serviceManager;
        }

        public IActionResult Index([FromQuery] OrderRequestParameters requestParameters)
        {
            var UserID = _userManager.GetUserId(User);
            requestParameters.UserId = UserID;
            requestParameters.PageSize = 4;
            var orders = _manager.OrderService.FindAllOrdersWithUserId(requestParameters);
            var pagination = new Pagination()
            {
                CurrentPage = requestParameters.PageNumber,
                ItemsPerPage = requestParameters.PageSize,
                TotalItems = _manager.OrderService.OrderCount(UserID)
            };
            return View(new OrderListViewModel()
            {
                Orders = orders,
                Pagination = pagination
            });
        }
        public IActionResult OrderDetail([FromRoute] int slug)
        {
            var successMessage = TempData["SuccessMessage"] as string;
            var OrderId = TempData["OrderId"];
               var model = _manager.OrderService.GetOrderById(slug);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rating([FromForm] int productId,int orderId, double rating)
        {
            var messageAndRating = _manager.PhoneService.AddRating(productId,orderId,rating);
            TempData["SuccessMessage"] = messageAndRating;
            TempData["OrderId"] = orderId;
            return RedirectToAction("OrderDetail", new
            {
                slug = orderId
            });
        }
    }
}
