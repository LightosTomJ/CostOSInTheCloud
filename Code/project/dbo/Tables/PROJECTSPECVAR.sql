CREATE TABLE [dbo].[PROJECTSPECVAR] (
    [ID]                   BIGINT           IDENTITY (1, 1) NOT NULL,
    [TEMPLATEID]           BIGINT           NULL,
    [NAME]                 NVARCHAR (MAX)   NULL,
    [DESCRIPTION]          NVARCHAR (MAX)   NULL,
    [DATATYPE]             NVARCHAR (255)   NULL,
    [DEFVAL]               NVARCHAR (MAX)   NULL,
    [STOVAL]               NVARCHAR (MAX)   NULL,
    [SORTORDER]            INT              NULL,
    [CELLX]                INT              NULL,
    [CELLY]                INT              NULL,
    [SHEETNO]              INT              NULL,
    [MAPPED]               BIT              NULL,
    [STOVALNUM]            NUMERIC (30, 10) NULL,
    [ISNUMBER]             BIT              NULL,
    [MANDATORY]            BIT              NULL,
    [PUSHFIELD]            NVARCHAR (255)   NULL,
    [HIDDEN]               BIT              NULL,
    [DATABASETEMPLATEID]   BIGINT           NULL,
    [DATABASETEMPLATENAME] NVARCHAR (255)   NULL,
    [PRJID]                BIGINT           NULL,
    [REF__ID]              BIGINT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FKD3E10C539A9C964D] FOREIGN KEY ([TEMPLATEID]) REFERENCES [dbo].[PROJECTTEMPLATE] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[PROJECTSPECVAR]([PRJID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PROJECTTEMPLATE]
    ON [dbo].[PROJECTSPECVAR]([TEMPLATEID] ASC);

