using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission8.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?. HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Basket") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }


        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book bk, int qty)
        {
            base.AddItem(bk, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book bk)
        {
            base.RemoveItem(bk);
            Session.SetJson("Basket", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Basket");
        }
    }
}
