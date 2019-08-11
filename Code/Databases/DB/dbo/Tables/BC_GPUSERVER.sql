CREATE TABLE [dbo].[BC_GPUSERVER] (
    [ID]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [ACTIVE]       BIT            NULL,
    [AVA_MEM]      BIGINT         NULL,
    [CAPACITY]     BIGINT         NULL,
    [CUR_MEM]      BIGINT         NULL,
    [CUR_SESSIONS] INT            NULL,
    [DEDICATED]    NVARCHAR (MAX) NULL,
    [HOSTNAME]     NVARCHAR (256) NULL,
    [LAST_UPDATE]  DATETIME2 (7)  NULL,
    [MAXSESSIONS]  INT            NULL,
    [NAME]         NVARCHAR (256) NULL,
    [ONLN]         BIT            NULL,
    [PASWD]        NVARCHAR (256) NULL,
    [PORT]         NVARCHAR (50)  NULL,
    [RENDERER]     NVARCHAR (255) NULL,
    [USERNAME]     NVARCHAR (256) NULL,
    [VENDOR]       NVARCHAR (512) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

