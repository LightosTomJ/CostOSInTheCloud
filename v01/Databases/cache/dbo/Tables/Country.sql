CREATE TABLE [dbo].[Country](
	[CountryId]			[smallint] NOT NULL,
	[ISO]				[char](3) NOT NULL,
	[Name]				[nvarchar](127) NOT NULL,
	[SentenceCaseName]	[nvarchar](127) NOT NULL,
	[ISO3]				[char](3) NULL,
	[numcode]			[smallint] NULL,
	[phonecode]			[int] NOT NULL,
	[CreatedDate]		[datetime] NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

