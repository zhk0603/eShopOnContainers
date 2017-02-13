using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.Seedwork;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    //public class ProgramTest
    //{
    //    public static void Main(string[] args)
    //    {
    //        TestContextFactory factory = new TestContextFactory();
    //        var dbcontext = factory.Create(null);

    //        try
    //        {
    //            var t = new Test();
    //            var p1 = new Product();
    //            t.Add(p1);
    //            var p2 = new Product();
    //            t.Add(p2);
    //            dbcontext.Add(t);
    //            dbcontext.SaveChanges();

    //            var t2 = dbcontext.Tests.Include(p=>p.Products).Where( x=> x.Id == t.Id).FirstOrDefault();
    //            var c = t2.Products.Count;
    //            var status = t2.Status;
    //            foreach ( var p in t2.Products )
    //            {
    //                t2.Remove(p);
    //                break;
    //            }
    //            t2.ChangeStatus();
    //            dbcontext.SaveChanges();

    //            var t3 = dbcontext.Tests.Include(p => p.Products).Where(x => x.Id == t.Id).FirstOrDefault();
    //            var c2 = t3.Products.Count;

    //        }
    //        catch (Exception ex)
    //        {
    //            string s = ex.Message;
    //        }
    //   }

    //    public class TestContext : DbContext

    //    {
    //        const string DEFAULT_SCHEMA = "test";

    //        public DbSet<Test> Tests { get; set; }

    //        public DbSet<Product> Products { get; set; }

    //        public TestContext(DbContextOptions options) : base(options)
    //        {
    //        }

    //        protected override void OnModelCreating(ModelBuilder modelBuilder)
    //        {
    //            modelBuilder.Entity<Test>().HasMany(b => b.Products);
    //            modelBuilder.Entity<Test>().Property<Guid>(t => t.Id);
    //            modelBuilder.Entity<Product>().Property(p=> p.Id);
    //            modelBuilder.Entity<Product>().Property<Guid>("TestId");
    //        }
    //    }

    //    public class Test : Entity
    //    {
    //        private ICollection<Product> _products = new List<Product>();
    //        public Test()
    //        {
    //            Status = OrderStatusType.Created;
    //        }

    //        public string Name { get; set; }

    //        public OrderStatusType Status { get; set; }

    //        public void Add(Product p)
    //        {
    //            _products.Add(p);
    //        }

    //        public void Remove(Product p)
    //        {
    //            _products.Remove(p);
    //        }

    //        internal void ChangeStatus()
    //        {
    //            Status = OrderStatusType.CheckedOut;
    //        }

    //        public IReadOnlyCollection<Product> Products { get { return _products as IReadOnlyCollection<Product>; } }
    //    }

    //    public class Product : ValueObject
    //    {
    //        public int Quantity { get; set; }

    //        internal override IEnumerable<object> GetComparisonValues()
    //        {
    //            yield return Quantity;
    //        }
    //    }

    //    public class TestContextFactory : IDbContextFactory<TestContext>
    //    {
    //        public TestContext Create(DbContextFactoryOptions options)
    //        {
    //            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
    //            optionsBuilder.UseSqlServer("Data Source=\".\\SQLExpress\";Initial Catalog=TestDb;Integrated Security=True;Pooling=False", b => b.MigrationsAssembly("ConsoleApp1"));
    //            var dbcontext = new TestContext(optionsBuilder.Options);
    //            return dbcontext;
    //        }
    //    }


    //}
}
