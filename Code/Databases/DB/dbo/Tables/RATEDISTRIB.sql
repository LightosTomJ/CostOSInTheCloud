CREATE TABLE [dbo].[RATEDISTRIB] (
    [ID]              BIGINT           IDENTITY (1, 1) NOT NULL,
    [TEMPLATEID]      BIGINT           NULL,
    [NAME]            NVARCHAR (255)   NULL,
    [DESCRIPTION]     NVARCHAR (MAX)   NULL,
    [SORTORDER]       INT              NULL,
    [DISTTYPE]        INT              NULL,
    [BALANCED]        BIT              NULL,
    [DSTRBTD]         BIT              NULL,
    [TARGETFIELD]     NVARCHAR (255)   NULL,
    [TARGETCOSTFIELD] NVARCHAR (255)   NULL,
    [DISTRANGES]      NVARCHAR (MAX)   NULL,
    [DISTRATES]       NVARCHAR (MAX)   NULL,
    [MAPPED]          BIT              NULL,
    [SHEETNO]         INT              NULL,
    [CELLX]           INT              NULL,
    [CELLY]           INT              NULL,
    [STOVALNUM]       NUMERIC (30, 10) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FKEC7F0CA59A9C964D] FOREIGN KEY ([TEMPLATEID]) REFERENCES [dbo].[PROJECTTEMPLATE] ([ID])
);

