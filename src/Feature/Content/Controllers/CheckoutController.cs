using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dresscode.Feature.Content.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpPost]
        public ActionResult Purchase()
        {

            return Json(new {ok = true});
        }
    }
}