CREATE TABLE [dbo].[alcObjectsStatus] (
    [ObjId]   NVARCHAR (100)   NOT NULL,
    [Version] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [alcObjectsStatus_I00] PRIMARY KEY CLUSTERED ([ObjId] ASC)
);

