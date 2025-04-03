﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKho.Data;

#nullable disable

namespace QuanLyKho.Migrations
{
    [DbContext(typeof(QuanlyKhoDbContext))]
    [Migration("20250402142902_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("QuanLyKho.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAbsent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK__Attendan__3214EC07EE8EF055");

                    b.HasIndex(new[] { "EmployeeId", "Date" }, "UQ_Attendance_Employee_Date")
                        .IsUnique();

                    b.ToTable("Attendance", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK__Category__3214EC07F509DC8B");

                    b.HasIndex(new[] { "Name" }, "UQ__Category__737584F614237C5B")
                        .IsUnique();

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ContactDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("MoreInfo")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK__Customer__3214EC07987F24E8");

                    b.HasIndex(new[] { "Phone" }, "UQ__Customer__5C7E359E93D59A33")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Customer__A9D105342B3741AC")
                        .IsUnique();

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.HasKey("Id")
                        .HasName("PK__Employee__3214EC07256EBBD4");

                    b.HasIndex(new[] { "Phone" }, "UQ__Employee__5C7E359EB71966F3")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Employee__A9D10534A8ED21EA")
                        .IsUnique();

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.Input", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateInput")
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK__Input__3214EC072F75DBAF");

                    b.ToTable("Input", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.InputInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ContractImage")
                        .HasColumnType("BLOB");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdInput")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProductSupplier")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("InputPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("OutputPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK__InputInf__3214EC07109D386D");

                    b.HasIndex("IdInput");

                    b.HasIndex("IdProductSupplier");

                    b.ToTable("InputInfo", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.Output", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOutput")
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK__Output__3214EC0742352A9A");

                    b.ToTable("Output", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.OutputInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ContractImage")
                        .HasColumnType("BLOB");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdInputInfo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdOutput")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduct")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK__OutputIn__3214EC07F8D0596F");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdInputInfo");

                    b.HasIndex("IdOutput");

                    b.HasIndex("IdProduct");

                    b.ToTable("OutputInfo", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUnit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WarningQuantity")
                        .HasColumnType("INTEGER")
                        .HasColumnName("WarningQuantity");

                    b.HasKey("Id")
                        .HasName("PK__Product__3214EC07D6D7399C");

                    b.HasIndex("CategoryId");

                    b.HasIndex("IdUnit");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.ProductSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduct")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdSupplier")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("PK__ProductS__3214EC07F4F3CBB8");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdSupplier");

                    b.ToTable("ProductSupplier", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ContactDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("MoreInfo")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK__Supplier__3214EC07F6861598");

                    b.HasIndex(new[] { "Phone" }, "UQ__Supplier__5C7E359E6F037600")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Supplier__A9D1053492801B71")
                        .IsUnique();

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK__Unit__3214EC0734CBA8A6");

                    b.HasIndex(new[] { "Name" }, "UQ__Unit__737584F61F12D1C6")
                        .IsUnique();

                    b.ToTable("Unit", (string)null);
                });

            modelBuilder.Entity("QuanLyKho.Models.Attendance", b =>
                {
                    b.HasOne("QuanLyKho.Models.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK_Attendance_Employee");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QuanLyKho.Models.InputInfo", b =>
                {
                    b.HasOne("QuanLyKho.Models.Input", "IdInputNavigation")
                        .WithMany("InputInfos")
                        .HasForeignKey("IdInput")
                        .IsRequired()
                        .HasConstraintName("FK__InputInfo__IdInp__3D5E1FD2");

                    b.HasOne("QuanLyKho.Models.ProductSupplier", "IdProductSupplierNavigation")
                        .WithMany("InputInfos")
                        .HasForeignKey("IdProductSupplier")
                        .IsRequired()
                        .HasConstraintName("FK__InputInfo__IdPro__3C69FB99");

                    b.Navigation("IdInputNavigation");

                    b.Navigation("IdProductSupplierNavigation");
                });

            modelBuilder.Entity("QuanLyKho.Models.OutputInfo", b =>
                {
                    b.HasOne("QuanLyKho.Models.Customer", "IdCustomerNavigation")
                        .WithMany("OutputInfos")
                        .HasForeignKey("IdCustomer")
                        .IsRequired()
                        .HasConstraintName("FK__OutputInf__IdCus__44FF419A");

                    b.HasOne("QuanLyKho.Models.InputInfo", "IdInputInfoNavigation")
                        .WithMany("OutputInfos")
                        .HasForeignKey("IdInputInfo")
                        .IsRequired()
                        .HasConstraintName("FK__OutputInf__IdInp__440B1D61");

                    b.HasOne("QuanLyKho.Models.Output", "IdOutputNavigation")
                        .WithMany("OutputInfos")
                        .HasForeignKey("IdOutput")
                        .IsRequired()
                        .HasConstraintName("FK__OutputInf__IdOut__4222D4EF");

                    b.HasOne("QuanLyKho.Models.Product", "IdProductNavigation")
                        .WithMany("OutputInfos")
                        .HasForeignKey("IdProduct")
                        .IsRequired()
                        .HasConstraintName("FK__OutputInf__IdPro__4316F928");

                    b.Navigation("IdCustomerNavigation");

                    b.Navigation("IdInputInfoNavigation");

                    b.Navigation("IdOutputNavigation");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("QuanLyKho.Models.Product", b =>
                {
                    b.HasOne("QuanLyKho.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Product__Categor__33D4B598");

                    b.HasOne("QuanLyKho.Models.Unit", "IdUnitNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdUnit")
                        .IsRequired()
                        .HasConstraintName("FK__Product__IdUnit__32E0915F");

                    b.Navigation("Category");

                    b.Navigation("IdUnitNavigation");
                });

            modelBuilder.Entity("QuanLyKho.Models.ProductSupplier", b =>
                {
                    b.HasOne("QuanLyKho.Models.Product", "IdProductNavigation")
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("IdProduct")
                        .IsRequired()
                        .HasConstraintName("FK__ProductSu__IdPro__36B12243");

                    b.HasOne("QuanLyKho.Models.Supplier", "IdSupplierNavigation")
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("IdSupplier")
                        .IsRequired()
                        .HasConstraintName("FK__ProductSu__IdSup__37A5467C");

                    b.Navigation("IdProductNavigation");

                    b.Navigation("IdSupplierNavigation");
                });

            modelBuilder.Entity("QuanLyKho.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("QuanLyKho.Models.Customer", b =>
                {
                    b.Navigation("OutputInfos");
                });

            modelBuilder.Entity("QuanLyKho.Models.Employee", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("QuanLyKho.Models.Input", b =>
                {
                    b.Navigation("InputInfos");
                });

            modelBuilder.Entity("QuanLyKho.Models.InputInfo", b =>
                {
                    b.Navigation("OutputInfos");
                });

            modelBuilder.Entity("QuanLyKho.Models.Output", b =>
                {
                    b.Navigation("OutputInfos");
                });

            modelBuilder.Entity("QuanLyKho.Models.Product", b =>
                {
                    b.Navigation("OutputInfos");

                    b.Navigation("ProductSuppliers");
                });

            modelBuilder.Entity("QuanLyKho.Models.ProductSupplier", b =>
                {
                    b.Navigation("InputInfos");
                });

            modelBuilder.Entity("QuanLyKho.Models.Supplier", b =>
                {
                    b.Navigation("ProductSuppliers");
                });

            modelBuilder.Entity("QuanLyKho.Models.Unit", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
