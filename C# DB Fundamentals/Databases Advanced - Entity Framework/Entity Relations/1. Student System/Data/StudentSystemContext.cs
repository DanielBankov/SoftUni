namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        { }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        { }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            StudentEntity(modelBuilder);
            CourseEntity(modelBuilder);
            ResourceEntity(modelBuilder);
            HomeworkEntity(modelBuilder);
            StudentCourseEntity(modelBuilder);
        }

        private void StudentCourseEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(e => e.CourseId);
            });

        }

        private void HomeworkEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Homework>()
                .HasKey(h => h.HomeworkId);

            modelBuilder
                .Entity<Homework>()
                .Property(h => h.Content);

            modelBuilder
                .Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);

            modelBuilder
               .Entity<Homework>()
               .HasOne(h => h.Student)
               .WithMany(s => s.HomeworkSubmissions)
               .HasForeignKey(h => h.StudentId);
        }

        private void ResourceEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Resource>()
                .HasKey(r => r.ResourceId);

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Url)
                .IsRequired();

            modelBuilder
                .Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources);
        }

        private void CourseEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>()
                .HasKey(c => c.CourseId);

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Description)
                .IsUnicode();

            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(c => c.ResourceId);
        }

        private static void StudentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder
                .Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasColumnType("CHAR(10)");

            modelBuilder
                .Entity<Student>()
                .Property(e => e.RegisteredOn )
            .IsRequired();

            modelBuilder
                .Entity<Student>().Property(e => e.Birthday)
                .IsRequired(false);
        }
    }
}
