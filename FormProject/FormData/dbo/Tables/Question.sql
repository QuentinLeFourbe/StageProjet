CREATE TABLE [dbo].[Question] (
    [Id]      INT        IDENTITY (1, 1) NOT NULL,
    [Title]   NCHAR (50) NOT NULL,
    [Type]    INT        NOT NULL,
    [BlockId] INT        NOT NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Question_Bloc] FOREIGN KEY ([BlockId]) REFERENCES [dbo].[Block] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);



