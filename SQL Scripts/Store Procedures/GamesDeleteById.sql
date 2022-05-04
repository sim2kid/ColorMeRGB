USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[GamesDeleteById]    Script Date: 5/3/2022 10:32:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: April 29, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GamesDeleteById] 
	-- Add the parameters for the stored procedure here
	@ID uniqueidentifier = null,
	@ReturnValue int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE from [ColorMeRGB].[dbo].[GamesTable]
	Where [id] = @ID
END
GO

