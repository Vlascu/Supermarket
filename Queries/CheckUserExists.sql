USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[CheckUserExists]    Script Date: 16.05.2024 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CheckUserExists]
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @userCount INT;

    -- Count the number of users with the given username and password
    SELECT @userCount = COUNT(*)
    FROM Users
    WHERE Username = @username
    
    -- Return 1 if user exists, 0 if not
    IF @userCount > 0
    BEGIN
        SELECT 1 AS UserExists;
    END
    ELSE
    BEGIN
        SELECT 0 AS UserExists;
    END
END