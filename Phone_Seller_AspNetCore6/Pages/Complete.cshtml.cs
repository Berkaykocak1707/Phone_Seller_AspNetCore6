using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace Phone_Seller_AspNetCore6.Pages
{
    public class CompleteModel : PageModel
    {
        private readonly IServiceManager _serviceManager;

        public CompleteModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public Order Order
        {
        get; set; }
        public IActionResult OnGet()
        {
            /// TempData içinde "OrderId" var mý ve null deðil mi kontrol et
            if (TempData.ContainsKey("OrderId") && TempData["OrderId"] != null)
            {
                // TempData üzerinden orderId'i al
                int OrderId = (int)TempData["OrderId"];

                // OrderId ile Order nesnesini al
                Order = _serviceManager.OrderService.GetOneOrderForComplete(OrderId);
            }
            else
            {
                // TempData içinde "OrderId" bulunamadý veya null
                // Hata iþlemleri veya kullanýcýya bildirim yapma
            }

            return Page();
        }
    }
}
