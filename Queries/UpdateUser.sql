CREATE PROCEDURE UpdateUser
    @username NVARCHAR(50),
    @password NVARCHAR(64), 
    @user_type NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET 
        Password = @password,
        UserType = @user_type
    WHERE 
        Username = @username;
END