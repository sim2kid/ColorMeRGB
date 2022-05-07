USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[GuessesUpdateById]    Script Date: 5/3/2022 10:35:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: May 3, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GuessesUpdateById] 
	-- Add the parameters for the stored procedure here
	@GuessID uniqueidentifier = null,
	@GuessColor nvarchar(6) = null,
	@Distance float = null,
	@Timestamp datetime = null,
	@IsCorrect bit = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [ColorMeRGB].[dbo].[GuessesTable]
	SET [guess_color] = @GuessColor, [distance] = @Distance, [timestamp] = @Timestamp, [is_correct] = @IsCorrect
	WHERE [id] = @GuessID
END
GO

