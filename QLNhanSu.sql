
select * from TaiKhoan
insert into TaiKhoan values('TK02', 'staff', '123', 'NV03', N'Người dùng')
--create database QLNhanSu
--use QLNhanSu
-- =========================
-- BẢNG PHÒNG BAN
-- =========================
CREATE TABLE PhongBan (
    MaPhongBan VARCHAR(10) PRIMARY KEY NOT NULL,
    TenPhongBan NVARCHAR(50) NOT NULL,
    MaTruongPhong VARCHAR(10) NULL
);
GO
INSERT INTO PhongBan(MaPhongBan, TenPhongBan) VALUES
('PB01', N'Phòng nhân sự');
GO


-- =========================
-- BẢNG TRÌNH ĐỘ
-- =========================
CREATE TABLE TrinhDo (
    MaTrinhDo VARCHAR(10) PRIMARY KEY NOT NULL,
    TenTrinhDo NVARCHAR(50) NOT NULL
);
GO
INSERT INTO TrinhDo VALUES 
('TD01', N'Cao đẳng'),
('TD02', N'Cử nhân'),
('TD03', N'Thạc sĩ'),
('TD04', N'Tiến sĩ'),
('TD05', N'Giáo sư');
GO

-- =========================
-- BẢNG NHÂN VIÊN
-- =========================
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY NOT NULL,
    HoTen NVARCHAR(50) NOT NULL,
    GioiTinh BIT NOT NULL,                 -- 1 = Nam, 0 = Nữ
    NgaySinh DATE NOT NULL,
    SDT VARCHAR(15),
    CCCD VARCHAR(12),
    DiaChi NVARCHAR(100),
    Email VARCHAR(50),
    TrangThai NVARCHAR(20) DEFAULT N'Đang làm việc',
    MaPhongBan VARCHAR(10),
    MaTrinhDo VARCHAR(10),
    ChucVu NVARCHAR(50),
    SoBaoHiemXaHoi VARCHAR(25),
    MucDong DECIMAL(18,2) DEFAULT 0,
    SoTaiKhoan VARCHAR(25),
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
    FOREIGN KEY (MaTrinhDo) REFERENCES TrinhDo(MaTrinhDo)
);




GO
ALTER TABLE PhongBan
ADD CONSTRAINT FK_PhongBan_NhanVien
FOREIGN KEY (MaTruongPhong) REFERENCES NhanVien(MaNV);
GO

-- =========================
-- BẢNG HỢP ĐỒNG
-- =========================
CREATE TABLE HopDong (
    MaHopDong VARCHAR(10) PRIMARY KEY NOT NULL,
    ThoiHan NVARCHAR(50),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    NoiDung NVARCHAR(300),
    LanKi INT DEFAULT 1,
    HeSoLuong FLOAT CHECK (HeSoLuong >= 0),
    MaNV VARCHAR(10),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO
alter table HopDong
add LuongCoBan DECIMAL(18,2) CHECK (LuongCoBan >= 0)
go
-- =========================
-- BẢNG LOẠI CÔNG
-- =========================
CREATE TABLE LoaiCong (
    MaLoaiCong VARCHAR(10) PRIMARY KEY NOT NULL,
    TenLoaiCong NVARCHAR(50) NOT NULL,
    HeSo FLOAT DEFAULT 1 CHECK (HeSo >= 0)
);
GO
-- =========================
-- BẢNG TĂNG CA
-- =========================


-- =========================
-- BẢNG PHỤ CẤP
-- =========================
CREATE TABLE PhuCap (
    MaPhuCap VARCHAR(10) PRIMARY KEY NOT NULL,
    TenPhuCap NVARCHAR(50),
    TienPhuCap DECIMAL(18,2) CHECK (TienPhuCap >= 0)
);
GO


-- =========================
-- BẢNG KHEN THƯỞNG
-- =========================
CREATE TABLE KhenThuong (
    MaKhenThuong VARCHAR(10) PRIMARY KEY NOT NULL,
    NoiDung NVARCHAR(300),
    TienKhenThuong DECIMAL(18,2) CHECK (TienKhenThuong >= 0)
);
GO


-- =========================
-- BẢNG KỶ LUẬT
-- =========================
CREATE TABLE KiLuat (
    MaKiLuat VARCHAR(10) PRIMARY KEY NOT NULL,
    NoiDung NVARCHAR(300),
    TienPhat DECIMAL(18,2) CHECK (TienPhat >= 0)
);
GO


-- =========================
-- BẢNG TÀI KHOẢN
-- =========================
CREATE TABLE TaiKhoan (
    MaNguoiDung VARCHAR(10) PRIMARY KEY,
    TenDangNhap VARCHAR(30) UNIQUE NOT NULL,
    MatKhau VARCHAR(50) NOT NULL,
    MaNV VARCHAR(10),
    VaiTro NVARCHAR(20),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO
--MaNV, VaiTro không được null
select * from NhanVien where MaNV='NV03'
INSERT INTO TaiKhoan VALUES ('TK01', 'admin', '123', 'NV01', N'Quản trị viên');
INSERT INTO TaiKhoan VALUES ('TK02', 'staff', '123', 'NV02', N'Người dùng');
GO
sp_help 'NhanVien';


-- =========================
-- BẢNG BẢNG LƯƠNG
-- =========================
CREATE TABLE BangLuong (
    MaBangLuong VARCHAR(10) PRIMARY KEY,
    MaNV VARCHAR(10),
    Thang INT CHECK (Thang BETWEEN 1 AND 12),
    Nam INT CHECK (Nam >= 2000),
    SoNgayCong FLOAT DEFAULT 0,
    SoGioTangCa FLOAT DEFAULT 0,
    TongPhuCap DECIMAL(18,2) DEFAULT 0,
    TongThuong DECIMAL(18,2) DEFAULT 0,
    TongPhat DECIMAL(18,2) DEFAULT 0,
    LuongCoBan DECIMAL(18,2),
    HeSoLuong FLOAT DEFAULT 1,
    LuongThucLinh DECIMAL(18,2),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO
SELECT TOP 1 *
FROM NhanVien


-- =========================
-- BẢNG LOẠI CÔNG - NHÂN VIÊN
-- =========================
CREATE TABLE LoaiCong_NhanVien (
    MaLoaiCong VARCHAR(10),
    MaNV VARCHAR(10),
    NgayLam DATE,
    GioVao TIME,
    GioRa TIME,
    HeSoCong DECIMAL(5,2) DEFAULT 1 CHECK (HeSoCong >= 0),
    PRIMARY KEY (MaLoaiCong, MaNV, NgayLam),
    FOREIGN KEY (MaLoaiCong) REFERENCES LoaiCong(MaLoaiCong),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO

SELECT name 
FROM sys.check_constraints 
WHERE parent_object_id = OBJECT_ID('LoaiCong_NhanVien');

ALTER TABLE LoaiCong_NhanVien
DROP CONSTRAINT CK__LoaiCong___HeSoC__778AC167;

ALTER TABLE LoaiCong_NhanVien
DROP CONSTRAINT DF__LoaiCong___HeSoC__76969D2E;

ALTER TABLE LoaiCong_NhanVien
DROP COLUMN HeSoCong;




-- =========================
-- BẢNG TĂNG CA - NHÂN VIÊN
-- =========================

GO
select * from TangCa_NhanVien

-- =========================
-- BẢNG PHỤ CẤP - NHÂN VIÊN
-- =========================
CREATE TABLE PhuCap_NhanVien (
    MaPhuCap VARCHAR(10),
    MaNV VARCHAR(10),
    PRIMARY KEY (MaPhuCap, MaNV),
    FOREIGN KEY (MaPhuCap) REFERENCES PhuCap(MaPhuCap),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO


-- =========================
-- BẢNG KHEN THƯỞNG - NHÂN VIÊN
-- =========================
CREATE TABLE Khen_NhanVien (
    MaKhenThuong VARCHAR(10),
    MaNV VARCHAR(10),
    NgayKhenThuong DATE,
    PRIMARY KEY (MaKhenThuong, MaNV),
    FOREIGN KEY (MaKhenThuong) REFERENCES KhenThuong(MaKhenThuong),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO

-- =========================
-- BẢNG KỶ LUẬT - NHÂN VIÊN
-- =========================
CREATE TABLE KiLuat_NhanVien (
    MaKiLuat VARCHAR(10),
    MaNV VARCHAR(10),
    NgayKiLuat DATE,
    PRIMARY KEY (MaKiLuat, MaNV),
    FOREIGN KEY (MaKiLuat) REFERENCES KiLuat(MaKiLuat),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO

SELECT name AS TenRangBuoc
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('TangCa_NhanVien');


ALTER TABLE TangCa_NhanVien
DROP CONSTRAINT FK__TangCa_Nh__MaTan__7D439ABD;

DROP TABLE TangCa;

DROP TABLE TangCa_NhanVien;

CREATE TABLE TangCa_NhanVien (
    MaNV VARCHAR(10),
    NgayTangCa DATE NOT NULL,
    SoGioTangCa INT CHECK (SoGioTangCa >= 0),
    PRIMARY KEY (MaNV, NgayTangCa),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);


---15/11

SELECT 
    name AS ConstraintName,
    OBJECT_NAME(parent_object_id) AS TableName
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('dbo.PhuCap_NhanVien');

ALTER TABLE PhuCap_NhanVien
DROP CONSTRAINT FK__PhuCap_Nha__MaNV__02084FDA;

ALTER TABLE PhuCap_NhanVien
ADD CONSTRAINT FK_PhuCap_Nha_MaNV_02084FDA
FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
ON DELETE CASCADE;
--
-- TangCa_NhanVien
SELECT 
    name AS ConstraintName,
    OBJECT_NAME(parent_object_id) AS TableName
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('dbo.TangCa_NhanVien');
ALTER TABLE TangCa_NhanVien
DROP CONSTRAINT [FK__TangCa_Nha__MaNV__3D2915A8]; 
ALTER TABLE TangCa_NhanVien
ADD CONSTRAINT FK_TangCa_NhanVien_NhanVien
FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
ON DELETE CASCADE;

-- Khen_NhanVien
SELECT 
    name AS ConstraintName,
    OBJECT_NAME(parent_object_id) AS TableName
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('dbo.Khen_NhanVien');
ALTER TABLE Khen_NhanVien
DROP CONSTRAINT [FK__Khen_NhanV__MaNV__05D8E0BE];
ALTER TABLE Khen_NhanVien
ADD CONSTRAINT FK_Khen_NhanVien_NhanVien
FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
ON DELETE CASCADE;

-- KiLuat_NhanVien
SELECT 
    name AS ConstraintName,
    OBJECT_NAME(parent_object_id) AS TableName
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('dbo.KiLuat_NhanVien');
ALTER TABLE KiLuat_NhanVien
DROP CONSTRAINT [FK__KiLuat_Nha__MaNV__09A971A2];
ALTER TABLE KiLuat_NhanVien
ADD CONSTRAINT FK_KiLuat_NhanVien_NhanVien
FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
ON DELETE CASCADE;

-- LoaiCong_NhanVien
SELECT 
    name AS ConstraintName,
    OBJECT_NAME(parent_object_id) AS TableName
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('dbo.LoaiCong_NhanVien');
ALTER TABLE LoaiCong_NhanVien
DROP CONSTRAINT [FK__LoaiCong_N__MaNV__797309D9];
ALTER TABLE LoaiCong_NhanVien
ADD CONSTRAINT FK_LoaiCong_NhanVien_NhanVien
FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
ON DELETE CASCADE;

--HopDong
SELECT 
    name AS ConstraintName,
    OBJECT_NAME(parent_object_id) AS TableName
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('dbo.HopDong');

ALTER TABLE HopDong
DROP CONSTRAINT FK__HopDong__MaNV__571DF1D5;

ALTER TABLE HopDong
ADD CONSTRAINT FK_HopDong_NhanVien
FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
ON DELETE CASCADE;





