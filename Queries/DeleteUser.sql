CREATE PROCEDURE DeleteUser
    @username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
	SET Deleted = 1
	WHERE Username = @username;
END