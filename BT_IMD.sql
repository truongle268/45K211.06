Create database BTN_IMD
use BTN_IMD

--tạo tài khoản
Create table TaiKhoan
(
  ID char(10),
  TenDangNhap nvarchar (50),
  MatKhau char(10),
  primary key (ID),
)
INSERT INTO TaiKhoan
Values
('1','minh', '12345'),
('2','Trúc Ly', '56789'),
('3','Hoàng Quỳnh', '1809'),
('4','Phương Trúc', '1357')

---Tạo bảng xem thông tin
Create table XemThongTin
(
	HoTen nvarchar(50),
	MaSV char(12),
	BienSo char(12),
	DongXe nvarchar(100),
	MauXe nvarchar(50),
	NhapMatKhau char(10),
	NhapLaiMatKhau char(10)
primary key (MaSV)
)
insert into XemThongTin
values
(N'Nguyễn Thị Minh','191121521119','43B1235',N'Honda Vision',N'màu đỏ','12345','12345'),
(N'Lê Thị Trúc Ly','191121521118','43B1375',N'Honda Vario',N'màu đen','56789','56789'),
(N'Hoàng Thuý Quỳnh','191121521120','43B1235',N'Yamaha latter',N'màu Trắng','1809','1809'),
(N'Võ Huỳnh Phương Trúc','191121521121','43B1235',N'SYM Elite',N'màu đen','12345','12345')

-- Tạo Bảng feedback
Create table Feedback
(
  ID char(10),
  Feedback nvarchar (100),
  primary key (ID),
)
INSERT INTO Feedback
Values
('SV001',N'Ứng dụng rất tiện lợi cho sinh sử dụng'),
('SV002',N'Hệ thống rất tốt'),
('SV003',N'các tính năng của ứng dụng tạo thuận lợi cho sinh viên'),
('SV004',N'Ứng dụng cần được cải thiện nhiều hơn'),
('SV005',N'Hệ thống nên được nâng cấp')

--Tạo bảng Thông báo
Create table ThongBao
(
  ID char(10),
  ThongBao nvarchar (100),
  primary key (ID),
)
INSERT INTO ThongBao
Values
('QT001',N'Nhà xe nhận giữ xe từ 6h đến 20h'),
('QT002',N'Nhà xe nhận giữ xe từ thứ 2 đến thứ 7 hàng tuần'),
('QT003',N'Thông báo các bạn sinh viên xem thời hạn vé để gia hạn')