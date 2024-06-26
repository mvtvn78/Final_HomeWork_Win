USE [master]
GO
/****** Object:  Database [qlsinhvien]    Script Date: 6/9/2024 9:53:15 AM ******/
CREATE DATABASE [qlsinhvien]
GO
USE [qlsinhvien]
GO
/****** Object:  Table [dbo].[GIAOVIEN]    Script Date: 6/9/2024 9:53:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIAOVIEN](
	[MAGV] [char](10) NOT NULL,
	[MAQQ] [char](10) NOT NULL,
	[TenGV] [nvarchar](150) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOCSINH]    Script Date: 6/9/2024 9:53:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOCSINH](
	[MAHS] [char](10) NOT NULL,
	[MAQQ] [char](10) NOT NULL,
	[MALOP] [char](10) NOT NULL,
	[TENHS] [nvarchar](150) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HS_HOC_LOP]    Script Date: 6/9/2024 9:53:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HS_HOC_LOP](
	[MAHS] [char](10) NOT NULL,
	[MAMH] [char](10) NOT NULL,
	[diemQT] [float] NULL,
	[diemThi] [float] NULL,
	[thoigianbatdau] [datetime] NULL,
	[thoigianketthuc] [datetime] NULL,
	[ngayhoc] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOP]    Script Date: 6/9/2024 9:53:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOP](
	[MALOP] [char](10) NOT NULL,
	[TENLOP] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MONHOC]    Script Date: 6/9/2024 9:53:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONHOC](
	[MAMH] [char](10) NOT NULL,
	[TENMH] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 6/9/2024 9:53:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[MAND] [char](10) NOT NULL,
	[TENND] [varchar](100) NULL,
	[PASS] [char](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHAN_CONG]    Script Date: 6/9/2024 9:53:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHAN_CONG](
	[MAMH] [char](10) NOT NULL,
	[MAGV] [char](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUEQUAN]    Script Date: 6/9/2024 9:53:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUEQUAN](
	[MAQQ] [char](10) NOT NULL,
	[TENQQ] [nvarchar](100) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV01      ', N'PY        ', N'Mai Hoàng Xuân', 1, CAST(N'2004-09-15T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV02      ', N'HN        ', N'Nguyễn Lương Xuân', 1, CAST(N'1987-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV03      ', N'PY        ', N'Hoàng Thị Cẩm', 0, CAST(N'1987-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV04      ', N'PY        ', N'Lương Hoàng Cao', 1, CAST(N'1987-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV05      ', N'QN        ', N'Đỗ Minh Tuấn', 1, CAST(N'1987-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV06      ', N'NT02      ', N'Cao Bá Xuân', 1, CAST(N'1987-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV07      ', N'ND        ', N'Tiêu Thị', 1, CAST(N'1987-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV08      ', N'H1        ', N'Tiêu Tiêu', 1, CAST(N'1987-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV09      ', N'CM        ', N'Cao Lâm Hoàng', 1, CAST(N'1987-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV10      ', N'PY        ', N'Lee Huynh Sung', 1, CAST(N'1987-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV11      ', N'PY        ', N'Lee Min Ho', 1, CAST(N'1987-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'T1        ', N'PY        ', N'He1', 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'T2        ', N'PY        ', N'He11', 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'T4        ', N'PY        ', N'He21', 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'T5        ', N'PY        ', N'He31', 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'T6        ', N'PY        ', N'He1231', 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'23123st   ', N'PY        ', N'Hoàng Thị Dung', 0, CAST(N'1984-07-09T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV0232s   ', N'CM        ', N'Hoàng Văn Kan', 0, CAST(N'2004-09-18T00:00:00.000' AS DateTime))
INSERT [dbo].[GIAOVIEN] ([MAGV], [MAQQ], [TenGV], [GioiTinh], [NgaySinh]) VALUES (N'GV13      ', N'H1        ', N'2', 1, CAST(N'2004-01-24T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS01      ', N'PY        ', N'CNTT      ', N'Mai Văn Tiền', 1, CAST(N'2004-09-15T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS02      ', N'HN        ', N'TMDT      ', N'Nguyễn Văn A', 1, CAST(N'2003-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS03      ', N'H1        ', N'KT        ', N'Hoàng Thị Hạnh', 0, CAST(N'2000-12-29T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS04      ', N'HN        ', N'LG        ', N'Nguyễn thị cẩm', 0, CAST(N'2002-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS05      ', N'PY        ', N'CNTT      ', N'Nguyễn thị Hoa', 0, CAST(N'2002-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS06      ', N'BD        ', N'KT        ', N'Hoàng Công Hậu', 1, CAST(N'2002-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS07      ', N'ND        ', N'LG        ', N'Nguyễn Thành Luân', 1, CAST(N'2002-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS08      ', N'BT        ', N'CNTT      ', N'Mai Ông Hoàng', 1, CAST(N'2002-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS09      ', N'CM        ', N'TMDT      ', N'Kai Oken Blue', 1, CAST(N'2002-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS10      ', N'NT02      ', N'LG        ', N'Nguyễn Hoàng Diệu', 0, CAST(N'2002-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS11      ', N'QN        ', N'LG        ', N'Nguyễn Thị Kim Tuyến', 0, CAST(N'2002-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS0121    ', N'BD        ', N'TMDT      ', N'Nguyễn Thị B', 0, CAST(N'2004-01-13T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS12      ', N'PY        ', N'CNTT      ', N'Mai Văn Tiền', 1, CAST(N'2004-09-15T00:00:00.000' AS DateTime))
INSERT [dbo].[HOCSINH] ([MAHS], [MAQQ], [MALOP], [TENHS], [GioiTinh], [NgaySinh]) VALUES (N'HS012     ', N'PY        ', N'CNTT      ', N'HS05', 1, CAST(N'2004-09-15T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'Web001    ', 2, 2, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS01      ', N'LN001     ', 8.5, 9.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS01      ', N'Win001    ', 10, 10, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS01      ', N'KT01      ', 10, 9.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS01      ', N'MLN001    ', 5.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS01      ', N'NML01     ', 9, 9, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS02      ', N'LN001     ', 3.5, 4.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS02      ', N'Win001    ', 5, 5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS02      ', N'KT01      ', 7.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS02      ', N'MLN001    ', 5.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS02      ', N'NML01     ', 2.5, 3.9, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS03      ', N'LN001     ', 8.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS03      ', N'Win001    ', 8.9, 8.2, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS03      ', N'KT01      ', 8.6, 9.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS03      ', N'MLN001    ', 5.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS03      ', N'NML01     ', 2.4, 8, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS04      ', N'LN001     ', 7.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS04      ', N'Win001    ', 2.8, 3.8, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS04      ', N'KT01      ', 8.3, 9.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS04      ', N'MLN001    ', 5.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS04      ', N'NML01     ', 7, 9, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'LN001     ', 3.5, 4.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'Win001    ', 5, 5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'KT01      ', 7.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'MLN001    ', 5.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'NML01     ', 2.5, 3.9, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'LN001     ', 8.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'Win001    ', 8.9, 8.2, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'KT01      ', 8.6, 9.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'MLN001    ', 5.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'NML01     ', 2.4, 8, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'LN001     ', 7.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'Win001    ', 2.8, 3.8, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'KT01      ', 8.3, 9.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'MLN001    ', 5.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'NML01     ', 7, 9, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'MLN002    ', 7.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'NMTC      ', 5.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'KT002     ', 6.5, 5.9, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'LKT001    ', 2.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS05      ', N'CLQL02    ', 3.9, 8.2, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'MLN002    ', 7.5, 5.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'NMTC      ', 5.5, 6.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'KT002     ', 2.5, 3.9, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'LKT001    ', 2.5, 2.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS06      ', N'CLQL02    ', 8.2, 7.2, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'MLN002    ', 7.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'NMTC      ', 5.5, 8.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'KT002     ', 2.5, 3.9, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'LKT001    ', 8.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS07      ', N'CLQL02    ', 1.9, 8.2, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS08      ', N'MLN002    ', 7.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS08      ', N'NMTC      ', 5.5, 2.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS08      ', N'KT002     ', 2.5, 3.9, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS08      ', N'LKT001    ', 5.5, 7.5, CAST(N'2024-06-02T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'234')
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS11      ', N'LKT001    ', 2.8, 3.9, NULL, NULL, NULL)
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS10      ', N'LN001     ', 2, 3, NULL, NULL, NULL)
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS03      ', N'Web001    ', 9, 10, NULL, NULL, NULL)
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS11      ', N'Web001    ', 9, 9, NULL, NULL, NULL)
INSERT [dbo].[HS_HOC_LOP] ([MAHS], [MAMH], [diemQT], [diemThi], [thoigianbatdau], [thoigianketthuc], [ngayhoc]) VALUES (N'HS02      ', N'Web001    ', 2, 2, NULL, NULL, NULL)
GO
INSERT [dbo].[LOP] ([MALOP], [TENLOP]) VALUES (N'KT        ', N'Kinh Tế')
INSERT [dbo].[LOP] ([MALOP], [TENLOP]) VALUES (N'CNTT      ', N'Công nghệ thông tin')
INSERT [dbo].[LOP] ([MALOP], [TENLOP]) VALUES (N'TMDT      ', N'Thương mai điện tử')
INSERT [dbo].[LOP] ([MALOP], [TENLOP]) VALUES (N'LG        ', N'Logistics')
GO
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'Web001    ', N'Nền tảng Web')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'Win001    ', N'Lập trình Win')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'KT01      ', N'Kinh tế vĩ mô')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'MLN001    ', N'Mác Lê Nin')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'NML01     ', N'Nhập môn lập trình')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'LN001     ', N'Hệ điều hành Linux')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'MLN002    ', N'Kinh tế chính trị')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'NMTC      ', N'Nhập môn tài chính tiền tệ')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'KT002     ', N'Kinh tế logistics')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'CLQL02    ', N'Chiến lược quản lý chuỗi cung ứng')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH]) VALUES (N'LKT001    ', N'Luật Kế Toán')
GO
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND01      ', N'maivantien', N'maivantien                                                                                          ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'2         ', N'1', N'2                                                                                                   ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND03      ', N'ND055', N'testing04                                                                                           ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'2st       ', N'1', N'3                                                                                                   ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND05      ', N'MaiVanTien', N'testing04                                                                                           ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND06      ', N'MaiHoangThanh', N'mi                                                                                                  ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND07      ', N'ND055', N'testing04                                                                                           ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND08      ', N'ND055', N'testing04                                                                                           ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'Hello     ', N'hello', N'hello                                                                                               ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND10      ', N'ND055', N'testing04                                                                                           ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'Kai       ', N'2', N'0                                                                                                   ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND182024  ', N'ND055', N'testing04                                                                                           ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND6182024 ', N'ND055', N'testing04                                                                                           ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'k         ', N'2', N'3                                                                                                   ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'mai       ', N'k2', N'2                                                                                                   ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'1530152024', N'mvt', N'mvt                                                                                                 ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'2249520247', N'admin', N'admin                                                                                               ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'8202920247', N'mai', N'mai                                                                                                 ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'1852820246', N'ND055', N'testing04                                                                                           ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'1852102024', N'ND055', N'testing04                                                                                           ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'8204620246', N'Total', N'total                                                                                               ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'ND13      ', N'any', N'any                                                                                                 ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'kai1      ', N'kai1', N'kai1                                                                                                ')
INSERT [dbo].[NGUOIDUNG] ([MAND], [TENND], [PASS]) VALUES (N'2216220241', N'ND055', N'testing04                                                                                           ')
GO
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'CLQL02    ', N'GV01      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'CLQL02    ', N'GV02      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'KT002     ', N'GV02      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'KT01      ', N'GV01      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'LKT001    ', N'GV01      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'LKT001    ', N'GV02      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'LN001     ', N'GV02      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'MLN001    ', N'GV01      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'MLN002    ', N'GV01      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'MLN002    ', N'GV02      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'NML01     ', N'GV03      ')
INSERT [dbo].[PHAN_CONG] ([MAMH], [MAGV]) VALUES (N'Web001    ', N'GV01      ')
GO
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'PY        ', N'Phú Yên')
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'HN        ', N'Hà Nội')
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'ND        ', N'Nam Định')
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'NT01      ', N'Ninh Thuận')
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'H1        ', N'Huế')
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'BD        ', N'Bình Định')
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'CM        ', N'Cà Mau')
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'NT02      ', N'Nha Trang')
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'BT        ', N'Bến Tre')
INSERT [dbo].[QUEQUAN] ([MAQQ], [TENQQ]) VALUES (N'QN        ', N'Quảng Nam')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_GIAOVIEN]    Script Date: 6/9/2024 9:53:16 AM ******/
ALTER TABLE [dbo].[GIAOVIEN] ADD  CONSTRAINT [PK_GIAOVIEN] PRIMARY KEY NONCLUSTERED 
(
	[MAGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [GV_THUOCQQ_FK]    Script Date: 6/9/2024 9:53:16 AM ******/
CREATE NONCLUSTERED INDEX [GV_THUOCQQ_FK] ON [dbo].[GIAOVIEN]
(
	[MAQQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_HOCSINH]    Script Date: 6/9/2024 9:53:16 AM ******/
ALTER TABLE [dbo].[HOCSINH] ADD  CONSTRAINT [PK_HOCSINH] PRIMARY KEY NONCLUSTERED 
(
	[MAHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [HS_THUOCLOP_FK]    Script Date: 6/9/2024 9:53:16 AM ******/
CREATE NONCLUSTERED INDEX [HS_THUOCLOP_FK] ON [dbo].[HOCSINH]
(
	[MALOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [HS_THUOCQQ_FK]    Script Date: 6/9/2024 9:53:16 AM ******/
CREATE NONCLUSTERED INDEX [HS_THUOCQQ_FK] ON [dbo].[HOCSINH]
(
	[MAQQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_HS_HOC_LOP]    Script Date: 6/9/2024 9:53:16 AM ******/
ALTER TABLE [dbo].[HS_HOC_LOP] ADD  CONSTRAINT [PK_HS_HOC_LOP] PRIMARY KEY NONCLUSTERED 
(
	[MAHS] ASC,
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [HS_HOC_LOP_FK]    Script Date: 6/9/2024 9:53:16 AM ******/
CREATE NONCLUSTERED INDEX [HS_HOC_LOP_FK] ON [dbo].[HS_HOC_LOP]
(
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [HS_HOC_LOP2_FK]    Script Date: 6/9/2024 9:53:16 AM ******/
CREATE NONCLUSTERED INDEX [HS_HOC_LOP2_FK] ON [dbo].[HS_HOC_LOP]
(
	[MAHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_LOP]    Script Date: 6/9/2024 9:53:16 AM ******/
ALTER TABLE [dbo].[LOP] ADD  CONSTRAINT [PK_LOP] PRIMARY KEY NONCLUSTERED 
(
	[MALOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_MONHOC]    Script Date: 6/9/2024 9:53:16 AM ******/
ALTER TABLE [dbo].[MONHOC] ADD  CONSTRAINT [PK_MONHOC] PRIMARY KEY NONCLUSTERED 
(
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_NGUOIDUNG]    Script Date: 6/9/2024 9:53:16 AM ******/
ALTER TABLE [dbo].[NGUOIDUNG] ADD  CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY NONCLUSTERED 
(
	[MAND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_PHAN_CONG]    Script Date: 6/9/2024 9:53:16 AM ******/
ALTER TABLE [dbo].[PHAN_CONG] ADD  CONSTRAINT [PK_PHAN_CONG] PRIMARY KEY NONCLUSTERED 
(
	[MAMH] ASC,
	[MAGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PHAN_CONG_FK]    Script Date: 6/9/2024 9:53:16 AM ******/
CREATE NONCLUSTERED INDEX [PHAN_CONG_FK] ON [dbo].[PHAN_CONG]
(
	[MAGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PHAN_CONG2_FK]    Script Date: 6/9/2024 9:53:16 AM ******/
CREATE NONCLUSTERED INDEX [PHAN_CONG2_FK] ON [dbo].[PHAN_CONG]
(
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_QUEQUAN]    Script Date: 6/9/2024 9:53:16 AM ******/
ALTER TABLE [dbo].[QUEQUAN] ADD  CONSTRAINT [PK_QUEQUAN] PRIMARY KEY NONCLUSTERED 
(
	[MAQQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GIAOVIEN]  WITH CHECK ADD  CONSTRAINT [FK_GIAOVIEN_GV_THUOCQ_QUEQUAN] FOREIGN KEY([MAQQ])
REFERENCES [dbo].[QUEQUAN] ([MAQQ])
GO
ALTER TABLE [dbo].[GIAOVIEN] CHECK CONSTRAINT [FK_GIAOVIEN_GV_THUOCQ_QUEQUAN]
GO
ALTER TABLE [dbo].[HOCSINH]  WITH CHECK ADD  CONSTRAINT [FK_HOCSINH_HS_THUOCL_LOP] FOREIGN KEY([MALOP])
REFERENCES [dbo].[LOP] ([MALOP])
GO
ALTER TABLE [dbo].[HOCSINH] CHECK CONSTRAINT [FK_HOCSINH_HS_THUOCL_LOP]
GO
ALTER TABLE [dbo].[HOCSINH]  WITH CHECK ADD  CONSTRAINT [FK_HOCSINH_HS_THUOCQ_QUEQUAN] FOREIGN KEY([MAQQ])
REFERENCES [dbo].[QUEQUAN] ([MAQQ])
GO
ALTER TABLE [dbo].[HOCSINH] CHECK CONSTRAINT [FK_HOCSINH_HS_THUOCQ_QUEQUAN]
GO
ALTER TABLE [dbo].[HS_HOC_LOP]  WITH CHECK ADD  CONSTRAINT [FK_HS_HOC_L_HS_HOC_LO_HOCSINH] FOREIGN KEY([MAHS])
REFERENCES [dbo].[HOCSINH] ([MAHS])
GO
ALTER TABLE [dbo].[HS_HOC_LOP] CHECK CONSTRAINT [FK_HS_HOC_L_HS_HOC_LO_HOCSINH]
GO
ALTER TABLE [dbo].[HS_HOC_LOP]  WITH CHECK ADD  CONSTRAINT [FK_HS_HOC_L_HS_HOC_LO_MONHOC] FOREIGN KEY([MAMH])
REFERENCES [dbo].[MONHOC] ([MAMH])
GO
ALTER TABLE [dbo].[HS_HOC_LOP] CHECK CONSTRAINT [FK_HS_HOC_L_HS_HOC_LO_MONHOC]
GO
ALTER TABLE [dbo].[PHAN_CONG]  WITH CHECK ADD  CONSTRAINT [FK_PHAN_CON_PHAN_CONG_GIAOVIEN] FOREIGN KEY([MAGV])
REFERENCES [dbo].[GIAOVIEN] ([MAGV])
GO
ALTER TABLE [dbo].[PHAN_CONG] CHECK CONSTRAINT [FK_PHAN_CON_PHAN_CONG_GIAOVIEN]
GO
ALTER TABLE [dbo].[PHAN_CONG]  WITH CHECK ADD  CONSTRAINT [FK_PHAN_CON_PHAN_CONG_MONHOC] FOREIGN KEY([MAMH])
REFERENCES [dbo].[MONHOC] ([MAMH])
GO
ALTER TABLE [dbo].[PHAN_CONG] CHECK CONSTRAINT [FK_PHAN_CON_PHAN_CONG_MONHOC]
GO
USE [master]
GO
ALTER DATABASE [qlsinhvien] SET  READ_WRITE 
GO
