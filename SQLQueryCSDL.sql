-- =========================
-- BẢNG PHÒNG BAN
-- =========================
CREATE TABLE PhongBan (
    MaPhongBan VARCHAR(10) PRIMARY KEY NOT NULL,
TenPhongBan NVARCHAR(30),
MaTruongPhong VARCHAR(10))
go
insert into PhongBan(MaPhongBan, TenPhongBan) values('PB01', N'Phòng nhân sự');
go
-- =========================
-- BẢNG TRÌNH ĐỘ
-- =========================
CREATE TABLE TrinhDo (
    MaTrinhDo VARCHAR(10) PRIMARY KEY NOT NULL,
    TenTrinhDo NVARCHAR(50)
);
go
INSERT INTO TrinhDo VALUES ('TD01', N'Cao đẳng');
INSERT INTO TrinhDo VALUES ('TD02', N'Cử nhân');
INSERT INTO TrinhDo VALUES ('TD03', N'Tiến sĩ');
INSERT INTO TrinhDo VALUES ('TD04', N'Thạc sĩ');
INSERT INTO TrinhDo VALUES ('TD05', N'Giáo sư');
Go
-- =========================
-- BẢNG NHÂN VIÊN
-- =========================
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY NOT NULL,
    HoTen NVARCHAR(50),
    GioiTinh BIT,
    NgaySinh DATE,
    SDT VARCHAR(15),
    CCCD VARCHAR(12),
    DiaChi NVARCHAR(100),
    Email VARCHAR(50),
    TrangThai NVARCHAR(20),
    MaPhongBan VARCHAR(10),
    MaTrinhDo VARCHAR(10),
    ChucVu NVARCHAR(50),
    LuongCoBan DECIMAL(18,2),
    SoBaoHiemXaHoi VARCHAR(15),
    MucDong DECIMAL(18,2),
    SoTaiKhoan INT,
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
    FOREIGN KEY (MaTrinhDo) REFERENCES TrinhDo(MaTrinhDo)
);
Go
ALTER TABLE NhanVien
--alter column SoTaiKhoan varchar(25)
alter column SoBaoHiemXaHoi varchar(25)
go
ALTER TABLE PhongBan
ADD CONSTRAINT FK_PhongBan_NhanVien
FOREIGN KEY (MaTruongPhong) REFERENCES NhanVien(MaNV);
GO
INSERT INTO NhanVien VALUES ('NV01', N'Nguyễn Văn A', 1, '1999-01-01', '0901234567', '123456789012', N'Hà Nội', 'vana@gmail.com', N'Đang làm việc', 'PB01', 'TD01', N'Quản lý', 15000000, '231725428192', 1000000, '23018278374');
Go
-- =========================
-- BẢNG HỢP ĐỒNG
-- =========================
CREATE TABLE HopDong (
    MaHopDong VARCHAR(10) PRIMARY KEY NOT NULL,
    ThoiHan NVARCHAR(50),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    NoiDung NVARCHAR(300),
    LanKi INT,
    HeSoLuong FLOAT,
    MaNV VARCHAR(10),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
Go
-- =========================
-- BẢNG LOẠI CÔNG
-- =========================
CREATE TABLE LoaiCong (
    MaLoaiCong VARCHAR(10) PRIMARY KEY,
    TenLoaiCong NVARCHAR(50),
    HeSo FLOAT
);
Go
-- =========================
-- BẢNG TĂNG CA
-- =========================
CREATE TABLE TangCa (
    MaTangCa VARCHAR(10) PRIMARY KEY NOT NULL,
    NgayTangCa DATETIME
);
Go
-- =========================
-- BẢNG PHỤ CẤP
-- =========================
CREATE TABLE PhuCap (
    MaPhuCap VARCHAR(10) PRIMARY KEY NOT NULL,
    TenPhuCap NVARCHAR(50),
    TienPhuCap DECIMAL(18,2)
);
Go
-- =========================
-- BẢNG KHEN THƯỞNG
-- =========================
CREATE TABLE KhenThuong (
    MaKhenThuong VARCHAR(10) PRIMARY KEY NOT NULL,
    NoiDung NVARCHAR(300),
    TienKhenThuong DECIMAL(18,2)
);
Go
-- =========================
-- BẢNG KỶ LUẬT
-- =========================
CREATE TABLE KiLuat (
    MaKiLuat VARCHAR(10) PRIMARY KEY NOT NULL,
    NoiDung NVARCHAR(300),
    TienPhat DECIMAL(18,2)
);
Go
-- =========================
-- BẢNG TÀI KHOẢN
-- =========================
CREATE TABLE TaiKhoan (
    MaNguoiDung VARCHAR(10) PRIMARY KEY,
    TenDangNhap VARCHAR(30),
    MatKhau VARCHAR(10),
    MaNV VARCHAR(10),
    VaiTro NVARCHAR(20),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
Go
INSERT INTO TaiKhoan VALUES ('TK01', 'ADMIN', '123', 'NV01', N'Quản trị');
-- =========================
-- BẢNG BẢNG LƯƠNG
-- =========================
CREATE TABLE BangLuong (
    MaBangLuong VARCHAR(10) PRIMARY KEY,
    MaNV VARCHAR(10),
    Thang INT,
    Nam INT,
    SoNgayCong FLOAT,
    SoGioTangCa FLOAT,
    TongPhuCap DECIMAL(18,2),
    TongThuong DECIMAL(18,2),
    TongPhat DECIMAL(18,2),
    LuongCoBan DECIMAL(18,2),
    HeSoLuong FLOAT,
    LuongThucLinh DECIMAL(18,2),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
Go
-- =========================
-- BẢNG LOẠI CÔNG - NHÂN VIÊN
-- =========================
CREATE TABLE LoaiCong_NhanVien (
    MaLoaiCong VARCHAR(10),
    MaNV VARCHAR(10),
    NgayLam DATE,
    GioVao TIME,
    GioRa TIME,
    HeSoCong DECIMAL(5,2),
    PRIMARY KEY (MaLoaiCong, MaNV),
    FOREIGN KEY (MaLoaiCong) REFERENCES LoaiCong(MaLoaiCong),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
Go
-- =========================
-- BẢNG TĂNG CA - NHÂN VIÊN
-- =========================
CREATE TABLE TangCa_NhanVien (
    MaTangCa VARCHAR(10),
    MaNV VARCHAR(10),
    SoGioTangCa INT,
    PRIMARY KEY (MaTangCa, MaNV),
    FOREIGN KEY (MaTangCa) REFERENCES TangCa(MaTangCa),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
Go
-- =========================
-- BẢNG PHỤ CẤP - NHÂN VIÊN
-- =========================
CREATE TABLE PhuCap_NhanVien (
    MaPhuCap VARCHAR(10),
    MaNV VARCHAR(10),
    TienPhuCap DECIMAL(18,2),
    PRIMARY KEY (MaPhuCap, MaNV),
    FOREIGN KEY (MaPhuCap) REFERENCES PhuCap(MaPhuCap),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
Go
-- =========================
-- BẢNG KHEN THƯỞNG - NHÂN VIÊN
-- =========================
CREATE TABLE Khen_NhanVien (
    MaKhenThuong VARCHAR(10),
    MaNV VARCHAR(10),
    NgayKhenThuong DATE,
    TienKhenThuong DECIMAL(18,2),
    PRIMARY KEY (MaKhenThuong, MaNV),
    FOREIGN KEY (MaKhenThuong) REFERENCES KhenThuong(MaKhenThuong),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
Go
-- =========================
-- BẢNG KỶ LUẬT - NHÂN VIÊN
-- =========================
CREATE TABLE KiLuat_NhanVien (
    MaKiLuat VARCHAR(10),
    MaNV VARCHAR(10),
    NgayKiLuat DATE,
    TienPhat DECIMAL(18,2),
    PRIMARY KEY (MaKiLuat, MaNV),
    FOREIGN KEY (MaKiLuat) REFERENCES KiLuat(MaKiLuat),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
