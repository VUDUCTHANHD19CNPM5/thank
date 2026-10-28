CREATE DATABASE ql_hocvien;
USE ql_hocvien;

CREATE TABLE HocVien (
	id INT AUTO_INCREMENT PRIMARY KEY,
    ho_ten varchar(100) NOT NULL,
    sdt varchar(20),
    ngay_sinh date,
    khoa_hoc varchar(100),
    gioi_tinh varchar(10),
    da_dong_hoc_phi TINYINT(1)
);

SELECT * FROM ql_hocvien.hocvien;