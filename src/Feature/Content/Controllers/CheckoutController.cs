using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dresscode.Feature.Content.Models;
using Dresscode.Foundation.Services.SitecoreSend;
using Sitecore.Tasks;

namespace Dresscode.Feature.Content.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IEmailService _emailService;
        public CheckoutController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public ActionResult Index()
        {
            var model = new OrderConfirmation()
            {
                Total = 12.23m,
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "A",
                        Description = "D",
                        Price = 11.05m
                    },
                    new Product()
                    {
                        Name = "B",
                        Description = "D",
                        Price = 21.05m
                    }
                },
                BillingInformation = new BillingInformation()
            };
            return View("Index",model);
        }

        [HttpPost]
        public ActionResult Purchase(BillingInformation billingInformation)
        {
            var orderNumber = new Random().Next(123,99999).ToString();
            _emailService.AddSubscriber(billingInformation.Email, billingInformation.Name, orderNumber);
            return Redirect("~/Home");
        }
    }
}