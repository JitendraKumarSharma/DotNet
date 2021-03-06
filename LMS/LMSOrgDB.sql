USE [master]
GO
/****** Object:  Database [LMSOrgDB]    Script Date: 10/23/2018 1:16:19 PM ******/
CREATE DATABASE [LMSOrgDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'leadDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\leadDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'leadDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\leadDB_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LMSOrgDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LMSOrgDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LMSOrgDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LMSOrgDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LMSOrgDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LMSOrgDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LMSOrgDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LMSOrgDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LMSOrgDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LMSOrgDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LMSOrgDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LMSOrgDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LMSOrgDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LMSOrgDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LMSOrgDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LMSOrgDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LMSOrgDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LMSOrgDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LMSOrgDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LMSOrgDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LMSOrgDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LMSOrgDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LMSOrgDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LMSOrgDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LMSOrgDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LMSOrgDB] SET RECOVERY FULL 
GO
ALTER DATABASE [LMSOrgDB] SET  MULTI_USER 
GO
ALTER DATABASE [LMSOrgDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LMSOrgDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LMSOrgDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LMSOrgDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LMSOrgDB', N'ON'
GO
USE [LMSOrgDB]
GO
/****** Object:  StoredProcedure [dbo].[AddUpdateEmailHistory]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[AddUpdateEmailHistory] 
(
@EId int,
@EmailSubject varchar(50),
@EmailId varchar(50),
@UserId int,
@ResponseStatus varchar(20),
@Action varchar(20))
AS
  IF (@action = 'add')
    -- insert record  
    INSERT INTO TR_EmailHistory(EmailSubject, EmailId, UserId, ResponseStatus, SendDate)
      VALUES (@EmailSubject, @EmailId, @UserId, @ResponseStatus, GETDATE())

  IF (@action = 'update')
    UPDATE TR_EmailHistory
    SET 
        UserId = @UserId,
        EmailSubject = @EmailSubject,
        ResponseStatus = @ResponseStatus,
		EmailId=@EmailId

    WHERE EId = @EId


GO
/****** Object:  StoredProcedure [dbo].[AddUpdateLeads]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[AddUpdateLeads] (@LeadId int,
@FirstName varchar(50),
@LastName varchar(50),
@Title varchar(50),
@Salutition varchar(50),
@email varchar(50),
@Phone varchar(20),
@Mobile varchar(20),
@company varchar(50),
@CompanyDunSNo varchar(50),
@NoOfEmployee varchar(20),
@website varchar(50),
@industry varchar(50),
@state varchar(20),
@city varchar(50),
@StreetNumber varchar(50),
@ZipCode varchar(20),
@AnnualRevenue varchar(50),
@LoadSource varchar(50),
@Rating varchar(10),
@Remark varchar(200),
@CreatedBy int,
@AccessBy int,
@Action varchar(20))
AS
  IF (@action = 'add')
    -- insert record  
    INSERT INTO TR_Leads (FirstName,
    LastName,
    Title,
    Salutation,
    email,
    Phone,
    MobileNo,
    company,
    CompanyDunSNo,
    NumberOfEmployee,
    website,
    industry,
    state,
    city,
    StreetNumber,
    ZipCode,
    AnnualRevenue,
    LoadSource,
    Rating,
    Remark,
    createdby,
    AccessBy,
    createdon)
      VALUES (@FirstName, @LastName, @Title, @Salutition, @email, @Phone, @Mobile, @company, @CompanyDunSNo, @NoOfEmployee, @website, @industry, @state, @city, @StreetNumber, @ZipCode, @AnnualRevenue, @LoadSource, @Rating, @Remark, @CreatedBy, @AccessBy, GETDATE())

  IF (@action = 'update')
    UPDATE TR_Leads
    SET FirstName = @FirstName,
        LastName = @LastName,
        Title = @Title,
        Salutation = @Salutition,
        email = @email,
        Phone = @Phone,
        MobileNo = @Mobile,
        company = @company,
        CompanyDunSNo = @CompanyDunSNo,
        NumberOfEmployee = @NoOfEmployee,
        website = @website,
        industry = @industry,
        state = @state,
        city = @city,
        StreetNumber = @StreetNumber,
        ZipCode = @ZipCode,
        AnnualRevenue = @AnnualRevenue,
        LoadSource = @LoadSource,
        Rating = @Rating,
        Remark = @Remark,
        AccessBy = @AccessBy
    WHERE LeadId = @LeadId






GO
/****** Object:  StoredProcedure [dbo].[AddUpdateLeadTransfer]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[AddUpdateLeadTransfer] (@LeadTransferId int,
@LeadId int,
@CreatedBy int,
@UserId int,
@status varchar(20),
@Action varchar(20))
AS
  IF (@action = 'add')
    -- insert record  
    INSERT INTO TR_LeadTransfer (LeadId,
    CreatedBy,
    UserId,
    status,
    createdon)
      VALUES (@LeadId, @CreatedBy, @UserId, @status, GETDATE())

  IF (@action = 'update')
    UPDATE TR_LeadTransfer
    SET UserId = @UserId,
        status = @status
    WHERE LeadTransferId = @LeadTransferId





GO
/****** Object:  StoredProcedure [dbo].[AddUpdateMsgRequestType]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[AddUpdateMsgRequestType] (@MsgRequestId int,
@UserId int,
@Message varchar(max),
@MessageTypeId int,
@ProcessStatus varchar(20),
@Action varchar(20))
AS
  IF (@action = 'add')
    -- insert record  
    INSERT INTO TR_MsgRequestType (UserId, Msg, MsgTypeId, ProcessStatus, createdon)
      VALUES (@UserId, @Message, @MessageTypeId, @ProcessStatus, GETDATE())

  IF (@action = 'update')
    UPDATE TR_MsgRequestType
    SET Msg = @Message,
        UserId = @UserId,
        MsgTypeId = @MessageTypeId,
        ProcessStatus = @ProcessStatus
    WHERE MsgReqstId = @MsgRequestId

GO
/****** Object:  StoredProcedure [dbo].[DeleteEmailHistory]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[DeleteEmailHistory] (@EId int)
AS

  DELETE FROM TR_EmailHistory
  WHERE EId = @EId


GO
/****** Object:  StoredProcedure [dbo].[DeleteLeads]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE  PROCEDURE [dbo].[DeleteLeads] (@LeadId int)
AS

  DELETE FROM TR_Leads
  WHERE LeadId = @LeadId



GO
/****** Object:  StoredProcedure [dbo].[DeleteLeadTransfer]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE  PROCEDURE [dbo].[DeleteLeadTransfer] (@LeadTransferId int)
AS

  DELETE FROM TR_LeadTransfer
  WHERE LeadTransferId = @LeadTransferId




GO
/****** Object:  StoredProcedure [dbo].[DeleteMsgRequestType]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[DeleteMsgRequestType] (@MsgRequestId int)
AS
  DELETE FROM TR_MsgRequestType
  WHERE MsgReqstId = @MsgRequestId

GO
/****** Object:  StoredProcedure [dbo].[Document]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE  PROCEDURE [dbo].[Document]
 (
 @DocumentId   INT,
 @DocumentPath nVARCHAR(200),
 @CreatedBy    INT,
 @Action       VARCHAR(20)
 )
AS
begin
	IF( @action = 'add' )
	begin
		INSERT INTO mst_document (documentpath, createdby, createdon)
						VALUES (@DocumentPath, @CreatedBy, Getdate())
		if(@@ROWCOUNT>0)
			select @@IDENTITY
	end

	IF( @action = 'update' )
	begin
		UPDATE mst_document	SET documentpath = @DocumentPath
		WHERE documentid = @DocumentId
		if(@@ROWCOUNT>0)
			select @DocumentId
		else
			select -1 ---- record not found
	end

	IF( @action = 'delete' )
	begin
		DELETE FROM mst_document WHERE documentid = @DocumentId
		if(@@ROWCOUNT>0)
			select @DocumentId
		else
			select -1 ---- record not found
	end
end


GO
/****** Object:  StoredProcedure [dbo].[DocumentAssign]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[DocumentAssign] (@DocAssignId int,
@UserId int,
@DocumentId int,
@Action varchar(20))
AS
begin
	IF (@action = 'add')
	begin
		if not exists(select * from TR_DocumentAssign where UserId=@UserId and DocumentId=@DocumentId)
		begin
			INSERT INTO TR_DocumentAssign (UserId, DocumentId) VALUES (@UserId, @DocumentId)
			select @@IDENTITY
		end
		else
		begin
			-- already exists
			select 0
		end 
	end

	IF (@action = 'update')
	begin
		if not exists(select * from TR_DocumentAssign where UserId=@UserId and DocumentId=@DocumentId and DocAssignId <> @DocAssignId)
		begin
			UPDATE TR_DocumentAssign SET DocumentId = @DocumentId, UserId = @UserId WHERE DocAssignId = @DocAssignId
			select @DocAssignId
		end
		else
		begin
			-- already exists
			select 0
		end  
	end

	IF (@action = 'delete')
	begin
		DELETE FROM TR_DocumentAssign WHERE DocAssignId = @DocAssignId
		if(@@ROWCOUNT>0)
			select @DocAssignId
		else
			select -1
	end
end
GO
/****** Object:  StoredProcedure [dbo].[GetDocumentAssign]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:      
-- Create date:
-- Description:
-- =============================================  
CREATE PROCEDURE [dbo].[GetDocumentAssign]
AS
  SELECT
    da.docAssignId,
    d.documentPath,
    u.username
  FROM TR_DocumentAssign da
  JOIN LMSMasterdb..mst_Users u
    ON da.UserId = u.UserId
  JOIN Mst_Document d
    ON da.DocumentId = d.DocumentId



GO
/****** Object:  StoredProcedure [dbo].[Getdocuments]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:      
-- Create date:
-- Description:
-- =============================================  
CREATE PROCEDURE [dbo].[Getdocuments]
@DocumentId int
AS
begin
	if(@DocumentId = 0)
	begin
		SELECT documentid, documentpath, createdon, createdby FROM mst_document
	end
	else
	begin
		SELECT documentid, documentpath, createdon, createdby FROM mst_document where documentid = @DocumentId
	end
end
GO
/****** Object:  StoredProcedure [dbo].[GetEmailHistory]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[GetEmailHistory]
AS

  SELECT
    e.Eid,
    e.EmailSubject,
    e.EmailId,
    u.UserName
  FROM TR_EmailHistory e
  JOIN LMSMasterdb..mst_Users u
    ON e.UserId = u.userid


GO
/****** Object:  StoredProcedure [dbo].[GetLeads]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:
-- Description:
-- =============================================  
CREATE PROCEDURE [dbo].[GetLeads]
AS
  SELECT
    l.FirstName,
    l.LastName,
    l.Title,
    l.Salutation,
    l.email,
    l.Phone,
    l.MobileNo,
    l.company,
    l.CompanyDunSNo,
    l.NumberOfEmployee,
    l.Website,
    l.Industry,
    l.state,
    l.city,
    l.StreetNumber,
    l.ZipCode,
    l.AnnualRevenue,
    l.LoadSource,
    l.Rating,
    l.Remark,
    l.createdOn,
    u.username AS createdBy,
    m.username AS AccessBy

  FROM TR_Leads l
  JOIN LMSMasterdb..mst_Users u
    ON l.createdBy = u.userid
  JOIN LMSMasterdb..mst_Users m
    ON l.AccessBy = m.UserId





GO
/****** Object:  StoredProcedure [dbo].[GetLeadTransfer]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================  
-- Author:      
-- Create date:
-- Description:
-- =============================================  
CREATE PROCEDURE [dbo].[GetLeadTransfer]
AS
  SELECT
    l.LeadId,
    u.username AS CreatedBy,
    m.UserName AS UserId,
    l.status,
    l.CreatedOn
  FROM TR_LeadTransfer l
  JOIN LMSMasterdb..mst_Users u
    ON l.createdBy = u.userid
  JOIN LMSMasterdb..mst_Users m
    ON l.Userid = m.UserId






GO
/****** Object:  StoredProcedure [dbo].[GetMsgRequestType]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[GetMsgRequestType]

AS
  SELECT
    m.MsgReqstId,
    m.Msg,
    m.processStatus,
    u.username,
    mr.msgrequesttype
  FROM TR_MsgRequestType m
  JOIN LMSMasterdb..mst_Users u
    ON m.userid = u.userid
  JOIN LMSMasterdb..mst_msgRequestType mr
    ON m.MsgTypeId = mr.msgtypeid

GO
/****** Object:  StoredProcedure [dbo].[GetUserActivity]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:      
-- Create date:
-- Description:
-- =============================================  
CREATE  PROCEDURE [dbo].[GetUserActivity]
AS
  SELECT
    a.UserActivityId,
    a.UserId,
    a.ActivityId,
    a.createdon,
    at.Activity,
    u.userName
  FROM TR_UserActivity a
  JOIN LMSMasterdb..mst_Users u
    ON a.UserId = u.userid
  JOIN LMSMasterdb..mst_Activity at
    ON a.ActivityId = at.Activity_Id



GO
/****** Object:  StoredProcedure [dbo].[UserActivity]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[UserActivity] (@UserActivityId int,
@UserId int,
@ActivityId int,
@Action varchar(20))
AS
  IF (@action = 'add')
    -- insert record  
    INSERT INTO TR_UserActivity (UserId,
    ActivityId,
    createdon)
      VALUES (@ActivityId, @UserId, GETDATE())

  IF (@action = 'update')
    UPDATE TR_UserActivity
    SET ActivityId = @ActivityId,
	  UserId = @UserId
    WHERE UserActivityId = @UserActivityId

  IF (@action = 'delete')
    DELETE FROM TR_UserActivity
    WHERE UserActivityId = @UserActivityId




GO
/****** Object:  Table [dbo].[Mst_Document]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_Document](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentPath] [nvarchar](200) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Mst_Document] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TR_DocumentAssign]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TR_DocumentAssign](
	[DocAssignId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DocumentId] [int] NOT NULL,
 CONSTRAINT [PK_TR_DocumentAssign] PRIMARY KEY CLUSTERED 
(
	[DocAssignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TR_EmailHistory]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TR_EmailHistory](
	[EId] [int] IDENTITY(1,1) NOT NULL,
	[EmailSubject] [varchar](50) NOT NULL,
	[EmailId] [varchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[SendDate] [datetime] NOT NULL,
	[ResponseStatus] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TR_EmailHistory] PRIMARY KEY CLUSTERED 
(
	[EId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TR_Leads]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TR_Leads](
	[LeadId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Salutation] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[MobileNo] [varchar](20) NOT NULL,
	[Company] [varchar](50) NOT NULL,
	[CompanyDUNSNo] [varchar](50) NOT NULL,
	[NumberOfEmployee] [varchar](20) NOT NULL,
	[Website] [varchar](50) NOT NULL,
	[Industry] [varchar](50) NOT NULL,
	[State] [varchar](20) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[StreetNumber] [varchar](10) NOT NULL,
	[ZipCode] [varchar](20) NOT NULL,
	[AnnualRevenue] [varchar](50) NOT NULL,
	[LoadSource] [varchar](50) NOT NULL,
	[Rating] [varchar](10) NOT NULL,
	[Remark] [varchar](200) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[AccessBy] [int] NOT NULL,
 CONSTRAINT [PK_TR_Leads] PRIMARY KEY CLUSTERED 
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TR_LeadTransfer]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TR_LeadTransfer](
	[LeadTransferId] [int] IDENTITY(1,1) NOT NULL,
	[LeadId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Status] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TR_LeadTransfer] PRIMARY KEY CLUSTERED 
(
	[LeadTransferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TR_MsgRequestType]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TR_MsgRequestType](
	[MsgReqstId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Msg] [varchar](max) NOT NULL,
	[MsgTypeId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ProcessStatus] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TR_MsgRequestType] PRIMARY KEY CLUSTERED 
(
	[MsgReqstId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TR_UserActivity]    Script Date: 10/23/2018 1:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TR_UserActivity](
	[UserActivityId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ActivityId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_TR_UserActivity] PRIMARY KEY CLUSTERED 
(
	[UserActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Mst_Document] ON 

INSERT [dbo].[Mst_Document] ([DocumentId], [DocumentPath], [CreatedOn], [CreatedBy]) VALUES (2, N'test1.csv', CAST(0x0000A96E00FEF8AD AS DateTime), 2)
INSERT [dbo].[Mst_Document] ([DocumentId], [DocumentPath], [CreatedOn], [CreatedBy]) VALUES (5, N'2018_10_17_17_7_29_69_DemoSchool.sql', CAST(0x0000A97B00C86C3D AS DateTime), 3)
INSERT [dbo].[Mst_Document] ([DocumentId], [DocumentPath], [CreatedOn], [CreatedBy]) VALUES (6, N'2018_10_16_12_13_15_547_download.png', CAST(0x0000A97B00C966BD AS DateTime), 3)
INSERT [dbo].[Mst_Document] ([DocumentId], [DocumentPath], [CreatedOn], [CreatedBy]) VALUES (7, N'2018_10_16_12_13_23_602_lovesove_love_quote_074.jpg', CAST(0x0000A97B00C96F79 AS DateTime), 3)
INSERT [dbo].[Mst_Document] ([DocumentId], [DocumentPath], [CreatedOn], [CreatedBy]) VALUES (8, N'2018_10_17_12_1_6_780_2018-01-16_1541.png', CAST(0x0000A97C00C61262 AS DateTime), 0)
INSERT [dbo].[Mst_Document] ([DocumentId], [DocumentPath], [CreatedOn], [CreatedBy]) VALUES (9, N'2018_10_22_15_30_41_978_config.dev.json', CAST(0x0000A98100FFA0B6 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Mst_Document] OFF
SET IDENTITY_INSERT [dbo].[TR_DocumentAssign] ON 

INSERT [dbo].[TR_DocumentAssign] ([DocAssignId], [UserId], [DocumentId]) VALUES (2, 2, 2)
SET IDENTITY_INSERT [dbo].[TR_DocumentAssign] OFF
SET IDENTITY_INSERT [dbo].[TR_EmailHistory] ON 

INSERT [dbo].[TR_EmailHistory] ([EId], [EmailSubject], [EmailId], [UserId], [SendDate], [ResponseStatus]) VALUES (2, N'Welcome usern', N'admin@gmail.com', 2, CAST(0x0000A96F01141308 AS DateTime), N'Active')
SET IDENTITY_INSERT [dbo].[TR_EmailHistory] OFF
SET IDENTITY_INSERT [dbo].[TR_Leads] ON 

INSERT [dbo].[TR_Leads] ([LeadId], [FirstName], [LastName], [Title], [Salutation], [Email], [Phone], [MobileNo], [Company], [CompanyDUNSNo], [NumberOfEmployee], [Website], [Industry], [State], [City], [StreetNumber], [ZipCode], [AnnualRevenue], [LoadSource], [Rating], [Remark], [CreatedOn], [CreatedBy], [AccessBy]) VALUES (1, N'saas', N'admin', N'test', N'xt', N'sa@gmail.com', N'9485036', N'2145658', N'XyZ', N'12', N'5', N'test.com', N'textile', N'UP', N'lKo', N'54215', N'15647', N'$50000', N'CSV', N'3', N'sst', CAST(0x0000A9730100F80C AS DateTime), 2, 2)
SET IDENTITY_INSERT [dbo].[TR_Leads] OFF
SET IDENTITY_INSERT [dbo].[TR_LeadTransfer] ON 

INSERT [dbo].[TR_LeadTransfer] ([LeadTransferId], [LeadId], [CreatedOn], [CreatedBy], [UserId], [Status]) VALUES (2, 1, CAST(0x0000A97301148564 AS DateTime), 2, 2, N'Access')
SET IDENTITY_INSERT [dbo].[TR_LeadTransfer] OFF
SET IDENTITY_INSERT [dbo].[TR_MsgRequestType] ON 

INSERT [dbo].[TR_MsgRequestType] ([MsgReqstId], [UserId], [Msg], [MsgTypeId], [CreatedOn], [ProcessStatus]) VALUES (1, 2, N'Welcome Admingg', 1, CAST(0x0000A96F00FD2594 AS DateTime), N'Accept')
SET IDENTITY_INSERT [dbo].[TR_MsgRequestType] OFF
SET IDENTITY_INSERT [dbo].[TR_UserActivity] ON 

INSERT [dbo].[TR_UserActivity] ([UserActivityId], [UserId], [ActivityId], [CreatedOn]) VALUES (2, 2, 1, CAST(0x0000A96F00DD03EA AS DateTime))
SET IDENTITY_INSERT [dbo].[TR_UserActivity] OFF
ALTER TABLE [dbo].[TR_DocumentAssign]  WITH CHECK ADD  CONSTRAINT [FK_TR_DocumentAssign_Mst_Document] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Mst_Document] ([DocumentId])
GO
ALTER TABLE [dbo].[TR_DocumentAssign] CHECK CONSTRAINT [FK_TR_DocumentAssign_Mst_Document]
GO
ALTER TABLE [dbo].[TR_LeadTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TR_LeadTransfer_TR_Leads] FOREIGN KEY([LeadId])
REFERENCES [dbo].[TR_Leads] ([LeadId])
GO
ALTER TABLE [dbo].[TR_LeadTransfer] CHECK CONSTRAINT [FK_TR_LeadTransfer_TR_Leads]
GO
USE [master]
GO
ALTER DATABASE [LMSOrgDB] SET  READ_WRITE 
GO
