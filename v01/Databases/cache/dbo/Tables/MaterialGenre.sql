CREATE TABLE [dbo].[MaterialGenre]
(
	[MaterialGenreId]	SMALLINT		NOT NULL,
	[Name]				NVARCHAR(255)	NOT NULL,
	[CreatedDate]		DATE			NOT NULL,

	CONSTRAINT [PK_MaterialGenre] PRIMARY KEY CLUSTERED ([MaterialGenreId] ASC)
)
