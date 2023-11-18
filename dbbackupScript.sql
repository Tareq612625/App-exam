USE [master]
GO
/****** Object:  Database [EXAM01]    Script Date: 18/11/2023 16:40:32 ******/
CREATE DATABASE [EXAM01]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EXAM01', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SA\MSSQL\DATA\EXAM01.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EXAM01_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SA\MSSQL\DATA\EXAM01_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EXAM01] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EXAM01].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EXAM01] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EXAM01] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EXAM01] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EXAM01] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EXAM01] SET ARITHABORT OFF 
GO
ALTER DATABASE [EXAM01] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EXAM01] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EXAM01] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EXAM01] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EXAM01] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EXAM01] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EXAM01] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EXAM01] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EXAM01] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EXAM01] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EXAM01] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EXAM01] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EXAM01] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EXAM01] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EXAM01] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EXAM01] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EXAM01] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EXAM01] SET RECOVERY FULL 
GO
ALTER DATABASE [EXAM01] SET  MULTI_USER 
GO
ALTER DATABASE [EXAM01] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EXAM01] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EXAM01] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EXAM01] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EXAM01] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EXAM01] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EXAM01', N'ON'
GO
ALTER DATABASE [EXAM01] SET QUERY_STORE = ON
GO
ALTER DATABASE [EXAM01] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EXAM01]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/11/2023 16:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuyerMaster]    Script Date: 18/11/2023 16:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyerMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuyerCode] [nvarchar](max) NOT NULL,
	[BuyerName] [nvarchar](100) NOT NULL,
	[SingleDevice] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CreateUser] [nvarchar](100) NULL,
	[CreateDevice] [nvarchar](100) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateDevice] [nvarchar](100) NULL,
 CONSTRAINT [PK_BuyerMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerLocation]    Script Date: 18/11/2023 16:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerLocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CustomerShipLocation] [nvarchar](100) NOT NULL,
	[SingleDevice] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CreateUser] [nvarchar](100) NULL,
	[CreateDevice] [nvarchar](100) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateDevice] [nvarchar](100) NULL,
 CONSTRAINT [PK_CustomerLocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerMaster]    Script Date: 18/11/2023 16:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [nvarchar](max) NOT NULL,
	[CustomerName] [nvarchar](100) NOT NULL,
	[CustomerDetails] [nvarchar](500) NULL,
	[SingleDevice] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CreateUser] [nvarchar](100) NULL,
	[CreateDevice] [nvarchar](100) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateDevice] [nvarchar](100) NULL,
 CONSTRAINT [PK_CustomerMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PIDetails]    Script Date: 18/11/2023 16:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PIDetails](
	[PIDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[PIMasterCode] [nvarchar](max) NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[OrderQty] [int] NOT NULL,
	[ExpShipmentDate] [datetime2](7) NULL,
	[PIMasterId] [int] NULL,
	[SingleDevice] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CreateUser] [nvarchar](100) NULL,
	[CreateDevice] [nvarchar](100) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateDevice] [nvarchar](100) NULL,
 CONSTRAINT [PK_PIDetails] PRIMARY KEY CLUSTERED 
(
	[PIDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PIMaster]    Script Date: 18/11/2023 16:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PIMaster](
	[PIMasterId] [int] IDENTITY(1,1) NOT NULL,
	[PICode] [nvarchar](max) NULL,
	[CustomerId] [int] NOT NULL,
	[ShipToId] [int] NOT NULL,
	[BuyerId] [int] NOT NULL,
	[Dyecond] [nvarchar](100) NOT NULL,
	[OrderType] [nvarchar](100) NOT NULL,
	[TrackingNumber] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[OrderNo] [int] NOT NULL,
	[CustomerPO] [nvarchar](30) NOT NULL,
	[SingleDevice] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CreateUser] [nvarchar](100) NULL,
	[CreateDevice] [nvarchar](100) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateDevice] [nvarchar](100) NULL,
 CONSTRAINT [PK_PIMaster] PRIMARY KEY CLUSTERED 
(
	[PIMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductMaster]    Script Date: 18/11/2023 16:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](max) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[ProductDetails] [nvarchar](100) NULL,
	[Unit] [nvarchar](20) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[SingleDevice] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CreateUser] [nvarchar](100) NULL,
	[CreateDevice] [nvarchar](100) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateDevice] [nvarchar](100) NULL,
 CONSTRAINT [PK_ProductMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 18/11/2023 16:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [nvarchar](20) NOT NULL,
	[UserPassword] [nvarchar](200) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Designation] [nvarchar](50) NOT NULL,
	[DepartmentId] [nvarchar](max) NOT NULL,
	[Mobile] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231118081240_init', N'7.0.7')
GO
SET IDENTITY_INSERT [dbo].[BuyerMaster] ON 
GO
INSERT [dbo].[BuyerMaster] ([Id], [BuyerCode], [BuyerName], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (1, N'BU-001', N'ANANTA', NULL, NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[BuyerMaster] ([Id], [BuyerCode], [BuyerName], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (2, N'BU-002', N'Test', NULL, NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[BuyerMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerLocation] ON 
GO
INSERT [dbo].[CustomerLocation] ([Id], [CustomerId], [CustomerShipLocation], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (1, 1, N'UK North', N'1', NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CustomerLocation] ([Id], [CustomerId], [CustomerShipLocation], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (2, 1, N'UK South', N'2', NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CustomerLocation] ([Id], [CustomerId], [CustomerShipLocation], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (3, 2, N'USA North', NULL, NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CustomerLocation] ([Id], [CustomerId], [CustomerShipLocation], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (4, 2, N'USA South', NULL, NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CustomerLocation] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerMaster] ON 
GO
INSERT [dbo].[CustomerMaster] ([Id], [CustomerCode], [CustomerName], [CustomerDetails], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (1, N'C-001', N'ABC', N'UK', NULL, NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CustomerMaster] ([Id], [CustomerCode], [CustomerName], [CustomerDetails], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (2, N'C-002', N'XYZ', N'USA', NULL, NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CustomerMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[PIDetails] ON 
GO
INSERT [dbo].[PIDetails] ([PIDetailsId], [PIMasterCode], [ProductId], [UnitPrice], [OrderQty], [ExpShipmentDate], [PIMasterId], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (1, N'2023-11-0002', 3, CAST(100.00 AS Decimal(18, 2)), 3, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), 2, N'N', 1, CAST(N'2023-11-18T15:47:23.5781757' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL', CAST(N'2023-11-18T15:47:23.5781758' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL')
GO
INSERT [dbo].[PIDetails] ([PIDetailsId], [PIMasterCode], [ProductId], [UnitPrice], [OrderQty], [ExpShipmentDate], [PIMasterId], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (2, N'2023-11-0002', 3, CAST(100.00 AS Decimal(18, 2)), 222, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), 3, N'N', 1, CAST(N'2023-11-18T16:29:46.2782300' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL', CAST(N'2023-11-18T16:29:46.2782301' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL')
GO
INSERT [dbo].[PIDetails] ([PIDetailsId], [PIMasterCode], [ProductId], [UnitPrice], [OrderQty], [ExpShipmentDate], [PIMasterId], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (3, N'2023-11-0003', 3, CAST(100.00 AS Decimal(18, 2)), 3, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), 4, N'N', 1, CAST(N'2023-11-18T16:32:06.1281972' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL', CAST(N'2023-11-18T16:32:06.1281972' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL')
GO
INSERT [dbo].[PIDetails] ([PIDetailsId], [PIMasterCode], [ProductId], [UnitPrice], [OrderQty], [ExpShipmentDate], [PIMasterId], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (4, N'2023-11-0004', 3, CAST(100.00 AS Decimal(18, 2)), 2, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), 5, N'N', 1, CAST(N'2023-11-18T16:32:43.9716178' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL', CAST(N'2023-11-18T16:32:43.9716178' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL')
GO
INSERT [dbo].[PIDetails] ([PIDetailsId], [PIMasterCode], [ProductId], [UnitPrice], [OrderQty], [ExpShipmentDate], [PIMasterId], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (5, N'2023-11-0004', 5, CAST(120.00 AS Decimal(18, 2)), 2, CAST(N'2023-11-15T00:00:00.0000000' AS DateTime2), 5, N'N', 1, CAST(N'2023-11-18T16:32:43.9722566' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL', CAST(N'2023-11-18T16:32:43.9722566' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL')
GO
SET IDENTITY_INSERT [dbo].[PIDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[PIMaster] ON 
GO
INSERT [dbo].[PIMaster] ([PIMasterId], [PICode], [CustomerId], [ShipToId], [BuyerId], [Dyecond], [OrderType], [TrackingNumber], [Description], [OrderNo], [CustomerPO], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (2, N'2023-11-0002', 2, 3, 1, N'sdf', N'asdf', N'sdf', N'sf', 234234, N'sdf', N'N', 1, CAST(N'2023-11-18T15:47:23.5739504' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL', CAST(N'2023-11-18T15:47:23.5739505' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL')
GO
INSERT [dbo].[PIMaster] ([PIMasterId], [PICode], [CustomerId], [ShipToId], [BuyerId], [Dyecond], [OrderType], [TrackingNumber], [Description], [OrderNo], [CustomerPO], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (3, N'2023-11-0002', 2, 3, 2, N'sdasdasd', N'dfsdfsd', N'sdfsdf', N'sdfsdfds', 1232323, N'fsdf', N'N', 1, CAST(N'2023-11-18T16:29:46.2741238' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL', CAST(N'2023-11-18T16:29:46.2741238' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL')
GO
INSERT [dbo].[PIMaster] ([PIMasterId], [PICode], [CustomerId], [ShipToId], [BuyerId], [Dyecond], [OrderType], [TrackingNumber], [Description], [OrderNo], [CustomerPO], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (4, N'2023-11-0003', 2, 3, 2, N'sdf', N'sdf', N'sdf', N'asdf', 2, N'sdf', N'N', 1, CAST(N'2023-11-18T16:32:06.1220149' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL', CAST(N'2023-11-18T16:32:06.1220149' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL')
GO
INSERT [dbo].[PIMaster] ([PIMasterId], [PICode], [CustomerId], [ShipToId], [BuyerId], [Dyecond], [OrderType], [TrackingNumber], [Description], [OrderNo], [CustomerPO], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (5, N'2023-11-0004', 1, 1, 1, N'sadf', N'asdf', N'asdf', N'asdf', 2342, N'sdfas', N'N', 1, CAST(N'2023-11-18T16:32:43.9709635' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL', CAST(N'2023-11-18T16:32:43.9709635' AS DateTime2), N'tareq.aziz', N'DESKTOP-B40OJHL')
GO
SET IDENTITY_INSERT [dbo].[PIMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductMaster] ON 
GO
INSERT [dbo].[ProductMaster] ([Id], [ProductCode], [ProductName], [ProductDetails], [Unit], [UnitPrice], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (3, N'P-001', N'AEBLK-5001', N'Perma Spun Color000678', N'Lt', CAST(100.00 AS Decimal(18, 2)), NULL, NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ProductMaster] ([Id], [ProductCode], [ProductName], [ProductDetails], [Unit], [UnitPrice], [SingleDevice], [IsActive], [CreateDate], [CreateUser], [CreateDevice], [UpdateDate], [UpdateUser], [UpdateDevice]) VALUES (5, N'P-001', N'AEWHT-001677', N'D Core White 56789', N'Lt', CAST(120.00 AS Decimal(18, 2)), NULL, NULL, CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ProductMaster] OFF
GO
INSERT [dbo].[User] ([UserId], [UserPassword], [UserName], [Designation], [DepartmentId], [Mobile], [Email]) VALUES (N'tareq', N'123', N'tareq', N'as', N'a', N'01858612625', N'mdazizkhn@gmailc.om')
GO
/****** Object:  Index [IX_PIDetails_PIMasterId]    Script Date: 18/11/2023 16:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_PIDetails_PIMasterId] ON [dbo].[PIDetails]
(
	[PIMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PIDetails_ProductId]    Script Date: 18/11/2023 16:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_PIDetails_ProductId] ON [dbo].[PIDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PIMaster_BuyerId]    Script Date: 18/11/2023 16:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_PIMaster_BuyerId] ON [dbo].[PIMaster]
(
	[BuyerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PIMaster_CustomerId]    Script Date: 18/11/2023 16:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_PIMaster_CustomerId] ON [dbo].[PIMaster]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PIMaster_ShipToId]    Script Date: 18/11/2023 16:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_PIMaster_ShipToId] ON [dbo].[PIMaster]
(
	[ShipToId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PIDetails]  WITH CHECK ADD  CONSTRAINT [FK_PIDetails_PIMaster_PIMasterId] FOREIGN KEY([PIMasterId])
REFERENCES [dbo].[PIMaster] ([PIMasterId])
GO
ALTER TABLE [dbo].[PIDetails] CHECK CONSTRAINT [FK_PIDetails_PIMaster_PIMasterId]
GO
ALTER TABLE [dbo].[PIDetails]  WITH CHECK ADD  CONSTRAINT [FK_PIDetails_ProductMaster_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[ProductMaster] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PIDetails] CHECK CONSTRAINT [FK_PIDetails_ProductMaster_ProductId]
GO
ALTER TABLE [dbo].[PIMaster]  WITH CHECK ADD  CONSTRAINT [FK_PIMaster_BuyerMaster_BuyerId] FOREIGN KEY([BuyerId])
REFERENCES [dbo].[BuyerMaster] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PIMaster] CHECK CONSTRAINT [FK_PIMaster_BuyerMaster_BuyerId]
GO
ALTER TABLE [dbo].[PIMaster]  WITH CHECK ADD  CONSTRAINT [FK_PIMaster_CustomerLocation_ShipToId] FOREIGN KEY([ShipToId])
REFERENCES [dbo].[CustomerLocation] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PIMaster] CHECK CONSTRAINT [FK_PIMaster_CustomerLocation_ShipToId]
GO
ALTER TABLE [dbo].[PIMaster]  WITH CHECK ADD  CONSTRAINT [FK_PIMaster_CustomerMaster_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerMaster] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PIMaster] CHECK CONSTRAINT [FK_PIMaster_CustomerMaster_CustomerId]
GO
USE [master]
GO
ALTER DATABASE [EXAM01] SET  READ_WRITE 
GO
