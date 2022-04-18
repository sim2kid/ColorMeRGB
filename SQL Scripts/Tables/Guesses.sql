USE [ColorMeRGB]
GO

/****** Object:  Table [dbo].[Guesses]    Script Date: 4/18/2022 6:16:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Guesses](
	[id] [uniqueidentifier] NOT NULL,
	[game_id] [uniqueidentifier] NOT NULL,
	[answer] [int] NOT NULL,
	[guess] [int] NOT NULL,
	[distance] [float] NOT NULL,
 CONSTRAINT [PK_Guesses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Guesses] ADD  CONSTRAINT [DF_Guesses_id]  DEFAULT (newid()) FOR [id]
GO

ALTER TABLE [dbo].[Guesses]  WITH CHECK ADD  CONSTRAINT [FK_Guesses_Games1] FOREIGN KEY([game_id])
REFERENCES [dbo].[Games] ([id])
GO

ALTER TABLE [dbo].[Guesses] CHECK CONSTRAINT [FK_Guesses_Games1]
GO

