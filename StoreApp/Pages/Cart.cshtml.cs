using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using Store.Entities.Models;
using StoreApp.Infrastructe.Extensions;
using StoreApp.Infrastructe.Helpers;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public Cart Cart { get; set; } // IoC
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IServiceManager manager, IMapper mapper, Cart cartService)
        {
            _manager = manager;
            _mapper = mapper;
            Cart = cartService;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/"; //ReturnUrl yoksa anasayfaya atar
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); Ctor da cart istendiði için Program.cs dosyasýnda scopladýðýmýz cart gelicek
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId, false);         

            if (product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                StockHelper.StockDown(product, _manager, _mapper);
                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl }); //anonim nesne
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Product product = Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product;
            //StockHelper.StockUp(product, _manager, _mapper); Hata: Eklenen ürün sayýsý-1 tane ekliyor??
            
            Cart.RemoveLine(product);
            //HttpContext.Session.SetJson<Cart>("cart", Cart);

            return Page();
        }

        public IActionResult OnPostRemoveItem(int productId)
        {
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId, false);

            if (product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                StockHelper.StockUp(product, _manager, _mapper);
                Cart.RemoveItem(product);
                //HttpContext.Session.SetJson<Cart>("cart", Cart);
            }

            // Sayfayý ayný sayfada güncelle
            return Page();
        }

        public IActionResult OnPostAddItem(int productId)
        {
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId, false);

            if (product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                StockHelper.StockDown(product, _manager, _mapper);
                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart", Cart);
            }
            return Page();
        }

        [Obsolete("This method is obsolete")]
        public IActionResult OnPostClearCart()
        {
            Cart.Clear();
            return Page();
        }
    }
}
