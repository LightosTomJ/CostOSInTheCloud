CREATE TABLE [dbo].[OtherIndicies]
(
	[OtherIndiceId]				BIGINT				NOT NULL,
	[Date]						DATE                NOT NULL,
    [Rate]						DECIMAL(18,6)       NOT NULL,
	[CreatedDate]				DATE				NOT NULL,
	[OtherIndiceCategoryId]		SMALLINT			NOT NULL,
	
	CONSTRAINT [PK_OtherIndice] PRIMARY KEY CLUSTERED ([OtherIndiceCategoryId] ASC),
	CONSTRAINT [FK_OtherIndice_OtherIndiceCategory] FOREIGN KEY ([OtherIndiceCategoryId]) REFERENCES [OtherIndiceCategory]([OtherIndiceCategoryId])
)
