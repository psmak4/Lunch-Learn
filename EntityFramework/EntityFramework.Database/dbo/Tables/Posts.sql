CREATE TABLE [dbo].[Posts] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [Title]   NVARCHAR (250)   NOT NULL,
    [Content] NVARCHAR (MAX)   NOT NULL,
    [Date]    DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

