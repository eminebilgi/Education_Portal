USE [master]
GO
/****** Object:  Database [EducationPortal]    Script Date: 1.01.2024 17:23:46 ******/
CREATE DATABASE [EducationPortal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EducationPortal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EducationPortal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EducationPortal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EducationPortal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EducationPortal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EducationPortal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EducationPortal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EducationPortal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EducationPortal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EducationPortal] SET ARITHABORT OFF 
GO
ALTER DATABASE [EducationPortal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EducationPortal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EducationPortal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EducationPortal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EducationPortal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EducationPortal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EducationPortal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EducationPortal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EducationPortal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EducationPortal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EducationPortal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EducationPortal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EducationPortal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EducationPortal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EducationPortal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EducationPortal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EducationPortal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EducationPortal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EducationPortal] SET  MULTI_USER 
GO
ALTER DATABASE [EducationPortal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EducationPortal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EducationPortal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EducationPortal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EducationPortal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EducationPortal] SET QUERY_STORE = OFF
GO
USE [EducationPortal]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1.01.2024 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 1.01.2024 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EducationName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryID] [int] NULL,
	[TrainerID] [int] NULL,
	[Quota] [int] NULL,
	[Duration] [char](3) NULL,
	[Price] [decimal](18, 0) NULL,
	[Currency] [char](3) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 1.01.2024 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembersEducation]    Script Date: 1.01.2024 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembersEducation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[EducationID] [int] NOT NULL,
	[TransactionDate] [date] NULL,
	[TransactionType] [nvarchar](50) NULL,
 CONSTRAINT [PK_MembersEducation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Source]    Script Date: 1.01.2024 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Source](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EducationID] [int] NULL,
	[SourcePath] [nvarchar](50) NULL,
 CONSTRAINT [PK_Source] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainer]    Script Date: 1.01.2024 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
 CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Education] ADD  CONSTRAINT [DF_Education_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD  CONSTRAINT [FK_Education_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Education] CHECK CONSTRAINT [FK_Education_Category]
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD  CONSTRAINT [FK_Education_Trainer] FOREIGN KEY([TrainerID])
REFERENCES [dbo].[Trainer] ([ID])
GO
ALTER TABLE [dbo].[Education] CHECK CONSTRAINT [FK_Education_Trainer]
GO
ALTER TABLE [dbo].[MembersEducation]  WITH CHECK ADD  CONSTRAINT [FK_MembersEducation_Education] FOREIGN KEY([EducationID])
REFERENCES [dbo].[Education] ([ID])
GO
ALTER TABLE [dbo].[MembersEducation] CHECK CONSTRAINT [FK_MembersEducation_Education]
GO
ALTER TABLE [dbo].[MembersEducation]  WITH CHECK ADD  CONSTRAINT [FK_MembersEducation_Member] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([ID])
GO
ALTER TABLE [dbo].[MembersEducation] CHECK CONSTRAINT [FK_MembersEducation_Member]
GO
ALTER TABLE [dbo].[Source]  WITH CHECK ADD  CONSTRAINT [FK_Source_Education] FOREIGN KEY([EducationID])
REFERENCES [dbo].[Education] ([ID])
GO
ALTER TABLE [dbo].[Source] CHECK CONSTRAINT [FK_Source_Education]
GO
USE [master]
GO
ALTER DATABASE [EducationPortal] SET  READ_WRITE 
GO
