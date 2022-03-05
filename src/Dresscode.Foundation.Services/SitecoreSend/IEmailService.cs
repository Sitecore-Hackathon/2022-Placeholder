using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresscode.Foundation.Services.SitecoreSend
{
    public interface IEmailService
    {
        void AddSubscriber(string email, string name, string orderNumber);
    }
}
