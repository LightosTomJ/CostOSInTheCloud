CREATE TABLE [dbo].[WSCOLIDENT] (
    [ID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [SPLITFIELD]  NVARCHAR (255) NULL,
    [MUNIQUE]     BIT            NULL,
    [SHEETPREFIX] BIT            NULL,
    [FILEPREFIX]  BIT            NULL,
    [EXAUMA]      BIT            NULL,
    [COLTYPE]     INT            NULL,
    [MAPACTION]   INT            NULL,
    [FLDNAME]     NVARCHAR (255) NULL,
    [COLINDEX]    INT            NULL,
    [FLDTYPE]     INT            NULL,
    [FIELDMAP]    NVARCHAR (MAX) NULL,
    [MAPPINGID]   BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK1FF56F4CBCB673A4] FOREIGN KEY ([MAPPINGID]) REFERENCES [dbo].[WSDATAMAPPING] ([ID])
);

