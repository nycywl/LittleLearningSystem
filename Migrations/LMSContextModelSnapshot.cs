﻿using System;
using LittleLearningSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LittleLearningSystem.Migrations
{
    [DbContext(typeof(LMSContext))]
    partial class LMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LittleLearningSystem.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<int>("AmountLimit")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<TimeOnly>("CourseTime")
                        .HasColumnType("time");

                    b.Property<string>("CourseWeek")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CourseId")
                        .HasName("PK__Course__C92D71873200C9EC");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("LittleLearningSystem.Models.Enroll", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<decimal?>("Score")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("StudentId", "CourseId")
                        .HasName("PK__Enroll__5E57FD61BEB4025B");

                    b.HasIndex("CourseId");

                    b.ToTable("Enroll", (string)null);
                });

            modelBuilder.Entity("LittleLearningSystem.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .HasColumnType("int")
                        .HasColumnName("MaterialID");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("MaterialId")
                        .HasName("PK__Material__C5061317BB034DFD");

                    b.HasIndex("CourseId");

                    b.ToTable("Material", (string)null);
                });

            modelBuilder.Entity("LittleLearningSystem.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Spassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("SPassword");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("StudentId")
                        .HasName("PK__Student__32C52A79262AB31D");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("LittleLearningSystem.Models.Enroll", b =>
                {
                    b.HasOne("LittleLearningSystem.Models.Course", "Course")
                        .WithMany("Enrolls")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_Enroll_Course");

                    b.HasOne("LittleLearningSystem.Models.Student", "Student")
                        .WithMany("Enrolls")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Enroll_Student");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LittleLearningSystem.Models.Material", b =>
                {
                    b.HasOne("LittleLearningSystem.Models.Course", "Course")
                        .WithMany("Materials")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_Material_Course");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LittleLearningSystem.Models.Course", b =>
                {
                    b.Navigation("Enrolls");

                    b.Navigation("Materials");
                });

            modelBuilder.Entity("LittleLearningSystem.Models.Student", b =>
                {
                    b.Navigation("Enrolls");
                });
#pragma warning restore 612, 618
        }
    }
}
