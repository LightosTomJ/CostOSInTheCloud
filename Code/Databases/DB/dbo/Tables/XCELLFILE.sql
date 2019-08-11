CREATE TABLE [dbo].[XCELLFILE] (
    [XCELLID]   BIGINT          IDENTITY (1, 1) NOT NULL,
    [XCELLFILE] VARBINARY (MAX) NULL,
    [SHEET]     INT             NULL,
    [CELLX]     INT             NULL,
    [CELLY]     INT             NULL,
    PRIMARY KEY CLUSTERED ([XCELLID] ASC)
);

