CREATE TABLE [dbo].[CONSUMABLE] (
    [CONSUMABLEID]         BIGINT           IDENTITY (1, 1) NOT NULL,
    [LASTUPDATE]           DATETIME2 (7)    NULL,
    [CREATEUSER]           NVARCHAR (255)   NULL,
    [CREATEDATE]           DATETIME2 (7)    NULL,
    [RESCODE]              NVARCHAR (255)   NULL,
    [BURATE]               NUMERIC (30, 10) NULL,
    [OVERTYPE]             INT              NULL,
    [DESCRIPTION]          NVARCHAR (MAX)   NULL,
    [UNIT]                 NVARCHAR (255)   NULL,
    [RATE]                 NUMERIC (30, 10) NULL,
    [QTY]                  NUMERIC (30, 10) NULL,
    [GROUPCODE]            NVARCHAR (255)   NULL,
    [GEKCODE]              NVARCHAR (255)   NULL,
    [PROJECT]              NVARCHAR (255)   NULL,
    [ACCRIGHTS]            NVARCHAR (255)   NULL,
    [KEYW]                 NVARCHAR (MAX)   NULL,
    [TITLE]                NVARCHAR (MAX)   NULL,
    [NOTES]                NVARCHAR (255)   NULL,
    [CURRENCY]             NVARCHAR (255)   NULL,
    [EDITORID]             NVARCHAR (255)   NULL,
    [STATEPROVINCE]        NVARCHAR (255)   NULL,
    [COUNTRY]              NVARCHAR (255)   NULL,
    [DATABASEID]           BIGINT           NULL,
    [DATABASECREATIONDATE] BIGINT           NULL,
    [VIRTUAL]              BIT              NULL,
    [PREDICTED]            BIT              NULL,
    [CONCEPTUAL]           BIT              NULL,
    [TCHTYPE]              INT              NULL,
    [TVAL]                 NUMERIC (30, 10) NULL,
    [TUNIT]                NVARCHAR (255)   NULL,
    [TCOLOR]               INT              NULL,
    [TREGTYPE]             INT              NULL,
    [TRIDS]                NVARCHAR (MAX)   NULL,
    [TRDATE]               DATETIME2 (7)    NULL,
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
    [PRJID]                BIGINT           NULL,
    [REF__ID]              BIGINT           NULL,
    PRIMARY KEY CLUSTERED ([CONSUMABLEID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_MDBID]
    ON [dbo].[CONSUMABLE]([DATABASEID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[CONSUMABLE]([PRJID] ASC);

