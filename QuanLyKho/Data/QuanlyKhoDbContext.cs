using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyKho.Models;

public partial class QuanlyKhoDbContext : DbContext
{
    public QuanlyKhoDbContext()
    {
    }

    public QuanlyKhoDbContext(DbContextOptions<QuanlyKhoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Input> Inputs { get; set; }

    public virtual DbSet<InputInfo> InputInfos { get; set; }

    public virtual DbSet<Output> Outputs { get; set; }

    public virtual DbSet<OutputInfo> OutputInfos { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=QuanlyKho;User Id=sa;Password=123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC0798766A73");

            entity.ToTable("Attendance");

            entity.HasIndex(e => new { e.EmployeeId, e.Date }, "UQ_Attendance_Employee_Date").IsUnique();

            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Employee");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07EC8E75B5");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359EE8C6249B").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D105342D15C596").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MoreInfo).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC073C438062");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Phone, "UQ__Employee__5C7E359E49DD463E").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Employee__A9D10534FED458CC").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Input>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Input__3214EC077BE7ED4F");

            entity.ToTable("Input");
        });

        modelBuilder.Entity<InputInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InputInf__3214EC07B486C670");

            entity.ToTable("InputInfo");

            entity.Property(e => e.InputPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OutputPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.IdInputNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdInput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__IdInp__37A5467C");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__IdPro__35BCFE0A");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__IdSup__36B12243");
        });

        modelBuilder.Entity<Output>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Output__3214EC07B4B2F77B");

            entity.ToTable("Output");
        });

        modelBuilder.Entity<OutputInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OutputIn__3214EC07E33E70E9");

            entity.ToTable("OutputInfo");

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdCus__3F466844");

            entity.HasOne(d => d.IdInputInfoNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdInputInfo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdInp__3E52440B");

            entity.HasOne(d => d.IdOutputNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdOutput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdOut__3C69FB99");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdPro__3D5E1FD2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC073B0A8570");

            entity.ToTable("Product");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__IdSuppl__30F848ED");

            entity.HasOne(d => d.IdUnitNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdUnit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__IdUnit__300424B4");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC0797AAE523");

            entity.ToTable("Supplier");

            entity.HasIndex(e => e.Phone, "UQ__Supplier__5C7E359EA85735C1").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Supplier__A9D105348BF68F31").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MoreInfo).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Unit__3214EC0783411A75");

            entity.ToTable("Unit");

            entity.HasIndex(e => e.Name, "UQ__Unit__737584F66AF73CF7").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
