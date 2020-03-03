CREATE TABLE [dbo].[Currency](
	[CurrencyId]		SMALLINT IDENTITY(1,1) NOT NULL,
	[Entity]			NVARCHAR(255)	NOT NULL,
	[Name]				NVARCHAR(255)	NOT NULL,
	[AlphabeticCode]	CHAR(3)			NOT NULL,
	[NumericCode]		SMALLINT		NOT NULL,
	[MinorUnit]			TINYINT			NOT NULL,
	[IsFundYesNo]		BIT				NOT NULL,
 [CountryId] SMALLINT NOT NULL, 
    CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], 
    CONSTRAINT [FK_Currency_Country] FOREIGN KEY ([CountryId]) REFERENCES [Country]([CountryId])
) ON [PRIMARY]


GO
CREATE NONCLUSTERED INDEX [IDX_CNAME]
    ON [dbo].[Currency]([Name] ASC, [AlphabeticCode] ASC, [NumericCode] ASC, [MinorUnit] ASC);

