CREATE DATABASE IF NOT EXISTS CafePOSDB CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE CafePOSDB;

CREATE TABLE BanAn (
    MaBan INT AUTO_INCREMENT PRIMARY KEY,
    TenBan VARCHAR(50) NOT NULL,
    TrangThai VARCHAR(20) DEFAULT 'Trống'
);

CREATE TABLE DanhMuc (
    MaDanhMuc INT AUTO_INCREMENT PRIMARY KEY,
    TenDanhMuc VARCHAR(100) NOT NULL
);

CREATE TABLE MonAn (
    MaMon INT AUTO_INCREMENT PRIMARY KEY,
    TenMon VARCHAR(100) NOT NULL,
    MaDanhMuc INT,
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc) ON DELETE CASCADE
);

CREATE TABLE HoaDon (
    MaHoaDon INT AUTO_INCREMENT PRIMARY KEY,
    MaBan INT,
    GioVao DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    GioRa DATETIME NULL,
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai TINYINT(1) DEFAULT 0, -- 0: Chưa thanh toán, 1: Đã thanh toán
    FOREIGN KEY (MaBan) REFERENCES BanAn(MaBan)
);

CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT,
    MaMon INT,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHoaDon, MaMon),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaMon) REFERENCES MonAn(MaMon)
);

INSERT INTO BanAn (TenBan) VALUES ('Bàn 01'), ('Bàn 02'), ('Bàn 03'), ('Bàn 04'), ('Bàn 05'), ('Bàn 06');
INSERT INTO DanhMuc (TenDanhMuc) VALUES ('Cà phê'), ('Trà sữa'), ('Đồ ăn nhẹ');
INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES 
('Cà phê đen', 1, 25000),
('Cà phê sữa', 1, 29000),
('Trà sữa Trân châu', 2, 35000),
('Trà ô long', 2, 30000),
('Bánh mì tỏi', 3, 20000);