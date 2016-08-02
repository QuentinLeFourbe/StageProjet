CREATE TABLE [dbo].[Form] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [Nom]      NCHAR (50) NOT NULL,
    [DateCreation] DATE       NOT NULL,
    CONSTRAINT [PK_Formulaire] PRIMARY KEY CLUSTERED ([Id] ASC)
);



