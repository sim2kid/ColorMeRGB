USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[UsersUpdateById]    Script Date: 5/9/2022 12:56:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: May 3, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UsersUpdateById] 
	-- Add the parameters for the stored procedure here
	@UserID uniqueidentifier = null,
	@Username nvarchar(max) = null,
	@Password nvarchar(max) = null,
	@Salt nvarchar(128) = null,
	@SignUpTime datetime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [ColorMeRGB].[dbo].[UsersTable]
	SET [username] = @Username, [password] = @Password, [salt] = @Salt, [signup_time] = @SignUpTime
	WHERE [id] = @UserID
END
GO

