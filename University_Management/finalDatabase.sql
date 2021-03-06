USE [master]
GO
/****** Object:  Database [UniversityCourseandResultDB]    Script Date: 8/29/2016 6:23:30 AM ******/
CREATE DATABASE [UniversityCourseandResultDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityCourseandResultDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UniversityCourseandResultDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityCourseandResultDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UniversityCourseandResultDB_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityCourseandResultDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityCourseandResultDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityCourseandResultDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET RECOVERY FULL 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityCourseandResultDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityCourseandResultDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversityCourseandResultDB', N'ON'
GO
USE [UniversityCourseandResultDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Results]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Results](
	[R_ID] [int] IDENTITY(1,1) NOT NULL,
	[RegNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Id] [int] NULL,
	[CourseID] [int] NULL,
	[GradeId] [int] NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[R_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Allocateion]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Allocateion](
	[Al_Id] [int] IDENTITY(1,1) NOT NULL,
	[Id] [int] NULL,
	[CourseName] [varchar](50) NULL,
	[RoomName] [varchar](50) NULL,
	[Day] [varchar](50) NULL,
	[Forms] [time](2) NULL,
	[Tows] [time](2) NULL,
 CONSTRAINT [PK_tbl_Allocateion] PRIMARY KEY CLUSTERED 
(
	[Al_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Course]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Credit] [varchar](50) NULL,
	[Description] [varchar](100) NULL,
	[Id] [int] NULL,
	[SemID] [int] NULL,
 CONSTRAINT [PK_tbl_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Designation]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Designation](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesinationName] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Designation] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Enrols]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Enrols](
	[E_Id] [int] IDENTITY(1,1) NOT NULL,
	[RegNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Id] [int] NULL,
	[Dates] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Enrols] PRIMARY KEY CLUSTERED 
(
	[E_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Grade]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Grade](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Grade] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Room]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Semester]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Semester](
	[SemID] [int] IDENTITY(1,1) NOT NULL,
	[SemName] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Semester] PRIMARY KEY CLUSTERED 
(
	[SemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SevenDay]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SevenDay](
	[DayId] [int] IDENTITY(1,1) NOT NULL,
	[Day] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_SevenDay_1] PRIMARY KEY CLUSTERED 
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Student]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Student](
	[St_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[Dates] [date] NULL,
	[Addres] [varchar](50) NULL,
	[RegNo] [varchar](50) NULL,
	[Id] [int] NULL,
 CONSTRAINT [PK_tbl_Student] PRIMARY KEY CLUSTERED 
(
	[St_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Teacher]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Teacher](
	[TeachID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[Email] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[DesignationId] [int] NULL,
	[Id] [int] NULL,
	[Credict] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeachID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Vw_CourseStus]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Vw_CourseStus] as

select s.St_id,c.Name as CourseName,s.RegNo,s.Id from tbl_Student as s  inner join tbl_Course as c on s.Id=c.Id
GO
/****** Object:  View [dbo].[VW_StudentDepartment]    Script Date: 8/29/2016 6:23:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[VW_StudentDepartment]
as
select s.St_id,s.RegNo,d.Id,d.Name as DepartmentName from tbl_Student as s inner join Department as d on s.id=d.Id

GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (1, N'CSE', N'COMPUTER SCIENCE AND ENGINEERING')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (1002, N'ME', N'Machinical Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (2002, N'EEE', N'Electrial and Electronic Enginering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (2006, N'TE', N'Textile Engineering')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([R_ID], [RegNo], [Name], [Email], [Id], [CourseID], [GradeId]) VALUES (1, N'1004', N'karim', N'karim@gmail.com', 1, 0, 0)
INSERT [dbo].[Results] ([R_ID], [RegNo], [Name], [Email], [Id], [CourseID], [GradeId]) VALUES (2, N'1004', N'karim', N'karim@gmail.com', 1, 0, 0)
INSERT [dbo].[Results] ([R_ID], [RegNo], [Name], [Email], [Id], [CourseID], [GradeId]) VALUES (3, N'1020', N'karim', N'k@gmail.com', 1, 0, 0)
SET IDENTITY_INSERT [dbo].[Results] OFF
SET IDENTITY_INSERT [dbo].[tbl_Allocateion] ON 

INSERT [dbo].[tbl_Allocateion] ([Al_Id], [Id], [CourseName], [RoomName], [Day], [Forms], [Tows]) VALUES (1, 1, N'Computer Fundamental', N'A-202', N'Sunday', CAST(0x0200F91500000000 AS Time), CAST(0x0240771B00000000 AS Time))
SET IDENTITY_INSERT [dbo].[tbl_Allocateion] OFF
SET IDENTITY_INSERT [dbo].[tbl_Course] ON 

INSERT [dbo].[tbl_Course] ([CourseID], [Code], [Name], [Credit], [Description], [Id], [SemID]) VALUES (11, N'cse-101', N'computer fundamental', N'1.2', N'this is computer', 1, 1)
INSERT [dbo].[tbl_Course] ([CourseID], [Code], [Name], [Credit], [Description], [Id], [SemID]) VALUES (16, N'cse-103', N'programming', N'3.00', N'this is computer dept subject', 1, 1)
SET IDENTITY_INSERT [dbo].[tbl_Course] OFF
SET IDENTITY_INSERT [dbo].[tbl_Designation] ON 

INSERT [dbo].[tbl_Designation] ([DesignationId], [DesinationName]) VALUES (1, N'Assistant professor')
INSERT [dbo].[tbl_Designation] ([DesignationId], [DesinationName]) VALUES (2, N'Professor')
INSERT [dbo].[tbl_Designation] ([DesignationId], [DesinationName]) VALUES (3, N'Senior Lecturer')
INSERT [dbo].[tbl_Designation] ([DesignationId], [DesinationName]) VALUES (4, N'Lecturer')
SET IDENTITY_INSERT [dbo].[tbl_Designation] OFF
SET IDENTITY_INSERT [dbo].[tbl_Enrols] ON 

INSERT [dbo].[tbl_Enrols] ([E_Id], [RegNo], [Name], [Email], [Id], [Dates]) VALUES (1, N'1005', N'Electronic', N'dolar125@gmail.com', 4, N'1/1/0001 12:00:00 AM')
INSERT [dbo].[tbl_Enrols] ([E_Id], [RegNo], [Name], [Email], [Id], [Dates]) VALUES (2, N'1004', N'karim', N'karim@gmail.com', NULL, N'1/1/0001 12:00:00 AM')
INSERT [dbo].[tbl_Enrols] ([E_Id], [RegNo], [Name], [Email], [Id], [Dates]) VALUES (3, N'1005', N'Electronic', N'dolar125@gmail.com', 0, N'1/1/0001 12:00:00 AM')
INSERT [dbo].[tbl_Enrols] ([E_Id], [RegNo], [Name], [Email], [Id], [Dates]) VALUES (4, N'1004', N'karim', N'karim@gmail.com', 0, N'1/1/0001 12:00:00 AM')
INSERT [dbo].[tbl_Enrols] ([E_Id], [RegNo], [Name], [Email], [Id], [Dates]) VALUES (5, N'1004', N'karim', N'karim@gmail.com', 0, N'1/1/0001 12:00:00 AM')
INSERT [dbo].[tbl_Enrols] ([E_Id], [RegNo], [Name], [Email], [Id], [Dates]) VALUES (6, N'1005', N'Electronic', N'dolar125@gmail.com', 0, N'1/1/0001 12:00:00 AM')
INSERT [dbo].[tbl_Enrols] ([E_Id], [RegNo], [Name], [Email], [Id], [Dates]) VALUES (7, N'1005', N'Electronic', N'dolar125@gmail.com', 0, N'1/1/0001 12:00:00 AM')
INSERT [dbo].[tbl_Enrols] ([E_Id], [RegNo], [Name], [Email], [Id], [Dates]) VALUES (8, N'1004', N'karim', N'karim@gmail.com', 1, N'1/1/0001 12:00:00 AM')
INSERT [dbo].[tbl_Enrols] ([E_Id], [RegNo], [Name], [Email], [Id], [Dates]) VALUES (9, N'1020', N'karim', N'k@gmail.com', 1, N'1/1/0001 12:00:00 AM')
SET IDENTITY_INSERT [dbo].[tbl_Enrols] OFF
SET IDENTITY_INSERT [dbo].[tbl_Grade] ON 

INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (1, N'A+')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (2, N'A')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (3, N'A-')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (4, N'B+')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (5, N'B')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (6, N'B-')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (7, N'C+')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (8, N'C')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (9, N'C-')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (10, N'D+')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (11, N'D')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (12, N'D-')
INSERT [dbo].[tbl_Grade] ([GradeId], [Grade]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[tbl_Grade] OFF
SET IDENTITY_INSERT [dbo].[tbl_Room] ON 

INSERT [dbo].[tbl_Room] ([RoomId], [RoomNo]) VALUES (1, N'A-202')
INSERT [dbo].[tbl_Room] ([RoomId], [RoomNo]) VALUES (2, N'A-203')
INSERT [dbo].[tbl_Room] ([RoomId], [RoomNo]) VALUES (3, N'B-303')
INSERT [dbo].[tbl_Room] ([RoomId], [RoomNo]) VALUES (4, N'B-304')
INSERT [dbo].[tbl_Room] ([RoomId], [RoomNo]) VALUES (5, N'C-404')
INSERT [dbo].[tbl_Room] ([RoomId], [RoomNo]) VALUES (6, N'C-405')
SET IDENTITY_INSERT [dbo].[tbl_Room] OFF
SET IDENTITY_INSERT [dbo].[tbl_Semester] ON 

INSERT [dbo].[tbl_Semester] ([SemID], [SemName]) VALUES (1, N'1st Semester')
INSERT [dbo].[tbl_Semester] ([SemID], [SemName]) VALUES (2, N'2nd Semester')
INSERT [dbo].[tbl_Semester] ([SemID], [SemName]) VALUES (3, N'3rd Semester')
INSERT [dbo].[tbl_Semester] ([SemID], [SemName]) VALUES (4, N'4th Semester')
INSERT [dbo].[tbl_Semester] ([SemID], [SemName]) VALUES (5, N'5th Semester')
INSERT [dbo].[tbl_Semester] ([SemID], [SemName]) VALUES (6, N'6th Semester')
INSERT [dbo].[tbl_Semester] ([SemID], [SemName]) VALUES (7, N'7th Semester')
INSERT [dbo].[tbl_Semester] ([SemID], [SemName]) VALUES (8, N'8th Semester')
SET IDENTITY_INSERT [dbo].[tbl_Semester] OFF
SET IDENTITY_INSERT [dbo].[tbl_SevenDay] ON 

INSERT [dbo].[tbl_SevenDay] ([DayId], [Day]) VALUES (1, N'Sunday')
INSERT [dbo].[tbl_SevenDay] ([DayId], [Day]) VALUES (2, N'Monday')
INSERT [dbo].[tbl_SevenDay] ([DayId], [Day]) VALUES (3, N'Tuesday')
INSERT [dbo].[tbl_SevenDay] ([DayId], [Day]) VALUES (4, N'Wednesday')
INSERT [dbo].[tbl_SevenDay] ([DayId], [Day]) VALUES (5, N'Thursday')
INSERT [dbo].[tbl_SevenDay] ([DayId], [Day]) VALUES (6, N'Friday')
INSERT [dbo].[tbl_SevenDay] ([DayId], [Day]) VALUES (7, N'Saturday')
SET IDENTITY_INSERT [dbo].[tbl_SevenDay] OFF
SET IDENTITY_INSERT [dbo].[tbl_Student] ON 

INSERT [dbo].[tbl_Student] ([St_id], [Name], [Email], [ContactNo], [Dates], [Addres], [RegNo], [Id]) VALUES (1020, N'karim', N'k@gmail.com', N'01735484587', CAST(0xCC3B0B00 AS Date), N'dhaka bangladesh', N'CSE-2016-1', 1)
SET IDENTITY_INSERT [dbo].[tbl_Student] OFF
SET IDENTITY_INSERT [dbo].[tbl_Teacher] ON 

INSERT [dbo].[tbl_Teacher] ([TeachID], [Name], [Address], [Email], [Contact], [DesignationId], [Id], [Credict]) VALUES (1005, N'karim', N'Dhaka Bangladesh', N'karim@gmail.com', N'01735485123', 1, 1, N'10.5')
SET IDENTITY_INSERT [dbo].[tbl_Teacher] OFF
USE [master]
GO
ALTER DATABASE [UniversityCourseandResultDB] SET  READ_WRITE 
GO
