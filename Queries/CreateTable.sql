CREATE TABLE [Users] (
    [UserID] INT IDENTITY(1,1) PRIMARY KEY,
    [Username] NVARCHAR(50) NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    [UserType] NVARCHAR(50) NOT NULL
);
