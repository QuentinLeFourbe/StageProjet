CREATE TABLE [dbo].[User] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [Username] NCHAR (30) NOT NULL,
    [Password] NCHAR (30) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);



