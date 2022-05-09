USE [ColorMeRGB]
GO

/****** Object:  Table [dbo].[Logs]    Script Date: 5/9/2022 2:14:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Logs](
	[id] [uniqueidentifier] NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[user_id] [uniqueidentifier] NULL,
	[source] [nvarchar](50) NULL,
	[level] [nvarchar](10) NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_id]  DEFAULT (newid()) FOR [id]
GO

