USE [ColorMeRGB]
GO

/****** Object:  StoredProcedure [dbo].[Log]    Script Date: 5/9/2022 2:13:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Owen Ravelo
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Log] 
	-- Add the parameters for the stored procedure here
	@source nvarchar(50), 
	@level nvarchar(10),
	@userid uniqueidentifier = NULL,
	@message nvarchar(max),
	@exception nvarchar(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [ColorMeRGB].[dbo].[Logs] ([timestamp], [source], [user_id], [level], [message], [exception]) 
	VALUES (GetDate(), @source, @userid, @level, @message, @exception);
END
GO

