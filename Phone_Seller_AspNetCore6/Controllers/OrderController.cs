using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Services.Contracts;

namespace Phone_Seller_AspNetCore6.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;
        private readonly UserManager<CustomUser> _userManager;

        public OrderController(IServiceManager manager, Cart cart, UserManager<CustomUser> userManager)
        {
            _manager = manager;
            _cart = cart;
            _userManager = userManager;
        }

        public IActionResult Checkout()
        {
            var userIdValue = _userManager.GetUserId(User);
            ViewData["UserId"] = userIdValue;
            return View(new OrderDtoForCreation());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] OrderDtoForCreation order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sepete ürün ekle");
            }
            //var userIdValue = _userManager.GetUserId(User);
            //ModelState.SetModelValue("UserId", new ValueProviderResult(userIdValue));
            if (ModelState.IsValid)
            {
                
                order.Lines = _cart.Lines.ToArray();
                var orderModel =_manager.OrderService.CreateOrder(order);
                var orderId = orderModel.OrderId;
                TempData["OrderId"] = orderId;
                _cart.Clear();
                return RedirectToPage("/Complete");
            }
            return View();
        }
    }
}
