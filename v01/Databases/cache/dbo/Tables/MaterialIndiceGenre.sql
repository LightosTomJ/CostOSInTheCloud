CREATE TABLE [dbo].[MaterialIndiceGenre]
(
	[MaterialIndiceGenreId]	SMALLINT		NOT NULL,
	[Name]				NVARCHAR(255)	NOT NULL,
	[CreatedDate]		DATE			NOT NULL,

	CONSTRAINT [PK_MaterialIndiceGenre] PRIMARY KEY CLUSTERED ([MaterialIndiceGenreId] ASC)
)
