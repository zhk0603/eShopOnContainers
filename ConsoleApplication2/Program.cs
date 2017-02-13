using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.eShopOnContainers.Services.Ordering.Infrastructure;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderingContext>();
            optionsBuilder.UseSqlServer("Data Source=\".\\SQLExpress\";Initial Catalog=OrderingDb;Integrated Security=True;Pooling=False");
            var dbcontext = new OrderingContext(optionsBuilder.Options);

            IOrderRepository rep = new OrderRepository(dbcontext);
            rep.Add(new Order(0, 0, new Address("", "", "", "", "")));
            dbcontext.SaveChanges();

        }
    }
}
