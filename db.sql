USE master
-- Xóa database cũ nếu tồn tại
DROP DATABASE IF EXISTS QuanlyKho;
GO
-- Tạo database mới
CREATE DATABASE QuanlyKho;
GO
USE QuanlyKho;
GO

-- Tạo bảng Unit (Đơn vị tính)
CREATE TABLE Unit (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);

-- Tạo bảng Supplier (Nhà cung cấp)
CREATE TABLE Supplier (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(20) UNIQUE,
    ContactDate DATE,
    MoreInfo NVARCHAR(500)
);

-- Tạo bảng Customer (Khách hàng)
CREATE TABLE Customer (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(20) UNIQUE,
    ContactDate DATE,
    MoreInfo NVARCHAR(500)
);

-- Tạo bảng Category (Danh mục sản phẩm)
CREATE TABLE Category (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);

-- Tạo bảng Product (Hàng hóa)
CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    IdUnit INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 0,
    CategoryId INT, -- Thêm cột CategoryId
	WarningQuantity INT,
    FOREIGN KEY (IdUnit) REFERENCES Unit(Id),
    FOREIGN KEY (CategoryId) REFERENCES Category(Id) -- Liên kết với bảng Category
);

-- Bảng trung gian ProductSupplier (Sản phẩm - Nhà cung cấp)
CREATE TABLE ProductSupplier (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdProduct INT NOT NULL,
    IdSupplier INT NOT NULL,
    FOREIGN KEY (IdProduct) REFERENCES Product(Id),
    FOREIGN KEY (IdSupplier) REFERENCES Supplier(Id)
);

-- Tạo bảng Input (Phiếu nhập)
CREATE TABLE Input (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DateInput DATE NOT NULL
);

-- Tạo bảng InputInfo (Chi tiết phiếu nhập)
CREATE TABLE InputInfo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdProductSupplier INT NOT NULL,
    IdInput INT NOT NULL,
    Count INT NOT NULL,
    InputPrice DECIMAL(18,2) NOT NULL,
    OutputPrice DECIMAL(18,2) NOT NULL, --giá xuất dự kiến
    Status NVARCHAR(50),
    ContractImage VARBINARY(MAX),
    FOREIGN KEY (IdProductSupplier) REFERENCES ProductSupplier(Id),
    FOREIGN KEY (IdInput) REFERENCES Input(Id)
);

-- Tạo bảng Output (Phiếu xuất)
CREATE TABLE Output (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DateOutput DATE NOT NULL
);

-- Tạo bảng OutputInfo (Chi tiết phiếu xuất)
CREATE TABLE OutputInfo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdOutput INT NOT NULL,
    IdProduct INT NOT NULL,
    IdInputInfo INT NOT NULL,
    Count INT NOT NULL,
	OutputPrice DECIMAL(18,2) NOT NULL, -- giá xuất thật
    IdCustomer INT NOT NULL,
    ContractImage VARBINARY(MAX),
    Status NVARCHAR(50),
    FOREIGN KEY (IdOutput) REFERENCES Output(Id),
    FOREIGN KEY (IdProduct) REFERENCES Product(Id),
    FOREIGN KEY (IdInputInfo) REFERENCES InputInfo(Id),
    FOREIGN KEY (IdCustomer) REFERENCES Customer(Id)
);

-- Tạo bảng Employee (Nhân viên)
CREATE TABLE Employee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Phone NVARCHAR(20) UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    Status BIT NOT NULL DEFAULT 1
);

-- Tạo bảng Attendance (Chấm công)
CREATE TABLE Attendance (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    Date DATE NOT NULL,
    IsAbsent BIT NOT NULL,
    Note NVARCHAR(255),
    CONSTRAINT FK_Attendance_Employee FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
    CONSTRAINT UQ_Attendance_Employee_Date UNIQUE (EmployeeId, Date)
);

