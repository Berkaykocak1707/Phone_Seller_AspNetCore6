using System.Text.Json.Serialization;
using Entities.Dtos;
using Entities.Models;
using Phone_Seller_AspNetCore6.Infrastructure.Extensions;

namespace Phone_Seller_AspNetCore6.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Phone product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCart>("cart",this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }
        public override void UpdateItemQuantity(Phone product, int quantity)
        {
            base.UpdateItemQuantity(product, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }
        public override void RemoveLine(Phone product)
        {
            base.RemoveLine(product);
            Session?.SetJson<SessionCart>("cart",this);
        }
    }
}