using Microsoft.EntityFrameworkCore;
using Ordering.Domain.SagaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Application.Sagas
{
    public abstract class Saga<TEntity> where TEntity : class, ISagaEntity
    {
        private DbContext _context;
        public Saga(DbContext ctx)
        {
            _context = ctx; 
        }

        protected TEntity FindById(int id)
        {
            return _context.Set<TEntity>().Where(x => x.CorrelationId == id).SingleOrDefault();
        }

        protected void MarkAsCompleted(TEntity item)
        {
            item.Completed = true;
        }

        protected void MarkAsCancelled(TEntity item)
        {
            item.Cancelled = true;
        }

        protected void Add(TEntity item)
        {
            _context.Add(item);
        }

        protected void Save()
        {
            _context.SaveChanges();
        }
    }
}
