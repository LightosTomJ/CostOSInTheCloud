CREATE TABLE [dbo].[MATERIAL] (
    [MATERIALID]           BIGINT           IDENTITY (1, 1) NOT NULL,
    [ACCURACY]             NVARCHAR (255)   NULL,
    [DESCRIPTION]          NVARCHAR (MAX)   NULL,
    [VIRTUAL]              BIT              NULL,
    [PREDICTED]            BIT              NULL,
    [TCHTYPE]              INT              NULL,
    [TVAL]                 NUMERIC (30, 10) NULL,
    [TUNIT]                NVARCHAR (255)   NULL,
    [TCOLOR]               INT              NULL,
    [TREGTYPE]             INT              NULL,
    [TRIDS]                NVARCHAR (MAX)   NULL,
    [TRDATE]               DATETIME2 (7)    NULL,
    [CONCEPTUAL]           BIT              NULL,
    [BIMMATERIAL]          NVARCHAR (MAX)   NULL,
    [BIMTYPE]              NVARCHAR (255)   NULL,
    [COUNTRY]              NVARCHAR (255)   NULL,
    [RAWMAT]               NVARCHAR (255)   NULL,
    [RELIANCE]             NUMERIC (30, 10) NULL,
    [RAWMAT2]              NVARCHAR (255)   NULL,
    [RELIANCE2]            NUMERIC (30, 10) NULL,
    [RAWMAT3]              NVARCHAR (255)   NULL,
    [RELIANCE3]            NUMERIC (30, 10) NULL,
    [RAWMAT4]              NVARCHAR (255)   NULL,
    [RELIANCE4]            NUMERIC (30, 10) NULL,
    [RAWMAT5]              NVARCHAR (255)   NULL,
    [RELIANCE5]            NUMERIC (30, 10) NULL,
    [UNIT]                 NVARCHAR (255)   NULL,
    [RATE]                 NUMERIC (30, 10) NULL,
    [SHIPRATE]             NUMERIC (30, 10) NULL,
    [FABRATE]              NUMERIC (30, 10) NULL,
    [TOTALRATE]            NUMERIC (30, 10) NULL,
    [INCLUSION]            NVARCHAR (255)   NULL,
    [DISTANCE]             NUMERIC (30, 10) NULL,
    [DISTUNIT]             NVARCHAR (255)   NULL,
    [GROUPCODE]            NVARCHAR (255)   NULL,
    [GEKCODE]              NVARCHAR (255)   NULL,
    [PROJECT]              NVARCHAR (255)   NULL,
    [NOTES]                NVARCHAR (255)   NULL,
    [EDITORID]             NVARCHAR (255)   NULL,
    [STATEPROVINCE]        NVARCHAR (255)   NULL,
    [CREATEUSER]           NVARCHAR (255)   NULL,
    [CREATEDATE]           DATETIME2 (7)    NULL,
    [LASTUPDATE]           DATETIME2 (7)    NULL,
    [ACCRIGHTS]            NVARCHAR (255)   NULL,
    [KEYW]                 NVARCHAR (MAX)   NULL,
    [RESCODE]              NVARCHAR (255)   NULL,
    [TITLE]                NVARCHAR (MAX)   NULL,
    [SUPPLIERNAME]         NVARCHAR (255)   NULL,
    [CURRENCY]             NVARCHAR (255)   NULL,
    [WEIGHT]               NUMERIC (30, 10) NULL,
    [WEIGHTUNIT]           NVARCHAR (255)   NULL,
    [VOLFLOW]              NUMERIC (30, 10) NULL,
    [MSFLOW]               NUMERIC (30, 10) NULL,
    [DUTY]                 NUMERIC (30, 10) NULL,
    [OPRES]                NUMERIC (30, 10) NULL,
    [OPTMP]                NUMERIC (30, 10) NULL,
    [VLFLOWUT]             NVARCHAR (255)   NULL,
    [MSFLOWUT]             NVARCHAR (255)   NULL,
    [DUTYUT]               NVARCHAR (255)   NULL,
    [OPTEMPUT]             NVARCHAR (255)   NULL,
    [OPRESUT]              NVARCHAR (255)   NULL,
    [QTY]                  NUMERIC (30, 10) NULL,
    [DATABASEID]           BIGINT           NULL,
    [DATABASECREATIONDATE] BIGINT           NULL,
    [SUPPLIERID]           BIGINT           NULL,
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
    [BURATE]               NUMERIC (30, 10) NULL,
    [OVERTYPE]             INT              NULL,
    [PRJID]                BIGINT           NULL,
    [REF__ID]              BIGINT           NULL,
    PRIMARY KEY CLUSTERED ([MATERIALID] ASC),
    CONSTRAINT [FK40795527D05B2C5E] FOREIGN KEY ([SUPPLIERID]) REFERENCES [dbo].[SUPPLIER] ([SUPPLIERID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_MDBID]
    ON [dbo].[MATERIAL]([DATABASEID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[MATERIAL]([PRJID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_SUPPLIER]
    ON [dbo].[MATERIAL]([SUPPLIERID] ASC);

