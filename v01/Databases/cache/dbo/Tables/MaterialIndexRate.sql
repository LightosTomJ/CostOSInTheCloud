CREATE TABLE [dbo].[MaterialIndexRate]
(
	[MaterialIndexRateId]		UNIQUEIDENTIFIER	NOT NULL,
    [Date]						DATE                NOT NULL,
    [Rate]						DECIMAL(18,6)       NOT NULL,
	[MaterialCategoryId]		SMALLINT			NOT NULL,
	[CreatedDate]				DATE				NOT NULL,

    CONSTRAINT [PK_MaterialIndexRate] PRIMARY KEY CLUSTERED ([MaterialIndexRateId] ASC),
	CONSTRAINT [FK_MaterialIndexRate_MaterialCategory] FOREIGN KEY ([MaterialCategoryId]) REFERENCES [MaterialIndiceCategory]([MaterialIndiceCategoryId]),
)
