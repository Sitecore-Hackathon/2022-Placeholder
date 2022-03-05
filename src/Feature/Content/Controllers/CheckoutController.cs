using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dresscode.Feature.Content.Models;
using Dresscode.Foundation.Services.SitecoreSend;

namespace Dresscode.Feature.Content.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IEmailService _emailService;

        public CheckoutController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public ActionResult Purchase(OrderConfirmation orderConfirmation)
        {
            _emailService.AddSubscriber(orderConfirmation.Email, orderConfirmation.Name, orderConfirmation.OrderNumber);
            return Json(new {ok = true});
        }
    }
}