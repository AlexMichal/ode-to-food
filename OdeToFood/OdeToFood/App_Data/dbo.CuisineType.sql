CREATE TABLE [dbo].[CuisineType] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Type] VARCHAR (50) DEFAULT ('None') NOT NULL,
    CONSTRAINT [PK_CuisineType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

