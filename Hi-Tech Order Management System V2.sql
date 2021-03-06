USE [master]
GO
/****** Object:  Database [HiTechDistributionDB]    Script Date: 2019-04-27 9:36:46 AM ******/
CREATE DATABASE [HiTechDistributionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HiTechDistributionDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\HiTechDistributionDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HiTechDistributionDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\HiTechDistributionDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HiTechDistributionDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HiTechDistributionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HiTechDistributionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HiTechDistributionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HiTechDistributionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HiTechDistributionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HiTechDistributionDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HiTechDistributionDB] SET  MULTI_USER 
GO
ALTER DATABASE [HiTechDistributionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HiTechDistributionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HiTechDistributionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HiTechDistributionDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HiTechDistributionDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HiTechDistributionDB', N'ON'
GO
ALTER DATABASE [HiTechDistributionDB] SET QUERY_STORE = OFF
GO
USE [HiTechDistributionDB]
GO
/****** Object:  Table [dbo].[AProducts]    Script Date: 2019-04-27 9:36:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AProducts](
	[ISBN] [nvarchar](30) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_Author_products] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC,
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 2019-04-27 9:36:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Atuhors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2019-04-27 9:36:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2019-04-27 9:36:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StreetNo] [int] NOT NULL,
	[StreetName] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](30) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[FaxNumber] [nvarchar](20) NULL,
	[Credit] [float] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2019-04-27 9:36:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[JobTitle] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_lines]    Script Date: 2019-04-27 9:36:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_lines](
	[OrderId] [int] NOT NULL,
	[ISBN] [nvarchar](30) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[OrderQuantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[SubTotal] [float] NOT NULL,
 CONSTRAINT [PK_Order_lines] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2019-04-27 9:36:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[OrderBy] [nvarchar](20) NOT NULL,
	[TotalPrice] [float] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2019-04-27 9:36:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ISBN] [nvarchar](30) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[YearPublished] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[SuppliedId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 2019-04-27 9:36:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [int] NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2019-04-27 9:36:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[EmployeeId] [int] NOT NULL,
	[UserName] [nvarchar](10) NOT NULL,
	[JobTitle] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AProducts] ([ISBN], [AuthorId], [Date]) VALUES (N'1111111111111', 100, NULL)
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email]) VALUES (100, N'Edgar', N'Poe', N'edgar@gmail.com')
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email]) VALUES (101, N'Machado', N'de Assis', N'machado@gmail.com')
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email]) VALUES (102, N'Willian', N'Shakespeare', N'unknown')
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email]) VALUES (103, N'Charles', N'Dickens', N'unknown')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (10, N'Programming')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (11, N'Event Programming')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (12, N'Database')
INSERT [dbo].[Customers] ([CustomerId], [Name], [StreetNo], [StreetName], [PostalCode], [City], [PhoneNumber], [FaxNumber], [Credit]) VALUES (1, N'College LaSalle', 23, N'Catherine', N'H7Y6T7', N'Quebec', N'(222) 222-2222', N'(222) 222-2222', 8983)
INSERT [dbo].[Customers] ([CustomerId], [Name], [StreetNo], [StreetName], [PostalCode], [City], [PhoneNumber], [FaxNumber], [Credit]) VALUES (2, N'University Montreal', 456, N'Wellington', N'G7Y 5T6', N'Manitoba', N'4444444444', N'4444444444', 99036)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle], [PhoneNumber], [Email]) VALUES (1000, N'Henry', N'Brown', N'MIS Manager', N'(514) 111-1111', N'henry@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle], [PhoneNumber], [Email]) VALUES (1001, N'Mary', N'Brown', N'Clerk', N'(514) 222-2222', N'mary@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle], [PhoneNumber], [Email]) VALUES (1002, N'Jennifer', N'Bouchard', N'Clerk', N'(514) 333-3333', N'jennifer@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle], [PhoneNumber], [Email]) VALUES (1003, N'Thomas', N'Moore', N'Sales Manager', N'(514) 444-4444', N'thomar@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle], [PhoneNumber], [Email]) VALUES (1004, N'Kim ', N'Hoa Nguyen', N'Accountant', N'(514) 555-5555', N'kim@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle], [PhoneNumber], [Email]) VALUES (1005, N'Peter', N'Wang', N'Inventory Controller', N'(514) 666-6666', N'peter@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [JobTitle], [PhoneNumber], [Email]) VALUES (1006, N'Quang ', N'Hoang Cao', N'God', N'(514) 777-7777', N'cao@gmail.com')
INSERT [dbo].[Order_lines] ([OrderId], [ISBN], [Title], [OrderQuantity], [Price], [SubTotal]) VALUES (1000, N'1111111111111', N'poe', 10, 19.99, 199.9)
INSERT [dbo].[Orders] ([OrderId], [EmployeeId], [CustomerId], [OrderDate], [OrderBy], [TotalPrice]) VALUES (1000, 1001, 1, CAST(N'2019-04-15' AS Date), N'Fax', 199.9)
INSERT [dbo].[Products] ([ISBN], [Title], [CategoryId], [Price], [YearPublished], [Quantity], [SuppliedId]) VALUES (N'1111111111111', N'100 Percentage', 12, 19.99, 1991, 430, 10)
INSERT [dbo].[Products] ([ISBN], [Title], [CategoryId], [Price], [YearPublished], [Quantity], [SuppliedId]) VALUES (N'2222222222222', N'Programming in C#', 10, 25.99, 1980, 300, 11)
INSERT [dbo].[Suppliers] ([SupplierId], [Name]) VALUES (10, N'Premier Press')
INSERT [dbo].[Suppliers] ([SupplierId], [Name]) VALUES (11, N'Wrox')
INSERT [dbo].[Suppliers] ([SupplierId], [Name]) VALUES (12, N'Murach')
INSERT [dbo].[Users] ([EmployeeId], [UserName], [JobTitle], [Password]) VALUES (1000, N'heBrown', N'MIS Manager', N'1111111')
INSERT [dbo].[Users] ([EmployeeId], [UserName], [JobTitle], [Password]) VALUES (1001, N'maBrown', N'Clerk', N'2222222')
INSERT [dbo].[Users] ([EmployeeId], [UserName], [JobTitle], [Password]) VALUES (1002, N'jeBroch', N'Clerk', N'3333333')
INSERT [dbo].[Users] ([EmployeeId], [UserName], [JobTitle], [Password]) VALUES (1003, N'thMoore', N'Sales Manager', N'4444444')
INSERT [dbo].[Users] ([EmployeeId], [UserName], [JobTitle], [Password]) VALUES (1004, N'kNguyen', N'Accountant', N'5555555')
INSERT [dbo].[Users] ([EmployeeId], [UserName], [JobTitle], [Password]) VALUES (1005, N'petWang', N'Inventory Controller', N'6666666')
INSERT [dbo].[Users] ([EmployeeId], [UserName], [JobTitle], [Password]) VALUES (1006, N'caoHang', N'God', N'0000000')
ALTER TABLE [dbo].[AProducts]  WITH CHECK ADD  CONSTRAINT [FK_AProducts_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[AProducts] CHECK CONSTRAINT [FK_AProducts_Authors]
GO
ALTER TABLE [dbo].[AProducts]  WITH CHECK ADD  CONSTRAINT [FK_AProducts_Products] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Products] ([ISBN])
GO
ALTER TABLE [dbo].[AProducts] CHECK CONSTRAINT [FK_AProducts_Products]
GO
ALTER TABLE [dbo].[Order_lines]  WITH CHECK ADD  CONSTRAINT [FK_Order_lines_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[Order_lines] CHECK CONSTRAINT [FK_Order_lines_Orders]
GO
ALTER TABLE [dbo].[Order_lines]  WITH CHECK ADD  CONSTRAINT [FK_Order_lines_Products] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Products] ([ISBN])
GO
ALTER TABLE [dbo].[Order_lines] CHECK CONSTRAINT [FK_Order_lines_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employees]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SuppliedId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Employees]
GO
USE [master]
GO
ALTER DATABASE [HiTechDistributionDB] SET  READ_WRITE 
GO
