USE [ColorMeRGB]
GO

/****** Object:  Table [dbo].[GamesTable]    Script Date: 5/3/2022 10:37:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GamesTable](
	[id] [uniqueidentifier] NOT NULL,
	[user_id] [uniqueidentifier] NOT NULL,
	[answer_color] [nvarchar](6) NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[completed] [bit] NOT NULL,
 CONSTRAINT [PK_GamesTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GamesTable] ADD  CONSTRAINT [DF_GamesTable_id]  DEFAULT (newid()) FOR [id]
GO

ALTER TABLE [dbo].[GamesTable]  WITH CHECK ADD  CONSTRAINT [FK_GamesTable_UsersTable] FOREIGN KEY([user_id])
REFERENCES [dbo].[UsersTable] ([id])
GO

ALTER TABLE [dbo].[GamesTable] CHECK CONSTRAINT [FK_GamesTable_UsersTable]
GO

