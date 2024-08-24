using Entities.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Store.Entities.Models;
using StoreApp.Models;
using System.Runtime.CompilerServices;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;

        public OrderController(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            _cart = cart;
        }  

        [Authorize]
        public ViewResult Checkout() 
        {
            var paymentAmount = _cart.ComputeTotalValue().ToString();

            var order = new Order
            {
                PaymentAmount = paymentAmount
            };

            return View(order); 
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                var payment = PaymentProcess(order);
                _manager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = order.OrderId });
            }
            else
            {
                return View();
            }
        }

        private Payment PaymentProcess(Order model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-g69CmM0yDnUtKPKOie6qNM77g6j1gT7B";
            options.SecretKey = "qLV0nNLNODyFJtswWEmuk0hGd0GcN5E9";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString();
            request.Price = "999";
            request.PaidPrice = "999";
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = "Murat Oğuz";
            paymentCard.CardNumber = "5528790000000008";
            paymentCard.ExpireMonth = "12";
            paymentCard.ExpireYear = "2030";
            paymentCard.Cvc = "123";
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            //  paymentCard.CardNumber = "5528790000000008";
            // paymentCard.ExpireMonth = "12";
            // paymentCard.ExpireYear = "2030";
            // paymentCard.Cvc = "123";

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = model.FirstName;
            buyer.Surname = model.LastName;
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;  
            
            foreach (var item in model.Lines)
            {
                basketItem = new BasketItem();
                basketItem.Id = "id";
                basketItem.Name = "item.Name";
                basketItem.Category1 = "Book";
                basketItem.Price = "100";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItems.Add(basketItem);
            }

            request.BasketItems = basketItems;
            return Payment.Create(request, options);
        }
    }
}
