using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_Core.Models
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.ToTable("Department");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("Dept_Id");

                entity.Property(e => e.DeptDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Dept_Desc");

                entity.Property(e => e.DeptLocation)
                    .HasMaxLength(50)
                    .HasColumnName("Dept_Location");

                entity.Property(e => e.DeptManager).HasColumnName("Dept_Manager");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .HasColumnName("Dept_Name");

                entity.Property(e => e.ManagerHiredate)
                    .HasColumnType("date")
                    .HasColumnName("Manager_hiredate");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StId);

                entity.ToTable("Student");

                entity.Property(e => e.DeptId).HasColumnName("Dept_Id");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("Full_Name");

                entity.Property(e => e.StAddress)
                    .HasMaxLength(100)
                    .HasColumnName("St_Address");

                entity.Property(e => e.StAge).HasColumnName("St_Age");

                entity.Property(e => e.StId).HasColumnName("St_Id");

                entity.Property(e => e.StLname)
                    .HasMaxLength(10)
                    .HasColumnName("St_Lname")
                    .IsFixedLength(true);

                entity.Property(e => e.StSuper).HasColumnName("St_super");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
