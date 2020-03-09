CREATE TABLE [dbo].[MaterialIndexFeed]
(
	[MaterialIndexFeedId]	SMALLINT		NOT NULL,
	[URL]					NVARCHAR(MAX)	NOT NULL,
	[SourceName]			NVARCHAR(255)	NULL,
	[MaterialIndiceId]			BIGINT			NOT NULL,

	CONSTRAINT [PK_MaterialIndexFeed] PRIMARY KEY CLUSTERED ([MaterialIndexFeedId] ASC),
    CONSTRAINT [FK_MaterialIndexFeed_Material] FOREIGN KEY ([MaterialIndiceId]) REFERENCES [MaterialIndice]([MaterialIndiceId])
)
