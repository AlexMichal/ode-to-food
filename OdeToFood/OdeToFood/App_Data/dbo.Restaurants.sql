CREATE TABLE [dbo].[Restaurants] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Cuisine]  INT           NOT NULL,
    [Name]     NVARCHAR (80) NOT NULL,
    [Likes]    INT           NOT NULL,
    [Dislikes] INT           NOT NULL,
    CONSTRAINT [PK_Restaurants] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Restaurants_ToTable] FOREIGN KEY ([Cuisine]) REFERENCES [CuisineType]([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

