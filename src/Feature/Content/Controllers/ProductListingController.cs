using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dresscode.Feature.Content.Models;
using Dresscode.Foundation.Services;
using Dresscode.Foundation.Services.OrderCloud;
using OrderCloud.SDK;

namespace Dresscode.Feature.Content.Controllers
{
    public class ProductListingController : Controller
    {
        private readonly IOrderCloudService _orderCloudService = new OrderCloudService();

        public ActionResult Index()
        {
            var products = _orderCloudService.ViewProducts().Result.Items.ToList();
            return View(products);
        }

        [HttpPost]
        public ActionResult Purchase(string productId)
        {
            _orderCloudService.CreateOrder(productId);
            return Json(new { ok = true });
        }
    }
}