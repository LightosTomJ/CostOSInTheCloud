CREATE TABLE [dbo].[MaterialCategory]
(
	[MaterialCategoryId]	SMALLINT		NOT NULL,
	[Name]					NVARCHAR(255)	NOT NULL,
	[MaterialGenreId]		SMALLINT		NOT NULL, 
	[CreatedDate]			DATE			NOT NULL,

	CONSTRAINT [PK_MaterialCategory] PRIMARY KEY CLUSTERED ([MaterialCategoryId] ASC),
    CONSTRAINT [FK_MaterialCategory_MaterialGenre] FOREIGN KEY ([MaterialGenreId]) REFERENCES [MaterialGenre]([MaterialGenreId])
)
