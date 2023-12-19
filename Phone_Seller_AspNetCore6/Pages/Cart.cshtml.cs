using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Services.Contracts;

namespace Phone_Seller_AspNetCore6.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;
       
        public Cart Cart { get; set; }

        public CartModel(IServiceManager manager, Cart cartService, IMapper mapper)
        {
            _manager = manager;
            Cart = cartService;
            _mapper = mapper;
        }


        public void OnGet()
        {
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int phoneID)
        {
            var productDto = _manager.PhoneService.GetPhoneById(phoneID);
            var phone = _mapper.Map<Phone>(productDto);
            if(phone is not null)
            {
                // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(phone, 1);
                // HttpContext.Session.SetJson<Cart>("cart",Cart);
            }
            return Page(); // returnUrl
        }
        public IActionResult OnPostUpdate(int productId, int quantity)
        {
            PhoneDto productDto = _manager.PhoneService.GetPhoneById(productId);
            var phone = _mapper.Map<Phone>(productDto);
            if (phone != null)
            {
                if (phone.PhoneStock < quantity)
                {
                    ViewData["ErrorMessage"] = $"Limit for this product is {phone.PhoneStock}";
                    return Page();
                }
                else
                {
                    Cart.UpdateItemQuantity(phone, quantity);
                }
                
            }

            return Page();
        }
        public IActionResult OnPostRemove(int productId)
        {
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Phone.PhoneID.Equals(productId)).Phone);
            // HttpContext.Session.SetJson<Cart>("cart",Cart);
            return Page(); 
        }
    }
}