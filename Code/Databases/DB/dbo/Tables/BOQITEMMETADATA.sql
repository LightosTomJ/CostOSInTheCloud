﻿CREATE TABLE [dbo].[BOQITEMMETADATA] (
    [ID]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [FIELDKEY]           NVARCHAR (255) NULL,
    [INITIALDISPLAYNAME] NVARCHAR (255) NULL,
    [FIELDNAME]          NVARCHAR (255) NULL,
    [COLUMNNAME]         NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
