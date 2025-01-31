﻿CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (128) NOT NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    CONSTRAINT [PK_AspNetRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);