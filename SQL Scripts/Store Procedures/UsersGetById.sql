USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[UsersGetById]    Script Date: 5/3/2022 10:36:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: April 29, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UsersGetById] 
	-- Add the parameters for the stored procedure here
	@ID uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from [ColorMeRGB].[dbo].[User]
	where [id] = @ID
END
GO
