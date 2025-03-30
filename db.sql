CREATE DATABASE QuanlyKho;
GO
USE QuanLyKho;
GO

-- Bảng Unit (Đơn vị tính)
CREATE TABLE Unit (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);

-- Bảng Supplier (Nhà cung cấp)
CREATE TABLE Supplier (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(20) UNIQUE,
    ContactDate DATE,
    MoreInfo NVARCHAR(500)
);

-- Bảng Customer (Khách hàng)
CREATE TABLE Customer (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(20) UNIQUE,
    ContactDate DATE,
    MoreInfo NVARCHAR(500)
);

-- Bảng Object (Hàng hóa)
CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    IdUnit INT NOT NULL,
    IdSupplier INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 0,
    FOREIGN KEY (IdUnit) REFERENCES Unit(Id),
    FOREIGN KEY (IdSupplier) REFERENCES Supplier(Id)
);

-- Bảng Input (Phiếu nhập)
CREATE TABLE Input (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DateInput DATE NOT NULL
);

-- Bảng InputInfo (Chi tiết phiếu nhập)
CREATE TABLE InputInfo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdProduct INT NOT NULL,
    IdSupplier INT NOT NULL,
    IdInput INT NOT NULL,
    Count INT NOT NULL,
    InputPrice DECIMAL(18,2) NOT NULL,
    OutputPrice DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(50),
    FOREIGN KEY (IdProduct) REFERENCES Product(Id),
    FOREIGN KEY (IdSupplier) REFERENCES Supplier(Id),
    FOREIGN KEY (IdInput) REFERENCES Input(Id)
);

-- Bảng Output (Phiếu xuất)
CREATE TABLE Output (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DateOutput DATE NOT NULL
);

-- Bảng OutputInfo (Chi tiết phiếu xuất)
CREATE TABLE OutputInfo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdOutput INT NOT NULL,
    IdProduct INT NOT NULL,
    IdInputInfo INT NOT NULL,
    Count INT NOT NULL,
    IdCustomer INT NOT NULL,
    Status NVARCHAR(50),
    FOREIGN KEY (IdOutput) REFERENCES Output(Id),
    FOREIGN KEY (IdProduct) REFERENCES Product(Id),
    FOREIGN KEY (IdInputInfo) REFERENCES InputInfo(Id),
    FOREIGN KEY (IdCustomer) REFERENCES Customer(Id)
);

-- Bảng Employee (Nhân viên)
CREATE TABLE Employee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Phone NVARCHAR(20) UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    Status BIT NOT NULL DEFAULT 1
);

INSERT INTO Employee (Name, Address, Phone, Email, Status)
VALUES 
('Nguyễn Văn A', '123 Đường ABC, Quận 1', '0909123456', 'nguyenvana@gmail.com', 1),
('Trần Thị B', '456 Đường DEF, Quận 3', '0912345678', 'tranthib@yahoo.com', 1),
('Lê Văn C', '789 Đường GHI, Quận 5', '0987654321', 'levanc@outlook.com', 0),
('Phạm Thị D', '321 Đường JKL, Quận 7', '0977123456', 'phamthid@hotmail.com', 1);

-- Bảng Attendance (Chấm công)
CREATE TABLE Attendance (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    Date DATE NOT NULL,
    IsAbsent BIT NOT NULL,
    Note NVARCHAR(255),
    CONSTRAINT FK_Attendance_Employee FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
    CONSTRAINT UQ_Attendance_Employee_Date UNIQUE (EmployeeId, Date)
);
INSERT INTO Unit (Name)
VALUES 
('Cái'),
('Kg'),
('Lít');

INSERT INTO Supplier (Name, Address, Email, Phone, ContactDate, MoreInfo)
VALUES 
('Nhà Cung Cấp A', '123 Đường ABC, Quận 1', 'nccA@gmail.com', '0909123456', '2025-03-30', 'Nhà cung cấp chính thức sản phẩm điện tử.'),
('Nhà Cung Cấp B', '456 Đường DEF, Quận 2', 'nccB@yahoo.com', '0912345678', '2025-03-28', 'Cung cấp thiết bị văn phòng phẩm.');

INSERT INTO Customer (Name, Address, Email, Phone, ContactDate, MoreInfo)
VALUES 
('Khách hàng A', '123 Đường ABC, Quận 1', 'khachhangA@gmail.com', '0909123456', '2025-03-25', 'Khách hàng thường xuyên mua thiết bị văn phòng.'),
('Khách hàng B', '789 Đường GHI, Quận 3', 'khachhangB@yahoo.com', '0987654321', '2025-03-26', 'Khách hàng mua hàng với số lượng lớn.');

INSERT INTO Product (Name, IdUnit, IdSupplier, Quantity)
VALUES 
('Laptop', 1, 1, 50),
('Điện thoại', 1, 2, 30),
('Máy tính bảng', 1, 1, 20);

INSERT INTO Attendance (EmployeeId, Date, IsAbsent, Note)
VALUES 
(1, '2025-03-30', 0, NULL),
(2, '2025-03-30', 0, NULL),
(3, '2025-03-30', 1, 'Nghỉ vì lý do cá nhân'),
(4, '2025-03-30', 0, NULL);

-- Thêm một phiếu nhập vào bảng Input
INSERT INTO Input (DateInput)
VALUES ('2025-03-30');  -- Thêm phiếu nhập với ngày nhập là 30/03/2025
-- Thêm thông tin chi tiết vào phiếu nhập (InputInfo)
INSERT INTO InputInfo (IdProduct, IdSupplier, IdInput, Count, InputPrice, OutputPrice, Status)
VALUES 
(1, 1, 1, 10, 1500000, 1800000, 'Mới'),
(3, 2, 1, 15, 800000, 1000000, 'Mới');
