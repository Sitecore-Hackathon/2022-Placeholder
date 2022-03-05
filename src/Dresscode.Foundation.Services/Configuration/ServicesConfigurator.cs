using Dresscode.Foundation.Services.SitecoreSend;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Dresscode.Foundation.Services.Configuration
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IEmailService), typeof(EmailService));
        }
    }
}