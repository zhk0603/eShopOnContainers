using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.BuyerAggregate;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.Seedwork;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork;
using Microsoft.eShopOnContainers.Services.Ordering.Infrastructure;
using Microsoft.eShopOnContainers.Services.Ordering.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OrderingContextFactory factory = new OrderingContextFactory();
            var dbcontext = factory.Create(null);

            try
            {
             var b =   dbcontext.Buyers.Include("PaymentMethods").Where(x => x.FullName == "Pierre Mile").FirstOrDefault();
             var pm  = b.PaymentMethods.FirstOrDefault();
             Order o = new Order(b.Id, pm.Id, new Address( "", "", "", "", ""));
             IOrderRepository repo = new OrderRepository( dbcontext );
             repo.Add(o);
             repo.UnitOfWork.SaveChangesAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
       }

      

        public class OrderingContextFactory : IDbContextFactory<OrderingContext>
        {
            public OrderingContext Create(DbContextFactoryOptions options)
            {
                var optionsBuilder = new DbContextOptionsBuilder<OrderingContext>();
                optionsBuilder.UseSqlServer("Data Source=\".\\SQLExpress\";Initial Catalog=orderingdb;Integrated Security=True;Pooling=False", b => b.MigrationsAssembly("ConsoleApp1"));
                var dbcontext = new OrderingContext(optionsBuilder.Options);
                return dbcontext;
            }
        }


    }
}
