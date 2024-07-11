using Microsoft.EntityFrameworkCore;
using LittleLearningSystem.Models;

namespace LittleLearningSystem.Models
{
    public partial class LMSContext : DbContext
    {
        public LMSContext()
        {
        }

        public LMSContext(DbContextOptions<LMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enroll> Enrolls { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseID).HasName("PK__Course__C92D71873200C9EC");

                entity.ToTable("Course");

                entity.Property(e => e.CourseID)
                    .ValueGeneratedOnAdd() // 设置CourseId自动递增
                    .HasColumnName("CourseID");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CourseWeek)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enroll>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId }).HasName("PK__Enroll__5E57FD61BEB4025B");

                entity.ToTable("Enroll");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
                entity.Property(e => e.CourseId).HasColumnName("CourseID");
                entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Course).WithMany(p => p.Enrolls)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enroll_Course");

                entity.HasOne(d => d.Student).WithMany(p => p.Enrolls)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enroll_Student");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.MaterialId).HasName("PK__Material__C5061317BB034DFD");

                entity.ToTable("Material");

                entity.Property(e => e.MaterialId)
                    .ValueGeneratedOnAdd() // 设置MaterialId自动递增
                    .HasColumnName("MaterialID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");
                entity.Property(e => e.CreateTime).HasColumnType("datetime");
                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FileType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Course).WithMany(p => p.Materials)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Material_Course");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A79262AB31D");

                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedOnAdd() // 设置StudentId自动递增
                    .HasColumnName("StudentID");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Spassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SPassword");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
