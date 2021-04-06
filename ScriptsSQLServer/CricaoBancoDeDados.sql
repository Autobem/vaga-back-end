/************************************************************************/
/*                                                                      */
/*                 Criação do banco de dados                            */
/*                                                                      */
/************************************************************************/

USE [master]
GO

/****** Object:  Database [Autobem]    Script Date: 06/04/2021 16:35:25 ******/
CREATE DATABASE [Autobem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Autobem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Autobem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Autobem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Autobem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Autobem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Autobem] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Autobem] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Autobem] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Autobem] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Autobem] SET ARITHABORT OFF 
GO

ALTER DATABASE [Autobem] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Autobem] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Autobem] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Autobem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Autobem] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Autobem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Autobem] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Autobem] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Autobem] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Autobem] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Autobem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Autobem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Autobem] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Autobem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Autobem] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Autobem] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Autobem] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Autobem] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Autobem] SET  MULTI_USER 
GO

ALTER DATABASE [Autobem] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Autobem] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Autobem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Autobem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Autobem] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Autobem] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Autobem] SET  READ_WRITE 
GO


/************************************************************************/
/*                                                                      */
/*                 Criação da tabela Cores                              */
/*                                                                      */
/************************************************************************/


USE [Autobem]
GO

/****** Object:  Table [dbo].[Cores]    Script Date: 06/04/2021 16:34:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](40) NOT NULL,
 CONSTRAINT [PK_Cores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/************************************************************************/
/*                                                                      */
/*                 Criação da tabela Proprietarios                      */
/*                                                                      */
/************************************************************************/


USE [Autobem]
GO

/****** Object:  Table [dbo].[Proprietarios]    Script Date: 06/04/2021 16:34:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Proprietarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](45) NOT NULL,
	[Celular] [varchar](9) NOT NULL,
 CONSTRAINT [PK_Proprietarios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/************************************************************************/
/*                                                                      */
/*                 Criação da tabela Veiculos                           */
/*                                                                      */
/************************************************************************/


USE [Autobem]
GO

/****** Object:  Table [dbo].[Veiculos]    Script Date: 06/04/2021 16:35:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Veiculos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](20) NOT NULL,
	[Modelo] [varchar](30) NOT NULL,
	[AnoFabricacao] [int] NOT NULL,
	[Placa] [varchar](7) NOT NULL,
 CONSTRAINT [PK_vEICULOS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Veiculos]  WITH CHECK ADD  CONSTRAINT [FK_Veiculos_Cores] FOREIGN KEY([ID])
REFERENCES [dbo].[Cores] ([ID])
GO

ALTER TABLE [dbo].[Veiculos] CHECK CONSTRAINT [FK_Veiculos_Cores]
GO

ALTER TABLE [dbo].[Veiculos]  WITH CHECK ADD  CONSTRAINT [FK_Veiculos_Proprietarios] FOREIGN KEY([ID])
REFERENCES [dbo].[Proprietarios] ([ID])
GO

ALTER TABLE [dbo].[Veiculos] CHECK CONSTRAINT [FK_Veiculos_Proprietarios]
GO