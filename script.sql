USE [master]
GO
/****** Object:  Database [Trade v.2]    Script Date: 25.05.2022 14:11:21 ******/
CREATE DATABASE [Trade v.2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Trade v.2', FILENAME = N'D:\SSDE\MSSQL15.MSSQLSERVER\MSSQL\DATA\Trade v.2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Trade v.2_log', FILENAME = N'D:\SSDE\MSSQL15.MSSQLSERVER\MSSQL\DATA\Trade v.2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Trade v.2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Trade v.2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Trade v.2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Trade v.2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Trade v.2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Trade v.2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Trade v.2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Trade v.2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Trade v.2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Trade v.2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Trade v.2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Trade v.2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Trade v.2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Trade v.2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Trade v.2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Trade v.2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Trade v.2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Trade v.2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Trade v.2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Trade v.2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Trade v.2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Trade v.2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Trade v.2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Trade v.2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Trade v.2] SET RECOVERY FULL 
GO
ALTER DATABASE [Trade v.2] SET  MULTI_USER 
GO
ALTER DATABASE [Trade v.2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Trade v.2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Trade v.2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Trade v.2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Trade v.2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Trade v.2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Trade v.2', N'ON'
GO
ALTER DATABASE [Trade v.2] SET QUERY_STORE = OFF
GO
USE [Trade v.2]
GO
/****** Object:  Table [dbo].[Action]    Script Date: 25.05.2022 14:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Action](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Start Time] [datetime] NOT NULL,
	[End Time] [datetime] NOT NULL,
	[Discount] [float] NOT NULL,
	[TypeId] [int] NOT NULL,
	[RowUpdateTime] [datetime] NOT NULL,
	[RowInsertTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 25.05.2022 14:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RowInsertTime] [datetime] NOT NULL,
	[RowUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Category_1] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 25.05.2022 14:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RowInsertTime] [datetime] NOT NULL,
	[RowUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supply]    Script Date: 25.05.2022 14:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[SupplyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[RowInsertTime] [datetime] NOT NULL,
	[RowUpdateTime] [datetime] NOT NULL,
	[ActionId] [int] NULL,
 CONSTRAINT [PK_Supply] PRIMARY KEY CLUSTERED 
(
	[SupplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 25.05.2022 14:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[RowInsertTime] [datetime] NOT NULL,
	[RowUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25.05.2022 14:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [binary](64) NOT NULL,
	[Salt] [uniqueidentifier] NOT NULL,
	[RowInsertTime] [datetime] NOT NULL,
	[RowUpdateTime] [datetime] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Action] ADD  CONSTRAINT [DF_Action_RowUpdateTime]  DEFAULT (getutcdate()) FOR [RowUpdateTime]
GO
ALTER TABLE [dbo].[Action] ADD  CONSTRAINT [DF_Action_RowInsertTime]  DEFAULT (getutcdate()) FOR [RowInsertTime]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_RowInsertTime_1]  DEFAULT (getutcdate()) FOR [RowInsertTime]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_RowUpdateTime_1]  DEFAULT (getutcdate()) FOR [RowUpdateTime]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_RowInsertTime]  DEFAULT (getutcdate()) FOR [RowInsertTime]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_RowUpdateTime]  DEFAULT (getutcdate()) FOR [RowUpdateTime]
GO
ALTER TABLE [dbo].[Supply] ADD  CONSTRAINT [DF_Supply_RowInsertTime]  DEFAULT (getutcdate()) FOR [RowInsertTime]
GO
ALTER TABLE [dbo].[Supply] ADD  CONSTRAINT [DF_Supply_RowUpdateTime]  DEFAULT (getutcdate()) FOR [RowUpdateTime]
GO
ALTER TABLE [dbo].[Supply] ADD  CONSTRAINT [DF_Supply_ActionId]  DEFAULT ((1)) FOR [ActionId]
GO
ALTER TABLE [dbo].[Type] ADD  CONSTRAINT [DF_Category_RowInsertTime]  DEFAULT (getutcdate()) FOR [RowInsertTime]
GO
ALTER TABLE [dbo].[Type] ADD  CONSTRAINT [DF_Category_RowUpdateTime]  DEFAULT (getutcdate()) FOR [RowUpdateTime]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_RowInsertTime]  DEFAULT (getutcdate()) FOR [RowInsertTime]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_RowUpdateTime]  DEFAULT (getutcdate()) FOR [RowUpdateTime]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([TypeId])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_Type]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Action] FOREIGN KEY([ActionId])
REFERENCES [dbo].[Action] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Action]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Category]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [Trade v.2] SET  READ_WRITE 
GO
