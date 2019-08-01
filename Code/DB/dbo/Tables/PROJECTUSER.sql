CREATE TABLE [dbo].[PROJECTUSER] (
    [PUID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [USERID]        NVARCHAR (255) NULL,
    [UNAME]         NVARCHAR (255) NULL,
    [EMAIL]         NVARCHAR (255) NULL,
    [XCHANGE]       BIT            NULL,
    [ESCLTE]        BIT            NULL,
    [PROPS]         BIT            NULL,
    [TAKEOFF]       BIT            NULL,
    [RSRC]          BIT            NULL,
    [ESTIM]         BIT            NULL,
    [ADMN]          BIT            NULL,
    [SQUOTE]        BIT            NULL,
    [RQUOTE]        BIT            NULL,
    [AQUOTE]        BIT            NULL,
    [WBS]           BIT            NULL,
    [ADITMS]        BIT            NULL,
    [RMITMS]        BIT            NULL,
    [EDITMS]        BIT            NULL,
    [VAITMS]        BIT            NULL,
    [VARSUSR]       BIT            NULL,
    [VARSADMIN]     BIT            NULL,
    [VARSVIEWER]    BIT            NULL,
    [PROJECTINFOID] BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([PUID] ASC),
    CONSTRAINT [FK485D96445B1C0C14] FOREIGN KEY ([PROJECTINFOID]) REFERENCES [dbo].[PROJECTINFO] ([PROJECTINFOID])
);


GO
CREATE NONCLUSTERED INDEX [IDX_USERID]
    ON [dbo].[PROJECTUSER]([USERID] ASC);

