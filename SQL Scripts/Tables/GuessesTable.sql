USE [ColorMeRGB]
GO

/****** Object:  Table [dbo].[GuessesTable]    Script Date: 5/3/2022 10:38:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GuessesTable](
	[id] [uniqueidentifier] NOT NULL,
	[game_id] [uniqueidentifier] NOT NULL,
	[guess_color] [nvarchar](6) NOT NULL,
	[distance] [float] NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[is_correct] [bit] NOT NULL,
 CONSTRAINT [PK_GuessesTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GuessesTable] ADD  CONSTRAINT [DF_GuessesTable_id]  DEFAULT (newid()) FOR [id]
GO

ALTER TABLE [dbo].[GuessesTable]  WITH CHECK ADD  CONSTRAINT [FK_GuessesTable_GamesTable1] FOREIGN KEY([game_id])
REFERENCES [dbo].[GamesTable] ([id])
GO

ALTER TABLE [dbo].[GuessesTable] CHECK CONSTRAINT [FK_GuessesTable_GamesTable1]
GO

