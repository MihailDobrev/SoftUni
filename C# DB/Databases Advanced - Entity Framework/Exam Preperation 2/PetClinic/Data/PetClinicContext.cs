namespace PetClinic.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Models;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext() { }

        public PetClinicContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Passport> Passports { get; set; }

        public DbSet<Vet> Vets { get; set; }

        public DbSet<AnimalAid> AnimalAids { get; set; }

        public DbSet<ProcedureAnimalAid> ProceduresAnimalAids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProcedureAnimalAid>(entity =>
            entity.HasKey(k => new { k.ProcedureId, k.AnimalAidId }
            ));

            builder.Entity<AnimalAid>(entity =>
           entity.HasIndex(e => e.Name).IsUnique()
           );

            builder.Entity<Vet>(entity =>
           entity.HasIndex(e => e.PhoneNumber).IsUnique()
           );

            builder.Entity<Animal>(entity =>
               entity.HasOne(a => a.Passport)
               .WithOne(p => p.Animal)
               .HasForeignKey<Animal>(a => a.PassportSerialNumber));
            
        }
    }
}
