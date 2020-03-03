CREATE TABLE [dbo].[PARAMITEM] (
    [PARAMITEMID]          BIGINT           IDENTITY (1, 1) NOT NULL,
    [SAMPLERATE]           NUMERIC (30, 10) NULL,
    [WASEXPLODED]          BIT              NULL,
    [ICON]                 NVARCHAR (255)   NULL,
    [CMODEL]               BIT              NULL,
    [GROUPNAME]            NVARCHAR (255)   NULL,
    [TOTALCOST]            NUMERIC (30, 10) NULL,
    [QTY]                  NUMERIC (30, 10) NULL,
    [MULTUNITQTY]          BIT              NULL,
    [VARIABLE]             NVARCHAR (255)   NULL,
    [DESCRIPTION]          NVARCHAR (MAX)   NULL,
    [ACCRIGHTS]            NVARCHAR (255)   NULL,
    [KEYW]                 NVARCHAR (MAX)   NULL,
    [RESCODE]              NVARCHAR (255)   NULL,
    [TITLEEQU]             NVARCHAR (MAX)   NULL,
    [GROUPIDENTITY]        NVARCHAR (255)   NULL,
    [TITLE]                NVARCHAR (255)   NULL,
    [UNIT]                 NVARCHAR (255)   NULL,
    [GROUPCODE]            NVARCHAR (255)   NULL,
    [GEKCODE]              NVARCHAR (255)   NULL,
    [EDITORID]             NVARCHAR (255)   NULL,
    [NOTES]                NVARCHAR (255)   NULL,
    [LASTUPDATE]           DATETIME2 (7)    NULL,
    [EXTRACODE1]           NVARCHAR (255)   NULL,
    [EXTRACODE2]           NVARCHAR (255)   NULL,
    [EXTRACODE3]           NVARCHAR (255)   NULL,
    [EXTRACODE4]           NVARCHAR (255)   NULL,
    [EXTRACODE5]           NVARCHAR (255)   NULL,
    [EXTRACODE6]           NVARCHAR (255)   NULL,
    [EXTRACODE7]           NVARCHAR (255)   NULL,
    [EXTRACODE8]           NVARCHAR (255)   NULL,
    [EXTRACODE9]           NVARCHAR (255)   NULL,
    [EXTRACODE10]          NVARCHAR (255)   NULL,
    [WBS]                  NVARCHAR (255)   NULL,
    [WBS2]                 NVARCHAR (255)   NULL,
    [LOC]                  NVARCHAR (255)   NULL,
    [PSWD]                 NVARCHAR (255)   NULL,
    [SNUM]                 NVARCHAR (MAX)   NULL,
    [PRTTYPE]              NVARCHAR (255)   NULL,
    [CREATEUSERID]         NVARCHAR (255)   NULL,
    [CREATEDATE]           DATETIME2 (7)    NULL,
    [BOQITEMID]            BIGINT           NULL,
    [DATABASEID]           BIGINT           NULL,
    [DATABASECREATIONDATE] BIGINT           NULL,
    [GLBID]                BIGINT           NULL,
    [PRJID]                BIGINT           NULL,
    [REF__ID]              BIGINT           NULL,
    PRIMARY KEY CLUSTERED ([PARAMITEMID] ASC),
    CONSTRAINT [FK1A98950089F3BCA6] FOREIGN KEY ([BOQITEMID]) REFERENCES [dbo].[BOQITEM] ([BOQITEMID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_BOQITEM]
    ON [dbo].[PARAMITEM]([BOQITEMID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_GROUPIDENTITY]
    ON [dbo].[PARAMITEM]([GROUPIDENTITY] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_MDBID]
    ON [dbo].[PARAMITEM]([DATABASEID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[PARAMITEM]([PRJID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_TITLE]
    ON [dbo].[PARAMITEM]([TITLE] ASC);

