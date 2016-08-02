CREATE TABLE [dbo].[Session] (
    [Id]     INT        IDENTITY (1, 1) NOT NULL,
    [Name]   NCHAR (50) NOT NULL,
    [Date]   DATE       NOT NULL,
    [FormId] INT        NULL,
    CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Session_Form] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id])
);



