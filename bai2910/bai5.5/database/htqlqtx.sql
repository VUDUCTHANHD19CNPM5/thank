CREATE DATABASE IF NOT EXISTS InventoryDB CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE InventoryDB;

CREATE TABLE NhaCungCap (
    MaNCC INT AUTO_INCREMENT PRIMARY KEY,
    TenNCC VARCHAR(150) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiaChi VARCHAR(255)
);

CREATE TABLE VatTu (
    MaVatTu VARCHAR(20) PRIMARY KEY,
    TenVatTu VARCHAR(150) NOT NULL,
    DVT VARCHAR(20),
    SoLuongTon DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0)
);

CREATE TABLE PhieuKho (
    MaPhieu INT AUTO_INCREMENT PRIMARY KEY,
    LoaiPhieu VARCHAR(10) NOT NULL, -- 'NHAP' hoặc 'XUAT'
    NgayLap DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    MaNCC INT NULL,
    TongTien DECIMAL(18,2) DEFAULT 0,
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);

CREATE TABLE ChiTietPhieuKho (
    MaPhieu INT,
    MaVatTu VARCHAR(20),
    SoLuong DECIMAL(18,2) NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    PRIMARY KEY (MaPhieu, MaVatTu),
    FOREIGN KEY (MaPhieu) REFERENCES PhieuKho(MaPhieu),
    FOREIGN KEY (MaVatTu) REFERENCES VatTu(MaVatTu)
);

INSERT INTO NhaCungCap (TenNCC, DienThoai, DiaChi) VALUES
('Công ty Nông Sản Việt', '0905123456', 'Hà Nội'),
('Nhà Cung Cấp Bao Bì Xanh', '0914987654', 'TP. Hồ Chí Minh');

INSERT INTO VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES
('VT001', 'Hạt Cà Phê Robusta', 'Kg', 100.00),
('VT002', 'Sữa Tươi Tiệt Trùng', 'Hộp', 50.00),
('VT003', 'Đường Cát Trắng', 'Kg', 5.00), -- Hàng tồn thấp
('VT004', 'Ly Giấy 350ml', 'Cái', 200.00);