using Microsoft.EntityFrameworkCore;
using CustomerOrdersAPI.Model;

namespace CustomerOrdersAPI.DAL
{
    public class CustomerOrdersDbContext : DbContext
    {
        public CustomerOrdersDbContext(DbContextOptions<CustomerOrdersDbContext> options) : base(options)
        {
        }
        public CustomerOrdersDbContext() { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public List<Customer> Customer { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = Guid.Parse("481cf36a-fdb8-4911-853f-34ad26df4a2a"),
                    FirstName = "Alice",
                    LastName = "Smith",
                    DOB = new DateTime(1987, 1, 1)
                },
                new Customer
                {
                    CustomerID = Guid.Parse("1db7a052-91d5-43f0-8eeb-c852b504cd59"),
                    FirstName = "Bob",
                    LastName = "Smith",
                    DOB = new DateTime(1986, 12, 12)
                });

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1,
                    CustomerID = Guid.Parse("481cf36a-fdb8-4911-853f-34ad26df4a2a"),
                    ItemName = "Nail Polish",
                    ItemPrice = 100.00m
                },
                new Order
                {
                    OrderID = 2,
                    CustomerID = Guid.Parse("481cf36a-fdb8-4911-853f-34ad26df4a2a"),
                    ItemName = "Hair Brush",
                    ItemPrice = 500.00m
                },
                new Order
                {
                    OrderID = 3,
                    CustomerID = Guid.Parse("1db7a052-91d5-43f0-8eeb-c852b504cd59"),
                    ItemName = "Shaving Cream",
                    ItemPrice = 90.00m
                });
        }
    }
}
