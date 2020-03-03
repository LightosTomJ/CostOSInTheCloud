﻿CREATE TABLE [dbo].[BOQITEM_SUBCONTRACTOR] (
    [BOQITEMSUBCONTRACTORID] BIGINT           IDENTITY (1, 1) NOT NULL,
    [FRATE]                  NUMERIC (30, 10) NULL,
    [TOTALCOST]              NUMERIC (30, 10) NULL,
    [PARAMITEMID]            BIGINT           NULL,
    [FACTOR1]                NUMERIC (30, 10) NULL,
    [FACTOR2]                NUMERIC (30, 10) NULL,
    [FACTOR3]                NUMERIC (30, 10) NULL,
    [QTYPUNIT]               NUMERIC (30, 10) NULL,
    [QTYPUNITFORM]           NVARCHAR (MAX)   NULL,
    [QTYPUFORMSTATE]         TINYINT          NULL,
    [COSTCENTER]             NUMERIC (30, 10) NULL,
    [LOCALFACTOR]            NUMERIC (30, 10) NULL,
    [LOCALCOUNTRY]           NVARCHAR (255)   NULL,
    [LOCALSTATE]             NVARCHAR (255)   NULL,
    [TOTALUNITS]             NUMERIC (30, 10) NULL,
    [USERTOTALUNITS]         BIT              NULL,
    [FIXEDCOST]              NUMERIC (30, 10) NULL,
    [FINALFIXEDCOST]         NUMERIC (30, 10) NULL,
    [VARIABLECOST]           NUMERIC (30, 10) NULL,
    [PV_VARS]                NVARCHAR (MAX)   NULL,
    [LAST_UPDATE]            DATETIME2 (7)    NULL,
    [SUBCONTRACTORID]        BIGINT           NULL,
    [QUOTEITEMID]            BIGINT           NULL,
    [BOQITEMID]              BIGINT           NULL,
    [PRJID]                  BIGINT           NULL,
    [REF__ID]                BIGINT           NULL,
    PRIMARY KEY CLUSTERED ([BOQITEMSUBCONTRACTORID] ASC),
    CONSTRAINT [FK7EC9710D37613E66] FOREIGN KEY ([QUOTEITEMID]) REFERENCES [dbo].[QUOTEITEM] ([QUOTEITEMID]),
    CONSTRAINT [FK7EC9710D7C0276B4] FOREIGN KEY ([SUBCONTRACTORID]) REFERENCES [dbo].[SUBCONTRACTOR] ([SUBCONTRACTORID]),
    CONSTRAINT [FK7EC9710D89F3BCA6] FOREIGN KEY ([BOQITEMID]) REFERENCES [dbo].[BOQITEM] ([BOQITEMID]),
    CONSTRAINT [FK7EC9710DB8FEF034] FOREIGN KEY ([PARAMITEMID]) REFERENCES [dbo].[PARAMITEM] ([PARAMITEMID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_BOQITEM]
    ON [dbo].[BOQITEM_SUBCONTRACTOR]([BOQITEMID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[BOQITEM_SUBCONTRACTOR]([PRJID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_SUBCONTRACTOR]
    ON [dbo].[BOQITEM_SUBCONTRACTOR]([SUBCONTRACTORID] ASC);
