USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[GamesGetById]    Script Date: 5/9/2022 12:50:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: April 29, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GamesGetById] 
	-- Add the parameters for the stored procedure here
	@ID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from [ColorMeRGB].[dbo].[GamesTable]
	where [id] = @ID
END
GO

