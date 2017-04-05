using eShopOnContainers.Core.Services.RequestProvider;
using Microsoft.eShopOnContainers.BuildingBlocks.Resilience.HttpResilience;
using Microsoft.Extensions.Logging;

namespace eShopOnContainers.UnitTests
{
    public abstract class BaseTest
    {
        protected RequestProvider RequestProvider
        {
            get
            {
                var requestProvider = new RequestProvider(
                    new StandardHttpClient(
                        new Logger<StandardHttpClient>(
                            new LoggerFactory())));

                return requestProvider;
            }
        }
    }
}
