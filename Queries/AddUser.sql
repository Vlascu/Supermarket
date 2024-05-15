CREATE PROCEDURE AddUser
    @username NVARCHAR(50),
    @password NVARCHAR(50),
    @user_type NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Users(Username, Password, UserType)
    VALUES (@username, @password, @user_type);

    SELECT SCOPE_IDENTITY() AS UserID;
END
