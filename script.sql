USE [master]
GO
/****** Object:  Database [CSEBookBankDb]    Script Date: 11/18/2018 11:06:23 PM ******/
CREATE DATABASE [CSEBookBankDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CSEBookBankDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\CSEBookBankDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CSEBookBankDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\CSEBookBankDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CSEBookBankDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CSEBookBankDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CSEBookBankDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CSEBookBankDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CSEBookBankDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CSEBookBankDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CSEBookBankDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CSEBookBankDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CSEBookBankDb] SET  MULTI_USER 
GO
ALTER DATABASE [CSEBookBankDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CSEBookBankDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CSEBookBankDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CSEBookBankDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CSEBookBankDb]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/18/2018 11:06:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book](
	[Title] [nvarchar](50) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[Edition] [int] NOT NULL,
	[BookID] [int] NOT NULL,
	[ImagePath] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[IssuedTo] [nvarchar](50) NULL,
	[IssuedDate] [date] NULL,
	[ReturnDate] [date] NULL,
	[DueDate] [date] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Librarian]    Script Date: 11/18/2018 11:06:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Librarian](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Librarian] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[student]    Script Date: 11/18/2018 11:06:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[StudentName] [nvarchar](50) NOT NULL,
	[RegistrationNo] [nvarchar](50) NOT NULL,
	[Fine] [int] NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [CSEBookBankDb] SET  READ_WRITE 
GO
