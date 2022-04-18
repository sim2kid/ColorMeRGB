USE [ColorMeRGB]
GO

/****** Object:  Table [dbo].[Games]    Script Date: 4/18/2022 6:15:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Games](
	[id] [uniqueidentifier] NOT NULL,
	[user_id] [uniqueidentifier] NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[completed] [bit] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Games] ADD  CONSTRAINT [DF_Games_id]  DEFAULT (newid()) FOR [id]
GO

ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_User1] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO

ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_User1]
GO

