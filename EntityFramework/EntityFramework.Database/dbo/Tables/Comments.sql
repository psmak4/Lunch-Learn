CREATE TABLE [dbo].[Comments] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [PostId]  UNIQUEIDENTIFIER NOT NULL,
    [Content] NVARCHAR (MAX)   NOT NULL,
    [Date]    DATETIME         NOT NULL,
    [Email]   NVARCHAR (100)   NOT NULL,
    [Approved] BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Comments_Posts] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts] ([Id])
);

