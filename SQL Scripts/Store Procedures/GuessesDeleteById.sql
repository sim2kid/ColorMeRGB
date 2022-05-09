USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[GuessesDeleteById]    Script Date: 5/9/2022 12:52:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: April 29, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GuessesDeleteById] 
	-- Add the parameters for the stored procedure here
	@ID uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE from [ColorMeRGB].[dbo].[GuessesTable]
	where [id] = @ID
END
GO

