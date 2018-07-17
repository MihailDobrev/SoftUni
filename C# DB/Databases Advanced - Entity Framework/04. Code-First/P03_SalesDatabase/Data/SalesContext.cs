namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;

    public class SalesContext:DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Product>(
                entity =>
                {
                    entity.HasKey(p => p.ProductId);

                    entity.Property(p => p.Name)
                           .IsUnicode(true)
                           .HasMaxLength(50);

                    entity.HasMany(p => p.Sales)
                        .WithOne(s => s.Product)
                        .HasForeignKey(s => s.ProductId);

                    entity.Property(p => p.Description)
                        .HasMaxLength(250)
                        .HasDefaultValue("No description");
                });

            modelBuilder.Entity<Customer>(
                entity =>
                {
                    entity.HasKey(c => c.CustomerId);

                    entity.Property(c => c.Name)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                    entity.Property(c => c.Email)
                      .HasMaxLength(80)
                      .IsUnicode(false);

                    entity.HasMany(c => c.Sales)
                    .WithOne(s => s.Customer)
                    .HasForeignKey(s => s.CustomerId);
                });

             modelBuilder.Entity<Store>(
               entity =>
               {
                   entity.HasKey(s=>s.StoreId);

                   entity.Property(c => c.Name)
                   .HasMaxLength(80)
                   .IsUnicode(true);

                   entity.HasMany(s => s.Sales)
                   .WithOne(s => s.Store)
                   .HasForeignKey(s => s.StoreId);
               });

            modelBuilder.Entity<Sale>(
              entity =>
              {
                  entity.HasKey(s => s.SaleId);

                  entity.Property(s=>s.Date)
                  .HasDefaultValueSql("GETDATE()");
              });
        }
    }
}
