CREATE TABLE [dbo].[XCELLFILE] (
    [XCELLID]   BIGINT          IDENTITY (1, 1) NOT NULL,
    [XCELLFILE] VARBINARY (MAX) NULL,
    [SHEET]     INT             NULL,
    [CELLX]     INT             NULL,
    [CELLY]     INT             NULL,
    [PRJID]     BIGINT          NULL,
    [REF__ID]   BIGINT          NULL,
    PRIMARY KEY CLUSTERED ([XCELLID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_PRJID]
    ON [dbo].[XCELLFILE]([PRJID] ASC);

