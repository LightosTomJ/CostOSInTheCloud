CREATE TABLE [dbo].[Material]
(
	[MaterialId]			BIGINT			NOT NULL,
	[Name]					NVARCHAR(512)	NOT NULL,
	[CreatedDate]			DATE			NOT NULL,
	[MaterialCategoryId]	SMALLINT		NOT NULL,

	CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED ([MaterialId] ASC),
    CONSTRAINT [FK_Material_MaterialCategory] FOREIGN KEY ([MaterialCategoryId]) REFERENCES [MaterialCategory]([MaterialCategoryId])
)
