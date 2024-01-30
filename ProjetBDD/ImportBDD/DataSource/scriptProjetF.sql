USE [master]
GO
/****** Object:  Database [projetF]    Script Date: 28/01/2024 02:21:22 ******/
CREATE DATABASE [projetF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'projetF', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\projetF.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'projetF_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\projetF_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [projetF] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [projetF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [projetF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [projetF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [projetF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [projetF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [projetF] SET ARITHABORT OFF 
GO
ALTER DATABASE [projetF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [projetF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [projetF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [projetF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [projetF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [projetF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [projetF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [projetF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [projetF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [projetF] SET  DISABLE_BROKER 
GO
ALTER DATABASE [projetF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [projetF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [projetF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [projetF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [projetF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [projetF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [projetF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [projetF] SET RECOVERY FULL 
GO
ALTER DATABASE [projetF] SET  MULTI_USER 
GO
ALTER DATABASE [projetF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [projetF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [projetF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [projetF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [projetF] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'projetF', N'ON'
GO
ALTER DATABASE [projetF] SET QUERY_STORE = OFF
GO
USE [projetF]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [projetF]
GO
/****** Object:  Table [dbo].[authentifications]    Script Date: 28/01/2024 02:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authentifications](
	[login] [nvarchar](10) NOT NULL,
	[password] [nvarchar](10) NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_authentifications] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 28/01/2024 02:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] NOT NULL,
	[nom] [nvarchar](50) NOT NULL,
	[prenom] [nvarchar](50) NOT NULL,
	[age] [int] NULL,
	[adresse] [nvarchar](50) NULL,
	[telephone] [nvarchar](10) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_authentifications]    Script Date: 28/01/2024 02:21:22 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_authentifications] ON [dbo].[authentifications]
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[authentifications]  WITH CHECK ADD  CONSTRAINT [FK__authentifications_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[authentifications] CHECK CONSTRAINT [FK__authentifications_users]
GO
USE [master]
GO
ALTER DATABASE [projetF] SET  READ_WRITE 
GO
