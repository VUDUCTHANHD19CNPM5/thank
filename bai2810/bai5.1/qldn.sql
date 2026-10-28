CREATE DATABASE ql_dangnhap;
USE ql_dangnhap;

CREATE TABLE NguoiDung(
	id INT auto_increment primary key,
    username varchar(50) not null unique,
    password varchar(50) not null
);

insert into NguoiDung (username, password)
values ('admin', '123456');

insert into NguoiDung (username, password)
values ('Thanh', '123456');