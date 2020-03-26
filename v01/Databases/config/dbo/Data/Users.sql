USE [config]
GO

INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [IsTrial], [Title], [FirstName], [MiddleNames], [Surname], [DateOfBirth], [PhotoPath], [Photo], [GenderId], [CreatedDate], [PositionTitle], [CompanyId]) 
VALUES (N'160e488d-2288-413a-935e-d3e339f8dd80', 0, N'd42459fe-bf45-4641-a9d8-f60569dee6d6', N'tom.james@lightos.co.uk', 0, 1, NULL, N'tom.james@lightos.co.uk', N'tom.james@lightos.co.uk', N'AQAAAAEAACcQAAAAEA8ZZkz5UOMO6r6e51kmg9NIYpzWixuYL95HMH06TCvrNzOjUrLt75sCXjy+eyXPmg==', N'00447919245997', 0, N'DZFCDA7GDLDV4KO62XO24LDTF7QF5HEL', 0, N'tom.james@lightos.co.uk', 1, N'Mr', N'Tom', NULL, N'James', CAST(N'1982-06-01T00:00:00.000' AS DateTime), NULL, NULL, 1, CAST(N'2019-07-10T21:10:03.723' AS DateTime), N'Director', 1)
GO