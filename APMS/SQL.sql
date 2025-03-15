-- Tạo cơ sở dữ liệu
CREATE DATABASE ParkingManagement;
GO
USE ParkingManagement;
GO

-- Bảng Người dùng
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Staff')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Bảng Loại Xe
CREATE TABLE VehicleTypes (
    TypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) UNIQUE NOT NULL,
    PricePerHour DECIMAL(10,2) NOT NULL
);

-- Bảng Xe
CREATE TABLE Vehicles (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    LicensePlate NVARCHAR(20) UNIQUE NOT NULL,
    OwnerName NVARCHAR(100) NOT NULL,
    TypeID INT NOT NULL,
    FOREIGN KEY (TypeID) REFERENCES VehicleTypes(TypeID)
);

-- Bảng Bãi Đỗ Xe
CREATE TABLE ParkingSlots (
    SlotID INT IDENTITY(1,1) PRIMARY KEY,
    SlotNumber NVARCHAR(10) UNIQUE NOT NULL,
    Status NVARCHAR(20) CHECK (Status IN ('Available', 'Occupied')) DEFAULT 'Available'
);

-- Bảng Giao Dịch Giữ Xe
CREATE TABLE ParkingTransactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    VehicleID INT NOT NULL,
    SlotID INT NOT NULL,
    UserID INT NOT NULL,
    EntryTime DATETIME DEFAULT GETDATE(),
    ExitTime DATETIME NULL,
    TotalAmount DECIMAL(10,2) NULL,
    FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID),
    FOREIGN KEY (SlotID) REFERENCES ParkingSlots(SlotID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Thêm dữ liệu mẫu
INSERT INTO Users (FullName, Username, PasswordHash, Role) VALUES
('Admin User', 'admin', 'hashedpassword123', 'Admin'),
('Staff User', 'staff', 'hashedpassword456', 'Staff');

INSERT INTO VehicleTypes (TypeName, PricePerHour) VALUES
('Motorbike', 5.00),
('Car', 20.00),
('Truck', 50.00);

INSERT INTO Vehicles (LicensePlate, OwnerName, TypeID) VALUES
('79A-12345', 'Nguyen Van A', 2),
('59B-67890', 'Tran Thi B', 1);

INSERT INTO ParkingSlots (SlotNumber, Status) VALUES
('A1', 'Available'),
('A2', 'Occupied'),
('B1', 'Available');

-- Thêm một giao dịch mẫu
INSERT INTO ParkingTransactions (VehicleID, SlotID, UserID, EntryTime) VALUES
(1, 2, 2, GETDATE());
