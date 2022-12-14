USE [master]
GO
/****** Object:  Database [LMS]    Script Date: 10-08-2022 23:15:22 ******/
CREATE DATABASE [LMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDEVNEW2019\MSSQL\DATA\LMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDEVNEW2019\MSSQL\DATA\LMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [LMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LMS] SET RECOVERY FULL 
GO
ALTER DATABASE [LMS] SET  MULTI_USER 
GO
ALTER DATABASE [LMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LMS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LMS', N'ON'
GO
ALTER DATABASE [LMS] SET QUERY_STORE = OFF
GO
USE [LMS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10-08-2022 23:15:23 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10-08-2022 23:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10-08-2022 23:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10-08-2022 23:15:24 ******/
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
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[FirstName] [nvarchar](50) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookIssues]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookIssues](
	[IssueId] [int] IDENTITY(1,1) NOT NULL,
	[Days] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IssueDate] [datetime2](7) NOT NULL,
	[ReturnDate] [datetime2](7) NOT NULL,
	[PanaltyStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_BookIssues] PRIMARY KEY CLUSTERED 
(
	[IssueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](100) NOT NULL,
	[Detail] [varchar](200) NULL,
	[Author] [varchar](100) NOT NULL,
	[PubId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[Price] [decimal](5, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[BookPhoto] [varchar](300) NULL,
	[IsActive] [bit] NOT NULL,
	[Available] [int] NOT NULL,
	[Rent] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Penalties]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Penalties](
	[PenaltyId] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](max) NULL,
	[PublicationName] [nvarchar](max) NULL,
	[BranchName] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[StudentName] [nvarchar](max) NULL,
	[Day] [int] NOT NULL,
	[IssueDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NULL,
	[PenaltyAmount] [decimal](18, 2) NOT NULL,
	[Reason] [nvarchar](max) NULL,
	[BookName] [nvarchar](max) NULL,
	[BookPhotoPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Penalties] PRIMARY KEY CLUSTERED 
(
	[PenaltyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publications]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publications](
	[PubId] [int] IDENTITY(1,1) NOT NULL,
	[PublicationName] [varchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Publications] PRIMARY KEY CLUSTERED 
(
	[PubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registers]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registers](
	[RegId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[MobileNo] [varchar](50) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Registers] PRIMARY KEY CLUSTERED 
(
	[RegId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](20) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 10-08-2022 23:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](100) NOT NULL,
	[BranchId] [int] NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[MobileNo] [varchar](20) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[Pincode] [varchar](10) NOT NULL,
	[Photo] [varchar](300) NULL,
	[Email] [varchar](200) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727112702_LMSRoleMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727112817_LMSPublicationMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727113320_LMSRoleMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727115944_LMSBranchMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727122738_LMSRegistrationMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727122912_LMSBookMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727123037_LMSStudentMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727123428_LMSBookIssueMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727124809_issuebook', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727125336_bookissue', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727132031_LMSBookIssueMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727141852_LMSBookIssueMigration', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220729093337_LMSApplication', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220804125725_addactive', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220804132114_addarole', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220805102053_bookupdate', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220808102338_issuebooks', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220808110846_BookIssue', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220808112158_IssueBooks', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220808154012_BookIssues', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220809104310_Penalties', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220809142656_Penalties', N'3.1.0')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'42008e3e-1543-43e0-9a9a-d7c0302af665', N'Librarian', N'LIBRARIAN', N'26f9c6c6-ea2a-4424-bb75-132be554c999')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'54be8c69-d342-4e91-b955-7fe7289145b9', N'Student', N'STUDENT', N'fa82b2e4-3ec6-41b6-96a5-1b0a55c80d57')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd4e6f800-d18b-4e44-9b83-a9db86ccd077', N'Super Admin', N'SUPER ADMIN', N'c1154e6d-98d6-4112-bf8b-b90b1cece3fb')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'403ea435-b682-44f2-847e-5ffbd189ae64', N'42008e3e-1543-43e0-9a9a-d7c0302af665')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3b5ac54b-449b-4e25-8a13-f91384cf419f', N'54be8c69-d342-4e91-b955-7fe7289145b9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7be45dba-4ee1-4a26-940c-98b2b3e1ea95', N'54be8c69-d342-4e91-b955-7fe7289145b9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b1b6d8b1-7f9d-47d9-9802-ab3f0a7d534b', N'd4e6f800-d18b-4e44-9b83-a9db86ccd077')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ef08aff0-036b-4c97-95f1-b97dbc3d2761', N'd4e6f800-d18b-4e44-9b83-a9db86ccd077')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [FirstName]) VALUES (N'3b5ac54b-449b-4e25-8a13-f91384cf419f', N'washimraaza@chetu.com', N'WASHIMRAAZA@CHETU.COM', N'washimraaza@chetu.com', N'WASHIMRAAZA@CHETU.COM', 0, N'AQAAAAEAACcQAAAAEF36anuwMV7xVLU3tpqZ90RCTz77fZpKrLsO2cediEPypxjBP8M1LmkIlA5FcMl9rg==', N'ZDKGDU55JRQIMZRW6BDHMBVAXM66FSQP', N'af6e5e76-1812-4dc2-a4bc-0c1fc46dccc6', N'8574905398', 0, 0, NULL, 1, 0, N'Noida', N'washiam')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [FirstName]) VALUES (N'403ea435-b682-44f2-847e-5ffbd189ae64', N'ankit@chetu.com', N'ANKIT@CHETU.COM', N'ankit@chetu.com', N'ANKIT@CHETU.COM', 0, N'AQAAAAEAACcQAAAAEKHygsVVY07VBaBNY9ByDJ3YHt6e8VflRip0lr5ffyI6eaPMqqf8qfqP1tPuzrX2Zg==', N'GQ347KGYOHY7BYBTCI5E23SFXZ5XT3XQ', N'192a1868-20e3-4e1c-88b0-c2122f2b361e', N'8574905398', 0, 0, NULL, 1, 0, N'Noida', N'Ankit')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [FirstName]) VALUES (N'7be45dba-4ee1-4a26-940c-98b2b3e1ea95', N'amant@chetu.com', N'AMANT@CHETU.COM', N'amant@chetu.com', N'AMANT@CHETU.COM', 0, N'AQAAAAEAACcQAAAAEDM4fSLK66bLQVQnIQNliWndKTFKwytxz2+zUd4UjKlc1lipDEMKjfq1FpqW9K65pw==', N'TNZJZSFQMEBX2D6UD7EYWST6E6ADZW7A', N'fea4f938-c42d-4e08-b5da-2ac49b3c15ef', N'8574905398', 0, 0, NULL, 1, 0, N'Noida', N'Aman')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [FirstName]) VALUES (N'b1b6d8b1-7f9d-47d9-9802-ab3f0a7d534b', N'shan@chetu.com', N'SHAN@CHETU.COM', N'shan@chetu.com', N'SHAN@CHETU.COM', 0, N'AQAAAAEAACcQAAAAECfh0nY+3LCln/4p6vlsr/I7OVEjj3C67TO8QH2MvhO0tQf63AdCMO35Zz5Ko/WWTg==', N'3ZLVZO77H3HDEWDUOEXKLOYKLADJ5F34', N'f514b4de-16e1-431c-afa9-c49a12d515f2', NULL, 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [FirstName]) VALUES (N'ef08aff0-036b-4c97-95f1-b97dbc3d2761', N'parulp2@chetu.com', N'PARULP2@CHETU.COM', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEBLK0toWIMQXtw0P7R7E8GAigYEMklhupbUsK45J95JhlG+vQEThJGm9vPWHMoEgng==', N'ECMPDIGIHRIMIAKNBQYFD3PRR7BQY7QY', N'9a139e84-d9e4-47fb-9fcb-dc8398168a91', NULL, 0, 0, NULL, 1, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[BookIssues] ON 

INSERT [dbo].[BookIssues] ([IssueId], [Days], [BookId], [StudentId], [IsActive], [IssueDate], [ReturnDate], [PanaltyStatus]) VALUES (3, 3, 2, 2, 0, CAST(N'2022-08-08T17:24:56.5677551' AS DateTime2), CAST(N'2022-08-08T17:25:35.8633476' AS DateTime2), N'No')
INSERT [dbo].[BookIssues] ([IssueId], [Days], [BookId], [StudentId], [IsActive], [IssueDate], [ReturnDate], [PanaltyStatus]) VALUES (4, 2, 3, 2, 1, CAST(N'2022-08-08T17:25:16.1598067' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Yes Penalty')
SET IDENTITY_INSERT [dbo].[BookIssues] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [BookName], [Detail], [Author], [PubId], [BranchId], [Price], [Quantity], [BookPhoto], [IsActive], [Available], [Rent]) VALUES (1, N'Asp .Net Core', N'this is very helpful for biggners', N'A.S', 6, 1, CAST(200.00 AS Decimal(5, 2)), 15, NULL, 0, 25, 0)
INSERT [dbo].[Books] ([BookId], [BookName], [Detail], [Author], [PubId], [BranchId], [Price], [Quantity], [BookPhoto], [IsActive], [Available], [Rent]) VALUES (2, N'Angular', N'this is very helpful for biggners', N'A.S', 7, 2, CAST(200.00 AS Decimal(5, 2)), 25, N'7bc5152e-6277-4670-a104-28926bf0ad9d_tree-736885__480.jpg', 1, 24, 1)
INSERT [dbo].[Books] ([BookId], [BookName], [Detail], [Author], [PubId], [BranchId], [Price], [Quantity], [BookPhoto], [IsActive], [Available], [Rent]) VALUES (3, N'Asp .Net Core', N'this is very helpful for biggners', N'A.S', 6, 1, CAST(200.00 AS Decimal(5, 2)), 25, N'6bf1a08d-58ef-4771-8903-938e8fe59788_image2.jpeg', 1, 24, 1)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([BranchId], [BranchName], [IsActive]) VALUES (1, N'CSE', 1)
INSERT [dbo].[Branches] ([BranchId], [BranchName], [IsActive]) VALUES (2, N'EC', 1)
INSERT [dbo].[Branches] ([BranchId], [BranchName], [IsActive]) VALUES (3, N'IT', 0)
SET IDENTITY_INSERT [dbo].[Branches] OFF
SET IDENTITY_INSERT [dbo].[Penalties] ON 

INSERT [dbo].[Penalties] ([PenaltyId], [Author], [PublicationName], [BranchName], [Price], [StudentName], [Day], [IssueDate], [Status], [PenaltyAmount], [Reason], [BookName], [BookPhotoPath]) VALUES (1, N'A.S', N'Bharat Publication 6', N'CSE', CAST(200.00 AS Decimal(18, 2)), N'washiam', 5, CAST(N'2022-08-08T17:25:16.0000000' AS DateTime2), N'No', CAST(100.00 AS Decimal(18, 2)), N'Late Fine', N'Asp .Net Core', N'6bf1a08d-58ef-4771-8903-938e8fe59788_image2.jpeg')
SET IDENTITY_INSERT [dbo].[Penalties] OFF
SET IDENTITY_INSERT [dbo].[Publications] ON 

INSERT [dbo].[Publications] ([PubId], [PublicationName], [IsActive]) VALUES (1, N'Bharat Publication1', 0)
INSERT [dbo].[Publications] ([PubId], [PublicationName], [IsActive]) VALUES (2, N'Bharat Publication 2', 0)
INSERT [dbo].[Publications] ([PubId], [PublicationName], [IsActive]) VALUES (3, N'Bharat Publication 3', 0)
INSERT [dbo].[Publications] ([PubId], [PublicationName], [IsActive]) VALUES (4, N'Bharat Publication 4', 0)
INSERT [dbo].[Publications] ([PubId], [PublicationName], [IsActive]) VALUES (5, N'Bharat Publication 5', 1)
INSERT [dbo].[Publications] ([PubId], [PublicationName], [IsActive]) VALUES (6, N'Bharat Publication 6', 1)
INSERT [dbo].[Publications] ([PubId], [PublicationName], [IsActive]) VALUES (7, N'Bharat Publication 7', 1)
SET IDENTITY_INSERT [dbo].[Publications] OFF
SET IDENTITY_INSERT [dbo].[Registers] ON 

INSERT [dbo].[Registers] ([RegId], [Name], [Email], [Password], [MobileNo], [Address], [RoleId]) VALUES (2, N'Parul', N'parulp2@chetu.com', N'Chetu@123', N'8574905398', N'Noida', 1)
INSERT [dbo].[Registers] ([RegId], [Name], [Email], [Password], [MobileNo], [Address], [RoleId]) VALUES (3, N'Shan', N'shan@chetu.com', N'123456', N'8574905398', N'Noida', 2)
INSERT [dbo].[Registers] ([RegId], [Name], [Email], [Password], [MobileNo], [Address], [RoleId]) VALUES (4, N'Shan', N'shan@chetu.com', N'Chetu@123', N'8574905398', N'Noida', 1)
INSERT [dbo].[Registers] ([RegId], [Name], [Email], [Password], [MobileNo], [Address], [RoleId]) VALUES (5, N'Aman', N'amant@chetu.com', N'Chetu@123', N'8574905398', N'Noida', 3)
SET IDENTITY_INSERT [dbo].[Registers] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Super Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Librarian')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Student')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [StudentName], [BranchId], [Gender], [DateOfBirth], [MobileNo], [Address], [City], [Pincode], [Photo], [Email], [Password], [IsActive], [RoleId]) VALUES (1, N'Parul Patel', 1, N'Female', CAST(N'2022-08-04T00:00:00.0000000' AS DateTime2), N'8574905398', N'Noida', N'Delhi', N'1232010', N'', N'parul@chetu.com', N'Chetu@123', 0, 3)
INSERT [dbo].[Students] ([StudentId], [StudentName], [BranchId], [Gender], [DateOfBirth], [MobileNo], [Address], [City], [Pincode], [Photo], [Email], [Password], [IsActive], [RoleId]) VALUES (2, N'washiam', 1, N'Female', CAST(N'2022-08-04T00:00:00.0000000' AS DateTime2), N'8574905398', N'Noida', N'Delhi', N'1232010', N'7e2d6b4f-cfd0-47e8-a392-2e9d94d930a5_image2.jpeg', N'washimraaza@chetu.com', N'Chetu@12345', 1, 3)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10-08-2022 23:15:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10-08-2022 23:15:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookIssues_BookId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_BookIssues_BookId] ON [dbo].[BookIssues]
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Books_BranchId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_Books_BranchId] ON [dbo].[Books]
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Books_PubId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_Books_PubId] ON [dbo].[Books]
(
	[PubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Registers_RoleId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_Registers_RoleId] ON [dbo].[Registers]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_BranchId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_Students_BranchId] ON [dbo].[Students]
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_RoleId]    Script Date: 10-08-2022 23:15:24 ******/
CREATE NONCLUSTERED INDEX [IX_Students_RoleId] ON [dbo].[Students]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((0)) FOR [Available]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((0)) FOR [Rent]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT ((0)) FOR [RoleId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BookIssues]  WITH CHECK ADD  CONSTRAINT [FK_BookIssues_Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookIssues] CHECK CONSTRAINT [FK_BookIssues_Books_BookId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([BranchId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Branches_BranchId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publications_PubId] FOREIGN KEY([PubId])
REFERENCES [dbo].[Publications] ([PubId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publications_PubId]
GO
ALTER TABLE [dbo].[Registers]  WITH CHECK ADD  CONSTRAINT [FK_Registers_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registers] CHECK CONSTRAINT [FK_Registers_Roles_RoleId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([BranchId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Branches_BranchId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [LMS] SET  READ_WRITE 
GO
