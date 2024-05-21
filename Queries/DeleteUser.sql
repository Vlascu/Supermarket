CREATE PROCEDURE DeleteUser
    @username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Users
    WHERE Username = @username;
END