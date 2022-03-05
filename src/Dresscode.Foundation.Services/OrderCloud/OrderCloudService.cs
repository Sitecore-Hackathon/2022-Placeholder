using System;
using System.Linq;
using System.Threading.Tasks;
using OrderCloud.SDK;

namespace Dresscode.Foundation.Services.OrderCloud
{
    public class OrderCloudService : IOrderCloudService
    {

        public async Task<Product> CreateProduct(string ProductId)
        {
            var product = new Product
            {
                ID = ProductId,
                Name = "Custom Cotton T-Shirt",
                Description = "A T-Shirt Designed just for you!",
                Active = true
            };
            var assignment = new ProductCatalogAssignment
            {
                CatalogID = "BUYER_ORGANIZATION",
                ProductID = ProductId
            };
            try
            {
                Product response = await CreateBuyerClient().Products.CreateAsync(product);
            }
            catch (OrderCloudException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return product;
        }

        public async Task<Boolean> AssignProduct(string ProductId)
        {
            bool success = false;
            var assignment = new ProductCatalogAssignment
            {
                CatalogID = "BUYER_ORGANIZATION",
                ProductID = ProductId
            };
            try
            {
                await CreateBuyerClient().Catalogs.SaveProductAssignmentAsync(assignment);
                success = true;
            }
            catch (OrderCloudException ex)
            {
                Sitecore.Diagnostics.Log.Error("Error in OrderCloud API", ex.InnerException, this);
            }

            return success;
        }

        public async Task<ListPageWithFacets<BuyerProduct>> ViewProducts()
        {
            var buyerProducts = new ListPageWithFacets<BuyerProduct>();
            try
            {
                buyerProducts = await CreateBuyerClient().Me.ListProductsAsync();
            }
            catch (OrderCloudException ex)
            {
                Sitecore.Diagnostics.Log.Error("Error in OrderCloud API", ex.InnerException, this);
            }

            return buyerProducts;
        }


        public async Task<ListPage<Order>> ViewOrders()
        {
            var buyerProducts = new ListPage<Order>();
            try
            {
                buyerProducts = await CreateBuyerClient().Orders.ListAsync(OrderDirection.Outgoing);
            }
            catch (OrderCloudException ex)
            {
                Sitecore.Diagnostics.Log.Error("Error in OrderCloud API", ex.InnerException, this);
            }

            return buyerProducts;
        }

        public async Task<Order> CreateOrder(string productId)
        {
            var response = new Order();
            try
            {
                response = await CreateBuyerClient().Orders.CreateAsync(OrderDirection.Outgoing, new Order());
                AddItemToOrder(response.ID, productId);
            }
            catch (OrderCloudException ex)
            {
                Sitecore.Diagnostics.Log.Error("Error in OrderCloud API", ex.InnerException, this);
            }
            return response;
        }

        public async void AddItemToOrder(string orderID, string productId)
        {
            try
            {
                LineItem response = await CreateBuyerClient().LineItems.CreateAsync(OrderDirection.Outgoing, orderID, new PartialLineItem
                {
                    ProductID = productId,
                    Quantity = 2
                });
            }
            catch (OrderCloudException ex)
            {
                Sitecore.Diagnostics.Log.Error("Error in OrderCloud API", ex.InnerException, this);
            }
        }


        #region PrivateMethods

        private OrderCloudClient CreateAdminClient()
        {
            return new OrderCloudClient(new OrderCloudClientConfig
            {
                ApiUrl = "https://useast-sandbox.ordercloud.io",
                AuthUrl = "https://useast-sandbox.ordercloud.io",
                ClientId = "25E365D8-8767-40F7-8082-C7AE85979AAC",
                Username = "admin01",
                Password = "placeholderRocks1!",
                Roles = new[] {
                ApiRole.MeAdmin,
                ApiRole.PasswordReset,
                ApiRole.BuyerReader,
                ApiRole.OrderAdmin,
                ApiRole.CatalogAdmin,
                ApiRole.ProductAdmin,
                ApiRole.ProductAssignmentAdmin,
                ApiRole.PriceScheduleAdmin,
                ApiRole.ShipmentAdmin
            }
            });
        }

        private OrderCloudClient CreateBuyerClient()
        {
            return new OrderCloudClient(new OrderCloudClientConfig
            {
                ApiUrl = "https://useast-sandbox.ordercloud.io",
                AuthUrl = "https://useast-sandbox.ordercloud.io",
                ClientId = "25E365D8-8767-40F7-8082-C7AE85979AAC",
                Username = "buyer01",
                Password = "placeholderRocks1!",
                Roles = new[] {
                    ApiRole.MeAdmin,
                    ApiRole.PasswordReset,
                    ApiRole.Shopper
                }
            });
        }

        #endregion

    }
}
