CREATE TABLE [dbo].[MaterialIndexFeed]
(
	[MaterialIndexFeedId]	SMALLINT		NOT NULL,
	[URL]					NVARCHAR(MAX)	NOT NULL,
	[SourceName]			NVARCHAR(255)	NULL,
	[MaterialId]			BIGINT			NOT NULL,

	CONSTRAINT [PK_MaterialIndexFeed] PRIMARY KEY CLUSTERED ([MaterialIndexFeedId] ASC),
    CONSTRAINT [FK_MaterialIndexFeed_Material] FOREIGN KEY ([MaterialId]) REFERENCES [Material]([MaterialId]),


)
