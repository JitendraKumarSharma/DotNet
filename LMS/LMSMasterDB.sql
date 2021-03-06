USE [master]
GO
/****** Object:  Database [LMSMasterDB]    Script Date: 10/23/2018 1:15:46 PM ******/
CREATE DATABASE [LMSMasterDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LMSMasterDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LMSMasterDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LMSMasterDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LMSMasterDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LMSMasterDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LMSMasterDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LMSMasterDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LMSMasterDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LMSMasterDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LMSMasterDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LMSMasterDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LMSMasterDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LMSMasterDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LMSMasterDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LMSMasterDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LMSMasterDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LMSMasterDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LMSMasterDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LMSMasterDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LMSMasterDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LMSMasterDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LMSMasterDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LMSMasterDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LMSMasterDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LMSMasterDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LMSMasterDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LMSMasterDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LMSMasterDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LMSMasterDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LMSMasterDB] SET RECOVERY FULL 
GO
ALTER DATABASE [LMSMasterDB] SET  MULTI_USER 
GO
ALTER DATABASE [LMSMasterDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LMSMasterDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LMSMasterDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LMSMasterDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LMSMasterDB', N'ON'
GO
USE [LMSMasterDB]
GO
/****** Object:  StoredProcedure [dbo].[Activity]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from mst_Activity
-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[Activity]  --20,'Data','update'
(
@ActivityId INT, 
@Activity   VARCHAR(50) = null,
@Action VARCHAR(20)) 
AS 
begin
	IF( @action = 'add' ) 
	begin
		if not exists(select * from mst_Activity where Activity=@Activity)
		begin
			INSERT INTO mst_Activity (Activity) VALUES (@Activity ) 
			select @@IDENTITY
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	IF( @action = 'update' ) 
	begin
		if not exists(select * from mst_Activity where Activity = @Activity and Activity_Id <> @ActivityId)
		begin
			UPDATE mst_Activity SET Activity = @Activity WHERE Activity_Id = @ActivityId 
			if(@@ROWCOUNT>0)
			begin
				select @ActivityId
			end			
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	IF( @action = 'delete' ) 
	begin
		DELETE FROM mst_Activity WHERE  Activity_Id = @ActivityId
		if(@@ROWCOUNT>0)
		begin
			select @ActivityId
		end
		else
		begin
			-- record not found
			select -1
		end
	end 
end
GO
/****** Object:  StoredProcedure [dbo].[Addupdatedatabase]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================    
-- Author:        
-- Create date:     
-- Description:      
-- =============================================    
CREATE PROCEDURE [dbo].[Addupdatedatabase] (@DatabaseId   INT, 
                                            @ServerName   VARCHAR(50), 
                                            @DatabaseName VARCHAR(50), 
                                            @LoginId      VARCHAR(50), 
                                            @Password     VARCHAR(50), 
                                            @Action       VARCHAR(20)) 
AS 
    IF( @action = 'add' ) 
      -- insert record    
      INSERT INTO mst_database 
                  (servername, 
                   databasename, 
                   loginid, 
                   password, 
                   createdon) 
      VALUES      ( @ServerName, 
                    @DatabaseName, 
                    @LoginId, 
                    @Password, 
                    Getdate()) 

    IF( @action = 'update' ) 
      UPDATE mst_database 
      SET    servername = @ServerName, 
             databasename = @DatabaseName, 
             loginid = @LoginId, 
             password = @Password, 
             createdon = Getdate() 
      WHERE  databaseid = @DatabaseId 




GO
/****** Object:  StoredProcedure [dbo].[Addupdateuser]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from mst_Role
--select * from mst_users
-- =============================================   
-- Author:       
-- Create date:    
-- Description:     
-- =============================================   
CREATE  PROCEDURE [dbo].[Addupdateuser] 
(
@UserId           INT, 
@UserName         VARCHAR(100),                                       
@RoleId           INT, 
@Address          VARCHAR(200), 
@EmailId          VARCHAR(100), 
@ContactNo        VARCHAR(20), 
@DatabaseId       INT, 
@password         VARCHAR(100), 
@RegistrationType INT, 
@CreatedBy        INT,
@Action           VARCHAR(20),
@Salt			  Varchar(100)
) 
AS 
begin
	IF( @action = 'add' ) 
	begin
		if not exists(select * from mst_users where emailid = @EmailId)
		begin
			declare @newDBId int
			INSERT INTO mst_users 
			(username, 
			roleid, 
			address, 
			emailid, 
			contactno, 
			DatabaseId,
			password, 
			registrationtype, 
			createdby, 
			createdon,
			Salt) 
		VALUES      
			(@UserName, 
			@RoleId, 
			@Address, 
			@EmailId, 
			@ContactNo, 
			@DatabaseId,
			@password, 
			@RegistrationType, 
			@CreatedBy, 
			Getdate(),
			@Salt)
			set @newDBId = (select @@IDENTITY)
			select @newDBId
			if (@RoleId = 6)
			begin
				declare @newDbName varchar(100) = 'LMS' + convert(varchar(20),@newDBId) + 'OrgDB';
				declare @newDbNameMDF varchar(100);
				declare @newDbNameLDF varchar(100);
				Set @newDbNameMDF = ( select CONCAT('E:\',@newDbName,'.mdf'))
				Set @newDbNameLDF = ( select CONCAT('E:\',@newDbName,'_log.ldf'))
				RESTORE DATABASE @newDbName FROM DISK = 'E:\LMSOrgDB.Bak'
				WITH REPLACE, RECOVERY,
				   MOVE 'leadDB' TO @newDbNameMDF,
				   MOVE 'leadDB_log' TO @newDbNameLDF
				--select @newDbName
			end
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	IF( @action = 'update' ) 
	begin
		if not exists(select * from mst_users where emailid = @EmailId and UserId <> @UserId)
		begin
			UPDATE mst_users 
				SET username = @UserName, 
				roleid = @RoleId, 
				address = @Address, 
				emailid = @EmailId, 
				contactno = @ContactNo, 
				DatabaseId = @DatabaseId,
				password = @password, 
				registrationtype = @RegistrationType, 
				createdby = @CreatedBy, 
				createdon = Getdate(),
				Salt = @Salt 
				where UserId = @UserId
			if(@@ROWCOUNT>0)
			begin
				select @UserId
			end
		end
		else
		begin
			-- already exists
			select 0
		end
	end
end



GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[DeleteUser] 
@UserId INT
AS 
begin
	DELETE FROM Mst_Users WHERE userid = @UserId  
	if(@@ROWCOUNT>0)
	begin
		select @UserId
	end
	else
	begin
		-- record not found
		select -1
	end

end


GO
/****** Object:  StoredProcedure [dbo].[FAnswer]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[FAnswer] 
(
@FAnswerId INT, 
@FAnswer   VARCHAR(max),
@FQuestionId   int,
@Action VARCHAR(20)
) 
AS 
    IF( @action = 'add' ) 
      -- insert record  
      INSERT INTO TR_FAnswers
                  (FAnswer,FQuestionId) 
      VALUES      ( @FAnswer,@FQuestionId ) 

    IF( @action = 'update' ) 
      UPDATE TR_FAnswers
      SET    FAnswer = @FAnswer 
      WHERE  FAnswerId = @FAnswerId 

    IF( @action = 'delete' ) 
      DELETE FROM TR_FAnswers 
      WHERE  FAnswerId =@FAnswerId




GO
/****** Object:  StoredProcedure [dbo].[Fquestion]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[Fquestion]
 (
 @FQuestionId INT,
 @FQuestion   VARCHAR(max) = null,
 @CreatedBy   INT = null,
 @Action      VARCHAR(20)
 )
AS
	IF( @action = 'add' )
	begin
		if not exists(select * from mst_fquestion where fquestion = @FQuestion)
		begin
			INSERT INTO mst_fquestion (fquestion, createdby, createdon)
					VALUES (@FQuestion, @CreatedBy, Getdate())
			select @@IDENTITY
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	IF( @action = 'update' )
	begin
		if not exists(select * from mst_fquestion where fquestion = @FQuestion and fquestionid <> @FQuestionId)
		begin
			UPDATE mst_fquestion SET fquestion = @FQuestion	WHERE  fquestionid = @FQuestionId
			if(@@ROWCOUNT>0)
			begin
				select @FQuestionId
			end		
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	IF( @action = 'delete' )
	begin
		DELETE FROM mst_fquestion WHERE fquestionid = @FQuestionId
		if(@@ROWCOUNT>0)
		begin
			select @FQuestionId
		end
		else
		begin
			-- record not found
			select -1
		end
	end





GO
/****** Object:  StoredProcedure [dbo].[GetActivity]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:      
-- Create date:
-- Description:
-- =============================================  
CREATE  PROCEDURE [dbo].[GetActivity]
@ActivityId int
AS
begin
	if(@ActivityId=0)
	begin
		SELECT activity_id, activity FROM mst_activity
	end
	else
	begin
		SELECT activity_id, activity FROM mst_activity where activity_id = @ActivityId
	end
end




GO
/****** Object:  StoredProcedure [dbo].[GetFAnswers]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:
-- Description:
-- =============================================  
CREATE PROCEDURE [dbo].[GetFAnswers]
AS
  SELECT
    FAnswerId,
    FAnswer,
    FQuestionId
  FROM TR_FAnswers





GO
/****** Object:  StoredProcedure [dbo].[Getfquestions]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:      
-- Create date:
-- Description:
-- =============================================  
CREATE PROCEDURE [dbo].[Getfquestions]
@FQuestionId int
AS
	if(@FQuestionId = 0)
	begin
		SELECT fquestionid, fquestion, createdon, createdby FROM mst_fquestion
	end
	else
	begin
		SELECT fquestionid, fquestion, createdon, createdby FROM mst_fquestion where fquestionid = @FQuestionId
	end





GO
/****** Object:  StoredProcedure [dbo].[GetLoginDetail]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from Mst_Users
--select * from Mst_role
--exec GetLoginDetail 'aa@aa.com','12345'

CREATE procedure [dbo].[GetLoginDetail]
@EmailId varchar(100)
as
begin
	SELECT u.userid, 
           u.username, 
           u.roleid, 
           u.address, 
           u.emailid, 
           u.contactno, 
           u.password, 
           u.registrationtype, 
		   u.DatabaseId,
           rt.regtype, 
           r.role, 
           u.createdby, 
           u.createdon, 
		   u.Salt
    FROM   mst_users u 
           JOIN mst_role r 
             ON u.roleid = r.roleid 
           JOIN mst_registrationtype rt 
             ON u.registrationtype = rt.regtypeid where u.EmailId=@EmailId
end
GO
/****** Object:  StoredProcedure [dbo].[Getmsgrequesttype]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:      
-- Create date:  
-- Description:
-- =============================================  
CREATE PROCEDURE [dbo].[Getmsgrequesttype]
@MsgTypeId int
AS
	if(@MsgTypeId = 0)
	begin
		SELECT msgtypeid, msgrequesttype FROM mst_msgrequesttype
	end
	else
	begin
		SELECT msgtypeid, msgrequesttype FROM mst_msgrequesttype where msgtypeid = @MsgTypeId
	end




GO
/****** Object:  StoredProcedure [dbo].[GetRegistrationType]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:      
-- Create date:  
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[GetRegistrationType]
@RegTypeId int
AS
	if(@RegTypeId = 0)
	begin
		SELECT regtypeid, regtype FROM mst_registrationtype 
	end
	else
	begin
		SELECT regtypeid, regtype FROM mst_registrationtype where regtypeid = @RegTypeId
	end


GO
/****** Object:  StoredProcedure [dbo].[GetRole]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:      
-- Create date:10-03-2018   
-- Description:View role detail    
-- =============================================  
CREATE PROCEDURE [dbo].[GetRole] 
@RoleId int
AS 
	if(@RoleId = 0)
	begin
		Select roleid, role from Mst_Role
	end
	else
	begin
		Select roleid, role from Mst_Role where RoleId = @RoleId
	end


GO
/****** Object:  StoredProcedure [dbo].[GetUserRequestStatus]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:
-- Description:
-- =============================================  
CREATE PROCEDURE [dbo].[GetUserRequestStatus]
AS
  SELECT
    r.RequestId,
    r.Status,
    r.OrgId,
    u.UserName,
    r.CreatedOn
  FROM TR_UserRequestStatus r
  JOIN Mst_Users u
    ON r.OrgId = u.UserId





GO
/****** Object:  StoredProcedure [dbo].[Getusers]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================   
-- Author:       
-- Create date:  
-- Description:   
-- =============================================   
CREATE PROCEDURE [dbo].[Getusers] 
@UserId int
AS 
	if(@UserId = 0)
	begin
    SELECT u.userid, 
           u.username, 
           u.roleid, 
           u.address, 
           u.emailid, 
           u.contactno, 
           u.password, 
           u.registrationtype, 
           rt.regtype, 
           r.role, 
           u.createdby, 
           u.createdon 
    FROM   mst_users u 
           JOIN mst_role r 
             ON u.roleid = r.roleid 
           JOIN mst_registrationtype rt 
             ON u.registrationtype = rt.regtypeid 
	end
	else
	begin
		SELECT u.userid, 
           u.username, 
           u.roleid, 
           u.address, 
           u.emailid, 
           u.contactno, 
           u.password, 
           u.registrationtype, 
           rt.regtype, 
           r.role, 
           u.createdby, 
           u.createdon 
    FROM   mst_users u 
           JOIN mst_role r 
             ON u.roleid = r.roleid 
           JOIN mst_registrationtype rt 
             ON u.registrationtype = rt.regtypeid where u.userid = @UserId
	end




GO
/****** Object:  StoredProcedure [dbo].[MsgRequestType]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[MsgRequestType] 
(
@MsgTypeId INT, 
@MsgRequestType   VARCHAR(50) = null,
@Action VARCHAR(20)
) 
AS 
	IF( @action = 'add' ) 
	begin
		if not exists(select * from Mst_MsgRequestType where MsgRequestType = @MsgRequestType)
		begin
			INSERT INTO Mst_MsgRequestType(MsgRequestType) VALUES (@MsgRequestType) 
			select @@IDENTITY
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	IF( @action = 'update' ) 
	begin
		if not exists(select * from Mst_MsgRequestType where MsgRequestType = @MsgRequestType and MsgTypeId <> @MsgTypeId)
		begin
			UPDATE Mst_MsgRequestType SET MsgRequestType = @MsgRequestType WHERE MsgTypeId = @MsgTypeId
			if(@@ROWCOUNT>0)
			begin
				select @MsgTypeId
			end		
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	IF( @action = 'delete' ) 
	begin
		DELETE FROM Mst_MsgRequestType WHERE MsgTypeId = @MsgTypeId
		if(@@ROWCOUNT>0)
		begin
			select @MsgTypeId
		end
		else
		begin
			-- record not found
			select -1
		end
	end



GO
/****** Object:  StoredProcedure [dbo].[RegistrationType]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[RegistrationType] 
(
@RegTypeId INT, 
@RegType  VARCHAR(50) = null,
@Action VARCHAR(20)) 
AS 
	-- insert record  
    IF( @action = 'add' ) 
	begin
		if not exists(select * from Mst_RegistrationType where RegType = @RegType)
		begin
			INSERT INTO Mst_RegistrationType (RegType) VALUES ( @RegType) 
			select @@IDENTITY
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	-- update record
    IF( @action = 'update' ) 
    begin
		if not exists(select * from Mst_RegistrationType where RegType=@RegType and RegTypeId<>@RegTypeId)
		begin
			UPDATE Mst_RegistrationType SET RegType = @RegType WHERE  RegTypeId = @RegTypeId 
			if(@@ROWCOUNT>0)
			begin
				select @RegTypeId
			end			
		end
		else
		begin
			-- already exists
			select 0
		end
	end 


	-- delete record
    IF( @action = 'delete' ) 
	begin
      DELETE FROM Mst_RegistrationType  WHERE RegTypeId = @RegTypeId  
	  if(@@ROWCOUNT>0)
		begin
			select @RegTypeId
		end
		else
		begin
			-- record not found
			select -1
		end
	end



GO
/****** Object:  StoredProcedure [dbo].[Role]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from mst_role
-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[Role] 
(
@RoleId INT, 
@Role   VARCHAR(50) = null,
@Action VARCHAR(20)) 
AS 
begin	
	-- insert record  
	IF( @action = 'add' ) 
	begin      
		if not exists(select * from Mst_Role where Role=@Role)
		begin
			INSERT INTO mst_role (role) VALUES ( @role ) 
			select @@IDENTITY
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	-- update record
	IF( @action = 'update' )
	begin 
		if not exists(select * from Mst_Role where Role=@Role and RoleId<>@RoleId)
		begin
			UPDATE mst_role SET role = @role WHERE  roleid = @RoleId 
			if(@@ROWCOUNT>0)
			begin
				select @RoleId
			end			
		end
		else
		begin
			-- already exists
			select 0
		end
	end

	-- delete record
	IF( @action = 'delete' )
	begin
		DELETE FROM mst_role WHERE  roleid = @RoleId 
		if(@@ROWCOUNT>0)
		begin
			select @RoleId
		end
		else
		begin
			-- record not found
			select -1
		end
	end
end


GO
/****** Object:  StoredProcedure [dbo].[UserRequestStatus]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================  
-- Author:      
-- Create date:   
-- Description:    
-- =============================================  
CREATE PROCEDURE [dbo].[UserRequestStatus] (@RequestId int,
@Status varchar(50),
@OrgId int,
@Action varchar(20))
AS
  IF (@action = 'add')
    -- insert record  
    INSERT INTO TR_UserRequestStatus (Status, OrgId, CreatedOn)
      VALUES (@Status, @OrgId, GETDATE())

  IF (@action = 'update')
    UPDATE TR_UserRequestStatus
    SET status = @Status,
        OrgId = @OrgId
    WHERE RequestId = @RequestId

  IF (@action = 'delete')
    DELETE FROM TR_UserRequestStatus
    WHERE RequestId = @RequestId




GO
/****** Object:  Table [dbo].[Mst_Activity]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Activity](
	[Activity_Id] [int] IDENTITY(1,1) NOT NULL,
	[Activity] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Mst_Activity] PRIMARY KEY CLUSTERED 
(
	[Activity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_Database]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Database](
	[DatabaseId] [int] IDENTITY(1,1) NOT NULL,
	[ServerName] [varchar](50) NOT NULL,
	[DatabaseName] [varchar](50) NOT NULL,
	[LoginId] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Mst_Database] PRIMARY KEY CLUSTERED 
(
	[DatabaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_FQuestion]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_FQuestion](
	[FQuestionId] [int] IDENTITY(1,1) NOT NULL,
	[FQuestion] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Mst_FQuestion] PRIMARY KEY CLUSTERED 
(
	[FQuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_MsgRequestType]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_MsgRequestType](
	[MsgTypeId] [int] IDENTITY(1,1) NOT NULL,
	[MsgRequestType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Mst_MsgRequestType] PRIMARY KEY CLUSTERED 
(
	[MsgTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_RegistrationType]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_RegistrationType](
	[RegTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RegType] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Mst_RegistrationType] PRIMARY KEY CLUSTERED 
(
	[RegTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_Role]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Mst_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_Users]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Address] [varchar](200) NULL,
	[EmailId] [varchar](100) NOT NULL,
	[ContactNo] [varchar](20) NOT NULL,
	[DatabaseId] [int] NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[RegistrationType] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[Salt] [varchar](100) NULL,
 CONSTRAINT [PK_Mst_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TR_FAnswers]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TR_FAnswers](
	[FAnswerId] [int] IDENTITY(1,1) NOT NULL,
	[FAnswer] [varchar](max) NOT NULL,
	[FQuestionId] [int] NOT NULL,
 CONSTRAINT [PK_Mst_FAsnswers] PRIMARY KEY CLUSTERED 
(
	[FAnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TR_UserRequestStatus]    Script Date: 10/23/2018 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TR_UserRequestStatus](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[OrgId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_TR_UserRequestStatus] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Mst_Activity] ON 

INSERT [dbo].[Mst_Activity] ([Activity_Id], [Activity]) VALUES (1, N'View')
INSERT [dbo].[Mst_Activity] ([Activity_Id], [Activity]) VALUES (2, N'download')
INSERT [dbo].[Mst_Activity] ([Activity_Id], [Activity]) VALUES (4, N'Data')
INSERT [dbo].[Mst_Activity] ([Activity_Id], [Activity]) VALUES (5, N'view11')
INSERT [dbo].[Mst_Activity] ([Activity_Id], [Activity]) VALUES (6, N'jkljkl')
INSERT [dbo].[Mst_Activity] ([Activity_Id], [Activity]) VALUES (7, N'View112')
SET IDENTITY_INSERT [dbo].[Mst_Activity] OFF
SET IDENTITY_INSERT [dbo].[Mst_FQuestion] ON 

INSERT [dbo].[Mst_FQuestion] ([FQuestionId], [FQuestion], [CreatedOn], [CreatedBy]) VALUES (2, N'Rest111111', CAST(0x0000A97D010A57C1 AS DateTime), 0)
INSERT [dbo].[Mst_FQuestion] ([FQuestionId], [FQuestion], [CreatedOn], [CreatedBy]) VALUES (3, N'Rest', CAST(0x0000A97D010A5F62 AS DateTime), 0)
INSERT [dbo].[Mst_FQuestion] ([FQuestionId], [FQuestion], [CreatedOn], [CreatedBy]) VALUES (5, N'Rest222', CAST(0x0000A9810129291D AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Mst_FQuestion] OFF
SET IDENTITY_INSERT [dbo].[Mst_MsgRequestType] ON 

INSERT [dbo].[Mst_MsgRequestType] ([MsgTypeId], [MsgRequestType]) VALUES (1, N'Issue')
INSERT [dbo].[Mst_MsgRequestType] ([MsgTypeId], [MsgRequestType]) VALUES (2, N'Request')
SET IDENTITY_INSERT [dbo].[Mst_MsgRequestType] OFF
SET IDENTITY_INSERT [dbo].[Mst_RegistrationType] ON 

INSERT [dbo].[Mst_RegistrationType] ([RegTypeId], [RegType]) VALUES (1, N'Organization')
INSERT [dbo].[Mst_RegistrationType] ([RegTypeId], [RegType]) VALUES (2, N'User')
INSERT [dbo].[Mst_RegistrationType] ([RegTypeId], [RegType]) VALUES (4, N'adfasdfsfsdfsdf')
SET IDENTITY_INSERT [dbo].[Mst_RegistrationType] OFF
SET IDENTITY_INSERT [dbo].[Mst_Role] ON 

INSERT [dbo].[Mst_Role] ([RoleId], [Role]) VALUES (1, N'Clerk1')
INSERT [dbo].[Mst_Role] ([RoleId], [Role]) VALUES (2, N'Employee')
INSERT [dbo].[Mst_Role] ([RoleId], [Role]) VALUES (3, N'Manager')
INSERT [dbo].[Mst_Role] ([RoleId], [Role]) VALUES (5, N'Admin')
INSERT [dbo].[Mst_Role] ([RoleId], [Role]) VALUES (6, N'Organization')
INSERT [dbo].[Mst_Role] ([RoleId], [Role]) VALUES (7, N'User')
INSERT [dbo].[Mst_Role] ([RoleId], [Role]) VALUES (8, N'sdfsdfsdf')
SET IDENTITY_INSERT [dbo].[Mst_Role] OFF
SET IDENTITY_INSERT [dbo].[Mst_Users] ON 

INSERT [dbo].[Mst_Users] ([UserId], [UserName], [RoleId], [Address], [EmailId], [ContactNo], [DatabaseId], [Password], [RegistrationType], [CreatedOn], [CreatedBy], [Salt]) VALUES (1, N'Amrish23423asda', 6, N'Kanpur', N'c3qc@cc.com', N'9874563210', 1, N'D5-36-FF-1B-AE-EF-53-69-49-02-09-EA-E4-C1-9F-20', 2, CAST(0x0000A97A00FE84AB AS DateTime), 1, N'M744YL8nBg')
INSERT [dbo].[Mst_Users] ([UserId], [UserName], [RoleId], [Address], [EmailId], [ContactNo], [DatabaseId], [Password], [RegistrationType], [CreatedOn], [CreatedBy], [Salt]) VALUES (2, N'Amrish23423asdasdfsdfsdasdfasdf', 6, N'Kanpur', N'c3q2c@cc.com', N'9874563210', 1, N'00-CE-96-FB-B9-61-88-72-60-C6-56-11-D4-84-07-4A', 2, CAST(0x0000A97A010B27CF AS DateTime), 1, N'mZszNYxrRb')
INSERT [dbo].[Mst_Users] ([UserId], [UserName], [RoleId], [Address], [EmailId], [ContactNo], [DatabaseId], [Password], [RegistrationType], [CreatedOn], [CreatedBy], [Salt]) VALUES (3, N'Rahul22', 5, N'Lucknow', N'rahul@rr.com', N'1234567890', 2, N'FE-91-1B-73-DD-92-98-A0-54-1C-03-95-69-2F-B5-06', 3, CAST(0x0000A97C012AE483 AS DateTime), 1, N'evti9gDtCe')
INSERT [dbo].[Mst_Users] ([UserId], [UserName], [RoleId], [Address], [EmailId], [ContactNo], [DatabaseId], [Password], [RegistrationType], [CreatedOn], [CreatedBy], [Salt]) VALUES (4, N'Rahul', 5, N'ff', N'fgd', N'dfgdf', 2, N'C6-F5-8D-C1-8F-D0-2F-5C-21-2E-12-C8-B5-02-D5-E8', 2, CAST(0x0000A98100F33297 AS DateTime), 1, N'iJ5a9uTFmx')
SET IDENTITY_INSERT [dbo].[Mst_Users] OFF
ALTER TABLE [dbo].[TR_FAnswers]  WITH CHECK ADD  CONSTRAINT [FK_TR_FAsnswers_Mst_FQuestion] FOREIGN KEY([FQuestionId])
REFERENCES [dbo].[Mst_FQuestion] ([FQuestionId])
GO
ALTER TABLE [dbo].[TR_FAnswers] CHECK CONSTRAINT [FK_TR_FAsnswers_Mst_FQuestion]
GO
USE [master]
GO
ALTER DATABASE [LMSMasterDB] SET  READ_WRITE 
GO
