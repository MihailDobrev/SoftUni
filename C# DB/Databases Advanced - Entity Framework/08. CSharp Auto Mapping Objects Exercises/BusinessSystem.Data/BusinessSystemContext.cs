namespace BusinessSystem.Data
{
    using BusinessSystem.Models;
    using Microsoft.EntityFrameworkCore;

    public class BusinessSystemContext : DbContext
    {
        public BusinessSystemContext(DbContextOptions options) 
            : base(options)
        {
        }

        public BusinessSystemContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(e => e.Manager)
                .WithMany(m => m.EmployeesOfManager)
                .HasForeignKey(m => m.ManagerId);
            });    
        }
    }
}
