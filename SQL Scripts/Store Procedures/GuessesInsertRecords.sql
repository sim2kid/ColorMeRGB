USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[GuessesInsertRecords]    Script Date: 5/9/2022 12:53:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: May 2, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GuessesInsertRecords] 
	-- Add the parameters for the stored procedure here
	@GameId uniqueidentifier = null,
	@GuessColor nvarchar(6) = null, 
	@Distance float = null,
	@Timestamp datetime = null,
	@IsCorrect bit = null,
	@ReturnValue uniqueidentifier OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @ReturnValue = NEWID()

	insert into [ColorMeRGB].[dbo].[GuessesTable] ([id], [game_id], [guess_color], [distance], [timestamp], [is_correct])
	values (@ReturnValue, @GameId, @GuessColor, @Distance, @Timestamp, @IsCorrect)
END
GO

