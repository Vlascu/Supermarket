CREATE PROCEDURE CheckUserExists
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @userCount INT;

    SELECT @userCount = COUNT(*)
    FROM Users
    WHERE Username = @username
    AND Password = @password;

    IF @userCount > 0
    BEGIN
        SELECT 1 AS UserExists;
    END
    ELSE
    BEGIN
        SELECT 0 AS UserExists;
    END
END