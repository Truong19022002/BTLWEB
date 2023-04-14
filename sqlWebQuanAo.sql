create database QlWebQuanAo
use QlWebQuanAo
--tao bang nhanvien
CREATE TABLE tNhanVien(
	[MaNV] nvarchar(25) NOT NULL,
	[TenNV] nvarchar(50) NULL,
	[MaCV] nvarchar(25)  NULL,
	[username] nvarchar(100) NULL,
	[NgaySinh] date NULL,
	[GioiTinh] nvarchar(5)  null,
	[SDT] int NULL,
	[Luong] int NULL,
	CONSTRAINT [pk_MaNV] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
alter table tNhanVien
add [AnhDaiDien] nvarchar(100) NULL

GO
--tao bang chucvu
CREATE TABLE tChucVu(
	[MaCV] nvarchar(25) not NULL,
	[TenCV] nvarchar(50) NULL,
	CONSTRAINT [pk_tChucVu] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--tao bang phieuhap
CREATE TABLE tPhieuNhap(
	[SoHDN] nvarchar(25) not NULL,
	[NgayNhap] datetime NULL,
	[MaNCC] nvarchar(25)  NULL,
	CONSTRAINT [pk_tPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[SoHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
--tao bang nha cung cap
CREATE TABLE tNhaCungCap(
	[MaNCC] nvarchar(25)  not NULL,
	[TenNCC] nvarchar(200) NULL,
	[DiaChi] nvarchar(200) NULL,
	[SDT] int NULL,
	CONSTRAINT [pk_tNhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
--tao bang khachhang
CREATE TABLE tKhachHang(
	[MaKH] nvarchar(25) not NULL,
	[TenKH] nvarchar(50) NULL,
	[username] nvarchar(100) NULL,
	[GioiTinh] nvarchar(5) NULL,
	[DiaChi] nvarchar(150) NULL,
	[SDT] int NULL,
	[Email] nvarchar(100) NULL,
	CONSTRAINT [pk_tKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
alter table tKhachHang
add [AnhDaiDien] nvarchar(100) NULL

GO
--t?o bang hoadonban
CREATE TABLE tHoaDonBan(
	[SoHDB] nvarchar(25) not NULL,
	[NgayLapHD] datetime NULL,
	[MaKH] nvarchar(25)  NULL,
	[MaNV] nvarchar(25)  NULL,
	[TongTienHD] int NULL,
	[GiamGiaHD] float NULL,
	[PhuongThucThanhToan] tinyint NULL,
	CONSTRAINT [pk_tHoaDonBan] PRIMARY KEY CLUSTERED 
(
	[SoHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--tao bang chi tiet hoa don ban
CREATE TABLE tChiTietHDB(
	[SoHDB] nvarchar(25) NOT NULL,
	[MaChiTietSP] nvarchar(25) NOT NULL,
	[SoLuongBan] int NULL,
	[DonGiaBan] int NULL,
	[GiamGia] float NULL,
 CONSTRAINT [PK_tChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[SoHDB] ASC,
	[MaChiTietSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--t?o bang san pham
CREATE TABLE tSanPham(
	[MaSP] nvarchar(25) not  NULL,
	[TenSP] nvarchar(200)  NULL,
	[GiaNhap] int NULL,
	[GiaBan] int NULL,
	[MaDD] nvarchar(25)  NULL,
	[MaCL] nvarchar(25)  NULL,
	[MaLoai] nvarchar(25)  NULL,
	[MaNCC] nvarchar(25)  NULL,
	[AnhDaiDien] nvarchar(100) NULL,
	CONSTRAINT [pk_tSanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--tao bang chi tiet san pham
CREATE TABLE tChiTietSP(
	[MaChiTietSP] nvarchar(25) NOT NULL,
	[MaSP] nvarchar(25)  NULL,
	[MaMauSac] nvarchar(25)  NULL,
	[MaKichCo] nvarchar(25)  NULL,
	[SoLuong] int  null,
	[AnhDaiDien] nvarchar(100) NULL,
	CONSTRAINT [pk_tChiTietSP] PRIMARY KEY CLUSTERED 
(
	[MaChiTietSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--tao bang anh san pham
CREATE TABLE tAnhSP(
	[MaSP] nvarchar(25) NOT NULL,
	[TenFileAnh] nvarchar(100) NOT  NULL,
	[ViTri] smallint NULL,
	CONSTRAINT [pk_tAnhSP] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC,
	[TenFileAnh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--t?o bang d?c di?m
CREATE TABLE tDacDiem(
	[MaDD] nvarchar(25) NOT  NULL,
	[TenDD] nvarchar(200) NULL,
	CONSTRAINT [pk_tDacDiem] PRIMARY KEY CLUSTERED 
(
	[MaDD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
--t?o bang màu
CREATE TABLE tMauSac(
	[MaMauSac] nvarchar(25) NOT NULL,
	[TenMauSac] nvarchar(200) NULL,
	CONSTRAINT [pk_tMau] PRIMARY KEY CLUSTERED 
(
	[MaMauSac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
--t?o bang kich co
CREATE TABLE tKichCo(
	[MaKichCo] nvarchar(25) NOT NULL,
	[TenKichCo] nvarchar(200) NULL,
	CONSTRAINT [pk_tKichCo] PRIMARY KEY CLUSTERED 
(
	[MaKichCo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--tao bang loai san pham
CREATE TABLE tLoaiSP(
	[MaLoai] nvarchar(25)NOT NULL,
	[Loai] nvarchar(100) NULL,
 CONSTRAINT [PK_tLoaiSP] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
--
CREATE TABLE [dbo].[Order](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[MaKH] [nvarchar](25) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[OrderDetail](
	[MaSP] nvarchar(25) not  NULL,
	[OderID] [bigint] NOT NULL,
	[Quanlity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[ID] [bigint] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC,
	[OderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
--tao bang chat lieu sp
CREATE TABLE tChatlieuSP(
	[MaCL] nvarchar(25) NOT NULL,
	[TenCL] nvarchar(100) NULL,
 CONSTRAINT [PK_tChatlieuSP] PRIMARY KEY CLUSTERED 
(
	[MaCL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--tao bang nguoi dung
CREATE TABLE [dbo].[tUser](
	[username] nvarchar(100)not  NULL,
	[password] nvarchar(256) NOT  NULL,
	
	
	[email] nvarchar (100)  NULL,
	[LoaiUser] tinyint NULL,
 CONSTRAINT [PK_tUser] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--Foreign key--

ALTER TABLE [dbo].tSanPham  WITH CHECK ADD  CONSTRAINT [FK_tSanPham_tDacDiem] FOREIGN KEY([MaDD])
REFERENCES [dbo].[tDacDiem] ([MaDD])
GO
ALTER TABLE [dbo].tSanPham CHECK CONSTRAINT [FK_tSanPham_tDacDiem]
GO

ALTER TABLE [dbo].tSanPham  WITH CHECK ADD  CONSTRAINT [FK_tSanPham_tLoaiSP] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[tLoaiSP] ([MaLoai])
GO
ALTER TABLE [dbo].tSanPham CHECK CONSTRAINT [FK_tSanPham_tLoaiSP]
GO

ALTER TABLE [dbo].tSanPham  WITH CHECK ADD  CONSTRAINT [FK_tSanPham_tChatlieuSP] FOREIGN KEY([MaCL])
REFERENCES [dbo].[tChatlieuSP] ([MaCL])
GO
ALTER TABLE [dbo].tSanPham CHECK CONSTRAINT [FK_tSanPham_tChatlieuSP]
GO

ALTER TABLE [dbo].tSanPham  WITH CHECK ADD  CONSTRAINT [FK_tSanPham_tNhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[tNhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].tSanPham CHECK CONSTRAINT [FK_tSanPham_tNhaCungCap]
GO


ALTER TABLE [dbo].tChiTietSP  WITH CHECK ADD  CONSTRAINT [FK_tChiTietSP_tSanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[tSanPham] ([MaSP])
GO
ALTER TABLE [dbo].tChiTietSP CHECK CONSTRAINT [FK_tChiTietSP_tSanPham]
GO


ALTER TABLE [dbo].tChiTietSP  WITH CHECK ADD  CONSTRAINT [FK_tChiTietSP_tMauSac] FOREIGN KEY([MaMauSac])
REFERENCES [dbo].[tMauSac] ([MaMauSac])
GO
ALTER TABLE [dbo].tChiTietSP CHECK CONSTRAINT [FK_tChiTietSP_tMauSac]
GO

ALTER TABLE [dbo].tChiTietSP  WITH CHECK ADD  CONSTRAINT [FK_tChiTietSP_tKichCo] FOREIGN KEY([MaKichCo])
REFERENCES [dbo].[tKichCo] ([MaKichCo])
GO
ALTER TABLE [dbo].tChiTietSP CHECK CONSTRAINT [FK_tChiTietSP_tKichCo]
GO

ALTER TABLE [dbo].tPhieuNhap  WITH CHECK ADD  CONSTRAINT [FK_tPhieuNhap_tNhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[tNhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].tPhieuNhap CHECK CONSTRAINT [FK_tPhieuNhap_tNhaCungCap]
GO

ALTER TABLE [dbo].tHoaDonBan  WITH CHECK ADD  CONSTRAINT [FK_tHoaDonBan_tKhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[tKhachHang] ([MaKH])
GO
ALTER TABLE [dbo].tHoaDonBan CHECK CONSTRAINT [FK_tHoaDonBan_tKhachHang]
GO

ALTER TABLE [dbo].tChiTietHDB  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHDB_tChiTietSP] FOREIGN KEY([MaChiTietSP])
REFERENCES [dbo].[tChiTietSP] ([MaChiTietSP])
GO
ALTER TABLE [dbo].tChiTietHDB CHECK CONSTRAINT [FK_tChiTietHDB_tChiTietSP]
GO

ALTER TABLE [dbo].tChiTietHDB  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHDB_tHoaDonBan] FOREIGN KEY([SoHDB])
REFERENCES [dbo].[tHoaDonBan] ([SoHDB])
GO
ALTER TABLE [dbo].tChiTietHDB CHECK CONSTRAINT [FK_tChiTietHDB_tHoaDonBan]
GO

ALTER TABLE [dbo].[tKhachHang]  WITH CHECK ADD  CONSTRAINT [FK_tKhachHang_tUser] FOREIGN KEY([username])
REFERENCES [dbo].[tUser] ([username])
GO
ALTER TABLE [dbo].[tKhachHang] CHECK CONSTRAINT [FK_tKhachHang_tUser]
GO
ALTER TABLE [dbo].[tNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_tNhanVien_tUser] FOREIGN KEY([username])
REFERENCES [dbo].[tUser] ([username])
GO
ALTER TABLE [dbo].[tNhanVien] CHECK CONSTRAINT [FK_tNhanVien_tUser]
GO

ALTER TABLE [dbo].[tAnhSP]  WITH CHECK ADD  CONSTRAINT [FK_tAnhSP_tSanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[tSanPham] ([MaSP])
GO
ALTER TABLE [dbo].[tAnhSP] CHECK CONSTRAINT [FK_tAnhSP_tSanPham]
GO

ALTER TABLE [dbo].[tNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_tNhanVien_tChucVu] FOREIGN KEY([MaCV])
REFERENCES [dbo].[tChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[tNhanVien] CHECK CONSTRAINT [FK_tNhanVien_tChucVu]
GO

ALTER TABLE [dbo].[tHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_tHoaDonBan_tNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tNhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tHoaDonBan] CHECK CONSTRAINT [FK_tHoaDonBan_tNhanVien]
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_tKhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[tKhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_tKhachHang]
GO

ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([ID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order] 
GO

ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_tSanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[tSanPham] ([MaSP])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_tSanPham] 
GO

--Nhap du lieu--

--insert tChatLieu
INSERT [dbo].[tChatLieuSP] ([MaCL] ,[TenCL]) VALUES (N'cot', N'Cotton')
INSERT [dbo].[tChatLieuSP] ([MaCL] ,[TenCL]) VALUES (N'li', N'Linen')
INSERT [dbo].[tChatLieuSP] ([MaCL] ,[TenCL]) VALUES (N'lea', N'Leather')
GO

--insert tLoaiSP
INSERT [dbo].[tLoaiSP] ([MaLoai] ,[Loai]) VALUES (N'nam', N'Nam')
INSERT [dbo].[tLoaiSP] ([MaLoai] ,[Loai]) VALUES (N'nu', N'Nữ')
INSERT [dbo].[tLoaiSP] ([MaLoai] ,[Loai]) VALUES (N'te', N'Trẻ em')
GO

--insert tMau
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'black', N'Ðen')
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'blue ', N'Xanh dương')
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'brown', N'Nâu')
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'gray', N'Xám')
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'green', N'Xanh lá')
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'orange', N'Cam')
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'pink ', N'Hồng')
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'red', N'Ðỏ')
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'white', N'Trắng')
INSERT [dbo].[tMauSac] ([MaMauSac], [TenMauSac]) VALUES (N'yellow ', N'Vàng')
GO

--insert tNhaCungCap
INSERT [dbo].[tNhaCungCap] ([MaNCC] ,[TenNCC] ,[DiaChi],[SDT]) VALUES (N'das', N'Adidas', NULL, NULL)
INSERT [dbo].[tNhaCungCap] ([MaNCC] ,[TenNCC] ,[DiaChi],[SDT]) VALUES (N'nik', N'Nike', NULL, NULL)
INSERT [dbo].[tNhaCungCap] ([MaNCC] ,[TenNCC] ,[DiaChi],[SDT]) VALUES (N'guc', N'Gucci', NULL, NULL)
INSERT [dbo].[tNhaCungCap] ([MaNCC] ,[TenNCC] ,[DiaChi],[SDT]) VALUES (N'pu', N'Puma', NULL, NULL)

--insert tDacDiem
INSERT [dbo].[tDacDiem] ([MaDD], [TenDD]) VALUES (N'dd1', N'lịch sự')
INSERT [dbo].[tDacDiem] ([MaDD], [TenDD]) VALUES (N'dd2', N'dễ phối đồ')
INSERT [dbo].[tDacDiem] ([MaDD], [TenDD]) VALUES (N'dd3', N'công sở')
INSERT [dbo].[tDacDiem] ([MaDD], [TenDD]) VALUES (N'dd4', N'giản dị')
INSERT [dbo].[tDacDiem] ([MaDD], [TenDD]) VALUES (N'dd5', N'cá tính')



--insert tSanPham
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'vay4', N'Váy bò nữ',220, 359, N'dd1',N'lea',N'nu',N'guc',N'model1.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'quanaolaodong', N'Bộ bảo hộ lao động',120, 180, N'dd4',N'cot',N'nam',N'pu',N'model2.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aogile', N'Áo Gile nữ',150, 260, N'dd3',N'cot',N'nu',N'das',N'model3.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnam3', N'Áo ba lỗ thể thao nam',100, 199, N'dd5',N'cot',N'nam',N'nik',N'mode4.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'vay5', N'Váy len ôm body',180, 310, N'dd2',N'li',N'nu',N'guc',N'model5.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnam4', N'Áo thun nam mùa đông',140, 220, N'dd4',N'cot',N'nam',N'das',N'model6.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'quanaonu', N'Set đồ mùa đông nữ',320, 499, N'dd2',N'cot',N'nu',N'das',N'model7.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnu4', N'Áo thun nữ cổ tim',120, 170, N'dd2',N'cot',N'nu',N'pu',N'p1.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aosominam', N'Áo sơ mi công sở nam',220, 3690, N'dd3',N'cot',N'nam',N'das',N'p2.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aokhoac4', N'Áo khoác thể thao nữ',220, 360, N'dd5',N'cot',N'nu',N'nik',N'p3.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnam5', N'Áo thun nam cổ tim',120, 180, N'dd2',N'cot',N'nam',N'das',N'p4.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'vay6', N'Váy xòe họa tiết chấm bi',190, 350, N'dd5',N'cot',N'nu',N'guc',N'p5.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnam', N'Áo Cotton nam cổ tròn',120, 160, N'dd4',N'cot',N'nam',N'das',N'Ao_thun_X_T_ca_heo.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnam1', N'Áo Cotton nam có cổ',110, 150, N'dd2',N'cot',N'nam',N'nik',N'Ao_thun_polo.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnam2', N'Áo Cotton nam có họa tiết chìm',140, 200, N'dd5',N'cot',N'nam',N'pu', N'ao_thun_cotton_nam_hoatiet.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnu', N'Áo thun nữ ngắn tay',100, 180, N'dd2',N'cot',N'nu',N'das',N'Ao_thun_nu_ngan_tay.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnu1', N'Áo thun nữ dài tay',125, 169, N'dd4',N'cot',N'nu',N'guc',N'ao_thun_colo_nu_daitay.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnu2', N'Áo thun 2 dây',99, 149, N'dd5',N'cot',N'nu',N'nik',N'Ao_thun_2_day.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aothunnu3', N'Áo thun form rộng',111, 155, N'dd2',N'cot',N'nu',N'pu',N'Ao_thun_rong.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aolen', N'Áo len cao cổ nam',200, 350, N'dd1',N'li',N'nam',N'das',N'ao-len_cao_co_nam.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aolen1', N'Áo len cardigan nữ',210, 359, N'dd5',N'li',N'nu',N'guc',N'cardigan_nu.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aolen2', N'Áo len dệt nữ',180, 259, N'dd1',N'li',N'nu',N'pu',N'Ao_len_det.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aolen3', N'Áo len cổ tròn nam',230, 300, N'dd2',N'li',N'nam',N'guc',N'ao_len_nam_co_tron.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aolen4', N'Áo khoác len nam',300, 449, N'dd1',N'li',N'nam',N'das',N'ao_khoac_len_nam_cardigan.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aolen5', N'Áo khoác len nữ',310, 469, N'dd2',N'li',N'nu',N'nik',N'ao_khoac_len_nu.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aokhoac', N'Áo khoác dù nam ',250, 320, N'dd4',N'cot',N'nam',N'das',N'ao_khoac_du_nam.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aokhoac1', N'Áo khoác dù nữ',220, 339, N'dd4',N'cot',N'nu',N'pu',N'ao_khoac_du_nu.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aokhoac2', N'Áo khoác da nam',330, 599, N'dd1',N'lea',N'nam',N'nik',N'ao_khoac_da_nam.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'aokhoac3', N'Áo khoác da nữ',300, 499, N'dd1',N'lea',N'nu',N'pu',N'ao_khoac_da_nu.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'vay', N'váy da ngắn',250, 350, N'dd5',N'lea',N'nu',N'guc',N'vay_da.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'vay1', N'váy da xòe',270, 399, N'dd2',N'lea',N'nu',N'das',N'vay_da_xoe.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'vay2', N'váy dài ',120, 200, N'dd4',N'cot',N'nu',N'pu',N'vay_xoe.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'vay3', N'váy len ',150, 269, N'dd2',N'li',N'nu',N'guc',N'vay_len.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'quan', N'Quần vải công sở nam',200, 359, N'dd1',N'cot',N'nam',N'das',N'quan_vai_nam.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'quan1', N'Quần vải công sở nữ',170, 330, N'dd1',N'cot',N'nu',N'nik',N'quan_vai_nu.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'quan2', N'Quần vải công sở nữ ống suông',180, 349, N'dd1',N'cot',N'nu',N'guc',N'quan_vai_nu_suong.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'quan3', N'Quần đũi dài nam ',120, 219, N'dd2',N'cot',N'nam',N'das',N'quan_dui_dai.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'quan4', N'Quần đũi cộc nam ',100, 199, N'dd4',N'cot',N'nam',N'nik',N'quan_dui_ngan.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'treem', N'Bộ thể thao mùa hè',100, 199, N'dd4',N'cot',N'te',N'pu',N'bo_the_thao_tre_em.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'treem1', N'Áo khoác da trẻ em ',200, 350, N'dd1',N'lea',N'te',N'guc',N'ao_khoac_da_tre_em.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'treem2', N'Bộ đồ ngủ trẻ em ',120, 200, N'dd4',N'cot',N'te',N'nik',N'do_ngu_tre_em.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'treem3', N'Áo len trẻ em ',150, 220, N'dd2',N'li',N'te',N'guc',N'ao_len_tre_em.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'treem4', N'Áo thun dài trẻ em ',120, 250, N'dd4',N'cot',N'te',N'das',N'ao_thun_tre_em.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'treem5', N'Bộ mùa dông trẻ em ',150, 269, N'dd5',N'li',N'te',N'nik',N'bo_mua_dong_tre_em.jpg')
INSERT [dbo].[tSanPham]([MaSP],[TenSP] ,[GiaNhap] ,[GiaBan] ,[MaDD] ,[MaCL],[MaLoai],[MaNCC],[AnhDaiDien]) VALUES (N'treem6', N'Áo siêu nhân  ',99, 169, N'dd5',N'cot',N'te',N'pu',N'ao_sieu_nhan.jpg')
GO

--insert tAnhSP
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'vay4',N'model1.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'quanaolaodong',N'model2.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aogile',N'model3.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnam3',N'model4.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'vay5',N'model5.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnam4',N'model6.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'quanaonu',N'model7.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnu4',N'p1.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aosominam',N'p2.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aokhoac4',N'p3.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnam5',N'p4.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'vay6',N'p5.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnam',N'Ao_thun_X_T_ca_heo.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnam1',N'Ao_thun_polo.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnam2',N'ao_thun_cotton_nam_hoatiet.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnu',N'Ao_thun_nu_ngan_tay.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnu1',N'ao_thun_colo_nu_daitay.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnu2',N'Ao_thun_2_day.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aothunnu3',N'Ao_thun_rong.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aolen',N'ao-len_cao_co_nam.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aolen1',N'cardigan_nu.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aolen2',N'Ao_len_det.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aolen3',N'ao_len_nam_co_tron.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aolen4',N'ao_khoac_len_nam_cardigan.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aolen5',N'ao_khoac_len_nu.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aokhoac',N'ao_khoac_du_nam.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aokhoac1',N'ao_khoac_du_nu.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aokhoac2',N'ao_khoac_da_nam.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'aokhoac3',N'ao_khoac_da_nu.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'vay',N'vay_da.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'vay1',N'vay_da_xoe.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'vay2',N'vay_xoe.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'vay3',N'vay_len.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'quan',N'quan_vai_nam.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'quan1',N'quan_vai_nu.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'quan2',N'quan_vai_nu_suong.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'quan3',N'quan_dui_dai.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'quan4',N'quan_dui_ngan.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'treem',N'bo_the_thao_tre_em.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'treem1',N'ao_khoac_da_tre_em.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'treem2',N'do_ngu_tre_em.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'treem3',N'ao_len_tre_em.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'treem4',N'ao_thun_tre_em.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'treem5',N'bo_mua_dong_tre_em.jpg',NULL)
INSERT [dbo].[tAnhSP]([MaSP] ,[TenFileAnh] ,[ViTri])VALUES(N'treem6',N'ao_sieu_nhan.jpg',NULL)

