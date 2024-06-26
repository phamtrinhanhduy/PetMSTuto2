CREATE DATABASE [PetShopDb]
USE [PetShopDb]
GO
/****** Object:  Table [dbo].[BillTbl]    Script Date: 5/22/2024 7:37:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillTbl](
	[BNum] [int] IDENTITY(1,1) NOT NULL,
	[BDate] [date] NOT NULL,
	[CustId] [int] NOT NULL,
	[CustName] [nvarchar](50) NOT NULL,
	[Amt] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerTbl]    Script Date: 5/22/2024 7:37:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerTbl](
	[CustId] [int] IDENTITY(1,1) NOT NULL,
	[CustName] [nvarchar](50) NOT NULL,
	[CustAdd] [nvarchar](100) NOT NULL,
	[CustPhone] [nvarchar](20) NOT NULL,
	[CustType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CustormerTbl] PRIMARY KEY CLUSTERED 
(
	[CustId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTbl]    Script Date: 5/22/2024 7:37:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTbl](
	[EmpNum] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [nvarchar](50) NOT NULL,
	[EmpAdd] [nvarchar](100) NOT NULL,
	[EmpDOB] [date] NOT NULL,
	[EmpPhone] [nvarchar](50) NOT NULL,
	[EmpAcc] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmployeeTbl] PRIMARY KEY CLUSTERED 
(
	[EmpNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceTbl]    Script Date: 5/22/2024 7:37:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceTbl](
	[INum] [int] IDENTITY(1,1) NOT NULL,
	[PrName] [nvarchar](50) NOT NULL,
	[PrQty] [int] NOT NULL,
	[PrPrice] [int] NOT NULL,
	[Tamt] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[INum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTbl]    Script Date: 5/22/2024 7:37:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTbl](
	[PrId] [int] IDENTITY(1,1) NOT NULL,
	[PrName] [nvarchar](50) NOT NULL,
	[PrCat] [nvarchar](20) NOT NULL,
	[PrQty] [int] NOT NULL,
	[PrPrice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTbl]    Script Date: 5/22/2024 7:37:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTbl](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserAcc] [varchar](50) NOT NULL,
	[UserPass] [varchar](20) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPhone] [varchar](50) NOT NULL,
	[UserDOB] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BillTbl] ON 

INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (1, CAST(N'2024-02-11' AS Date), 1, N'Phạm Anh Tú', 9500000)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (2, CAST(N'2024-02-13' AS Date), 3, N'Hàn Tấn Phát', 783750)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (3, CAST(N'2024-02-15' AS Date), 2, N'Lưu Vân Tá', 8740000)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (4, CAST(N'2024-02-23' AS Date), 14, N'Trần Tú Linh', 2280000)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (5, CAST(N'2024-02-27' AS Date), 5, N'Phan Mạnh Dũng', 1178000)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (6, CAST(N'2024-03-19' AS Date), 11, N'Hoàng Trọng Nghĩa', 2299000)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (7, CAST(N'2024-03-21' AS Date), 12, N'Trần Tú Anh', 20282500)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (8, CAST(N'2024-03-25' AS Date), 5, N'Phan Mạnh Dũng', 3586250)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (9, CAST(N'2024-03-28' AS Date), 6, N'Lâm Chí Thành', 6650000)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (10, CAST(N'2024-04-16' AS Date), 14, N'Trần Tú Linh', 6650000)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (11, CAST(N'2024-04-17' AS Date), 9, N'Hoàng Văn Hậu', 707750)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (12, CAST(N'2024-04-19' AS Date), 5, N'Phan Mạnh Dũng', 234600)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (13, CAST(N'2024-04-21' AS Date), 9, N'Hoàng Văn Hậu', 2123250)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (14, CAST(N'2024-04-25' AS Date), 5, N'Phan Mạnh Dũng', 2760000)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (15, CAST(N'2024-04-30' AS Date), 6, N'Lâm Chí Thành', 411240)
INSERT [dbo].[BillTbl] ([BNum], [BDate], [CustId], [CustName], [Amt]) VALUES (16, CAST(N'2024-05-20' AS Date), 6, N'Lâm Chí Thành', 10814600)
SET IDENTITY_INSERT [dbo].[BillTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerTbl] ON 

INSERT [dbo].[CustomerTbl] ([CustId], [CustName], [CustAdd], [CustPhone], [CustType]) VALUES (1, N'Phạm Anh Tú', N'TP.HCM, Phường 7, Quận 8', N'0938987165', N'Vàng')
INSERT [dbo].[CustomerTbl] ([CustId], [CustName], [CustAdd], [CustPhone], [CustType]) VALUES (2, N'Lưu Vân Tá', N'TP.HCM, 280 An Dương Vương, Quận 5', N'0988825542', N'Vàng')
INSERT [dbo].[CustomerTbl] ([CustId], [CustName], [CustAdd], [CustPhone], [CustType]) VALUES (3, N'Hàn Tấn Phát', N'TP Thủ Đức, Phường Trường Thọ', N'0377921954', N'Đồng')
INSERT [dbo].[CustomerTbl] ([CustId], [CustName], [CustAdd], [CustPhone], [CustType]) VALUES (5, N'Phan Mạnh Dũng', N'TP.HCM, đường Nguyễn Hữu Thọ, Quận 7', N'0909221975', N'Bạc')
INSERT [dbo].[CustomerTbl] ([CustId], [CustName], [CustAdd], [CustPhone], [CustType]) VALUES (6, N'Lâm Chí Thành', N'TP.HCM, Phường 5, Quận 12', N'0929311782', N'Kim Cương')
INSERT [dbo].[CustomerTbl] ([CustId], [CustName], [CustAdd], [CustPhone], [CustType]) VALUES (9, N'Hoàng Văn Hậu', N'TP. HCM, đường Điện Biên Phủ, Quận 3', N'0722895476', N'Đồng')
INSERT [dbo].[CustomerTbl] ([CustId], [CustName], [CustAdd], [CustPhone], [CustType]) VALUES (11, N'Hoàng Trọng Nghĩa', N'TP. HCM, Phường 6, Quận 3', N'0990277822', N'Đồng')
INSERT [dbo].[CustomerTbl] ([CustId], [CustName], [CustAdd], [CustPhone], [CustType]) VALUES (12, N'Trần Tú Anh', N'TP. Thủ Đức, Phường An Phú', N'0529209012', N'Kim Cương')
INSERT [dbo].[CustomerTbl] ([CustId], [CustName], [CustAdd], [CustPhone], [CustType]) VALUES (14, N'Trần Tú Linh', N'TP. Thủ Đức, Phường Linh Trung', N'0388082903', N'Vàng')
SET IDENTITY_INSERT [dbo].[CustomerTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeTbl] ON 

INSERT [dbo].[EmployeeTbl] ([EmpNum], [EmpName], [EmpAdd], [EmpDOB], [EmpPhone], [EmpAcc]) VALUES (1, N'Phạm Trịnh Duy Anh', N'TP Thủ Đức', CAST(N'2004-05-04' AS Date), N'0902892102', N'Đã Cấp')
INSERT [dbo].[EmployeeTbl] ([EmpNum], [EmpName], [EmpAdd], [EmpDOB], [EmpPhone], [EmpAcc]) VALUES (8, N'Hoàng Văn Kẹo', N'Tỉnh Long An', CAST(N'1999-02-02' AS Date), N'0902187298', N'Chưa Cấp')
INSERT [dbo].[EmployeeTbl] ([EmpNum], [EmpName], [EmpAdd], [EmpDOB], [EmpPhone], [EmpAcc]) VALUES (10, N'Lưu Thị Tâm', N'TP.HCM', CAST(N'2000-02-01' AS Date), N'0389212023', N'Chưa Cấp')
INSERT [dbo].[EmployeeTbl] ([EmpNum], [EmpName], [EmpAdd], [EmpDOB], [EmpPhone], [EmpAcc]) VALUES (11, N'Phan Trần Thúy Đan', N'TP.HCM', CAST(N'2002-05-24' AS Date), N'0937821103', N'Đã Cấp')
INSERT [dbo].[EmployeeTbl] ([EmpNum], [EmpName], [EmpAdd], [EmpDOB], [EmpPhone], [EmpAcc]) VALUES (12, N'Nguyễn Minh Anh', N'TP Thủ Đức', CAST(N'2004-04-06' AS Date), N'0731892913', N'Đã Cấp')
INSERT [dbo].[EmployeeTbl] ([EmpNum], [EmpName], [EmpAdd], [EmpDOB], [EmpPhone], [EmpAcc]) VALUES (15, N'Lý Thị Mây', N'TP Thủ Đức', CAST(N'2004-04-06' AS Date), N'0909931762', N'Chưa Cấp')
INSERT [dbo].[EmployeeTbl] ([EmpNum], [EmpName], [EmpAdd], [EmpDOB], [EmpPhone], [EmpAcc]) VALUES (19, N'Nguyễn Văn Tấn', N'TP. Đồng Nai', CAST(N'2005-06-10' AS Date), N'0377929056', N'Chưa Cấp')
SET IDENTITY_INSERT [dbo].[EmployeeTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTbl] ON 

INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (6, N'Chó Corgi', N'Chó', 5, 8000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (14, N'Mèo Muớp', N'Mèo', 5, 300000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (17, N'Vòng Cổ', N'Phụ Kiện', 25, 85000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (18, N'Hộp Cát Vệ Sinh', N'Phụ Kiện', 25, 55000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (19, N'Chó Husky', N'Chó', 4, 10000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (20, N'Chim Vàng Anh', N'Chim', 7, 500000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (22, N'Chim Sơn Ca', N'Chim', 8, 1000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (23, N'Royal Canin', N'Thức Ăn', 50, 230000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (24, N'Chó Phú Quốc', N'Chó', 3, 3000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (26, N'Smartheart', N'Thức Ăn', 50, 121000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (27, N'Yếm Chó Mèo', N'Phụ Kiện', 29, 255000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (28, N'Mũ Chó Mèo', N'Phụ Kiện', 20, 155000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (29, N'Lồng Chim', N'Phụ Kiện', 20, 135000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (30, N'Chuồng Đa Năng', N'Phụ Kiện', 27, 149000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (31, N'Mèo Tam Thể', N'Mèo', 8, 1000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (32, N'Chó Shiba', N'Chó', 3, 20000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (33, N'Chó Poodle', N'Chó', 5, 7000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (34, N'Chó Pug', N'Chó', 3, 7000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (35, N'Mèo Vàng', N'Mèo', 5, 200000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (36, N'Mèo Bengal', N'Mèo', 3, 7000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (38, N'Mèo Chân Ngắn', N'Mèo', 10, 15000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (39, N'Chó Dachshund', N'Chó', 3, 12000000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (40, N'Thỏ Sư Tử', N'Thỏ', 3, 800000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (41, N'Hạt Whiskas', N'Thức Ăn', 10, 115000)
INSERT [dbo].[ProductTbl] ([PrId], [PrName], [PrCat], [PrQty], [PrPrice]) VALUES (47, N'Mèo Ragdoll', N'Mèo', 5, 6000000)
SET IDENTITY_INSERT [dbo].[ProductTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTbl] ON 

INSERT [dbo].[UserTbl] ([UserID], [UserAcc], [UserPass], [UserType], [UserName], [UserPhone], [UserDOB]) VALUES (1, N'Admin1', N'111111', N'Admin', N'Phạm Trịnh Anh Duy', N'0982120902', CAST(N'1999-02-02' AS Date))
INSERT [dbo].[UserTbl] ([UserID], [UserAcc], [UserPass], [UserType], [UserName], [UserPhone], [UserDOB]) VALUES (8, N'User1', N'111111', N'Nhân Viên', N'Phạm Trịnh Duy Anh', N'0902892102', CAST(N'2004-05-04' AS Date))
INSERT [dbo].[UserTbl] ([UserID], [UserAcc], [UserPass], [UserType], [UserName], [UserPhone], [UserDOB]) VALUES (12, N'User2', N'111111', N'Nhân Viên', N'Phan Trần Thúy Đan', N'0937821103', CAST(N'2002-05-24' AS Date))
INSERT [dbo].[UserTbl] ([UserID], [UserAcc], [UserPass], [UserType], [UserName], [UserPhone], [UserDOB]) VALUES (15, N'User5', N'111111', N'Nhân Viên', N'Nguyễn Minh Anh', N'0731892913', CAST(N'2004-04-06' AS Date))
SET IDENTITY_INSERT [dbo].[UserTbl] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_PrName_ProductTbl]    Script Date: 5/22/2024 7:37:49 AM ******/
ALTER TABLE [dbo].[ProductTbl] ADD  CONSTRAINT [UK_PrName_ProductTbl] UNIQUE NONCLUSTERED 
(
	[PrName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BillTbl]  WITH CHECK ADD  CONSTRAINT [FK_BillTbl_CustomerTbl] FOREIGN KEY([CustId])
REFERENCES [dbo].[CustomerTbl] ([CustId])
GO
ALTER TABLE [dbo].[BillTbl] CHECK CONSTRAINT [FK_BillTbl_CustomerTbl]
GO
ALTER TABLE [dbo].[InvoiceTbl]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceTbl_ProductTbl] FOREIGN KEY([PrName])
REFERENCES [dbo].[ProductTbl] ([PrName])
GO
ALTER TABLE [dbo].[InvoiceTbl] CHECK CONSTRAINT [FK_InvoiceTbl_ProductTbl]
GO
