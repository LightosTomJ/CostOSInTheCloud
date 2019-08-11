CREATE TABLE [dbo].[AD] (
    [ID]           BIGINT           IDENTITY (1, 1) NOT NULL,
    [TYPE]         NVARCHAR (255)   NULL,
    [STATUSMSG]    NVARCHAR (255)   NULL,
    [PORT]         INT              NULL,
    [ISSSL]        BIT              NULL,
    [BINDDN]       NVARCHAR (255)   NULL,
    [SEARCHFILTER] NVARCHAR (255)   NULL,
    [PASSWORD]     NVARCHAR (255)   NULL,
    [BASEDN]       NVARCHAR (255)   NULL,
    [ENABLE]       BIT              NULL,
    [SYNCTIME]     NUMERIC (30, 10) NULL,
    [HOSTNAME]     NVARCHAR (255)   NULL,
    [PROFILE]      NVARCHAR (255)   NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

