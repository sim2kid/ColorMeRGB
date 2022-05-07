USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[GamesUpdateById]    Script Date: 5/3/2022 10:33:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: May 3, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GamesUpdateById] 
	-- Add the parameters for the stored procedure here
	@GameID uniqueidentifier = null,
	@AnswerColor int = null, 
	@Timestamp datetime = null,
	@Completed bit = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [ColorMeRGB].[dbo].[GamesTable]
	SET [answer_color] = @AnswerColor, [timestamp] = @Timestamp, [completed] = @Completed
	WHERE [id] = @GameID
END
GO

