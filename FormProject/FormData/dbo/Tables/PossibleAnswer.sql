CREATE TABLE [dbo].[PossibleAnswer] (
    [Id]         INT        IDENTITY (1, 1) NOT NULL,
    [QuestionId] INT        NOT NULL,
    [Title]      NCHAR (30) NULL,
    CONSTRAINT [PK_ReponsePossible] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PossibleAnswer_Question] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE
);



