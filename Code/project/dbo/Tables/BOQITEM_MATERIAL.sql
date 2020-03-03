﻿CREATE TABLE [dbo].[BOQITEM_MATERIAL] (
    [BOQITEMMATERIALID] BIGINT           IDENTITY (1, 1) NOT NULL,
    [FRATE]             NUMERIC (30, 10) NULL,
    [TOTALCOST]         NUMERIC (30, 10) NULL,
    [PARAMITEMID]       BIGINT           NULL,
    [FACTOR1]           NUMERIC (30, 10) NULL,
    [FACTOR2]           NUMERIC (30, 10) NULL,
    [ESCALATION]        NUMERIC (30, 10) NULL,
    [DIVIDER]           NUMERIC (30, 10) NULL,
    [QTYPUNIT]          NUMERIC (30, 10) NULL,
    [QTYPUNITFORM]      NVARCHAR (MAX)   NULL,
    [QTYPUFORMSTATE]    TINYINT          NULL,
    [TOTALUNITS]        NUMERIC (30, 10) NULL,
    [USERTOTALUNITS]    BIT              NULL,
    [COSTCENTER]        NUMERIC (30, 10) NULL,
    [LOCALFACTOR]       NUMERIC (30, 10) NULL,
    [LOCALCOUNTRY]      NVARCHAR (255)   NULL,
    [LOCALSTATE]        NVARCHAR (255)   NULL,
    [FIXEDCOST]         NUMERIC (30, 10) NULL,
    [FINALFIXEDCOST]    NUMERIC (30, 10) NULL,
    [VARIABLECOST]      NUMERIC (30, 10) NULL,
    [PV_VARS]           NVARCHAR (MAX)   NULL,
    [LAST_UPDATE]       DATETIME2 (7)    NULL,
    [MATERIALID]        BIGINT           NULL,
    [BOQITEMID]         BIGINT           NULL,
    [QUOTEITEMID]       BIGINT           NULL,
    [PRJID]             BIGINT           NULL,
    [REF__ID]           BIGINT           NULL,
    PRIMARY KEY CLUSTERED ([BOQITEMMATERIALID] ASC),
    CONSTRAINT [FKC4BEA1AF2461A27E] FOREIGN KEY ([MATERIALID]) REFERENCES [dbo].[MATERIAL] ([MATERIALID]),
    CONSTRAINT [FKC4BEA1AF37613E66] FOREIGN KEY ([QUOTEITEMID]) REFERENCES [dbo].[QUOTEITEM] ([QUOTEITEMID]),
    CONSTRAINT [FKC4BEA1AF89F3BCA6] FOREIGN KEY ([BOQITEMID]) REFERENCES [dbo].[BOQITEM] ([BOQITEMID]),
    CONSTRAINT [FKC4BEA1AFB8FEF034] FOREIGN KEY ([PARAMITEMID]) REFERENCES [dbo].[PARAMITEM] ([PARAMITEMID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_BOQITEM]
    ON [dbo].[BOQITEM_MATERIAL]([BOQITEMID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_MATERIAL]
    ON [dbo].[BOQITEM_MATERIAL]([MATERIALID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PARAMITEM]
    ON [dbo].[BOQITEM_MATERIAL]([PARAMITEMID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[BOQITEM_MATERIAL]([PRJID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_QUOTEITEM]
    ON [dbo].[BOQITEM_MATERIAL]([QUOTEITEMID] ASC);
