CREATE TABLE [dbo].[CONSUMABLE] (
    [CONSUMABLEID]  BIGINT           IDENTITY (1, 1) NOT NULL,
    [LASTUPDATE]    DATETIME2 (7)    NULL,
    [CREATEUSER]    NVARCHAR (255)   NULL,
    [CREATEDATE]    DATETIME2 (7)    NULL,
    [RESCODE]       NVARCHAR (255)   NULL,
    [OVERTYPE]      INT              NULL,
    [DESCRIPTION]   NVARCHAR (MAX)   NULL,
    [UNIT]          NVARCHAR (255)   NULL,
    [RATE]          NUMERIC (30, 10) NULL,
    [QTY]           NUMERIC (30, 10) NULL,
    [GROUPCODE]     NVARCHAR (255)   NULL,
    [GEKCODE]       NVARCHAR (255)   NULL,
    [PROJECT]       NVARCHAR (255)   NULL,
    [ACCRIGHTS]     NVARCHAR (255)   NULL,
    [KEYW]          NVARCHAR (MAX)   NULL,
    [TITLE]         NVARCHAR (MAX)   NULL,
    [NOTES]         NVARCHAR (255)   NULL,
    [CURRENCY]      NVARCHAR (255)   NULL,
    [EDITORID]      NVARCHAR (255)   NULL,
    [STATEPROVINCE] NVARCHAR (255)   NULL,
    [COUNTRY]       NVARCHAR (255)   NULL,
    [VIRTUAL]       BIT              NULL,
    [PREDICTED]     BIT              NULL,
    [CONCEPTUAL]    BIT              NULL,
    [TCHTYPE]       INT              NULL,
    [TVAL]          NUMERIC (30, 10) NULL,
    [TUNIT]         NVARCHAR (255)   NULL,
    [TCOLOR]        INT              NULL,
    [TREGTYPE]      INT              NULL,
    [TRIDS]         NVARCHAR (MAX)   NULL,
    [TRDATE]        DATETIME2 (7)    NULL,
    [EXTRACODE1]    NVARCHAR (255)   NULL,
    [EXTRACODE2]    NVARCHAR (255)   NULL,
    [EXTRACODE3]    NVARCHAR (255)   NULL,
    [EXTRACODE4]    NVARCHAR (255)   NULL,
    [EXTRACODE5]    NVARCHAR (255)   NULL,
    [EXTRACODE6]    NVARCHAR (255)   NULL,
    [EXTRACODE7]    NVARCHAR (255)   NULL,
    [EXTRACODE8]    NVARCHAR (255)   NULL,
    [EXTRACODE9]    NVARCHAR (255)   NULL,
    [EXTRACODE10]   NVARCHAR (255)   NULL,
    PRIMARY KEY CLUSTERED ([CONSUMABLEID] ASC)
);


GO

create trigger trigger_unique_item_code_consumable on dbo.CONSUMABLE

FOR INSERT ,UPDATE
AS 

SET NOCOUNT ON;
DECLARE @tempRes VARCHAR(max)
DECLARE @tempId bigint
DECLARE @TempString VARCHAR(max)
DECLARE my_Cursor CURSOR LOCAL FAST_FORWARD FOR SELECT RESCODE,CONSUMABLEID FROM INSERTED;
OPEN my_Cursor 
FETCH NEXT FROM my_Cursor into @tempRes,@tempId
 
 WHILE @@FETCH_STATUS = 0 
 
 BEGIN
	IF ( CHARINDEX( '_N_VALID',@tempRes) = 0) 
	IF EXISTS ( SELECT before.RESCODE 
	FROM ( SELECT * FROM dbo.CONSUMABLE AS a WHERE a.CONSUMABLEID NOT IN(SELECT o.CONSUMABLEID FROM inserted o ) ) AS before
	WHERE before.RESCODE=@tempRes )	
	UPDATE a SET  a.RESCODE = a.RESCODE+'_N_VALID' FROM dbo.CONSUMABLE a WHERE  a.CONSUMABLEID = @tempId 
	FETCH NEXT FROM my_Cursor into @tempRes,@tempId
 END 

GO
DISABLE TRIGGER [dbo].[trigger_unique_item_code_consumable]
    ON [dbo].[CONSUMABLE];

