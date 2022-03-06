using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Dresscode.Feature.Content.Models
{
    public class OrderConfirmation
    {
        public string OrderNumber { get; set; }
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }
        public BillingInformation BillingInformation { get; set; }
    }
}