CREATE TABLE [dbo].[UserRoles] (
    [RoleID] INT        NOT NULL IDENTITY,
    [Role]   NCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

