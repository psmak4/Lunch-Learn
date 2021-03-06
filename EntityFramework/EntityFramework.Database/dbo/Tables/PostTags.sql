﻿CREATE TABLE [dbo].[PostTags]
(
	[PostId] UNIQUEIDENTIFIER NOT NULL, 
    [TagId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_PostTags_Posts] FOREIGN KEY ([PostId]) REFERENCES [Posts]([Id]), 
    CONSTRAINT [FK_PostTags_Tags] FOREIGN KEY ([TagId]) REFERENCES [Tags]([Id]), 
    CONSTRAINT [PK_PostTags] PRIMARY KEY ([PostId], [TagId])
)
