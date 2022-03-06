using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderCloud.SDK;

namespace Dresscode.Foundation.Services.OrderCloud
{
    public interface IOrderCloudService
    {
        Task<Product> CreateProduct(string ProductId);

        Task<Boolean> AssignProduct(string ProductId);

        Task<ListPageWithFacets<BuyerProduct>> ViewProducts();

        Task<ListPage<Order>> ViewOrders();
        Task<Order> CreateOrder(string productId);

    }
}
