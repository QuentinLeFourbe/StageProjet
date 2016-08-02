CREATE TABLE [dbo].[Answer] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [PossibleAnswerId] INT            NOT NULL,
    [QuestionId]       INT            NOT NULL,
    [UserAnswer]       NVARCHAR (500) NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Answer_PossibleAnswer] FOREIGN KEY ([PossibleAnswerId]) REFERENCES [dbo].[PossibleAnswer] ([Id]),
    CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);



