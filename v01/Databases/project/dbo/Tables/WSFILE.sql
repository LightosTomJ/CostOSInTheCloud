﻿CREATE TABLE [dbo].[WSFILE] (
    [ID]        BIGINT          IDENTITY (1, 1) NOT NULL,
    [XMLFILE]   BIT             NULL,
    [TITLE]     NVARCHAR (255)  NULL,
    [FPATH]     NVARCHAR (255)  NULL,
    [XCELLFILE] VARBINARY (MAX) NULL,
    [NUMSHEETS] INT             NULL,
    [FILEREVID] BIGINT          NULL,
    [ACTSHEETS] NVARCHAR (MAX)  NULL,
    [TCMFILE]   BIT             NULL,
    [PRJID]     BIGINT          NULL,
    [FINDEX]    INT             NULL,
    [REF__ID]   BIGINT          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK99282A5859F4EE84] FOREIGN KEY ([FILEREVID]) REFERENCES [dbo].[WSREVISION] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[WSFILE]([PRJID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_WSREVISION]
    ON [dbo].[WSFILE]([FILEREVID] ASC);

