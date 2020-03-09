CREATE TABLE [dbo].[MaterialIndiceCategory]
(
	[MaterialIndiceCategoryId]	SMALLINT		NOT NULL,
	[Name]						NVARCHAR(255)	NOT NULL,
	[MaterialIndiceGenreId]		SMALLINT		NOT NULL, 
	[CreatedDate]				DATE			NOT NULL,

	CONSTRAINT [PK_MaterialIndiceCategory] PRIMARY KEY CLUSTERED ([MaterialIndiceCategoryId] ASC),
    CONSTRAINT [FK_MaterialIndiceCategory_MaterialIndiceGenre] FOREIGN KEY ([MaterialIndiceGenreId]) REFERENCES [MaterialIndiceGenre]([MaterialIndiceGenreId])
)
