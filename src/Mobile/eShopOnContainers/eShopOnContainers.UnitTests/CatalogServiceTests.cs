using eShopOnContainers.Core.Services.Catalog;
using eShopOnContainers.Core.Services.RequestProvider;
using System.Threading.Tasks;
using Xunit;

namespace eShopOnContainers.UnitTests
{
    public class CatalogServiceTests : BaseTest
    {
        [Fact]
        public async Task GetFakeCatalogTest()
        {
            var catalogMockService = new CatalogMockService();
            var catalog = await catalogMockService.GetCatalogAsync();

            Assert.NotEqual(0, catalog.Count);
        }

        [Fact]
        public async Task GetCatalogTest()
        {
            var catalogService = new CatalogService(RequestProvider);
            var catalog = await catalogService.GetCatalogAsync();

            Assert.NotEqual(0, catalog.Count);
        }

        [Fact]
        public async Task GetFakeCatalogBrandTest()
        {
            var catalogMockService = new CatalogMockService();
            var catalogBrand = await catalogMockService.GetCatalogBrandAsync();

            Assert.NotEqual(0, catalogBrand.Count);
        }

        [Fact]
        public async Task GetCatalogBrandTest()
        {
            var catalogService = new CatalogService(RequestProvider);
            var catalogBrand = await catalogService.GetCatalogBrandAsync();

            Assert.NotEqual(0, catalogBrand.Count);
        }

        [Fact]
        public async Task GetFakeCatalogTypeTest()
        {
            var catalogMockService = new CatalogMockService();
            var catalogType = await catalogMockService.GetCatalogTypeAsync();

            Assert.NotEqual(0, catalogType.Count);
        }

        [Fact]
        public async Task GetCatalogTypeTest()
        {
            var catalogService = new CatalogService(RequestProvider);
            var catalogType = await catalogService.GetCatalogTypeAsync();

            Assert.NotEqual(0, catalogType.Count);
        }
    }
}