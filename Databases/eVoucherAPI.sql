USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'eVoucher')
BEGIN
	DROP DATABASE [eVoucher]
END
GO
CREATE DATABASE [eVoucher]
GO
USE [eVoucher]
GO
/****** Object:  Table [dbo].[User] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Phone] [varchar](12) NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[IsActive] [bit] NULL
	PRIMARY KEY (ID)
)
GO

/****** Object:  Table [dbo].[Address] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[ID] [uniqueidentifier] NOT NULL,
	[Street] [varchar](200) NULL,
	[District] [varchar](200) NULL,
	[City] [varchar](200) NULL,
	[Country] [varchar](200) NULL,
	[Type] [tinyint] NULL,
	[IsDeleted] [bit] NULL,
	[User_ID_FK] [uniqueidentifier] NOT NULL
	PRIMARY KEY (ID),
    CONSTRAINT FK_AddressUser FOREIGN KEY (User_ID_FK)
    REFERENCES [User](ID)
	)
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Campaign]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campaign](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[StartedDate] [datetime] NULL,
	[ExpiredDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NULL,
	PRIMARY KEY (ID),
    CONSTRAINT FK_CampaignCreatedBy FOREIGN KEY ([CreatedBy])
    REFERENCES [User](ID),
	CONSTRAINT FK_CampaignModifiedBy FOREIGN KEY (ModifiedBy)
    REFERENCES [User](ID)
)
GO
/****** Object:  Table [dbo].[Game]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NULL,
	PRIMARY KEY (ID),
   CONSTRAINT FK_GameCreatedBy FOREIGN KEY ([CreatedBy])
    REFERENCES [User](ID),
	CONSTRAINT FK_GameModifiedBy FOREIGN KEY (ModifiedBy)
    REFERENCES [User](ID)
)
GO
/****** Object:  Table [dbo].[CampaignGame]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampaignGame](
	[ID] [uniqueidentifier] NOT NULL,
	[Campaign_ID_FK] [uniqueidentifier] NOT NULL,
	[Game_ID_FK] [uniqueidentifier] NOT NULL,
	PRIMARY KEY (ID),
    CONSTRAINT FK_CampaignGameCampaign FOREIGN KEY ([Campaign_ID_FK])
    REFERENCES [Campaign](ID),
	CONSTRAINT FK_CampaignGameGame FOREIGN KEY ([Game_ID_FK])
    REFERENCES [Game](ID)
)
GO
/****** Object:  Table [dbo].[CampaignUser]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampaignUser](
	[ID] [uniqueidentifier] NOT NULL,
	[User_ID_FK] [uniqueidentifier] NOT NULL,
	[Campaign_ID_FK] [uniqueidentifier] NOT NULL,
	[JoinDate] [datetime] NULL,
	PRIMARY KEY (ID),
    CONSTRAINT FK_CampaignUserUser FOREIGN KEY ([User_ID_FK])
    REFERENCES [User](ID),
	CONSTRAINT FK_CampaignUserCampaign FOREIGN KEY ([Campaign_ID_FK])
    REFERENCES [Campaign](ID)
)
GO

GO
/****** Object:  Table [dbo].[Partner]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partner](
	[ID] [uniqueidentifier] NOT NULL,
	[User_ID_FK] [uniqueidentifier] NOT NULL,
	[CompanyName] [nvarchar](200) NULL,
	[Description] [nvarchar](200) NULL,
	[CompanyEmailAddress] [nvarchar](50) NULL,
	[CompanyPhone] [varchar](12) NULL,
	[Image] [image] NULL,
	[JoinDate] [datetime] NULL,
	[Type] [tinyint] NULL,
	[IsActive] [bit] NULL,
	PRIMARY KEY (ID),
    CONSTRAINT FK_PartnerUser FOREIGN KEY ([User_ID_FK])
    REFERENCES [User](ID),
 )

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]  ******/

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroup]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	PRIMARY KEY (ID)
)

GO
/****** Object:  Table [dbo].[UserGroupLink]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupLink](
	[ID] [uniqueidentifier] NOT NULL,
	[UserGroup_ID_FK] [uniqueidentifier] NOT NULL,
	[User_ID_FK] [uniqueidentifier] NOT NULL,
	PRIMARY KEY (ID),
    CONSTRAINT FK_UserGroupLinkUserGroup FOREIGN KEY ([UserGroup_ID_FK])
    REFERENCES [UserGroup](ID),
	CONSTRAINT FK_UserGroupLinkUser FOREIGN KEY ([User_ID_FK])
    REFERENCES [User](ID),
)
GO
/****** Object:  Table [dbo].[Voucher]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Voucher](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NULL,
	[Code] [varchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[AppliedDate] [datetime] NULL,
	[ExpiredDate] [datetime] NULL,
	[Game_ID_FK] [uniqueidentifier] NULL,
	[Type] [tinyint] NULL,
	[LimitAmount] [money] NULL,
	[Quantity] [int] NULL,
	[IsActive] [bit] NULL,
	PRIMARY KEY (ID),
    CONSTRAINT FK_VoucherGame FOREIGN KEY (Game_ID_FK)
    REFERENCES [Game](ID),
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VoucherUsed]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoucherUsed](
	[ID] [uniqueidentifier] NOT NULL,
	[User_ID_FK] [uniqueidentifier] NULL,
	[ReceivedDate] [datetime] NULL,
	[IsUsed] [bit] NULL,
	[UsedDate] [datetime] NULL,
	PRIMARY KEY (ID),
    CONSTRAINT FK_VoucherUsedUser FOREIGN KEY ([User_ID_FK])
    REFERENCES [User](ID),
)

GO
