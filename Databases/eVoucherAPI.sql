use master
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'eVoucher')
BEGIN
CREATE DATABASE [eVoucher]

END
GO
----You need to check if the table exists
--IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TableName' and xtype='U')
--BEGIN
--    CREATE TABLE TableName (
--        Id INT PRIMARY KEY IDENTITY (1, 1),
--        Name VARCHAR(100)
--    )
--END

USE [eVoucher]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2023/04/27 下午 04:03:18 ******/
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
	[UserID] [uniqueidentifier] NULL, 
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Campaign]    Script Date: 2023/04/27 下午 04:03:18 ******/
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
 CONSTRAINT [PK_Campaign_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CampaignGame]    Script Date: 2023/04/27 下午 04:03:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampaignGame](
	[ID] [uniqueidentifier] NOT NULL,
	[Campaign_ID] [uniqueidentifier] NOT NULL,
	[Game_ID] [nchar](10) NOT NULL,
 CONSTRAINT [PK_CampaignGame_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CampaignUser]    Script Date: 2023/04/27 下午 04:03:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampaignUser](
	[ID] [uniqueidentifier] NOT NULL,
	[User_ID] [uniqueidentifier] NOT NULL,
	[Campaign_ID] [uniqueidentifier] NOT NULL,
	[JoinDate] [datetime] NULL,
 CONSTRAINT [PK_CampaignUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Game]    Script Date: 2023/04/27 下午 04:03:18 ******/
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
 CONSTRAINT [PK_Game_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Partner]    Script Date: 2023/04/27 下午 04:03:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partner](
	[ID] [uniqueidentifier] NOT NULL,
	[User_ID] [uniqueidentifier] NOT NULL,
	[CompanyName] [nvarchar](200) NULL,
	[Description] [nvarchar](200) NULL,
	[CompanyEmailAddress] [nvarchar](50) NULL,
	[CompanyPhone] [varchar](12) NULL,
	[CompanyAddess] [uniqueidentifier] NULL,
	[Image] [image] NULL,
	[JoinDate] [datetime] NULL,
	[Type] [tinyint] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Partner_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2023/04/27 下午 04:03:18 ******/
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
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 2023/04/27 下午 04:03:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroupLink]    Script Date: 2023/04/27 下午 04:03:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupLink](
	[ID] [uniqueidentifier] NOT NULL,
	[UserGroup_ID] [uniqueidentifier] NOT NULL,
	[User_ID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserGroupLink_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 2023/04/27 下午 04:03:18 ******/
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
	[Game_ID] [uniqueidentifier] NULL,
	[Type] [tinyint] NULL,
	[LimitAmount] [money] NULL,
	[Quantity] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VoucherUsed]    Script Date: 2023/04/27 下午 04:03:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoucherUsed](
	[ID] [uniqueidentifier] NOT NULL,
	[User_ID] [uniqueidentifier] NULL,
	[ReceivedDate] [datetime] NULL,
	[IsUsed] [bit] NULL,
	[UsedDate] [datetime] NULL,
 CONSTRAINT [PK_VoucherUsed] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
