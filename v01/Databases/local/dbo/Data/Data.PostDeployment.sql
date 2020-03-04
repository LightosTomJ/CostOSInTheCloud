/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [local]
GO

INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (1, N'AF ', N'AFGHANISTAN', N'Afghanistan', N'AFG', 4, 93, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (2, N'AL ', N'ALBANIA', N'Albania', N'ALB', 8, 355, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (3, N'DZ ', N'ALGERIA', N'Algeria', N'DZA', 12, 213, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (4, N'AS ', N'AMERICAN SAMOA', N'American Samoa', N'ASM', 16, 1684, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (5, N'AD ', N'ANDORRA', N'Andorra', N'AND', 20, 376, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (6, N'AO ', N'ANGOLA', N'Angola', N'AGO', 24, 244, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (7, N'AI ', N'ANGUILLA', N'Anguilla', N'AIA', 660, 1264, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (8, N'AQ ', N'ANTARCTICA', N'Antarctica', NULL, NULL, 0, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (9, N'AG ', N'ANTIGUA AND BARBUDA', N'Antigua and Barbuda', N'ATG', 28, 1268, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (10, N'AR ', N'ARGENTINA', N'Argentina', N'ARG', 32, 54, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (11, N'AM ', N'ARMENIA', N'Armenia', N'ARM', 51, 374, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (12, N'AW ', N'ARUBA', N'Aruba', N'ABW', 533, 297, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (13, N'AU ', N'AUSTRALIA', N'Australia', N'AUS', 36, 61, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (14, N'AT ', N'AUSTRIA', N'Austria', N'AUT', 40, 43, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (15, N'AZ ', N'AZERBAIJAN', N'Azerbaijan', N'AZE', 31, 994, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (16, N'BS ', N'BAHAMAS', N'Bahamas', N'BHS', 44, 1242, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (17, N'BH ', N'BAHRAIN', N'Bahrain', N'BHR', 48, 973, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (18, N'BD ', N'BANGLADESH', N'Bangladesh', N'BGD', 50, 880, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (19, N'BB ', N'BARBADOS', N'Barbados', N'BRB', 52, 1246, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (20, N'BY ', N'BELARUS', N'Belarus', N'BLR', 112, 375, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (21, N'BE ', N'BELGIUM', N'Belgium', N'BEL', 56, 32, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (22, N'BZ ', N'BELIZE', N'Belize', N'BLZ', 84, 501, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (23, N'BJ ', N'BENIN', N'Benin', N'BEN', 204, 229, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (24, N'BM ', N'BERMUDA', N'Bermuda', N'BMU', 60, 1441, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (25, N'BT ', N'BHUTAN', N'Bhutan', N'BTN', 64, 975, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (26, N'BO ', N'BOLIVIA', N'Bolivia', N'BOL', 68, 591, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (27, N'BA ', N'BOSNIA AND HERZEGOVINA', N'Bosnia and Herzegovina', N'BIH', 70, 387, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (28, N'BW ', N'BOTSWANA', N'Botswana', N'BWA', 72, 267, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (29, N'BV ', N'BOUVET ISLAND', N'Bouvet Island', NULL, NULL, 0, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (30, N'BR ', N'BRAZIL', N'Brazil', N'BRA', 76, 55, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (31, N'IO ', N'BRITISH INDIAN OCEAN TERRITORY', N'British Indian Ocean Territory', NULL, NULL, 246, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (32, N'BN ', N'BRUNEI DARUSSALAM', N'Brunei Darussalam', N'BRN', 96, 673, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (33, N'BG ', N'BULGARIA', N'Bulgaria', N'BGR', 100, 359, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (34, N'BF ', N'BURKINA FASO', N'Burkina Faso', N'BFA', 854, 226, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (35, N'BI ', N'BURUNDI', N'Burundi', N'BDI', 108, 257, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (36, N'KH ', N'CAMBODIA', N'Cambodia', N'KHM', 116, 855, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (37, N'CM ', N'CAMEROON', N'Cameroon', N'CMR', 120, 237, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (38, N'CA ', N'CANADA', N'Canada', N'CAN', 124, 1, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (39, N'CV ', N'CAPE VERDE', N'Cape Verde', N'CPV', 132, 238, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (40, N'KY ', N'CAYMAN ISLANDS', N'Cayman Islands', N'CYM', 136, 1345, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (41, N'CF ', N'CENTRAL AFRICAN REPUBLIC', N'Central African Republic', N'CAF', 140, 236, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (42, N'TD ', N'CHAD', N'Chad', N'TCD', 148, 235, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (43, N'CL ', N'CHILE', N'Chile', N'CHL', 152, 56, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (44, N'CN ', N'CHINA', N'China', N'CHN', 156, 86, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (45, N'CX ', N'CHRISTMAS ISLAND', N'Christmas Island', NULL, NULL, 61, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (46, N'CC ', N'COCOS (KEELING) ISLANDS', N'Cocos (Keeling) Islands', NULL, NULL, 672, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (47, N'CO ', N'COLOMBIA', N'Colombia', N'COL', 170, 57, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (48, N'KM ', N'COMOROS', N'Comoros', N'COM', 174, 269, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (49, N'CG ', N'CONGO', N'Congo', N'COG', 178, 242, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (50, N'CD ', N'CONGO, THE DEMOCRATIC REPUBLIC OF THE', N'Congo, the Democratic Republic of the', N'COD', 180, 242, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (51, N'CK ', N'COOK ISLANDS', N'Cook Islands', N'COK', 184, 682, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (52, N'CR ', N'COSTA RICA', N'Costa Rica', N'CRI', 188, 506, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (53, N'CI ', N'COTE D''IVOIRE', N'Cote D''Ivoire', N'CIV', 384, 225, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (54, N'HR ', N'CROATIA', N'Croatia', N'HRV', 191, 385, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (55, N'CU ', N'CUBA', N'Cuba', N'CUB', 192, 53, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (56, N'CY ', N'CYPRUS', N'Cyprus', N'CYP', 196, 357, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (57, N'CZ ', N'CZECH REPUBLIC', N'Czech Republic', N'CZE', 203, 420, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (58, N'DK ', N'DENMARK', N'Denmark', N'DNK', 208, 45, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (59, N'DJ ', N'DJIBOUTI', N'Djibouti', N'DJI', 262, 253, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (60, N'DM ', N'DOMINICA', N'Dominica', N'DMA', 212, 1767, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (61, N'DO ', N'DOMINICAN REPUBLIC', N'Dominican Republic', N'DOM', 214, 1809, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (62, N'EC ', N'ECUADOR', N'Ecuador', N'ECU', 218, 593, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (63, N'EG ', N'EGYPT', N'Egypt', N'EGY', 818, 20, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (64, N'SV ', N'EL SALVADOR', N'El Salvador', N'SLV', 222, 503, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (65, N'GQ ', N'EQUATORIAL GUINEA', N'Equatorial Guinea', N'GNQ', 226, 240, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (66, N'ER ', N'ERITREA', N'Eritrea', N'ERI', 232, 291, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (67, N'EE ', N'ESTONIA', N'Estonia', N'EST', 233, 372, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (68, N'ET ', N'ETHIOPIA', N'Ethiopia', N'ETH', 231, 251, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (69, N'FK ', N'FALKLAND ISLANDS (MALVINAS)', N'Falkland Islands (Malvinas)', N'FLK', 238, 500, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (70, N'FO ', N'FAROE ISLANDS', N'Faroe Islands', N'FRO', 234, 298, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (71, N'FJ ', N'FIJI', N'Fiji', N'FJI', 242, 679, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (72, N'FI ', N'FINLAND', N'Finland', N'FIN', 246, 358, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (73, N'FR ', N'FRANCE', N'France', N'FRA', 250, 33, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (74, N'GF ', N'FRENCH GUIANA', N'French Guiana', N'GUF', 254, 594, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (75, N'PF ', N'FRENCH POLYNESIA', N'French Polynesia', N'PYF', 258, 689, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (76, N'TF ', N'FRENCH SOUTHERN TERRITORIES', N'French Southern Territories', NULL, NULL, 0, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (77, N'GA ', N'GABON', N'Gabon', N'GAB', 266, 241, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (78, N'GM ', N'GAMBIA', N'Gambia', N'GMB', 270, 220, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (79, N'GE ', N'GEORGIA', N'Georgia', N'GEO', 268, 995, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (80, N'DE ', N'GERMANY', N'Germany', N'DEU', 276, 49, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (81, N'GH ', N'GHANA', N'Ghana', N'GHA', 288, 233, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (82, N'GI ', N'GIBRALTAR', N'Gibraltar', N'GIB', 292, 350, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (83, N'GR ', N'GREECE', N'Greece', N'GRC', 300, 30, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (84, N'GL ', N'GREENLAND', N'Greenland', N'GRL', 304, 299, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (85, N'GD ', N'GRENADA', N'Grenada', N'GRD', 308, 1473, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (86, N'GP ', N'GUADELOUPE', N'Guadeloupe', N'GLP', 312, 590, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (87, N'GU ', N'GUAM', N'Guam', N'GUM', 316, 1671, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (88, N'GT ', N'GUATEMALA', N'Guatemala', N'GTM', 320, 502, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (89, N'GN ', N'GUINEA', N'Guinea', N'GIN', 324, 224, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (90, N'GW ', N'GUINEA-BISSAU', N'Guinea-Bissau', N'GNB', 624, 245, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (91, N'GY ', N'GUYANA', N'Guyana', N'GUY', 328, 592, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (92, N'HT ', N'HAITI', N'Haiti', N'HTI', 332, 509, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (93, N'HM ', N'HEARD ISLAND AND MCDONALD ISLANDS', N'Heard Island and Mcdonald Islands', NULL, NULL, 0, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (94, N'VA ', N'HOLY SEE (VATICAN CITY STATE)', N'Holy See (Vatican City State)', N'VAT', 336, 39, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (95, N'HN ', N'HONDURAS', N'Honduras', N'HND', 340, 504, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (96, N'HK ', N'HONG KONG', N'Hong Kong', N'HKG', 344, 852, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (97, N'HU ', N'HUNGARY', N'Hungary', N'HUN', 348, 36, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (98, N'IS ', N'ICELAND', N'Iceland', N'ISL', 352, 354, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (99, N'IN ', N'INDIA', N'India', N'IND', 356, 91, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (100, N'ID ', N'INDONESIA', N'Indonesia', N'IDN', 360, 62, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (101, N'IR ', N'IRAN, ISLAMIC REPUBLIC OF', N'Iran, Islamic Republic of', N'IRN', 364, 98, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (102, N'IQ ', N'IRAQ', N'Iraq', N'IRQ', 368, 964, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (103, N'IE ', N'IRELAND', N'Ireland', N'IRL', 372, 353, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (104, N'IL ', N'ISRAEL', N'Israel', N'ISR', 376, 972, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (105, N'IT ', N'ITALY', N'Italy', N'ITA', 380, 39, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (106, N'JM ', N'JAMAICA', N'Jamaica', N'JAM', 388, 1876, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (107, N'JP ', N'JAPAN', N'Japan', N'JPN', 392, 81, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (108, N'JO ', N'JORDAN', N'Jordan', N'JOR', 400, 962, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (109, N'KZ ', N'KAZAKHSTAN', N'Kazakhstan', N'KAZ', 398, 7, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (110, N'KE ', N'KENYA', N'Kenya', N'KEN', 404, 254, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (111, N'KI ', N'KIRIBATI', N'Kiribati', N'KIR', 296, 686, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (112, N'KP ', N'KOREA, DEMOCRATIC PEOPLE''S REPUBLIC OF', N'Korea, Democratic People''s Republic of', N'PRK', 408, 850, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (113, N'KR ', N'KOREA, REPUBLIC OF', N'Korea, Republic of', N'KOR', 410, 82, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (114, N'KW ', N'KUWAIT', N'Kuwait', N'KWT', 414, 965, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (115, N'KG ', N'KYRGYZSTAN', N'Kyrgyzstan', N'KGZ', 417, 996, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (116, N'LA ', N'LAO PEOPLE''S DEMOCRATIC REPUBLIC', N'Lao People''s Democratic Republic', N'LAO', 418, 856, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (117, N'LV ', N'LATVIA', N'Latvia', N'LVA', 428, 371, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (118, N'LB ', N'LEBANON', N'Lebanon', N'LBN', 422, 961, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (119, N'LS ', N'LESOTHO', N'Lesotho', N'LSO', 426, 266, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (120, N'LR ', N'LIBERIA', N'Liberia', N'LBR', 430, 231, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (121, N'LY ', N'LIBYAN ARAB JAMAHIRIYA', N'Libyan Arab Jamahiriya', N'LBY', 434, 218, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (122, N'LI ', N'LIECHTENSTEIN', N'Liechtenstein', N'LIE', 438, 423, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (123, N'LT ', N'LITHUANIA', N'Lithuania', N'LTU', 440, 370, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (124, N'LU ', N'LUXEMBOURG', N'Luxembourg', N'LUX', 442, 352, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (125, N'MO ', N'MACAO', N'Macao', N'MAC', 446, 853, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (126, N'MK ', N'MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF', N'Macedonia, the Former Yugoslav Republic of', N'MKD', 807, 389, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (127, N'MG ', N'MADAGASCAR', N'Madagascar', N'MDG', 450, 261, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (128, N'MW ', N'MALAWI', N'Malawi', N'MWI', 454, 265, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (129, N'MY ', N'MALAYSIA', N'Malaysia', N'MYS', 458, 60, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (130, N'MV ', N'MALDIVES', N'Maldives', N'MDV', 462, 960, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (131, N'ML ', N'MALI', N'Mali', N'MLI', 466, 223, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (132, N'MT ', N'MALTA', N'Malta', N'MLT', 470, 356, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (133, N'MH ', N'MARSHALL ISLANDS', N'Marshall Islands', N'MHL', 584, 692, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (134, N'MQ ', N'MARTINIQUE', N'Martinique', N'MTQ', 474, 596, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (135, N'MR ', N'MAURITANIA', N'Mauritania', N'MRT', 478, 222, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (136, N'MU ', N'MAURITIUS', N'Mauritius', N'MUS', 480, 230, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (137, N'YT ', N'MAYOTTE', N'Mayotte', NULL, NULL, 269, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (138, N'MX ', N'MEXICO', N'Mexico', N'MEX', 484, 52, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (139, N'FM ', N'MICRONESIA, FEDERATED STATES OF', N'Micronesia, Federated States of', N'FSM', 583, 691, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (140, N'MD ', N'MOLDOVA, REPUBLIC OF', N'Moldova, Republic of', N'MDA', 498, 373, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (141, N'MC ', N'MONACO', N'Monaco', N'MCO', 492, 377, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (142, N'MN ', N'MONGOLIA', N'Mongolia', N'MNG', 496, 976, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (143, N'MS ', N'MONTSERRAT', N'Montserrat', N'MSR', 500, 1664, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (144, N'MA ', N'MOROCCO', N'Morocco', N'MAR', 504, 212, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (145, N'MZ ', N'MOZAMBIQUE', N'Mozambique', N'MOZ', 508, 258, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (146, N'MM ', N'MYANMAR', N'Myanmar', N'MMR', 104, 95, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (147, N'NA ', N'NAMIBIA', N'Namibia', N'NAM', 516, 264, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (148, N'NR ', N'NAURU', N'Nauru', N'NRU', 520, 674, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (149, N'NP ', N'NEPAL', N'Nepal', N'NPL', 524, 977, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (150, N'NL ', N'NETHERLANDS', N'Netherlands', N'NLD', 528, 31, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (151, N'AN ', N'NETHERLANDS ANTILLES', N'Netherlands Antilles', N'ANT', 530, 599, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (152, N'NC ', N'NEW CALEDONIA', N'New Caledonia', N'NCL', 540, 687, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (153, N'NZ ', N'NEW ZEALAND', N'New Zealand', N'NZL', 554, 64, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (154, N'NI ', N'NICARAGUA', N'Nicaragua', N'NIC', 558, 505, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (155, N'NE ', N'NIGER', N'Niger', N'NER', 562, 227, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (156, N'NG ', N'NIGERIA', N'Nigeria', N'NGA', 566, 234, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (157, N'NU ', N'NIUE', N'Niue', N'NIU', 570, 683, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (158, N'NF ', N'NORFOLK ISLAND', N'Norfolk Island', N'NFK', 574, 672, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (159, N'MP ', N'NORTHERN MARIANA ISLANDS', N'Northern Mariana Islands', N'MNP', 580, 1670, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (160, N'NO ', N'NORWAY', N'Norway', N'NOR', 578, 47, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (161, N'OM ', N'OMAN', N'Oman', N'OMN', 512, 968, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (162, N'PK ', N'PAKISTAN', N'Pakistan', N'PAK', 586, 92, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (163, N'PW ', N'PALAU', N'Palau', N'PLW', 585, 680, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (164, N'PS ', N'PALESTINIAN TERRITORY, OCCUPIED', N'Palestinian Territory, Occupied', NULL, NULL, 970, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (165, N'PA ', N'PANAMA', N'Panama', N'PAN', 591, 507, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (166, N'PG ', N'PAPUA NEW GUINEA', N'Papua New Guinea', N'PNG', 598, 675, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (167, N'PY ', N'PARAGUAY', N'Paraguay', N'PRY', 600, 595, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (168, N'PE ', N'PERU', N'Peru', N'PER', 604, 51, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (169, N'PH ', N'PHILIPPINES', N'Philippines', N'PHL', 608, 63, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (170, N'PN ', N'PITCAIRN', N'Pitcairn', N'PCN', 612, 0, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (171, N'PL ', N'POLAND', N'Poland', N'POL', 616, 48, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (172, N'PT ', N'PORTUGAL', N'Portugal', N'PRT', 620, 351, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (173, N'PR ', N'PUERTO RICO', N'Puerto Rico', N'PRI', 630, 1787, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (174, N'QA ', N'QATAR', N'Qatar', N'QAT', 634, 974, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (175, N'RE ', N'REUNION', N'Reunion', N'REU', 638, 262, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (176, N'RO ', N'ROMANIA', N'Romania', N'ROM', 642, 40, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (177, N'RU ', N'RUSSIAN FEDERATION', N'Russian Federation', N'RUS', 643, 70, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (178, N'RW ', N'RWANDA', N'Rwanda', N'RWA', 646, 250, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (179, N'SH ', N'SAINT HELENA', N'Saint Helena', N'SHN', 654, 290, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (180, N'KN ', N'SAINT KITTS AND NEVIS', N'Saint Kitts and Nevis', N'KNA', 659, 1869, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (181, N'LC ', N'SAINT LUCIA', N'Saint Lucia', N'LCA', 662, 1758, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (182, N'PM ', N'SAINT PIERRE AND MIQUELON', N'Saint Pierre and Miquelon', N'SPM', 666, 508, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (183, N'VC ', N'SAINT VINCENT AND THE GRENADINES', N'Saint Vincent and the Grenadines', N'VCT', 670, 1784, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (184, N'WS ', N'SAMOA', N'Samoa', N'WSM', 882, 684, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (185, N'SM ', N'SAN MARINO', N'San Marino', N'SMR', 674, 378, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (186, N'ST ', N'SAO TOME AND PRINCIPE', N'Sao Tome and Principe', N'STP', 678, 239, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (187, N'SA ', N'SAUDI ARABIA', N'Saudi Arabia', N'SAU', 682, 966, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (188, N'SN ', N'SENEGAL', N'Senegal', N'SEN', 686, 221, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (189, N'CS ', N'SERBIA AND MONTENEGRO', N'Serbia and Montenegro', NULL, NULL, 381, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (190, N'SC ', N'SEYCHELLES', N'Seychelles', N'SYC', 690, 248, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (191, N'SL ', N'SIERRA LEONE', N'Sierra Leone', N'SLE', 694, 232, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (192, N'SG ', N'SINGAPORE', N'Singapore', N'SGP', 702, 65, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (193, N'SK ', N'SLOVAKIA', N'Slovakia', N'SVK', 703, 421, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (194, N'SI ', N'SLOVENIA', N'Slovenia', N'SVN', 705, 386, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (195, N'SB ', N'SOLOMON ISLANDS', N'Solomon Islands', N'SLB', 90, 677, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (196, N'SO ', N'SOMALIA', N'Somalia', N'SOM', 706, 252, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (197, N'ZA ', N'SOUTH AFRICA', N'South Africa', N'ZAF', 710, 27, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (198, N'GS ', N'SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS', N'South Georgia and the South Sandwich Islands', NULL, NULL, 0, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (199, N'ES ', N'SPAIN', N'Spain', N'ESP', 724, 34, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (200, N'LK ', N'SRI LANKA', N'Sri Lanka', N'LKA', 144, 94, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (201, N'SD ', N'SUDAN', N'Sudan', N'SDN', 736, 249, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (202, N'SR ', N'SURINAME', N'Suriname', N'SUR', 740, 597, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (203, N'SJ ', N'SVALBARD AND JAN MAYEN', N'Svalbard and Jan Mayen', N'SJM', 744, 47, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (204, N'SZ ', N'SWAZILAND', N'Swaziland', N'SWZ', 748, 268, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (205, N'SE ', N'SWEDEN', N'Sweden', N'SWE', 752, 46, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (206, N'CH ', N'SWITZERLAND', N'Switzerland', N'CHE', 756, 41, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (207, N'SY ', N'SYRIAN ARAB REPUBLIC', N'Syrian Arab Republic', N'SYR', 760, 963, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (208, N'TW ', N'TAIWAN, PROVINCE OF CHINA', N'Taiwan, Province of China', N'TWN', 158, 886, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (209, N'TJ ', N'TAJIKISTAN', N'Tajikistan', N'TJK', 762, 992, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (210, N'TZ ', N'TANZANIA, UNITED REPUBLIC OF', N'Tanzania, United Republic of', N'TZA', 834, 255, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (211, N'TH ', N'THAILAND', N'Thailand', N'THA', 764, 66, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (212, N'TL ', N'TIMOR-LESTE', N'Timor-Leste', NULL, NULL, 670, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (213, N'TG ', N'TOGO', N'Togo', N'TGO', 768, 228, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (214, N'TK ', N'TOKELAU', N'Tokelau', N'TKL', 772, 690, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (215, N'TO ', N'TONGA', N'Tonga', N'TON', 776, 676, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (216, N'TT ', N'TRINIDAD AND TOBAGO', N'Trinidad and Tobago', N'TTO', 780, 1868, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (217, N'TN ', N'TUNISIA', N'Tunisia', N'TUN', 788, 216, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (218, N'TR ', N'TURKEY', N'Turkey', N'TUR', 792, 90, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (219, N'TM ', N'TURKMENISTAN', N'Turkmenistan', N'TKM', 795, 7370, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (220, N'TC ', N'TURKS AND CAICOS ISLANDS', N'Turks and Caicos Islands', N'TCA', 796, 1649, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (221, N'TV ', N'TUVALU', N'Tuvalu', N'TUV', 798, 688, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (222, N'UG ', N'UGANDA', N'Uganda', N'UGA', 800, 256, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (223, N'UA ', N'UKRAINE', N'Ukraine', N'UKR', 804, 380, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (224, N'AE ', N'UNITED ARAB EMIRATES', N'United Arab Emirates', N'ARE', 784, 971, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (225, N'GB ', N'UNITED KINGDOM', N'United Kingdom', N'GBR', 826, 44, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (226, N'US ', N'UNITED STATES', N'United States', N'USA', 840, 1, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (227, N'UM ', N'UNITED STATES MINOR OUTLYING ISLANDS', N'United States Minor Outlying Islands', NULL, NULL, 1, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (228, N'UY ', N'URUGUAY', N'Uruguay', N'URY', 858, 598, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (229, N'UZ ', N'UZBEKISTAN', N'Uzbekistan', N'UZB', 860, 998, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (230, N'VU ', N'VANUATU', N'Vanuatu', N'VUT', 548, 678, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (231, N'VE ', N'VENEZUELA', N'Venezuela', N'VEN', 862, 58, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (232, N'VN ', N'VIET NAM', N'Viet Nam', N'VNM', 704, 84, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (233, N'VG ', N'VIRGIN ISLANDS, BRITISH', N'Virgin Islands, British', N'VGB', 92, 1284, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (234, N'VI ', N'VIRGIN ISLANDS, U.S.', N'Virgin Islands, U.s.', N'VIR', 850, 1340, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (235, N'WF ', N'WALLIS AND FUTUNA', N'Wallis and Futuna', N'WLF', 876, 681, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (236, N'EH ', N'WESTERN SAHARA', N'Western Sahara', N'ESH', 732, 212, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (237, N'YE ', N'YEMEN', N'Yemen', N'YEM', 887, 967, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (238, N'ZM ', N'ZAMBIA', N'Zambia', N'ZMB', 894, 260, NULL)
GO
INSERT [dbo].[Countries] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate], [UserId]) VALUES (239, N'ZW ', N'ZIMBABWE', N'Zimbabwe', N'ZWE', 716, 263, NULL)
GO


SET IDENTITY_INSERT [Currency].[CurrencyId] OFF
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (1, N'AFGHANISTAN', N'Afghani', N'AFN', N'971', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (2, N'ALBANIA', N'Lek', N'ALL', N'8', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (3, N'ALGERIA', N'Algerian Dinar', N'DZD', N'12', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (4, N'AMERICAN SAMOA', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (5, N'ANDORRA', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (6, N'ANGOLA', N'Kwanza', N'AOA', N'973', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (7, N'ANGUILLA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (8, N'ANTIGUA AND BARBUDA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (9, N'ARGENTINA', N'Argentine Peso', N'ARS', N'32', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (10, N'ARMENIA', N'Armenian Dram', N'AMD', N'51', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (11, N'ARUBA', N'Aruban Florin', N'AWG', N'533', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (12, N'AUSTRALIA', N'Australian Dollar', N'AUD', N'36', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (13, N'AUSTRIA', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (14, N'AZERBAIJAN', N'Azerbaijanian Manat', N'AZN', N'944', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (15, N'BAHAMAS', N'Bahamian Dollar', N'BSD', N'44', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (16, N'BAHRAIN', N'Bahraini Dinar', N'BHD', N'48', 3, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (17, N'BANGLADESH', N'Taka', N'BDT', N'50', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (18, N'BARBADOS', N'Barbados Dollar', N'BBD', N'52', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (19, N'BELARUS', N'Belarussian Ruble', N'BYR', N'974', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (20, N'BELGIUM', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (21, N'BELIZE', N'Belize Dollar', N'BZD', N'84', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (22, N'BENIN', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (23, N'BERMUDA', N'Bermudian Dollar', N'BMD', N'60', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (24, N'BHUTAN', N'Ngultrum', N'BTN', N'64', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (25, N'BHUTAN', N'Indian Rupee', N'INR', N'356', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (26, N'BOSNIA AND HERZEGOVINA', N'Convertible Mark', N'BAM', N'977', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (27, N'BOTSWANA', N'Pula', N'BWP', N'72', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (28, N'BOUVET ISLAND', N'Norwegian Krone', N'NOK', N'578', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (29, N'BRAZIL', N'Brazilian Real', N'BRL', N'986', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (30, N'BRITISH INDIAN OCEAN TERRITORY', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (31, N'BRUNEI DARUSSALAM', N'Brunei Dollar', N'BND', N'96', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (32, N'BULGARIA', N'Bulgarian Lev', N'BGN', N'975', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (33, N'BURKINA FASO', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (34, N'BURUNDI', N'Burundi Franc', N'BIF', N'108', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (35, N'CAMBODIA', N'Riel', N'KHR', N'116', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (36, N'CAMEROON', N'CFA Franc BEAC', N'XAF', N'950', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (37, N'CANADA', N'Canadian Dollar', N'CAD', N'124', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (38, N'CAPE VERDE', N'Cape Verde Escudo', N'CVE', N'132', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (39, N'CAYMAN ISLANDS', N'Cayman Islands Dollar', N'KYD', N'136', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (40, N'CENTRAL AFRICAN REPUBLIC', N'CFA Franc BEAC', N'XAF', N'950', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (41, N'CHAD', N'CFA Franc BEAC', N'XAF', N'950', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (42, N'CHILE', N'Unidades de fomento', N'CLF', N'990', 0, 1)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (43, N'CHILE', N'Chilean Peso', N'CLP', N'152', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (44, N'CHINA', N'Yuan Renminbi', N'CNY', N'156', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (45, N'CHRISTMAS ISLAND', N'Australian Dollar', N'AUD', N'36', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (46, N'COCOS (KEELING) ISLANDS', N'Australian Dollar', N'AUD', N'36', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (47, N'COLOMBIA', N'Colombian Peso', N'COP', N'170', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (48, N'COLOMBIA', N'Unidad de Valor Real', N'COU', N'970', 2, 1)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (49, N'COMOROS', N'Comoro Franc', N'KMF', N'174', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (50, N'CONGO', N'CFA Franc BEAC', N'XAF', N'950', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (51, N'COOK ISLANDS', N'New Zealand Dollar', N'NZD', N'554', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (52, N'COSTA RICA', N'Costa Rican Colon', N'CRC', N'188', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (53, N'CROATIA', N'Croatian Kuna', N'HRK', N'191', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (54, N'CUBA', N'Peso Convertible', N'CUC', N'931', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (55, N'CUBA', N'Cuban Peso', N'CUP', N'192', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (56, N'CYPRUS', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (57, N'CZECH REPUBLIC', N'Czech Koruna', N'CZK', N'203', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (58, N'DENMARK', N'Danish Krone', N'DKK', N'208', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (59, N'DJIBOUTI', N'Djibouti Franc', N'DJF', N'262', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (60, N'DOMINICA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (61, N'DOMINICAN REPUBLIC', N'Dominican Peso', N'DOP', N'214', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (62, N'ECUADOR', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (63, N'EGYPT', N'Egyptian Pound', N'EGP', N'818', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (64, N'EL SALVADOR', N'El Salvador Colon', N'SVC', N'222', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (65, N'EL SALVADOR', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (66, N'EQUATORIAL GUINEA', N'CFA Franc BEAC', N'XAF', N'950', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (67, N'ERITREA', N'Nakfa', N'ERN', N'232', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (68, N'ESTONIA', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (69, N'ETHIOPIA', N'Ethiopian Birr', N'ETB', N'230', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (70, N'FALKLAND ISLANDS (MALVINAS)', N'Falkland Islands Pound', N'FKP', N'238', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (71, N'FAROE ISLANDS', N'Danish Krone', N'DKK', N'208', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (72, N'FIJI', N'Fiji Dollar', N'FJD', N'242', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (73, N'FINLAND', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (74, N'FRANCE', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (75, N'FRENCH GUIANA', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (76, N'FRENCH POLYNESIA', N'CFP Franc', N'XPF', N'953', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (77, N'FRENCH SOUTHERN TERRITORIES', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (78, N'GABON', N'CFA Franc BEAC', N'XAF', N'950', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (79, N'GAMBIA', N'Dalasi', N'GMD', N'270', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (80, N'GEORGIA', N'Lari', N'GEL', N'981', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (81, N'GERMANY', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (82, N'GHANA', N'Ghana Cedi', N'GHS', N'936', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (83, N'GIBRALTAR', N'Gibraltar Pound', N'GIP', N'292', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (84, N'GREECE', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (85, N'GREENLAND', N'Danish Krone', N'DKK', N'208', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (86, N'GRENADA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (87, N'GUADELOUPE', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (88, N'GUAM', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (89, N'GUATEMALA', N'Quetzal', N'GTQ', N'320', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (90, N'GUINEA', N'Guinea Franc', N'GNF', N'324', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (91, N'GUINEA-BISSAU', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (92, N'GUYANA', N'Guyana Dollar', N'GYD', N'328', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (93, N'HAITI', N'Gourde', N'HTG', N'332', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (94, N'HAITI', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (95, N'HEARD ISLAND AND McDONALD ISLANDS', N'Australian Dollar', N'AUD', N'36', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (96, N'HOLY SEE (VATICAN CITY STATE)', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (97, N'HONDURAS', N'Lempira', N'HNL', N'340', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (98, N'HONG KONG', N'Hong Kong Dollar', N'HKD', N'344', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (99, N'HUNGARY', N'Forint', N'HUF', N'348', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (100, N'ICELAND', N'Iceland Krona', N'ISK', N'352', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (101, N'INDIA', N'Indian Rupee', N'INR', N'356', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (102, N'INDONESIA', N'Rupiah', N'IDR', N'360', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (103, N'IRAN, ISLAMIC REPUBLIC OF', N'Iranian Rial', N'IRR', N'364', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (104, N'IRAQ', N'Iraqi Dinar', N'IQD', N'368', 3, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (105, N'IRELAND', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (106, N'ISRAEL', N'New Israeli Sheqel', N'ILS', N'376', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (107, N'ITALY', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (108, N'JAMAICA', N'Jamaican Dollar', N'JMD', N'388', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (109, N'JAPAN', N'Yen', N'JPY', N'392', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (110, N'JORDAN', N'Jordanian Dinar', N'JOD', N'400', 3, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (111, N'KAZAKHSTAN', N'Tenge', N'KZT', N'398', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (112, N'KENYA', N'Kenyan Shilling', N'KES', N'404', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (113, N'KIRIBATI', N'Australian Dollar', N'AUD', N'36', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (114, N'KOREA, REPUBLIC OF', N'Won', N'KRW', N'410', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (115, N'KUWAIT', N'Kuwaiti Dinar', N'KWD', N'414', 3, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (116, N'KYRGYZSTAN', N'Som', N'KGS', N'417', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (117, N'LATVIA', N'Latvian Lats', N'LVL', N'428', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (118, N'LEBANON', N'Lebanese Pound', N'LBP', N'422', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (119, N'LESOTHO', N'Loti', N'LSL', N'426', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (120, N'LESOTHO', N'Rand', N'ZAR', N'710', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (121, N'LIBERIA', N'Liberian Dollar', N'LRD', N'430', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (122, N'LIECHTENSTEIN', N'Swiss Franc', N'CHF', N'756', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (123, N'LITHUANIA', N'Lithuanian Litas', N'LTL', N'440', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (124, N'LUXEMBOURG', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (125, N'MACAO', N'Pataca', N'MOP', N'446', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (126, N'MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF', N'Denar', N'MKD', N'807', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (127, N'MADAGASCAR', N'Malagasy Ariary', N'MGA', N'969', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (128, N'MALAWI', N'Kwacha', N'MWK', N'454', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (129, N'MALAYSIA', N'Malaysian Ringgit', N'MYR', N'458', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (130, N'MALDIVES', N'Rufiyaa', N'MVR', N'462', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (131, N'MALI', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (132, N'MALTA', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (133, N'MARSHALL ISLANDS', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (134, N'MARTINIQUE', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (135, N'MAURITANIA', N'Ouguiya', N'MRO', N'478', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (136, N'MAURITIUS', N'Mauritius Rupee', N'MUR', N'480', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (137, N'MAYOTTE', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (138, N'MEXICO', N'Mexican Peso', N'MXN', N'484', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (139, N'MEXICO', N'Mexican Unidad de Inversion (UDI)', N'MXV', N'979', 2, 1)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (140, N'MICRONESIA, FEDERATED STATES OF', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (141, N'MOLDOVA, REPUBLIC OF', N'Moldovan Leu', N'MDL', N'498', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (142, N'MONACO', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (143, N'MONGOLIA', N'Tugrik', N'MNT', N'496', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (144, N'MONTSERRAT', N'East Caribbean Dollar', N'XCD', N'951', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (145, N'MOROCCO', N'Moroccan Dirham', N'MAD', N'504', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (146, N'MOZAMBIQUE', N'Mozambique Metical', N'MZN', N'943', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (147, N'MYANMAR', N'Kyat', N'MMK', N'104', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (148, N'NAMIBIA', N'Namibia Dollar', N'NAD', N'516', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (149, N'NAMIBIA', N'Rand', N'ZAR', N'710', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (150, N'NAURU', N'Australian Dollar', N'AUD', N'36', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (151, N'NEPAL', N'Nepalese Rupee', N'NPR', N'524', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (152, N'NETHERLANDS', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (153, N'NEW CALEDONIA', N'CFP Franc', N'XPF', N'953', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (154, N'NEW ZEALAND', N'New Zealand Dollar', N'NZD', N'554', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (155, N'NICARAGUA', N'Cordoba Oro', N'NIO', N'558', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (156, N'NIGER', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (157, N'NIGERIA', N'Naira', N'NGN', N'566', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (158, N'NIUE', N'New Zealand Dollar', N'NZD', N'554', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (159, N'NORFOLK ISLAND', N'Australian Dollar', N'AUD', N'36', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (160, N'NORTHERN MARIANA ISLANDS', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (161, N'NORWAY', N'Norwegian Krone', N'NOK', N'578', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (162, N'OMAN', N'Rial Omani', N'OMR', N'512', 3, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (163, N'PAKISTAN', N'Pakistan Rupee', N'PKR', N'586', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (164, N'PALAU', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (165, N'PANAMA', N'Balboa', N'PAB', N'590', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (166, N'PANAMA', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (167, N'PAPUA NEW GUINEA', N'Kina', N'PGK', N'598', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (168, N'PARAGUAY', N'Guarani', N'PYG', N'600', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (169, N'PERU', N'Nuevo Sol', N'PEN', N'604', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (170, N'PHILIPPINES', N'Philippine Peso', N'PHP', N'608', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (171, N'PITCAIRN', N'New Zealand Dollar', N'NZD', N'554', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (172, N'POLAND', N'Zloty', N'PLN', N'985', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (173, N'PORTUGAL', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (174, N'PUERTO RICO', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (175, N'QATAR', N'Qatari Rial', N'QAR', N'634', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (176, N'ROMANIA', N'New Romanian Leu', N'RON', N'946', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (177, N'RUSSIAN FEDERATION', N'Russian Ruble', N'RUB', N'643', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (178, N'RWANDA', N'Rwanda Franc', N'RWF', N'646', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (179, N'SAINT KITTS AND NEVIS', N'East Caribbean Dollar', N'XCD', N'951', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (180, N'SAINT LUCIA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (181, N'SAINT PIERRE AND MIQUELON', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (182, N'SAINT VINCENT AND THE GRENADINES', N'East Caribbean Dollar', N'XCD', N'951', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (183, N'SAMOA', N'Tala', N'WST', N'882', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (184, N'SAN MARINO', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (185, N'SAO TOME AND PRINCIPE', N'Dobra', N'STD', N'678', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (186, N'SAUDI ARABIA', N'Saudi Riyal', N'SAR', N'682', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (187, N'SENEGAL', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (188, N'SEYCHELLES', N'Seychelles Rupee', N'SCR', N'690', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (189, N'SIERRA LEONE', N'Leone', N'SLL', N'694', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (190, N'SINGAPORE', N'Singapore Dollar', N'SGD', N'702', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (191, N'SLOVAKIA', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (192, N'SLOVENIA', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (193, N'SOLOMON ISLANDS', N'Solomon Islands Dollar', N'SBD', N'90', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (194, N'SOMALIA', N'Somali Shilling', N'SOS', N'706', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (195, N'SOUTH AFRICA', N'Rand', N'ZAR', N'710', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (196, N'SPAIN', N'Euro', N'EUR', N'978', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (197, N'SRI LANKA', N'Sri Lanka Rupee', N'LKR', N'144', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (198, N'SUDAN', N'Sudanese Pound', N'SDG', N'938', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (199, N'SURINAME', N'Surinam Dollar', N'SRD', N'968', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (200, N'SVALBARD AND JAN MAYEN', N'Norwegian Krone', N'NOK', N'578', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (201, N'SWAZILAND', N'Lilangeni', N'SZL', N'748', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (202, N'SWEDEN', N'Swedish Krona', N'SEK', N'752', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (203, N'SWITZERLAND', N'WIR Euro', N'CHE', N'947', 2, 1)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (204, N'SWITZERLAND', N'Swiss Franc', N'CHF', N'756', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (205, N'SWITZERLAND', N'WIR Franc', N'CHW', N'948', 2, 1)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (206, N'SYRIAN ARAB REPUBLIC', N'Syrian Pound', N'SYP', N'760', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (207, N'TAIWAN, PROVINCE OF CHINA', N'New Taiwan Dollar', N'TWD', N'901', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (208, N'TAJIKISTAN', N'Somoni', N'TJS', N'972', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (209, N'TANZANIA, UNITED REPUBLIC OF', N'Tanzanian Shilling', N'TZS', N'834', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (210, N'THAILAND', N'Baht', N'THB', N'764', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (211, N'TIMOR-LESTE', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (212, N'TOGO', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (213, N'TOKELAU', N'New Zealand Dollar', N'NZD', N'554', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (214, N'TONGA', N'Pa’anga', N'TOP', N'776', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (215, N'TRINIDAD AND TOBAGO', N'Trinidad and Tobago Dollar', N'TTD', N'780', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (216, N'TUNISIA', N'Tunisian Dinar', N'TND', N'788', 3, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (217, N'TURKEY', N'Turkish Lira', N'TRY', N'949', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (218, N'TURKMENISTAN', N'Turkmenistan New Manat', N'TMT', N'934', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (219, N'TURKS AND CAICOS ISLANDS', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (220, N'TUVALU', N'Australian Dollar', N'AUD', N'36', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (221, N'UGANDA', N'Uganda Shilling', N'UGX', N'800', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (222, N'UKRAINE', N'Hryvnia', N'UAH', N'980', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (223, N'UNITED ARAB EMIRATES', N'UAE Dirham', N'AED', N'784', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (224, N'UNITED KINGDOM', N'Pound Sterling', N'GBP', N'826', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (225, N'UNITED STATES', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (226, N'UNITED STATES', N'US Dollar (Next day)', N'USN', N'997', 2, 1)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (227, N'UNITED STATES', N'US Dollar (Same day)', N'USS', N'998', 2, 1)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (228, N'UNITED STATES MINOR OUTLYING ISLANDS', N'US Dollar', N'USD', N'840', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (229, N'URUGUAY', N'Uruguay Peso en Unidades Indexadas (URUIURUI)', N'UYI', N'940', 0, 1)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (230, N'URUGUAY', N'Peso Uruguayo', N'UYU', N'858', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (231, N'UZBEKISTAN', N'Uzbekistan Sum', N'UZS', N'860', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (232, N'VANUATU', N'Vatu', N'VUV', N'548', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (233, N'VIET NAM', N'Dong', N'VND', N'704', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (234, N'WALLIS AND FUTUNA', N'CFP Franc', N'XPF', N'953', 0, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (235, N'WESTERN SAHARA', N'Moroccan Dirham', N'MAD', N'504', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (236, N'YEMEN', N'Yemeni Rial', N'YER', N'886', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (237, N'ZAMBIA', N'Zambian Kwacha', N'ZMW', N'967', 2, 0)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (238, N'ZIMBABWE', N'Zimbabwe Dollar', N'ZWL', N'932', 2, 0)
GO
SET IDENTITY_INSERT [Currency].[CurrencyId] ON
GO