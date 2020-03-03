CREATE TABLE [dbo].[alcObjectsInUse] (
    [ObjId]   NVARCHAR (250)   NOT NULL,
    [UserId]  UNIQUEIDENTIFIER NOT NULL,
    [UseMode] INT              NOT NULL,
    CONSTRAINT [alcObjectsInUse_I00] PRIMARY KEY CLUSTERED ([ObjId] ASC, [UserId] ASC)
);

