using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticalExerciseBNR_DAL;

public partial class TestscursnetcoreContext : DbContext
{
    public TestscursnetcoreContext()
    {
    }

    public TestscursnetcoreContext(DbContextOptions<TestscursnetcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=testscursnetcore;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.Idbank);

            entity.ToTable("Bank");

            entity.Property(e => e.Idbank).HasColumnName("IDBank");
            entity.Property(e => e.NameBank).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Idcustomer);

            entity.ToTable("Customer");

            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");
            entity.Property(e => e.Idbank).HasColumnName("IDBank");
            entity.Property(e => e.NameCustomer).HasMaxLength(100);

            entity.HasOne(d => d.IdbankNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Idbank)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Bank");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Iddepartment);

            entity.ToTable("Department");

            entity.Property(e => e.Iddepartment).HasColumnName("IDDepartment");
            entity.Property(e => e.NameDepartment).HasMaxLength(50);
            entity.Property(e => e.TenantId).HasColumnName("TenantID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Idemployee);

            entity.ToTable("Employee");

            entity.Property(e => e.Idemployee).HasColumnName("IDEmployee");
            entity.Property(e => e.Iddepartment).HasColumnName("IDDepartment");
            entity.Property(e => e.NameEmployee).HasMaxLength(50);

            entity.HasOne(d => d.IddepartmentNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Iddepartment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
