using Catalog.API.Infrastructure.Idempotency;
using MediatR;
using System.Threading.Tasks;

namespace Catalog.API.Application.Commands
{
    public class CreateStockCommandIdentifiedHandler : IdentifierCommandHandler<CreateStockCommand, bool>
    {
        public CreateStockCommandIdentifiedHandler(IMediator mediator, IRequestManager requestManager) : base(mediator, requestManager)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for creating order.
        }
    }

    public class CreateStockCommandHandler
        : IAsyncRequestHandler<CreateStockCommand, bool>
    {
        private readonly IMediator _mediator;

        public CreateStockCommandHandler()
        {
            
        }

        public async Task<bool> Handle(CreateStockCommand message)
        {
            //TODO: update stock and send integration event
        }
    }
}
