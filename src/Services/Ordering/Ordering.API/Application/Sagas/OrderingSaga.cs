using MediatR;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.eShopOnContainers.Services.Ordering.Infrastructure;
using Ordering.API.Application.IntegrationEvents.Events;
using Ordering.Domain.Events;
using Ordering.Domain.SagaData;
using System.Threading.Tasks;

namespace Ordering.API.Application.Sagas
{
    public class OrderingSaga : Saga<OrderSagaData>,
        IAsyncNotificationHandler<OrderStartedDomainEvent>,
        IIntegrationEventHandler<OrderPaidIntegrationEvent>,
        IIntegrationEventHandler<OrderStockProvidedIntegrationEvent>
    {
        public OrderingSaga(OrderingContext orderingContext) 
            : base(orderingContext) { }

        public async Task Handle(OrderStartedDomainEvent message)
        {
            var saga = new OrderSagaData();
            Add(saga);
            Save();
            var id = FindById(1);
            //TODO: Implement business logic when order is created in saga
        }

        public async Task Handle(OrderPaidIntegrationEvent @event)
        {
            //TODO: Implement  business logic when receiving orderpaid integrationevent
        }

        public async Task Handle(OrderStockProvidedIntegrationEvent @event)
        {
            //TODO: Implement  business logic when receiving stock provided integrationevent
        }
    }
}
