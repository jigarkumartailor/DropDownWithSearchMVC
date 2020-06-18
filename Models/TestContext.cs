using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DropDownWithSearch.Models
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

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<EmpDeptIns> EmpDeptIns { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeList> EmployeeList { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=TestDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Ins)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.InsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_Institution");
            });

            modelBuilder.Entity<EmpDeptIns>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Ins)
                    .WithMany()
                    .HasForeignKey(d => d.InsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmpDeptIns_Institution");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<EmployeeList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeeList");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.InsName).IsRequired();
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
