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
    OutputPrice DECIMAL(18,2) NOT NULL,
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

-- Thêm một số đơn vị tính vào bảng Unit
INSERT INTO Unit (Name) VALUES ('Cái');
INSERT INTO Unit (Name) VALUES ('Kg');
INSERT INTO Unit (Name) VALUES ('Lít');

-- Thêm một số nhà cung cấp vào bảng Supplier
INSERT INTO Supplier (Name, Address, Email, Phone, ContactDate, MoreInfo) 
VALUES 
('Nhà cung cấp A', 'Địa chỉ A', 'ncc_a@example.com', '0123456789', '2025-04-01', 'Thông tin thêm A'),
('Nhà cung cấp B', 'Địa chỉ B', 'ncc_b@example.com', '0987654321', '2025-04-02', 'Thông tin thêm B');

-- Thêm một số khách hàng vào bảng Customer
INSERT INTO Customer (Name, Address, Email, Phone, ContactDate, MoreInfo) 
VALUES 
('Khách hàng A', 'Địa chỉ KH A', 'kh_a@example.com', '0912345678', '2025-04-01', 'Thông tin thêm KH A'),
('Khách hàng B', 'Địa chỉ KH B', 'kh_b@example.com', '0923456789', '2025-04-02', 'Thông tin thêm KH B');

-- Thêm danh mục sản phẩm vào bảng Category
INSERT INTO Category (Name) 
VALUES 
('Điện tử'),
('Thực phẩm'),
('Văn phòng phẩm');

-- Thêm sản phẩm vào bảng Product
INSERT INTO Product (Name, IdUnit, Quantity, CategoryId) 
VALUES 
('Smartphone', 1, 100, 1),  -- 1 là đơn vị "Cái", 1 là CategoryId "Điện tử"
('Laptop', 1, 50, 1),       -- 1 là đơn vị "Cái", 1 là CategoryId "Điện tử"
('Gạo', 2, 200, 2),        -- 2 là đơn vị "Kg", 2 là CategoryId "Thực phẩm"
('Bút bi', 1, 500, 3);     -- 1 là đơn vị "Cái", 3 là CategoryId "Văn phòng phẩm"

-- Thêm thông tin sản phẩm và nhà cung cấp vào bảng ProductSupplier
INSERT INTO ProductSupplier (IdProduct, IdSupplier) 
VALUES 
(1, 1), -- Smartphone từ Nhà cung cấp A
(2, 2), -- Laptop từ Nhà cung cấp B
(3, 1); -- Gạo từ Nhà cung cấp A

-- Thêm phiếu nhập vào bảng Input
INSERT INTO Input (DateInput) 
VALUES ('2025-04-01'), 
       ('2025-04-02');

-- Thêm chi tiết phiếu nhập vào bảng InputInfo
INSERT INTO InputInfo (IdProductSupplier, IdInput, Count, InputPrice, OutputPrice, Status) 
VALUES 
(1, 1, 50, 5000000, 6000000, 'Đã nhập'),
(2, 2, 30, 15000000, 18000000, 'Đã nhập');

-- Thêm phiếu xuất vào bảng Output
INSERT INTO Output (DateOutput) 
VALUES ('2025-04-03'), 
       ('2025-04-04');

-- Thêm chi tiết phiếu xuất vào bảng OutputInfo
INSERT INTO OutputInfo (IdOutput, IdProduct, IdInputInfo, Count, IdCustomer, ContractImage, Status) 
VALUES 
(1, 1, 1, 10, 1, NULL, 'Đã xuất'),
(2, 2, 2, 5, 2, NULL, 'Đã xuất');

-- Thêm nhân viên vào bảng Employee
INSERT INTO Employee (Name, Address, Phone, Email, Status) 
VALUES 
('Nhân viên A', 'Địa chỉ NV A', '0912345678', 'nv_a@example.com', 1),
('Nhân viên B', 'Địa chỉ NV B', '0912345679', 'nv_b@example.com', 1);

-- Thêm thông tin chấm công vào bảng Attendance
INSERT INTO Attendance (EmployeeId, Date, IsAbsent, Note) 
VALUES 
(1, '2025-04-01', 0, 'Đi làm'),
(2, '2025-04-01', 1, 'Nghỉ phép');
