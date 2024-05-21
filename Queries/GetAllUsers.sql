CREATE PROCEDURE GetAllUsers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Username,
        Password,
        UserType
    FROM Users;
END