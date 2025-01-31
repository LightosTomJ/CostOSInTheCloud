﻿CREATE TABLE [dbo].[PARAMOUTPUT] (
    [PARAMOUTPUTID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [QTYEQ]         NVARCHAR (MAX) NULL,
    [FACTOREQ]      NVARCHAR (MAX) NULL,
    [LABLOCEQ]      NVARCHAR (MAX) NULL,
    [MATLOCEQ]      NVARCHAR (MAX) NULL,
    [EQULOCEQ]      NVARCHAR (MAX) NULL,
    [SUBLOCEQ]      NVARCHAR (MAX) NULL,
    [CONLOCEQ]      NVARCHAR (MAX) NULL,
    [PRDEQ]         NVARCHAR (MAX) NULL,
    [TITLE]         NVARCHAR (MAX) NULL,
    [RESIDS]        NVARCHAR (MAX) NULL,
    [GENERATION]    NVARCHAR (MAX) NULL,
    [SORTORDER]     INT            NULL,
    [LOOPVAR]       NVARCHAR (255) NULL,
    [PARAMITEMID]   BIGINT         NULL,
    [PRJID]         BIGINT         NULL,
    [REF__ID]       BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([PARAMOUTPUTID] ASC),
    CONSTRAINT [FKE11967AEB8FEF034] FOREIGN KEY ([PARAMITEMID]) REFERENCES [dbo].[PARAMITEM] ([PARAMITEMID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_PARAMITEM]
    ON [dbo].[PARAMOUTPUT]([PARAMITEMID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[PARAMOUTPUT]([PRJID] ASC);

