CREATE TABLE [dbo].[BC_GEOMFILE] (
    [ID]                 BIGINT                     IDENTITY (1, 1) NOT NULL,
    [FDATA]              VARBINARY (MAX) FILESTREAM NULL,
    [FNAME]              NVARCHAR (256)             NULL,
    [FTYPE]              INT                        NULL,
    [FGUID]              UNIQUEIDENTIFIER           ROWGUIDCOL NOT NULL,
    [NOVERTICES]         INT                        NULL,
    [NOELEMENTS]         INT                        NULL,
    [ELEMOFFSET]         INT                        NULL,
    [ORIGINAL_FORMAT]    NVARCHAR (255)             NULL,
    [SERIALIZATION_TYPE] INT                        NULL,
    [MODEL_ID]           BIGINT                     NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FKF44224F64160E6D4] FOREIGN KEY ([MODEL_ID]) REFERENCES [dbo].[BC_MODEL] ([ID]),
    UNIQUE NONCLUSTERED ([FGUID] ASC)
) FILESTREAM_ON [BIMCity_Filestream];

