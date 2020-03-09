CREATE TABLE [dbo].[MaterialIndice]
(
	[MaterialIndiceId]			BIGINT			NOT NULL,
	[Name]						NVARCHAR(512)	NOT NULL,
	[CreatedDate]				DATE			NOT NULL,
	[MaterialIndiceCategoryId]	SMALLINT		NOT NULL,

	CONSTRAINT [PK_MaterialIndice] PRIMARY KEY CLUSTERED ([MaterialIndiceId] ASC),
    CONSTRAINT [FK_MaterialIndice_MaterialIndiceCategory] FOREIGN KEY ([MaterialIndiceCategoryId]) REFERENCES [MaterialIndiceCategory]([MaterialIndiceCategoryId])
)
