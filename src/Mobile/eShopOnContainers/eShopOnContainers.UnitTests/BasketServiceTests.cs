using eShopOnContainers.Core.Services.Catalog;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class BasketServiceTests : BaseTest
    {
        [Fact]
        public async Task GetFakeBasketTest()
        {
            var catalogMockService = new CatalogMockService();       
            var result  = await catalogMockService.GetCatalogAsync();
            Assert.NotEqual(0, result.Count);
        }
    }
}