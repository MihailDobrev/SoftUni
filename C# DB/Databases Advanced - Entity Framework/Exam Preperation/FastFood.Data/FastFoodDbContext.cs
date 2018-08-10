namespace FastFood.Data
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;

    public class FastFoodDbContext : DbContext
    {
        public FastFoodDbContext()
        {
        }

        public FastFoodDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(entity =>
             entity.HasOne(e => e.Position)
             .WithMany(e => e.Employees)
             .HasForeignKey(e => e.PositionId)
            );

            builder.Entity<Position>(entity =>
             entity.HasIndex(x => x.Name).IsUnique()
            );

            builder.Entity<Item>(entity =>
          entity.HasIndex(x => x.Name).IsUnique()
            );

            builder.Entity<Item>(entity =>
             entity.HasOne(i=>i.Category)
             .WithMany(c=>c.Items)
             .HasForeignKey(i=>i.CategoryId)
           );

            builder.Entity<Order>(entity =>
             entity.HasOne(o=>o.Employee)
             .WithMany(e=>e.Orders)
             .HasForeignKey(o=>o.EmployeeId)
           );

            builder.Entity<OrderItem>(entity =>
            entity.HasKey(k => new { k.OrderId, k.ItemId }));

        }


    }
}