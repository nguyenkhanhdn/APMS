USE [master]
GO
/****** Object:  Database [APMS]    Script Date: 4/4/2025 4:30:16 PM ******/
CREATE DATABASE [APMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'APMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\APMS.mdf' , SIZE = 11264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'APMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\APMS_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [APMS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [APMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [APMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [APMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [APMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [APMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [APMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [APMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [APMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [APMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [APMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [APMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [APMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [APMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [APMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [APMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [APMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [APMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [APMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [APMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [APMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [APMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [APMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [APMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [APMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [APMS] SET  MULTI_USER 
GO
ALTER DATABASE [APMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [APMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [APMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [APMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [APMS] SET DELAYED_DURABILITY = DISABLED 
GO
USE [APMS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [sql_variant] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingAvailabilities]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingAvailabilities](
	[Id] [int] NOT NULL,
	[TotalSlots] [int] NOT NULL,
	[AvailableSlots] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingSlots]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingSlots](
	[ParkingSlotId] [int] NOT NULL,
	[SlotNumber] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tariff]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tariff](
	[TariffId] [int] NOT NULL,
	[TariffName] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[ParkingSlotId] [int] NOT NULL,
	[EntryTime] [smalldatetime] NOT NULL,
	[ExitTime] [smalldatetime] NULL,
	[TotalAmount] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserPayments]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPayments](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[TariffId] [int] NOT NULL,
	[PaymentDate] [smalldatetime] NOT NULL,
	[Amount] [real] NOT NULL,
	[IsPaid] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Role] [nvarchar](max) NOT NULL,
	[Balance] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleId] [int] NOT NULL,
	[LicensePlate] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[VehicleTypeId] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehicleTypes]    Script Date: 4/4/2025 4:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleTypes](
	[VehicleTypeId] [int] NOT NULL,
	[TypeName] [nvarchar](max) NOT NULL,
	[DescriptionImage] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250323083756_a', N'8.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250323090544_iden', N'8.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250323135341_abc', N'8.0.13')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2994fb26-9eaa-4fdc-a206-d54c13bb9c05', N'khanhdsp@gmail.com', N'KHANHDSP@GMAIL.COM', N'khanhdsp@gmail.com', N'KHANHDSP@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEJ1qzhvYilIBD2m7ocFAZCuHbO7cGp73KfPqd1VqD+/u3uA1EBFcI4NFT1SmYu++0w==', N'PORTQBZ35P2YVEUEMJ3RK5O434U6V5ZF', N'f4a052a9-2ab5-4c6b-8a1b-ae7d5076dc5e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'620fbe41-282a-4b26-ac42-b6d1caff35ba', N'lqg@example.com', N'LQG@EXAMPLE.COM', N'lqg@example.com', N'LQG@EXAMPLE.COM', 1, N'AQAAAAIAAYagAAAAEJ/v8D8dSI4FZiHoCr6sKdE628jKGU36BsDPxYKG7g5D2a7bSEuIRvVWlcSXsVztIg==', N'EBG6HDE24OFAQAT73FSMVWUEL6Q3CCYC', N'bde43801-aec8-4326-9cee-d67a36cda5c6', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c1241b51-3df7-49e1-a0b0-ccd995360bed', N'nta@example.com', N'NTA@EXAMPLE.COM', N'nta@example.com', N'NTA@EXAMPLE.COM', 1, N'AQAAAAIAAYagAAAAEBN2JWL3uE2ASZY6kdLxMy26O5SXWo0PKI0z2BTCcSOFe/Sjx5ZhKvYSsHxye2kdvQ==', N'V7WICVT74VWMXNVA6TGFZ3KEMGPUXUOZ', N'eb1a74e7-6744-4899-aeed-310523b0b92c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7f4db731-986d-4f06-b9c3-e362858f41d4', N'hmh@example.com', N'HMH@EXAMPLE.COM', N'hmh@example.com', N'HMH@EXAMPLE.COM', 1, N'AQAAAAIAAYagAAAAEM7mbU6avH+h5nObzpK7q9y8ybpfin16PHWq8XjvOcYl4UNCaM8uKilRKVD6h28hUg==', N'NTM3CWBRWFHKF5Q37RWLWXAP56YDTKLP', N'301fdeae-9577-4eb9-85aa-2b3cf0952de1', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[ParkingAvailabilities] ([Id], [TotalSlots], [AvailableSlots]) VALUES (1, 10, 8)
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (1, N'B3', N'Đã có xe')
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (2, N'B4', N'Trống')
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (3, N'B5', N'Đã có xe')
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (4, N'C1', N'Trống')
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (5, N'C2', N'Trống')
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (6, N'C3', N'Trống')
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (7, N'C4', N'Trống')
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (8, N'D1', N'Trống')
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (9, N'D2', N'Trống')
INSERT [dbo].[ParkingSlots] ([ParkingSlotId], [SlotNumber], [Status]) VALUES (10, N'D3', N'Trống')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (1, N'Gói ngày VIP', CAST(100000.00 AS Decimal(18, 2)), N'Phí gửi xe trong ngày với quyền ưu tiên')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (2, N'Gói xe SUV', CAST(1400000.00 AS Decimal(18, 2)), N'Phí gửi xe SUV hàng tháng')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (3, N'Gói xe thể thao', CAST(1800000.00 AS Decimal(18, 2)), N'Phí gửi xe thể thao hàng tháng')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (4, N'Gói xe van', CAST(1300000.00 AS Decimal(18, 2)), N'Phí gửi xe van hàng tháng')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (5, N'Gói xe mô tô', CAST(1700000.00 AS Decimal(18, 2)), N'Phí gửi xe mô tô phân khối lớn')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (6, N'Gói xe tải nhẹ', CAST(1600000.00 AS Decimal(18, 2)), N'Phí gửi xe tải nhẹ hàng tháng')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (7, N'Gói xe điện', CAST(1100000.00 AS Decimal(18, 2)), N'Phí gửi xe điện hàng tháng')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (8, N'Gói xe hybrid', CAST(1250000.00 AS Decimal(18, 2)), N'Phí gửi xe hybrid hàng tháng')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (9, N'Gói xe coupe', CAST(1550000.00 AS Decimal(18, 2)), N'Phí gửi xe coupe hàng tháng')
INSERT [dbo].[Tariff] ([TariffId], [TariffName], [Price], [Description]) VALUES (10, N'Gói xe hatchback', CAST(1350000.00 AS Decimal(18, 2)), N'Phí gửi xe hatchback hàng tháng')
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([TransactionId], [VehicleId], [ParkingSlotId], [EntryTime], [ExitTime], [TotalAmount]) VALUES (1, 8, 1, CAST(N'2025-04-04 14:43:00' AS SmallDateTime), CAST(N'2025-04-04 15:06:00' AS SmallDateTime), CAST(70000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionId], [VehicleId], [ParkingSlotId], [EntryTime], [ExitTime], [TotalAmount]) VALUES (2, 9, 1, CAST(N'2025-04-04 15:08:00' AS SmallDateTime), CAST(N'2025-04-04 15:08:00' AS SmallDateTime), CAST(70000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionId], [VehicleId], [ParkingSlotId], [EntryTime], [ExitTime], [TotalAmount]) VALUES (3, 10, 1, CAST(N'2025-04-04 15:09:00' AS SmallDateTime), NULL, CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionId], [VehicleId], [ParkingSlotId], [EntryTime], [ExitTime], [TotalAmount]) VALUES (4, 11, 2, CAST(N'2025-04-04 15:09:00' AS SmallDateTime), CAST(N'2025-04-04 15:09:00' AS SmallDateTime), CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[Transactions] ([TransactionId], [VehicleId], [ParkingSlotId], [EntryTime], [ExitTime], [TotalAmount]) VALUES (5, 12, 3, CAST(N'2025-04-04 15:09:00' AS SmallDateTime), NULL, CAST(70000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Transactions] OFF
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (12, 1, 2, CAST(N'2024-03-01 00:00:00' AS SmallDateTime), 200000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (13, 2, 1, CAST(N'2024-03-05 00:00:00' AS SmallDateTime), 150000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (14, 3, 3, CAST(N'2024-03-10 00:00:00' AS SmallDateTime), 300000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (15, 4, 2, CAST(N'2024-03-12 00:00:00' AS SmallDateTime), 200000, 0)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (16, 5, 1, CAST(N'2024-03-15 00:00:00' AS SmallDateTime), 150000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (17, 6, 3, CAST(N'2024-03-18 00:00:00' AS SmallDateTime), 300000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (18, 7, 2, CAST(N'2024-03-20 00:00:00' AS SmallDateTime), 200000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (19, 8, 1, CAST(N'2024-03-22 00:00:00' AS SmallDateTime), 150000, 0)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (20, 9, 3, CAST(N'2024-03-25 00:00:00' AS SmallDateTime), 300000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (21, 1, 2, CAST(N'2024-03-28 00:00:00' AS SmallDateTime), 200000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (22, 1, 1, CAST(N'2024-04-01 00:00:00' AS SmallDateTime), 150000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (23, 2, 3, CAST(N'2024-04-05 00:00:00' AS SmallDateTime), 300000, 0)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (24, 3, 2, CAST(N'2024-04-10 00:00:00' AS SmallDateTime), 200000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (25, 4, 1, CAST(N'2024-04-15 00:00:00' AS SmallDateTime), 150000, 1)
INSERT [dbo].[UserPayments] ([Id], [UserId], [TariffId], [PaymentDate], [Amount], [IsPaid]) VALUES (26, 5, 3, CAST(N'2024-04-20 00:00:00' AS SmallDateTime), 300000, 1)
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (1, N'Nguyễn Thị An', N'nta@example.com', N'0932109876', N'User', N'600000')
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (2, N'Lê Quốc Giao', N'lqg@example.com', N'0921098765', N'User', N'250000')
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (3, N'Hoàng Minh Hạnh', N'hmh@example.com', N'0910987654', N'User', N'1500000')
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (4, N'Phan Văn Lâm', N'pvl@example.com', N'0909876543', N'User', N'450000')
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (5, N'Đặng Thị Huệ', N'dth@example.com', N'0898765432', N'User', N'320000')
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (6, N'Trần Văn Kha', N'tvk@example.com', N'0887654321', N'User', N'290000')
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (7, N'Bùi Hồng Liên', N'bhl@example.com', N'0876543210', N'User', N'110000')
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (8, N'Võ Quang Minh', N'vqm@example.com', N'0865432109', N'User', N'750000')
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (9, N'Dương Mai Nam', N'dmn@example.com', N'0854321098', N'User', N'650000')
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Role], [Balance]) VALUES (10, N'Tạ Ngọc Oanh', N'tno@example.com', N'0843210987', N'User', N'800000')
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (7, N'30P-6688', 1, 6)
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (8, N'88H-8888', 2, 7)
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (9, N'62A-00222', 3, 8)
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (10, N'30N-6789', 4, 9)
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (11, N'30E-16888', 5, 10)
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (12, N'62A-03740', 6, 2)
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (13, N'52X-5756', 7, 3)
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (14, N'35N-7667', 8, 4)
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (15, N'36B-00826', 9, 5)
INSERT [dbo].[Vehicles] ([VehicleId], [LicensePlate], [UserId], [VehicleTypeId]) VALUES (16, N'36N-6789', 10, 1)
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (1, N'Xe van', N'van.jpg', N'Xe nhỏ có khoang chứa đồ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (2, N'Xe mô tô', N'moto.jpg', N'Xe hai bánh phân khối lớn')
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (3, N'Xe tải nhẹ', N'light_truck.jpg', N'Xe tải có trọng tải nhỏ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (4, N'Xe điện', N'ev.jpg', N'Xe chạy bằng điện')
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (5, N'Xe hybrid', N'hybrid.jpg', N'Xe chạy xăng - điện')
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (6, N'Xe coupe', N'coupe.jpg', N'Xe thể thao hai cửa')
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (7, N'Xe crossover', N'crossover.jpg', N'Xe đa dụng kết hợp SUV và Sedan')
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (8, N'Xe sedan', N'sedan.jpg', N'Xe 4 cửa truyền thống')
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (9, N'Xe hatchback', N'hatchback.jpg', N'Xe nhỏ với cốp mở lên trên')
INSERT [dbo].[VehicleTypes] ([VehicleTypeId], [TypeName], [DescriptionImage], [Description]) VALUES (10, N'Xe thể thao', N'sports.jpg', N'Xe tốc độ cao, thiết kế khí động học')
USE [master]
GO
ALTER DATABASE [APMS] SET  READ_WRITE 
GO
