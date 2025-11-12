

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
    LuongCoBan DECIMAL(18,2) CHECK (LuongCoBan >= 0),
    SoBaoHiemXaHoi VARCHAR(25),
    MucDong DECIMAL(18,2) DEFAULT 0,
    SoTaiKhoan VARCHAR(25),
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
    FOREIGN KEY (MaTrinhDo) REFERENCES TrinhDo(MaTrinhDo)
);

ALTER TABLE NhanVien
DROP CONSTRAINT CK__NhanVien__LuongC__4E88ABD4;

alter table NhanVien
drop column LuongCoBan
GO
INSERT INTO NhanVien VALUES 
('NV01', N'Nguyễn Văn A', 1, '1999-01-01', '0901234567', '123456789012', 
 N'Hà Nội', 'vana@gmail.com', N'Đang làm việc', 'PB01', 'TD01', 
 N'Quản lý', 15000000, '231725428192', 1000000, '23018278374');
 INSERT INTO NhanVien VALUES 
('NV02', N'Trần Văn B', 1, '2001-05-01', '0901292067', '123456019012', 
 N'Hà Nội', 'vanB@gmail.com', N'Đang làm việc', 'PB01', 'TD01', 
 N'NhanVien', 10000000, '231720188192', 800000, '23018123474');
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

select * from HopDong
delete from HopDong where MaHopDong = 'HD02'
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
CREATE TABLE TangCa (
    MaTangCa VARCHAR(10) PRIMARY KEY NOT NULL,
    NgayTangCa DATETIME NOT NULL
);
GO


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

INSERT INTO TaiKhoan VALUES ('TK01', 'admin', '123', 'NV01', N'Quản trị viên');
INSERT INTO TaiKhoan VALUES ('TK02', 'staff', '123', 'NV02', N'Người dùng');
GO


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



-- =========================
-- BẢNG TĂNG CA - NHÂN VIÊN
-- =========================
CREATE TABLE TangCa_NhanVien (
    MaTangCa VARCHAR(10),
    MaNV VARCHAR(10),
    SoGioTangCa INT CHECK (SoGioTangCa >= 0),
    PRIMARY KEY (MaTangCa, MaNV),
    FOREIGN KEY (MaTangCa) REFERENCES TangCa(MaTangCa),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO


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