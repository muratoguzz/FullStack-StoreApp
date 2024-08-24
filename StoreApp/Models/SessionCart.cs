using System.Text.Json.Serialization;
using Entities.Models;
using Store.Entities.Models;
using StoreApp.Infrastructe.Extensions;

namespace StoreApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore] //Session özelliği JSON verisi olarak dönüştürülmez.Sessionun içindeki veriler serileştirilir.
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            // IHttpContextAccessor servisini al
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();

            // HttpContext'ten oturum (session) nesnesini al
            var session = httpContextAccessor.HttpContext?.Session;

            // Oturumdan sepeti al, eğer sepet yoksa yeni bir sepet oluştur
            var cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();

            // Sepeti oturumla ilişkilendirdik
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson<SessionCart>("cart", this);
        }

        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            Session?.SetJson<SessionCart>("cart", this);
        }
    }
}
