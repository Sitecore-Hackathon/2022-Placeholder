using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moosend.Wrappers.CSharpWrapper.Api;
using Moosend.Wrappers.CSharpWrapper.Client;
using Moosend.Wrappers.CSharpWrapper.Model;
using Sitecore.Diagnostics;

namespace Dresscode.Foundation.Services.SitecoreSend
{
    public class EmailService : IEmailService
    {
        public void AddSubscriber(string email, string name, string orderNumber) 
        {
            var apiInstance = new SubscribersApi();
            var format = "json";
            var mailingListID = "df1f3a65-2ada-4309-b7be-a8befc56b0f0";
            var apiKey = "5974c953-31bf-45d1-958a-192832af4213";
            var customFields = new List<string>()
            {
                $"OrderNumber={orderNumber}",
                $"OrderUrl=https://tentwosc.dev.local/URL"
            };

            var body = new AddingSubscribersRequest(email, name, customFields);

            try
            {
                var result = apiInstance.AddingSubscribers(format, mailingListID, apiKey, body);
            }
            catch (Exception e)
            {
                Log.Error($"Error in AddSubscriber", e, typeof(EmailService));
            }
        }
    }
}
