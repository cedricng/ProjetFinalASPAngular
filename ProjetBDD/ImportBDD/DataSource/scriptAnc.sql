USE [master]
GO
/****** Object:  Database [projet-hopital-db]    Script Date: 09/12/2023 22:27:45 ******/
CREATE DATABASE [projet-hopital-db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'projet-hopital-db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\projet-hopital-db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'projet-hopital-db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\projet-hopital-db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [projet-hopital-db] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [projet-hopital-db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [projet-hopital-db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [projet-hopital-db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [projet-hopital-db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [projet-hopital-db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [projet-hopital-db] SET ARITHABORT OFF 
GO
ALTER DATABASE [projet-hopital-db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [projet-hopital-db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [projet-hopital-db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [projet-hopital-db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [projet-hopital-db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [projet-hopital-db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [projet-hopital-db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [projet-hopital-db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [projet-hopital-db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [projet-hopital-db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [projet-hopital-db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [projet-hopital-db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [projet-hopital-db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [projet-hopital-db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [projet-hopital-db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [projet-hopital-db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [projet-hopital-db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [projet-hopital-db] SET RECOVERY FULL 
GO
ALTER DATABASE [projet-hopital-db] SET  MULTI_USER 
GO
ALTER DATABASE [projet-hopital-db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [projet-hopital-db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [projet-hopital-db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [projet-hopital-db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [projet-hopital-db] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'projet-hopital-db', N'ON'
GO
ALTER DATABASE [projet-hopital-db] SET QUERY_STORE = OFF
GO
USE [projet-hopital-db]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [projet-hopital-db]
GO
/****** Object:  Table [dbo].[authentification]    Script Date: 09/12/2023 22:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authentification](
	[login] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[metier] [int] NOT NULL,
 CONSTRAINT [PK_authentification] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 09/12/2023 22:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patients](
	[id] [int] NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenom] [varchar](50) NOT NULL,
	[age] [int] NOT NULL,
	[adresse] [varchar](50) NULL,
	[telephone] [varchar](50) NULL,
 CONSTRAINT [PK_patients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[visites]    Script Date: 09/12/2023 22:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[visites](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idpatient] [int] NOT NULL,
	[date] [dateTime] NOT NULL,
	[medecin] [varchar](50) NOT NULL,
	[num_salle] [int] NOT NULL,
	[tarif] [int] NOT NULL,
 CONSTRAINT [PK_visites] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [projet-hopital-db] SET  READ_WRITE 
GO
