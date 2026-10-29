CREATE DATABASE IF NOT EXISTS HotelDB CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE HotelDB;

CREATE TABLE Phong (
    SoPhong VARCHAR(10) PRIMARY KEY,
    LoaiPhong VARCHAR(50) NOT NULL, -- 'Đơn', 'Đôi', 'VIP'
    GiaTheoGio DECIMAL(18,2) NOT NULL CHECK (GiaTheoGio >= 0),
    TrangThai VARCHAR(30) DEFAULT 'Trống' -- 'Trống', 'Đang ở', 'Đang dọn dẹp'
);

CREATE TABLE KhachHang (
    MaKH INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL,
    CCCD VARCHAR(20) UNIQUE NOT NULL,
    SoDienThoai VARCHAR(15)
);

CREATE TABLE DichVu (
    MaDV INT AUTO_INCREMENT PRIMARY KEY,
    TenDV VARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0)
);

CREATE TABLE PhieuDatPhong (
    MaPhieu INT AUTO_INCREMENT PRIMARY KEY,
    SoPhong VARCHAR(10),
    MaKH INT,
    NgayNhanPhong DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    NgayTraPhong DATETIME NULL,
    TongTienThanhToan DECIMAL(18,2) DEFAULT 0,
    FOREIGN KEY (SoPhong) REFERENCES Phong(SoPhong),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

CREATE TABLE SuDungDichVu (
    MaPhieu INT,
    MaDV INT,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    ThoiGian DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (MaPhieu, MaDV, ThoiGian),
    FOREIGN KEY (MaPhieu) REFERENCES PhieuDatPhong(MaPhieu),
    FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
);

INSERT INTO Phong (SoPhong, LoaiPhong, GiaTheoGio) VALUES 
('P101', 'Đơn', 100000),
('P102', 'Đơn', 100000),
('P201', 'Đôi', 150000),
('P202', 'Đôi', 150000),
('P301', 'VIP', 300000);

INSERT INTO DichVu (TenDV, DonGia) VALUES 
('Nước suối', 15000),
('Cà phê', 25000),
('Giặt ủi', 50000),
('Mì xào hải sản', 60000);