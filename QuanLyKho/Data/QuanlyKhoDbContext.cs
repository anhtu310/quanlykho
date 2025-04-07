using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Models;
using System.IO;

namespace QuanLyKho.Data;

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

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Input> Inputs { get; set; }

    public virtual DbSet<InputInfo> InputInfos { get; set; }

    public virtual DbSet<Output> Outputs { get; set; }

    public virtual DbSet<OutputInfo> OutputInfos { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSupplier> ProductSuppliers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(AppContext.BaseDirectory, "QuanlyKho.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC07EE8EF055");

            entity.ToTable("Attendance");

            entity.HasIndex(e => new { e.EmployeeId, e.Date }, "UQ_Attendance_Employee_Date").IsUnique();

            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Employee");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07F509DC8B");

            entity.ToTable("Category");

            entity.HasIndex(e => e.Name, "UQ__Category__737584F614237C5B").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07987F24E8");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359E93D59A33").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D105342B3741AC").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MoreInfo).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07256EBBD4");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Phone, "UQ__Employee__5C7E359EB71966F3").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Employee__A9D10534A8ED21EA").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Input>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Input__3214EC072F75DBAF");

            entity.ToTable("Input");
        });

        modelBuilder.Entity<InputInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InputInf__3214EC07109D386D");

            entity.ToTable("InputInfo");

            entity.Property(e => e.InputPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OutputPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.IdInputNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdInput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__IdInp__3D5E1FD2");

            entity.HasOne(d => d.IdProductSupplierNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdProductSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__IdPro__3C69FB99");
        });

        modelBuilder.Entity<Output>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Output__3214EC0742352A9A");

            entity.ToTable("Output");
        });

        modelBuilder.Entity<OutputInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OutputIn__3214EC07F8D0596F");

            entity.ToTable("OutputInfo");

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdCus__44FF419A");

            entity.HasOne(d => d.IdInputInfoNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdInputInfo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdInp__440B1D61");

            entity.HasOne(d => d.IdOutputNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdOutput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdOut__4222D4EF");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdPro__4316F928");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07D6D7399C");

            entity.ToTable("Product");

            entity.Property(e => e.Name).HasMaxLength(100);

            // Thêm dòng này cho WarningQuantity (có thể nullable)
            entity.Property(e => e.WarningQuantity).HasColumnName("WarningQuantity");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__33D4B598");

            entity.HasOne(d => d.IdUnitNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdUnit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__IdUnit__32E0915F");
        });

        modelBuilder.Entity<ProductSupplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductS__3214EC07F4F3CBB8");

            entity.ToTable("ProductSupplier");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductSuppliers)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductSu__IdPro__36B12243");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.ProductSuppliers)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductSu__IdSup__37A5467C");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07F6861598");

            entity.ToTable("Supplier");

            entity.HasIndex(e => e.Phone, "UQ__Supplier__5C7E359E6F037600").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Supplier__A9D1053492801B71").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MoreInfo).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Unit__3214EC0734CBA8A6");

            entity.ToTable("Unit");

            entity.HasIndex(e => e.Name, "UQ__Unit__737584F61F12D1C6").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    // Thêm vào QuanlyKhoDbContext.cs hoặc tạo file mới ProductService.cs
    public List<Product> GetLowStockProducts()
    {
        return this.Products
            .Where(p => p.WarningQuantity.HasValue &&
                       p.Quantity <= p.WarningQuantity.Value)
            .ToList();
    }
}