USE [master]
GO
/****** Object:  Database [TaskTracker]    Script Date: 7/14/2022 10:37:01 AM ******/
CREATE DATABASE [TaskTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\TaskTracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaskTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\TaskTracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TaskTracker] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskTracker] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TaskTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskTracker] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TaskTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskTracker] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TaskTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskTracker] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TaskTracker] SET  MULTI_USER 
GO
ALTER DATABASE [TaskTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskTracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TaskTracker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TaskTracker] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TaskTracker] SET QUERY_STORE = OFF
GO
USE [TaskTracker]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/14/2022 10:37:01 AM ******/
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
/****** Object:  Table [dbo].[Projects]    Script Date: 7/14/2022 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[CompletionDate] [datetime2](7) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 7/14/2022 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Description] [nvarchar](600) NOT NULL,
	[Priority] [int] NOT NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220630184251_InitialModel', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220630192906_OverrideDefaultModelConfigurations', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220630204651_SeedTestingData', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220709183403_DbAutogenerateIdsForNewEntities', N'5.0.17')
GO
INSERT [dbo].[Projects] ([ProjectId], [Name], [StartDate], [CompletionDate], [Status], [Priority]) VALUES (N'5eaaca65-3597-44fd-a92a-43352d0636cd', N'Project_NNN', CAST(N'2022-08-15T14:00:00.0000000' AS DateTime2), CAST(N'2022-08-20T14:00:00.0000000' AS DateTime2), 3, 4)
INSERT [dbo].[Projects] ([ProjectId], [Name], [StartDate], [CompletionDate], [Status], [Priority]) VALUES (N'a43ff7b4-95c0-4915-b1ed-6d028c9ae688', N'Project_4', CAST(N'2022-08-15T14:00:00.0000000' AS DateTime2), CAST(N'2022-08-20T14:00:00.0000000' AS DateTime2), 1, 4)
INSERT [dbo].[Projects] ([ProjectId], [Name], [StartDate], [CompletionDate], [Status], [Priority]) VALUES (N'c2870df6-f1ab-4524-bd9c-75ec47721352', N'Project2', CAST(N'2022-07-02T13:00:00.0000000' AS DateTime2), CAST(N'2022-07-08T13:00:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Projects] ([ProjectId], [Name], [StartDate], [CompletionDate], [Status], [Priority]) VALUES (N'32504d45-34a0-4315-ab00-99caad137b8e', N'Project1', CAST(N'2022-07-01T12:00:00.0000000' AS DateTime2), CAST(N'2022-07-07T12:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Projects] ([ProjectId], [Name], [StartDate], [CompletionDate], [Status], [Priority]) VALUES (N'c2f3eab5-ed1f-474f-add4-b6d14cf69564', N'Project3', CAST(N'2022-07-03T14:00:00.0000000' AS DateTime2), CAST(N'2022-07-09T14:00:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Projects] ([ProjectId], [Name], [StartDate], [CompletionDate], [Status], [Priority]) VALUES (N'13e21fde-6034-440e-afea-bdf319432ed1', N'Project_5', CAST(N'2022-08-16T14:00:00.0000000' AS DateTime2), CAST(N'2022-08-21T14:00:00.0000000' AS DateTime2), 1, 5)
INSERT [dbo].[Projects] ([ProjectId], [Name], [StartDate], [CompletionDate], [Status], [Priority]) VALUES (N'e527582d-043e-4a0d-9279-ecba6c48e18d', N'Project_555', CAST(N'2022-08-15T14:00:00.0000000' AS DateTime2), CAST(N'2022-08-20T14:00:00.0000000' AS DateTime2), 1, 4)
GO
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'2ee99086-6031-4624-b891-034ff894c247', N'Task2', 1, N'Description for Task2', 1, N'32504d45-34a0-4315-ab00-99caad137b8e')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'51f1f31d-1c1f-4b8a-b982-35c73bf5a59a', N'Task3', 1, N'Description for Task3', 1, N'c2870df6-f1ab-4524-bd9c-75ec47721352')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'612ba24a-f8ac-410e-8343-40af1faab47a', N'Task5', 1, N'Description for Task5', 1, N'c2870df6-f1ab-4524-bd9c-75ec47721352')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'4db40b77-6571-4877-9ef3-49fafab54b92', N'completelyNewTask', 2, N'Description for completelyNewTask', 2, N'e527582d-043e-4a0d-9279-ecba6c48e18d')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'f7b84a2a-935b-479a-8b61-678be6844d6e', N'TaskNNN12', 1, N'Description for TaskNNN12', 2, N'5eaaca65-3597-44fd-a92a-43352d0636cd')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'adf2b14a-cd37-4c52-abe5-71e5c8ba1a22', N'Task11', 1, N'Description for Task11', 1, N'a43ff7b4-95c0-4915-b1ed-6d028c9ae688')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'e839eb2f-7bef-4bfd-8399-aa2f3759dae8', N'Task111', 1, N'Description for Task111', 1, N'e527582d-043e-4a0d-9279-ecba6c48e18d')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'ad43e901-7030-4934-8c67-abf24d1fa0e5', N'Task122', 1, N'Description for Task122', 2, N'e527582d-043e-4a0d-9279-ecba6c48e18d')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'aa63cc96-b539-4d5b-8de2-bb9dbb36cab6', N'Task4', 1, N'Description for Task4', 1, N'c2870df6-f1ab-4524-bd9c-75ec47721352')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'916ff0dc-a60a-4552-93c6-c4b7e3f73253', N'TaskNNN11', 1, N'Description for TaskNNN11', 1, N'5eaaca65-3597-44fd-a92a-43352d0636cd')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'a0cce7c0-26f0-4379-9f10-c96912cb12bb', N'Task6', 1, N'Description for Task6', 1, N'c2f3eab5-ed1f-474f-add4-b6d14cf69564')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'a5ded57f-533d-4764-8ad8-e41ca65d2719', N'noviTaskic', 2, N'Description for noviTaskic', 2, N'e527582d-043e-4a0d-9279-ecba6c48e18d')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'2ac3dd2a-261f-4b91-9c09-fa1622cbe192', N'Task1', 1, N'Description for Task1', 1, N'32504d45-34a0-4315-ab00-99caad137b8e')
INSERT [dbo].[Tasks] ([TaskId], [Name], [Status], [Description], [Priority], [ProjectId]) VALUES (N'914328de-d709-4b9c-83d5-fe48b60716a6', N'Task12', 1, N'Description for Task12', 2, N'a43ff7b4-95c0-4915-b1ed-6d028c9ae688')
GO
/****** Object:  Index [IX_Tasks_ProjectId]    Script Date: 7/14/2022 10:37:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_ProjectId] ON [dbo].[Tasks]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT (newid()) FOR [ProjectId]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT (CONVERT([tinyint],(1))) FOR [Status]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((1)) FOR [Priority]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (newid()) FOR [TaskId]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (CONVERT([tinyint],(1))) FOR [Status]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT ((1)) FOR [Priority]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Projects_ProjectId]
GO
USE [master]
GO
ALTER DATABASE [TaskTracker] SET  READ_WRITE 
GO
