USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[GamesInsertRecords]    Script Date: 5/8/2022 3:03:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: May 2, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GamesInsertRecords] 
	-- Add the parameters for the stored procedure here
	@UserID uniqueidentifier = null,
	@AnswerColor nvarchar(6) = null, 
	@Timestamp datetime = null,
	@Completed bit = null,
	@ReturnValue uniqueidentifier OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @ReturnValue = NEWID()

	insert into [ColorMeRGB].[dbo].[GamesTable] ([id], [user_id], [answer_color], [timestamp], [completed])
	values (@ReturnValue, @UserID, @AnswerColor, @Timestamp, @Completed)

END
GO

