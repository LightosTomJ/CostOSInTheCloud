USE [config]
GO

SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([CompanyId], [Name], [CompanyNumber], [Vatnumber], [CreatedDate], [UserId], [Website]) VALUES (1, N'LIGHTOS ENERGY LIMITED', N'07389639', N'312662330', CAST(N'2017-11-06T00:00:00.000' AS DateTime), 1, N'www.lightos.co.uk')
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO