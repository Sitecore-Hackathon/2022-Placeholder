using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moosend.Wrappers.CSharpWrapper.Api;
using Moosend.Wrappers.CSharpWrapper.Client;
using Moosend.Wrappers.CSharpWrapper.Model;

namespace Dresscode.Foundation.Services.SitecoreSend
{
    public class EmailService
    {
        public void AddSubscriber(string email, string name, string orderNumber)
        {
            var apiInstance = new SubscribersApi();
            var format = "json";  // string | 
            var mailingListID = "df1f3a65-2ada-4309-b7be-a8befc56b0f0";  // string | The ID of the mailing list to add the new member.
            var apikey = "5974c953-31bf-45d1-958a-192832af4213";  // string | You may find your API Key or generate a new one in your account settings.
            var customFields = new List<string>()
            {
                $"OrderNumber={orderNumber}",
                $"OrderUrl=https://tentwosc.dev.local/URL"
            };

            var body = new AddingSubscribersRequest(email, name, customFields);

            try
            {
                // Adding subscribers
                AddingSubscribersResponse result = apiInstance.AddingSubscribers(format, mailingListID, apikey, body);

            }
            catch (Exception e)
            {

            }
        }
    }
}
