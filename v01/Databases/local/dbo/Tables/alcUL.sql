﻿CREATE TABLE [dbo].[alcUL] (
    [ULGID]  UNIQUEIDENTIFIER NOT NULL,
    [ULLA]   DATETIME         NOT NULL,
    [ULFlag] SMALLINT         NOT NULL,
    CONSTRAINT [alcUL_I00] PRIMARY KEY CLUSTERED ([ULGID] ASC)
);
