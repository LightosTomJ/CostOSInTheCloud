﻿CREATE TABLE [dbo].[BOQITEM] (
    [BOQITEMID]             BIGINT           IDENTITY (1, 1) NOT NULL,
    [PARAMITEMID]           BIGINT           NULL,
    [GLBPARAMITEMID]        BIGINT           NULL,
    [PARAMCODE]             NVARCHAR (255)   NULL,
    [CODE]                  BIGINT           NULL,
    [TITLE]                 NVARCHAR (MAX)   NULL,
    [MQTYFORM]              NVARCHAR (MAX)   NULL,
    [EQTYFORM]              NVARCHAR (MAX)   NULL,
    [TTLFORM]               NVARCHAR (MAX)   NULL,
    [DSCFORM]               NVARCHAR (MAX)   NULL,
    [WBSFORM]               NVARCHAR (MAX)   NULL,
    [WBS2FORM]              NVARCHAR (MAX)   NULL,
    [QTYFORM]               NVARCHAR (MAX)   NULL,
    [MARKUPFORM]            NVARCHAR (MAX)   NULL,
    [DURATIONFORM]          NVARCHAR (MAX)   NULL,
    [PRODFORM]              NVARCHAR (MAX)   NULL,
    [UMHFORM]               NVARCHAR (MAX)   NULL,
    [AUMHFORM]              NVARCHAR (MAX)   NULL,
    [TOTALCOSTFORM]         NVARCHAR (MAX)   NULL,
    [OFFEREDPRICEFORM]      NVARCHAR (MAX)   NULL,
    [RATEFORM]              NVARCHAR (MAX)   NULL,
    [OFFRATEFORM]           NVARCHAR (MAX)   NULL,
    [OFFSECRATEFORM]        NVARCHAR (MAX)   NULL,
    [SECRATEFORM]           NVARCHAR (MAX)   NULL,
    [SECQTYFORM]            NVARCHAR (MAX)   NULL,
    [QTYLOSSFORM]           NVARCHAR (MAX)   NULL,
    [SECUNITFORM]           NVARCHAR (MAX)   NULL,
    [UNITSDIVFORM]          NVARCHAR (MAX)   NULL,
    [ASSTOTALFORM]          NVARCHAR (MAX)   NULL,
    [EQUTOTALFORM]          NVARCHAR (MAX)   NULL,
    [MATTOTALFORM]          NVARCHAR (MAX)   NULL,
    [SUBTOTALFORM]          NVARCHAR (MAX)   NULL,
    [LABTOTALFORM]          NVARCHAR (MAX)   NULL,
    [CONTOTALFORM]          NVARCHAR (255)   NULL,
    [SCHEDULED]             BIT              NULL,
    [HAS_PRODUCTIVITY]      BIT              NULL,
    [ACTBASED]              BIT              NULL,
    [HAS_ASSFORM]           BIT              NULL,
    [HAS_PVFORM]            BIT              NULL,
    [PV_VARS]               NVARCHAR (MAX)   NULL,
    [DESCRIPTION]           NVARCHAR (MAX)   NULL,
    [DURATION]              NUMERIC (30, 10) NULL,
    [GROUPCODE]             NVARCHAR (255)   NULL,
    [GEKCODE]               NVARCHAR (255)   NULL,
    [NOTES]                 NVARCHAR (MAX)   NULL,
    [SURFACETYPE]           NVARCHAR (255)   NULL,
    [STATUS]                NVARCHAR (255)   NULL,
    [FLAG]                  INT              NULL,
    [PRODUCTIVITY]          NUMERIC (30, 10) NULL,
    [ADJPROD]               NUMERIC (30, 10) NULL,
    [PRODFACFORM]           NVARCHAR (MAX)   NULL,
    [MHFACFORM]             NVARCHAR (MAX)   NULL,
    [ADJPRODFORM]           NVARCHAR (MAX)   NULL,
    [PRODFACTOR]            NUMERIC (30, 10) NULL,
    [MHOURSFACTOR]          NUMERIC (30, 10) NULL,
    [LOCPROF]               NVARCHAR (255)   NULL,
    [LOCFAC]                NVARCHAR (255)   NULL,
    [LOCCOUNTRY]            NVARCHAR (255)   NULL,
    [LOCSTATE]              NVARCHAR (255)   NULL,
    [MANHOURS]              NUMERIC (30, 10) NULL,
    [EQUHOURS]              NUMERIC (30, 10) NULL,
    [UNITMHOURS]            NUMERIC (30, 10) NULL,
    [AUNITMHOURS]           NUMERIC (30, 10) NULL,
    [PUBLISHEDITEMCODE]     NVARCHAR (255)   NULL,
    [PUBLISHEDRATE]         NUMERIC (30, 10) NULL,
    [PUBLISHEDREVISIONCODE] NVARCHAR (255)   NULL,
    [GENERATIONID]          NVARCHAR (255)   NULL,
    [VARS]                  NVARCHAR (MAX)   NULL,
    [BIMTYPE]               NVARCHAR (MAX)   NULL,
    [BIMMATERIAL]           NVARCHAR (MAX)   NULL,
    [QUANTITY]              NUMERIC (30, 10) NULL,
    [MEASQUANT]             NUMERIC (30, 10) NULL,
    [ESTQUANT]              NUMERIC (30, 10) NULL,
    [QUANTLOSS]             NUMERIC (30, 10) NULL,
    [SECQUANTITY]           NUMERIC (30, 10) NULL,
    [ACCURACY]              NVARCHAR (255)   NULL,
    [MARKUP]                NUMERIC (30, 10) NULL,
    [AWDMAT]                NUMERIC (30, 10) NULL,
    [AWDINS]                NUMERIC (30, 10) NULL,
    [AWDSUB]                NUMERIC (30, 10) NULL,
    [AWDMHOURS]             NUMERIC (30, 10) NULL,
    [AWDIND]                NUMERIC (30, 10) NULL,
    [AWDSHIP]               NUMERIC (30, 10) NULL,
    [AWDTOTAL]              NUMERIC (30, 10) NULL,
    [ESCALATION]            NUMERIC (30, 10) NULL,
    [UNITS_DIV]             NUMERIC (30, 10) NULL,
    [ASSRATE]               NUMERIC (30, 10) NULL,
    [LABRATE]               NUMERIC (30, 10) NULL,
    [SUBRATE]               NUMERIC (30, 10) NULL,
    [SUBQUOTERATE]          NUMERIC (30, 10) NULL,
    [EQURATE]               NUMERIC (30, 10) NULL,
    [CONRATE]               NUMERIC (30, 10) NULL,
    [MATRATE]               NUMERIC (30, 10) NULL,
    [MATQUOTERATE]          NUMERIC (30, 10) NULL,
    [FABRATE]               NUMERIC (30, 10) NULL,
    [SHIPRATE]              NUMERIC (30, 10) NULL,
    [ASSCOST]               NUMERIC (30, 10) NULL,
    [LABCOST]               NUMERIC (30, 10) NULL,
    [SUBCOST]               NUMERIC (30, 10) NULL,
    [EQUCOST]               NUMERIC (30, 10) NULL,
    [CONCOST]               NUMERIC (30, 10) NULL,
    [MATCOST]               NUMERIC (30, 10) NULL,
    [FABCOST]               NUMERIC (30, 10) NULL,
    [SHIPCOST]              NUMERIC (30, 10) NULL,
    [MATRESCOST]            NUMERIC (30, 10) NULL,
    [RATE]                  NUMERIC (30, 10) NULL,
    [TOTALCOST]             NUMERIC (30, 10) NULL,
    [FIXEDCOST]             NUMERIC (30, 10) NULL,
    [OFFSECRATE]            NUMERIC (30, 10) NULL,
    [OFFPRICE]              NUMERIC (30, 10) NULL,
    [OFFRATE]               NUMERIC (30, 10) NULL,
    [SECRATE]               NUMERIC (30, 10) NULL,
    [CALCULATED_RATE]       NUMERIC (30, 10) NULL,
    [CALCULATED_TOTAL_COST] NUMERIC (30, 10) NULL,
    [UNIT]                  NVARCHAR (255)   NULL,
    [SECOND_UNIT]           NVARCHAR (255)   NULL,
    [WRSLKP]                NVARCHAR (255)   NULL,
    [PAYMENT_DATE]          DATETIME2 (7)    NULL,
    [CREATE_DATE]           DATETIME2 (7)    NULL,
    [LAST_UPDATE]           DATETIME2 (7)    NULL,
    [EDITORID]              NVARCHAR (255)   NULL,
    [ESTIMATOR]             NVARCHAR (255)   NULL,
    [CREATEUSERID]          NVARCHAR (255)   NULL,
    [EXTRACODE1]            NVARCHAR (255)   NULL,
    [EXTRACODE2]            NVARCHAR (255)   NULL,
    [WBSCODE]               NVARCHAR (255)   NULL,
    [WBS2CODE]              NVARCHAR (255)   NULL,
    [ROLLUP]                NVARCHAR (255)   NULL,
    [LOCATION]              NVARCHAR (255)   NULL,
    [EXTRACODE3]            NVARCHAR (255)   NULL,
    [EXTRACODE4]            NVARCHAR (255)   NULL,
    [EXTRACODE5]            NVARCHAR (255)   NULL,
    [EXTRACODE6]            NVARCHAR (255)   NULL,
    [EXTRACODE7]            NVARCHAR (255)   NULL,
    [EXTRACODE8]            NVARCHAR (255)   NULL,
    [EXTRACODE9]            NVARCHAR (255)   NULL,
    [EXTRACODE10]           NVARCHAR (255)   NULL,
    [PUGRCFACTOR]           NUMERIC (30, 10) NULL,
    [PUGEKFACTOR]           NUMERIC (30, 10) NULL,
    [PUEX1FACTOR]           NUMERIC (30, 10) NULL,
    [PUEX2FACTOR]           NUMERIC (30, 10) NULL,
    [PUEX3FACTOR]           NUMERIC (30, 10) NULL,
    [PUEX4FACTOR]           NUMERIC (30, 10) NULL,
    [PUEX5FACTOR]           NUMERIC (30, 10) NULL,
    [PUEX6FACTOR]           NUMERIC (30, 10) NULL,
    [PUEX7FACTOR]           NUMERIC (30, 10) NULL,
    [CUSRATE1]              NUMERIC (30, 10) NULL,
    [CUSRATE2]              NUMERIC (30, 10) NULL,
    [CUSRATE3]              NUMERIC (30, 10) NULL,
    [CUSRATE4]              NUMERIC (30, 10) NULL,
    [CUSRATE5]              NUMERIC (30, 10) NULL,
    [CUSRATE6]              NUMERIC (30, 10) NULL,
    [CUSRATE7]              NUMERIC (30, 10) NULL,
    [CUSRATE8]              NUMERIC (30, 10) NULL,
    [CUSRATE9]              NUMERIC (30, 10) NULL,
    [CUSRATE10]             NUMERIC (30, 10) NULL,
    [CUSRATE11]             NUMERIC (30, 10) NULL,
    [CUSRATE12]             NUMERIC (30, 10) NULL,
    [CUSRATE13]             NUMERIC (30, 10) NULL,
    [CUSRATE14]             NUMERIC (30, 10) NULL,
    [CUSRATE15]             NUMERIC (30, 10) NULL,
    [CUSRATE16]             NUMERIC (30, 10) NULL,
    [CUSRATE17]             NUMERIC (30, 10) NULL,
    [CUSRATE18]             NUMERIC (30, 10) NULL,
    [CUSRATE19]             NUMERIC (30, 10) NULL,
    [CUSRATE20]             NUMERIC (30, 10) NULL,
    [CUSCUMRATE1]           NUMERIC (30, 10) NULL,
    [CUSCUMRATE2]           NUMERIC (30, 10) NULL,
    [CUSCUMRATE3]           NUMERIC (30, 10) NULL,
    [CUSCUMRATE4]           NUMERIC (30, 10) NULL,
    [CUSCUMRATE5]           NUMERIC (30, 10) NULL,
    [CUSCUMRATE6]           NUMERIC (30, 10) NULL,
    [CUSCUMRATE7]           NUMERIC (30, 10) NULL,
    [CUSCUMRATE8]           NUMERIC (30, 10) NULL,
    [CUSCUMRATE9]           NUMERIC (30, 10) NULL,
    [CUSCUMRATE10]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE11]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE12]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE13]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE14]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE15]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE16]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE17]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE18]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE19]          NUMERIC (30, 10) NULL,
    [CUSCUMRATE20]          NUMERIC (30, 10) NULL,
    [CUSPER1]               NUMERIC (30, 10) NULL,
    [CUSPER2]               NUMERIC (30, 10) NULL,
    [CUSPER3]               NUMERIC (30, 10) NULL,
    [CUSPER4]               NUMERIC (30, 10) NULL,
    [CUSPER5]               NUMERIC (30, 10) NULL,
    [CUSPER6]               NUMERIC (30, 10) NULL,
    [CUSPER7]               NUMERIC (30, 10) NULL,
    [CUSPER8]               NUMERIC (30, 10) NULL,
    [CUSPER9]               NUMERIC (30, 10) NULL,
    [CUSPER10]              NUMERIC (30, 10) NULL,
    [CUSPER11]              NUMERIC (30, 10) NULL,
    [CUSPER12]              NUMERIC (30, 10) NULL,
    [CUSPER13]              NUMERIC (30, 10) NULL,
    [CUSPER14]              NUMERIC (30, 10) NULL,
    [CUSPER15]              NUMERIC (30, 10) NULL,
    [CUSPER16]              NUMERIC (30, 10) NULL,
    [CUSPER17]              NUMERIC (30, 10) NULL,
    [CUSPER18]              NUMERIC (30, 10) NULL,
    [CUSPER19]              NUMERIC (30, 10) NULL,
    [CUSPER20]              NUMERIC (30, 10) NULL,
    [CUSTXT1]               NVARCHAR (255)   NULL,
    [CUSTXT2]               NVARCHAR (255)   NULL,
    [CUSTXT3]               NVARCHAR (255)   NULL,
    [CUSTXT4]               NVARCHAR (255)   NULL,
    [CUSTXT5]               NVARCHAR (255)   NULL,
    [CUSTXT6]               NVARCHAR (255)   NULL,
    [CUSTXT7]               NVARCHAR (255)   NULL,
    [CUSTXT8]               NVARCHAR (255)   NULL,
    [CUSTXT9]               NVARCHAR (255)   NULL,
    [CUSTXT10]              NVARCHAR (255)   NULL,
    [CUSTXT11]              NVARCHAR (255)   NULL,
    [CUSTXT12]              NVARCHAR (255)   NULL,
    [CUSTXT13]              NVARCHAR (255)   NULL,
    [CUSTXT14]              NVARCHAR (255)   NULL,
    [CUSTXT15]              NVARCHAR (255)   NULL,
    [CUSTXT16]              NVARCHAR (255)   NULL,
    [CUSTXT17]              NVARCHAR (255)   NULL,
    [CUSTXT18]              NVARCHAR (255)   NULL,
    [CUSTXT19]              NVARCHAR (255)   NULL,
    [CUSTXT20]              NVARCHAR (255)   NULL,
    [CUSTXT21]              NVARCHAR (255)   NULL,
    [CUSTXT22]              NVARCHAR (255)   NULL,
    [CUSTXT23]              NVARCHAR (255)   NULL,
    [CUSTXT24]              NVARCHAR (255)   NULL,
    [CUSTXT25]              NVARCHAR (255)   NULL,
    [CUSRATE1FORM]          NVARCHAR (MAX)   NULL,
    [CUSRATE2FORM]          NVARCHAR (MAX)   NULL,
    [CUSRATE3FORM]          NVARCHAR (MAX)   NULL,
    [CUSRATE4FORM]          NVARCHAR (MAX)   NULL,
    [CUSRATE5FORM]          NVARCHAR (MAX)   NULL,
    [CUSRATE6FORM]          NVARCHAR (MAX)   NULL,
    [CUSRATE7FORM]          NVARCHAR (MAX)   NULL,
    [CUSRATE8FORM]          NVARCHAR (MAX)   NULL,
    [CUSRATE9FORM]          NVARCHAR (MAX)   NULL,
    [CUSRATE10FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE11FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE12FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE13FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE14FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE15FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE16FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE17FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE18FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE19FORM]         NVARCHAR (MAX)   NULL,
    [CUSRATE20FORM]         NVARCHAR (MAX)   NULL,
    [CUSCUM1FORM]           NVARCHAR (MAX)   NULL,
    [CUSCUM2FORM]           NVARCHAR (MAX)   NULL,
    [CUSCUM3FORM]           NVARCHAR (MAX)   NULL,
    [CUSCUM4FORM]           NVARCHAR (MAX)   NULL,
    [CUSCUM5FORM]           NVARCHAR (MAX)   NULL,
    [CUSCUM6FORM]           NVARCHAR (MAX)   NULL,
    [CUSCUM7FORM]           NVARCHAR (MAX)   NULL,
    [CUSCUM8FORM]           NVARCHAR (MAX)   NULL,
    [CUSCUM9FORM]           NVARCHAR (MAX)   NULL,
    [CUSCUM10FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM11FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM12FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM13FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM14FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM15FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM16FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM17FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM18FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM19FORM]          NVARCHAR (MAX)   NULL,
    [CUSCUM20FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER1FORM]           NVARCHAR (MAX)   NULL,
    [CUSPER2FORM]           NVARCHAR (MAX)   NULL,
    [CUSPER3FORM]           NVARCHAR (MAX)   NULL,
    [CUSPER4FORM]           NVARCHAR (MAX)   NULL,
    [CUSPER5FORM]           NVARCHAR (MAX)   NULL,
    [CUSPER6FORM]           NVARCHAR (MAX)   NULL,
    [CUSPER7FORM]           NVARCHAR (MAX)   NULL,
    [CUSPER8FORM]           NVARCHAR (MAX)   NULL,
    [CUSPER9FORM]           NVARCHAR (MAX)   NULL,
    [CUSPER10FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER11FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER12FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER13FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER14FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER15FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER16FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER17FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER18FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER19FORM]          NVARCHAR (MAX)   NULL,
    [CUSPER20FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT1FORM]           NVARCHAR (MAX)   NULL,
    [CUSTXT2FORM]           NVARCHAR (MAX)   NULL,
    [CUSTXT3FORM]           NVARCHAR (MAX)   NULL,
    [CUSTXT4FORM]           NVARCHAR (MAX)   NULL,
    [CUSTXT5FORM]           NVARCHAR (MAX)   NULL,
    [CUSTXT6FORM]           NVARCHAR (MAX)   NULL,
    [CUSTXT7FORM]           NVARCHAR (MAX)   NULL,
    [CUSTXT8FORM]           NVARCHAR (MAX)   NULL,
    [CUSTXT9FORM]           NVARCHAR (MAX)   NULL,
    [CUSTXT10FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT11FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT12FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT13FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT14FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT15FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT16FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT17FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT18FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT19FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT20FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT21FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT22FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT23FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT24FORM]          NVARCHAR (MAX)   NULL,
    [CUSTXT25FORM]          NVARCHAR (MAX)   NULL,
    [CUSDATE1]              DATETIME2 (7)    NULL,
    [CUSDATE2]              DATETIME2 (7)    NULL,
    [CUSDATE3]              DATETIME2 (7)    NULL,
    [CUSDATE4]              DATETIME2 (7)    NULL,
    [CUSDATE5]              DATETIME2 (7)    NULL,
    [ASRT]                  TINYINT          NULL,
    [EQRT]                  TINYINT          NULL,
    [SBRT]                  TINYINT          NULL,
    [LBRT]                  TINYINT          NULL,
    [MART]                  TINYINT          NULL,
    [CMRT]                  TINYINT          NULL,
    [CNQT]                  TINYINT          NULL,
    [PRJID]                 BIGINT           NULL,
    [REF__ID]               BIGINT           NULL,
    PRIMARY KEY CLUSTERED ([BOQITEMID] ASC),
    CONSTRAINT [FK2EC202B7B8FEF034] FOREIGN KEY ([PARAMITEMID]) REFERENCES [dbo].[PARAMITEM] ([PARAMITEMID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_CODE]
    ON [dbo].[BOQITEM]([CODE] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_EDITORID]
    ON [dbo].[BOQITEM]([EDITORID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_ESTIMATORID]
    ON [dbo].[BOQITEM]([ESTIMATOR] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_GENID]
    ON [dbo].[BOQITEM]([GENERATIONID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PARAMITEM]
    ON [dbo].[BOQITEM]([PARAMITEMID] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PBCODE]
    ON [dbo].[BOQITEM]([PUBLISHEDITEMCODE] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PBRVCODE]
    ON [dbo].[BOQITEM]([PUBLISHEDREVISIONCODE] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[BOQITEM]([PRJID] ASC)
    INCLUDE([CODE]);


GO
CREATE NONCLUSTERED INDEX [IDX_WSLKP]
    ON [dbo].[BOQITEM]([WRSLKP] ASC);

