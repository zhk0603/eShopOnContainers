using eShopOnContainers.Core;
using eShopOnContainers.Core.Services.Order;
using eShopOnContainers.Core.Services.RequestProvider;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class OrdersServiceTests : BaseTest
    {
        [Fact]
        public async Task GetFakeOrdersTest()
        {
            var ordersMockService = new OrderMockService();
            var result = await ordersMockService.GetOrdersAsync(GlobalSetting.Instance.AuthToken);

            Assert.NotEqual(0, result.Count);
        }

        [Fact]
        public async Task GetOrdersTest()
        {
            var ordersService = new OrderService(RequestProvider);
            var result = await ordersService.GetOrdersAsync(GlobalSetting.Instance.AuthToken);

            Assert.NotEqual(0, result.Count);
        }
    }
}