USE [master]
GO
/****** Object:  Database [BusinessAdvanceManagement]    Script Date: 19.12.2023 17:37:30 ******/
CREATE DATABASE [BusinessAdvanceManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BusinessAdvanceManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BusinessAdvanceManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BusinessAdvanceManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BusinessAdvanceManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BusinessAdvanceManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BusinessAdvanceManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BusinessAdvanceManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET  MULTI_USER 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BusinessAdvanceManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BusinessAdvanceManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BusinessAdvanceManagement', N'ON'
GO
ALTER DATABASE [BusinessAdvanceManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [BusinessAdvanceManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BusinessAdvanceManagement]
GO
/****** Object:  Table [dbo].[AdvancePayment]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvancePayment](
	[AdvanceID] [int] IDENTITY(1,1) NOT NULL,
	[WorkerID] [int] NULL,
	[ProjectID] [int] NULL,
	[ClaimAmount] [decimal](15, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[DesiredDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_AdvancePayment] PRIMARY KEY CLUSTERED 
(
	[AdvanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvanceRequest]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvanceRequest](
	[AdvanceRequestID] [int] IDENTITY(1,1) NOT NULL,
	[AdvanceRequestStatus] [int] NULL,
	[ApprovingDisapproving] [int] NULL,
	[ApprovalRejectionDate] [datetime] NULL,
	[ConfirmedAmount] [decimal](15, 2) NULL,
	[DeterminedPaymentDate] [datetime] NULL,
	[PaymentMadeDate] [datetime] NULL,
	[RefundStatus] [int] NULL,
	[ApprovingDisapprovingRole] [int] NULL,
	[WorkerID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[Amount] [decimal](15, 2) NULL,
	[ProjectID] [int] NULL,
	[DesiredDate] [datetime] NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_AdvanceRequest] PRIMARY KEY CLUSTERED 
(
	[AdvanceRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvanceRequestDetail]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvanceRequestDetail](
	[AdvanceRequestDetailID] [int] IDENTITY(1,1) NOT NULL,
	[AdvenceRequestID] [int] NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[TransactionOwner] [int] NULL,
	[ConfirmedAmount] [decimal](15, 2) NULL,
	[NextStageUser] [int] NULL,
	[NextStatu] [int] NULL,
 CONSTRAINT [PK_AdvanceRequestDetail] PRIMARY KEY CLUSTERED 
(
	[AdvanceRequestDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvanceRule]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvanceRule](
	[AdvanceRuleID] [int] IDENTITY(1,1) NOT NULL,
	[MinValue] [int] NULL,
	[MaxValue] [int] NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_AdvanceRule] PRIMARY KEY CLUSTERED 
(
	[AdvanceRuleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalOrder]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalOrder](
	[ApprovelOrderID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[ApprovalOrder] [int] NULL,
 CONSTRAINT [PK_ApprovalOrder] PRIMARY KEY CLUSTERED 
(
	[ApprovelOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTable]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTable](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Timestamp] [datetime] NULL,
	[Level] [int] NULL,
	[logger] [int] NULL,
	[message] [nvarchar](max) NULL,
	[Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_LogTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Page]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [varchar](100) NULL,
	[PageController] [varchar](100) NULL,
	[PageAction] [varchar](100) NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PageRole]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageRole](
	[PageID] [int] NULL,
	[RoleID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](100) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefundStatus]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefundStatus](
	[RefoundStatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](100) NULL,
 CONSTRAINT [PK_RefundStatus] PRIMARY KEY CLUSTERED 
(
	[RefoundStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statu]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statu](
	[StatuID] [int] IDENTITY(1,1) NOT NULL,
	[StatuName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Statu] PRIMARY KEY CLUSTERED 
(
	[StatuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitID] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[WorkerID] [int] IDENTITY(1,1) NOT NULL,
	[WorkerRolID] [int] NULL,
	[WorkerManagerID] [int] NULL,
	[WorkerBirimID] [int] NULL,
	[WorkerName] [nvarchar](100) NULL,
	[WorkerSurname] [nvarchar](100) NULL,
	[WorkerEmail] [nvarchar](100) NULL,
	[WorkerPasswordHash] [varbinary](max) NULL,
	[WorkerPasswordSalt] [varbinary](max) NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[WorkerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdvanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequest_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[AdvanceRequest] CHECK CONSTRAINT [FK_AdvanceRequest_Project]
GO
ALTER TABLE [dbo].[AdvanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequest_RefundStatus] FOREIGN KEY([RefundStatus])
REFERENCES [dbo].[RefundStatus] ([RefoundStatusID])
GO
ALTER TABLE [dbo].[AdvanceRequest] CHECK CONSTRAINT [FK_AdvanceRequest_RefundStatus]
GO
ALTER TABLE [dbo].[AdvanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequest_Role] FOREIGN KEY([ApprovingDisapprovingRole])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[AdvanceRequest] CHECK CONSTRAINT [FK_AdvanceRequest_Role]
GO
ALTER TABLE [dbo].[AdvanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequest_Statu] FOREIGN KEY([AdvanceRequestStatus])
REFERENCES [dbo].[Statu] ([StatuID])
GO
ALTER TABLE [dbo].[AdvanceRequest] CHECK CONSTRAINT [FK_AdvanceRequest_Statu]
GO
ALTER TABLE [dbo].[AdvanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequest_Worker] FOREIGN KEY([ApprovingDisapproving])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[AdvanceRequest] CHECK CONSTRAINT [FK_AdvanceRequest_Worker]
GO
ALTER TABLE [dbo].[AdvanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequest_Worker1] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[AdvanceRequest] CHECK CONSTRAINT [FK_AdvanceRequest_Worker1]
GO
ALTER TABLE [dbo].[AdvanceRequestDetail]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequestDetail_AdvanceRequest] FOREIGN KEY([AdvenceRequestID])
REFERENCES [dbo].[AdvanceRequest] ([AdvanceRequestID])
GO
ALTER TABLE [dbo].[AdvanceRequestDetail] CHECK CONSTRAINT [FK_AdvanceRequestDetail_AdvanceRequest]
GO
ALTER TABLE [dbo].[AdvanceRequestDetail]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequestDetail_Statu] FOREIGN KEY([Status])
REFERENCES [dbo].[Statu] ([StatuID])
GO
ALTER TABLE [dbo].[AdvanceRequestDetail] CHECK CONSTRAINT [FK_AdvanceRequestDetail_Statu]
GO
ALTER TABLE [dbo].[AdvanceRequestDetail]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequestDetail_Statu1] FOREIGN KEY([NextStatu])
REFERENCES [dbo].[Statu] ([StatuID])
GO
ALTER TABLE [dbo].[AdvanceRequestDetail] CHECK CONSTRAINT [FK_AdvanceRequestDetail_Statu1]
GO
ALTER TABLE [dbo].[AdvanceRequestDetail]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequestDetail_Worker] FOREIGN KEY([TransactionOwner])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[AdvanceRequestDetail] CHECK CONSTRAINT [FK_AdvanceRequestDetail_Worker]
GO
ALTER TABLE [dbo].[AdvanceRequestDetail]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRequestDetail_Worker1] FOREIGN KEY([NextStageUser])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[AdvanceRequestDetail] CHECK CONSTRAINT [FK_AdvanceRequestDetail_Worker1]
GO
ALTER TABLE [dbo].[AdvanceRule]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceRule_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[AdvanceRule] CHECK CONSTRAINT [FK_AdvanceRule_Role]
GO
ALTER TABLE [dbo].[ApprovalOrder]  WITH CHECK ADD  CONSTRAINT [FK_ApprovalOrder_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[ApprovalOrder] CHECK CONSTRAINT [FK_ApprovalOrder_Role]
GO
ALTER TABLE [dbo].[PageRole]  WITH CHECK ADD  CONSTRAINT [FK_PageRole_Page] FOREIGN KEY([PageID])
REFERENCES [dbo].[Page] ([PageID])
GO
ALTER TABLE [dbo].[PageRole] CHECK CONSTRAINT [FK_PageRole_Page]
GO
ALTER TABLE [dbo].[PageRole]  WITH CHECK ADD  CONSTRAINT [FK_PageRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[PageRole] CHECK CONSTRAINT [FK_PageRole_Role]
GO
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Role] FOREIGN KEY([WorkerRolID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Role]
GO
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Unit] FOREIGN KEY([WorkerBirimID])
REFERENCES [dbo].[Unit] ([UnitID])
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Unit]
GO
/****** Object:  StoredProcedure [dbo].[SP_AdvanceRequestAdd]    Script Date: 19.12.2023 17:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AdvanceRequestAdd]
	@Amount  decimal(15,2),
	@CreatedDate datetime,
	@DesiredDate datetime,
	@ProjectID int,
	@Description varchar(MAX),
	@AdvanceRequestStatus int,
	@WorkerID int,
	@NextStageUser int,
	@NextStatu int,
	@FirstStatus int
AS
BEGIN
	BEGIN TRANSACTION;
		DECLARE @AdvanceRequestID int;

	BEGIN TRY 
		insert into AdvanceRequest (Amount,CreatedDate,DesiredDate,ProjectID,Description,AdvanceRequestStatus,WorkerID) values (@Amount,@CreatedDate,@DesiredDate,@ProjectID,@Description,@AdvanceRequestStatus,@WorkerID)

		SET @AdvanceRequestID = SCOPE_IDENTITY();

		insert into AdvanceRequestDetail (AdvenceRequestID,Status,CreatedDate,TransactionOwner,NextStageUser,NextStatu) values ( @AdvanceRequestID,@FirstStatus,@CreatedDate,@WorkerID,@NextStageUser,@NextStatu) 
		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
	END CATCH
END
GO
USE [master]
GO
ALTER DATABASE [BusinessAdvanceManagement] SET  READ_WRITE 
GO
