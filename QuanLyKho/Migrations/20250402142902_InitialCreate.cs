using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKho.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3214EC07F509DC8B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ContactDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MoreInfo = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3214EC07987F24E8", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3214EC07256EBBD4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Input",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateInput = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Input__3214EC072F75DBAF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Output",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOutput = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Output__3214EC0742352A9A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ContactDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MoreInfo = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Supplier__3214EC07F6861598", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Unit__3214EC0734CBA8A6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    IsAbsent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attendan__3214EC07EE8EF055", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IdUnit = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    WarningQuantity = table.Column<int>(type: "INTEGER", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__3214EC07D6D7399C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Product__Categor__33D4B598",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Product__IdUnit__32E0915F",
                        column: x => x.IdUnit,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProduct = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSupplier = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductS__3214EC07F4F3CBB8", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProductSu__IdPro__36B12243",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ProductSu__IdSup__37A5467C",
                        column: x => x.IdSupplier,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InputInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProductSupplier = table.Column<int>(type: "INTEGER", nullable: false),
                    IdInput = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    InputPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OutputPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ContractImage = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InputInf__3214EC07109D386D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__InputInfo__IdInp__3D5E1FD2",
                        column: x => x.IdInput,
                        principalTable: "Input",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__InputInfo__IdPro__3C69FB99",
                        column: x => x.IdProductSupplier,
                        principalTable: "ProductSupplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OutputInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdOutput = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProduct = table.Column<int>(type: "INTEGER", nullable: false),
                    IdInputInfo = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCustomer = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractImage = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OutputIn__3214EC07F8D0596F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__OutputInf__IdCus__44FF419A",
                        column: x => x.IdCustomer,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OutputInf__IdInp__440B1D61",
                        column: x => x.IdInputInfo,
                        principalTable: "InputInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OutputInf__IdOut__4222D4EF",
                        column: x => x.IdOutput,
                        principalTable: "Output",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OutputInf__IdPro__4316F928",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Attendance_Employee_Date",
                table: "Attendance",
                columns: new[] { "EmployeeId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Category__737584F614237C5B",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__5C7E359E93D59A33",
                table: "Customer",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__A9D105342B3741AC",
                table: "Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__5C7E359EB71966F3",
                table: "Employee",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__A9D10534A8ED21EA",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputInfo_IdInput",
                table: "InputInfo",
                column: "IdInput");

            migrationBuilder.CreateIndex(
                name: "IX_InputInfo_IdProductSupplier",
                table: "InputInfo",
                column: "IdProductSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_OutputInfo_IdCustomer",
                table: "OutputInfo",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_OutputInfo_IdInputInfo",
                table: "OutputInfo",
                column: "IdInputInfo");

            migrationBuilder.CreateIndex(
                name: "IX_OutputInfo_IdOutput",
                table: "OutputInfo",
                column: "IdOutput");

            migrationBuilder.CreateIndex(
                name: "IX_OutputInfo_IdProduct",
                table: "OutputInfo",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdUnit",
                table: "Product",
                column: "IdUnit");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_IdProduct",
                table: "ProductSupplier",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_IdSupplier",
                table: "ProductSupplier",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "UQ__Supplier__5C7E359E6F037600",
                table: "Supplier",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Supplier__A9D1053492801B71",
                table: "Supplier",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Unit__737584F61F12D1C6",
                table: "Unit",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "OutputInfo");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "InputInfo");

            migrationBuilder.DropTable(
                name: "Output");

            migrationBuilder.DropTable(
                name: "Input");

            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
