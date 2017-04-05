using MediatR;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.eShopOnContainers.BuildingBlocks.Resilience.HttpResilience;
using Microsoft.eShopOnContainers.Services.Ordering.Infrastructure;
using Ordering.API.Application.Commands;
using Ordering.API.Application.IntegrationEvents.Events;
using Ordering.Domain.Events;
using Ordering.Domain.SagaData;
using System;
using System.Threading.Tasks;

namespace Ordering.API.Application.Sagas
{    

    public class OrderingSaga : Saga<OrderSagaData>,
        IAsyncRequest<ProcessOrderCommand>,
        IIntegrationEventHandler<OrderPaidIntegrationEvent>,
        IIntegrationEventHandler<StockCreatedIntegrationEvent>
    {
        private IHttpClient _apiClient;
        public OrderingSaga(IHttpClient httpClient, OrderingContext orderingContext) 
            : base(orderingContext)
        {
            _apiClient = httpClient;           
        }

        public async Task Handle(ProcessOrderCommand command)
        {
            //TODO: Call PAyment and catalog api

            _apiClient.Inst.DefaultRequestHeaders.Add("x-requestid", command.RequestId.ToString());
            //var basketUrl = _remoteServiceBaseUrl;

            var response = await _apiClient.PostAsync("basketUrl", command);

            response.EnsureSuccessStatusCode();

            //var saga = new OrderSagaData();
            //Add(saga);
            //Save();
            //var id = FindById(1);
            //TODO: Implement business logic when order is created in saga
        }

        public async Task Handle(OrderPaidIntegrationEvent @event)
        {
            //TODO: Implement  business logic when receiving orderpaid integrationevent
        }

        public async Task Handle(StockCreatedIntegrationEvent @event)
        {
            //TODO: Implement  business logic when receiving stock provided integrationevent
        }
    }
}
