CREATE TABLE [dbo].[TAKEOFFLINE] (
    [ID]         BIGINT           IDENTITY (1, 1) NOT NULL,
    [SX]         NUMERIC (30, 10) NULL,
    [SY]         NUMERIC (30, 10) NULL,
    [EX]         NUMERIC (30, 10) NULL,
    [EY]         NUMERIC (30, 10) NULL,
    [LID]        BIGINT           NULL,
    [LINESCOUNT] INT              NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK1FEB975C3EBEC1B7] FOREIGN KEY ([LID]) REFERENCES [dbo].[TAKEOFFCON] ([ID])
);

