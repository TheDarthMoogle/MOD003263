CREATE TABLE [dbo].[Users] (
    [UserID]   INT        IDENTITY (1, 1) NOT NULL,
    [Username] NCHAR (10) NOT NULL,
    [Password] NCHAR (10) NOT NULL,
    [UserRole] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([UserID] ASC), 
    CONSTRAINT [FK_Users_ToTable] FOREIGN KEY ([UserRole]) REFERENCES [UserRoles]([RoleID])
);

