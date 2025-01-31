﻿CREATE TABLE [dbo].[QUERYRESOURCE] (
    [QRESID]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [EXECTYPE]      INT            NULL,
    [TYPE]          INT            NULL,
    [TITLE]         NVARCHAR (255) NULL,
    [JSONURL]       NVARCHAR (255) NULL,
    [RESTYPE]       NVARCHAR (255) NULL,
    [ORDFLD]        NVARCHAR (255) NULL,
    [ASCDNG]        BIT            NULL,
    [SNGSEL]        BIT            NULL,
    [TLTEQ]         NVARCHAR (MAX) NULL,
    [DSCEQ]         NVARCHAR (MAX) NULL,
    [NTSEQ]         NVARCHAR (MAX) NULL,
    [LOCEQ]         NVARCHAR (MAX) NULL,
    [PDTEQ]         NVARCHAR (MAX) NULL,
    [PRDEQ]         NVARCHAR (MAX) NULL,
    [PRFEQ]         NVARCHAR (MAX) NULL,
    [WB1EQ]         NVARCHAR (MAX) NULL,
    [WB2EQ]         NVARCHAR (MAX) NULL,
    [PICEQ]         NVARCHAR (MAX) NULL,
    [GC1EQ]         NVARCHAR (MAX) NULL,
    [GC2EQ]         NVARCHAR (MAX) NULL,
    [GC3EQ]         NVARCHAR (MAX) NULL,
    [GC4EQ]         NVARCHAR (MAX) NULL,
    [GC5EQ]         NVARCHAR (MAX) NULL,
    [GC6EQ]         NVARCHAR (MAX) NULL,
    [GC7EQ]         NVARCHAR (MAX) NULL,
    [GC8EQ]         NVARCHAR (MAX) NULL,
    [GC9EQ]         NVARCHAR (MAX) NULL,
    [CT01EQ]        NVARCHAR (MAX) NULL,
    [CT02EQ]        NVARCHAR (MAX) NULL,
    [CT03EQ]        NVARCHAR (MAX) NULL,
    [CT04EQ]        NVARCHAR (MAX) NULL,
    [CT05EQ]        NVARCHAR (MAX) NULL,
    [CT06EQ]        NVARCHAR (MAX) NULL,
    [CT07EQ]        NVARCHAR (MAX) NULL,
    [CT08EQ]        NVARCHAR (MAX) NULL,
    [CT09EQ]        NVARCHAR (MAX) NULL,
    [CT10EQ]        NVARCHAR (MAX) NULL,
    [CT11EQ]        NVARCHAR (MAX) NULL,
    [CT12EQ]        NVARCHAR (MAX) NULL,
    [CT13EQ]        NVARCHAR (MAX) NULL,
    [CT14EQ]        NVARCHAR (MAX) NULL,
    [CT15EQ]        NVARCHAR (MAX) NULL,
    [CT16EQ]        NVARCHAR (MAX) NULL,
    [CT17EQ]        NVARCHAR (MAX) NULL,
    [CT18EQ]        NVARCHAR (MAX) NULL,
    [CT19EQ]        NVARCHAR (MAX) NULL,
    [CT20EQ]        NVARCHAR (MAX) NULL,
    [CT21EQ]        NVARCHAR (MAX) NULL,
    [CT22EQ]        NVARCHAR (MAX) NULL,
    [CT23EQ]        NVARCHAR (MAX) NULL,
    [CT24EQ]        NVARCHAR (MAX) NULL,
    [CT25EQ]        NVARCHAR (MAX) NULL,
    [CR01EQ]        NVARCHAR (MAX) NULL,
    [CR02EQ]        NVARCHAR (MAX) NULL,
    [CR03EQ]        NVARCHAR (MAX) NULL,
    [CR04EQ]        NVARCHAR (MAX) NULL,
    [CR05EQ]        NVARCHAR (MAX) NULL,
    [CR06EQ]        NVARCHAR (MAX) NULL,
    [CR07EQ]        NVARCHAR (MAX) NULL,
    [CR08EQ]        NVARCHAR (MAX) NULL,
    [CR09EQ]        NVARCHAR (MAX) NULL,
    [CR10EQ]        NVARCHAR (MAX) NULL,
    [CR11EQ]        NVARCHAR (MAX) NULL,
    [CR12EQ]        NVARCHAR (MAX) NULL,
    [CR13EQ]        NVARCHAR (MAX) NULL,
    [CR14EQ]        NVARCHAR (MAX) NULL,
    [CR15EQ]        NVARCHAR (MAX) NULL,
    [CR16EQ]        NVARCHAR (MAX) NULL,
    [CR17EQ]        NVARCHAR (MAX) NULL,
    [CR18EQ]        NVARCHAR (MAX) NULL,
    [CR19EQ]        NVARCHAR (MAX) NULL,
    [CR20EQ]        NVARCHAR (MAX) NULL,
    [CC01EQ]        NVARCHAR (MAX) NULL,
    [CC02EQ]        NVARCHAR (MAX) NULL,
    [CC03EQ]        NVARCHAR (MAX) NULL,
    [CC04EQ]        NVARCHAR (MAX) NULL,
    [CC05EQ]        NVARCHAR (MAX) NULL,
    [CC06EQ]        NVARCHAR (MAX) NULL,
    [CC07EQ]        NVARCHAR (MAX) NULL,
    [CC08EQ]        NVARCHAR (MAX) NULL,
    [CC09EQ]        NVARCHAR (MAX) NULL,
    [CC10EQ]        NVARCHAR (MAX) NULL,
    [CC11EQ]        NVARCHAR (MAX) NULL,
    [CC12EQ]        NVARCHAR (MAX) NULL,
    [CC13EQ]        NVARCHAR (MAX) NULL,
    [CC14EQ]        NVARCHAR (MAX) NULL,
    [CC15EQ]        NVARCHAR (MAX) NULL,
    [CC16EQ]        NVARCHAR (MAX) NULL,
    [CC17EQ]        NVARCHAR (MAX) NULL,
    [CC18EQ]        NVARCHAR (MAX) NULL,
    [CC19EQ]        NVARCHAR (MAX) NULL,
    [CC20EQ]        NVARCHAR (MAX) NULL,
    [PARAMOUTPUTID] BIGINT         NULL,
    [PRJID]         BIGINT         NULL,
    [REF__ID]       BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([QRESID] ASC),
    CONSTRAINT [FKCB7ACB662282EA1] FOREIGN KEY ([PARAMOUTPUTID]) REFERENCES [dbo].[PARAMOUTPUT] ([PARAMOUTPUTID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[QUERYRESOURCE]([PRJID] ASC);

