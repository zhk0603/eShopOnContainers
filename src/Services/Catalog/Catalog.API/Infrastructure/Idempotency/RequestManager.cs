using Catalog.API.Infrastructure.Exceptions;
using Microsoft.eShopOnContainers.Services.Catalog.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure.Idempotency
{
    public class RequestManager : IRequestManager
    {
        private readonly CatalogContext _context;
        public RequestManager(CatalogContext ctx)
        {
            _context = ctx;
        }


        public async Task<bool> ExistAsync(Guid id)
        {
            var request = await _context.FindAsync<ClientRequest>(id);
            return request != null;
        }

        public async Task CreateRequestForCommandAsync<T>(Guid id)
        {

            var exists = await ExistAsync(id);
            var request = exists ?
                throw new CatalogDomainException($"Request with {id} already exists") :
                new ClientRequest()
                {
                    Id = id,
                    Name = typeof(T).Name,
                    Time = DateTime.UtcNow
                };

            _context.Add(request);
            await _context.SaveChangesAsync();
        }

    }
}
