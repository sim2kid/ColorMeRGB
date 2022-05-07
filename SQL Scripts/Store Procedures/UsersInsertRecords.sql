USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[UsersInsertRecords]    Script Date: 5/3/2022 10:36:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sebastian Pedersen
-- Create date: May 2, 2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UsersInsertRecords] 
	-- Add the parameters for the stored procedure here
	@Username nvarchar(max) = null, 
	@Password nvarchar(max) = null,
	@Salt nvarchar(128) = null,
	@SignupTime datetime = null,
	@ReturnValue uniqueidentifier OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @ReturnValue = NEWID()

	insert into [ColorMeRGB].[dbo].[UsersTable] ([id], [username], [password], [salt], [signup_time])
	values(@ReturnValue, @Username, @Password, @Salt, @SignupTime)
END
GO

