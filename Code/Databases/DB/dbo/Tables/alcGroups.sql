CREATE TABLE [dbo].[alcGroups] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Code]        NVARCHAR (50)    NOT NULL,
    [Description] NVARCHAR (300)   NULL,
    CONSTRAINT [alcGroups_I00] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [alcGroups_I01] UNIQUE NONCLUSTERED ([Code] ASC)
);

