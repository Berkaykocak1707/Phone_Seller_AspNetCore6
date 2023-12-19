using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Contracts;
using Phone_Seller_AspNetCore6.Infrastructure.Extensions;

namespace Phone_Seller_AspNetCore6.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        public Cart? Cart
        {
            get; set;
        }
        public string Invoke()
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            return Cart.ComputeTotalQuantity().ToString();
        }
    }
}
