using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dresscode.Feature.Content.Controllers;
using Dresscode.Foundation.Services.SitecoreSend;
using Microsoft.Extensions.DependencyInjection;

namespace Dresscode.Feature.Content.Configuration
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(CheckoutController));
            serviceCollection.AddScoped(typeof(IEmailService), typeof(EmailService));
            
        }
    }
}