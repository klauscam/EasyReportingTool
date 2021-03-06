USE [EasyReportingTool]
GO
/****** Object:  User [ertUser]    Script Date: 08/15/2015 18:03:34 ******/
CREATE USER [ertUser] FOR LOGIN [ertUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Query]    Script Date: 08/15/2015 18:03:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Query](
	[GUID] [varchar](50) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sql] [varchar](max) NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[createdon] [datetime] NOT NULL,
	[enabled] [bit] NOT NULL,
	[catalog] [varchar](50) NOT NULL,
	[server] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[url] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Query] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
