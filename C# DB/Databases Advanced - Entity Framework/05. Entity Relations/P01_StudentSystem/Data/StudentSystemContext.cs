namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;

    public class StudentSystemContext : DbContext
    {

        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(
                entity =>
                {
                    entity.Property(s => s.Name)
                          .IsUnicode()
                          .HasMaxLength(100);

                    entity.Property(s => s.PhoneNumber)
                      .HasMaxLength(10)
                      .IsUnicode(false);

                    entity.HasMany(s => s.HomeworkSubmissions)
                        .WithOne(hs => hs.Student)
                        .HasForeignKey(hs => hs.StudentId);

                    entity.HasMany(s => s.CourseEnrollments)
                        .WithOne(c => c.Student)
                        .HasForeignKey(c => c.StudentId);

                });

            modelBuilder.Entity<Course>(
              entity =>
              {
                  entity.Property(s => s.Name)
                        .IsUnicode();

                  entity.Property(s => s.Description)
                        .IsUnicode();

                  entity.HasMany(c => c.Resources)
                        .WithOne(r => r.Course)
                        .HasForeignKey(r => r.CourseId);

                  entity.HasMany(c => c.HomeworkSubmissions)
                        .WithOne(r => r.Course)
                        .HasForeignKey(r => r.CourseId);

                  entity.HasMany(c => c.StudentsEnrolled)
                        .WithOne(s => s.Course)
                        .HasForeignKey(r => r.CourseId);
              });


            modelBuilder.Entity<Resource>(
              entity =>
              {
                  entity.Property(s => s.Name)
                        .IsUnicode()
                        .HasMaxLength(50);

                  entity.Property(s => s.Url)
                       .IsUnicode(false);
              });

            modelBuilder.Entity<Homework>(
             entity =>
             {
                 entity.Property(s => s.Content)
                       .IsUnicode(false);
             });

            modelBuilder.Entity<StudentCourse>(
                entity =>
                {
                    entity.HasKey(sc => new { sc.CourseId, sc.StudentId });

                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
