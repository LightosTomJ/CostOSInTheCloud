CREATE TABLE [dbo].[Roles]
(
	[RoleId]	TINYINT		    NOT NULL,
	[Name]      NVARCHAR(63)    NOT NULL,
    [CanView]   BIT             NOT NULL,
    [CanEdit]   BIT             NOT NULL,
	[Id]        NVARCHAR(50)	NULL,

	CONSTRAINT [PK_RoleId] PRIMARY KEY CLUSTERED (RoleId ASC),
    CONSTRAINT [FK_Roles_AspNetUsers] FOREIGN KEY ([Id]) REFERENCES [AspNetUsers]([Id]),
)
