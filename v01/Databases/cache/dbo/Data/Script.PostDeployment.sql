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
USE [cache]
GO

INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (1, N'AF ', N'AFGHANISTAN', N'Afghanistan', N'AFG', 4, 93, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (2, N'AL ', N'ALBANIA', N'Albania', N'ALB', 8, 355, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (3, N'DZ ', N'ALGERIA', N'Algeria', N'DZA', 12, 213, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (4, N'AS ', N'AMERICAN SAMOA', N'American Samoa', N'ASM', 16, 1684, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (5, N'AD ', N'ANDORRA', N'Andorra', N'AND', 20, 376, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (6, N'AO ', N'ANGOLA', N'Angola', N'AGO', 24, 244, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (7, N'AI ', N'ANGUILLA', N'Anguilla', N'AIA', 660, 1264, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (8, N'AQ ', N'ANTARCTICA', N'Antarctica', NULL, NULL, 0, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (9, N'AG ', N'ANTIGUA AND BARBUDA', N'Antigua and Barbuda', N'ATG', 28, 1268, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (10, N'AR ', N'ARGENTINA', N'Argentina', N'ARG', 32, 54, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (11, N'AM ', N'ARMENIA', N'Armenia', N'ARM', 51, 374, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (12, N'AW ', N'ARUBA', N'Aruba', N'ABW', 533, 297, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (13, N'AU ', N'AUSTRALIA', N'Australia', N'AUS', 36, 61, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (14, N'AT ', N'AUSTRIA', N'Austria', N'AUT', 40, 43, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (15, N'AZ ', N'AZERBAIJAN', N'Azerbaijan', N'AZE', 31, 994, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (16, N'BS ', N'BAHAMAS', N'Bahamas', N'BHS', 44, 1242, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (17, N'BH ', N'BAHRAIN', N'Bahrain', N'BHR', 48, 973, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (18, N'BD ', N'BANGLADESH', N'Bangladesh', N'BGD', 50, 880, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (19, N'BB ', N'BARBADOS', N'Barbados', N'BRB', 52, 1246, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (20, N'BY ', N'BELARUS', N'Belarus', N'BLR', 112, 375, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (21, N'BE ', N'BELGIUM', N'Belgium', N'BEL', 56, 32, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (22, N'BZ ', N'BELIZE', N'Belize', N'BLZ', 84, 501, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (23, N'BJ ', N'BENIN', N'Benin', N'BEN', 204, 229, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (24, N'BM ', N'BERMUDA', N'Bermuda', N'BMU', 60, 1441, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (25, N'BT ', N'BHUTAN', N'Bhutan', N'BTN', 64, 975, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (26, N'BO ', N'BOLIVIA', N'Bolivia', N'BOL', 68, 591, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (27, N'BA ', N'BOSNIA AND HERZEGOVINA', N'Bosnia and Herzegovina', N'BIH', 70, 387, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (28, N'BW ', N'BOTSWANA', N'Botswana', N'BWA', 72, 267, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (29, N'BV ', N'BOUVET ISLAND', N'Bouvet Island', NULL, NULL, 0, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (30, N'BR ', N'BRAZIL', N'Brazil', N'BRA', 76, 55, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (31, N'IO ', N'BRITISH INDIAN OCEAN TERRITORY', N'British Indian Ocean Territory', NULL, NULL, 246, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (32, N'BN ', N'BRUNEI DARUSSALAM', N'Brunei Darussalam', N'BRN', 96, 673, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (33, N'BG ', N'BULGARIA', N'Bulgaria', N'BGR', 100, 359, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (34, N'BF ', N'BURKINA FASO', N'Burkina Faso', N'BFA', 854, 226, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (35, N'BI ', N'BURUNDI', N'Burundi', N'BDI', 108, 257, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (36, N'KH ', N'CAMBODIA', N'Cambodia', N'KHM', 116, 855, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (37, N'CM ', N'CAMEROON', N'Cameroon', N'CMR', 120, 237, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (38, N'CA ', N'CANADA', N'Canada', N'CAN', 124, 1, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (39, N'CV ', N'CAPE VERDE', N'Cape Verde', N'CPV', 132, 238, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (40, N'KY ', N'CAYMAN ISLANDS', N'Cayman Islands', N'CYM', 136, 1345, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (41, N'CF ', N'CENTRAL AFRICAN REPUBLIC', N'Central African Republic', N'CAF', 140, 236, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (42, N'TD ', N'CHAD', N'Chad', N'TCD', 148, 235, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (43, N'CL ', N'CHILE', N'Chile', N'CHL', 152, 56, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (44, N'CN ', N'CHINA', N'China', N'CHN', 156, 86, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (45, N'CX ', N'CHRISTMAS ISLAND', N'Christmas Island', NULL, NULL, 61, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (46, N'CC ', N'COCOS (KEELING) ISLANDS', N'Cocos (Keeling) Islands', NULL, NULL, 672, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (47, N'CO ', N'COLOMBIA', N'Colombia', N'COL', 170, 57, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (48, N'KM ', N'COMOROS', N'Comoros', N'COM', 174, 269, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (49, N'CG ', N'CONGO', N'Congo', N'COG', 178, 242, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (50, N'CD ', N'CONGO, THE DEMOCRATIC REPUBLIC OF THE', N'Congo, the Democratic Republic of the', N'COD', 180, 242, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (51, N'CK ', N'COOK ISLANDS', N'Cook Islands', N'COK', 184, 682, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (52, N'CR ', N'COSTA RICA', N'Costa Rica', N'CRI', 188, 506, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (53, N'CI ', N'COTE D''IVOIRE', N'Cote D''Ivoire', N'CIV', 384, 225, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (54, N'HR ', N'CROATIA', N'Croatia', N'HRV', 191, 385, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (55, N'CU ', N'CUBA', N'Cuba', N'CUB', 192, 53, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (56, N'CY ', N'CYPRUS', N'Cyprus', N'CYP', 196, 357, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (57, N'CZ ', N'CZECH REPUBLIC', N'Czech Republic', N'CZE', 203, 420, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (58, N'DK ', N'DENMARK', N'Denmark', N'DNK', 208, 45, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (59, N'DJ ', N'DJIBOUTI', N'Djibouti', N'DJI', 262, 253, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (60, N'DM ', N'DOMINICA', N'Dominica', N'DMA', 212, 1767, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (61, N'DO ', N'DOMINICAN REPUBLIC', N'Dominican Republic', N'DOM', 214, 1809, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (62, N'EC ', N'ECUADOR', N'Ecuador', N'ECU', 218, 593, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (63, N'EG ', N'EGYPT', N'Egypt', N'EGY', 818, 20, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (64, N'SV ', N'EL SALVADOR', N'El Salvador', N'SLV', 222, 503, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (65, N'GQ ', N'EQUATORIAL GUINEA', N'Equatorial Guinea', N'GNQ', 226, 240, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (66, N'ER ', N'ERITREA', N'Eritrea', N'ERI', 232, 291, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (67, N'EE ', N'ESTONIA', N'Estonia', N'EST', 233, 372, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (68, N'ET ', N'ETHIOPIA', N'Ethiopia', N'ETH', 231, 251, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (69, N'FK ', N'FALKLAND ISLANDS (MALVINAS)', N'Falkland Islands (Malvinas)', N'FLK', 238, 500, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (70, N'FO ', N'FAROE ISLANDS', N'Faroe Islands', N'FRO', 234, 298, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (71, N'FJ ', N'FIJI', N'Fiji', N'FJI', 242, 679, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (72, N'FI ', N'FINLAND', N'Finland', N'FIN', 246, 358, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (73, N'FR ', N'FRANCE', N'France', N'FRA', 250, 33, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (74, N'GF ', N'FRENCH GUIANA', N'French Guiana', N'GUF', 254, 594, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (75, N'PF ', N'FRENCH POLYNESIA', N'French Polynesia', N'PYF', 258, 689, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (76, N'TF ', N'FRENCH SOUTHERN TERRITORIES', N'French Southern Territories', NULL, NULL, 0, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (77, N'GA ', N'GABON', N'Gabon', N'GAB', 266, 241, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (78, N'GM ', N'GAMBIA', N'Gambia', N'GMB', 270, 220, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (79, N'GE ', N'GEORGIA', N'Georgia', N'GEO', 268, 995, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (80, N'DE ', N'GERMANY', N'Germany', N'DEU', 276, 49, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (81, N'GH ', N'GHANA', N'Ghana', N'GHA', 288, 233, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (82, N'GI ', N'GIBRALTAR', N'Gibraltar', N'GIB', 292, 350, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (83, N'GR ', N'GREECE', N'Greece', N'GRC', 300, 30, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (84, N'GL ', N'GREENLAND', N'Greenland', N'GRL', 304, 299, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (85, N'GD ', N'GRENADA', N'Grenada', N'GRD', 308, 1473, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (86, N'GP ', N'GUADELOUPE', N'Guadeloupe', N'GLP', 312, 590, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (87, N'GU ', N'GUAM', N'Guam', N'GUM', 316, 1671, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (88, N'GT ', N'GUATEMALA', N'Guatemala', N'GTM', 320, 502, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (89, N'GN ', N'GUINEA', N'Guinea', N'GIN', 324, 224, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (90, N'GW ', N'GUINEA-BISSAU', N'Guinea-Bissau', N'GNB', 624, 245, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (91, N'GY ', N'GUYANA', N'Guyana', N'GUY', 328, 592, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (92, N'HT ', N'HAITI', N'Haiti', N'HTI', 332, 509, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (93, N'HM ', N'HEARD ISLAND AND MCDONALD ISLANDS', N'Heard Island and Mcdonald Islands', NULL, NULL, 0, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (94, N'VA ', N'HOLY SEE (VATICAN CITY STATE)', N'Holy See (Vatican City State)', N'VAT', 336, 39, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (95, N'HN ', N'HONDURAS', N'Honduras', N'HND', 340, 504, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (96, N'HK ', N'HONG KONG', N'Hong Kong', N'HKG', 344, 852, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (97, N'HU ', N'HUNGARY', N'Hungary', N'HUN', 348, 36, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (98, N'IS ', N'ICELAND', N'Iceland', N'ISL', 352, 354, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (99, N'IN ', N'INDIA', N'India', N'IND', 356, 91, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (100, N'ID ', N'INDONESIA', N'Indonesia', N'IDN', 360, 62, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (101, N'IR ', N'IRAN, ISLAMIC REPUBLIC OF', N'Iran, Islamic Republic of', N'IRN', 364, 98, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (102, N'IQ ', N'IRAQ', N'Iraq', N'IRQ', 368, 964, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (103, N'IE ', N'IRELAND', N'Ireland', N'IRL', 372, 353, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (104, N'IL ', N'ISRAEL', N'Israel', N'ISR', 376, 972, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (105, N'IT ', N'ITALY', N'Italy', N'ITA', 380, 39, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (106, N'JM ', N'JAMAICA', N'Jamaica', N'JAM', 388, 1876, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (107, N'JP ', N'JAPAN', N'Japan', N'JPN', 392, 81, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (108, N'JO ', N'JORDAN', N'Jordan', N'JOR', 400, 962, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (109, N'KZ ', N'KAZAKHSTAN', N'Kazakhstan', N'KAZ', 398, 7, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (110, N'KE ', N'KENYA', N'Kenya', N'KEN', 404, 254, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (111, N'KI ', N'KIRIBATI', N'Kiribati', N'KIR', 296, 686, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (112, N'KP ', N'KOREA, DEMOCRATIC PEOPLE''S REPUBLIC OF', N'Korea, Democratic People''s Republic of', N'PRK', 408, 850, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (113, N'KR ', N'KOREA, REPUBLIC OF', N'Korea, Republic of', N'KOR', 410, 82, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (114, N'KW ', N'KUWAIT', N'Kuwait', N'KWT', 414, 965, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (115, N'KG ', N'KYRGYZSTAN', N'Kyrgyzstan', N'KGZ', 417, 996, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (116, N'LA ', N'LAO PEOPLE''S DEMOCRATIC REPUBLIC', N'Lao People''s Democratic Republic', N'LAO', 418, 856, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (117, N'LV ', N'LATVIA', N'Latvia', N'LVA', 428, 371, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (118, N'LB ', N'LEBANON', N'Lebanon', N'LBN', 422, 961, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (119, N'LS ', N'LESOTHO', N'Lesotho', N'LSO', 426, 266, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (120, N'LR ', N'LIBERIA', N'Liberia', N'LBR', 430, 231, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (121, N'LY ', N'LIBYAN ARAB JAMAHIRIYA', N'Libyan Arab Jamahiriya', N'LBY', 434, 218, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (122, N'LI ', N'LIECHTENSTEIN', N'Liechtenstein', N'LIE', 438, 423, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (123, N'LT ', N'LITHUANIA', N'Lithuania', N'LTU', 440, 370, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (124, N'LU ', N'LUXEMBOURG', N'Luxembourg', N'LUX', 442, 352, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (125, N'MO ', N'MACAO', N'Macao', N'MAC', 446, 853, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (126, N'MK ', N'MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF', N'Macedonia, the Former Yugoslav Republic of', N'MKD', 807, 389, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (127, N'MG ', N'MADAGASCAR', N'Madagascar', N'MDG', 450, 261, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (128, N'MW ', N'MALAWI', N'Malawi', N'MWI', 454, 265, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (129, N'MY ', N'MALAYSIA', N'Malaysia', N'MYS', 458, 60, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (130, N'MV ', N'MALDIVES', N'Maldives', N'MDV', 462, 960, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (131, N'ML ', N'MALI', N'Mali', N'MLI', 466, 223, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (132, N'MT ', N'MALTA', N'Malta', N'MLT', 470, 356, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (133, N'MH ', N'MARSHALL ISLANDS', N'Marshall Islands', N'MHL', 584, 692, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (134, N'MQ ', N'MARTINIQUE', N'Martinique', N'MTQ', 474, 596, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (135, N'MR ', N'MAURITANIA', N'Mauritania', N'MRT', 478, 222, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (136, N'MU ', N'MAURITIUS', N'Mauritius', N'MUS', 480, 230, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (137, N'YT ', N'MAYOTTE', N'Mayotte', NULL, NULL, 269, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (138, N'MX ', N'MEXICO', N'Mexico', N'MEX', 484, 52, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (139, N'FM ', N'MICRONESIA, FEDERATED STATES OF', N'Micronesia, Federated States of', N'FSM', 583, 691, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (140, N'MD ', N'MOLDOVA, REPUBLIC OF', N'Moldova, Republic of', N'MDA', 498, 373, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (141, N'MC ', N'MONACO', N'Monaco', N'MCO', 492, 377, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (142, N'MN ', N'MONGOLIA', N'Mongolia', N'MNG', 496, 976, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (143, N'MS ', N'MONTSERRAT', N'Montserrat', N'MSR', 500, 1664, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (144, N'MA ', N'MOROCCO', N'Morocco', N'MAR', 504, 212, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (145, N'MZ ', N'MOZAMBIQUE', N'Mozambique', N'MOZ', 508, 258, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (146, N'MM ', N'MYANMAR', N'Myanmar', N'MMR', 104, 95, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (147, N'NA ', N'NAMIBIA', N'Namibia', N'NAM', 516, 264, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (148, N'NR ', N'NAURU', N'Nauru', N'NRU', 520, 674, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (149, N'NP ', N'NEPAL', N'Nepal', N'NPL', 524, 977, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (150, N'NL ', N'NETHERLANDS', N'Netherlands', N'NLD', 528, 31, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (151, N'AN ', N'NETHERLANDS ANTILLES', N'Netherlands Antilles', N'ANT', 530, 599, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (152, N'NC ', N'NEW CALEDONIA', N'New Caledonia', N'NCL', 540, 687, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (153, N'NZ ', N'NEW ZEALAND', N'New Zealand', N'NZL', 554, 64, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (154, N'NI ', N'NICARAGUA', N'Nicaragua', N'NIC', 558, 505, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (155, N'NE ', N'NIGER', N'Niger', N'NER', 562, 227, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (156, N'NG ', N'NIGERIA', N'Nigeria', N'NGA', 566, 234, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (157, N'NU ', N'NIUE', N'Niue', N'NIU', 570, 683, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (158, N'NF ', N'NORFOLK ISLAND', N'Norfolk Island', N'NFK', 574, 672, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (159, N'MP ', N'NORTHERN MARIANA ISLANDS', N'Northern Mariana Islands', N'MNP', 580, 1670, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (160, N'NO ', N'NORWAY', N'Norway', N'NOR', 578, 47, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (161, N'OM ', N'OMAN', N'Oman', N'OMN', 512, 968, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (162, N'PK ', N'PAKISTAN', N'Pakistan', N'PAK', 586, 92, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (163, N'PW ', N'PALAU', N'Palau', N'PLW', 585, 680, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (164, N'PS ', N'PALESTINIAN TERRITORY, OCCUPIED', N'Palestinian Territory, Occupied', NULL, NULL, 970, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (165, N'PA ', N'PANAMA', N'Panama', N'PAN', 591, 507, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (166, N'PG ', N'PAPUA NEW GUINEA', N'Papua New Guinea', N'PNG', 598, 675, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (167, N'PY ', N'PARAGUAY', N'Paraguay', N'PRY', 600, 595, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (168, N'PE ', N'PERU', N'Peru', N'PER', 604, 51, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (169, N'PH ', N'PHILIPPINES', N'Philippines', N'PHL', 608, 63, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (170, N'PN ', N'PITCAIRN', N'Pitcairn', N'PCN', 612, 0, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (171, N'PL ', N'POLAND', N'Poland', N'POL', 616, 48, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (172, N'PT ', N'PORTUGAL', N'Portugal', N'PRT', 620, 351, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (173, N'PR ', N'PUERTO RICO', N'Puerto Rico', N'PRI', 630, 1787, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (174, N'QA ', N'QATAR', N'Qatar', N'QAT', 634, 974, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (175, N'RE ', N'REUNION', N'Reunion', N'REU', 638, 262, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (176, N'RO ', N'ROMANIA', N'Romania', N'ROM', 642, 40, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (177, N'RU ', N'RUSSIAN FEDERATION', N'Russian Federation', N'RUS', 643, 70, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (178, N'RW ', N'RWANDA', N'Rwanda', N'RWA', 646, 250, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (179, N'SH ', N'SAINT HELENA', N'Saint Helena', N'SHN', 654, 290, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (180, N'KN ', N'SAINT KITTS AND NEVIS', N'Saint Kitts and Nevis', N'KNA', 659, 1869, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (181, N'LC ', N'SAINT LUCIA', N'Saint Lucia', N'LCA', 662, 1758, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (182, N'PM ', N'SAINT PIERRE AND MIQUELON', N'Saint Pierre and Miquelon', N'SPM', 666, 508, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (183, N'VC ', N'SAINT VINCENT AND THE GRENADINES', N'Saint Vincent and the Grenadines', N'VCT', 670, 1784, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (184, N'WS ', N'SAMOA', N'Samoa', N'WSM', 882, 684, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (185, N'SM ', N'SAN MARINO', N'San Marino', N'SMR', 674, 378, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (186, N'ST ', N'SAO TOME AND PRINCIPE', N'Sao Tome and Principe', N'STP', 678, 239, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (187, N'SA ', N'SAUDI ARABIA', N'Saudi Arabia', N'SAU', 682, 966, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (188, N'SN ', N'SENEGAL', N'Senegal', N'SEN', 686, 221, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (189, N'CS ', N'SERBIA AND MONTENEGRO', N'Serbia and Montenegro', NULL, NULL, 381, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (190, N'SC ', N'SEYCHELLES', N'Seychelles', N'SYC', 690, 248, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (191, N'SL ', N'SIERRA LEONE', N'Sierra Leone', N'SLE', 694, 232, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (192, N'SG ', N'SINGAPORE', N'Singapore', N'SGP', 702, 65, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (193, N'SK ', N'SLOVAKIA', N'Slovakia', N'SVK', 703, 421, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (194, N'SI ', N'SLOVENIA', N'Slovenia', N'SVN', 705, 386, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (195, N'SB ', N'SOLOMON ISLANDS', N'Solomon Islands', N'SLB', 90, 677, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (196, N'SO ', N'SOMALIA', N'Somalia', N'SOM', 706, 252, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (197, N'ZA ', N'SOUTH AFRICA', N'South Africa', N'ZAF', 710, 27, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (198, N'GS ', N'SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS', N'South Georgia and the South Sandwich Islands', NULL, NULL, 0, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (199, N'ES ', N'SPAIN', N'Spain', N'ESP', 724, 34, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (200, N'LK ', N'SRI LANKA', N'Sri Lanka', N'LKA', 144, 94, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (201, N'SD ', N'SUDAN', N'Sudan', N'SDN', 736, 249, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (202, N'SR ', N'SURINAME', N'Suriname', N'SUR', 740, 597, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (203, N'SJ ', N'SVALBARD AND JAN MAYEN', N'Svalbard and Jan Mayen', N'SJM', 744, 47, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (204, N'SZ ', N'SWAZILAND', N'Swaziland', N'SWZ', 748, 268, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (205, N'SE ', N'SWEDEN', N'Sweden', N'SWE', 752, 46, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (206, N'CH ', N'SWITZERLAND', N'Switzerland', N'CHE', 756, 41, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (207, N'SY ', N'SYRIAN ARAB REPUBLIC', N'Syrian Arab Republic', N'SYR', 760, 963, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (208, N'TW ', N'TAIWAN, PROVINCE OF CHINA', N'Taiwan, Province of China', N'TWN', 158, 886, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (209, N'TJ ', N'TAJIKISTAN', N'Tajikistan', N'TJK', 762, 992, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (210, N'TZ ', N'TANZANIA, UNITED REPUBLIC OF', N'Tanzania, United Republic of', N'TZA', 834, 255, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (211, N'TH ', N'THAILAND', N'Thailand', N'THA', 764, 66, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (212, N'TL ', N'TIMOR-LESTE', N'Timor-Leste', NULL, NULL, 670, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (213, N'TG ', N'TOGO', N'Togo', N'TGO', 768, 228, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (214, N'TK ', N'TOKELAU', N'Tokelau', N'TKL', 772, 690, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (215, N'TO ', N'TONGA', N'Tonga', N'TON', 776, 676, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (216, N'TT ', N'TRINIDAD AND TOBAGO', N'Trinidad and Tobago', N'TTO', 780, 1868, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (217, N'TN ', N'TUNISIA', N'Tunisia', N'TUN', 788, 216, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (218, N'TR ', N'TURKEY', N'Turkey', N'TUR', 792, 90, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (219, N'TM ', N'TURKMENISTAN', N'Turkmenistan', N'TKM', 795, 7370, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (220, N'TC ', N'TURKS AND CAICOS ISLANDS', N'Turks and Caicos Islands', N'TCA', 796, 1649, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (221, N'TV ', N'TUVALU', N'Tuvalu', N'TUV', 798, 688, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (222, N'UG ', N'UGANDA', N'Uganda', N'UGA', 800, 256, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (223, N'UA ', N'UKRAINE', N'Ukraine', N'UKR', 804, 380, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (224, N'AE ', N'UNITED ARAB EMIRATES', N'United Arab Emirates', N'ARE', 784, 971, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (225, N'GB ', N'UNITED KINGDOM', N'United Kingdom', N'GBR', 826, 44, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (226, N'US ', N'UNITED STATES', N'United States', N'USA', 840, 1, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (227, N'UM ', N'UNITED STATES MINOR OUTLYING ISLANDS', N'United States Minor Outlying Islands', NULL, NULL, 1, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (228, N'UY ', N'URUGUAY', N'Uruguay', N'URY', 858, 598, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (229, N'UZ ', N'UZBEKISTAN', N'Uzbekistan', N'UZB', 860, 998, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (230, N'VU ', N'VANUATU', N'Vanuatu', N'VUT', 548, 678, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (231, N'VE ', N'VENEZUELA', N'Venezuela', N'VEN', 862, 58, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (232, N'VN ', N'VIET NAM', N'Viet Nam', N'VNM', 704, 84, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (233, N'VG ', N'VIRGIN ISLANDS, BRITISH', N'Virgin Islands, British', N'VGB', 92, 1284, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (234, N'VI ', N'VIRGIN ISLANDS, U.S.', N'Virgin Islands, U.s.', N'VIR', 850, 1340, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (235, N'WF ', N'WALLIS AND FUTUNA', N'Wallis and Futuna', N'WLF', 876, 681, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (236, N'EH ', N'WESTERN SAHARA', N'Western Sahara', N'ESH', 732, 212, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (237, N'YE ', N'YEMEN', N'Yemen', N'YEM', 887, 967, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (238, N'ZM ', N'ZAMBIA', N'Zambia', N'ZMB', 894, 260, GETDATE())
GO
INSERT [dbo].[Country] ([CountryId], [ISO], [Name], [SentenceCaseName], [ISO3], [numcode], [phonecode], [CreatedDate]) VALUES (239, N'ZW ', N'ZIMBABWE', N'Zimbabwe', N'ZWE', 716, 263, GETDATE())
GO



SET IDENTITY_INSERT [dbo].[Currency] ON
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (1, N'AFGHANISTAN', N'Afghani', N'AFN', N'971', 2, 0, 1)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (2, N'ALBANIA', N'Lek', N'ALL', N'8', 2, 0, 2)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (3, N'ALGERIA', N'Algerian Dinar', N'DZD', N'12', 2, 0, 3)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (4, N'AMERICAN SAMOA', N'US Dollar', N'USD', N'840', 2, 0, 4)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (5, N'ANDORRA', N'Euro', N'EUR', N'978', 2, 0, 5)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (6, N'ANGOLA', N'Kwanza', N'AOA', N'973', 2, 0, 6)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (7, N'ANGUILLA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0, 7)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (8, N'ANTIGUA AND BARBUDA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0, 9)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (9, N'ARGENTINA', N'Argentine Peso', N'ARS', N'32', 2, 0, 10)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (10, N'ARMENIA', N'Armenian Dram', N'AMD', N'51', 2, 0, 11)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (11, N'ARUBA', N'Aruban Florin', N'AWG', N'533', 2, 0, 12)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (12, N'AUSTRALIA', N'Australian Dollar', N'AUD', N'36', 2, 0, 13)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (13, N'AUSTRIA', N'Euro', N'EUR', N'978', 2, 0, 14)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (14, N'AZERBAIJAN', N'Azerbaijanian Manat', N'AZN', N'944', 2, 0, 15)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (15, N'BAHAMAS', N'Bahamian Dollar', N'BSD', N'44', 2, 0, 16)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (16, N'BAHRAIN', N'Bahraini Dinar', N'BHD', N'48', 3, 0, 17)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (17, N'BANGLADESH', N'Taka', N'BDT', N'50', 2, 0, 18)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (18, N'BARBADOS', N'Barbados Dollar', N'BBD', N'52', 2, 0, 19)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (19, N'BELARUS', N'Belarussian Ruble', N'BYR', N'974', 0, 0, 20)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (20, N'BELGIUM', N'Euro', N'EUR', N'978', 2, 0, 21)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (21, N'BELIZE', N'Belize Dollar', N'BZD', N'84', 2, 0, 22)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (22, N'BENIN', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0, 23)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (23, N'BERMUDA', N'Bermudian Dollar', N'BMD', N'60', 2, 0, 24)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (24, N'BHUTAN', N'Ngultrum', N'BTN', N'64', 2, 0, 25)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (25, N'BHUTAN', N'Indian Rupee', N'INR', N'356', 2, 0, 25)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (26, N'BOSNIA AND HERZEGOVINA', N'Convertible Mark', N'BAM', N'977', 2, 0, 27)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (27, N'BOTSWANA', N'Pula', N'BWP', N'72', 2, 0, 28)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (28, N'BOUVET ISLAND', N'Norwegian Krone', N'NOK', N'578', 2, 0, 29)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (29, N'BRAZIL', N'Brazilian Real', N'BRL', N'986', 2, 0, 30)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (30, N'BRITISH INDIAN OCEAN TERRITORY', N'US Dollar', N'USD', N'840', 2, 0, 31)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (31, N'BRUNEI DARUSSALAM', N'Brunei Dollar', N'BND', N'96', 2, 0, 32)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (32, N'BULGARIA', N'Bulgarian Lev', N'BGN', N'975', 2, 0, 33)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (33, N'BURKINA FASO', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0, 34)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (34, N'BURUNDI', N'Burundi Franc', N'BIF', N'108', 0, 0, 35)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (35, N'CAMBODIA', N'Riel', N'KHR', N'116', 2, 0, 36)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (36, N'CAMEROON', N'CFA Franc BEAC', N'XAF', N'950', 0, 0, 37)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (37, N'CANADA', N'Canadian Dollar', N'CAD', N'124', 2, 0, 38)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (38, N'CAPE VERDE', N'Cape Verde Escudo', N'CVE', N'132', 2, 0, 39)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (39, N'CAYMAN ISLANDS', N'Cayman Islands Dollar', N'KYD', N'136', 2, 0, 40)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (40, N'CENTRAL AFRICAN REPUBLIC', N'CFA Franc BEAC', N'XAF', N'950', 0, 0, 41)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (41, N'CHAD', N'CFA Franc BEAC', N'XAF', N'950', 0, 0, 42)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (42, N'CHILE', N'Unidades de fomento', N'CLF', N'990', 0, 1, 43)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (43, N'CHILE', N'Chilean Peso', N'CLP', N'152', 0, 0, 43)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (44, N'CHINA', N'Yuan Renminbi', N'CNY', N'156', 2, 0, 44)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (45, N'CHRISTMAS ISLAND', N'Australian Dollar', N'AUD', N'36', 2, 0, 45)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (46, N'COCOS (KEELING) ISLANDS', N'Australian Dollar', N'AUD', N'36', 2, 0, 46)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (47, N'COLOMBIA', N'Colombian Peso', N'COP', N'170', 2, 0, 47)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (48, N'COLOMBIA', N'Unidad de Valor Real', N'COU', N'970', 2, 1, 47)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (49, N'COMOROS', N'Comoro Franc', N'KMF', N'174', 0, 0, 48)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (50, N'CONGO', N'CFA Franc BEAC', N'XAF', N'950', 0, 0, 49)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (51, N'COOK ISLANDS', N'New Zealand Dollar', N'NZD', N'554', 2, 0, 51)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (52, N'COSTA RICA', N'Costa Rican Colon', N'CRC', N'188', 2, 0, 52)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (53, N'CROATIA', N'Croatian Kuna', N'HRK', N'191', 2, 0, 54)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (54, N'CUBA', N'Peso Convertible', N'CUC', N'931', 2, 0, 55)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (55, N'CUBA', N'Cuban Peso', N'CUP', N'192', 2, 0, 55)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (56, N'CYPRUS', N'Euro', N'EUR', N'978', 2, 0, 56)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (57, N'CZECH REPUBLIC', N'Czech Koruna', N'CZK', N'203', 2, 0, 57)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (58, N'DENMARK', N'Danish Krone', N'DKK', N'208', 2, 0, 58)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (59, N'DJIBOUTI', N'Djibouti Franc', N'DJF', N'262', 0, 0, 59)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (60, N'DOMINICA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0, 60)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (61, N'DOMINICAN REPUBLIC', N'Dominican Peso', N'DOP', N'214', 2, 0, 61)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (62, N'ECUADOR', N'US Dollar', N'USD', N'840', 2, 0, 62)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (63, N'EGYPT', N'Egyptian Pound', N'EGP', N'818', 2, 0, 63)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (64, N'EL SALVADOR', N'El Salvador Colon', N'SVC', N'222', 2, 0, 64)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (65, N'EL SALVADOR', N'US Dollar', N'USD', N'840', 2, 0, 64)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (66, N'EQUATORIAL GUINEA', N'CFA Franc BEAC', N'XAF', N'950', 0, 0, 65)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (67, N'ERITREA', N'Nakfa', N'ERN', N'232', 2, 0, 66)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (68, N'ESTONIA', N'Euro', N'EUR', N'978', 2, 0, 67)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (69, N'ETHIOPIA', N'Ethiopian Birr', N'ETB', N'230', 2, 0, 68)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (70, N'FALKLAND ISLANDS (MALVINAS)', N'Falkland Islands Pound', N'FKP', N'238', 2, 0, 69)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (71, N'FAROE ISLANDS', N'Danish Krone', N'DKK', N'208', 2, 0, 70)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (72, N'FIJI', N'Fiji Dollar', N'FJD', N'242', 2, 0, 71)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (73, N'FINLAND', N'Euro', N'EUR', N'978', 2, 0, 72)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (74, N'FRANCE', N'Euro', N'EUR', N'978', 2, 0, 73)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (75, N'FRENCH GUIANA', N'Euro', N'EUR', N'978', 2, 0, 74)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (76, N'FRENCH POLYNESIA', N'CFP Franc', N'XPF', N'953', 0, 0, 75)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (77, N'FRENCH SOUTHERN TERRITORIES', N'Euro', N'EUR', N'978', 2, 0, 76)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (78, N'GABON', N'CFA Franc BEAC', N'XAF', N'950', 0, 0, 77)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (79, N'GAMBIA', N'Dalasi', N'GMD', N'270', 2, 0, 78)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (80, N'GEORGIA', N'Lari', N'GEL', N'981', 2, 0, 79)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (81, N'GERMANY', N'Euro', N'EUR', N'978', 2, 0, 80)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (82, N'GHANA', N'Ghana Cedi', N'GHS', N'936', 2, 0, 81)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (83, N'GIBRALTAR', N'Gibraltar Pound', N'GIP', N'292', 2, 0, 82)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (84, N'GREECE', N'Euro', N'EUR', N'978', 2, 0, 83)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (85, N'GREENLAND', N'Danish Krone', N'DKK', N'208', 2, 0, 84)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (86, N'GRENADA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0, 85)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (87, N'GUADELOUPE', N'Euro', N'EUR', N'978', 2, 0, 86)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (88, N'GUAM', N'US Dollar', N'USD', N'840', 2, 0, 87)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (89, N'GUATEMALA', N'Quetzal', N'GTQ', N'320', 2, 0, 88)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (90, N'GUINEA', N'Guinea Franc', N'GNF', N'324', 0, 0, 89)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (91, N'GUINEA-BISSAU', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0, 90)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (92, N'GUYANA', N'Guyana Dollar', N'GYD', N'328', 2, 0, 91)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (93, N'HAITI', N'Gourde', N'HTG', N'332', 2, 0, 92)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (94, N'HAITI', N'US Dollar', N'USD', N'840', 2, 0, 92)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (95, N'HEARD ISLAND AND McDONALD ISLANDS', N'Australian Dollar', N'AUD', N'36', 2, 0, 93)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (96, N'HOLY SEE (VATICAN CITY STATE)', N'Euro', N'EUR', N'978', 2, 0, 94)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (97, N'HONDURAS', N'Lempira', N'HNL', N'340', 2, 0, 95)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (98, N'HONG KONG', N'Hong Kong Dollar', N'HKD', N'344', 2, 0, 96)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (99, N'HUNGARY', N'Forint', N'HUF', N'348', 2, 0, 97)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (100, N'ICELAND', N'Iceland Krona', N'ISK', N'352', 0, 0, 98)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (101, N'INDIA', N'Indian Rupee', N'INR', N'356', 2, 0, 99)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (102, N'INDONESIA', N'Rupiah', N'IDR', N'360', 2, 0, 100)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (103, N'IRAN, ISLAMIC REPUBLIC OF', N'Iranian Rial', N'IRR', N'364', 2, 0, 101)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (104, N'IRAQ', N'Iraqi Dinar', N'IQD', N'368', 3, 0, 102)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (105, N'IRELAND', N'Euro', N'EUR', N'978', 2, 0, 103)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (106, N'ISRAEL', N'New Israeli Sheqel', N'ILS', N'376', 2, 0, 104)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (107, N'ITALY', N'Euro', N'EUR', N'978', 2, 0, 105)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (108, N'JAMAICA', N'Jamaican Dollar', N'JMD', N'388', 2, 0, 106)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (109, N'JAPAN', N'Yen', N'JPY', N'392', 0, 0, 107)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (110, N'JORDAN', N'Jordanian Dinar', N'JOD', N'400', 3, 0, 108)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (111, N'KAZAKHSTAN', N'Tenge', N'KZT', N'398', 2, 0, 109)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (112, N'KENYA', N'Kenyan Shilling', N'KES', N'404', 2, 0, 110)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (113, N'KIRIBATI', N'Australian Dollar', N'AUD', N'36', 2, 0, 111)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (114, N'KOREA, REPUBLIC OF', N'Won', N'KRW', N'410', 0, 0, 113)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (115, N'KUWAIT', N'Kuwaiti Dinar', N'KWD', N'414', 3, 0, 114)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (116, N'KYRGYZSTAN', N'Som', N'KGS', N'417', 2, 0, 115)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (117, N'LATVIA', N'Latvian Lats', N'LVL', N'428', 2, 0, 117)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (118, N'LEBANON', N'Lebanese Pound', N'LBP', N'422', 2, 0, 118)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (119, N'LESOTHO', N'Loti', N'LSL', N'426', 2, 0, 119)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (120, N'LESOTHO', N'Rand', N'ZAR', N'710', 2, 0, 119)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (121, N'LIBERIA', N'Liberian Dollar', N'LRD', N'430', 2, 0, 120)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (122, N'LIECHTENSTEIN', N'Swiss Franc', N'CHF', N'756', 2, 0, 122)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (123, N'LITHUANIA', N'Lithuanian Litas', N'LTL', N'440', 2, 0, 123)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (124, N'LUXEMBOURG', N'Euro', N'EUR', N'978', 2, 0, 124)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (125, N'MACAO', N'Pataca', N'MOP', N'446', 2, 0, 125)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (126, N'MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF', N'Denar', N'MKD', N'807', 2, 0, 126)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (127, N'MADAGASCAR', N'Malagasy Ariary', N'MGA', N'969', 2, 0, 127)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (128, N'MALAWI', N'Kwacha', N'MWK', N'454', 2, 0, 128)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (129, N'MALAYSIA', N'Malaysian Ringgit', N'MYR', N'458', 2, 0, 129)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (130, N'MALDIVES', N'Rufiyaa', N'MVR', N'462', 2, 0, 130)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (131, N'MALI', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0, 131)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (132, N'MALTA', N'Euro', N'EUR', N'978', 2, 0, 132)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (133, N'MARSHALL ISLANDS', N'US Dollar', N'USD', N'840', 2, 0, 133)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (134, N'MARTINIQUE', N'Euro', N'EUR', N'978', 2, 0, 134)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (135, N'MAURITANIA', N'Ouguiya', N'MRO', N'478', 2, 0, 135)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (136, N'MAURITIUS', N'Mauritius Rupee', N'MUR', N'480', 2, 0, 136)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (137, N'MAYOTTE', N'Euro', N'EUR', N'978', 2, 0, 137)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (138, N'MEXICO', N'Mexican Peso', N'MXN', N'484', 2, 0, 138)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (139, N'MEXICO', N'Mexican Unidad de Inversion (UDI)', N'MXV', N'979', 2, 1, 138)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (140, N'MICRONESIA, FEDERATED STATES OF', N'US Dollar', N'USD', N'840', 2, 0, 139)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (141, N'MOLDOVA, REPUBLIC OF', N'Moldovan Leu', N'MDL', N'498', 2, 0, 140)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (142, N'MONACO', N'Euro', N'EUR', N'978', 2, 0, 141)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (143, N'MONGOLIA', N'Tugrik', N'MNT', N'496', 2, 0, 142)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (144, N'MONTSERRAT', N'East Caribbean Dollar', N'XCD', N'951', 2, 0, 143)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (145, N'MOROCCO', N'Moroccan Dirham', N'MAD', N'504', 2, 0, 144)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (146, N'MOZAMBIQUE', N'Mozambique Metical', N'MZN', N'943', 2, 0, 145)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (147, N'MYANMAR', N'Kyat', N'MMK', N'104', 2, 0, 146)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (148, N'NAMIBIA', N'Namibia Dollar', N'NAD', N'516', 2, 0, 147)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (149, N'NAMIBIA', N'Rand', N'ZAR', N'710', 2, 0, 147)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (150, N'NAURU', N'Australian Dollar', N'AUD', N'36', 2, 0, 148)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (151, N'NEPAL', N'Nepalese Rupee', N'NPR', N'524', 2, 0, 149)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (152, N'NETHERLANDS', N'Euro', N'EUR', N'978', 2, 0, 150)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (153, N'NEW CALEDONIA', N'CFP Franc', N'XPF', N'953', 0, 0, 152)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (154, N'NEW ZEALAND', N'New Zealand Dollar', N'NZD', N'554', 2, 0, 153)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (155, N'NICARAGUA', N'Cordoba Oro', N'NIO', N'558', 2, 0, 154)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (156, N'NIGER', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0, 155)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (157, N'NIGERIA', N'Naira', N'NGN', N'566', 2, 0, 156)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (158, N'NIUE', N'New Zealand Dollar', N'NZD', N'554', 2, 0, 157)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (159, N'NORFOLK ISLAND', N'Australian Dollar', N'AUD', N'36', 2, 0, 158)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (160, N'NORTHERN MARIANA ISLANDS', N'US Dollar', N'USD', N'840', 2, 0, 159)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (161, N'NORWAY', N'Norwegian Krone', N'NOK', N'578', 2, 0, 160)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (162, N'OMAN', N'Rial Omani', N'OMR', N'512', 3, 0, 161)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (163, N'PAKISTAN', N'Pakistan Rupee', N'PKR', N'586', 2, 0, 162)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (164, N'PALAU', N'US Dollar', N'USD', N'840', 2, 0, 163)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (165, N'PANAMA', N'Balboa', N'PAB', N'590', 2, 0, 165)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (166, N'PANAMA', N'US Dollar', N'USD', N'840', 2, 0, 165)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (167, N'PAPUA NEW GUINEA', N'Kina', N'PGK', N'598', 2, 0, 166)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (168, N'PARAGUAY', N'Guarani', N'PYG', N'600', 0, 0, 167)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (169, N'PERU', N'Nuevo Sol', N'PEN', N'604', 2, 0, 168)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (170, N'PHILIPPINES', N'Philippine Peso', N'PHP', N'608', 2, 0, 169)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (171, N'PITCAIRN', N'New Zealand Dollar', N'NZD', N'554', 2, 0, 170)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (172, N'POLAND', N'Zloty', N'PLN', N'985', 2, 0, 171)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (173, N'PORTUGAL', N'Euro', N'EUR', N'978', 2, 0, 172)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (174, N'PUERTO RICO', N'US Dollar', N'USD', N'840', 2, 0, 173)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (175, N'QATAR', N'Qatari Rial', N'QAR', N'634', 2, 0, 174)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (176, N'ROMANIA', N'New Romanian Leu', N'RON', N'946', 2, 0, 176)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (177, N'RUSSIAN FEDERATION', N'Russian Ruble', N'RUB', N'643', 2, 0, 177)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (178, N'RWANDA', N'Rwanda Franc', N'RWF', N'646', 0, 0, 178)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (179, N'SAINT KITTS AND NEVIS', N'East Caribbean Dollar', N'XCD', N'951', 2, 0, 180)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (180, N'SAINT LUCIA', N'East Caribbean Dollar', N'XCD', N'951', 2, 0, 181)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (181, N'SAINT PIERRE AND MIQUELON', N'Euro', N'EUR', N'978', 2, 0, 182)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (182, N'SAINT VINCENT AND THE GRENADINES', N'East Caribbean Dollar', N'XCD', N'951', 2, 0, 183)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (183, N'SAMOA', N'Tala', N'WST', N'882', 2, 0, 184)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (184, N'SAN MARINO', N'Euro', N'EUR', N'978', 2, 0, 185)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (185, N'SAO TOME AND PRINCIPE', N'Dobra', N'STD', N'678', 2, 0, 186)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (186, N'SAUDI ARABIA', N'Saudi Riyal', N'SAR', N'682', 2, 0, 187)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (187, N'SENEGAL', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0, 188)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (188, N'SEYCHELLES', N'Seychelles Rupee', N'SCR', N'690', 2, 0, 190)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (189, N'SIERRA LEONE', N'Leone', N'SLL', N'694', 2, 0, 191)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (190, N'SINGAPORE', N'Singapore Dollar', N'SGD', N'702', 2, 0, 192)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (191, N'SLOVAKIA', N'Euro', N'EUR', N'978', 2, 0, 193)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (192, N'SLOVENIA', N'Euro', N'EUR', N'978', 2, 0, 194)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (193, N'SOLOMON ISLANDS', N'Solomon Islands Dollar', N'SBD', N'90', 2, 0, 195)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (194, N'SOMALIA', N'Somali Shilling', N'SOS', N'706', 2, 0, 196)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (195, N'SOUTH AFRICA', N'Rand', N'ZAR', N'710', 2, 0, 197)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (196, N'SPAIN', N'Euro', N'EUR', N'978', 2, 0, 199)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (197, N'SRI LANKA', N'Sri Lanka Rupee', N'LKR', N'144', 2, 0, 200)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (198, N'SUDAN', N'Sudanese Pound', N'SDG', N'938', 2, 0, 201)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (199, N'SURINAME', N'Surinam Dollar', N'SRD', N'968', 2, 0, 202)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (200, N'SVALBARD AND JAN MAYEN', N'Norwegian Krone', N'NOK', N'578', 2, 0, 203)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (201, N'SWAZILAND', N'Lilangeni', N'SZL', N'748', 2, 0, 204)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (202, N'SWEDEN', N'Swedish Krona', N'SEK', N'752', 2, 0, 205)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (203, N'SWITZERLAND', N'WIR Euro', N'CHE', N'947', 2, 1, 206)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (204, N'SWITZERLAND', N'Swiss Franc', N'CHF', N'756', 2, 0, 206)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (205, N'SWITZERLAND', N'WIR Franc', N'CHW', N'948', 2, 1, 206)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (206, N'SYRIAN ARAB REPUBLIC', N'Syrian Pound', N'SYP', N'760', 2, 0, 207)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (207, N'TAIWAN, PROVINCE OF CHINA', N'New Taiwan Dollar', N'TWD', N'901', 2, 0, 208)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (208, N'TAJIKISTAN', N'Somoni', N'TJS', N'972', 2, 0, 209)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (209, N'TANZANIA, UNITED REPUBLIC OF', N'Tanzanian Shilling', N'TZS', N'834', 2, 0, 210)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (210, N'THAILAND', N'Baht', N'THB', N'764', 2, 0, 211)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (211, N'TIMOR-LESTE', N'US Dollar', N'USD', N'840', 2, 0, 212)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (212, N'TOGO', N'CFA Franc BCEAO', N'XOF', N'952', 0, 0, 213)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (213, N'TOKELAU', N'New Zealand Dollar', N'NZD', N'554', 2, 0, 214)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (214, N'TONGA', N'Pa’anga', N'TOP', N'776', 2, 0, 215)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (215, N'TRINIDAD AND TOBAGO', N'Trinidad and Tobago Dollar', N'TTD', N'780', 2, 0, 216)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (216, N'TUNISIA', N'Tunisian Dinar', N'TND', N'788', 3, 0, 217)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (217, N'TURKEY', N'Turkish Lira', N'TRY', N'949', 2, 0, 218)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (218, N'TURKMENISTAN', N'Turkmenistan New Manat', N'TMT', N'934', 2, 0, 219)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (219, N'TURKS AND CAICOS ISLANDS', N'US Dollar', N'USD', N'840', 2, 0, 220)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (220, N'TUVALU', N'Australian Dollar', N'AUD', N'36', 2, 0, 221)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (221, N'UGANDA', N'Uganda Shilling', N'UGX', N'800', 0, 0, 222)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (222, N'UKRAINE', N'Hryvnia', N'UAH', N'980', 2, 0, 223)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (223, N'UNITED ARAB EMIRATES', N'UAE Dirham', N'AED', N'784', 2, 0, 224)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (224, N'UNITED KINGDOM', N'Pound Sterling', N'GBP', N'826', 2, 0, 225)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (225, N'UNITED STATES', N'US Dollar', N'USD', N'840', 2, 0, 226)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (226, N'UNITED STATES', N'US Dollar (Next day)', N'USN', N'997', 2, 1, 226)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (227, N'UNITED STATES', N'US Dollar (Same day)', N'USS', N'998', 2, 1, 226)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (228, N'UNITED STATES MINOR OUTLYING ISLANDS', N'US Dollar', N'USD', N'840', 2, 0, 227)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (229, N'URUGUAY', N'Uruguay Peso en Unidades Indexadas (URUIURUI)', N'UYI', N'940', 0, 1, 228)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (230, N'URUGUAY', N'Peso Uruguayo', N'UYU', N'858', 2, 0, 228)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (231, N'UZBEKISTAN', N'Uzbekistan Sum', N'UZS', N'860', 2, 0, 229)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (232, N'VANUATU', N'Vatu', N'VUV', N'548', 0, 0, 230)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (233, N'VIET NAM', N'Dong', N'VND', N'704', 0, 0, 232)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (234, N'WALLIS AND FUTUNA', N'CFP Franc', N'XPF', N'953', 0, 0, 235)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (235, N'WESTERN SAHARA', N'Moroccan Dirham', N'MAD', N'504', 2, 0, 236)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (236, N'YEMEN', N'Yemeni Rial', N'YER', N'886', 2, 0, 237)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (237, N'ZAMBIA', N'Zambian Kwacha', N'ZMW', N'967', 2, 0, 238)
GO
INSERT [dbo].[Currency] ([CurrencyId], [Entity], [Name], [AlphabeticCode], [NumericCode], [MinorUnit], [IsFundYesNo], [CountryId]) VALUES (238, N'ZIMBABWE', N'Zimbabwe Dollar', N'ZWL', N'932', 2, 0, 239)
GO

SET IDENTITY_INSERT [dbo].[Currency] OFF
GO

INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eee41670-5204-4b05-b7bf-14b7e4f56264', 224, CAST(N'1990-01-31' AS Date), CAST(0.605680 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b0e18259-10e7-4891-98eb-a44c75814252', 224, CAST(N'1990-02-28' AS Date), CAST(0.589593 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a53579ee-dd10-41ef-818c-856572880e04', 224, CAST(N'1990-03-31' AS Date), CAST(0.615675 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'87183b0c-3ee9-4953-a492-75407560cd3c', 224, CAST(N'1990-04-30' AS Date), CAST(0.610804 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0e111f94-6314-4c06-80c3-baa6ef257a10', 224, CAST(N'1990-05-31' AS Date), CAST(0.596237 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'50fddb94-6b41-4dc8-845e-cfc95d70954f', 224, CAST(N'1990-06-30' AS Date), CAST(0.584783 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b294d25-fc44-4a43-8b0d-e26768d8f309', 224, CAST(N'1990-07-31' AS Date), CAST(0.552623 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3155ee8c-f923-4c3a-af2c-4ca871324907', 224, CAST(N'1990-08-31' AS Date), CAST(0.526108 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b6761ec-8b0a-4e15-a3e1-a1b8fc672257', 224, CAST(N'1990-09-30' AS Date), CAST(0.532139 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f075505-20c6-46e2-a263-77045c9a4de5', 224, CAST(N'1990-10-31' AS Date), CAST(0.514073 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'10ab966e-f6ef-4214-98eb-2acee216870f', 224, CAST(N'1990-11-30' AS Date), CAST(0.509116 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'03225589-75e7-4520-990c-f628e9e27c83', 224, CAST(N'1990-12-31' AS Date), CAST(0.520399 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'460b057f-9563-4d68-9fe2-2dfd22189bed', 224, CAST(N'1991-01-31' AS Date), CAST(0.516973 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f4abef95-6397-4bb3-8ba9-d6ca458ec1a1', 224, CAST(N'1991-02-28' AS Date), CAST(0.509250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b801f85a-2b30-4b5b-b78b-74c6a59162c5', 224, CAST(N'1991-03-31' AS Date), CAST(0.549568 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'24ee7198-6b12-474c-8df1-0a35a6c1c9ba', 224, CAST(N'1991-04-30' AS Date), CAST(0.571832 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd95a1dc7-eb51-43d2-a3b6-a418b6add2a9', 224, CAST(N'1991-05-31' AS Date), CAST(0.580167 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bbdb12ba-7442-4f8d-bf51-5b121fa46d0b', 224, CAST(N'1991-06-30' AS Date), CAST(0.606321 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16eae086-ef81-47f5-9180-3018b5d0a4ec', 224, CAST(N'1991-07-31' AS Date), CAST(0.605793 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e43d29c9-cbe3-4feb-8b84-30c66a1a99c0', 224, CAST(N'1991-08-31' AS Date), CAST(0.593892 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'638984b7-91be-40f1-abce-f4a1b56c14b3', 224, CAST(N'1991-09-30' AS Date), CAST(0.579281 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'80844c39-9ea8-4a61-a29f-5b2b05cee70c', 224, CAST(N'1991-10-31' AS Date), CAST(0.580384 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ff6d194-b3a1-44fd-90f5-6048c4e37345', 224, CAST(N'1991-11-30' AS Date), CAST(0.561963 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'016be555-4e5f-47c6-856c-370ab65f94da', 224, CAST(N'1991-12-31' AS Date), CAST(0.547492 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cd2dee28-05ba-4582-ab65-577b7aa7817a', 224, CAST(N'1992-01-31' AS Date), CAST(0.553020 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb934e75-ab84-4d95-bbc8-fa5891a11abf', 224, CAST(N'1992-02-29' AS Date), CAST(0.562636 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad7bebca-022f-4b31-84df-7945abf19977', 224, CAST(N'1992-03-31' AS Date), CAST(0.580129 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'224960eb-9e2f-4d96-b16c-437be66e0987', 224, CAST(N'1992-04-30' AS Date), CAST(0.569313 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4d22c5bc-7c3a-4e69-9f33-4e551ac10866', 224, CAST(N'1992-05-31' AS Date), CAST(0.552697 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f374e498-544b-4a81-9aee-92592aaacafe', 224, CAST(N'1992-06-30' AS Date), CAST(0.539167 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'089512d8-6683-4447-8d60-71b3fe131002', 224, CAST(N'1992-07-31' AS Date), CAST(0.521487 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f364a3e9-2609-43af-8204-f48ded63fa4e', 224, CAST(N'1992-08-31' AS Date), CAST(0.514671 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9549d716-8b1d-46ee-ad4a-10b0e46befa5', 224, CAST(N'1992-09-30' AS Date), CAST(0.543733 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8fe62f43-33f8-4a5e-a3ed-9eb44115cc94', 224, CAST(N'1992-10-31' AS Date), CAST(0.605717 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'322c8f26-5076-423c-9889-307e656c53ff', 224, CAST(N'1992-11-30' AS Date), CAST(0.655016 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6bc68d5e-df5c-4d9a-8cb6-7c3d48e7664a', 224, CAST(N'1992-12-31' AS Date), CAST(0.644916 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd34ea8f5-2701-40fb-8f61-db7704be9c83', 224, CAST(N'1993-01-31' AS Date), CAST(0.652596 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e71bd95d-327d-4285-a8bf-2368b1fba725', 224, CAST(N'1993-02-28' AS Date), CAST(0.694737 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b32edc96-f40d-46bb-9f95-92a5b4cb54dd', 224, CAST(N'1993-03-31' AS Date), CAST(0.684316 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be79c958-d6ce-4d18-a13a-33e8dc633156', 224, CAST(N'1993-04-30' AS Date), CAST(0.647496 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb93a90a-ffbf-41e3-874f-254dd2f5e690', 224, CAST(N'1993-05-31' AS Date), CAST(0.646175 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b10b8ede-0ce8-413c-8a03-086516922abd', 224, CAST(N'1993-06-30' AS Date), CAST(0.663179 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c1b56d2-6a12-4a61-b14f-d205b6b302fe', 224, CAST(N'1993-07-31' AS Date), CAST(0.668699 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'217afff3-4922-4401-b5bf-14b11f8e9aba', 224, CAST(N'1993-08-31' AS Date), CAST(0.670581 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'56bfcc30-2158-4f34-a562-c674cb87e529', 224, CAST(N'1993-09-30' AS Date), CAST(0.655930 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a209e9a2-7592-4286-b50c-21353f122817', 224, CAST(N'1993-10-31' AS Date), CAST(0.665767 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94dff970-3a19-4c7b-8b0f-a63bd40eca2f', 224, CAST(N'1993-11-30' AS Date), CAST(0.675316 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd23f87c2-d4b9-4810-a61d-b5e1e351af67', 224, CAST(N'1993-12-31' AS Date), CAST(0.670586 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df9f8504-88e0-41d8-882b-d4cd344fd6f0', 224, CAST(N'1994-01-31' AS Date), CAST(0.670097 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b474bcec-54db-4121-9e58-2d732052bed5', 224, CAST(N'1994-02-28' AS Date), CAST(0.676093 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b62137c0-cf54-4927-bee5-d968cfa28d3d', 224, CAST(N'1994-03-31' AS Date), CAST(0.670298 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6ce8d64-cc33-49d5-a7d6-d3e9de55cbb5', 224, CAST(N'1994-04-30' AS Date), CAST(0.674699 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aff7af44-318f-402b-8f71-6a6a97e3fbc4', 224, CAST(N'1994-05-31' AS Date), CAST(0.664821 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b884fc74-e513-4429-b50f-6137cbeb1c6b', 224, CAST(N'1994-06-30' AS Date), CAST(0.655284 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a79783c-57f3-45fa-9c8e-6db53ac1787e', 224, CAST(N'1994-07-31' AS Date), CAST(0.646577 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'32376227-05f8-443a-b870-02dda20c8b9d', 224, CAST(N'1994-08-31' AS Date), CAST(0.648429 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d29085e-6428-4249-acf0-00b99eb756bc', 224, CAST(N'1994-09-30' AS Date), CAST(0.638582 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'15f631e0-db2b-426c-8fa2-e390dd1590b4', 224, CAST(N'1994-10-31' AS Date), CAST(0.622637 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'39cbb65d-9187-4cf5-88e9-193e461c3ada', 224, CAST(N'1994-11-30' AS Date), CAST(0.629381 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb432b9a-dd25-4940-86b7-1394922c9bf8', 224, CAST(N'1994-12-31' AS Date), CAST(0.641589 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ec432d4-ffbe-4168-9253-2f1be4bccb24', 224, CAST(N'1995-01-31' AS Date), CAST(0.635133 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'07e734a3-eb61-45ed-bd78-a2d720cfcfb1', 224, CAST(N'1995-02-28' AS Date), CAST(0.636168 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a947a8e0-4543-456a-a3c9-59819669c288', 224, CAST(N'1995-03-31' AS Date), CAST(0.625001 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dbe9ab9e-3fb0-4384-99f0-53dde4f24d89', 224, CAST(N'1995-04-30' AS Date), CAST(0.622184 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41c81dd3-8eaa-450a-b112-7840ae2f137b', 224, CAST(N'1995-05-31' AS Date), CAST(0.630070 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a23f309-11f7-48ba-99ec-d544bb9751d7', 224, CAST(N'1995-06-30' AS Date), CAST(0.627048 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cb420c29-83bd-4566-abfc-5aa4cbecdf8f', 224, CAST(N'1995-07-31' AS Date), CAST(0.626899 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b077a4e4-db7f-438a-8870-e6b53b04c62a', 224, CAST(N'1995-08-31' AS Date), CAST(0.638430 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c2d93ba-9444-40f4-b168-e63330941224', 224, CAST(N'1995-09-30' AS Date), CAST(0.641488 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec4033cc-b94a-4ba2-9335-0cc4efe64837', 224, CAST(N'1995-10-31' AS Date), CAST(0.633748 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'99cd9974-0eaa-4640-aeac-7643d4403e69', 224, CAST(N'1995-11-30' AS Date), CAST(0.640068 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8525523-c8e3-4e10-be54-9fece46744fa', 224, CAST(N'1995-12-31' AS Date), CAST(0.649153 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7e44e01b-6c98-4f9f-bc60-32e603a3bc71', 224, CAST(N'1996-01-31' AS Date), CAST(0.654224 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1a3f8b3-69f1-428a-b6f3-9fb5d55ca062', 224, CAST(N'1996-02-29' AS Date), CAST(0.651077 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43995c2f-9643-427b-a65e-0e44211bf1b5', 224, CAST(N'1996-03-31' AS Date), CAST(0.654859 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'675f05af-14df-4a4d-9968-528d5bcbe400', 224, CAST(N'1996-04-30' AS Date), CAST(0.659631 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b854587b-0869-4c79-8b69-496f358ce9dc', 224, CAST(N'1996-05-31' AS Date), CAST(0.659996 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'479b609c-e89d-4cd5-903e-acc6cad402c9', 224, CAST(N'1996-06-30' AS Date), CAST(0.648690 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b3f8981d-2f90-4295-9eac-ad58b6c8fe0d', 224, CAST(N'1996-07-31' AS Date), CAST(0.643917 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1a77274-178e-4a7b-a0f7-355edf5fa20e', 224, CAST(N'1996-08-31' AS Date), CAST(0.645219 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4639ca6b-8cc8-4ba4-8285-ed18bd0dc46d', 224, CAST(N'1996-09-30' AS Date), CAST(0.641323 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd11f9969-bd71-442d-a027-1b4e89a6c4f0', 224, CAST(N'1996-10-31' AS Date), CAST(0.630502 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84576fe2-6656-4eb2-b49a-727cd79218de', 224, CAST(N'1996-11-30' AS Date), CAST(0.601628 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e4fa011-78af-4ed8-b13e-eb0576a6ab89', 224, CAST(N'1996-12-31' AS Date), CAST(0.601070 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7eb14f29-9269-4d9c-8150-b44207cceaaf', 224, CAST(N'1997-01-31' AS Date), CAST(0.603146 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f7298f39-f777-4d8e-8560-fedb2a1a3040', 224, CAST(N'1997-02-28' AS Date), CAST(0.615173 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6c8d0cc9-737b-4c0c-9065-d3d1ed8b1f86', 224, CAST(N'1997-03-31' AS Date), CAST(0.621341 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'405707e6-77e7-4740-b3e8-470bc76d0c50', 224, CAST(N'1997-04-30' AS Date), CAST(0.613768 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82f4b049-3f51-495d-8714-04277bd35e2f', 224, CAST(N'1997-05-31' AS Date), CAST(0.612698 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ca453d8-9160-4f23-b842-abc3cbfea7a7', 224, CAST(N'1997-06-30' AS Date), CAST(0.607993 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf1c2630-38d9-4f84-954d-bee6f4321e18', 224, CAST(N'1997-07-31' AS Date), CAST(0.599120 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9036c887-beaf-4e25-bf8d-74e7c0923183', 224, CAST(N'1997-08-31' AS Date), CAST(0.623686 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43e4b151-dfc4-4b80-9476-c8a6ed1236b2', 224, CAST(N'1997-09-30' AS Date), CAST(0.624537 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af6ba0cf-27ef-44c1-8a1b-4839c7c624f5', 224, CAST(N'1997-10-31' AS Date), CAST(0.612468 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b03dad2-2a9f-4330-9a66-7aeed1e5adc6', 224, CAST(N'1997-11-30' AS Date), CAST(0.592112 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cefa92e8-2206-4c65-9966-08622eaaae92', 224, CAST(N'1997-12-31' AS Date), CAST(0.602562 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e8524d6-ef88-4d56-ad1c-dbe5f7b1babb', 224, CAST(N'1998-01-31' AS Date), CAST(0.611673 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5c893cc-8cc0-41ed-931d-da66a7f29ae7', 224, CAST(N'1998-02-28' AS Date), CAST(0.609471 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd45bbc3a-af56-4e65-9ac2-a03e52b2db67', 224, CAST(N'1998-03-31' AS Date), CAST(0.601765 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db61f66b-6c40-435e-90d9-3b30b44c7c5e', 224, CAST(N'1998-04-30' AS Date), CAST(0.597998 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7860f97a-94e0-4963-9d99-268f957b6827', 224, CAST(N'1998-05-31' AS Date), CAST(0.610454 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2e8c0e2-5f8a-4d87-b9f2-5f91ab853989', 224, CAST(N'1998-06-30' AS Date), CAST(0.605990 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ef09c1f-a4af-46e3-9dcc-3a549d81169f', 224, CAST(N'1998-07-31' AS Date), CAST(0.608404 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5388edd3-d265-4bf5-a5c4-f5ef7e242c3a', 224, CAST(N'1998-08-31' AS Date), CAST(0.611968 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ded69efb-55f7-4ee1-8249-cf26f2b6cfed', 224, CAST(N'1998-09-30' AS Date), CAST(0.594476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77f74c06-145b-41c3-be67-e3a72b2cdd0a', 224, CAST(N'1998-10-31' AS Date), CAST(0.590208 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1136cb7b-a04c-4986-b29a-7232d94967d6', 224, CAST(N'1998-11-30' AS Date), CAST(0.602029 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1dcd7b4-9eaa-4c7d-8301-ebc4a265dbd1', 224, CAST(N'1998-12-31' AS Date), CAST(0.598542 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4ae932c6-d43a-4650-9280-078dd988ccc7', 224, CAST(N'1999-01-31' AS Date), CAST(0.605964 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1efd4b5-4bb5-4b72-94af-8d1c121f58bb', 224, CAST(N'1999-02-28' AS Date), CAST(0.614463 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9065ed50-35ee-4283-8613-940e779e6b29', 224, CAST(N'1999-03-31' AS Date), CAST(0.616545 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3cbd09be-bbf6-4855-8a08-a31a4786ca74', 224, CAST(N'1999-04-30' AS Date), CAST(0.621293 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dc302253-9692-4825-841f-2cd434470bb0', 224, CAST(N'1999-05-31' AS Date), CAST(0.619021 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f492c8f-3691-4691-8f35-c0d28a1456e2', 224, CAST(N'1999-06-30' AS Date), CAST(0.626905 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1467fe9f-25dd-4906-808f-fe2924fb562a', 224, CAST(N'1999-07-31' AS Date), CAST(0.634915 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad8b1bb8-51b7-4c28-bcd0-daa64199b2b8', 224, CAST(N'1999-08-31' AS Date), CAST(0.622774 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b8166e4-d80f-491c-8d07-03ec7bf65dd1', 224, CAST(N'1999-09-30' AS Date), CAST(0.615514 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb85c3be-21c5-4d86-bf4d-931f46ae21f1', 224, CAST(N'1999-10-31' AS Date), CAST(0.603456 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4101230d-8721-4a38-ae66-c6a6bc3ec467', 224, CAST(N'1999-11-30' AS Date), CAST(0.617072 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f98d10f-0753-40d5-b028-cd247f5dd6b9', 224, CAST(N'1999-12-31' AS Date), CAST(0.620054 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c629ad94-6945-45b1-94ec-2bf142f870c8', 224, CAST(N'2000-01-31' AS Date), CAST(0.609439 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ae8a6e3-bf53-4495-9081-712c3cc10b2b', 224, CAST(N'2000-02-29' AS Date), CAST(0.624793 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'567310dd-22a4-4bce-8dee-7a843986713e', 224, CAST(N'2000-03-31' AS Date), CAST(0.633233 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b65717e7-ccd7-4bd6-bdf2-ed0d534979c5', 224, CAST(N'2000-04-30' AS Date), CAST(0.631776 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c4d3deef-763f-4e3b-b816-36abc484896d', 224, CAST(N'2000-05-31' AS Date), CAST(0.662588 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cbe64043-4ffa-46e4-8a6d-7f1e8227bdbf', 224, CAST(N'2000-06-30' AS Date), CAST(0.662906 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a08c3deb-1d46-4397-9400-96bb1bb8abc4', 224, CAST(N'2000-07-31' AS Date), CAST(0.663239 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01e4995f-a6da-4fc4-9575-388b3554c976', 224, CAST(N'2000-08-31' AS Date), CAST(0.671372 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7318047-e57d-45d4-8130-e65c0f20418d', 224, CAST(N'2000-09-30' AS Date), CAST(0.697801 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1195ca35-c1da-4b99-80f6-6ea1581a5bbd', 224, CAST(N'2000-10-31' AS Date), CAST(0.689205 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b02039fd-1eee-40d0-be6f-90cfd702597f', 224, CAST(N'2000-11-30' AS Date), CAST(0.701601 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd580cd70-5ada-4d11-831d-c0cb690a9db3', 224, CAST(N'2000-12-31' AS Date), CAST(0.683400 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc29e711-173e-4cdf-9a96-79cfb3f41954', 224, CAST(N'2001-01-31' AS Date), CAST(0.676515 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'04e99786-2cdc-443c-9049-3a2b3acfce3c', 224, CAST(N'2001-02-28' AS Date), CAST(0.688235 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e3c59d05-18af-4627-a8d5-2cab10fa7f78', 224, CAST(N'2001-03-31' AS Date), CAST(0.692390 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db47f985-c4ed-4391-b38b-8a30aac2f9cc', 224, CAST(N'2001-04-30' AS Date), CAST(0.696933 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c75a2e65-83db-43ef-afaf-7bd541361d0c', 224, CAST(N'2001-05-31' AS Date), CAST(0.700635 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e10ba8fa-bfb0-42d6-8ba8-5e63843078f0', 224, CAST(N'2001-06-30' AS Date), CAST(0.713168 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd480f5cf-8a43-4b07-a1a3-6eef2f4a3142', 224, CAST(N'2001-07-31' AS Date), CAST(0.707493 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12d51545-1317-4143-bdd2-fd012b318291', 224, CAST(N'2001-08-31' AS Date), CAST(0.696312 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ecdf5404-06d0-4854-9871-eeccc6dab1f9', 224, CAST(N'2001-09-30' AS Date), CAST(0.683743 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75f09569-5ea0-4b29-ba8f-fd58246f18c4', 224, CAST(N'2001-10-31' AS Date), CAST(0.688913 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'406abe75-a42d-4317-8d29-f45715e267c9', 224, CAST(N'2001-11-30' AS Date), CAST(0.697065 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f5e8dcc-66cc-4239-940a-0e69fcaaf571', 224, CAST(N'2001-12-31' AS Date), CAST(0.694128 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13275985-5626-4c7a-a751-4697929d6b3a', 224, CAST(N'2002-01-31' AS Date), CAST(0.697148 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b143823f-d89c-4dc0-b506-2f3f4252085a', 224, CAST(N'2002-02-28' AS Date), CAST(0.702770 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e567069e-c321-46b8-8356-e28c64bf5e18', 224, CAST(N'2002-03-31' AS Date), CAST(0.702718 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0fdb2483-aec0-40bb-a423-61905c9585c3', 224, CAST(N'2002-04-30' AS Date), CAST(0.693852 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85868483-7f32-43db-8bf9-88abc41e50da', 224, CAST(N'2002-05-31' AS Date), CAST(0.684926 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1df91be2-37eb-4c30-a541-cf8009549102', 224, CAST(N'2002-06-30' AS Date), CAST(0.674558 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ca2b025-5154-48ac-86d7-642d3074f414', 224, CAST(N'2002-07-31' AS Date), CAST(0.642630 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c825b77-28a5-4e83-94ec-52a73372772f', 224, CAST(N'2002-08-31' AS Date), CAST(0.650267 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4f1ae70-4e5b-45ab-ba25-26d24cd7ecae', 224, CAST(N'2002-09-30' AS Date), CAST(0.643367 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6693b65-c206-4830-b052-bb9bce42139c', 224, CAST(N'2002-10-31' AS Date), CAST(0.641779 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2354216-0630-441e-b932-1260871ac0cf', 224, CAST(N'2002-11-30' AS Date), CAST(0.635881 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b319c702-2d9f-4e35-9433-e388b9ccd459', 224, CAST(N'2002-12-31' AS Date), CAST(0.631780 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81988d3e-9aa9-4d21-88a3-d81c8c161a57', 224, CAST(N'2003-01-31' AS Date), CAST(0.619171 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f4a9942-a70f-4ce7-829b-9efeb42f6903', 224, CAST(N'2003-02-28' AS Date), CAST(0.620323 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ccce88e6-0270-4267-8f35-0e48e0d74f93', 224, CAST(N'2003-03-31' AS Date), CAST(0.631325 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'de64d4fc-2dec-4b1a-b1dd-d121cc6e77bf', 224, CAST(N'2003-04-30' AS Date), CAST(0.635653 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'481a2cc1-8119-445f-b4dd-8716fd4dabdd', 224, CAST(N'2003-05-31' AS Date), CAST(0.617114 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0583bbb4-f6c1-49a3-8191-4ece70510ea9', 224, CAST(N'2003-06-30' AS Date), CAST(0.602201 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e5e36a5a-3d71-4957-b59f-89abdeeda4cf', 224, CAST(N'2003-07-31' AS Date), CAST(0.614649 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27d28372-2ec8-4bcc-849d-22ba2a3f31da', 224, CAST(N'2003-08-31' AS Date), CAST(0.626562 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'74c8ef3b-c337-4c09-a4e9-2af4e11935f5', 224, CAST(N'2003-09-30' AS Date), CAST(0.622489 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'15b34c9a-dcf5-4448-88da-2785ba5a1d00', 224, CAST(N'2003-10-31' AS Date), CAST(0.596401 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5d4641d-fd4d-4d38-99b4-3e4f86191dc8', 224, CAST(N'2003-11-30' AS Date), CAST(0.591634 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cc86a70e-f30b-4e05-ba4d-1cd88dd7ae01', 224, CAST(N'2003-12-31' AS Date), CAST(0.571733 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6d2646dc-f807-430c-ba6e-7fbfca6cfea9', 224, CAST(N'2004-01-31' AS Date), CAST(0.549731 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca9fd0bd-c91c-4fd2-a02b-bdc47be0bba7', 224, CAST(N'2004-02-29' AS Date), CAST(0.536427 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db140eba-08f6-41f1-9677-b11fa90e5a00', 224, CAST(N'2004-03-31' AS Date), CAST(0.547481 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0440616a-e4d5-4bf9-b960-a19c4502421c', 224, CAST(N'2004-04-30' AS Date), CAST(0.552211 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9a65aa3b-3421-46c6-90f9-98ad552ece7d', 224, CAST(N'2004-05-31' AS Date), CAST(0.559640 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd80f1980-d03a-4ae6-938a-062dc14bdcc3', 224, CAST(N'2004-06-30' AS Date), CAST(0.545761 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1bd5951d-793d-46c2-a61e-05124c4df324', 224, CAST(N'2004-07-31' AS Date), CAST(0.543010 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43a70f15-da27-44ea-81db-55b41d91c875', 224, CAST(N'2004-08-31' AS Date), CAST(0.549381 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'11eb0b34-b4b6-4c57-afed-700b14d48e22', 224, CAST(N'2004-09-30' AS Date), CAST(0.556008 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2fdcb38-6ee5-4646-9014-686aecd62515', 224, CAST(N'2004-10-31' AS Date), CAST(0.553038 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f4227074-4e31-4a9d-a598-324f6a3e0029', 224, CAST(N'2004-11-30' AS Date), CAST(0.538577 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c13515ca-cd24-4a6d-be92-37f5bffa4085', 224, CAST(N'2004-12-31' AS Date), CAST(0.518751 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5353a7f-54d2-48b0-aaae-278111e691fd', 224, CAST(N'2005-01-31' AS Date), CAST(0.531512 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7a7e6ea0-6f80-4246-81d8-c784184da6bb', 224, CAST(N'2005-02-28' AS Date), CAST(0.530585 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'249b7eca-59e3-4f2b-be26-d370938cbafd', 224, CAST(N'2005-03-31' AS Date), CAST(0.524724 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21e448d3-e140-421d-b983-60cbc834b359', 224, CAST(N'2005-04-30' AS Date), CAST(0.527687 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41429714-28da-4f39-ae40-3a7a6d4c8aa1', 224, CAST(N'2005-05-31' AS Date), CAST(0.538561 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'762069c5-5026-4c3c-a27e-b3091e2da57f', 224, CAST(N'2005-06-30' AS Date), CAST(0.549592 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5351831b-2c93-43ad-98c4-275f39fc9e03', 224, CAST(N'2005-07-31' AS Date), CAST(0.570562 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2bb81257-220d-469c-b832-0e2d0bfea324', 224, CAST(N'2005-08-31' AS Date), CAST(0.557432 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8671c43-55a4-40e9-b275-f2f07d93b2ad', 224, CAST(N'2005-09-30' AS Date), CAST(0.552504 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41b769b3-8e28-4ac5-8121-fde8d0e12a31', 224, CAST(N'2005-10-31' AS Date), CAST(0.566571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e81ed538-a7ce-4a1a-9370-ab1a7b9af657', 224, CAST(N'2005-11-30' AS Date), CAST(0.576176 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'20fb32f4-27cb-450d-9bee-1556ca50e694', 224, CAST(N'2005-12-31' AS Date), CAST(0.572665 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4d40bcb9-6f18-4df9-a2cd-4045549039cb', 224, CAST(N'2006-01-31' AS Date), CAST(0.566897 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5031832-275e-4452-ab0e-32cd9d67f6ce', 224, CAST(N'2006-02-28' AS Date), CAST(0.571752 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'859514bf-55ee-42d5-a978-e91da5c63224', 224, CAST(N'2006-03-31' AS Date), CAST(0.573131 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aac21be1-e31d-4c67-8752-37f506cfec8d', 224, CAST(N'2006-04-30' AS Date), CAST(0.566475 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2a4ed7e3-9fdf-4a76-866e-2a1c2ff19b5a', 224, CAST(N'2006-05-31' AS Date), CAST(0.535278 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'187331ab-b70d-410a-b38a-831314e14f54', 224, CAST(N'2006-06-30' AS Date), CAST(0.542885 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0406d245-1049-4e2f-b5ff-c98f5a555bf3', 224, CAST(N'2006-07-31' AS Date), CAST(0.542249 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e64213eb-0d64-4b12-8483-1554b2381ce4', 224, CAST(N'2006-08-31' AS Date), CAST(0.528634 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b33e976b-180b-485c-8fa9-98bc5cda4c34', 224, CAST(N'2006-09-30' AS Date), CAST(0.529953 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9d731dcf-0eb6-4745-afa2-a0ba5c7523da', 224, CAST(N'2006-10-31' AS Date), CAST(0.533238 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'87d360bb-aa0e-4c91-b23e-1891a9edc013', 224, CAST(N'2006-11-30' AS Date), CAST(0.523426 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38d3a91b-8542-4ab8-b7b0-1d79d0b302ad', 224, CAST(N'2006-12-31' AS Date), CAST(0.509468 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77ca92ee-1866-4c06-a5f9-4597ee1e21a1', 224, CAST(N'2007-01-31' AS Date), CAST(0.510810 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'314240cf-ee5f-4786-912e-90caed86c5c9', 224, CAST(N'2007-02-28' AS Date), CAST(0.510565 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'35a8d66c-528b-423b-acae-1b788bef0ee7', 224, CAST(N'2007-03-31' AS Date), CAST(0.513594 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a18be6bf-a30b-4a4f-90dc-1501656f9232', 224, CAST(N'2007-04-30' AS Date), CAST(0.503436 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a08b7510-3fda-4f99-876d-8139a14836bf', 224, CAST(N'2007-05-31' AS Date), CAST(0.504295 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c9fb6bf-d3bb-40f6-93eb-a6da459f33b2', 224, CAST(N'2007-06-30' AS Date), CAST(0.503795 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c6366b8b-a5bd-4072-bd1d-6059c087cbfc', 224, CAST(N'2007-07-31' AS Date), CAST(0.491720 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e8e45ee-c8d7-45b4-bb85-846cbc98e38b', 224, CAST(N'2007-08-31' AS Date), CAST(0.497168 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3ebbb1f6-b2c9-4b5c-81ca-ebb321136056', 224, CAST(N'2007-09-30' AS Date), CAST(0.495279 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb023963-a979-4d4b-9d1f-301110033995', 224, CAST(N'2007-10-31' AS Date), CAST(0.489513 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df025566-5d4a-47ca-beab-5d97dd211eb5', 224, CAST(N'2007-11-30' AS Date), CAST(0.482616 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'820b9715-fbc7-46cc-bc66-2b02efd2f18a', 224, CAST(N'2007-12-31' AS Date), CAST(0.495461 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b53573fe-480e-4ed5-9ffc-d9c3f983abb0', 224, CAST(N'2008-01-31' AS Date), CAST(0.507647 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3737025d-78af-4682-98a7-fe451754f561', 224, CAST(N'2008-02-29' AS Date), CAST(0.509120 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f04e8b2f-4989-4f71-8c6a-11f67aebaee7', 224, CAST(N'2008-03-31' AS Date), CAST(0.499492 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6c38c243-9dbd-42bf-86a7-401da8542fb2', 224, CAST(N'2008-04-30' AS Date), CAST(0.504529 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d4d4f7a-96e1-4819-9dca-36df24e70fda', 224, CAST(N'2008-05-31' AS Date), CAST(0.508799 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'485357c3-0a67-4252-a3aa-d1c2a5bf68b4', 224, CAST(N'2008-06-30' AS Date), CAST(0.508708 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3fcd7841-c3fa-42a9-a2d3-65b767605073', 224, CAST(N'2008-07-31' AS Date), CAST(0.503135 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c954ad1f-e456-4d67-8960-2366533955f6', 224, CAST(N'2008-08-31' AS Date), CAST(0.527851 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd994df41-c640-4a11-9d34-443b798f3d98', 224, CAST(N'2008-09-30' AS Date), CAST(0.556121 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0cd9df5-c4d8-471a-8d76-7eb0665e47cc', 224, CAST(N'2008-10-31' AS Date), CAST(0.585927 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'003080be-68c3-4077-a43d-2477104b4748', 224, CAST(N'2008-11-30' AS Date), CAST(0.650762 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09498308-9ef4-4187-b47f-2fee517602f0', 224, CAST(N'2008-12-31' AS Date), CAST(0.671847 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2df67e3a-5efc-4123-aa18-e1865df1be84', 224, CAST(N'2009-01-31' AS Date), CAST(0.690732 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'29cd2fdb-fadb-455e-99de-4f8f80025d64', 224, CAST(N'2009-02-28' AS Date), CAST(0.694718 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b13f0331-65b3-4bcb-ab3e-2cdfd839f946', 224, CAST(N'2009-03-31' AS Date), CAST(0.703968 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82fe299c-7d84-4b9b-a616-8c3c0688a486', 224, CAST(N'2009-04-30' AS Date), CAST(0.680474 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dba10f18-e85b-4527-8fae-5dd7b11dd8e9', 224, CAST(N'2009-05-31' AS Date), CAST(0.649988 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9a83ee2-9cd3-4abc-ad28-35b419f90010', 224, CAST(N'2009-06-30' AS Date), CAST(0.610803 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'359b3918-0a0d-424b-8a9c-5ffcf7885535', 224, CAST(N'2009-07-31' AS Date), CAST(0.611251 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02ec01ef-5b25-4d32-8ab5-d49d01f8541c', 224, CAST(N'2009-08-31' AS Date), CAST(0.604588 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db642f77-7d61-4ec0-8902-3c6158f3f50a', 224, CAST(N'2009-09-30' AS Date), CAST(0.612587 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'365cd6c5-5d0d-43f4-a085-18b14c191a85', 224, CAST(N'2009-10-31' AS Date), CAST(0.618682 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0789cab2-0278-4b55-9615-cdf09e0faabc', 224, CAST(N'2009-11-30' AS Date), CAST(0.603039 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e5c626bf-f360-4a33-85bd-f68b1d20504d', 224, CAST(N'2009-12-31' AS Date), CAST(0.616514 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'39632958-0e72-4977-a696-51f0fe4473ab', 224, CAST(N'2010-01-31' AS Date), CAST(0.619309 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91f5acd7-eaff-43da-bd91-e77c53d4cfaf', 224, CAST(N'2010-02-28' AS Date), CAST(0.640824 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16a61009-d0ab-43e0-a26e-c99ebdb9e615', 224, CAST(N'2010-03-31' AS Date), CAST(0.664298 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'06a58086-ec4b-4f3c-85f9-da7606a20a49', 224, CAST(N'2010-04-30' AS Date), CAST(0.652307 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'55d7ebb2-799f-49be-9fc4-01cdebf86f01', 224, CAST(N'2010-05-31' AS Date), CAST(0.680260 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0b80a157-390a-420b-9133-993f3bd07668', 224, CAST(N'2010-06-30' AS Date), CAST(0.678630 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0930bc91-6cee-431f-95bf-49a8cf653d42', 224, CAST(N'2010-07-31' AS Date), CAST(0.654966 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4188d56a-d7f8-4989-a0e4-9e9063af9fb2', 224, CAST(N'2010-08-31' AS Date), CAST(0.638449 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c60dfaf-7efb-4848-b0c9-6ba0da39f6fa', 224, CAST(N'2010-09-30' AS Date), CAST(0.642713 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4f9f1363-d67e-4725-805e-04a924e64d6a', 224, CAST(N'2010-10-31' AS Date), CAST(0.630384 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8dc369e-bb29-4ec9-bf4d-bc1f87cbb851', 224, CAST(N'2010-11-30' AS Date), CAST(0.626113 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d3642a2-c1c6-4153-868c-39ffa92d3786', 224, CAST(N'2010-12-31' AS Date), CAST(0.641309 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'25cd46a4-4aa8-4d41-9513-dff388bc1073', 224, CAST(N'2011-01-31' AS Date), CAST(0.634520 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ba16a4b6-0891-4bae-b1ac-2e5f6d1c624e', 224, CAST(N'2011-02-28' AS Date), CAST(0.620569 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91dff7d0-6da3-4ba7-a594-982e4646a187', 224, CAST(N'2011-03-31' AS Date), CAST(0.618163 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf5c2d6d-d774-4be0-b6af-f525dd1c61cc', 224, CAST(N'2011-04-30' AS Date), CAST(0.611418 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30425abf-085f-4fb4-ad95-064bbdd6e268', 224, CAST(N'2011-05-31' AS Date), CAST(0.611459 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'560f1bba-32ff-4276-a8ca-bdded94520e8', 224, CAST(N'2011-06-30' AS Date), CAST(0.616422 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'951c938b-f23f-4294-8a95-b8d46006dcf4', 224, CAST(N'2011-07-31' AS Date), CAST(0.618996 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a5e0cff-667d-4dae-9140-c4bcb713a77e', 224, CAST(N'2011-08-31' AS Date), CAST(0.611047 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'680c1475-04a7-4586-b1a1-f6943dd8b91c', 224, CAST(N'2011-09-30' AS Date), CAST(0.632924 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4eb12a8c-feb2-4da7-b580-9dcea288c587', 224, CAST(N'2011-10-31' AS Date), CAST(0.634435 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4ce9ec16-5450-4e7b-9891-e12f307c87d0', 224, CAST(N'2011-11-30' AS Date), CAST(0.631920 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e509b62f-a5c2-4ea3-9108-5efca307d183', 224, CAST(N'2011-12-31' AS Date), CAST(0.641260 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2921301-e449-4a71-8ba3-a61a90f82cf1', 224, CAST(N'2012-01-31' AS Date), CAST(0.645058 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76e9b31f-55a0-4483-849e-2218af36700b', 224, CAST(N'2012-02-29' AS Date), CAST(0.632995 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8244bce-f958-497e-a72c-21c036146f5a', 224, CAST(N'2012-03-31' AS Date), CAST(0.631923 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5ca4303-6a40-4684-bafd-0109b00cf0fd', 224, CAST(N'2012-04-30' AS Date), CAST(0.625410 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75aa3127-57e1-475c-9658-70499726f432', 224, CAST(N'2012-05-31' AS Date), CAST(0.627476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'14ad9f3f-956f-4a36-a3ae-6c4c145d0f08', 224, CAST(N'2012-06-30' AS Date), CAST(0.643006 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'56d026fb-40f4-4660-9b14-a6433e7ea848', 224, CAST(N'2012-07-31' AS Date), CAST(0.640897 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0a4050aa-6509-4046-bcd7-4181274eb609', 224, CAST(N'2012-08-31' AS Date), CAST(0.636517 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd7eb7e4b-9fd3-429f-9eba-e3eced70251d', 224, CAST(N'2012-09-30' AS Date), CAST(0.621192 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cb586576-b432-4d06-8a12-edfff991175c', 224, CAST(N'2012-10-31' AS Date), CAST(0.621966 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7bb2ff13-6a5f-476f-984e-5e4276db1be9', 224, CAST(N'2012-11-30' AS Date), CAST(0.626474 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6b45b657-dd9f-4fe8-a6d0-81245ca0435c', 224, CAST(N'2012-12-31' AS Date), CAST(0.620137 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'36f387a8-5264-45c4-9d82-f1b52833b08a', 224, CAST(N'2013-01-31' AS Date), CAST(0.625740 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'263e08c2-e32e-406b-96a7-27c25c56718a', 224, CAST(N'2013-02-28' AS Date), CAST(0.644607 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ac5c2e8f-b8f6-4e79-9af1-429c1369e2fc', 224, CAST(N'2013-03-31' AS Date), CAST(0.662792 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c195593-de75-4312-991e-b6b0a5e86c75', 224, CAST(N'2013-04-30' AS Date), CAST(0.653281 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61a3c620-951f-492c-ade0-a27c13edafd1', 224, CAST(N'2013-05-31' AS Date), CAST(0.653375 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'55420ed2-60a4-4618-a226-995abac85c28', 224, CAST(N'2013-06-30' AS Date), CAST(0.646455 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e1d568de-85ab-495f-9f2f-539ca706507a', 224, CAST(N'2013-07-31' AS Date), CAST(0.659095 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f38a81a5-7255-44e7-b373-6c573dde0f10', 224, CAST(N'2013-08-31' AS Date), CAST(0.645440 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6a767a6-d744-494f-bb4a-84e102c92e20', 224, CAST(N'2013-09-30' AS Date), CAST(0.631188 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad4a9b6c-13b8-4e53-ba69-f6c84e2c5892', 224, CAST(N'2013-10-31' AS Date), CAST(0.621500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7a99f003-485f-4da0-8d19-9395819c82de', 224, CAST(N'2013-11-30' AS Date), CAST(0.621356 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'20735d17-6ecf-4584-8b4b-3f15aaa51ea3', 224, CAST(N'2013-12-31' AS Date), CAST(0.610821 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01a17e65-ca6d-4ad3-97cd-ecdeaa68388e', 224, CAST(N'2014-01-31' AS Date), CAST(0.607183 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41058c73-b559-4862-8a74-7c82a85e135d', 224, CAST(N'2014-02-28' AS Date), CAST(0.604265 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'320f3841-b87d-48cf-b6a4-e380e7f164d2', 224, CAST(N'2014-03-31' AS Date), CAST(0.601218 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ecda72f-35bf-4d03-b2fc-4b6216d83cf3', 224, CAST(N'2014-04-30' AS Date), CAST(0.597633 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f87d4470-9225-4d15-9cc7-47f177bad8cd', 224, CAST(N'2014-05-31' AS Date), CAST(0.593778 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0bad6dcd-e023-4d68-9318-d91adee46058', 224, CAST(N'2014-06-30' AS Date), CAST(0.591672 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'89446178-bab7-4866-a1f3-48cc3c9d5396', 224, CAST(N'2014-07-31' AS Date), CAST(0.585401 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76925b32-1dbe-440c-a3a5-783a6afd0a2f', 224, CAST(N'2014-08-31' AS Date), CAST(0.598406 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ddd99fb-c48a-4b18-ac23-c685226acda2', 224, CAST(N'2014-09-30' AS Date), CAST(0.613262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'56394fb2-eb61-496d-9f04-ceccda2b41e8', 224, CAST(N'2014-10-31' AS Date), CAST(0.622208 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd37bbea7-d0bc-4231-a570-ae6269bba93a', 224, CAST(N'2014-11-30' AS Date), CAST(0.633596 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2e4c9db-c2c8-4718-addf-1d5f512e065f', 224, CAST(N'2014-12-31' AS Date), CAST(0.639627 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'855fa1a9-aa35-410f-85ac-06b7902eefdf', 224, CAST(N'2015-01-31' AS Date), CAST(0.660656 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'172f581c-e0c3-4ddd-b1d6-fe9ec0a068e3', 224, CAST(N'2015-02-28' AS Date), CAST(0.652986 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fbb6f115-a65c-4e46-83f9-ebaba2d5ac5f', 224, CAST(N'2015-03-31' AS Date), CAST(0.667678 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3372047d-947c-4137-b46a-19691389fd7e', 224, CAST(N'2015-04-30' AS Date), CAST(0.669674 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a302df87-453a-40f4-a671-0ac1f588e177', 224, CAST(N'2015-05-31' AS Date), CAST(0.646982 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5fe67fe8-5c7c-442b-bfbc-81ba52c71943', 224, CAST(N'2015-06-30' AS Date), CAST(0.642277 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'67de11d4-047f-47b8-8e16-6b4cc918e20b', 224, CAST(N'2015-07-31' AS Date), CAST(0.642803 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'624b9bd1-3e8d-474f-862c-b6ac7bf18816', 224, CAST(N'2015-08-31' AS Date), CAST(0.641609 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec09b707-e907-45e5-9ab1-9045e4e6140f', 224, CAST(N'2015-09-30' AS Date), CAST(0.651945 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ac0e5ee2-ad59-4e3c-a9c1-c4cfa321c1ab', 224, CAST(N'2015-10-31' AS Date), CAST(0.652499 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4c563a6-aebe-4d1a-a950-1bdc10b928a0', 224, CAST(N'2015-11-30' AS Date), CAST(0.658196 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca74019a-4391-475e-8a69-cd4d3b19134b', 224, CAST(N'2015-12-31' AS Date), CAST(0.666588 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2b3412fc-1a50-4cbb-bb62-98615fe6be63', 224, CAST(N'2016-01-31' AS Date), CAST(0.693712 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0a1b3c36-5953-45f2-ae98-3d7e6fb2934e', 224, CAST(N'2016-02-29' AS Date), CAST(0.698669 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5e31bd73-76e7-4be9-a302-cdec2e990a6c', 224, CAST(N'2016-03-31' AS Date), CAST(0.701924 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9aab7382-3fe6-449e-82ff-2ed49122f3e7', 224, CAST(N'2016-04-30' AS Date), CAST(0.699402 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9828589-c079-42a6-b43f-243c4539aee1', 224, CAST(N'2016-05-31' AS Date), CAST(0.688545 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db2bc36c-5e57-4f0d-8345-18b957553971', 224, CAST(N'2016-06-30' AS Date), CAST(0.702777 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6615d7b2-1269-4060-a971-d4c8c48f4f76', 224, CAST(N'2016-07-31' AS Date), CAST(0.761013 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'559366ac-aa3a-46b4-a573-fef5ad1565b5', 224, CAST(N'2016-08-31' AS Date), CAST(0.764085 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7d8c6636-5475-41fa-8a4b-e524187c12c9', 224, CAST(N'2016-09-30' AS Date), CAST(0.760855 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f9c9005-6bfd-4735-af12-23286a2b125f', 224, CAST(N'2016-10-31' AS Date), CAST(0.808480 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e3bb588e-3ec1-4ad8-bf52-0407a3f48808', 224, CAST(N'2016-11-30' AS Date), CAST(0.803249 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd1cba2e1-6a51-4037-a985-65829e78c87f', 224, CAST(N'2016-12-31' AS Date), CAST(0.801430 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'11853aee-ab93-4f92-90e1-8ac69e47f980', 224, CAST(N'2017-01-31' AS Date), CAST(0.809965 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2dd32a8-9be6-4dcb-9673-2bd29f00f823', 224, CAST(N'2017-02-28' AS Date), CAST(0.801029 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0161c2dc-e82c-4347-9d33-6f65dfed2466', 224, CAST(N'2017-03-31' AS Date), CAST(0.810296 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e0c7622-f9ad-4494-9702-3a39fa05106b', 224, CAST(N'2017-04-30' AS Date), CAST(0.791234 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'efd94d32-f4c2-4486-9414-adff81adf625', 224, CAST(N'2017-05-31' AS Date), CAST(0.773977 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bce7e0cb-801e-4a00-8a5d-4122834cc98d', 224, CAST(N'2017-06-30' AS Date), CAST(0.781288 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fd7bbd8a-eb44-4cc0-a67a-7cf23631eb22', 224, CAST(N'2017-07-31' AS Date), CAST(0.768962 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f4f529ca-13b8-4ed9-853b-ff8b0a4da1f6', 224, CAST(N'2017-08-31' AS Date), CAST(0.771865 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dd7b8e13-db47-4fac-8ad5-905b19dde20c', 224, CAST(N'2017-09-30' AS Date), CAST(0.751130 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'88174add-4470-49a3-b3a5-194a1c06cce7', 224, CAST(N'2017-10-31' AS Date), CAST(0.757822 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'debe43f8-23fa-43b5-ba7e-aefd69e5ad4f', 224, CAST(N'2017-11-30' AS Date), CAST(0.756717 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'99275567-d20c-4bf7-bfc2-c76af9255459', 224, CAST(N'2017-12-31' AS Date), CAST(0.746057 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3a5674c1-ae3b-469c-a070-398fb86f60e5', 224, CAST(N'2018-01-31' AS Date), CAST(0.724077 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48d7a77b-f33e-4621-8603-f398139de599', 224, CAST(N'2018-02-28' AS Date), CAST(0.715903 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c2d8132-3882-4614-b3eb-1a796605cc9d', 224, CAST(N'2018-03-31' AS Date), CAST(0.716135 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'301f94f5-7163-4a5c-a9a3-a32ef7ef796f', 224, CAST(N'2018-04-30' AS Date), CAST(0.711113 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0fa19b17-2430-45bc-8add-5ee836504c55', 224, CAST(N'2018-05-31' AS Date), CAST(0.742756 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0dc6fd53-244e-4083-96eb-8ec1a1682e48', 224, CAST(N'2018-06-30' AS Date), CAST(0.752177 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23b4e04f-a6c6-4074-ac47-3fc528bf5809', 224, CAST(N'2018-07-31' AS Date), CAST(0.759306 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'90294b10-9cbc-496d-a2cd-97b6f44ec9ea', 224, CAST(N'2018-08-31' AS Date), CAST(0.777285 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cb0e964f-2af5-42ba-a60f-1eceb58a8663', 224, CAST(N'2018-09-30' AS Date), CAST(0.766762 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'097fe2f8-dff2-400d-8e82-3350a8cdd8bd', 224, CAST(N'2018-10-31' AS Date), CAST(0.768064 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d81f881-b218-4721-b8ba-f205dc7d3b3e', 224, CAST(N'2018-11-30' AS Date), CAST(0.775185 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8e2225b-4b2a-4d7d-9f4a-d392dd33eb3f', 224, CAST(N'2018-12-31' AS Date), CAST(0.788754 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cffc5047-cd30-4f94-90f1-f28368f3681a', 224, CAST(N'2019-01-31' AS Date), CAST(0.775477 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'29d34a59-8b30-44f5-93a9-ae5e5e0e3261', 224, CAST(N'2019-02-28' AS Date), CAST(0.768832 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5deef16e-2c64-42ad-a22a-40098056eba5', 224, CAST(N'2019-03-31' AS Date), CAST(0.759735 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4e3a1068-9bf4-45f4-9296-736802b1cfe5', 224, CAST(N'2019-04-30' AS Date), CAST(0.767821 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f99d94da-8a83-4ccc-81b2-cac9528588e0', 224, CAST(N'2019-05-31' AS Date), CAST(0.777814 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'66ed7280-e627-4c34-ad42-21c599613173', 224, CAST(N'2019-06-30' AS Date), CAST(0.788865 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'10a6d08f-6d8c-4334-aab6-5e42d328c5a8', 224, CAST(N'2019-07-31' AS Date), CAST(0.801780 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3e9b0486-3f09-4e4f-a58d-11e015df0ea1', 224, CAST(N'2019-08-31' AS Date), CAST(0.822511 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'851583d8-865c-45ca-b1e8-e0bac0d08c58', 224, CAST(N'2019-09-30' AS Date), CAST(0.809424 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'25b42f7e-ee89-4750-b155-6c2d353910e8', 224, CAST(N'2019-10-31' AS Date), CAST(0.789734 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42ee782e-9943-4dd5-b8c6-5ddd59dd5616', 224, CAST(N'2019-11-30' AS Date), CAST(0.776478 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2692d617-68f0-4cdb-9a56-a542a58e88b4', 224, CAST(N'2019-12-31' AS Date), CAST(0.763323 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6f0fccf-9ebf-4d6f-b4c6-75a482708335', 224, CAST(N'2020-01-31' AS Date), CAST(0.764843 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb310af5-80c3-495a-abfb-67c82d231275', 224, CAST(N'2020-02-29' AS Date), CAST(0.771086 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2cd4d7fe-9be8-491e-b2ac-305aa9be2563', 225, CAST(N'1990-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a0dffda0-2790-4f2f-a693-9691403c50a8', 225, CAST(N'1990-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b6713cb-ec3d-478e-8d36-d063f952e6ac', 225, CAST(N'1990-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02f9e899-024b-485d-a6c9-929e001415cb', 225, CAST(N'1990-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12c9b797-5b90-440f-88e3-721fbad48849', 225, CAST(N'1990-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f22f0901-8557-4c74-999a-31ea0eb9e865', 225, CAST(N'1990-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'56f0b589-31bb-4943-a01a-c78501938cb5', 225, CAST(N'1990-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a47128d-14c7-455f-bb11-143ff5d6fef5', 225, CAST(N'1990-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bd6a5f54-db7a-4f64-910d-437cec1a79fe', 225, CAST(N'1990-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'682efff9-473b-4c32-a9ae-0298b06a58e1', 225, CAST(N'1990-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'229e2a1a-228a-4aa3-b5a8-ed63ef5f75ac', 225, CAST(N'1990-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'685e589d-ab60-4b26-b6b2-36210b8dc56e', 225, CAST(N'1990-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16d70efd-3610-40fd-8b19-2d80f1ae7d2d', 225, CAST(N'1991-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'67f4241a-3a83-4905-9820-260667811588', 225, CAST(N'1991-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af0cc1f5-f2a9-44b4-8d1b-26f6e49a2a8e', 225, CAST(N'1991-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'522d0351-50ad-439a-b312-b5397eeaf2f3', 225, CAST(N'1991-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94c24c78-0b3a-465e-a093-3339e2221f2b', 225, CAST(N'1991-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'78d198bc-92d5-4b54-bb52-f9a451a8b92f', 225, CAST(N'1991-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'72e1b30d-614c-4b78-bee9-ad183770c517', 225, CAST(N'1991-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e2d36685-4d89-4603-ad78-6c9af31f97d2', 225, CAST(N'1991-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c9e7886-9f45-40f0-bc95-d4bc24192b49', 225, CAST(N'1991-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a783b5c-4aed-4820-8759-e25588b150c4', 225, CAST(N'1991-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'98a0d053-b8d3-46b3-8d1b-4855f42d2861', 225, CAST(N'1991-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3461d09a-726d-44d3-9774-efe9b122e818', 225, CAST(N'1991-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f10b6014-593a-4cb1-bc6f-0c3bae112783', 225, CAST(N'1992-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1178272e-e543-4205-a86e-cf558aab9c3d', 225, CAST(N'1992-02-29' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb6fc660-acba-47b6-af24-112ede9d9a08', 225, CAST(N'1992-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af6e66c2-efcf-4832-88f6-aa8db3c75788', 225, CAST(N'1992-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8b72949-8b41-4850-ba33-265b6e7d9ae3', 225, CAST(N'1992-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'903a472b-b060-49ad-bbaf-b721db9fa0b9', 225, CAST(N'1992-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'289800f7-9a8e-4c7a-b328-5abcadee269d', 225, CAST(N'1992-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'89cd1b63-260e-44a7-ba96-074479f5c865', 225, CAST(N'1992-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61a73251-4b4f-43f7-8153-379dba425109', 225, CAST(N'1992-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cf3386c1-84ca-495c-a237-d04e1a4b683b', 225, CAST(N'1992-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0ccf4552-ca82-47e4-8a69-490135e35fbc', 225, CAST(N'1992-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f2bfd3f-9517-400d-9e8c-ab344bb4d948', 225, CAST(N'1992-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cdc783a2-84b7-474e-a8c7-4b6d8d2e1550', 225, CAST(N'1993-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d1292f6-5a6d-46af-852e-7871903c7c7c', 225, CAST(N'1993-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ab5aac3-7239-443c-948d-bc24df5126f8', 225, CAST(N'1993-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f22e4d53-0c15-420c-90d4-158d4bccba7a', 225, CAST(N'1993-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db9f696b-85d5-4159-a449-cb7efcf7704a', 225, CAST(N'1993-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2b2b523f-5767-453e-9fb8-2fb954726d02', 225, CAST(N'1993-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b64414b8-1909-48a4-bae5-7d376f3f4653', 225, CAST(N'1993-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb2102ae-2448-451d-be3a-4f5d550c5c6a', 225, CAST(N'1993-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'518ef046-11ea-4526-9780-3fb57a17b102', 225, CAST(N'1993-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02d61b2e-942e-4e78-b381-c0f9fb8bf884', 225, CAST(N'1993-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1da18914-7d4e-4fcd-9c81-d1481259a81d', 225, CAST(N'1993-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ba577304-19ba-45a3-ba9a-86eb7e7fb40b', 225, CAST(N'1993-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41aabac5-7e9f-4dcc-8914-0c66f1364da7', 225, CAST(N'1994-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d8c7c6d-f0ba-4259-9e49-7844db944a34', 225, CAST(N'1994-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be778ea3-2928-43c0-8ca4-796b3b05081e', 225, CAST(N'1994-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cf5c51a6-946c-43dc-a041-a07cebac47fc', 225, CAST(N'1994-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cf74874d-667d-42f8-ab85-16f71f5dfc0f', 225, CAST(N'1994-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fdd798d7-cc51-46e9-9e12-521094602eb2', 225, CAST(N'1994-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d8fdef6-506e-4bdf-b5eb-8c1012b7b662', 225, CAST(N'1994-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94d26af9-6dc2-4be7-a569-ba8ca9d01a51', 225, CAST(N'1994-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b872af9-e469-4176-97e5-fb5a403400c8', 225, CAST(N'1994-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e771e73d-54d9-4c1a-af32-e80dde66ca8e', 225, CAST(N'1994-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e53f6e37-5954-49d0-976f-d4f63c1070f7', 225, CAST(N'1994-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09554a81-b90e-4b39-bd78-bbb48569309e', 225, CAST(N'1994-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd6612ba4-6daf-40a8-b4b9-792111084ff0', 225, CAST(N'1995-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'055ec46d-3904-459b-90bf-9fdb1544a0b6', 225, CAST(N'1995-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f1ce1515-ecfe-4ab0-bfa7-63a2d22f400c', 225, CAST(N'1995-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8f37657-4071-42d0-bec9-b298637c0ba8', 225, CAST(N'1995-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b6851a9-e6e2-43e5-ae49-92bff31f3175', 225, CAST(N'1995-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed599008-63f2-4549-a9fc-c5edde0fcb16', 225, CAST(N'1995-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd41e38b9-e5dc-42b0-83d5-a63eda08a89d', 225, CAST(N'1995-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dd8a7dce-085c-4f5e-a02c-a9bf62339d72', 225, CAST(N'1995-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'264973d2-8b8c-4d6c-b4fc-c4f74847da3e', 225, CAST(N'1995-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e58a63c6-1de7-47ee-b61a-bee171750597', 225, CAST(N'1995-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'311270cf-3e33-4994-893e-5f80c604e475', 225, CAST(N'1995-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f9fafdc-155f-461e-ac5d-cb46b01e0f52', 225, CAST(N'1995-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d503131-e0a7-4434-b2f6-fd2a400157dc', 225, CAST(N'1996-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a447001d-9702-4e53-8526-ea07160f3e4f', 225, CAST(N'1996-02-29' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ae67ac0-bf08-4566-85ba-7ae43b6c0405', 225, CAST(N'1996-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'caee8269-81b5-457e-98ae-71c2539cade2', 225, CAST(N'1996-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b4d4f17-997a-4aef-b6ba-38661f8db381', 225, CAST(N'1996-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad554f3d-5c21-441f-93e9-7a8ba1a47750', 225, CAST(N'1996-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a3917b83-882f-43f5-926a-603115a900df', 225, CAST(N'1996-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4f0635ec-0567-445c-a92f-68312702f4b2', 225, CAST(N'1996-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91fc8088-ee62-4759-a653-86e2b945c267', 225, CAST(N'1996-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'07fb3889-d7da-433b-8334-9e3bd82ef29d', 225, CAST(N'1996-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cdef41d4-c8fc-4d7c-97d3-117f042a6bd2', 225, CAST(N'1996-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'45b2668b-ee16-417a-8b40-cfc17db38503', 225, CAST(N'1996-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a27a60ac-b3d6-44bd-9ce7-97267ef312c9', 225, CAST(N'1997-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'733a9f77-0f96-493d-a4d3-fdb8dad788a4', 225, CAST(N'1997-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bfc4a1d8-0af3-48e9-bf89-8b12634665d5', 225, CAST(N'1997-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f503c628-a6a7-4cb6-a3c1-6e325b66d0f5', 225, CAST(N'1997-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9710a813-2ece-4f9a-996c-de3bd30099fa', 225, CAST(N'1997-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65243991-d89a-4563-b0e3-4f8ef58e9c30', 225, CAST(N'1997-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd861a8d6-45d2-4468-82ec-109682bded69', 225, CAST(N'1997-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c7f9bc10-8579-4531-bb63-0272b2bd4082', 225, CAST(N'1997-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aaeb3be1-87e2-479a-8ec4-a09a11225c30', 225, CAST(N'1997-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4f395d0f-f5d3-4638-91bc-1d5e3f431ce9', 225, CAST(N'1997-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6310079d-28ca-401e-8747-25275c0e44a0', 225, CAST(N'1997-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'20a20b63-1efd-4cb8-85ff-d0427ad6d4f8', 225, CAST(N'1997-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75c4a884-a1af-49af-beb6-955eb1238250', 225, CAST(N'1998-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6384b27e-497a-46ea-99b9-91656dd8421d', 225, CAST(N'1998-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3e4593f8-4181-4d9c-b76d-55c3d5d2a86e', 225, CAST(N'1998-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e43aacc4-b5e1-449c-94cf-3cf258f18c3a', 225, CAST(N'1998-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f0232302-00fc-4833-8d13-c4abe526ec75', 225, CAST(N'1998-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cca1759a-e078-4aa5-92b1-62a610df0540', 225, CAST(N'1998-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1bead820-5ce7-4a99-84a2-6082b81cac00', 225, CAST(N'1998-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3db55ce9-a700-417e-8850-f55427c6c1d8', 225, CAST(N'1998-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'11da3af7-8caf-42f1-8e6f-c0d81ad4886c', 225, CAST(N'1998-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2602d0c-42d3-4900-8f39-62dbaa4592f2', 225, CAST(N'1998-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7779ab17-6144-4344-b2b2-3b8d51f04595', 225, CAST(N'1998-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0331911d-b9fd-4d98-a3f8-0c598aaeb28c', 225, CAST(N'1998-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13a60404-71d7-4d54-afac-e70366289107', 225, CAST(N'1999-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'52fbec9e-e87b-496f-841d-34d86a03ddf8', 225, CAST(N'1999-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c976878-c274-4e83-9fda-444e121ef2be', 225, CAST(N'1999-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6e2abb87-42d6-4683-8103-8d8fbd08f305', 225, CAST(N'1999-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e629de7e-6277-477b-a1a3-83035f483d36', 225, CAST(N'1999-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be21705e-810c-4bc1-8229-75a93218762f', 225, CAST(N'1999-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'25e8f8e2-53f1-4e2c-a302-46f54b0c81cc', 225, CAST(N'1999-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f103284-fa6e-4578-83d7-7a0782982a1d', 225, CAST(N'1999-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dc05d2ad-ad84-4616-ac0f-791b8f7f26d0', 225, CAST(N'1999-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bff14500-7640-4d0a-a352-7c04f4755e07', 225, CAST(N'1999-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2b4ed8f0-ac7c-4ea4-98b6-9cf0e0d61ecf', 225, CAST(N'1999-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6d96c1c4-d39e-4bfd-b1ee-50bb5e28380b', 225, CAST(N'1999-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c75e3046-1339-4f7a-ba78-97eb040a999f', 225, CAST(N'2000-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c0abdbd4-ad21-4672-8089-27494123dbf7', 225, CAST(N'2000-02-29' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fb30bb55-42d5-438a-bdea-a6c9d4bc013d', 225, CAST(N'2000-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6a55c7b-a6d0-45e6-a2f1-7374a37aeed8', 225, CAST(N'2000-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a409e925-19cd-459f-b77d-6fd6226d23f9', 225, CAST(N'2000-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'edc54aac-5f7e-406b-8a8f-cc71b5703bdf', 225, CAST(N'2000-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d8e7adb-ef1b-432c-922f-6ca28f56b9e3', 225, CAST(N'2000-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0ca1ee12-77c8-4df1-ac1f-f19a2a149e96', 225, CAST(N'2000-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'958e881f-a49e-4cd2-9453-2fcdb3c0d374', 225, CAST(N'2000-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e752492-7210-491a-9049-f9fc94fd5bb6', 225, CAST(N'2000-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b30c5ed-42d5-4c18-b86c-795fa69fc967', 225, CAST(N'2000-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f7215b36-61b0-43c6-aaf0-75b1b325a89f', 225, CAST(N'2000-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dfb72e8a-bc9b-4c69-b8e3-e49090abbcac', 225, CAST(N'2001-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b68da81f-942f-4a85-a5ba-d093f075ea1d', 225, CAST(N'2001-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33028fdd-c58c-4225-8be5-d4f5db3ca7e6', 225, CAST(N'2001-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a26e375c-4602-4417-b6c2-9aa5579b77c2', 225, CAST(N'2001-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a97a687-d3dd-46cf-9b50-2818be94e59e', 225, CAST(N'2001-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a264f353-1109-40a9-845d-350dcb22588d', 225, CAST(N'2001-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad37baa7-9ce0-4eb2-b35c-56061fd6095f', 225, CAST(N'2001-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77e08ff9-80ef-4e31-8dbb-f468b454ace3', 225, CAST(N'2001-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'96c24430-5876-4ab9-8109-44087c174e73', 225, CAST(N'2001-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4b9b2c61-e808-4443-801f-d39b401b7068', 225, CAST(N'2001-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fa2467ed-8a32-4cf7-8c37-3576dab324af', 225, CAST(N'2001-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'71211dc4-e54c-4c16-a0f1-175781c4a965', 225, CAST(N'2001-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'de07161a-7ba8-432b-82b5-64e57fabebb7', 225, CAST(N'2002-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00529429-752d-44f1-b74b-5e2012b3ed65', 225, CAST(N'2002-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f12e5436-b4a5-45dd-a922-9b0038484df4', 225, CAST(N'2002-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ffd23f69-5522-4279-824d-abbebd5e9b6b', 225, CAST(N'2002-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f33e4b1c-4e16-466b-8a0b-68a0bb22995a', 225, CAST(N'2002-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4d1ba2b4-c26f-4775-ad38-b82305e76667', 225, CAST(N'2002-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'79d31feb-906c-4f26-8b9c-175b0c33658e', 225, CAST(N'2002-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9ff2a915-3edd-48d0-8b64-a15a22721162', 225, CAST(N'2002-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a94fc947-9c75-40fa-9c3c-90b744f22fd7', 225, CAST(N'2002-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b8f79ba-b581-4152-a774-6aec5ffd1328', 225, CAST(N'2002-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ccdde7d-8082-4c13-8339-5a7cd4a12eba', 225, CAST(N'2002-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3297579a-950b-4b9b-bcdb-361d378c1661', 225, CAST(N'2002-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ea430aa5-069a-4066-8438-73e57d64d69d', 225, CAST(N'2003-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b10e4ffd-e206-4f51-af13-168c5c1f3f9d', 225, CAST(N'2003-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f3d18016-299c-4ccf-a106-8f484895e83d', 225, CAST(N'2003-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17c80b11-a952-4d74-87ea-1c7e07a04170', 225, CAST(N'2003-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0dd83b24-8161-42c0-b6c4-9f8e3d714aa3', 225, CAST(N'2003-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0814b03f-2117-451f-b5f0-196217ab0417', 225, CAST(N'2003-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'57ea5ef3-324b-479d-95e0-9ea7353296d6', 225, CAST(N'2003-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c4ebae17-79b6-4842-ba83-b1c153efc469', 225, CAST(N'2003-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2026f68-e36d-4ed3-a562-9f9678f240e2', 225, CAST(N'2003-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fc5fdd01-8b4d-4ccc-8469-4d277cc61894', 225, CAST(N'2003-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'998f0cae-ba7e-4384-ba78-63766477a5da', 225, CAST(N'2003-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'715b9e8a-04dc-4c96-a6b3-63217336f9c9', 225, CAST(N'2003-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'688a9022-5c09-4902-99e7-349b88daf6b6', 225, CAST(N'2004-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'305b75dd-4327-4416-ae9e-edb767a350e3', 225, CAST(N'2004-02-29' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5542d985-f83e-4b6e-aaef-8b62ca01f3e7', 225, CAST(N'2004-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'147a7a35-6ed3-46fa-b1e0-0a7a31b276d4', 225, CAST(N'2004-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c7adaf2-b855-46e9-af86-c0907e135e76', 225, CAST(N'2004-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e63419d1-d25c-4a3d-8867-924867a9a8bc', 225, CAST(N'2004-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'219676c4-4a64-442f-aace-2f32f25f18b1', 225, CAST(N'2004-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'97a84e80-5ad9-494a-8c5b-9910783edb37', 225, CAST(N'2004-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'347df8be-7ea5-40bf-a316-e715bec565c5', 225, CAST(N'2004-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1076959d-f0aa-4ce1-843b-a21b47b724ee', 225, CAST(N'2004-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7d90ad9-8abf-4b1e-8720-0f3a996c9b84', 225, CAST(N'2004-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e110eb54-775c-4e04-9d09-132ae13110f1', 225, CAST(N'2004-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a11ae7e8-4704-4e50-be6c-a62168fff89b', 225, CAST(N'2005-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'841eebd9-5d3f-4f55-b414-40a54c7a72c3', 225, CAST(N'2005-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f9282b69-8244-4ac8-8b13-05762ef988af', 225, CAST(N'2005-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2549f64e-89d0-46e5-b390-d749077c54f3', 225, CAST(N'2005-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1171d2a0-5ad2-4e4e-b14b-71ce0d43ddfb', 225, CAST(N'2005-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f85131c-21e5-4099-9aa2-70f6288fa0ea', 225, CAST(N'2005-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'53f93c11-dbee-480c-a019-6262ebef46c1', 225, CAST(N'2005-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'04af533c-558d-4fc7-9772-d6743810265e', 225, CAST(N'2005-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'279e28d3-6c9b-4a52-a749-67a7909b1a82', 225, CAST(N'2005-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'25698e80-8502-4cf9-97cb-68263d5da581', 225, CAST(N'2005-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8090de65-63c3-4aba-a799-9276ed4052dc', 225, CAST(N'2005-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b24bb519-829a-40c1-a6a3-3624f372e414', 225, CAST(N'2005-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ab49449b-914d-4183-943c-f4189492b2ca', 225, CAST(N'2006-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'99eda3e5-8be7-47e7-8cb5-5838f9fc7c48', 225, CAST(N'2006-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8300e11-2cde-4780-b636-abedcf7f9fda', 225, CAST(N'2006-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fc5f0b11-32b4-4d92-bf98-501e9d46dede', 225, CAST(N'2006-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9192b98d-4336-48e9-a959-e48c28fcebac', 225, CAST(N'2006-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fe15eeb8-c46e-483d-990b-04cd71a3232f', 225, CAST(N'2006-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'53e5cf57-3e76-4692-b66b-a46e26700ad5', 225, CAST(N'2006-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'69097005-32a2-478f-bc3a-c40eee55ef81', 225, CAST(N'2006-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6035204e-1e48-4700-9e99-4d62f3bbf961', 225, CAST(N'2006-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ea0c885-0dbf-4a2d-b70e-d6f435207391', 225, CAST(N'2006-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'430efc0c-052c-4d9b-868c-c6ddecd75636', 225, CAST(N'2006-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f7634dc-8e10-4fa5-8c77-a9ee3fb7bfd0', 225, CAST(N'2006-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2a98a49-778c-4aa9-8b51-f2325fbbd71a', 225, CAST(N'2007-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f20360e8-960d-4f7d-9d3b-adb82ad50f6e', 225, CAST(N'2007-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'521efbdf-d982-441c-b2d0-ed2f9ba6a10e', 225, CAST(N'2007-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7f5bccab-11c1-4e75-ba24-ef5167e77fd9', 225, CAST(N'2007-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38fc9d6d-92e6-4800-9ecb-bcbe28e1b07d', 225, CAST(N'2007-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e6fc6d59-b0f7-48d3-b12f-2e7b30888838', 225, CAST(N'2007-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4123a65d-b9f2-47ac-8b82-dd9e86375e75', 225, CAST(N'2007-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8222daac-584d-4bac-8c2e-997061ff1951', 225, CAST(N'2007-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5791e75-db2a-467a-951c-05ee60d347bf', 225, CAST(N'2007-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'11d675c8-accf-4be6-a4eb-9a38a94fb113', 225, CAST(N'2007-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b81742da-579c-421a-9ee7-6b3462f5a3e3', 225, CAST(N'2007-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ff767f9-c752-4ff4-89df-9248d1c02179', 225, CAST(N'2007-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff3c86bf-44ed-4dba-a4cb-87415217cb38', 225, CAST(N'2008-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'447df2c0-7f3d-404e-b53f-1b56c8d39684', 225, CAST(N'2008-02-29' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc7e162b-4106-4d56-91ab-dc2c530f6080', 225, CAST(N'2008-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a45dd68b-d519-401e-8ad0-7652cbbc7d01', 225, CAST(N'2008-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f33f792-aead-44d3-93d0-3d69c648dc44', 225, CAST(N'2008-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf5a4eef-ad32-4326-885e-1a006d05ca6a', 225, CAST(N'2008-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b7114fa-20ce-4a91-81cd-d53e9cc48346', 225, CAST(N'2008-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c5786d6-71c8-4c02-ae9e-18872cad0515', 225, CAST(N'2008-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da4e4faf-a621-48a5-b273-a85c123fc3f3', 225, CAST(N'2008-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f4f76074-4e6d-461b-bc5b-e3728169a126', 225, CAST(N'2008-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a9b0b0d-19e7-4952-9e79-2c02d6a1f124', 225, CAST(N'2008-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7465d36e-2870-4154-9a48-31e22a5566c4', 225, CAST(N'2008-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fb6b06ee-aa43-4d50-8517-078f5d8fa81b', 225, CAST(N'2009-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2eeeb4fb-d90f-4847-a3b1-a8b4a4f82877', 225, CAST(N'2009-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00c76e91-d2f5-4423-8a8d-e7f66b7b19e4', 225, CAST(N'2009-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'abd4de88-600a-4d4b-9052-15a866882aca', 225, CAST(N'2009-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2eeefb80-e590-4279-8bbe-95d29279f23a', 225, CAST(N'2009-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'739f5d50-47c9-4384-9e91-973ca0c317d2', 225, CAST(N'2009-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17a614a1-2fd5-4f47-a658-cea30ee1f577', 225, CAST(N'2009-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1981b3e-0e4d-4fac-9384-2782506de681', 225, CAST(N'2009-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cfe37fca-a86b-40f9-8015-92c0519762b4', 225, CAST(N'2009-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae33d609-0b57-47c1-bd63-3226c751dd60', 225, CAST(N'2009-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e89502b1-e4d5-4dab-9bfc-763ee6e61a90', 225, CAST(N'2009-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'31cb5513-c9c2-4c66-b2d8-126e00549b6a', 225, CAST(N'2009-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c01c8255-0cb5-4a2c-bbda-45215ea89a9b', 225, CAST(N'2010-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'620fb70d-9c95-4a3d-b13a-691f7643b419', 225, CAST(N'2010-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7350a7bd-7fbc-4ceb-a36a-6dbe44c245c7', 225, CAST(N'2010-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd64c5064-ce8f-444a-be30-bea2ae0e1fc3', 225, CAST(N'2010-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09455d21-a4e9-4a6b-87c7-84c7b1c06f6d', 225, CAST(N'2010-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'089fa191-da12-4f4f-b716-a3942162c5e9', 225, CAST(N'2010-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b4a2e75-6d11-47a6-a6e1-1345c968d33d', 225, CAST(N'2010-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cbfd29cb-b117-43b4-9609-3ab6ded12b92', 225, CAST(N'2010-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65cc32c3-a31d-4fdd-806f-ad9c8c9f0dd4', 225, CAST(N'2010-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0386784-9349-449f-b68c-523f451d3bc4', 225, CAST(N'2010-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3340f63b-41b1-450f-8e79-91092f2f41e3', 225, CAST(N'2010-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'190ffabf-9b32-40ca-b34c-a893485f3b7d', 225, CAST(N'2010-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a480468-ba23-4336-ba19-4413dcb39234', 225, CAST(N'2011-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94e150f7-0edd-4784-83f7-f34f31e1021c', 225, CAST(N'2011-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5e045b6-3a60-4b4e-aee2-02a4f1aeb768', 225, CAST(N'2011-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8857711a-2b6e-429c-acb4-eed1a828fbbc', 225, CAST(N'2011-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33825aba-e3d2-47ad-ba62-0a37c2167651', 225, CAST(N'2011-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bebfd325-443e-4adc-a958-8055db84e185', 225, CAST(N'2011-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42a05dba-f0fe-43ba-a44f-6a2c1894df83', 225, CAST(N'2011-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'90bd929f-c893-44e1-84b1-1a2e61378a63', 225, CAST(N'2011-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8098a974-fe98-4424-a43f-d53675dbe696', 225, CAST(N'2011-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'531bcd01-654b-43ca-a12c-36e323591f33', 225, CAST(N'2011-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'59b4d832-c899-4527-9014-8243be4f9a59', 225, CAST(N'2011-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3e2720cc-65f0-4ff4-889b-6c033a15e05b', 225, CAST(N'2011-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'162c87c2-cdb3-4730-b33b-162e8c62b744', 225, CAST(N'2012-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'962f54dd-df2f-4256-ac2f-111649435d22', 225, CAST(N'2012-02-29' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6936f56-1487-4aef-89cb-321d49a8eded', 225, CAST(N'2012-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b7415e99-db82-45b6-a9c6-02e162c0218f', 225, CAST(N'2012-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6ffccf3d-be11-41df-80a8-3a969f02f5cf', 225, CAST(N'2012-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'194e0f58-420e-4d4c-83b2-58efa00f1e97', 225, CAST(N'2012-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4f27be56-01f7-4657-9875-a8bad2d5e4a7', 225, CAST(N'2012-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27c95141-bdc4-4ffa-94ee-6648c0c4e5e6', 225, CAST(N'2012-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77bec1eb-1ded-4d8d-9489-795cc89a3482', 225, CAST(N'2012-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e7e3d03e-a8ab-4b20-b856-72db87c6db5b', 225, CAST(N'2012-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3793e4a6-c3db-469f-88f0-a96c3a5bc144', 225, CAST(N'2012-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'31c674b7-45f2-4361-92cc-ce4da7a937dc', 225, CAST(N'2012-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c733ea62-9aab-4dd3-8728-0763ce335777', 225, CAST(N'2013-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad9a67a2-ca95-4e46-8ea6-f8425a598555', 225, CAST(N'2013-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9176080-81a9-4d1c-b007-a8abc8be942f', 225, CAST(N'2013-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ce124d0-36c1-4508-a935-8158295b5381', 225, CAST(N'2013-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c1c1fc7-b24a-4671-96ed-19ef50a33e94', 225, CAST(N'2013-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dcf90ded-98fa-45bd-8391-bb4e855453a5', 225, CAST(N'2013-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f9d08bc5-7656-4bee-881e-77a81c54b89a', 225, CAST(N'2013-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c7872aa8-da46-4f3a-9926-277027baa519', 225, CAST(N'2013-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'393c4037-e0d0-4af6-bd49-fee40e184ebf', 225, CAST(N'2013-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c3ca467-30a2-4168-bb8d-103c9d2a3de0', 225, CAST(N'2013-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5fd49af9-00b7-47e7-b4ac-958c19a370aa', 225, CAST(N'2013-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65df9c0b-6c9b-4b12-b2d2-2e30a7a754d3', 225, CAST(N'2013-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e3bb2c53-a5e4-4dbc-9ffe-0a96cd984eff', 225, CAST(N'2014-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c066caa-e6ad-48ed-9696-d4277271f3a1', 225, CAST(N'2014-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17032c18-6c49-4a15-b2bb-45bea91e0aa2', 225, CAST(N'2014-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b3aa66e0-bfcb-4976-a76d-c88967053ac6', 225, CAST(N'2014-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'317ff308-bb62-4463-b8c2-d4c7371960c2', 225, CAST(N'2014-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0b9a290b-f5be-4e11-b245-6a024af7c704', 225, CAST(N'2014-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'04de6ae0-4696-4c63-8ef8-a20acb843718', 225, CAST(N'2014-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cfac83fa-5cc6-4e38-abbb-c0c81c37b5cf', 225, CAST(N'2014-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'607652f4-971a-4777-b80f-948f13da974b', 225, CAST(N'2014-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3ae76575-5e1c-4b7e-89c9-dd75ef9f8aa6', 225, CAST(N'2014-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61e28778-76f2-4001-a971-7c848a6b3bad', 225, CAST(N'2014-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2803d1b3-b585-4e62-b149-6f7777be1e3e', 225, CAST(N'2014-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1f1c57c7-d731-4d5b-b6f7-532a8b9a0b68', 225, CAST(N'2015-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94ff15d2-5fba-440c-a346-c83a0aa2980f', 225, CAST(N'2015-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6ac06a1-6bfa-4219-a770-d1f6b595c928', 225, CAST(N'2015-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'adf7d311-5891-46f6-8b20-547b1134b244', 225, CAST(N'2015-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7125782-33c4-44c4-b56a-a20af2ab7db9', 225, CAST(N'2015-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eee2508b-9de3-4b26-9736-a60f39daa5b0', 225, CAST(N'2015-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0dce8297-74ec-495e-b28e-08ba59962b40', 225, CAST(N'2015-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d13326f-6ead-45b1-87f5-ceec746828be', 225, CAST(N'2015-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82ad1b6b-6c2e-4233-ac74-949a28676420', 225, CAST(N'2015-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8940ffa1-a9bb-4edc-8f60-3a45ee03a6e3', 225, CAST(N'2015-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'108e8f05-5972-4d0c-9c23-18660eceb295', 225, CAST(N'2015-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'525c7bbb-0cec-4ce2-b4cd-8da197987a47', 225, CAST(N'2015-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6dd2f46c-2695-4230-b103-548ff394c737', 225, CAST(N'2016-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'816466d6-099d-48af-ad02-770d1a8991a5', 225, CAST(N'2016-02-29' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'393b3a4b-6526-496c-9639-9f8206be2eaa', 225, CAST(N'2016-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'624c2257-3306-4c87-af95-9e8b47add63d', 225, CAST(N'2016-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d60a35e-c756-45f2-a089-5e119e2d9dd4', 225, CAST(N'2016-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41ac7d24-4275-4b34-8afa-64d5c0531d3e', 225, CAST(N'2016-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38495507-279b-451f-86cd-01473a5ce183', 225, CAST(N'2016-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f013651e-54ae-4815-b1a5-43628efe1e7e', 225, CAST(N'2016-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7d5725e5-2ba1-4f9f-a42c-11fea304dec2', 225, CAST(N'2016-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'72c9d5c4-903e-4ad3-9263-c76e6bc76800', 225, CAST(N'2016-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'39a938d7-9167-4722-b26c-5a1cd445c5e3', 225, CAST(N'2016-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0dd01f00-7912-46be-b974-0983ee32b4d9', 225, CAST(N'2016-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9a112f00-1187-4d4f-8103-4ab31bd4a56c', 225, CAST(N'2017-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b64db180-f691-459d-a1d5-5ee7b18645fb', 225, CAST(N'2017-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c1161dd-b605-46de-8abb-55a15f59eca1', 225, CAST(N'2017-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca453e91-2c4d-48aa-b488-99cdd7374bdf', 225, CAST(N'2017-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c8d0943f-5972-4d6d-88b3-de1b0ea56507', 225, CAST(N'2017-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'070378db-ff22-4621-94ca-64326f41598a', 225, CAST(N'2017-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0647a024-26a7-4c5f-b46d-8735a3351735', 225, CAST(N'2017-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef26f8a7-0f69-479b-933e-0c7404ba10db', 225, CAST(N'2017-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ad1da81-d303-4091-9285-5fa40f865213', 225, CAST(N'2017-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'490a6af1-652a-4600-aff1-3f82eb32cfc8', 225, CAST(N'2017-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3b77526-5503-480a-a0bb-8d2ce1618eda', 225, CAST(N'2017-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6fea633-3102-40c3-92b8-d07d7db1fdc0', 225, CAST(N'2017-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca5ec526-af1a-48ee-bdea-c29afcbb97ae', 225, CAST(N'2018-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'569e0dc9-187d-449c-ae7e-3fecba4ad7fb', 225, CAST(N'2018-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a17923b0-2897-47d2-91a5-08878179c71c', 225, CAST(N'2018-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8209b718-4bcd-4241-9b3b-d02b6863e4a6', 225, CAST(N'2018-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fb1fa633-b2f4-4a60-bb9a-bef7d70b5973', 225, CAST(N'2018-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a723d79d-c924-4060-9439-7e5d06590168', 225, CAST(N'2018-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7be745c6-d182-4864-b787-8c453cf91e33', 225, CAST(N'2018-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd3f659c5-378c-4992-9263-805f3badc4d3', 225, CAST(N'2018-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae1112a3-a69d-456a-8a29-49c5c2e1a259', 225, CAST(N'2018-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61082822-dc7f-4adc-8bdc-bc5e245e4f04', 225, CAST(N'2018-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'74c5254c-6d7b-4bd3-b689-7c9fd6c4c3d5', 225, CAST(N'2018-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd78ba9a9-061f-4dff-a8a0-c54255b71a5f', 225, CAST(N'2018-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9d817a69-0b98-457d-a09f-09a266be3dc6', 225, CAST(N'2019-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ac9c3694-9375-4ecd-922b-ae4f4d785d43', 225, CAST(N'2019-02-28' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'abb7c95a-e7ec-4a90-a6ea-fdc0fc8f515c', 225, CAST(N'2019-03-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e65b2df-1f1f-4c08-90a7-52ea64a8291d', 225, CAST(N'2019-04-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9b84f01-8415-4403-bfc9-5e6e2eddaa17', 225, CAST(N'2019-05-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'99fdbd5b-bec3-4722-9616-595b0d8c8414', 225, CAST(N'2019-06-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'331b48b4-21a7-437d-b2b6-e4038252f574', 225, CAST(N'2019-07-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'529bbdf1-092c-4494-9cfb-4ebb3b590882', 225, CAST(N'2019-08-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9716c1a-88e9-424c-9877-063634c2ccba', 225, CAST(N'2019-09-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6e2f8f9-c005-4022-85c3-345c4fa9167a', 225, CAST(N'2019-10-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12925ec3-a099-4caa-bed0-b719a7da5397', 225, CAST(N'2019-11-30' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'28e0a03e-9ffb-4dae-a6f0-9cd7fadf656c', 225, CAST(N'2019-12-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ededc49e-3a4b-4427-8716-b8396ed9d5cd', 225, CAST(N'2020-01-31' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da7fc617-7de3-49e1-9bf7-b21938ae2ab1', 225, CAST(N'2020-02-29' AS Date), CAST(1.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3d00650c-f150-4b44-aa34-4474fef016bb', 12, CAST(N'1990-01-31' AS Date), CAST(1.280559 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cebd0d8c-13f0-4d5d-adef-b45b5746b89a', 12, CAST(N'1990-02-28' AS Date), CAST(1.317088 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b52154de-8bc9-40af-8800-5b026dfbadd0', 12, CAST(N'1990-03-31' AS Date), CAST(1.323490 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'68f97706-8c67-4a0e-92b6-37257f1b0c47', 12, CAST(N'1990-04-30' AS Date), CAST(1.309558 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a32b2988-c47a-4903-8f29-ae9add2b25d7', 12, CAST(N'1990-05-31' AS Date), CAST(1.314044 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0437bade-6f9d-41e0-a413-3283779f0fc5', 12, CAST(N'1990-06-30' AS Date), CAST(1.283752 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed3e4549-9d49-4b5a-aae0-51a8506f47dc', 12, CAST(N'1990-07-31' AS Date), CAST(1.264716 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'72b2b7d8-7e09-4e65-b73f-7b4b4e2912d8', 12, CAST(N'1990-08-31' AS Date), CAST(1.236961 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a4f16562-2caf-4017-a722-54935fc7e9f2', 12, CAST(N'1990-09-30' AS Date), CAST(1.212015 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c90dc021-baa7-4dc5-86e5-6ab1edc54cf8', 12, CAST(N'1990-10-31' AS Date), CAST(1.250148 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6e5e53d-5e82-4c8c-bd8c-e9d4e1a3bfc6', 12, CAST(N'1990-11-30' AS Date), CAST(1.293925 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42e2635a-f9fa-473c-964b-aa4ba9a0703f', 12, CAST(N'1990-12-31' AS Date), CAST(1.298422 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec81abbb-5149-4345-9e22-ecac11cad6af', 12, CAST(N'1991-01-31' AS Date), CAST(1.283249 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f0adac5-5f7b-4ab7-a775-43b6a2c1d968', 12, CAST(N'1991-02-28' AS Date), CAST(1.276341 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3a6954a9-715e-4fc6-bb6b-8f3dd3c57b24', 12, CAST(N'1991-03-31' AS Date), CAST(1.296943 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'edf68750-ac03-4bdd-910a-d9e60da736b9', 12, CAST(N'1991-04-30' AS Date), CAST(1.282969 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'740624c8-5e8a-453e-88ae-e00d10137784', 12, CAST(N'1991-05-31' AS Date), CAST(1.291759 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f63b9e6f-9211-4a2c-be36-4506ed97a054', 12, CAST(N'1991-06-30' AS Date), CAST(1.316179 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'32f5168c-d777-459c-9451-c7ab1e14d25c', 12, CAST(N'1991-07-31' AS Date), CAST(1.296134 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aa72b5f3-bbd2-4175-bcf4-106414c6ebd1', 12, CAST(N'1991-08-31' AS Date), CAST(1.278223 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01e5731e-7afe-4174-8030-ebf7674915eb', 12, CAST(N'1991-09-30' AS Date), CAST(1.260016 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dccb5746-5e18-4e82-aaf8-21a593b20232', 12, CAST(N'1991-10-31' AS Date), CAST(1.261895 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0e8028f6-38e6-490b-b221-7a3b4ffd21cf', 12, CAST(N'1991-11-30' AS Date), CAST(1.271319 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'daa7f865-0214-4f9a-8fae-349ed46002ce', 12, CAST(N'1991-12-31' AS Date), CAST(1.296792 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c49d2ccc-83c8-4849-ad75-b01c678e38e8', 12, CAST(N'1992-01-31' AS Date), CAST(1.337810 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'463e2ca3-1904-4329-8843-0b350019d772', 12, CAST(N'1992-02-29' AS Date), CAST(1.330188 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'755589dd-977c-4840-aa30-3c2cab349595', 12, CAST(N'1992-03-31' AS Date), CAST(1.318194 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fb9c5d2f-da28-4cd3-9558-77b11789c9d5', 12, CAST(N'1992-04-30' AS Date), CAST(1.311680 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4c1277d0-ff39-4c7e-abad-b06b41ab5c30', 12, CAST(N'1992-05-31' AS Date), CAST(1.322994 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'28d8b806-e7aa-4c5c-81d7-ff394ad4d50a', 12, CAST(N'1992-06-30' AS Date), CAST(1.323520 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ff859d4-0d94-4857-8f0f-11e3f461a21c', 12, CAST(N'1992-07-31' AS Date), CAST(1.342170 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd730a1bb-c6ee-4244-9c00-5b75bed0555f', 12, CAST(N'1992-08-31' AS Date), CAST(1.379969 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ded89c7a-abd0-4b53-9856-2f3a9ed3a990', 12, CAST(N'1992-09-30' AS Date), CAST(1.384095 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5f7bd24-81f1-4fdf-99db-2e90472c8b0f', 12, CAST(N'1992-10-31' AS Date), CAST(1.399199 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4fb51b1c-bee3-461b-8cad-57b22b4434a9', 12, CAST(N'1992-11-30' AS Date), CAST(1.449703 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6796cedd-b7b9-4227-baa0-624173f3eb24', 12, CAST(N'1992-12-31' AS Date), CAST(1.449850 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'69d3e55f-462d-4684-9c07-f07b73de7e3c', 12, CAST(N'1993-01-31' AS Date), CAST(1.485996 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'538aa2c9-6937-4c4e-8264-bce9800fc337', 12, CAST(N'1993-02-28' AS Date), CAST(1.464515 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b282513e-a92c-4e88-89e2-1c5fc56c2eb3', 12, CAST(N'1993-03-31' AS Date), CAST(1.412965 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eff0f6f6-6e50-4a92-9344-9e82273eec36', 12, CAST(N'1993-04-30' AS Date), CAST(1.405536 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'03f8c30a-875c-4f4a-9eed-1ae4b0dbc124', 12, CAST(N'1993-05-31' AS Date), CAST(1.431554 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4571f39d-289e-4c3b-8f49-6ddf6590eb46', 12, CAST(N'1993-06-30' AS Date), CAST(1.481739 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8e4cb0c0-ec43-4966-9784-93cb98abd732', 12, CAST(N'1993-07-31' AS Date), CAST(1.475257 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'450b0921-cc38-4527-909b-b9dd6f69c71f', 12, CAST(N'1993-08-31' AS Date), CAST(1.476480 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ac99a342-8d2e-491c-a1e9-a364370a3d08', 12, CAST(N'1993-09-30' AS Date), CAST(1.534618 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cf54f4b9-4e44-44ba-b600-ed2d60924d10', 12, CAST(N'1993-10-31' AS Date), CAST(1.513053 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9ff03ede-d2ce-4960-a300-4d7ce7afedbd', 12, CAST(N'1993-11-30' AS Date), CAST(1.504688 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af3a7015-d4f4-4444-9d12-72bc403a8653', 12, CAST(N'1993-12-31' AS Date), CAST(1.484576 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'80c7361b-fd0d-4096-950e-bba7b26b1867', 12, CAST(N'1994-01-31' AS Date), CAST(1.436891 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c96b669d-aa5a-420c-85a5-7f2b5497af0a', 12, CAST(N'1994-02-28' AS Date), CAST(1.396489 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5557ebe6-8092-4f1d-b174-f8329a7fa525', 12, CAST(N'1994-03-31' AS Date), CAST(1.406799 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4ec7561a-a1c7-4fb9-9d66-3bb6d714ecce', 12, CAST(N'1994-04-30' AS Date), CAST(1.397449 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e04f2dd0-9630-4de8-844e-5ca7951fbd8c', 12, CAST(N'1994-05-31' AS Date), CAST(1.380785 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fc5e51eb-0ccc-4339-9cde-d89a88bd56dc', 12, CAST(N'1994-06-30' AS Date), CAST(1.364504 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cbbeb322-f23c-4b1f-9ea2-5edae6609069', 12, CAST(N'1994-07-31' AS Date), CAST(1.362303 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'03621cef-e6dc-4130-8ba0-4e744215e3ba', 12, CAST(N'1994-08-31' AS Date), CAST(1.351199 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a3501946-7bc8-4b06-a597-9f61f8c6f179', 12, CAST(N'1994-09-30' AS Date), CAST(1.347724 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'428db4a3-aa88-4e2d-a79e-277687929846', 12, CAST(N'1994-10-31' AS Date), CAST(1.355265 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'889cd98f-06a9-467e-97d0-f7484184277b', 12, CAST(N'1994-11-30' AS Date), CAST(1.324768 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'36c4389a-48eb-4186-ad61-cd66bf63c508', 12, CAST(N'1994-12-31' AS Date), CAST(1.292201 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3ff28536-f8e1-4c66-997e-69adccb95a42', 12, CAST(N'1995-01-31' AS Date), CAST(1.307760 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4cf2b246-1b24-435b-bb25-ff4951fec659', 12, CAST(N'1995-02-28' AS Date), CAST(1.342877 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23d49705-8f69-4f4b-b0fc-1c2b3c447658', 12, CAST(N'1995-03-31' AS Date), CAST(1.361591 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cb3a49fa-9591-4e3d-97e6-f851e1f8da52', 12, CAST(N'1995-04-30' AS Date), CAST(1.359440 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ad72114-79a5-48ef-ab95-7aceddb35641', 12, CAST(N'1995-05-31' AS Date), CAST(1.375391 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd7cec592-ceae-4433-b5c9-73e46be1c707', 12, CAST(N'1995-06-30' AS Date), CAST(1.389737 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'966b2c9f-bea2-41c5-aa02-8ceccc5b43d7', 12, CAST(N'1995-07-31' AS Date), CAST(1.374051 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca63eb52-c56a-4fcc-92d3-e94c59598fae', 12, CAST(N'1995-08-31' AS Date), CAST(1.348934 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7807f80c-8d11-4fe7-9f64-7b928deaa3fa', 12, CAST(N'1995-09-30' AS Date), CAST(1.326826 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'24998beb-b93d-4063-b4ab-874961aff59f', 12, CAST(N'1995-10-31' AS Date), CAST(1.321087 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2caabfb1-a704-423f-8471-a34bcc329efd', 12, CAST(N'1995-11-30' AS Date), CAST(1.341801 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f00e662d-a693-42a8-b4e7-a01c7f0ee598', 12, CAST(N'1995-12-31' AS Date), CAST(1.350412 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e78a517e-bdbe-4b7f-83af-204c1f85ce86', 12, CAST(N'1996-01-31' AS Date), CAST(1.348291 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e689b567-19c5-4938-904f-599fdb2c014f', 12, CAST(N'1996-02-29' AS Date), CAST(1.323534 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a0f10ed6-88af-4bf5-bc3c-f7ce3f518255', 12, CAST(N'1996-03-31' AS Date), CAST(1.296504 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'79b1fb25-7ce8-42f2-a2d7-8c0cce890aaa', 12, CAST(N'1996-04-30' AS Date), CAST(1.272828 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91dc33f6-39a1-4444-9bfb-184d7c5d7dcd', 12, CAST(N'1996-05-31' AS Date), CAST(1.254737 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30e8b87f-7b5d-4cac-b380-77c641b51049', 12, CAST(N'1996-06-30' AS Date), CAST(1.263905 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4a0136c9-b31a-44b5-accb-be54b7df9379', 12, CAST(N'1996-07-31' AS Date), CAST(1.266308 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84f73eef-2044-4ba1-baa9-e34ce1b8eed8', 12, CAST(N'1996-08-31' AS Date), CAST(1.277159 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef710ab5-31c8-4378-93a0-9b163be16172', 12, CAST(N'1996-09-30' AS Date), CAST(1.261400 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'71d3bd75-7292-4dab-9722-93ce64622a60', 12, CAST(N'1996-10-31' AS Date), CAST(1.262972 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4b9e8b6f-a17b-4461-82a4-e14d624da54e', 12, CAST(N'1996-11-30' AS Date), CAST(1.255185 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4001f152-a4ea-4c57-aaa2-50a58e9276e9', 12, CAST(N'1996-12-31' AS Date), CAST(1.255382 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8bd4d4a-d56a-4824-b03c-90ef5346f405', 12, CAST(N'1997-01-31' AS Date), CAST(1.286203 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f37a74c3-a7eb-4ef6-b257-45020b57b939', 12, CAST(N'1997-02-28' AS Date), CAST(1.302731 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7062a3c6-4a19-4b44-a306-ee01ec19ecba', 12, CAST(N'1997-03-31' AS Date), CAST(1.269925 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6af75c7b-518a-43d7-b2d0-c8326bd9c675', 12, CAST(N'1997-04-30' AS Date), CAST(1.284256 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb8fb90b-4f4c-43a2-8c7a-5d93359cee45', 12, CAST(N'1997-05-31' AS Date), CAST(1.290257 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'55d1e08c-54bc-4b00-be7a-05f56c4cf73c', 12, CAST(N'1997-06-30' AS Date), CAST(1.325922 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1f1b2b10-d219-4149-8db2-fae3195a0328', 12, CAST(N'1997-07-31' AS Date), CAST(1.347816 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'595430e9-8271-440d-8a02-c2c16428a112', 12, CAST(N'1997-08-31' AS Date), CAST(1.350740 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75450566-d3b9-4dfc-a5da-c9d28f85ad25', 12, CAST(N'1997-09-30' AS Date), CAST(1.383005 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae2a7c04-515d-4171-8a9e-c857441ee742', 12, CAST(N'1997-10-31' AS Date), CAST(1.390035 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'084e5ae9-eda7-4976-9230-4fd21ea6eac4', 12, CAST(N'1997-11-30' AS Date), CAST(1.438477 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b80892e-8c7d-41eb-891c-c59dfd290f61', 12, CAST(N'1997-12-31' AS Date), CAST(1.511143 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4fcd9277-0bd8-4f24-be3f-bfa476e06c33', 12, CAST(N'1998-01-31' AS Date), CAST(1.523795 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b66cb8d3-1fc8-4ac9-8cfa-968f3c00341c', 12, CAST(N'1998-02-28' AS Date), CAST(1.482994 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5ab38be-6ce2-4df8-9be1-bdd8c4fc7542', 12, CAST(N'1998-03-31' AS Date), CAST(1.493464 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e10ab903-c404-4cc2-910f-39b74ca0d6bb', 12, CAST(N'1998-04-30' AS Date), CAST(1.533092 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'268afa0e-b3f3-4a24-8aae-2b086f543d95', 12, CAST(N'1998-05-31' AS Date), CAST(1.584463 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'95e802bd-7609-4900-9817-e8c1c6892b8a', 12, CAST(N'1998-06-30' AS Date), CAST(1.654598 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eeae5b85-9a23-41fd-8b7f-e2f36aeea6c2', 12, CAST(N'1998-07-31' AS Date), CAST(1.618233 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'72ed6a0d-8b3e-42a6-acf5-3cc2de5f6bb8', 12, CAST(N'1998-08-31' AS Date), CAST(1.699268 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16736110-4e82-4b29-a67e-c2c28fca6e20', 12, CAST(N'1998-09-30' AS Date), CAST(1.698369 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6a08dc13-efb7-47ba-819a-339debf33444', 12, CAST(N'1998-10-31' AS Date), CAST(1.619256 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6381b5b6-1447-47c3-a39e-a95fa30ab921', 12, CAST(N'1998-11-30' AS Date), CAST(1.575124 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dc3bbe1a-16d2-4484-8322-254484b26ad6', 12, CAST(N'1998-12-31' AS Date), CAST(1.617740 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4345a5bf-060f-40e6-bf73-d4fc87a2912d', 12, CAST(N'1999-01-31' AS Date), CAST(1.581324 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'649fded9-b05d-4ebf-b6d9-47bb3a8493c3', 12, CAST(N'1999-02-28' AS Date), CAST(1.561886 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'97deb641-b244-4332-9f52-0ac827f34f95', 12, CAST(N'1999-03-31' AS Date), CAST(1.585384 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eba6af10-c561-41d2-9007-4add1564d820', 12, CAST(N'1999-04-30' AS Date), CAST(1.555350 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8516b019-82f2-44ab-a894-37e4db15301f', 12, CAST(N'1999-05-31' AS Date), CAST(1.509408 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c6325797-3564-4467-8d0a-aeabe35a307b', 12, CAST(N'1999-06-30' AS Date), CAST(1.523569 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e393f671-d3b5-4fa8-9ab0-ba73d10e2a95', 12, CAST(N'1999-07-31' AS Date), CAST(1.524143 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd3330882-b1ce-43c1-a957-b193dc1bdb5d', 12, CAST(N'1999-08-31' AS Date), CAST(1.551545 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a66110dd-d67f-4b66-b8a3-935715269eb7', 12, CAST(N'1999-09-30' AS Date), CAST(1.539432 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c343cabc-4de6-420d-b8f0-3e3e530a6525', 12, CAST(N'1999-10-31' AS Date), CAST(1.535911 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7a8f4c0c-efd4-41f0-9306-bde36833bb29', 12, CAST(N'1999-11-30' AS Date), CAST(1.565389 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c74bf26-2b8e-4f93-82ea-ab3e2598d2b7', 12, CAST(N'1999-12-31' AS Date), CAST(1.560828 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6e0a0f29-9cbf-45ca-b786-755cb2c5a2c6', 12, CAST(N'2000-01-31' AS Date), CAST(1.523615 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a363a0d1-0ee0-4f80-a7ee-1caf6d7a8af0', 12, CAST(N'2000-02-29' AS Date), CAST(1.592746 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8bb2e8f-a53e-4475-b3c3-2922a88da98a', 12, CAST(N'2000-03-31' AS Date), CAST(1.643085 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b5c9046f-d7a7-497f-948b-bcdfbbe95a25', 12, CAST(N'2000-04-30' AS Date), CAST(1.678546 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f86fd23-1760-4e2f-8759-3fb3d5d4e4f5', 12, CAST(N'2000-05-31' AS Date), CAST(1.729656 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e2ef4dbf-e786-4272-a4c1-2f60682c4d68', 12, CAST(N'2000-06-30' AS Date), CAST(1.684587 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fec805a0-9dea-4574-95ae-1347e9530125', 12, CAST(N'2000-07-31' AS Date), CAST(1.699851 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff5ffb9c-a311-49ed-95b8-cd4a18886306', 12, CAST(N'2000-08-31' AS Date), CAST(1.722627 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8116701e-620d-4f7d-bd75-5ed877c36480', 12, CAST(N'2000-09-30' AS Date), CAST(1.808416 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e30725b0-a736-4abf-8ee9-75119b547c58', 12, CAST(N'2000-10-31' AS Date), CAST(1.892806 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bfb48050-1e32-4ee7-8b12-3141213ade99', 12, CAST(N'2000-11-30' AS Date), CAST(1.914234 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f566043a-f23e-4d53-8295-9d5c42f4863f', 12, CAST(N'2000-12-31' AS Date), CAST(1.826581 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9369479b-795b-4299-9bcd-07a25fb64fab', 12, CAST(N'2001-01-31' AS Date), CAST(1.800082 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2d0fb7b-4b51-49f3-8a76-c98ab08d5b7d', 12, CAST(N'2001-02-28' AS Date), CAST(1.871286 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3467711d-fb6c-4939-89b7-4f6a80e82f19', 12, CAST(N'2001-03-31' AS Date), CAST(1.984646 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'614c6ccd-5d7e-4f8a-963c-f71734017e18', 12, CAST(N'2001-04-30' AS Date), CAST(1.994658 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1db1b3d1-69aa-4cd2-968f-5e2b10181a6f', 12, CAST(N'2001-05-31' AS Date), CAST(1.921010 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cc741eb9-7b04-4e01-9f05-dd62a655441d', 12, CAST(N'2001-06-30' AS Date), CAST(1.930375 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8ff5edf-c929-467c-a993-a34c2e5097f1', 12, CAST(N'2001-07-31' AS Date), CAST(1.959422 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'caa0e082-41d2-4c37-99d3-9f29e0e76e96', 12, CAST(N'2001-08-31' AS Date), CAST(1.907025 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'520400b4-c911-47cb-84a9-6ecdd26209ea', 12, CAST(N'2001-09-30' AS Date), CAST(1.974224 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4645217e-f667-43f0-8556-daa0c999a410', 12, CAST(N'2001-10-31' AS Date), CAST(1.982443 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a15ee5ef-946a-4302-bdbe-6d6a0107aaed', 12, CAST(N'2001-11-30' AS Date), CAST(1.934136 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'36f2580e-ff3b-4247-a1fa-be8128465b23', 12, CAST(N'2001-12-31' AS Date), CAST(1.944718 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a8f3b58-6b51-4896-bd90-612c72fac900', 12, CAST(N'2002-01-31' AS Date), CAST(1.932930 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f1cd7c07-fe17-4a98-a0a5-6a6c5f6766bb', 12, CAST(N'2002-02-28' AS Date), CAST(1.949221 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16012cb2-dc5e-49f0-ba86-450ac966c4c7', 12, CAST(N'2002-03-31' AS Date), CAST(1.905510 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e65bc2c-c6f3-465e-a00d-c361c581d554', 12, CAST(N'2002-04-30' AS Date), CAST(1.867260 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6c458923-ad5f-4a5c-a509-15d100999a42', 12, CAST(N'2002-05-31' AS Date), CAST(1.821677 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8d59499-3f23-41bb-9b38-e3ac5a3c92ef', 12, CAST(N'2002-06-30' AS Date), CAST(1.759342 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9fd4ef9b-ed94-452c-ab4d-918875daacef', 12, CAST(N'2002-07-31' AS Date), CAST(1.802951 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'93d6501b-6a83-4c22-96c7-e1603941a226', 12, CAST(N'2002-08-31' AS Date), CAST(1.847777 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8cde5e3b-d141-44f8-8a5e-3d1b853163ce', 12, CAST(N'2002-09-30' AS Date), CAST(1.827517 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ffc9f47-c94c-4a37-946c-ca7a682c56c3', 12, CAST(N'2002-10-31' AS Date), CAST(1.818658 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0aba7c50-c748-409d-9d57-7bfef2a8f285', 12, CAST(N'2002-11-30' AS Date), CAST(1.781151 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d43d3f0-536c-4ab0-ad26-5d5252e3d2eb', 12, CAST(N'2002-12-31' AS Date), CAST(1.777396 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6c25c31c-ca12-4f39-a90a-ad8cb0c0a096', 12, CAST(N'2003-01-31' AS Date), CAST(1.718053 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8e45ff65-1c32-41a1-8f2f-0441919340fb', 12, CAST(N'2003-02-28' AS Date), CAST(1.682512 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db320cf4-3763-4d93-a608-6030ac609baf', 12, CAST(N'2003-03-31' AS Date), CAST(1.660361 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2a86a250-1846-4cab-bb6b-e47890754ef6', 12, CAST(N'2003-04-30' AS Date), CAST(1.643499 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'03e203fa-a19d-4219-a2e4-3449499d19e4', 12, CAST(N'2003-05-31' AS Date), CAST(1.549366 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d3e9c66-8821-4158-9aa9-9582175c41c3', 12, CAST(N'2003-06-30' AS Date), CAST(1.504028 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f301e328-c79f-4063-bf57-80e61bf5277f', 12, CAST(N'2003-07-31' AS Date), CAST(1.509109 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e6f8453e-68db-4c32-ac93-381176a94169', 12, CAST(N'2003-08-31' AS Date), CAST(1.534493 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77d5b231-bd63-47d1-9424-ac29b0300ad0', 12, CAST(N'2003-09-30' AS Date), CAST(1.515295 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3611d21a-f90d-4875-b28a-9312ae4c4793', 12, CAST(N'2003-10-31' AS Date), CAST(1.443275 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'acbf0af9-15ea-4627-8b5a-e49a4da02a4d', 12, CAST(N'2003-11-30' AS Date), CAST(1.397338 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eeeda13d-c50d-4314-a46d-dd87084a4939', 12, CAST(N'2003-12-31' AS Date), CAST(1.357118 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6f04651d-ac43-46dd-9b46-84b8028530bc', 12, CAST(N'2004-01-31' AS Date), CAST(1.302610 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3e7be613-79d9-484b-ad69-50053f9f3830', 12, CAST(N'2004-02-29' AS Date), CAST(1.288295 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3f39261-8d77-47c1-8dff-52e5b365d872', 12, CAST(N'2004-03-31' AS Date), CAST(1.334696 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'baacbb70-6e60-43e3-b1d0-6d5067e5427c', 12, CAST(N'2004-04-30' AS Date), CAST(1.336217 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01aa5e7b-bce4-4e80-997e-351e85301654', 12, CAST(N'2004-05-31' AS Date), CAST(1.415193 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'32685ba6-6134-47e3-8ead-b4948633de9d', 12, CAST(N'2004-06-30' AS Date), CAST(1.439430 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8bbc6a66-1870-4237-a33f-1273ee18dfcc', 12, CAST(N'2004-07-31' AS Date), CAST(1.399002 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42f39a4c-d45c-4c00-80e6-1f5904755161', 12, CAST(N'2004-08-31' AS Date), CAST(1.408073 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9d2433b3-8c06-4f56-a4af-8a8e8055be92', 12, CAST(N'2004-09-30' AS Date), CAST(1.422095 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0e115750-595d-40ce-930a-bb4a05558702', 12, CAST(N'2004-10-31' AS Date), CAST(1.366049 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e9fe15fb-8ec4-4fa9-9a4f-58be63144617', 12, CAST(N'2004-11-30' AS Date), CAST(1.298501 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f699eb5-b18d-48c5-940e-63d01576e6b1', 12, CAST(N'2004-12-31' AS Date), CAST(1.305548 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'15712c50-7e37-42bc-9d04-921d0f71f78f', 12, CAST(N'2005-01-31' AS Date), CAST(1.305780 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1802d746-bd76-4533-b0f6-85ebe760b881', 12, CAST(N'2005-02-28' AS Date), CAST(1.280876 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'19a93367-d4a0-4901-ac4e-0e850080804f', 12, CAST(N'2005-03-31' AS Date), CAST(1.272960 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'97fe21cb-94df-4594-a3e8-cc6884d5bb4e', 12, CAST(N'2005-04-30' AS Date), CAST(1.293348 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'29e0cfa1-e491-4989-9c28-81c2cd8c34b4', 12, CAST(N'2005-05-31' AS Date), CAST(1.304472 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'05ffcadb-8248-4fc7-9c1e-c1805d01d383', 12, CAST(N'2005-06-30' AS Date), CAST(1.305083 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'012c3638-cd8d-4dbd-a9f9-f22ab5aaafc3', 12, CAST(N'2005-07-31' AS Date), CAST(1.327062 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f19d96c2-e5bc-410b-917f-ab2378ddfba3', 12, CAST(N'2005-08-31' AS Date), CAST(1.311869 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd71c6bff-ec95-42b1-9761-12569ffb6fa1', 12, CAST(N'2005-09-30' AS Date), CAST(1.307421 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'45d5987f-6481-44e6-bced-cf7c496d4699', 12, CAST(N'2005-10-31' AS Date), CAST(1.325926 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4f359328-c3f0-4115-95bf-40e2cfef19c5', 12, CAST(N'2005-11-30' AS Date), CAST(1.359849 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'674c5dce-9a53-4c12-8b4c-1620241aabe9', 12, CAST(N'2005-12-31' AS Date), CAST(1.347822 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4a1ecebb-d86e-48e7-9e9a-d5bbf4ffa49c', 12, CAST(N'2006-01-31' AS Date), CAST(1.335407 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'62e1ee86-31b6-406c-8fed-99d069544f60', 12, CAST(N'2006-02-28' AS Date), CAST(1.348431 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cad48ccd-b1bf-4d70-bf6f-300338b44b35', 12, CAST(N'2006-03-31' AS Date), CAST(1.373892 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da242e32-4383-4c06-9178-643197927cf2', 12, CAST(N'2006-04-30' AS Date), CAST(1.360382 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'260003d6-7b9f-4535-bd08-b64544b27f6f', 12, CAST(N'2006-05-31' AS Date), CAST(1.308166 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13a336d3-361d-41bf-84c1-e58a1594974d', 12, CAST(N'2006-06-30' AS Date), CAST(1.350656 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1788a88d-3e20-4c09-a842-3a47429fb497', 12, CAST(N'2006-07-31' AS Date), CAST(1.331483 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f7e84a3f-5087-4290-9e11-d31cefdd85ca', 12, CAST(N'2006-08-31' AS Date), CAST(1.311044 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'90e23768-8ef7-478b-bac1-296523ab300e', 12, CAST(N'2006-09-30' AS Date), CAST(1.322680 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eada8a5c-aa87-4951-8cef-ff3db4b1d92e', 12, CAST(N'2006-10-31' AS Date), CAST(1.327725 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81d2254a-35a4-4ed8-beff-20d676e07a2c', 12, CAST(N'2006-11-30' AS Date), CAST(1.295469 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b8a6999-0517-422b-84aa-9f223fcf4a6b', 12, CAST(N'2006-12-31' AS Date), CAST(1.272405 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b5559024-b387-47a5-a928-fddae4df0c7b', 12, CAST(N'2007-01-31' AS Date), CAST(1.277902 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'44adb867-64e4-420b-ae2e-a5950d301449', 12, CAST(N'2007-02-28' AS Date), CAST(1.278505 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9ed958c2-8095-430b-87b7-54e47eb77c74', 12, CAST(N'2007-03-31' AS Date), CAST(1.262687 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f44154e0-820d-44f3-bac3-36c6b7591d20', 12, CAST(N'2007-04-30' AS Date), CAST(1.210602 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dcd097eb-6160-445b-a690-a8aa3762645a', 12, CAST(N'2007-05-31' AS Date), CAST(1.213032 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5eceb3c7-3e6b-4ec9-bb72-c990cab3e174', 12, CAST(N'2007-06-30' AS Date), CAST(1.188594 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f68e5d87-338c-4c48-aa6e-55f7adbe42ca', 12, CAST(N'2007-07-31' AS Date), CAST(1.153183 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dca8e27e-af24-4b90-979b-68b3cc7bccae', 12, CAST(N'2007-08-31' AS Date), CAST(1.204795 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'32270e9a-85a9-4ac3-b9ac-1a07d85b72cd', 12, CAST(N'2007-09-30' AS Date), CAST(1.184867 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cbaccbd9-97f3-4988-8232-00f7c8f3976b', 12, CAST(N'2007-10-31' AS Date), CAST(1.114126 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fa9a99ce-aa4f-4606-aeed-fbab8ccad2d9', 12, CAST(N'2007-11-30' AS Date), CAST(1.113212 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8d154f4a-5500-4848-8006-85e21a9689c5', 12, CAST(N'2007-12-31' AS Date), CAST(1.146796 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1f2d306a-aa22-43aa-91b0-9d301d47f195', 12, CAST(N'2008-01-31' AS Date), CAST(1.134630 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bcf88893-faab-496b-af1a-6e2e5381572b', 12, CAST(N'2008-02-29' AS Date), CAST(1.100704 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd06eb508-bf80-43f3-8d19-32a239456a2c', 12, CAST(N'2008-03-31' AS Date), CAST(1.081800 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9e936f73-eda6-47e6-b060-7a73aaf78eb2', 12, CAST(N'2008-04-30' AS Date), CAST(1.075325 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef1b88ec-988b-4996-9d19-03bd9b6d521b', 12, CAST(N'2008-05-31' AS Date), CAST(1.055152 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd01138da-4f15-4418-9dd3-3a573ddea78d', 12, CAST(N'2008-06-30' AS Date), CAST(1.052476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'14f112f9-7a15-4b25-8ece-5b9ef8c81592', 12, CAST(N'2008-07-31' AS Date), CAST(1.039432 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3f04905-65aa-4b0f-b6c6-455a34fac1eb', 12, CAST(N'2008-08-31' AS Date), CAST(1.128535 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7fea45e-539f-4ebf-afdc-618efbb3301a', 12, CAST(N'2008-09-30' AS Date), CAST(1.219897 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ed2aeb1-7390-47ed-b44c-0e8b663fac94', 12, CAST(N'2008-10-31' AS Date), CAST(1.438343 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'329947ee-fb3b-4a2f-92d7-e48ed65e89c9', 12, CAST(N'2008-11-30' AS Date), CAST(1.522187 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'68da4a07-ebe0-47ce-9d52-68c621f68c53', 12, CAST(N'2008-12-31' AS Date), CAST(1.489925 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f30e4daf-1a61-42ca-99d8-331741fe43cd', 12, CAST(N'2009-01-31' AS Date), CAST(1.476335 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94510822-c20b-4d64-9fa1-a58793542290', 12, CAST(N'2009-02-28' AS Date), CAST(1.539005 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a09b65f0-8f6a-4779-a3fb-b4f56a0aa783', 12, CAST(N'2009-03-31' AS Date), CAST(1.504952 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b9199ef1-26f9-4d5e-b6d7-55a52c2f59e9', 12, CAST(N'2009-04-30' AS Date), CAST(1.399283 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'18c6acbe-3a23-4a16-8356-9b8a0201c0d9', 12, CAST(N'2009-05-31' AS Date), CAST(1.313388 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db13b33e-e856-440f-a349-3208734ca4a0', 12, CAST(N'2009-06-30' AS Date), CAST(1.244097 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42074d35-f85d-4582-84d0-ea3fdbdb7564', 12, CAST(N'2009-07-31' AS Date), CAST(1.247614 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0cd13657-3a61-404f-b793-21a10e51d123', 12, CAST(N'2009-08-31' AS Date), CAST(1.197603 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef1a62a6-028c-4974-be79-91b99144922f', 12, CAST(N'2009-09-30' AS Date), CAST(1.162112 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e0808f27-f6fe-40cb-bdb4-0c1a6b57fad6', 12, CAST(N'2009-10-31' AS Date), CAST(1.106134 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec8d45b5-d147-4e0b-ab65-3745a7b35bae', 12, CAST(N'2009-11-30' AS Date), CAST(1.089152 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f805917-5bf7-44a2-b127-da83154fedd6', 12, CAST(N'2009-12-31' AS Date), CAST(1.109618 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6d44ce7b-6f23-40cc-88f1-b1c1063d480a', 12, CAST(N'2010-01-31' AS Date), CAST(1.097948 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7a168571-f729-4ce2-93ea-ab22d3e67a5d', 12, CAST(N'2010-02-28' AS Date), CAST(1.129932 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3b43744-623d-4258-826e-7c9b5c252e04', 12, CAST(N'2010-03-31' AS Date), CAST(1.097858 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3811a872-dede-45bf-b1a9-5d4be9eb4764', 12, CAST(N'2010-04-30' AS Date), CAST(1.080073 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aaec8c3d-f89b-41c4-9707-f6c375b642f3', 12, CAST(N'2010-05-31' AS Date), CAST(1.145226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0490d1e1-c29b-4a37-b019-d2404f1f80e8', 12, CAST(N'2010-06-30' AS Date), CAST(1.171690 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94ca44d8-1347-471e-a585-76402cbfac71', 12, CAST(N'2010-07-31' AS Date), CAST(1.143857 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'52f92e57-87d5-41e6-b3dd-fa5d96f5fda4', 12, CAST(N'2010-08-31' AS Date), CAST(1.110439 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9118b998-a6aa-4fdb-b178-e44ba39f6f23', 12, CAST(N'2010-09-30' AS Date), CAST(1.070063 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb23e51e-659c-4b4b-aa9d-fe2e4117730e', 12, CAST(N'2010-10-31' AS Date), CAST(1.019487 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8ae57a4-a97c-4dc9-9a7b-0b566fb7c70d', 12, CAST(N'2010-11-30' AS Date), CAST(1.011449 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48d6c0e4-203e-4c01-aec8-df168f3983de', 12, CAST(N'2010-12-31' AS Date), CAST(1.008102 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ae7eeef-8e4c-409b-a5af-8a3b0d9c616d', 12, CAST(N'2011-01-31' AS Date), CAST(1.002661 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f7166b59-0144-4451-b6ff-182971f5f9ca', 12, CAST(N'2011-02-28' AS Date), CAST(0.991546 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e021b301-e714-4ae1-815e-19cfa1e92f51', 12, CAST(N'2011-03-31' AS Date), CAST(0.990022 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f172dbc-9501-4afc-8be8-e942361bbaf9', 12, CAST(N'2011-04-30' AS Date), CAST(0.945688 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'36f4e758-e77c-4d8f-bb40-23429803e11f', 12, CAST(N'2011-05-31' AS Date), CAST(0.935534 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3dc5f0a7-3142-4586-b68c-10aea0d2cba4', 12, CAST(N'2011-06-30' AS Date), CAST(0.943008 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e246ed15-f253-4dc7-9b9d-1d97b99e6802', 12, CAST(N'2011-07-31' AS Date), CAST(0.927775 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e2371177-25cc-4e90-a00a-9ceccb41b4ae', 12, CAST(N'2011-08-31' AS Date), CAST(0.953325 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'236de6a2-6978-49e5-8165-82fd40294e3c', 12, CAST(N'2011-09-30' AS Date), CAST(0.973368 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7973a23d-b880-4b8e-9671-7d774f175f56', 12, CAST(N'2011-10-31' AS Date), CAST(0.988054 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7a488b80-77ab-42f6-bcbe-0304e8783df5', 12, CAST(N'2011-11-30' AS Date), CAST(0.986771 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08bde77b-636c-4d8d-9394-3f1aff411fd1', 12, CAST(N'2011-12-31' AS Date), CAST(0.986258 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6641be48-c949-4d45-abf5-3e8c9d90c514', 12, CAST(N'2012-01-31' AS Date), CAST(0.963011 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ffa708c3-248c-4ba1-bed1-c210721393f3', 12, CAST(N'2012-02-29' AS Date), CAST(0.932773 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'686043fb-790a-410e-be79-b884781fa77c', 12, CAST(N'2012-03-31' AS Date), CAST(0.947794 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8307c4bf-7980-4530-a6f0-061fe5f72d08', 12, CAST(N'2012-04-30' AS Date), CAST(0.965445 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'361cafb1-c572-4ae2-9930-fbe72bd0efe6', 12, CAST(N'2012-05-31' AS Date), CAST(1.001379 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e0001eb-b413-48cd-9895-e471460b0a03', 12, CAST(N'2012-06-30' AS Date), CAST(1.003701 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b99c30c-d4b2-47b4-8784-c64f61b7484b', 12, CAST(N'2012-07-31' AS Date), CAST(0.971100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2913b892-a794-4c6c-be34-8621c732135b', 12, CAST(N'2012-08-31' AS Date), CAST(0.954116 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8475fb76-7766-4f59-a4c3-ed7f1ce660f4', 12, CAST(N'2012-09-30' AS Date), CAST(0.961206 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46abe55c-ad29-4473-8ff8-6eec82e7f1a9', 12, CAST(N'2012-10-31' AS Date), CAST(0.971769 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f11586df-e199-4f45-8e24-af6800b81cb9', 12, CAST(N'2012-11-30' AS Date), CAST(0.961996 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6ab62e2-3714-48e3-98a5-f8c7a3d325ee', 12, CAST(N'2012-12-31' AS Date), CAST(0.956228 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c825b7c2-f475-4f6e-9480-7e9e8aca48e0', 12, CAST(N'2013-01-31' AS Date), CAST(0.953122 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3bfb5e5d-b287-4ed4-a91e-38b9d87898d2', 12, CAST(N'2013-02-28' AS Date), CAST(0.968709 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c03f91ef-bf3e-4c17-ba08-cdac20521b00', 12, CAST(N'2013-03-31' AS Date), CAST(0.967290 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4c1d0774-75d8-496a-b893-15e0f8fd3d7d', 12, CAST(N'2013-04-30' AS Date), CAST(0.963541 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e1543711-ebb3-48da-b5f9-d4f712daaa3c', 12, CAST(N'2013-05-31' AS Date), CAST(1.007183 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'90f01fe0-7a03-4e97-93ca-c5a6e0b0a9c2', 12, CAST(N'2013-06-30' AS Date), CAST(1.059414 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c46f3237-9e78-48a0-b3bb-18497e013e16', 12, CAST(N'2013-07-31' AS Date), CAST(1.091984 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'396babe2-b936-4066-a649-7df84ff901b2', 12, CAST(N'2013-08-31' AS Date), CAST(1.105671 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eba9082c-4aa1-431c-879a-38a303ac65d2', 12, CAST(N'2013-09-30' AS Date), CAST(1.080317 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7cd48426-5506-49fc-8a4e-3b2599e5e913', 12, CAST(N'2013-10-31' AS Date), CAST(1.050750 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'505778aa-42cd-4bbe-abe8-dda0fc13e3e9', 12, CAST(N'2013-11-30' AS Date), CAST(1.072500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17d0f30d-ed74-4d94-bfdc-7a6130c45077', 12, CAST(N'2013-12-31' AS Date), CAST(1.113109 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'63e27b9b-92d0-419d-ab1c-d47d70d7dcf8', 12, CAST(N'2014-01-31' AS Date), CAST(1.128859 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bba60a65-062f-404c-8804-83c079499536', 12, CAST(N'2014-02-28' AS Date), CAST(1.116690 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b5b6295b-f63b-4f4a-bd8e-23ecdb4ebd52', 12, CAST(N'2014-03-31' AS Date), CAST(1.102443 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5cf5c55-03cb-4d39-b476-5620c9ca9951', 12, CAST(N'2014-04-30' AS Date), CAST(1.073605 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6358a08c-fbd7-48ed-8648-10946ee58101', 12, CAST(N'2014-05-31' AS Date), CAST(1.070200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8d19581-2cdf-47a9-8dac-1f0e94494c5a', 12, CAST(N'2014-06-30' AS Date), CAST(1.067948 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e10fb2cb-e797-4249-b5df-c27eeb2b8e32', 12, CAST(N'2014-07-31' AS Date), CAST(1.064708 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d4f2a02-8dfa-40b6-95ec-f74858b899a4', 12, CAST(N'2014-08-31' AS Date), CAST(1.074195 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b57d0562-5f8c-493e-a0cc-3388ca7318c3', 12, CAST(N'2014-09-30' AS Date), CAST(1.103888 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd24f98f8-5cad-4644-bb6f-e91f02ad96ab', 12, CAST(N'2014-10-31' AS Date), CAST(1.141017 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fbb63899-f268-42cf-b061-280b35ae479a', 12, CAST(N'2014-11-30' AS Date), CAST(1.154735 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'22c86c00-db29-429c-92cd-a3f2c46bef7d', 12, CAST(N'2014-12-31' AS Date), CAST(1.213293 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'69c2b13d-a5d6-43f4-9d05-61e5bba0c46d', 12, CAST(N'2015-01-31' AS Date), CAST(1.237968 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8b204fd-c88a-49c3-a381-55104cec028e', 12, CAST(N'2015-02-28' AS Date), CAST(1.282689 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'83aedab5-c737-4252-8b97-aa0fd93ca437', 12, CAST(N'2015-03-31' AS Date), CAST(1.293411 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'835ff4a6-4b2d-4204-9ae3-f9951ba5bc0e', 12, CAST(N'2015-04-30' AS Date), CAST(1.294143 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bab30453-068a-435f-ab57-2529b61e3c8e', 12, CAST(N'2015-05-31' AS Date), CAST(1.268318 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6fc56269-27b8-4b0d-9c5e-29261db042d7', 12, CAST(N'2015-06-30' AS Date), CAST(1.297247 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6f13fc74-d05a-4737-8063-680a25a1ae5d', 12, CAST(N'2015-07-31' AS Date), CAST(1.347844 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f2ce32d2-e78d-4a0e-b2ab-149be50a2c05', 12, CAST(N'2015-08-31' AS Date), CAST(1.368342 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fb3ace49-ef9f-4446-9523-c2daffd601f9', 12, CAST(N'2015-09-30' AS Date), CAST(1.416088 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c054cad8-57f0-4287-a639-d5efb482c9c3', 12, CAST(N'2015-10-31' AS Date), CAST(1.388068 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8372496-2dc4-489e-8356-d8719534b5d7', 12, CAST(N'2015-11-30' AS Date), CAST(1.399943 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aed71106-d763-479e-a6e0-da4dacb76422', 12, CAST(N'2015-12-31' AS Date), CAST(1.380100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec4379aa-ffb4-46bc-b432-fbdfe1336d54', 12, CAST(N'2016-01-31' AS Date), CAST(1.422723 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'062c3958-a81d-4c05-8098-09781485863d', 12, CAST(N'2016-02-29' AS Date), CAST(1.403469 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'755cf2eb-a229-447e-9834-4df865e5f9b5', 12, CAST(N'2016-03-31' AS Date), CAST(1.334747 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'10e03795-e229-4db6-af26-c750a2e35693', 12, CAST(N'2016-04-30' AS Date), CAST(1.304878 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b7aa5c5-b857-4579-bf9c-e1a1f95ad7a2', 12, CAST(N'2016-05-31' AS Date), CAST(1.365856 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2233ad33-d46c-4b06-8a46-2e40ac4e2bea', 12, CAST(N'2016-06-30' AS Date), CAST(1.352861 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd6f56835-56be-4e1f-8e5e-0e2fd2a50672', 12, CAST(N'2016-07-31' AS Date), CAST(1.328415 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c387807-fdee-47a1-8ec6-3a531d82b296', 12, CAST(N'2016-08-31' AS Date), CAST(1.311112 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b23c230-0c51-4560-9ee6-2fa84370f35e', 12, CAST(N'2016-09-30' AS Date), CAST(1.320827 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'354c326e-412a-4c64-ac7d-8be35703beb0', 12, CAST(N'2016-10-31' AS Date), CAST(1.313046 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'263b70a3-bb64-4442-a57f-65987017d808', 12, CAST(N'2016-11-30' AS Date), CAST(1.330105 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df5dea36-15c4-4251-b4fa-0b7170f20bba', 12, CAST(N'2016-12-31' AS Date), CAST(1.363180 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'388769ec-733d-4408-a125-5d59b43d8b1c', 12, CAST(N'2017-01-31' AS Date), CAST(1.342118 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'938e761a-40d5-41b2-b5e5-699da35ce6ea', 12, CAST(N'2017-02-28' AS Date), CAST(1.304068 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6d1888d-2c4b-4830-b623-b43235db6af1', 12, CAST(N'2017-03-31' AS Date), CAST(1.312279 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5425b091-fb7e-44fb-b90f-7c093dedbd72', 12, CAST(N'2017-04-30' AS Date), CAST(1.327322 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9793e694-8188-4f19-9764-68cb090fa582', 12, CAST(N'2017-05-31' AS Date), CAST(1.345501 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'28ad38f6-3283-4a20-8934-f53d39cfdfcf', 12, CAST(N'2017-06-30' AS Date), CAST(1.323688 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85d51a9e-3001-4afa-a3d2-ddbacfcd55d0', 12, CAST(N'2017-07-31' AS Date), CAST(1.282525 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'421166f4-57ac-4ceb-ba12-692cb4595f0a', 12, CAST(N'2017-08-31' AS Date), CAST(1.263344 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ed8e7f6-e3b7-4019-afba-61bbd3f2591d', 12, CAST(N'2017-09-30' AS Date), CAST(1.253718 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f78fb0d5-7750-4232-80ab-ae585b2f9467', 12, CAST(N'2017-10-31' AS Date), CAST(1.284490 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48d9ed70-33e2-4d13-8705-3d3ee0250537', 12, CAST(N'2017-11-30' AS Date), CAST(1.312073 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'44bbc11f-c099-4be3-9c2e-49b9c27ddf1a', 12, CAST(N'2017-12-31' AS Date), CAST(1.306028 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'279d26eb-5863-4d92-8f2c-a7587f7799c0', 12, CAST(N'2018-01-31' AS Date), CAST(1.257423 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d775b1c-c4e7-437e-9d0e-cacd6cebc0b0', 12, CAST(N'2018-02-28' AS Date), CAST(1.270755 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1668045e-c126-4ec7-9ffb-9fee61b7cc55', 12, CAST(N'2018-03-31' AS Date), CAST(1.289062 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c33a16f3-c280-4082-9f21-3235c8fae56a', 12, CAST(N'2018-04-30' AS Date), CAST(1.301910 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd3956493-6d2f-4540-bfcc-86bf1e92761d', 12, CAST(N'2018-05-31' AS Date), CAST(1.327973 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'592eef26-3a10-4e77-bcb9-6938957d057b', 12, CAST(N'2018-06-30' AS Date), CAST(1.334226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09814832-4626-430a-8229-c20f7a9f85a4', 12, CAST(N'2018-07-31' AS Date), CAST(1.350496 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9223627d-492e-4a33-a95e-e43931d45c8e', 12, CAST(N'2018-08-31' AS Date), CAST(1.364735 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5085a318-28bc-40e6-b63c-904f0895546d', 12, CAST(N'2018-09-30' AS Date), CAST(1.388886 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a926660-413e-465f-9939-be7107942549', 12, CAST(N'2018-10-31' AS Date), CAST(1.407698 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec564597-35e1-43df-835a-9f154b28b900', 12, CAST(N'2018-11-30' AS Date), CAST(1.379949 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2596593-8833-4c9d-936d-9c4ee8a222b3', 12, CAST(N'2018-12-31' AS Date), CAST(1.396893 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4bbb1bd-3832-437c-860b-3a2ab253cea6', 12, CAST(N'2019-01-31' AS Date), CAST(1.398086 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'70c389ed-1139-4739-b34b-ee544cd7102f', 12, CAST(N'2019-02-28' AS Date), CAST(1.400169 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7eb18ebe-847b-4b84-85ac-0636d322ad5a', 12, CAST(N'2019-03-31' AS Date), CAST(1.412695 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'58c4704c-d56c-44c0-9908-94f34b93dd8a', 12, CAST(N'2019-04-30' AS Date), CAST(1.405847 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c0eadf91-8e36-4398-ba71-6e97ae752a97', 12, CAST(N'2019-05-31' AS Date), CAST(1.439668 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb91087b-0192-4cb6-a492-1724016fddcd', 12, CAST(N'2019-06-30' AS Date), CAST(1.439347 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'66f99af2-20c3-4f7d-a2b8-6d05c85840e4', 12, CAST(N'2019-07-31' AS Date), CAST(1.432225 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f7d2c1f-a2e3-4c93-9978-83069e1459c7', 12, CAST(N'2019-08-31' AS Date), CAST(1.476194 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'44ed4c0a-160e-45ff-aede-59ea4fa73023', 12, CAST(N'2019-09-30' AS Date), CAST(1.468828 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ae80dcf-30d1-4a31-9ae5-448919f03c83', 12, CAST(N'2019-10-31' AS Date), CAST(1.470617 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8b715d34-b6fa-426a-bd14-0fdb4bb33a3e', 12, CAST(N'2019-11-30' AS Date), CAST(1.464694 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db3a2bd2-2e71-473a-9626-ed2c765fcf19', 12, CAST(N'2019-12-31' AS Date), CAST(1.452040 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc7b4f1c-7cab-4345-8629-e9bab19d5226', 12, CAST(N'2020-01-31' AS Date), CAST(1.456465 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c4cc278-3404-4a1b-85a0-9f0f14468bc9', 12, CAST(N'2020-02-29' AS Date), CAST(1.500632 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d2811f0-f9c2-4d0d-845f-5e0ae03b2d0a', 81, CAST(N'1999-01-31' AS Date), CAST(0.862566 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5a4299b-16c2-4c55-9a98-17863b8ddaf7', 81, CAST(N'1999-02-28' AS Date), CAST(0.892486 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dbda61eb-d74b-4bbc-9beb-dac8d0c795eb', 81, CAST(N'1999-03-31' AS Date), CAST(0.918784 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6bbec6e5-a763-4541-9c46-69829427445d', 81, CAST(N'1999-04-30' AS Date), CAST(0.934975 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9d70a99e-9f80-4258-a6dd-6e621e75940c', 81, CAST(N'1999-05-31' AS Date), CAST(0.941486 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00adcb4d-1801-477e-a1df-02633548ba5a', 81, CAST(N'1999-06-30' AS Date), CAST(0.963674 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'62760e54-3222-4ec0-a9a1-aae5800c2ac5', 81, CAST(N'1999-07-31' AS Date), CAST(0.964811 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84b86e0e-6018-4558-aef0-abd8565c75b0', 81, CAST(N'1999-08-31' AS Date), CAST(0.943074 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'19cab258-40af-4de1-b655-d255dd91059f', 81, CAST(N'1999-09-30' AS Date), CAST(0.952620 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'90a58406-6792-4560-a453-b0a1109c0e05', 81, CAST(N'1999-10-31' AS Date), CAST(0.934124 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1f43d1e1-9578-4c9a-a858-ac88a2d985da', 81, CAST(N'1999-11-30' AS Date), CAST(0.968539 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77061848-62b2-4c3e-a4b6-2aae3594bfc3', 81, CAST(N'1999-12-31' AS Date), CAST(0.989030 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e03c52a9-b1c3-486c-9fb2-e589fdba169a', 81, CAST(N'2000-01-31' AS Date), CAST(0.987611 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'57f3eab9-eccb-45e1-a65c-0c9447d36611', 81, CAST(N'2000-02-29' AS Date), CAST(1.017398 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4a19155-f832-4b04-bb04-4a6d9627e9b4', 81, CAST(N'2000-03-31' AS Date), CAST(1.036510 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'24c13740-ca8e-4948-b24c-0d88c272b0d7', 81, CAST(N'2000-04-30' AS Date), CAST(1.056792 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6d9edd3a-684b-4b40-aae9-aed6ee261eef', 81, CAST(N'2000-05-31' AS Date), CAST(1.101571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3665f966-9215-477b-84ab-ab8d6f844eb0', 81, CAST(N'2000-06-30' AS Date), CAST(1.053701 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'caa666ae-fb58-4dfd-b654-bd8e43b94a25', 81, CAST(N'2000-07-31' AS Date), CAST(1.064032 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13321000-c517-470e-8eed-3028ac91a7c0', 81, CAST(N'2000-08-31' AS Date), CAST(1.104440 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16888bfe-5a1b-4cbc-8fa9-ca29310808f1', 81, CAST(N'2000-09-30' AS Date), CAST(1.148160 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cdc7ec23-f6e2-49be-af96-639a6be24b99', 81, CAST(N'2000-10-31' AS Date), CAST(1.169133 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af958522-63e2-4b1c-91ea-7966646201a5', 81, CAST(N'2000-11-30' AS Date), CAST(1.168960 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8024083-da24-442d-a829-fe0681c87ce6', 81, CAST(N'2000-12-31' AS Date), CAST(1.112062 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c460fa44-e4bb-4668-aeb9-282c113a93b6', 81, CAST(N'2001-01-31' AS Date), CAST(1.065594 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'74d964a4-9ebf-4250-8bb9-03b1a79731cb', 81, CAST(N'2001-02-28' AS Date), CAST(1.085974 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c7abb40-12b4-4d54-96e9-0aaa668f028a', 81, CAST(N'2001-03-31' AS Date), CAST(1.100009 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b67818a8-d6d3-4c25-a7b4-0f0e6b7c063d', 81, CAST(N'2001-04-30' AS Date), CAST(1.121112 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4edcf546-829e-48d0-82f5-4ff4ca4f4f8d', 81, CAST(N'2001-05-31' AS Date), CAST(1.141182 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb403423-7bec-48a9-ae3a-4a63a7635bb0', 81, CAST(N'2001-06-30' AS Date), CAST(1.171584 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'437d2581-afcb-4f5f-b1be-0f65623db517', 81, CAST(N'2001-07-31' AS Date), CAST(1.163571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4c2d0871-7e20-4b2c-be4d-5b09ca915a91', 81, CAST(N'2001-08-31' AS Date), CAST(1.110609 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2711c04f-6815-4e55-b1c1-afaf8b6b1660', 81, CAST(N'2001-09-30' AS Date), CAST(1.096660 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a509ad98-771f-49f7-b0eb-8d412bc073b9', 81, CAST(N'2001-10-31' AS Date), CAST(1.103611 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4d6e1f9-5636-474b-b73c-a51149413b08', 81, CAST(N'2001-11-30' AS Date), CAST(1.126963 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd628dd9a-6421-4814-90f2-95336b662d5d', 81, CAST(N'2001-12-31' AS Date), CAST(1.120646 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5ec7d21-272b-41d3-a04b-a492eecc68b2', 81, CAST(N'2002-01-31' AS Date), CAST(1.130415 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'44beb9f9-4499-4064-851b-bafef7a9bdef', 81, CAST(N'2002-02-28' AS Date), CAST(1.149516 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'04fa4520-8e51-4714-a42f-6bfd7716fe08', 81, CAST(N'2002-03-31' AS Date), CAST(1.141443 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f584b22e-b070-4e26-942e-ffd68352601c', 81, CAST(N'2002-04-30' AS Date), CAST(1.129830 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e9b8460b-ba81-4dac-b1cb-8a41470d07c7', 81, CAST(N'2002-05-31' AS Date), CAST(1.091831 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23f296c5-89f8-4fe0-958c-b1bb8a87f014', 81, CAST(N'2002-06-30' AS Date), CAST(1.047553 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd01adcee-f5d6-4d83-83a4-6fe29ae76a08', 81, CAST(N'2002-07-31' AS Date), CAST(1.005981 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7f1e9467-1707-4c3a-ad6c-36e8eb702d30', 81, CAST(N'2002-08-31' AS Date), CAST(1.022842 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41ae3d39-1c5c-4c2d-aa10-28d99c5e98e0', 81, CAST(N'2002-09-30' AS Date), CAST(1.020248 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'96de26b6-cd43-4829-939e-92577bc099bb', 81, CAST(N'2002-10-31' AS Date), CAST(1.018568 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b0b79af2-0505-4b83-8e49-a02179fa9af4', 81, CAST(N'2002-11-30' AS Date), CAST(0.997651 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a2b90c6-8ba7-4674-84a5-172875564742', 81, CAST(N'2002-12-31' AS Date), CAST(0.983915 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b66e40bf-fa3a-403d-bca6-16ceca0f65e0', 81, CAST(N'2003-01-31' AS Date), CAST(0.943214 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'49116bcb-0324-4f62-937b-0beae741a2e0', 81, CAST(N'2003-02-28' AS Date), CAST(0.927373 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2008da3f-88d3-4aaa-82d2-2e534ee1dad0', 81, CAST(N'2003-03-31' AS Date), CAST(0.926616 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33b2af61-56b0-44fd-9ae8-2ac27f054d9d', 81, CAST(N'2003-04-30' AS Date), CAST(0.922396 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fa11b89a-8aaa-44d2-9f05-fc86b4acef5b', 81, CAST(N'2003-05-31' AS Date), CAST(0.866864 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9635b8fb-229e-4b32-99ef-f0e6967f9f1c', 81, CAST(N'2003-06-30' AS Date), CAST(0.855404 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3cbc52cb-15c8-43f5-babd-ea4b822cd5a5', 81, CAST(N'2003-07-31' AS Date), CAST(0.878082 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6bc80361-4e53-46a0-8405-93e969366217', 81, CAST(N'2003-08-31' AS Date), CAST(0.896779 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b7357e6-9e2a-4ac8-910d-34a34bc999f1', 81, CAST(N'2003-09-30' AS Date), CAST(0.892320 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'700977ce-1e91-4df6-b9ef-d0c487991bf3', 81, CAST(N'2003-10-31' AS Date), CAST(0.853720 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'086baddd-5a23-497c-ab48-888a7391c0f8', 81, CAST(N'2003-11-30' AS Date), CAST(0.854425 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f66f11cf-c6de-4034-9e55-5b135eaefac8', 81, CAST(N'2003-12-31' AS Date), CAST(0.815293 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5d3c394-3fee-465e-bcb3-3aaa833cb76c', 81, CAST(N'2004-01-31' AS Date), CAST(0.793143 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b563c748-931e-44c5-b031-8d24cfe398d5', 81, CAST(N'2004-02-29' AS Date), CAST(0.792831 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94e7e449-408e-4e49-80a0-c3c16a8c3428', 81, CAST(N'2004-03-31' AS Date), CAST(0.814878 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6ff24765-79bc-439c-b121-9482a3d5a46f', 81, CAST(N'2004-04-30' AS Date), CAST(0.830913 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'54b024c8-8edb-4ad2-87b7-39e196cb08cc', 81, CAST(N'2004-05-31' AS Date), CAST(0.833200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c61a5b7-44a5-4c9d-8531-347bf376230e', 81, CAST(N'2004-06-30' AS Date), CAST(0.823131 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b382f61b-9635-444e-8264-2e75eef2ccb9', 81, CAST(N'2004-07-31' AS Date), CAST(0.815164 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0a830d13-5ff2-4674-98f3-1c512ce0a061', 81, CAST(N'2004-08-31' AS Date), CAST(0.821033 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09d67600-7d57-447b-a0e1-1fa79d893122', 81, CAST(N'2004-09-30' AS Date), CAST(0.815902 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cd33018a-9f9b-40c5-863c-db92fd36a277', 81, CAST(N'2004-10-31' AS Date), CAST(0.800770 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27dc7b44-199c-4a30-a82b-850240986ddf', 81, CAST(N'2004-11-30' AS Date), CAST(0.770336 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'588a7957-88d2-4915-aa01-825def03e516', 81, CAST(N'2004-12-31' AS Date), CAST(0.745149 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'255b7214-105c-40e3-90e4-29ab1506adc4', 81, CAST(N'2005-01-31' AS Date), CAST(0.753247 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ad620b3-2cc8-4b2d-bcf8-0d82a661c26c', 81, CAST(N'2005-02-28' AS Date), CAST(0.769485 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a6e19c6-fdf6-4eab-b4d1-78268252afeb', 81, CAST(N'2005-03-31' AS Date), CAST(0.757570 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5cd010d2-6cd0-4b5e-aca0-5e6c29d188ab', 81, CAST(N'2005-04-30' AS Date), CAST(0.772585 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fbec6de8-cd8b-4d78-afc9-b1390cd490da', 81, CAST(N'2005-05-31' AS Date), CAST(0.787275 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33b5d2dc-d59f-46f1-856f-79e201e62a16', 81, CAST(N'2005-06-30' AS Date), CAST(0.821699 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2197f48d-a6c8-4035-af10-62db2035f288', 81, CAST(N'2005-07-31' AS Date), CAST(0.831595 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6479377b-bdb7-4c78-b6c1-5410393598a2', 81, CAST(N'2005-08-31' AS Date), CAST(0.813199 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd305c920-c66a-49ae-83d3-e59883b7c546', 81, CAST(N'2005-09-30' AS Date), CAST(0.815390 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01d51044-33e6-4650-ae7e-bb3003863a34', 81, CAST(N'2005-10-31' AS Date), CAST(0.830923 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'18699433-ec35-4652-902c-32dd95e208d2', 81, CAST(N'2005-11-30' AS Date), CAST(0.848133 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9803309-1104-4738-b534-621272c6a79b', 81, CAST(N'2005-12-31' AS Date), CAST(0.843222 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'891ddac8-a229-450c-ab83-6bf9c8b76668', 81, CAST(N'2006-01-31' AS Date), CAST(0.826020 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eccd26a8-49b2-460e-bc2c-a9925b9903db', 81, CAST(N'2006-02-28' AS Date), CAST(0.837126 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'06c8752e-eed8-4b5e-bbd7-31678ed7bc9d', 81, CAST(N'2006-03-31' AS Date), CAST(0.832105 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c12b610b-0c4a-443c-b348-1fbc5846aff1', 81, CAST(N'2006-04-30' AS Date), CAST(0.816108 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'324ecf41-22cd-439b-be44-82d8e7c3335d', 81, CAST(N'2006-05-31' AS Date), CAST(0.783203 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a1740dd-a181-4af1-ba2e-d94429daec8b', 81, CAST(N'2006-06-30' AS Date), CAST(0.789440 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aed6e36f-b319-4980-b956-5ad713bcfe63', 81, CAST(N'2006-07-31' AS Date), CAST(0.787583 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fd4ee854-dd89-447b-bdc4-641e0797638b', 81, CAST(N'2006-08-31' AS Date), CAST(0.781065 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cbbe4ac2-c607-44a4-a12c-6cc7ee1b65d5', 81, CAST(N'2006-09-30' AS Date), CAST(0.785126 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a246fa74-4fae-4994-9785-55b648a7354e', 81, CAST(N'2006-10-31' AS Date), CAST(0.792394 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'275bfce0-1712-4b50-99ff-d031b5cbb011', 81, CAST(N'2006-11-30' AS Date), CAST(0.776782 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'139cbe8c-54e9-49b0-8e24-c15219c0b0a4', 81, CAST(N'2006-12-31' AS Date), CAST(0.757058 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ca45077-fd75-41f6-873c-118d0fe29bb3', 81, CAST(N'2007-01-31' AS Date), CAST(0.769737 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c2575c1-72bf-4ded-96b5-e4fd3afad2c2', 81, CAST(N'2007-02-28' AS Date), CAST(0.765053 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91132948-1723-4ee9-b358-0741a209f422', 81, CAST(N'2007-03-31' AS Date), CAST(0.755412 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8e10694-b9ac-416a-9693-46d420284401', 81, CAST(N'2007-04-30' AS Date), CAST(0.740806 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a264daf-5712-4441-ac90-f6c9bc03076e', 81, CAST(N'2007-05-31' AS Date), CAST(0.740041 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f1034d2-465a-49c1-8ceb-320f37160ec2', 81, CAST(N'2007-06-30' AS Date), CAST(0.745371 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da46ebc2-37b9-4ec4-acb5-c6b5c40bcefc', 81, CAST(N'2007-07-31' AS Date), CAST(0.729018 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c8c426aa-61db-4ce7-8ad2-33418fa22d0f', 81, CAST(N'2007-08-31' AS Date), CAST(0.734203 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e1d83001-0ec0-4cf6-8a1c-1f842d374f5e', 81, CAST(N'2007-09-30' AS Date), CAST(0.720104 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8cca8b5-20af-4e88-8025-f221b1214756', 81, CAST(N'2007-10-31' AS Date), CAST(0.703086 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2bfc1c73-7cd8-4e36-a0a3-38d49833eca2', 81, CAST(N'2007-11-30' AS Date), CAST(0.681929 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e70696c3-0574-4507-a791-67277db9bfe4', 81, CAST(N'2007-12-31' AS Date), CAST(0.686845 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd7ee6983-737f-4d44-8d06-9e7f0e2867a5', 81, CAST(N'2008-01-31' AS Date), CAST(0.680153 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3e52e105-c827-41f2-a1ea-90bdcd2e6213', 81, CAST(N'2008-02-29' AS Date), CAST(0.679571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'606d9186-ac43-475a-84ec-9bb7c04a8cae', 81, CAST(N'2008-03-31' AS Date), CAST(0.646066 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'778cebfb-b061-49b8-99d2-f68c0f721a7f', 81, CAST(N'2008-04-30' AS Date), CAST(0.634241 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'58689f89-cd35-45a7-acb7-40222106ab27', 81, CAST(N'2008-05-31' AS Date), CAST(0.643417 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23751950-84bc-4adb-845e-5f4b7477b0c8', 81, CAST(N'2008-06-30' AS Date), CAST(0.643168 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17d8e3da-6e97-43ea-b85b-2972ed6c0cc7', 81, CAST(N'2008-07-31' AS Date), CAST(0.634992 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e6fc9cb9-f863-41bf-94da-2ffaf9bc6fbb', 81, CAST(N'2008-08-31' AS Date), CAST(0.666246 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0e47242-3c0b-44b2-b229-b4020c7428da', 81, CAST(N'2008-09-30' AS Date), CAST(0.695786 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'780d2a13-b4c7-4894-b9ee-649772a76e33', 81, CAST(N'2008-10-31' AS Date), CAST(0.746894 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b565589-70ce-4ae3-a7cf-91eb1feb7af4', 81, CAST(N'2008-11-30' AS Date), CAST(0.785321 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6e4fb35e-84b3-4bb2-8823-e5a22d45e2df', 81, CAST(N'2008-12-31' AS Date), CAST(0.741668 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2075701a-c303-4074-9426-49c329d0401c', 81, CAST(N'2009-01-31' AS Date), CAST(0.750006 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6cc25baa-2281-46b8-81e8-bea263389384', 81, CAST(N'2009-02-28' AS Date), CAST(0.780884 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84ea4e21-ca12-40b8-bc6a-8a4f06ce477d', 81, CAST(N'2009-03-31' AS Date), CAST(0.766233 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e0359e27-dcfb-4631-b984-c347e484033e', 81, CAST(N'2009-04-30' AS Date), CAST(0.758043 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'741e8179-eabd-461b-becb-7b1292269647', 81, CAST(N'2009-05-31' AS Date), CAST(0.733619 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'50c60f49-9156-468d-b033-5494f56a5ae9', 81, CAST(N'2009-06-30' AS Date), CAST(0.712450 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b36842fc-51f4-48f2-80bd-246127746970', 81, CAST(N'2009-07-31' AS Date), CAST(0.710590 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'989aed8e-8977-451c-859d-940543453b28', 81, CAST(N'2009-08-31' AS Date), CAST(0.701414 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6306186b-c336-4386-993d-d2eb9a792207', 81, CAST(N'2009-09-30' AS Date), CAST(0.687107 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e97f8fb4-14d6-41db-b5bf-757402bd905c', 81, CAST(N'2009-10-31' AS Date), CAST(0.675428 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b865a10-5924-4955-97f4-2220abf3374d', 81, CAST(N'2009-11-30' AS Date), CAST(0.671407 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76432ade-c9c2-4c0c-9f61-6c294552293a', 81, CAST(N'2009-12-31' AS Date), CAST(0.685756 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b47a497e-93f9-425b-84e1-ebaffb6698ce', 81, CAST(N'2010-01-31' AS Date), CAST(0.700487 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'44bb05be-77e7-414a-b542-77889ce78f87', 81, CAST(N'2010-02-28' AS Date), CAST(0.731961 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce4b464f-efb6-47bd-879d-02978f3faae7', 81, CAST(N'2010-03-31' AS Date), CAST(0.736676 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3533823-5886-46de-9064-3e139d6a5041', 81, CAST(N'2010-04-30' AS Date), CAST(0.744027 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'189b171f-00b1-4c65-875d-632b0d6999ea', 81, CAST(N'2010-05-31' AS Date), CAST(0.792661 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4a3259d-5b42-4443-9cb4-8020367e5ad6', 81, CAST(N'2010-06-30' AS Date), CAST(0.818736 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d148e8d-1d99-42cd-bd29-19d8a42b9f34', 81, CAST(N'2010-07-31' AS Date), CAST(0.783177 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd231b9f5-1c62-40de-bfdc-24df329fc021', 81, CAST(N'2010-08-31' AS Date), CAST(0.774916 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c66f1041-3509-480c-b534-413ce57d06d1', 81, CAST(N'2010-09-30' AS Date), CAST(0.767110 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6cdffd66-46d7-4152-8ae0-fbf35dcc45ee', 81, CAST(N'2010-10-31' AS Date), CAST(0.719856 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2803bec-e4ba-4c3c-bc49-88b3b665013d', 81, CAST(N'2010-11-30' AS Date), CAST(0.731627 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c2885a4-5f87-4cc4-87da-8ed85a906679', 81, CAST(N'2010-12-31' AS Date), CAST(0.756788 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dffd865e-c0b1-4cf0-9cfa-575e3f695661', 81, CAST(N'2011-01-31' AS Date), CAST(0.749022 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dbb4fa9b-09a9-4d33-ba88-f44342daf98c', 81, CAST(N'2011-02-28' AS Date), CAST(0.732810 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'49269b9d-e2f8-490f-b167-94f2cca28639', 81, CAST(N'2011-03-31' AS Date), CAST(0.712842 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3fb58378-5e14-463e-be9a-2ac1d3647861', 81, CAST(N'2011-04-30' AS Date), CAST(0.692355 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'177988c4-069c-41ca-8d6a-7620f1085bc0', 81, CAST(N'2011-05-31' AS Date), CAST(0.697695 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'07d8387b-b0c6-46df-8ba3-4080fff1dbce', 81, CAST(N'2011-06-30' AS Date), CAST(0.695219 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a14a4ac-c886-4a0d-b30f-243ded247cb7', 81, CAST(N'2011-07-31' AS Date), CAST(0.698936 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'44aac78c-3194-4007-acce-4cec3086f14a', 81, CAST(N'2011-08-31' AS Date), CAST(0.697978 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e86b9967-e511-4837-8cb9-f2a687410ed4', 81, CAST(N'2011-09-30' AS Date), CAST(0.725028 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b023fff-1416-4d59-88f7-ec4aa4f043b8', 81, CAST(N'2011-10-31' AS Date), CAST(0.729200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b3d7aef-6586-4de2-89a5-6cedcb4efd7a', 81, CAST(N'2011-11-30' AS Date), CAST(0.736589 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4ff6ef9c-e354-4deb-9b30-f074cfcc149b', 81, CAST(N'2011-12-31' AS Date), CAST(0.759055 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3387ebf5-9354-403f-9daf-8157b82258b5', 81, CAST(N'2012-01-31' AS Date), CAST(0.775735 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ea6818bc-0b6e-4206-b999-7bbef43d2abf', 81, CAST(N'2012-02-29' AS Date), CAST(0.756182 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33c91299-9791-464b-b5dd-658a2d330aab', 81, CAST(N'2012-03-31' AS Date), CAST(0.756929 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce69e6b8-35ef-48ba-8e49-986bb2cfe118', 81, CAST(N'2012-04-30' AS Date), CAST(0.759198 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9a1ec8b0-d199-4c47-9bbe-7cdfe0574d97', 81, CAST(N'2012-05-31' AS Date), CAST(0.779815 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'83c5f835-258e-47ca-8706-197de594591b', 81, CAST(N'2012-06-30' AS Date), CAST(0.797569 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8e740bf-c932-4abf-afbc-c6ecdead91b9', 81, CAST(N'2012-07-31' AS Date), CAST(0.812808 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2151e66-8cd6-48d0-8b72-243d4a1a1e83', 81, CAST(N'2012-08-31' AS Date), CAST(0.807143 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38da049f-1af0-4851-8557-61beed1085dc', 81, CAST(N'2012-09-30' AS Date), CAST(0.777573 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'57aa35a0-90df-4cf9-92bb-75f21f7465cd', 81, CAST(N'2012-10-31' AS Date), CAST(0.770797 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'72252799-25a9-4b09-a73b-2e3f974c27cb', 81, CAST(N'2012-11-30' AS Date), CAST(0.779581 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'187eec9d-1bc4-4834-b928-537fec800a7c', 81, CAST(N'2012-12-31' AS Date), CAST(0.762971 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce84a578-5d01-484f-8bf4-6eba31732d55', 81, CAST(N'2013-01-31' AS Date), CAST(0.752760 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30039caf-b6a7-453e-824b-a3b6f0d5de36', 81, CAST(N'2013-02-28' AS Date), CAST(0.747541 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4196e90f-f5f4-482f-827e-08632d3b25e5', 81, CAST(N'2013-03-31' AS Date), CAST(0.771355 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1523283c-fb4f-4d2e-9073-1fac710188ab', 81, CAST(N'2013-04-30' AS Date), CAST(0.768128 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5e2ac233-9953-43f0-83e0-a298a5756145', 81, CAST(N'2013-05-31' AS Date), CAST(0.770194 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f2aa8f8-0a4f-44bb-a242-4e8cca68d431', 81, CAST(N'2013-06-30' AS Date), CAST(0.758813 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3df4b425-e186-41f8-a6bb-9ff1c0898301', 81, CAST(N'2013-07-31' AS Date), CAST(0.764949 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'70ca6a72-1f29-4d0b-ace2-ba2269a04aea', 81, CAST(N'2013-08-31' AS Date), CAST(0.750628 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'827695d9-eae2-4a0b-978e-384cda75151a', 81, CAST(N'2013-09-30' AS Date), CAST(0.749233 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'940d96a8-520a-4e65-b258-448e4f047b85', 81, CAST(N'2013-10-31' AS Date), CAST(0.733181 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8108b3b7-f1d7-4045-8c40-7019ed7afbef', 81, CAST(N'2013-11-30' AS Date), CAST(0.741217 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ba202b1b-3bb4-4d6c-87d8-863a001ee3c7', 81, CAST(N'2013-12-31' AS Date), CAST(0.729946 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a480c76e-13f6-41d9-8c45-e1ad93d29a2d', 81, CAST(N'2014-01-31' AS Date), CAST(0.733745 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd1a75d1e-fd24-4c5b-b5e3-888353bacb4e', 81, CAST(N'2014-02-28' AS Date), CAST(0.732758 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7f9f0c95-ae13-48eb-85fe-669e6a16c388', 81, CAST(N'2014-03-31' AS Date), CAST(0.723119 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e5dc3a4-8e50-4e93-b54a-aca49b58ce68', 81, CAST(N'2014-04-30' AS Date), CAST(0.724346 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ebe3888f-4583-46b9-a75e-a5a7789718aa', 81, CAST(N'2014-05-31' AS Date), CAST(0.727923 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1fcc8ea5-629c-424f-9ebd-b1411176c108', 81, CAST(N'2014-06-30' AS Date), CAST(0.735334 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f1e175bb-b032-40ee-9253-a108400aedc6', 81, CAST(N'2014-07-31' AS Date), CAST(0.738214 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91b18c59-175e-460e-96c7-1c6819d04507', 81, CAST(N'2014-08-31' AS Date), CAST(0.750279 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e491365a-2363-4d28-87eb-b637aec4aebd', 81, CAST(N'2014-09-30' AS Date), CAST(0.774853 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f0a4667-67d5-4590-b7e4-cf44e3fd542e', 81, CAST(N'2014-10-31' AS Date), CAST(0.789253 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'50858277-40c6-4b9e-8046-b8ef0337a0b8', 81, CAST(N'2014-11-30' AS Date), CAST(0.801646 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fefa37bc-42e3-46a5-b708-3bea3efd1f98', 81, CAST(N'2014-12-31' AS Date), CAST(0.811697 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'388b610c-404f-48da-a100-a465cc00e723', 81, CAST(N'2015-01-31' AS Date), CAST(0.861615 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0003df84-2a5c-4918-b41e-06b24c91708f', 81, CAST(N'2015-02-28' AS Date), CAST(0.881076 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'73f3b93e-ade2-4c37-a3a4-2c14c38a4c75', 81, CAST(N'2015-03-31' AS Date), CAST(0.923383 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'95b1ee8e-5376-4907-a176-be0d80842657', 81, CAST(N'2015-04-30' AS Date), CAST(0.925450 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a707a78c-89f0-41d3-843e-5f2ad68bd741', 81, CAST(N'2015-05-31' AS Date), CAST(0.895522 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65df056d-0a2e-404d-a51a-ad169a3f3a52', 81, CAST(N'2015-06-30' AS Date), CAST(0.891106 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5aa3cdbf-d8aa-4e2b-80e9-58e16bfe6af0', 81, CAST(N'2015-07-31' AS Date), CAST(0.908471 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f77e01f7-ff4e-44ba-9608-8a37f58a0fbf', 81, CAST(N'2015-08-31' AS Date), CAST(0.898781 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42353003-58e5-4489-8497-abbb7d69dfed', 81, CAST(N'2015-09-30' AS Date), CAST(0.889836 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed2572b9-4c08-497f-84ca-803c03684ecb', 81, CAST(N'2015-10-31' AS Date), CAST(0.890691 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2b57cd9d-3191-4c62-9aad-8d38ac9d985c', 81, CAST(N'2015-11-30' AS Date), CAST(0.931522 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'34914809-7614-4395-bdae-31c9446d3c27', 81, CAST(N'2015-12-31' AS Date), CAST(0.918070 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8c12f83-1ef1-4c81-874f-a5a5072d0fdd', 81, CAST(N'2016-01-31' AS Date), CAST(0.920897 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09fc2f52-8f62-449d-ac8b-68c218c11276', 81, CAST(N'2016-02-29' AS Date), CAST(0.900873 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd78af297-e0b8-4183-be21-7a4843f2a4b8', 81, CAST(N'2016-03-31' AS Date), CAST(0.899460 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c58d26c2-39c4-4a45-9cd2-c0771e821d85', 81, CAST(N'2016-04-30' AS Date), CAST(0.881880 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6f2a462-3364-4cd3-8267-47a6a64073c0', 81, CAST(N'2016-05-31' AS Date), CAST(0.884370 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b13e806a-a3d7-4238-8bf8-e9a15de93909', 81, CAST(N'2016-06-30' AS Date), CAST(0.889375 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'600e80e0-323e-4d9d-8946-c4cb3191feb7', 81, CAST(N'2016-07-31' AS Date), CAST(0.904111 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb2e12c3-1ad0-4fba-ab9c-246fba910aa5', 81, CAST(N'2016-08-31' AS Date), CAST(0.892620 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8244420-ac21-4928-add6-580de93867ad', 81, CAST(N'2016-09-30' AS Date), CAST(0.892636 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c375c29-de72-4b1e-8dda-43b010b8cb23', 81, CAST(N'2016-10-31' AS Date), CAST(0.906425 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f828afc-9682-4fb6-bb59-e09137495a87', 81, CAST(N'2016-11-30' AS Date), CAST(0.927460 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'300e164c-41ea-4385-b2ce-8010374cc8d4', 81, CAST(N'2016-12-31' AS Date), CAST(0.949012 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6e09104-13f1-4615-9215-3be8ff059439', 81, CAST(N'2017-01-31' AS Date), CAST(0.940876 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3431a321-2993-4b3b-83c3-e46d70b4761b', 81, CAST(N'2017-02-28' AS Date), CAST(0.939114 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e71e643-2261-457e-9c4f-b27a3111ae55', 81, CAST(N'2017-03-31' AS Date), CAST(0.935100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6b88c233-4f2d-480b-a645-69142515b667', 81, CAST(N'2017-04-30' AS Date), CAST(0.933910 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a566a241-a111-44af-8586-a2d468845c1b', 81, CAST(N'2017-05-31' AS Date), CAST(0.904193 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'72315614-8bc4-4161-8913-b2219d129427', 81, CAST(N'2017-06-30' AS Date), CAST(0.890534 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca236c14-dcd7-4a89-acdc-6a4d292bbde2', 81, CAST(N'2017-07-31' AS Date), CAST(0.867527 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d731702-f33f-4420-8b92-a6a92e185d9f', 81, CAST(N'2017-08-31' AS Date), CAST(0.846339 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1698335-7b3a-4ffd-9a44-369fa913c19f', 81, CAST(N'2017-09-30' AS Date), CAST(0.839493 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61d3110e-27b7-4881-b6c7-85150eeb8817', 81, CAST(N'2017-10-31' AS Date), CAST(0.851139 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ea022814-1310-4dda-a9f3-07f731f7f661', 81, CAST(N'2017-11-30' AS Date), CAST(0.851487 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9d324a79-bf8b-4642-b5b7-3548f5c52a8c', 81, CAST(N'2017-12-31' AS Date), CAST(0.844250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2cd822fd-b8c6-4d66-bf28-39dd78604f2c', 81, CAST(N'2018-01-31' AS Date), CAST(0.819901 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fdfeed5d-e14b-49c2-a285-7974f5e5ae64', 81, CAST(N'2018-02-28' AS Date), CAST(0.810022 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ab588a14-f97d-4dc4-ad59-81f6d37e55db', 81, CAST(N'2018-03-31' AS Date), CAST(0.811046 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c8d890e-9bb3-44e4-a1b6-e64fc753613d', 81, CAST(N'2018-04-30' AS Date), CAST(0.814554 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5361791f-a44d-45c7-a55f-fb34b2c5542c', 81, CAST(N'2018-05-31' AS Date), CAST(0.845653 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd071083c-a3cf-416c-9ec9-5f250aff38cc', 81, CAST(N'2018-06-30' AS Date), CAST(0.856183 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f23991c1-927a-4b14-8a5b-2a5caf51947f', 81, CAST(N'2018-07-31' AS Date), CAST(0.855282 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'95a98a9d-ccff-401b-afb1-eef353a1960c', 81, CAST(N'2018-08-31' AS Date), CAST(0.866686 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c4e43e3-41f5-49bd-9172-6257950d3f84', 81, CAST(N'2018-09-30' AS Date), CAST(0.857968 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'385bddb8-1ebc-430b-9c98-61f15f4524c4', 81, CAST(N'2018-10-31' AS Date), CAST(0.870075 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'26cb7eba-a229-4c4e-b4f2-06a44eeb4b54', 81, CAST(N'2018-11-30' AS Date), CAST(0.879906 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9708cc06-36c1-40f1-9661-88a4901b8c48', 81, CAST(N'2018-12-31' AS Date), CAST(0.879002 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'60870115-2f01-4ca1-ad40-1235af61a6ff', 81, CAST(N'2019-01-31' AS Date), CAST(0.875631 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'712685f0-1b3f-488b-bff9-5c372c3ff912', 81, CAST(N'2019-02-28' AS Date), CAST(0.880959 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'691f8b3e-7ef0-4555-baa0-57aaa825df7a', 81, CAST(N'2019-03-31' AS Date), CAST(0.885152 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12d548cb-1662-4cd1-aa19-a3d8e9c9a9fa', 81, CAST(N'2019-04-30' AS Date), CAST(0.890132 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3785492c-ccc2-445a-903b-11300e42679c', 81, CAST(N'2019-05-31' AS Date), CAST(0.893524 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'797a19cd-40b5-43d5-abbd-21885384861c', 81, CAST(N'2019-06-30' AS Date), CAST(0.884948 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4dc5947a-0d11-44b7-b7e5-e34de21d9838', 81, CAST(N'2019-07-31' AS Date), CAST(0.891499 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f36a2bde-17a0-437e-aa72-6fb9b1fe14f3', 81, CAST(N'2019-08-31' AS Date), CAST(0.897508 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4b04a117-4a44-4716-bbd2-0681d9b0e497', 81, CAST(N'2019-09-30' AS Date), CAST(0.907199 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c7bf9322-379f-4a31-8a9a-1a87f034cb38', 81, CAST(N'2019-10-31' AS Date), CAST(0.903815 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c7cdc592-af18-47a9-a2fc-9aa219103d87', 81, CAST(N'2019-11-30' AS Date), CAST(0.904806 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4add82b-ad9e-4ace-a5b5-3b52fe1a4718', 81, CAST(N'2019-12-31' AS Date), CAST(0.900067 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e5b3c6e7-7afe-4f03-bc8b-9851e55a9fe6', 81, CAST(N'2020-01-31' AS Date), CAST(0.901049 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7fa2931b-f39c-486c-bcaf-17bfae5ea665', 81, CAST(N'2020-02-29' AS Date), CAST(0.916057 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76f887af-61e0-4c63-8b8b-f8be798f0278', 109, CAST(N'1990-01-31' AS Date), CAST(144.981906 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c1e716e5-e1ff-41c8-a6c5-36c38d21cea4', 109, CAST(N'1990-02-28' AS Date), CAST(145.693157 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fc4fa990-16e2-4944-8ca5-130d97dedbbf', 109, CAST(N'1990-03-31' AS Date), CAST(153.308182 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4afa37d-6316-449e-9ecc-41c1fd7234d7', 109, CAST(N'1990-04-30' AS Date), CAST(158.458571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5bbd481-fe95-463a-9fcc-8ad1401c878b', 109, CAST(N'1990-05-31' AS Date), CAST(154.044092 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d878d0f-a35f-4793-afe2-e5b52bb4932e', 109, CAST(N'1990-06-30' AS Date), CAST(153.695714 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b96120b-e125-4c1c-a44a-51c535266ece', 109, CAST(N'1990-07-31' AS Date), CAST(149.039525 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'14608a86-e557-4b38-9937-1896eab7cc1d', 109, CAST(N'1990-08-31' AS Date), CAST(147.460870 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4e72b6ab-ff47-4c1c-8802-8fc3dbe5fb57', 109, CAST(N'1990-09-30' AS Date), CAST(138.440527 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b65e5ed5-2c43-4ee2-8ccb-133984a53b39', 109, CAST(N'1990-10-31' AS Date), CAST(129.590907 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'405d1613-8e3d-4654-9a62-e9f1ca63c4a7', 109, CAST(N'1990-11-30' AS Date), CAST(129.215500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce6955ef-bb24-4848-8388-049d0391490d', 109, CAST(N'1990-12-31' AS Date), CAST(133.889001 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'478aee51-5a52-4dab-bc6c-e7fcf8c88bcf', 109, CAST(N'1991-01-31' AS Date), CAST(133.698573 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ded32a73-bb57-453a-9d0f-212108f49076', 109, CAST(N'1991-02-28' AS Date), CAST(130.535791 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5883ce7b-be65-47a7-ba6d-fdab1371b71f', 109, CAST(N'1991-03-31' AS Date), CAST(137.386668 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a60dd5fa-278d-4c2b-b3ec-3b6058db1d67', 109, CAST(N'1991-04-30' AS Date), CAST(137.112728 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c19e7ad9-3e7d-41b1-88ad-5d58d9a05f25', 109, CAST(N'1991-05-31' AS Date), CAST(138.221820 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'67bd76df-1188-42f4-8d67-4991b58b506b', 109, CAST(N'1991-06-30' AS Date), CAST(139.747498 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8acae5e1-2e2f-49a6-bd57-d67e78ca3578', 109, CAST(N'1991-07-31' AS Date), CAST(137.829998 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed042700-ef09-44a1-956f-67e19ccd6b15', 109, CAST(N'1991-08-31' AS Date), CAST(136.816364 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'92029a02-7755-457e-b0b5-544b7f42dcf8', 109, CAST(N'1991-09-30' AS Date), CAST(134.299500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76514b0c-5147-45de-bc54-9a2bc3fbbade', 109, CAST(N'1991-10-31' AS Date), CAST(130.772273 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9a9379e3-4078-41bf-a2c0-02fcca4b5d39', 109, CAST(N'1991-11-30' AS Date), CAST(129.632105 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ac56c330-ee39-46e8-824d-19607e54d375', 109, CAST(N'1991-12-31' AS Date), CAST(128.039524 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'69a2ddeb-7757-4672-8c03-2532b2164d08', 109, CAST(N'1992-01-31' AS Date), CAST(125.461428 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f31c1edc-a236-4f64-91ad-4bbdd5895743', 109, CAST(N'1992-02-29' AS Date), CAST(127.698946 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3ce73789-33a0-4e50-8fbd-353f2e692716', 109, CAST(N'1992-03-31' AS Date), CAST(132.862728 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8b3c47d6-51f7-47b1-b731-d6bb7097ad54', 109, CAST(N'1992-04-30' AS Date), CAST(133.539544 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd61bc925-3c20-42c8-95b1-030dbd486c04', 109, CAST(N'1992-05-31' AS Date), CAST(130.771000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd61527b0-b63e-49f8-ade3-9d55ffd9a748', 109, CAST(N'1992-06-30' AS Date), CAST(126.835455 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad9e4fee-0008-4b35-be4a-9d1c7006b34b', 109, CAST(N'1992-07-31' AS Date), CAST(125.881739 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e9348d9d-e91a-4adf-9112-fad14b8b4408', 109, CAST(N'1992-08-31' AS Date), CAST(126.230952 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d9aff70-102e-4dc8-ad73-3d2493e4be9e', 109, CAST(N'1992-09-30' AS Date), CAST(122.596667 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8461fcd3-8e8d-4909-83b9-8ff52a6b4408', 109, CAST(N'1992-10-31' AS Date), CAST(121.165238 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'506df1ea-51d7-422e-810f-67061521206f', 109, CAST(N'1992-11-30' AS Date), CAST(123.880000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9aacb790-8b61-4ce3-9951-849f6268af6c', 109, CAST(N'1992-12-31' AS Date), CAST(124.040909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9fb0d674-9711-4e14-9155-ce34332b21d2', 109, CAST(N'1993-01-31' AS Date), CAST(124.993158 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b1fb897b-c155-4c9b-80e3-b1e4ea91f8b7', 109, CAST(N'1993-02-28' AS Date), CAST(120.759474 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dbc03a82-db89-410e-a965-e1b6e208f65c', 109, CAST(N'1993-03-31' AS Date), CAST(117.017391 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4a4fe5a4-672c-4346-a127-d34ab1fdc309', 109, CAST(N'1993-04-30' AS Date), CAST(112.411364 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e7707c08-12c5-4236-b137-58c1eb29135c', 109, CAST(N'1993-05-31' AS Date), CAST(110.343000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1999549c-af87-405f-8d02-94ac1fd0bbb1', 109, CAST(N'1993-06-30' AS Date), CAST(107.411818 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'28be09c7-94e0-43bd-9858-af570b2bb2ce', 109, CAST(N'1993-07-31' AS Date), CAST(107.691429 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'45d35545-244f-4844-a111-a8c6f08a626b', 109, CAST(N'1993-08-31' AS Date), CAST(103.765000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'51cdb70f-83ba-4393-b941-95462eaa5bfc', 109, CAST(N'1993-09-30' AS Date), CAST(105.574762 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'377c4859-64f7-4ab2-8bcc-c34abf06d460', 109, CAST(N'1993-10-31' AS Date), CAST(107.020000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2d19c17-4894-4591-935c-2d92a1b25e8a', 109, CAST(N'1993-11-30' AS Date), CAST(107.876500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'677ec270-6afb-412d-afc2-e0dca3534cb4', 109, CAST(N'1993-12-31' AS Date), CAST(109.913043 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff2aa317-49c7-46d9-8004-5ab4934a03fe', 109, CAST(N'1994-01-31' AS Date), CAST(111.441500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e251bf09-5172-4656-abff-d3916d5b1e93', 109, CAST(N'1994-02-28' AS Date), CAST(106.301053 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da55ba33-87ad-4b1e-b87f-c8c20330caaa', 109, CAST(N'1994-03-31' AS Date), CAST(105.097391 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'418de0ea-9dc1-499d-a2aa-4d947def14d2', 109, CAST(N'1994-04-30' AS Date), CAST(103.484286 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17d880da-3886-4055-8f97-45740c395d1b', 109, CAST(N'1994-05-31' AS Date), CAST(103.753333 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c1df64de-2d0d-4763-88ea-6359cc3e4bbc', 109, CAST(N'1994-06-30' AS Date), CAST(102.526364 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce8855cc-517a-4d97-b742-3655fb08e65d', 109, CAST(N'1994-07-31' AS Date), CAST(98.445001 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bae27889-0177-4b45-9282-13386ec35244', 109, CAST(N'1994-08-31' AS Date), CAST(99.940435 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'62a8487c-cd67-4a6c-b829-50d607c64ed0', 109, CAST(N'1994-09-30' AS Date), CAST(98.774285 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e28e89bc-bff5-4156-bd42-9439773cbe06', 109, CAST(N'1994-10-31' AS Date), CAST(98.353000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b32323b-b4c6-402a-a1b3-c27a486b9719', 109, CAST(N'1994-11-30' AS Date), CAST(98.044000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1099127a-ff75-4756-9f06-96eb6e2f28d0', 109, CAST(N'1994-12-31' AS Date), CAST(100.182381 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6b6a0cbc-32be-4767-b4aa-f48072540165', 109, CAST(N'1995-01-31' AS Date), CAST(99.766000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b83c1b88-c469-4207-a0ba-f5e46ce0adab', 109, CAST(N'1995-02-28' AS Date), CAST(98.236843 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'de53c79b-e576-4631-b52f-dad1e3f78971', 109, CAST(N'1995-03-31' AS Date), CAST(90.519565 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c92918e4-6abc-4d24-b9ab-2d499307d188', 109, CAST(N'1995-04-30' AS Date), CAST(83.689500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ed9e50c-5109-4a8f-8dc1-b3f9f23be742', 109, CAST(N'1995-05-31' AS Date), CAST(85.112727 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5410a9f-d7c6-4243-ba7b-46a4228eb7e1', 109, CAST(N'1995-06-30' AS Date), CAST(84.635454 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2a3e2350-86e5-4e80-b56e-08128d7c07e2', 109, CAST(N'1995-07-31' AS Date), CAST(87.397000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30184f39-40df-4e8d-aff9-a7305a7d62e6', 109, CAST(N'1995-08-31' AS Date), CAST(94.738261 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'34bbf5cb-9979-4469-8d99-4ed802781324', 109, CAST(N'1995-09-30' AS Date), CAST(100.545500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3294a577-e283-4900-a867-9c0cf6c1b23a', 109, CAST(N'1995-10-31' AS Date), CAST(100.839047 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fe98a170-ee80-4d22-9293-b3097c44a6cd', 109, CAST(N'1995-11-30' AS Date), CAST(101.940000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f37f3e2-9abd-4b9a-987e-e3ab09232de9', 109, CAST(N'1995-12-31' AS Date), CAST(101.849500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd7bfc253-faf9-4c05-bc3a-08fcf919f9ea', 109, CAST(N'1996-01-31' AS Date), CAST(105.751429 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'04f78b45-0f14-4ddd-ba2f-d401bfc35f90', 109, CAST(N'1996-02-29' AS Date), CAST(105.788000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'83fc7e81-01fe-47c3-b95d-ac8498df3d51', 109, CAST(N'1996-03-31' AS Date), CAST(105.940000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8e677900-3711-4a91-b71e-231bc09c66f9', 109, CAST(N'1996-04-30' AS Date), CAST(107.199545 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9991d4a5-4004-4e4f-b774-764eb086029e', 109, CAST(N'1996-05-31' AS Date), CAST(106.342273 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b998b446-bc6e-496f-8dcb-e93fd68c52b6', 109, CAST(N'1996-06-30' AS Date), CAST(108.960000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7001f70e-c393-4966-a210-626720941fea', 109, CAST(N'1996-07-31' AS Date), CAST(109.190909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a82ec149-7606-4fb4-8655-e8290ad7a044', 109, CAST(N'1996-08-31' AS Date), CAST(107.865909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1dd2ab2d-d59c-4f80-b04e-dbb7c52fe40d', 109, CAST(N'1996-09-30' AS Date), CAST(109.931000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd51c827c-7251-4843-996b-3bcb6fae11a9', 109, CAST(N'1996-10-31' AS Date), CAST(112.412273 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9d35ebfc-8694-4ff2-9b30-970851114c63', 109, CAST(N'1996-11-30' AS Date), CAST(112.295789 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ba9115c5-ef11-4c26-91c2-e14697e83416', 109, CAST(N'1996-12-31' AS Date), CAST(113.980952 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7d28cd9d-9522-484e-86c9-fcc3af36099e', 109, CAST(N'1997-01-31' AS Date), CAST(117.912381 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4a53e624-6e84-4285-b445-7df5a84f93fc', 109, CAST(N'1997-02-28' AS Date), CAST(122.962105 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad77459f-1a14-4d53-9959-0fe684f90bee', 109, CAST(N'1997-03-31' AS Date), CAST(122.773810 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'493e4dcc-3eeb-4be5-9a4a-dffba4df69d8', 109, CAST(N'1997-04-30' AS Date), CAST(125.637727 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48907203-df0b-4e96-ad55-b3354018cf26', 109, CAST(N'1997-05-31' AS Date), CAST(119.192381 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e750ee11-1a28-4e65-9183-21df9f53ec33', 109, CAST(N'1997-06-30' AS Date), CAST(114.285714 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c112124-320c-421a-b2e8-b3b3e5e5a289', 109, CAST(N'1997-07-31' AS Date), CAST(115.375909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'950fce64-d1e9-429d-a6da-c85f83a7f78a', 109, CAST(N'1997-08-31' AS Date), CAST(117.929524 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'499c0952-5a8e-4b13-981c-b910ff57a771', 109, CAST(N'1997-09-30' AS Date), CAST(120.890000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e35a71f0-019d-48ee-9e1a-f6d81ae36394', 109, CAST(N'1997-10-31' AS Date), CAST(121.060455 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'47fa5771-6540-4497-9ded-11975e3b3597', 109, CAST(N'1997-11-30' AS Date), CAST(125.381667 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f97a48dd-f8d8-4cc5-99b8-f6fdbec6607f', 109, CAST(N'1997-12-31' AS Date), CAST(129.734090 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a02ddfd4-41c4-4b54-ba48-a073244150d1', 109, CAST(N'1998-01-31' AS Date), CAST(129.547500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'649a8d2c-8882-4c5f-af8e-a6b24e41eba4', 109, CAST(N'1998-02-28' AS Date), CAST(125.851578 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad93103a-0be4-4adb-83fe-202b4f7022c3', 109, CAST(N'1998-03-31' AS Date), CAST(129.082271 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'26505097-e78b-4683-9c9b-239481326913', 109, CAST(N'1998-04-30' AS Date), CAST(131.753637 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5a5b53e-0296-47a6-8cd8-1dfd3c420c0b', 109, CAST(N'1998-05-31' AS Date), CAST(134.896000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4cd27ebf-11ed-48a4-b1cd-13a54693ce5b', 109, CAST(N'1998-06-30' AS Date), CAST(140.330453 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8facf813-2ef8-4dcf-869f-32a112578233', 109, CAST(N'1998-07-31' AS Date), CAST(140.787392 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2a24b359-ce05-496d-9e8e-f8d1cd3efff0', 109, CAST(N'1998-08-31' AS Date), CAST(144.680000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02208c98-0e16-479f-8489-8f3f59885402', 109, CAST(N'1998-09-30' AS Date), CAST(134.480477 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43c0e69a-8263-449c-8720-b71fb79be064', 109, CAST(N'1998-10-31' AS Date), CAST(121.048571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75313547-90d5-48d5-a7f2-09a5553fed0d', 109, CAST(N'1998-11-30' AS Date), CAST(120.289474 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'547be126-86e7-4a82-a9ad-da24a349a2ab', 109, CAST(N'1998-12-31' AS Date), CAST(117.070909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21235096-aae3-4cde-9a64-4d9762c4fd6b', 109, CAST(N'1999-01-31' AS Date), CAST(113.333307 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0c62b0c-7eae-417d-9f0b-93379d20f46e', 109, CAST(N'1999-02-28' AS Date), CAST(116.611292 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f0bb2a5f-7d47-407b-8ee2-291098218092', 109, CAST(N'1999-03-31' AS Date), CAST(119.469262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'019bfd26-83c0-4a03-9d1c-f03ef2563595', 109, CAST(N'1999-04-30' AS Date), CAST(119.738364 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd6ccc659-6f1c-4843-a1a7-be99623087be', 109, CAST(N'1999-05-31' AS Date), CAST(121.891484 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0bf2db14-21a9-45cb-a71b-41b23260bd61', 109, CAST(N'1999-06-30' AS Date), CAST(120.731178 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eacbb32f-e778-4c59-bfdb-397774adc74a', 109, CAST(N'1999-07-31' AS Date), CAST(119.377692 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4348b9a4-6e76-4add-83b3-e45bf6c224b9', 109, CAST(N'1999-08-31' AS Date), CAST(113.171411 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33bb2724-d29c-4877-be9e-a9120e7cb424', 109, CAST(N'1999-09-30' AS Date), CAST(106.875172 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9bc83441-bc53-419a-a7d0-034919241fc9', 109, CAST(N'1999-10-31' AS Date), CAST(105.954656 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0905ea5d-850f-4cd3-a7d8-2bb8f6c22233', 109, CAST(N'1999-11-30' AS Date), CAST(104.638220 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ed19b64-7362-40f7-879f-718de16c73a5', 109, CAST(N'1999-12-31' AS Date), CAST(102.606213 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7951488-eee3-455a-b148-4f18cddff2e6', 109, CAST(N'2000-01-31' AS Date), CAST(105.449391 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'725019c0-dc57-4530-9c42-22e4083aef04', 109, CAST(N'2000-02-29' AS Date), CAST(109.459310 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a02afb22-6904-476b-8773-536c360436a4', 109, CAST(N'2000-03-31' AS Date), CAST(106.531621 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8110733c-f3b8-4949-a25f-a59108263ff4', 109, CAST(N'2000-04-30' AS Date), CAST(105.341270 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4667e13-837c-40a9-9461-25a7b6da3849', 109, CAST(N'2000-05-31' AS Date), CAST(108.118580 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fc4fa187-6d16-4ea2-b9f6-42e2a7b2a546', 109, CAST(N'2000-06-30' AS Date), CAST(106.156242 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'970b71e9-59f2-4c9f-8a70-1b0386d4c989', 109, CAST(N'2000-07-31' AS Date), CAST(107.908646 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e2a43c92-aa18-41c6-8888-15abc3c04174', 109, CAST(N'2000-08-31' AS Date), CAST(108.020080 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6cb67797-bd8a-48a8-93df-20244420b166', 109, CAST(N'2000-09-30' AS Date), CAST(106.794484 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33ba3750-1eba-4694-9515-f8d3bdd0ff95', 109, CAST(N'2000-10-31' AS Date), CAST(108.397960 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4bf535c4-dd75-45aa-91f0-1e3332109daa', 109, CAST(N'2000-11-30' AS Date), CAST(109.000995 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8210f4b2-1beb-4fbf-bcb7-2282699aacba', 109, CAST(N'2000-12-31' AS Date), CAST(112.228462 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91355f87-911f-4f8c-ad49-a03e37c50378', 109, CAST(N'2001-01-31' AS Date), CAST(116.726210 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'450c6043-6153-4582-a16f-c5ec203e7e3c', 109, CAST(N'2001-02-28' AS Date), CAST(116.177164 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'333f25dd-b94e-44a8-b9ae-735367f79dd9', 109, CAST(N'2001-03-31' AS Date), CAST(121.386808 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21206dcd-4bba-4d9d-b37a-733269ca23df', 109, CAST(N'2001-04-30' AS Date), CAST(123.685500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fee74491-adda-4142-9077-86e0de702280', 109, CAST(N'2001-05-31' AS Date), CAST(121.877000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e7ce4cef-2c80-4b87-9c41-0a25df88f438', 109, CAST(N'2001-06-30' AS Date), CAST(122.101700 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd19ff372-d2e3-4b64-b7c2-a6c600fa645b', 109, CAST(N'2001-07-31' AS Date), CAST(124.515410 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8f31904-62c1-4f73-828f-03069eea5d9d', 109, CAST(N'2001-08-31' AS Date), CAST(121.606461 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e145f7c6-831f-40cc-be0d-12d8e42f7be3', 109, CAST(N'2001-09-30' AS Date), CAST(118.661279 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd36f0802-5304-4298-870f-fe404a1dc60b', 109, CAST(N'2001-10-31' AS Date), CAST(121.237817 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8eab5643-a639-4750-b787-ae190ef55eca', 109, CAST(N'2001-11-30' AS Date), CAST(122.453435 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7f98bfd5-6f17-4932-b63e-2d368f39d43b', 109, CAST(N'2001-12-31' AS Date), CAST(127.182000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4db8cf40-dedb-42c7-8601-4055e5dcc983', 109, CAST(N'2002-01-31' AS Date), CAST(132.626590 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f1dc747-b10c-4c6d-9bbe-ad0ed79fbf3a', 109, CAST(N'2002-02-28' AS Date), CAST(133.512249 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'351aaf1b-4cc4-4cb0-8ee3-88d0b3b333d6', 109, CAST(N'2002-03-31' AS Date), CAST(131.317000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21e09fdd-cbda-4100-8633-7b84bbf4184d', 109, CAST(N'2002-04-30' AS Date), CAST(131.016818 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c07b828e-167f-48b3-9760-4557f971438e', 109, CAST(N'2002-05-31' AS Date), CAST(126.540217 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'03f3a0be-0c99-44e0-b619-6448374b3623', 109, CAST(N'2002-06-30' AS Date), CAST(123.510001 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c50e1f5b-cc93-4762-a921-c9a8035c2b8f', 109, CAST(N'2002-07-31' AS Date), CAST(117.965250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ce67688-e0bd-4cc4-bc05-b47537138f3a', 109, CAST(N'2002-08-31' AS Date), CAST(119.083864 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4346af1-5347-4414-adc6-f760b8e91e37', 109, CAST(N'2002-09-30' AS Date), CAST(120.832500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd86bc04d-d7f6-4d94-a47d-5001b9029016', 109, CAST(N'2002-10-31' AS Date), CAST(123.809545 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9c5deb5-5548-4c83-9aa0-b9b065b59474', 109, CAST(N'2002-11-30' AS Date), CAST(121.467368 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7f660a39-3627-43a6-804d-344e046ca7ca', 109, CAST(N'2002-12-31' AS Date), CAST(122.244000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fdf72012-b1b3-47b4-ad12-25936bf49b21', 109, CAST(N'2003-01-31' AS Date), CAST(118.891111 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd6d47818-ad6b-4fcd-a3bf-b1f7299ca4e1', 109, CAST(N'2003-02-28' AS Date), CAST(119.462500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6f86ecb-68e4-4169-a3ca-e17af4670a63', 109, CAST(N'2003-03-31' AS Date), CAST(118.719032 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'20343f1c-2def-4b48-aff1-03144eb7db05', 109, CAST(N'2003-04-30' AS Date), CAST(119.807333 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f9eb2446-9a0d-4969-ba79-6a4b74c0b3af', 109, CAST(N'2003-05-31' AS Date), CAST(117.357903 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0a87d7b2-77ac-4352-940d-4d37bc271b42', 109, CAST(N'2003-06-30' AS Date), CAST(118.340667 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f93e5b2-4ce7-44da-bd1a-0f786babba5f', 109, CAST(N'2003-07-31' AS Date), CAST(118.574194 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2da349c-5b0b-41de-ad76-f56bce7a530c', 109, CAST(N'2003-08-31' AS Date), CAST(118.806290 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'986ac089-d088-4fc3-a8cc-97a0cab1c9ce', 109, CAST(N'2003-09-30' AS Date), CAST(115.140500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f1dcee1e-5d7e-4455-a093-06b6eb4527d1', 109, CAST(N'2003-10-31' AS Date), CAST(109.509516 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c6b5cf1-2916-4fc7-a5e9-48cc7630f4a4', 109, CAST(N'2003-11-30' AS Date), CAST(109.137833 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'39740253-3499-445b-b614-ccdb7d11358b', 109, CAST(N'2003-12-31' AS Date), CAST(107.866774 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8d02d43-7095-42c7-83e2-9abc727f4cbd', 109, CAST(N'2004-01-31' AS Date), CAST(106.398226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'795d8874-0d56-47db-8e2b-51c3b71f7ae0', 109, CAST(N'2004-02-29' AS Date), CAST(106.603103 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6b8f1046-a473-45d9-a44e-abd72ca07d96', 109, CAST(N'2004-03-31' AS Date), CAST(108.767903 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'473ccdc0-cacc-4a75-95fe-2b23288b9b08', 109, CAST(N'2004-04-30' AS Date), CAST(107.214833 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08350c14-67af-4cc7-a8c8-c62b4e6f8f49', 109, CAST(N'2004-05-31' AS Date), CAST(111.965000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fcfff3bb-f38a-4520-ab28-38a0ab7ca27f', 109, CAST(N'2004-06-30' AS Date), CAST(109.379334 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2a97a6d-8e03-448b-bcfb-58a379509ca6', 109, CAST(N'2004-07-31' AS Date), CAST(109.397097 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3a57f235-044c-4e2a-bbe0-98a6bef0a9a0', 109, CAST(N'2004-08-31' AS Date), CAST(110.415968 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b3130bfc-3f11-4b3b-a9cb-1b045275838d', 109, CAST(N'2004-09-30' AS Date), CAST(109.616712 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e50d6d01-5776-4b4b-9487-65be703ce071', 109, CAST(N'2004-10-31' AS Date), CAST(108.967581 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42a0b47a-a4c4-43d5-a88d-14b5afcb0b82', 109, CAST(N'2004-11-30' AS Date), CAST(104.873833 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3e4b25bc-7a3e-4601-93d6-497bcdb9261e', 109, CAST(N'2004-12-31' AS Date), CAST(103.587886 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fc909234-d905-45f3-83d1-02a103bef315', 109, CAST(N'2005-01-31' AS Date), CAST(102.284629 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'446e0ecb-bdff-4e52-80bf-ae401c83f8f5', 109, CAST(N'2005-02-28' AS Date), CAST(105.023214 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13b515fb-145a-44e7-bef3-f6bb582a47b1', 109, CAST(N'2005-03-31' AS Date), CAST(105.145969 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3e7e5a7e-0a95-4f3a-90ea-de1811855100', 109, CAST(N'2005-04-30' AS Date), CAST(107.241833 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b7ee9d20-5abd-425e-85a4-58aae8fd1cf4', 109, CAST(N'2005-05-31' AS Date), CAST(106.610161 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae00582f-467c-4baa-827f-cabe79ab0618', 109, CAST(N'2005-06-30' AS Date), CAST(108.609834 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'89d4bc51-a758-4dda-bc3e-3e24ce4485dc', 109, CAST(N'2005-07-31' AS Date), CAST(111.948387 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0a2f7cb9-288a-4145-a507-6b975a488ea0', 109, CAST(N'2005-08-31' AS Date), CAST(110.590081 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef9847f6-da3a-491f-8732-9b7fce9f75f4', 109, CAST(N'2005-09-30' AS Date), CAST(110.964500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd663b3e3-8577-497a-b0b3-0986286d2527', 109, CAST(N'2005-10-31' AS Date), CAST(114.694355 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd26fd9fa-af81-490f-92a0-5fc32d3e120b', 109, CAST(N'2005-11-30' AS Date), CAST(118.404500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af71005a-a291-4922-a8f1-b7b507d61415', 109, CAST(N'2005-12-31' AS Date), CAST(118.388984 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2efda836-a457-4b4c-9727-035020e1777a', 109, CAST(N'2006-01-31' AS Date), CAST(115.663711 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3954f021-3cc8-4f8d-8b20-d7d5ff10ae57', 109, CAST(N'2006-02-28' AS Date), CAST(117.970129 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'929af23c-401a-46f1-a702-cf9dd6a443de', 109, CAST(N'2006-03-31' AS Date), CAST(117.198144 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2b64ceb8-66f6-420a-aeeb-7e4f88008b82', 109, CAST(N'2006-04-30' AS Date), CAST(117.097109 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84b0fb34-6e07-48dc-b06e-f541744d79c3', 109, CAST(N'2006-05-31' AS Date), CAST(111.760081 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1a0698c-d128-4a39-a2d3-1933810ccba4', 109, CAST(N'2006-06-30' AS Date), CAST(114.495933 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'187e7256-f55c-4f5f-b0f5-4818b2d509a6', 109, CAST(N'2006-07-31' AS Date), CAST(115.610645 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9257e11c-757f-46bf-bd97-76be09a7d7a5', 109, CAST(N'2006-08-31' AS Date), CAST(115.894979 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b902e1d9-2e12-408f-b692-ca91c15eba75', 109, CAST(N'2006-09-30' AS Date), CAST(117.102061 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fb5a1bba-92b3-46ad-ac27-1bc61835b26a', 109, CAST(N'2006-10-31' AS Date), CAST(118.651356 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eda60ca2-5382-467e-9f03-6ff014a65e78', 109, CAST(N'2006-11-30' AS Date), CAST(117.288497 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61a03b6a-114e-4cca-9a25-233cfb1f02a3', 109, CAST(N'2006-12-31' AS Date), CAST(117.310134 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'92021f83-6544-4c58-a381-46863d544b8c', 109, CAST(N'2007-01-31' AS Date), CAST(120.299194 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'daee586e-16dc-415e-a37a-41a22e81166e', 109, CAST(N'2007-02-28' AS Date), CAST(120.678893 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c221e10b-b3bc-465f-95d3-6de36580e04f', 109, CAST(N'2007-03-31' AS Date), CAST(117.326179 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'033c0e7a-55c8-4082-a967-b4f5f236d472', 109, CAST(N'2007-04-30' AS Date), CAST(118.845445 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c2298f5-f73b-4561-8715-4899497206c8', 109, CAST(N'2007-05-31' AS Date), CAST(120.789145 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e191e331-c534-4127-b2c3-2975fe08b179', 109, CAST(N'2007-06-30' AS Date), CAST(122.615557 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a58003ca-42d7-4636-8e74-79cd10e05437', 109, CAST(N'2007-07-31' AS Date), CAST(121.667386 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'349f75f2-4460-4ce3-8cd6-02935e79440b', 109, CAST(N'2007-08-31' AS Date), CAST(116.748605 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7eb7a2cd-75b2-4b22-88db-b76dd99ac923', 109, CAST(N'2007-09-30' AS Date), CAST(115.192167 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c734e38c-aa2f-4099-b4ef-36d89e8bd2d7', 109, CAST(N'2007-10-31' AS Date), CAST(115.875323 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91bc96d4-e0a8-4c99-8107-1ab0e2d15132', 109, CAST(N'2007-11-30' AS Date), CAST(111.308833 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e2e517e3-8d05-4601-9644-380b2f9a2ea5', 109, CAST(N'2007-12-31' AS Date), CAST(112.295484 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7d5ce05-48d6-4320-b832-32e250e04dd4', 109, CAST(N'2008-01-31' AS Date), CAST(108.137742 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'145cde01-2f03-4465-adb6-5bc09d22aad2', 109, CAST(N'2008-02-29' AS Date), CAST(107.214483 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2d712f6-99f4-4009-be51-39036f36ab06', 109, CAST(N'2008-03-31' AS Date), CAST(101.142419 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3bdb0e66-06d3-4b17-ad7b-c41c879681db', 109, CAST(N'2008-04-30' AS Date), CAST(102.459787 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a0903eeb-068c-4b5d-b2b4-ed13da2f3e18', 109, CAST(N'2008-05-31' AS Date), CAST(104.367387 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'80676ab0-df5c-46a2-a710-90d3138b0b06', 109, CAST(N'2008-06-30' AS Date), CAST(106.913611 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c8a5026-e598-48a8-8330-6e62a09a724b', 109, CAST(N'2008-07-31' AS Date), CAST(106.830704 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8805111-95d3-428e-b13e-373fca66a91b', 109, CAST(N'2008-08-31' AS Date), CAST(109.195332 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'70209b5d-2650-4d57-8123-bf8512c752ab', 109, CAST(N'2008-09-30' AS Date), CAST(106.626503 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b9de8685-8abf-4b83-af71-7526c75daa95', 109, CAST(N'2008-10-31' AS Date), CAST(100.983839 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ac6c41d-7276-4e88-8d23-e66001b7aaa3', 109, CAST(N'2008-11-30' AS Date), CAST(96.924478 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'98ea1032-e83b-4cdb-af4f-514d96d4292f', 109, CAST(N'2008-12-31' AS Date), CAST(91.357823 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01b33e12-4e13-402d-81b9-f90251fd9a1f', 109, CAST(N'2009-01-31' AS Date), CAST(90.234010 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bda16cc8-17c6-4e88-bc60-1a24db45a5f6', 109, CAST(N'2009-02-28' AS Date), CAST(92.565804 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'66749b0a-c463-4120-933d-1c54ce7583b3', 109, CAST(N'2009-03-31' AS Date), CAST(97.601080 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fdcd08b2-b517-448a-9b85-d575c49840a5', 109, CAST(N'2009-04-30' AS Date), CAST(99.037827 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'483808bc-9a2e-4d21-aed9-8546a82d02b1', 109, CAST(N'2009-05-31' AS Date), CAST(96.756631 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ef4f6e2-0439-4389-9888-f82d05d665ff', 109, CAST(N'2009-06-30' AS Date), CAST(96.602805 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ac3fca7d-daa7-460d-8d86-2e9bd92cd6cd', 109, CAST(N'2009-07-31' AS Date), CAST(94.421557 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bd298a28-c45d-4a96-911b-94e8b641e7ea', 109, CAST(N'2009-08-31' AS Date), CAST(94.904952 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed8c8746-aaf0-4f8f-b5d9-cb14a42c6194', 109, CAST(N'2009-09-30' AS Date), CAST(91.439650 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e215dcab-b132-464c-abef-d40e3b95c430', 109, CAST(N'2009-10-31' AS Date), CAST(90.381500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'54297463-e1e2-4df9-ad12-b252e095a2e4', 109, CAST(N'2009-11-30' AS Date), CAST(89.219067 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e5c9f9a-7f6e-4009-a236-c108223e653e', 109, CAST(N'2009-12-31' AS Date), CAST(89.863177 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b8996cac-54be-44b1-8d5b-8309b46c5633', 109, CAST(N'2010-01-31' AS Date), CAST(91.328065 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a4a62461-112a-46c0-a375-859e37d84aa5', 109, CAST(N'2010-02-28' AS Date), CAST(90.144643 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4b486e3a-8353-4a88-8950-d939370a4a4e', 109, CAST(N'2010-03-31' AS Date), CAST(90.625065 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'acdc05b7-70b4-45e5-9363-377cdbaeca9d', 109, CAST(N'2010-04-30' AS Date), CAST(93.481167 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'adf63443-2a68-4799-ad7e-40c10ea58572', 109, CAST(N'2010-05-31' AS Date), CAST(92.024161 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'98d75dfb-14de-423b-b0de-9ad8f172e710', 109, CAST(N'2010-06-30' AS Date), CAST(90.931533 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38b9bedf-f195-440d-b02a-61a835d897c8', 109, CAST(N'2010-07-31' AS Date), CAST(87.593839 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f3cddf44-c587-4552-8ee1-ccb5933b8f10', 109, CAST(N'2010-08-31' AS Date), CAST(85.577161 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d34abd9-1ebf-431e-b855-eb2614848766', 109, CAST(N'2010-09-30' AS Date), CAST(84.470833 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8c44266-ecb3-4d83-a99e-e14c17776673', 109, CAST(N'2010-10-31' AS Date), CAST(81.860000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'93322a21-cfb1-4372-afb3-3f2a4b521e83', 109, CAST(N'2010-11-30' AS Date), CAST(82.545867 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a23f4c09-71b2-4d55-b74c-7ef168678bf0', 109, CAST(N'2010-12-31' AS Date), CAST(83.334052 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46befc82-9454-42db-b8a2-6fc3f4265b3d', 109, CAST(N'2011-01-31' AS Date), CAST(82.540387 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4e6577a-43a5-4470-aad7-37aaab9555d4', 109, CAST(N'2011-02-28' AS Date), CAST(82.599571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cb4b9e66-f020-4766-b696-5f469fb7ec7c', 109, CAST(N'2011-03-31' AS Date), CAST(81.566586 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a2752589-c9e7-4934-bb5b-1d4388fe0bc9', 109, CAST(N'2011-04-30' AS Date), CAST(83.212233 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1815ae36-b0b6-4f82-8c16-f6a636c1a62a', 109, CAST(N'2011-05-31' AS Date), CAST(81.067645 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30033468-f312-4442-bcd0-3cc7605abbe4', 109, CAST(N'2011-06-30' AS Date), CAST(80.450967 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'03f18119-fd68-4daa-958c-2b5a3167adf1', 109, CAST(N'2011-07-31' AS Date), CAST(79.394258 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4e532f01-e1b3-4988-9819-e422dba42bbc', 109, CAST(N'2011-08-31' AS Date), CAST(77.074050 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'40129b1a-b884-454c-9ea2-93f25eb9ca70', 109, CAST(N'2011-09-30' AS Date), CAST(76.794167 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f95fee3-fa25-4881-8bb6-864e1612c720', 109, CAST(N'2011-10-31' AS Date), CAST(76.595385 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd566578a-332f-46fe-9db5-ee8226455712', 109, CAST(N'2011-11-30' AS Date), CAST(77.587923 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5702d46a-20ed-427a-8dd9-dfed7ceb3546', 109, CAST(N'2011-12-31' AS Date), CAST(77.794034 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eeef31e7-0549-48db-a07b-9d623f5a250a', 109, CAST(N'2012-01-31' AS Date), CAST(76.965034 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'100f53a8-876e-495c-8f58-6b40d0f5a488', 109, CAST(N'2012-02-29' AS Date), CAST(78.424385 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ea7c0a7-67c1-42d3-befa-66bc81040bd9', 109, CAST(N'2012-03-31' AS Date), CAST(82.449129 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce751917-c42a-4a58-8065-283840b0c284', 109, CAST(N'2012-04-30' AS Date), CAST(81.371815 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'93d936b5-0b9c-4f0a-8f73-0f1e42ae6ae3', 109, CAST(N'2012-05-31' AS Date), CAST(79.729516 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c3e25f5-d399-486a-850d-ccc474772fa1', 109, CAST(N'2012-06-30' AS Date), CAST(79.246310 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f2db2b7e-d7d3-481b-8d43-622d76a1f36c', 109, CAST(N'2012-07-31' AS Date), CAST(79.081444 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b918cce-18a4-4779-aff3-7514f711ce2b', 109, CAST(N'2012-08-31' AS Date), CAST(78.700033 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6f1dd721-9caf-490f-857e-d0afb3049c5d', 109, CAST(N'2012-09-30' AS Date), CAST(78.194783 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f19d714-a3aa-48eb-9158-027f0db802a6', 109, CAST(N'2012-10-31' AS Date), CAST(78.907846 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b09129f8-e87f-492d-a3bf-c7b3b86682c4', 109, CAST(N'2012-11-30' AS Date), CAST(80.910750 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4325193-2913-48ac-8ab0-7fa684a2abb9', 109, CAST(N'2012-12-31' AS Date), CAST(83.583241 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a382198-0e9a-42a1-b30d-cdfd407ba68c', 109, CAST(N'2013-01-31' AS Date), CAST(88.983226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5af86d78-f99c-4c96-aa1d-aa375113c9f5', 109, CAST(N'2013-02-28' AS Date), CAST(93.035321 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2aec0295-63f8-44cf-9caa-a032974b6dc4', 109, CAST(N'2013-03-31' AS Date), CAST(94.706742 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38ab6a88-311d-4d6c-bd1d-a221bcaadd12', 109, CAST(N'2013-04-30' AS Date), CAST(97.824633 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'308d9782-3665-4fae-95eb-6a5c472976d5', 109, CAST(N'2013-05-31' AS Date), CAST(100.926242 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4c688673-f49f-42ac-85d7-63794eb5fe76', 109, CAST(N'2013-06-30' AS Date), CAST(97.277696 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f0f639ea-138f-4cf8-b2a6-662aa5f3808a', 109, CAST(N'2013-07-31' AS Date), CAST(99.754758 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'796a64ad-32ad-4701-86f5-c7eeadd6654a', 109, CAST(N'2013-08-31' AS Date), CAST(97.842145 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e173748-78f7-4f04-a5b7-23f2f66f85cd', 109, CAST(N'2013-09-30' AS Date), CAST(99.119483 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb8d12b6-46be-4813-a1ae-0347825d29d2', 109, CAST(N'2013-10-31' AS Date), CAST(97.824081 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8796ca87-65ee-47a3-a002-30e7ceeac91f', 109, CAST(N'2013-11-30' AS Date), CAST(99.984317 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'deded979-babe-459a-b5a2-352212fddf7f', 109, CAST(N'2013-12-31' AS Date), CAST(103.462290 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'746bddb2-3357-41f3-a8eb-520b03fe3271', 109, CAST(N'2014-01-31' AS Date), CAST(103.959371 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c21bcda1-ef36-4a38-ae14-2383cd22224c', 109, CAST(N'2014-02-28' AS Date), CAST(102.143464 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd7800fd2-27c7-4950-8d3d-20085733694b', 109, CAST(N'2014-03-31' AS Date), CAST(102.286468 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ac722f06-1622-4f40-82bb-6078cb04d08b', 109, CAST(N'2014-04-30' AS Date), CAST(102.473150 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9472e339-702d-4e7e-9922-2036abd2401b', 109, CAST(N'2014-05-31' AS Date), CAST(101.829548 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7396da17-c9e7-4bed-88f9-b9a7e24a520c', 109, CAST(N'2014-06-30' AS Date), CAST(102.065550 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e5ce6a61-eb10-4b0a-aa21-a4c4014c41ed', 109, CAST(N'2014-07-31' AS Date), CAST(101.692339 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'68f3a6b3-2b00-4e1e-a939-1c92eb43e3d0', 109, CAST(N'2014-08-31' AS Date), CAST(102.888567 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4036678-00fd-4f0d-8f36-bfe971c0a141', 109, CAST(N'2014-09-30' AS Date), CAST(107.234607 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5dacd6d-00af-4e61-9761-fc1587ea91e2', 109, CAST(N'2014-10-31' AS Date), CAST(107.949323 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e6b471d-cec6-49f8-9fae-b18be2e30c00', 109, CAST(N'2014-11-30' AS Date), CAST(115.976783 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c252358b-a234-4af0-92c7-bc2241201b0f', 109, CAST(N'2014-12-31' AS Date), CAST(119.571419 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f1220492-5ca8-4d33-b08a-c1bf2d8149dc', 109, CAST(N'2015-01-31' AS Date), CAST(118.267161 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9ea716ce-8e75-4913-a787-93d4e5fac10e', 109, CAST(N'2015-02-28' AS Date), CAST(118.700625 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8e9e0a1-fa31-4223-9b7c-1171fa83bc6c', 109, CAST(N'2015-03-31' AS Date), CAST(120.341145 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd1f7acc0-e078-4833-8cf5-b7f3e6ffe14b', 109, CAST(N'2015-04-30' AS Date), CAST(119.474867 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3db37db2-28a3-4434-8131-90733a23e6a9', 109, CAST(N'2015-05-31' AS Date), CAST(120.684661 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c0d0991-e880-4f0c-94f1-a7c80999eac0', 109, CAST(N'2015-06-30' AS Date), CAST(123.829983 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0aa992ad-a8ea-4c80-aec2-f59e167f425f', 109, CAST(N'2015-07-31' AS Date), CAST(123.265726 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'678f3628-cb6d-4973-a0c1-13a0b5dc8562', 109, CAST(N'2015-08-31' AS Date), CAST(123.214161 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'136439ad-58b9-4faa-9ad7-a785075d5490', 109, CAST(N'2015-09-30' AS Date), CAST(120.141500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5dfba02b-1079-4247-898a-d97eb6077848', 109, CAST(N'2015-10-31' AS Date), CAST(120.136258 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4674936a-0e0b-46fc-a9d3-9989d0fc927c', 109, CAST(N'2015-11-30' AS Date), CAST(122.555467 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fbb4674a-2fb9-4d2c-bc47-464ae9db4239', 109, CAST(N'2015-12-31' AS Date), CAST(121.617790 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7da58e33-14ad-4287-929f-03cb26035f06', 109, CAST(N'2016-01-31' AS Date), CAST(118.457194 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ece74f38-9fff-4c0a-bb50-d8bda2ce9ca6', 109, CAST(N'2016-02-29' AS Date), CAST(114.778466 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'068ab4c9-1e95-46ba-9bbc-6053943bc5fb', 109, CAST(N'2016-03-31' AS Date), CAST(112.976274 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01556e32-254a-46c1-a4ea-406e037906da', 109, CAST(N'2016-04-30' AS Date), CAST(109.796550 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e06afc2c-5126-434d-8ca2-f80304e96b0b', 109, CAST(N'2016-05-31' AS Date), CAST(108.739032 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9e1ca1f-c07e-422b-a455-b59a1b86c473', 109, CAST(N'2016-06-30' AS Date), CAST(105.513333 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94f8aed5-2d39-4f26-bf47-28b9383d185c', 109, CAST(N'2016-07-31' AS Date), CAST(103.867129 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9be07921-ddeb-48d2-bd11-eb26679cbba2', 109, CAST(N'2016-08-31' AS Date), CAST(101.233242 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d64182b-b069-4b85-89e1-63fd8c5eece9', 109, CAST(N'2016-09-30' AS Date), CAST(102.099817 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f929d99-47b1-4208-b575-de3cec468ab9', 109, CAST(N'2016-10-31' AS Date), CAST(103.673468 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'86a28f40-dccb-4976-a157-df68a7bae8e9', 109, CAST(N'2016-11-30' AS Date), CAST(108.529750 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'28efc47f-1fc0-4e36-9604-f1db43da35cd', 109, CAST(N'2016-12-31' AS Date), CAST(116.073137 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75be5485-0cda-4525-ad47-59aff5fa23f3', 109, CAST(N'2017-01-31' AS Date), CAST(115.093355 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'903b758c-5cfb-44fb-9ccd-6a0209434b3d', 109, CAST(N'2017-02-28' AS Date), CAST(112.865464 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7526cb85-ca67-47b2-a956-8d9c48628ecb', 109, CAST(N'2017-03-31' AS Date), CAST(112.988573 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fdc57451-748c-4b8e-9376-350bffcc86ab', 109, CAST(N'2017-04-30' AS Date), CAST(110.149052 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2cd020bb-aec2-4ef5-b00f-05d587e9577d', 109, CAST(N'2017-05-31' AS Date), CAST(112.234879 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2744391-93c0-422f-9537-80e594113866', 109, CAST(N'2017-06-30' AS Date), CAST(110.854500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ccb064c-e064-444f-a9a7-72c445bc2285', 109, CAST(N'2017-07-31' AS Date), CAST(112.338871 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f2dd079a-bb49-4c08-9ab3-957bd5b132e4', 109, CAST(N'2017-08-31' AS Date), CAST(109.796917 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8979d62-ed32-41e6-97b4-ae8d16665a65', 109, CAST(N'2017-09-30' AS Date), CAST(110.693100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da0ee656-89fa-427a-8fe0-a26493b5acaf', 109, CAST(N'2017-10-31' AS Date), CAST(112.931667 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a736ff3f-512e-45aa-b4d3-08d06ed09958', 109, CAST(N'2017-11-30' AS Date), CAST(112.798983 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'092ddbce-d0a5-4cbf-8da7-bb4568edd31b', 109, CAST(N'2017-12-31' AS Date), CAST(112.897742 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3d83a7f-ca0e-441c-a334-ee32eaa6e31a', 109, CAST(N'2018-01-31' AS Date), CAST(110.932000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2101a79a-b4a2-4d24-8070-c8e221efb54c', 109, CAST(N'2018-02-28' AS Date), CAST(107.935670 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b63d39b4-c604-4d24-8829-f579d14b31cd', 109, CAST(N'2018-03-31' AS Date), CAST(106.030217 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6652f4fb-2ce8-4c25-81a4-223fc8099f89', 109, CAST(N'2018-04-30' AS Date), CAST(107.595850 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'266557e8-eb90-4696-8006-20856bcc1e58', 109, CAST(N'2018-05-31' AS Date), CAST(109.664452 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f49f0895-6764-4cfa-9df7-659cee5e9621', 109, CAST(N'2018-06-30' AS Date), CAST(110.047700 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9744445d-7091-4018-873a-6f2ee374a752', 109, CAST(N'2018-07-31' AS Date), CAST(111.431677 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a3177d42-ee12-47e9-9694-3184f0e2a66b', 109, CAST(N'2018-08-31' AS Date), CAST(111.006984 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'10b0512d-23f3-4275-8b31-c2a2a149be2d', 109, CAST(N'2018-09-30' AS Date), CAST(112.046800 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f6cb46e-712c-42a5-8fb9-6e7c840868a3', 109, CAST(N'2018-10-31' AS Date), CAST(112.710935 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c7f4f68d-c49c-4170-aa4d-23f39e10c6c4', 109, CAST(N'2018-11-30' AS Date), CAST(113.299900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f60b7ac1-e280-46b9-8f7d-b582321f9697', 109, CAST(N'2018-12-31' AS Date), CAST(112.116258 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'51a6bda2-b32f-44a3-8a13-d8e273d5abe9', 109, CAST(N'2019-01-31' AS Date), CAST(109.018129 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c87ccc3d-4e11-4e69-9d03-9a452b1d0dca', 109, CAST(N'2019-02-28' AS Date), CAST(110.342630 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91c45304-73c1-46a4-ac7d-3cb0b551a3f6', 109, CAST(N'2019-03-31' AS Date), CAST(111.126081 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'465b289e-5db5-4d78-8c6c-8fb82aeca91c', 109, CAST(N'2019-04-30' AS Date), CAST(111.691293 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4b6688cd-c63e-4898-b806-4506130afedf', 109, CAST(N'2019-05-31' AS Date), CAST(110.000065 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f9903d73-a357-4665-80eb-5049aa66b5ae', 109, CAST(N'2019-06-30' AS Date), CAST(108.072883 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'34eed43d-0d8f-40b4-b270-1551e9ab08f3', 109, CAST(N'2019-07-31' AS Date), CAST(108.249371 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b695013-429c-4a90-bcd8-55a4ca86ef0c', 109, CAST(N'2019-08-31' AS Date), CAST(106.144767 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1172d70-73ee-40ad-b2a4-6fd26a0926c2', 109, CAST(N'2019-09-30' AS Date), CAST(107.468050 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6cb101e9-82f0-4213-bc4e-c1ff135b8161', 109, CAST(N'2019-10-31' AS Date), CAST(108.144839 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c4ad1acc-b763-4184-a49b-2c96eb484117', 109, CAST(N'2019-11-30' AS Date), CAST(108.868117 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23f018da-7b71-4bbc-9811-baef676a1093', 109, CAST(N'2019-12-31' AS Date), CAST(109.146793 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a2229411-ea40-47b6-9beb-85d1ec3d9a4a', 109, CAST(N'2020-01-31' AS Date), CAST(109.352613 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4793e1d9-67e7-4212-862e-9ada214e413e', 109, CAST(N'2020-02-29' AS Date), CAST(109.975071 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d304e60-879a-425d-ac9f-2f7902cb23b9', 223, CAST(N'2000-02-29' AS Date), CAST(3.671807 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5eb8d01d-5d15-436c-a980-97791ab34e4a', 223, CAST(N'2000-03-31' AS Date), CAST(3.672771 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c185736-c793-45ab-8e7e-63629c597f01', 223, CAST(N'2000-04-30' AS Date), CAST(3.672249 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4c16469-c2a8-4ab6-84bf-1d3c113991fc', 223, CAST(N'2000-05-31' AS Date), CAST(3.672857 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8b3f6702-1f20-4478-b56e-ec5ac65b34c8', 223, CAST(N'2000-06-30' AS Date), CAST(3.672616 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61e9a424-481c-4cad-82d3-efe08ecad937', 223, CAST(N'2000-07-31' AS Date), CAST(3.672613 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b61f8821-f422-41c9-9e27-07a947b3d88c', 223, CAST(N'2000-08-31' AS Date), CAST(3.672903 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46d97599-9745-4911-9113-eff0910c9911', 223, CAST(N'2000-09-30' AS Date), CAST(3.672411 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4d1c751-86d7-4491-8486-a2545116d793', 223, CAST(N'2000-10-31' AS Date), CAST(3.673018 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b7c12f2c-054c-4c00-ad2f-f42d5e2365f0', 223, CAST(N'2000-11-30' AS Date), CAST(3.673761 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5cebfa3c-e49f-49f4-b1ea-c774c53db910', 223, CAST(N'2000-12-31' AS Date), CAST(3.673789 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4bd1bbc-aab4-4845-a93c-5dce516c410b', 223, CAST(N'2001-01-31' AS Date), CAST(3.673573 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd12af544-66fb-4acb-bb79-b21589b264ab', 223, CAST(N'2001-02-28' AS Date), CAST(3.674029 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3a25747b-f710-498a-a383-605e8e8551fe', 223, CAST(N'2001-03-31' AS Date), CAST(3.673833 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'79eac794-ddb1-470b-af89-16260afd2a9c', 223, CAST(N'2001-04-30' AS Date), CAST(3.673658 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'813d261e-daea-45e5-b776-ef1f89dd9181', 223, CAST(N'2001-05-31' AS Date), CAST(3.673558 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'05228183-5c08-4b13-b627-bd187b02a4f7', 223, CAST(N'2001-06-30' AS Date), CAST(3.673613 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e3169da7-d01b-4b3f-8c0e-b63da8310e14', 223, CAST(N'2001-07-31' AS Date), CAST(3.673886 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6281617-0f5e-4ec7-a9a9-0e48d389478b', 223, CAST(N'2001-08-31' AS Date), CAST(3.673725 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'31770774-525b-4dd1-8ddf-80b423d4f076', 223, CAST(N'2001-09-30' AS Date), CAST(3.673766 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8e43e72f-93c8-4c0b-9d27-3b7395b5ca06', 223, CAST(N'2001-10-31' AS Date), CAST(3.673627 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'99acdcf5-10be-488f-9d50-dde14d39732f', 223, CAST(N'2001-11-30' AS Date), CAST(3.673019 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f7d278c2-ee98-4d3b-8eff-07933a0c271c', 223, CAST(N'2001-12-31' AS Date), CAST(3.672980 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'858ddbcf-d7a4-4f9f-822e-a15a8ac9a9f0', 223, CAST(N'2002-01-31' AS Date), CAST(3.672982 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e0f45d03-d932-49b1-aedf-29ea3a2e603a', 223, CAST(N'2002-02-28' AS Date), CAST(3.673035 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'67122810-835f-463d-a91a-4b4faebad2ea', 223, CAST(N'2002-03-31' AS Date), CAST(3.673020 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b67fb9a-772b-47a5-956f-495bc994a812', 223, CAST(N'2002-04-30' AS Date), CAST(3.673004 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41eadf68-53b4-4ac7-95fe-002199ca318d', 223, CAST(N'2002-05-31' AS Date), CAST(3.672974 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f33f69b1-46ff-41c9-816d-8f28f517de43', 223, CAST(N'2002-06-30' AS Date), CAST(3.672984 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0235e6a7-6f3a-403c-9d5d-5d920f841db5', 223, CAST(N'2002-07-31' AS Date), CAST(3.672945 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ea82917f-a237-4d09-9f02-eceb8f5f97a3', 223, CAST(N'2002-08-31' AS Date), CAST(3.672923 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf9350de-9f10-43e4-a44e-33f9fa103384', 223, CAST(N'2002-09-30' AS Date), CAST(3.672985 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5a01d12-a52e-4977-b356-4b1ef755fd37', 223, CAST(N'2002-10-31' AS Date), CAST(3.673041 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'471199ea-5d7e-42f4-ab4b-2d7ad3a5be5a', 223, CAST(N'2002-11-30' AS Date), CAST(3.673042 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f725ff33-3852-4ab4-9328-bd04b9e28a7c', 223, CAST(N'2002-12-31' AS Date), CAST(3.672987 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a282d2e6-15a9-434e-bd3c-7c8c41784d38', 223, CAST(N'2003-01-31' AS Date), CAST(3.673000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17e94797-e84b-4e38-9354-0a26cb8687c3', 223, CAST(N'2003-02-28' AS Date), CAST(3.672979 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bbd559f5-6506-4549-a892-a3fb22d71fc0', 223, CAST(N'2003-03-31' AS Date), CAST(3.672979 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'329783c3-9e91-45d3-ba80-5e03fb6ef436', 223, CAST(N'2003-04-30' AS Date), CAST(3.673007 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b218bec9-fa89-4582-9c44-5d04c72efcf3', 223, CAST(N'2003-05-31' AS Date), CAST(3.672905 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c438dbb9-9b74-4f6a-b780-543437f13eba', 223, CAST(N'2003-06-30' AS Date), CAST(3.672980 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'66a39c18-8326-45a7-84a2-2a4224455a79', 223, CAST(N'2003-07-31' AS Date), CAST(3.673035 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a84f1366-5be1-4cda-bde0-660512e9ddef', 223, CAST(N'2003-08-31' AS Date), CAST(3.672958 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23984e1d-81f2-4af5-9761-48b17c478d5b', 223, CAST(N'2003-09-30' AS Date), CAST(3.672954 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fdb2d941-2f05-4249-8014-53572cdb4af5', 223, CAST(N'2003-10-31' AS Date), CAST(3.672933 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f4dbaa2-410d-4266-8942-2cd658a3efbc', 223, CAST(N'2003-11-30' AS Date), CAST(3.672900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4271be89-c03f-456c-ae8d-1ea441665a57', 223, CAST(N'2003-12-31' AS Date), CAST(3.672917 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd75cc60d-afd2-4431-a0ec-f3e812091797', 223, CAST(N'2004-01-31' AS Date), CAST(3.672867 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08c5b82c-bfcc-41bc-a673-d6be344a0e14', 223, CAST(N'2004-02-29' AS Date), CAST(3.672988 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a82fc12-76ae-4280-a868-1d9367b86023', 223, CAST(N'2004-03-31' AS Date), CAST(3.673070 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30589c47-3d54-4f1e-a625-89204dc20d0d', 223, CAST(N'2004-04-30' AS Date), CAST(3.673007 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61678a7c-0491-4168-aeb9-6ff351ffc347', 223, CAST(N'2004-05-31' AS Date), CAST(3.673037 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'15ef7b70-e71e-4caf-825e-71592a255f05', 223, CAST(N'2004-06-30' AS Date), CAST(3.673040 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'303d8489-3546-4254-a587-b19206f9f98b', 223, CAST(N'2004-07-31' AS Date), CAST(3.673059 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3776df2e-3f99-4ff1-b0c7-3bec133a3bb9', 223, CAST(N'2004-08-31' AS Date), CAST(3.673056 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cfbb6b76-d1b3-49be-9b8c-bcf90ef27660', 223, CAST(N'2004-09-30' AS Date), CAST(3.657189 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'06cfebfd-701a-4695-afd7-7ef42962c5a6', 223, CAST(N'2004-10-31' AS Date), CAST(3.691505 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3b2c88b-aa7b-46bb-b063-3e4d8b1e5738', 223, CAST(N'2004-11-30' AS Date), CAST(3.672889 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'792d2434-8830-4eb0-9bd0-0f09e1bd2c49', 223, CAST(N'2004-12-31' AS Date), CAST(3.655382 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6a8f3a63-a2b8-46a2-8b5c-582f0e8662be', 223, CAST(N'2005-01-31' AS Date), CAST(3.672598 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'55066cae-adfb-4c0b-95c2-eac59f2cdb92', 223, CAST(N'2005-02-28' AS Date), CAST(3.672746 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d4bdb61-14c8-4924-adb1-517274907d32', 223, CAST(N'2005-03-31' AS Date), CAST(3.672815 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4bfecb6b-e910-4880-8de9-2043a716636b', 223, CAST(N'2005-04-30' AS Date), CAST(3.672823 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0af3f96b-4599-47cd-96e0-7219e1b0c6cb', 223, CAST(N'2005-05-31' AS Date), CAST(3.672910 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a318e0eb-7bc6-4caa-9587-6ea2effed749', 223, CAST(N'2005-06-30' AS Date), CAST(3.672918 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2929713-6f45-423e-a008-b2d882bf14df', 223, CAST(N'2005-07-31' AS Date), CAST(3.672878 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b7ea78da-95f2-4e60-ab4e-2be49d0d5ba3', 223, CAST(N'2005-08-31' AS Date), CAST(3.537397 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8726d084-37fa-466e-a77e-7e27bc0a88fa', 223, CAST(N'2005-09-30' AS Date), CAST(3.672720 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae4f0ab5-7eb5-449e-bafb-1ac5993cda9e', 223, CAST(N'2005-10-31' AS Date), CAST(3.672767 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a61270d-08d5-465e-9f24-062b2c6d2cc5', 223, CAST(N'2005-11-30' AS Date), CAST(3.673005 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8968b55-69c2-42ce-b0a9-33e96a13f9a7', 223, CAST(N'2005-12-31' AS Date), CAST(3.672471 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'337d5382-7a8d-4216-9e2c-f4d902bf30a5', 223, CAST(N'2006-01-31' AS Date), CAST(3.672946 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6817e54b-39f7-400a-aa75-63c6bb12971d', 223, CAST(N'2006-02-28' AS Date), CAST(3.673544 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4f50de7-3b47-49f3-bfe7-c7a595609c97', 223, CAST(N'2006-03-31' AS Date), CAST(3.673548 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eac6c2ae-b233-4a5e-8bb6-318f932f5f0f', 223, CAST(N'2006-04-30' AS Date), CAST(3.672316 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9adb0e73-37e2-4454-b887-c06fb8a98f51', 223, CAST(N'2006-05-31' AS Date), CAST(3.673041 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9695a4b6-db4a-4551-ac5c-f1dfe8628f6d', 223, CAST(N'2006-06-30' AS Date), CAST(3.672571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd353450c-07bc-4f92-82a6-a05d22bfbfb2', 223, CAST(N'2006-07-31' AS Date), CAST(3.672967 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'109ff521-4859-407e-8976-a2c394f4b50f', 223, CAST(N'2006-08-31' AS Date), CAST(3.673384 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2113e48f-d654-48d4-b3df-cf9aea29d18c', 223, CAST(N'2006-09-30' AS Date), CAST(3.672943 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2845d7bb-aaf4-4734-854e-9ea57f5cf45b', 223, CAST(N'2006-10-31' AS Date), CAST(3.672886 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6af0e213-a88e-4b86-8538-2d4070872c2f', 223, CAST(N'2006-11-30' AS Date), CAST(3.672521 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'216d31d9-da87-4a81-80cb-5d810004c33f', 223, CAST(N'2006-12-31' AS Date), CAST(3.672570 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8e47f3ed-bda2-47ee-b454-de9826fefcf8', 223, CAST(N'2007-01-31' AS Date), CAST(3.672994 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'22296008-ab96-4992-b4d7-2257f98ab301', 223, CAST(N'2007-02-28' AS Date), CAST(3.672588 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0b6e6e55-a85c-4719-acc8-d1b5d466410d', 223, CAST(N'2007-03-31' AS Date), CAST(3.672040 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aa9a5eda-f05c-4b61-a5ea-9cf1eafbbfa3', 223, CAST(N'2007-04-30' AS Date), CAST(3.672325 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c4be7d2-4d57-4554-8c68-1632e7218eb9', 223, CAST(N'2007-05-31' AS Date), CAST(3.674216 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00fe730b-99ec-4902-931a-5e12f21ed216', 223, CAST(N'2007-06-30' AS Date), CAST(3.672757 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1bd2d9d0-74d1-4011-8a42-9e3c87a3b039', 223, CAST(N'2007-07-31' AS Date), CAST(3.672750 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bcfdbdc5-e4db-4cef-ac70-c639891c13f6', 223, CAST(N'2007-08-31' AS Date), CAST(3.672830 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a196fd21-0547-4624-b455-620804e8e42e', 223, CAST(N'2007-09-30' AS Date), CAST(3.672108 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2bc8ae5-7aea-4c18-a5e0-91b0b8e86425', 223, CAST(N'2007-10-31' AS Date), CAST(3.672093 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'415b4983-db0a-4d8b-b07a-28d8b0cbec63', 223, CAST(N'2007-11-30' AS Date), CAST(3.670345 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4030a2ff-4374-461a-99ca-a2e1d88f0771', 223, CAST(N'2007-12-31' AS Date), CAST(3.671950 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7f0f53d4-08ac-462b-8f56-d11d0c187348', 223, CAST(N'2008-01-31' AS Date), CAST(3.672837 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2b7fe522-b90a-4e44-b1f9-eae582b1f1f8', 223, CAST(N'2008-02-29' AS Date), CAST(3.672257 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'628aee58-5143-4009-8e76-19c3aa6d81d0', 223, CAST(N'2008-03-31' AS Date), CAST(3.672140 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'64be7fbc-b940-4163-b2ea-3deecb31b09b', 223, CAST(N'2008-04-30' AS Date), CAST(3.672012 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2de738f-4a34-4fd4-8656-d09afba079a8', 223, CAST(N'2008-05-31' AS Date), CAST(3.672946 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4d99053-5f7c-49c9-bf6f-29c80ca19c34', 223, CAST(N'2008-06-30' AS Date), CAST(3.673880 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9af02e4e-62e3-4d44-8edd-6451dc09ab9b', 223, CAST(N'2008-07-31' AS Date), CAST(3.673030 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'95f1d9cb-8923-4ca7-a2d0-e1ef4f534a59', 223, CAST(N'2008-08-31' AS Date), CAST(3.673090 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6e57703e-f91e-4692-a4bd-9dd4666cc55b', 223, CAST(N'2008-09-30' AS Date), CAST(3.673164 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8ded29f-daf8-4b02-8367-ab49df11e419', 223, CAST(N'2008-10-31' AS Date), CAST(3.673340 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4e44e6c-763f-441c-948d-3968da183e10', 223, CAST(N'2008-11-30' AS Date), CAST(3.673357 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a39aa367-b230-433b-bb9d-24e57042c9b1', 223, CAST(N'2008-12-31' AS Date), CAST(3.673059 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d645fef-3413-4597-a5c4-794f92dac6b5', 223, CAST(N'2009-01-31' AS Date), CAST(3.673266 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'683a0dc6-78ec-42c1-a35d-c72278a4649a', 223, CAST(N'2009-02-28' AS Date), CAST(3.673040 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7db984e-56af-418b-a87d-9384b5d6268c', 223, CAST(N'2009-03-31' AS Date), CAST(3.673039 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd83cfdad-ca07-46e7-92aa-039c20805bae', 223, CAST(N'2009-04-30' AS Date), CAST(3.673105 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'060227b0-da00-4d8d-a9a0-af60eb46bd00', 223, CAST(N'2009-05-31' AS Date), CAST(3.673542 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fe83eb26-9754-4a1d-a1d1-ed96b0e55295', 223, CAST(N'2009-06-30' AS Date), CAST(3.671843 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cfd1e84a-7174-49fa-97c3-2fb0373de818', 223, CAST(N'2009-07-31' AS Date), CAST(3.672733 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cd23297b-5c1e-4c97-9c22-2e62f645be8b', 223, CAST(N'2009-08-31' AS Date), CAST(3.672963 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9d2395a-4e44-49c0-9847-aad6d3ce11d3', 223, CAST(N'2009-09-30' AS Date), CAST(3.672945 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd7ea56a1-95a1-433a-8392-9a8ebe04a23d', 223, CAST(N'2009-10-31' AS Date), CAST(3.672795 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd936d5d6-c4bd-4a6f-a849-0330d966d6b8', 223, CAST(N'2009-11-30' AS Date), CAST(3.673065 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'564959c9-6f48-4864-b281-ee3af2469b43', 223, CAST(N'2009-12-31' AS Date), CAST(3.672497 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6e04be90-072c-4307-a6d9-db61ba050781', 223, CAST(N'2010-01-31' AS Date), CAST(3.672823 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b858f846-e1e0-4462-a123-096a6220446f', 223, CAST(N'2010-02-28' AS Date), CAST(3.673046 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a0fa98b-f211-4b95-b22a-cf92d58cb7c5', 223, CAST(N'2010-03-31' AS Date), CAST(3.672916 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94968570-a8a0-4a0c-89ae-4b2986a81502', 223, CAST(N'2010-04-30' AS Date), CAST(3.672953 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'71a7179e-159d-4caf-a72b-52c7b614a5b6', 223, CAST(N'2010-05-31' AS Date), CAST(3.672994 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'74527dbd-1947-4cc3-86c6-622621b75b1c', 223, CAST(N'2010-06-30' AS Date), CAST(3.672973 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca0fdb1a-d853-4b81-88c3-9c9372cf6fcf', 223, CAST(N'2010-07-31' AS Date), CAST(3.672948 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'96a462bf-0fa4-4308-a397-54083faa2ee8', 223, CAST(N'2010-08-31' AS Date), CAST(3.672971 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff22654f-a5f9-499e-a5cf-95d504f04c69', 223, CAST(N'2010-09-30' AS Date), CAST(3.672950 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd255c05e-eb37-4485-8a30-d7b01ad96346', 223, CAST(N'2010-10-31' AS Date), CAST(3.672961 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae614afc-5b44-412d-9325-2a2868999e75', 223, CAST(N'2010-11-30' AS Date), CAST(3.672880 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'535bd007-2050-4937-b05f-d1ecb3dea008', 223, CAST(N'2010-12-31' AS Date), CAST(3.672897 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3275536-45d8-4c0a-a5b0-a883459f57b3', 223, CAST(N'2011-01-31' AS Date), CAST(3.672984 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cf5729dd-b5f5-42ec-bfc3-91a244cd1b88', 223, CAST(N'2011-02-28' AS Date), CAST(3.672986 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dfee435d-2ede-4a53-876e-5e2f06f2902c', 223, CAST(N'2011-03-31' AS Date), CAST(3.673000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b36a1d91-360f-4471-b8a1-50318a2022b1', 223, CAST(N'2011-04-30' AS Date), CAST(3.672987 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6b74586d-0bc2-4e08-bbde-9066b49e8439', 223, CAST(N'2011-05-31' AS Date), CAST(3.673039 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'645efee5-dcd6-4801-80d3-3279c5fbaa4f', 223, CAST(N'2011-06-30' AS Date), CAST(3.673027 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc698a75-49f4-4d56-826d-6ff77a87cb8c', 223, CAST(N'2011-07-31' AS Date), CAST(3.672984 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'129e97b1-9564-466e-8c42-62208c36b016', 223, CAST(N'2011-08-31' AS Date), CAST(3.672948 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd955b55c-1bd8-419b-a3aa-58781db0c740', 223, CAST(N'2011-09-30' AS Date), CAST(3.673024 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43cabb1d-fd5f-45e4-976a-576edc5bbde8', 223, CAST(N'2011-10-31' AS Date), CAST(3.673000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'83ff08d8-142d-4a79-8f40-11dd3fff9ee8', 223, CAST(N'2011-11-30' AS Date), CAST(3.672980 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eee4bafa-71f0-4842-8fe6-8ba39f138df6', 223, CAST(N'2011-12-31' AS Date), CAST(3.673026 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc3aebf7-b510-4156-b35f-a8a17aef0663', 223, CAST(N'2012-01-31' AS Date), CAST(3.673023 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0da276f1-ecf3-4745-ad2d-9f1919735815', 223, CAST(N'2012-02-29' AS Date), CAST(3.673007 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a4b3d47-cb64-40f4-afee-1489787c9ff2', 223, CAST(N'2012-03-31' AS Date), CAST(3.673000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4471fd0b-be36-4c60-aaca-6ee53f0f3c0e', 223, CAST(N'2012-04-30' AS Date), CAST(3.673007 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'deb407dd-7143-442d-ba00-7a17a0d624cd', 223, CAST(N'2012-05-31' AS Date), CAST(3.673032 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85fc59eb-42e2-4cc1-ba06-099e0c4d6449', 223, CAST(N'2012-06-30' AS Date), CAST(3.673030 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85a33d45-1d77-4f56-b45b-0d1fc2dee46b', 223, CAST(N'2012-07-31' AS Date), CAST(3.673029 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'319134b5-8c75-48b4-ba9c-82100d113e8e', 223, CAST(N'2012-08-31' AS Date), CAST(3.673048 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1b6396c-29f2-43f3-94c0-cf400f3c4075', 223, CAST(N'2012-09-30' AS Date), CAST(3.673030 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6c69f649-f102-45d8-8b2d-dc6d90d14820', 223, CAST(N'2012-10-31' AS Date), CAST(3.673003 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b5252d56-7570-4889-ba79-9409485d424d', 223, CAST(N'2012-11-30' AS Date), CAST(3.673017 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'93942188-0f98-44a1-8211-0e2b6fbb74c3', 223, CAST(N'2012-12-31' AS Date), CAST(3.673037 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c967f82-6f8d-4492-a91a-39ffcbcad57d', 223, CAST(N'2013-01-31' AS Date), CAST(3.673040 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8e45df55-dcd9-4acc-b5b8-7dd056f42209', 223, CAST(N'2013-02-28' AS Date), CAST(3.673039 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'37bfeeca-2306-4f9d-8a91-749a98bdd8c2', 223, CAST(N'2013-03-31' AS Date), CAST(3.673015 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b0d7623e-9604-43ec-b96f-5b76b36df9c7', 223, CAST(N'2013-04-30' AS Date), CAST(3.672975 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3213b12-b3ce-4139-9c7d-07aa9f073359', 223, CAST(N'2013-05-31' AS Date), CAST(3.673044 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d24383f-f7a3-4bc5-86d3-44a7934672f8', 223, CAST(N'2013-06-30' AS Date), CAST(3.672965 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'377dc7f6-7d68-40ee-9e21-94b6f80fab27', 223, CAST(N'2013-07-31' AS Date), CAST(3.673018 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6a3fbf54-9fbd-488d-8fc1-194fe3481023', 223, CAST(N'2013-08-31' AS Date), CAST(3.673010 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1dba9fd7-1819-4fc0-b83a-7ca0748d8b89', 223, CAST(N'2013-09-30' AS Date), CAST(3.673023 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'31a4238f-3ae9-4b01-9f8c-3192b2f23b29', 223, CAST(N'2013-10-31' AS Date), CAST(3.673002 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cc73f3be-6656-4057-aee9-c322dab69fca', 223, CAST(N'2013-11-30' AS Date), CAST(3.673013 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'34ef3c45-13e8-4b38-a38a-39d6e4365807', 223, CAST(N'2013-12-31' AS Date), CAST(3.673002 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2fa0bf4f-b461-4299-ada9-09c624d6f171', 223, CAST(N'2014-01-31' AS Date), CAST(3.672997 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f2536bf-9abd-462b-88f9-986ef0c400a6', 223, CAST(N'2014-02-28' AS Date), CAST(3.673004 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'efe30c3a-2978-41fe-bb0a-e02541b242b8', 223, CAST(N'2014-03-31' AS Date), CAST(3.672995 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d1da4cf-a1ad-4b3e-ba31-d744b8e5e70f', 223, CAST(N'2014-04-30' AS Date), CAST(3.673015 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9fbc543b-494f-446f-aa57-7bdc763abf8c', 223, CAST(N'2014-05-31' AS Date), CAST(3.673000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'163f4824-a62f-4641-bcf3-dcf5af90d207', 223, CAST(N'2014-06-30' AS Date), CAST(3.673002 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb87e05f-16ff-4f9f-933b-326057c62c07', 223, CAST(N'2014-07-31' AS Date), CAST(3.672987 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3658afff-0a5a-4e86-8b78-333d39b7f0c3', 223, CAST(N'2014-08-31' AS Date), CAST(3.673067 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4abb1c18-48b7-448c-8c44-e7cb62d019bc', 223, CAST(N'2014-09-30' AS Date), CAST(3.673000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0091c297-47a7-40ae-8978-40d9a22472f5', 223, CAST(N'2014-10-31' AS Date), CAST(3.672985 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61552304-8fbb-45ae-8529-47e5be4bca9d', 223, CAST(N'2014-11-30' AS Date), CAST(3.673028 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f119e44a-6919-4bb9-9468-f618ad832998', 223, CAST(N'2014-12-31' AS Date), CAST(3.673015 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e1d9b5ef-ef00-47fd-99e9-9f245d55b060', 223, CAST(N'2015-01-31' AS Date), CAST(3.673039 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12eea8b7-cafb-4f52-af83-dd0322195df4', 223, CAST(N'2015-02-28' AS Date), CAST(3.673016 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b9d8f1b1-1ec1-4428-b489-3deeb00533c0', 223, CAST(N'2015-03-31' AS Date), CAST(3.672974 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c0056d7-28d7-44be-bd5d-bbf2af953064', 223, CAST(N'2015-04-30' AS Date), CAST(3.672995 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3d5064b7-7d44-474c-828b-35906228fa2a', 223, CAST(N'2015-05-31' AS Date), CAST(3.673031 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dd24d68a-d9f5-40df-9c08-48d785f0a489', 223, CAST(N'2015-06-30' AS Date), CAST(3.672977 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f0868016-86ee-405f-880f-eb703b8de9a9', 223, CAST(N'2015-07-31' AS Date), CAST(3.673027 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13272db5-0ab7-4e31-8b93-7dca3126e22a', 223, CAST(N'2015-08-31' AS Date), CAST(3.672985 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'98b7f5e8-56b5-4df5-ac13-14f491b95a2d', 223, CAST(N'2015-09-30' AS Date), CAST(3.672790 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2c84d04c-9375-4d43-a089-ed22c8d26414', 223, CAST(N'2015-10-31' AS Date), CAST(3.672939 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'58d274dd-1b9e-4869-90ab-1fdc4f0476bc', 223, CAST(N'2015-11-30' AS Date), CAST(3.672925 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'71135990-501a-4bea-9ff2-4e2e02f61791', 223, CAST(N'2015-12-31' AS Date), CAST(3.672937 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'44b6d243-ed0f-4926-a13c-c99c395ddd1f', 223, CAST(N'2016-01-31' AS Date), CAST(3.672884 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aceab483-82d5-4dd2-ac66-efe7b1e05507', 223, CAST(N'2016-02-29' AS Date), CAST(3.673010 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'621fbc82-1cca-4f30-8941-9ea26a863d45', 223, CAST(N'2016-03-31' AS Date), CAST(3.672985 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da17cd42-5bad-41b8-8e5f-ca9b4d827355', 223, CAST(N'2016-04-30' AS Date), CAST(3.673035 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b5cec0b-e5d3-4dca-8543-c84756c17197', 223, CAST(N'2016-05-31' AS Date), CAST(3.672995 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b46198a-6b62-42f2-9442-01d6b7e3ae4d', 223, CAST(N'2016-06-30' AS Date), CAST(3.672997 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9830652-797e-4d84-9e7d-8d1b2e78bb9e', 223, CAST(N'2016-07-31' AS Date), CAST(3.672971 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1cc23e2c-4263-4dd1-94dd-7a621c2debc2', 223, CAST(N'2016-08-31' AS Date), CAST(3.673006 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'28090b1c-a7eb-4b91-a16c-484e995d9998', 223, CAST(N'2016-09-30' AS Date), CAST(3.673023 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41d0a2af-929a-4356-9080-e838a36bd24a', 223, CAST(N'2016-10-31' AS Date), CAST(3.673019 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41848c83-0df7-4243-ad5c-804aef5451cc', 223, CAST(N'2016-11-30' AS Date), CAST(3.673022 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b0a98a2a-e3bd-4488-9268-f079dad2ff3b', 223, CAST(N'2016-12-31' AS Date), CAST(3.672884 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0eddf50c-45d8-4143-84d2-0ded3e8d9d70', 223, CAST(N'2017-01-31' AS Date), CAST(3.673006 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0ced5711-f52e-4b85-a8ac-cc02c53077b4', 223, CAST(N'2017-02-28' AS Date), CAST(3.672882 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4ac6353c-23f4-4dba-950c-f2f84ce13caf', 223, CAST(N'2017-03-31' AS Date), CAST(3.672890 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'05735e2c-480a-480a-810d-d5ee4c25f771', 223, CAST(N'2017-04-30' AS Date), CAST(3.672972 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f79ed3a2-e9bb-41a5-8570-05dc37e6f60b', 223, CAST(N'2017-05-31' AS Date), CAST(3.672945 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e591982f-2d68-4064-85f7-3012a4817ea1', 223, CAST(N'2017-06-30' AS Date), CAST(3.672992 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be8366fe-e201-45a2-8397-681030743903', 223, CAST(N'2017-07-31' AS Date), CAST(3.673003 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'39f4a080-8afb-4ab4-a3ea-0747ca4e1a60', 223, CAST(N'2017-08-31' AS Date), CAST(3.673005 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82d0b37c-5b08-4c6b-9348-278c978b6066', 223, CAST(N'2017-09-30' AS Date), CAST(3.672963 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2326ef1c-dd2b-4dae-a997-3e590c8925b8', 223, CAST(N'2017-10-31' AS Date), CAST(3.672932 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fb6e319c-7ddf-40a9-ab02-a093ca722d81', 223, CAST(N'2017-11-30' AS Date), CAST(3.672917 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81128c77-078a-40dc-b3cc-c4d9de2be736', 223, CAST(N'2017-12-31' AS Date), CAST(3.672905 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d9b74e8-4037-4a6b-b27c-9a473ac1eccf', 223, CAST(N'2018-01-31' AS Date), CAST(3.672982 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d20b03f-20d7-4141-bddc-a41ac9524127', 223, CAST(N'2018-02-28' AS Date), CAST(3.673055 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'965e7ed5-73ef-4946-9f88-dd342d5cbd72', 223, CAST(N'2018-03-31' AS Date), CAST(3.673043 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a4a49097-dcd9-4334-9199-0a0acc268706', 223, CAST(N'2018-04-30' AS Date), CAST(3.673023 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b165025e-95bd-4760-beff-ed76ccff73de', 223, CAST(N'2018-05-31' AS Date), CAST(3.673092 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'93155a8d-923f-4784-bba3-8c64ebddb37e', 223, CAST(N'2018-06-30' AS Date), CAST(3.673108 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c15824de-5a8a-41e9-b449-3466ef455bc5', 223, CAST(N'2018-07-31' AS Date), CAST(3.673100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'50da0383-2eaf-43f2-b907-2723de558a5e', 223, CAST(N'2018-08-31' AS Date), CAST(3.673132 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cab35d4e-654f-4d04-ac95-153962edf53f', 223, CAST(N'2018-09-30' AS Date), CAST(3.673072 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eeaabbbb-0359-450c-a2dc-7a345b9eaa40', 223, CAST(N'2018-10-31' AS Date), CAST(3.673092 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef1ec97f-fa7b-4162-b00c-e292f9885b58', 223, CAST(N'2018-11-30' AS Date), CAST(3.673147 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5cd73ef7-f0cd-4f64-bb3f-f02f2b2aa6fd', 223, CAST(N'2018-12-31' AS Date), CAST(3.673084 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2fce447c-2f39-4a35-8d18-ff89b68c2363', 223, CAST(N'2019-01-31' AS Date), CAST(3.673126 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2f3c5e0-c682-4c56-a896-6d3ab432fa26', 223, CAST(N'2019-02-28' AS Date), CAST(3.673130 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3417ab61-2660-4373-83b3-cc5ccbbc2ab6', 223, CAST(N'2019-03-31' AS Date), CAST(3.673087 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'428f7507-5c7d-44f8-a02b-2ad04e86ec0e', 223, CAST(N'2019-04-30' AS Date), CAST(3.673086 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a982ab0b-ec8c-4b43-8bf0-954797bf975a', 223, CAST(N'2019-05-31' AS Date), CAST(3.673055 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42619302-cbd9-471c-acb1-e421d0af9feb', 223, CAST(N'2019-06-30' AS Date), CAST(3.673100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f012e66d-b619-4100-aeb9-45ef6b2c4ced', 223, CAST(N'2019-07-31' AS Date), CAST(3.673123 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b053f739-2760-4992-89a5-0eb7e0db637c', 223, CAST(N'2019-08-31' AS Date), CAST(3.673087 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c85ff059-96a1-4308-a3ba-bee6bbab7eea', 223, CAST(N'2019-09-30' AS Date), CAST(3.673073 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6c6583fa-9b2c-455c-9353-15cf9127b165', 223, CAST(N'2019-10-31' AS Date), CAST(3.673033 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a876c2f3-725d-4d08-91b4-ab2f950c3902', 223, CAST(N'2019-11-30' AS Date), CAST(3.672871 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'007a4156-1ee9-4f04-89df-e41de4e4f0f7', 223, CAST(N'2019-12-31' AS Date), CAST(3.673012 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'60796e9d-3a6f-40d8-9f67-de32470881a1', 223, CAST(N'2020-01-31' AS Date), CAST(3.673044 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2a7271fd-45b5-464f-8ced-f32261244561', 223, CAST(N'2020-02-29' AS Date), CAST(3.673013 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27a0079b-e48d-4122-ba13-b4a9932ccba5', 177, CAST(N'2000-02-29' AS Date), CAST(28.708931 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e592adcd-9b68-4f3d-b099-8b461cc773cf', 177, CAST(N'2000-03-31' AS Date), CAST(28.440335 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23c76287-1f7f-4b7f-a414-fb1d2b97abe6', 177, CAST(N'2000-04-30' AS Date), CAST(28.579454 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f86b508-eee6-47c1-af2e-0fb4d6045479', 177, CAST(N'2000-05-31' AS Date), CAST(28.312549 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5dc6b0bd-78a6-4db8-b84e-cc426380d471', 177, CAST(N'2000-06-30' AS Date), CAST(28.223541 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5382df33-f748-4b26-bdf6-4759f504e203', 177, CAST(N'2000-07-31' AS Date), CAST(27.830600 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c9a8b00-b254-48f5-b310-8d70ac446ab2', 177, CAST(N'2000-08-31' AS Date), CAST(27.736296 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd3247bf4-2c3a-4ecf-b3a6-8c1f81ef9dee', 177, CAST(N'2000-09-30' AS Date), CAST(27.794515 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'421924ea-4f0c-42e7-94d8-eba7afa830d4', 177, CAST(N'2000-10-31' AS Date), CAST(27.872771 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6e05f18-b38b-4eab-b3e6-7b2408f276f9', 177, CAST(N'2000-11-30' AS Date), CAST(27.844160 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc6dbd6f-ace9-4b83-8f18-f63bf247b536', 177, CAST(N'2000-12-31' AS Date), CAST(28.020804 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'51892c88-7176-4a98-8cc8-e988d8995502', 177, CAST(N'2001-01-31' AS Date), CAST(28.387965 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09b6b5db-541c-458a-9411-23ef4b3e941a', 177, CAST(N'2001-02-28' AS Date), CAST(28.631102 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bbe1faa1-6dd3-4a75-9bfe-b1d2ef06ff7e', 177, CAST(N'2001-03-31' AS Date), CAST(28.706315 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b7e96a7-4420-468a-825b-546266f5d50a', 177, CAST(N'2001-04-30' AS Date), CAST(28.882453 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b65f3b0e-d1e6-4d79-94d2-c98188164e3c', 177, CAST(N'2001-05-31' AS Date), CAST(29.035109 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43b4ce67-09bc-4b67-bef4-ae390fd730a9', 177, CAST(N'2001-06-30' AS Date), CAST(29.140048 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca23cae1-4875-403a-8403-c1c7b547632a', 177, CAST(N'2001-07-31' AS Date), CAST(29.232368 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e16d6f85-ee14-413f-ac18-e51807b7bea6', 177, CAST(N'2001-08-31' AS Date), CAST(29.354082 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6d3f787e-9f0f-432e-8aa2-19460c394f93', 177, CAST(N'2001-09-30' AS Date), CAST(29.451210 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4ea86b0-41d9-49f6-99c6-7c0a57cb2da5', 177, CAST(N'2001-10-31' AS Date), CAST(29.555301 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'110eb0c9-7b80-4e85-ba33-5de71492f21e', 177, CAST(N'2001-11-30' AS Date), CAST(29.816105 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76c20b18-6329-49b9-83a0-f04570acee8b', 177, CAST(N'2001-12-31' AS Date), CAST(30.101760 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02a5c9fa-80dc-4268-bdd3-cc8b3b7c3bc9', 177, CAST(N'2002-01-31' AS Date), CAST(30.573637 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'629f492f-0d05-4628-8634-5041ce377105', 177, CAST(N'2002-02-28' AS Date), CAST(30.844000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4d704ce4-5ea9-4910-a466-005764e611b7', 177, CAST(N'2002-03-31' AS Date), CAST(31.101001 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82d8b7f8-fb16-4e4a-8969-7b891047cade', 177, CAST(N'2002-04-30' AS Date), CAST(31.202046 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9ced630-00d2-4843-8976-0473f9af9de0', 177, CAST(N'2002-05-31' AS Date), CAST(31.274044 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e81edaa2-0291-4ab7-b795-b4df75380b5c', 177, CAST(N'2002-06-30' AS Date), CAST(31.430685 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ffbcb825-bddb-415b-a8a9-f8fb3fd68824', 177, CAST(N'2002-07-31' AS Date), CAST(31.543650 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd219ef51-9730-4ae4-8eea-d9d776f6af15', 177, CAST(N'2002-08-31' AS Date), CAST(31.583023 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a4acbaa9-7ed8-4835-bad7-85e6103c835a', 177, CAST(N'2002-09-30' AS Date), CAST(31.653000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3c8e2f3-fdfd-4861-a53c-03568a695cdf', 177, CAST(N'2002-10-31' AS Date), CAST(31.720227 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c57ab09-5d61-4c7d-8e94-a33ce64b8f8f', 177, CAST(N'2002-11-30' AS Date), CAST(31.834210 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6ac113bd-1ce4-43e8-a9ad-e3892eb820e3', 177, CAST(N'2002-12-31' AS Date), CAST(31.855667 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6fb4d42-0338-4293-83c4-76a318f69efb', 177, CAST(N'2003-01-31' AS Date), CAST(31.842222 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e5f54630-88d9-4022-b12b-3800eb4e5bcb', 177, CAST(N'2003-02-28' AS Date), CAST(31.682368 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ea372ef5-1c26-45e7-8515-e4f120f82bf0', 177, CAST(N'2003-03-31' AS Date), CAST(31.476071 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'149e00b0-e046-42af-bb15-115d5013966a', 177, CAST(N'2003-04-30' AS Date), CAST(31.225000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'daca68da-43a1-4174-ac40-19a72890f71d', 177, CAST(N'2003-05-31' AS Date), CAST(30.918000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e9f32645-8f6f-4f47-8007-786c46f83f7a', 177, CAST(N'2003-06-30' AS Date), CAST(30.502500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f6d58921-7a90-48b4-9a52-a2dcbcbf3855', 177, CAST(N'2003-07-31' AS Date), CAST(30.355000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1689a865-beed-4db0-9f89-d05a7579a186', 177, CAST(N'2003-08-31' AS Date), CAST(30.357632 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7836971d-27d7-4382-a565-98baac499ae1', 177, CAST(N'2003-09-30' AS Date), CAST(30.593077 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2e4bec2-d3bb-47b3-a11a-b45c888a2b18', 177, CAST(N'2003-10-31' AS Date), CAST(30.110000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1f0a5c09-ce33-4db7-9dff-01ba2f71e163', 177, CAST(N'2003-11-30' AS Date), CAST(29.811316 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b20de62c-ef6c-4921-b28a-bec4dd5427a1', 177, CAST(N'2003-12-31' AS Date), CAST(29.454444 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fd0e2fab-eb42-485c-976d-c8ef3d3d037d', 177, CAST(N'2004-01-31' AS Date), CAST(28.877222 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'63e84fca-a330-4b5a-be8e-e74968696648', 177, CAST(N'2004-02-29' AS Date), CAST(28.503125 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ac54f963-6120-4b36-8879-aa879945cd58', 177, CAST(N'2004-03-31' AS Date), CAST(28.539250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f024344d-e7cd-4773-b47b-492d469e0e07', 177, CAST(N'2004-04-30' AS Date), CAST(28.670353 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e65b292c-c718-4cab-821a-74452f9de339', 177, CAST(N'2004-05-31' AS Date), CAST(28.992106 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'31ca0c55-ab02-459a-b178-786bc9e2ba23', 177, CAST(N'2004-06-30' AS Date), CAST(29.029250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fdfd9240-8324-4f92-b97f-af1c7ede2825', 177, CAST(N'2004-07-31' AS Date), CAST(29.082668 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c0ae5e2c-b32d-4c7b-b3f4-1c98fe5b4a14', 177, CAST(N'2004-08-31' AS Date), CAST(29.212608 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'399c0ab2-2bb0-4adb-a016-0bd7b5ef71ab', 177, CAST(N'2004-09-30' AS Date), CAST(29.221500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ea649f4e-306c-4067-a611-475eb96b92f0', 177, CAST(N'2004-10-31' AS Date), CAST(27.893166 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fce7a5c5-0379-43d7-aeb1-acae55567615', 177, CAST(N'2004-11-30' AS Date), CAST(28.603636 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae195e26-4326-45ea-bafb-61eec5e1b835', 177, CAST(N'2004-12-31' AS Date), CAST(27.799895 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'400a45b9-4453-4980-81c3-b4d57fa78b9e', 177, CAST(N'2005-01-31' AS Date), CAST(27.943688 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'83ccdef9-fafe-4197-a49b-95616b105050', 177, CAST(N'2005-02-28' AS Date), CAST(27.984619 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'10a91a5e-f50f-4701-818e-f69925f929a7', 177, CAST(N'2005-03-31' AS Date), CAST(27.627081 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'398eeb19-0bae-4b37-86dd-48b3644d733f', 177, CAST(N'2005-04-30' AS Date), CAST(27.822310 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'235e99f6-7476-4e93-9537-62ca0150e32e', 177, CAST(N'2005-05-31' AS Date), CAST(27.944787 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'36167bc4-2bc1-4ca7-9adc-356e0d857892', 177, CAST(N'2005-06-30' AS Date), CAST(28.413622 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'83c84ed9-fd5e-4770-bfbb-5ddd2288b84d', 177, CAST(N'2005-07-31' AS Date), CAST(28.689693 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9e4324e6-a267-4d55-bf0f-10e281670a93', 177, CAST(N'2005-08-31' AS Date), CAST(27.435518 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'acb48182-df60-455f-b887-3c885f8c8d41', 177, CAST(N'2005-09-30' AS Date), CAST(28.372548 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f26541cb-063a-4e98-8fb9-0f496e5752b8', 177, CAST(N'2005-10-31' AS Date), CAST(28.547527 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'995f48fa-3a49-429f-990b-6bf45c8169ec', 177, CAST(N'2005-11-30' AS Date), CAST(28.775084 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'461f0feb-06be-4d84-80d6-aab174bce158', 177, CAST(N'2005-12-31' AS Date), CAST(28.813534 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'70ef134a-d90c-4dfa-ae0a-c1b579326b8d', 177, CAST(N'2006-01-31' AS Date), CAST(28.404370 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6254fd6b-7c99-4846-8732-fec9565168e1', 177, CAST(N'2006-02-28' AS Date), CAST(28.230892 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ea0f51a-7261-4c72-bff7-a5beb302f098', 177, CAST(N'2006-03-31' AS Date), CAST(27.924749 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'28ea6b0c-0a70-4fd7-ba7d-b66cbdbb4926', 177, CAST(N'2006-04-30' AS Date), CAST(27.538295 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c1f06077-4ad1-481c-9e56-2f9ac179e49c', 177, CAST(N'2006-05-31' AS Date), CAST(27.061056 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'24b9748b-c261-4fc1-8033-17f7b2376d52', 177, CAST(N'2006-06-30' AS Date), CAST(27.022304 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c33fcb8c-0b1c-4928-88a5-ce0f2cafbb56', 177, CAST(N'2006-07-31' AS Date), CAST(26.900521 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a57417b2-9d52-4ce9-a29b-0c0478f547a9', 177, CAST(N'2006-08-31' AS Date), CAST(26.764945 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7e55fa7e-c992-4255-b1f5-4a5fbdaab5ae', 177, CAST(N'2006-09-30' AS Date), CAST(26.753690 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cc8ee889-ca57-4b37-9021-4abf06477335', 177, CAST(N'2006-10-31' AS Date), CAST(26.852741 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f16be384-9828-4655-8489-d85e25514e13', 177, CAST(N'2006-11-30' AS Date), CAST(26.612690 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b690695b-1066-4734-939d-6af42f1054f5', 177, CAST(N'2006-12-31' AS Date), CAST(26.292222 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cb6feee7-d872-4e0f-94c9-03bdfe498525', 177, CAST(N'2007-01-31' AS Date), CAST(26.503371 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ceb02a55-4058-4a5b-b3ff-1c11d9edc949', 177, CAST(N'2007-02-28' AS Date), CAST(26.340533 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'79dceb99-c14f-465d-8d60-7b4e79ef3db0', 177, CAST(N'2007-03-31' AS Date), CAST(26.115583 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a4184058-b955-4006-93dd-9c98d7810fc7', 177, CAST(N'2007-04-30' AS Date), CAST(25.845288 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9ea566b2-d186-443d-9f04-2f6c8bda19ab', 177, CAST(N'2007-05-31' AS Date), CAST(25.826349 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94c3d8f3-c48a-4b2f-aa84-dd20c2bc19de', 177, CAST(N'2007-06-30' AS Date), CAST(25.931375 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aea0c06b-283e-4cf9-bfe2-9f917ef8ec11', 177, CAST(N'2007-07-31' AS Date), CAST(25.531974 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3d1fe457-bb84-43dc-b1c8-d8b472e9a64a', 177, CAST(N'2007-08-31' AS Date), CAST(25.643325 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4631b9b1-a5ca-4047-821d-90efbf130e03', 177, CAST(N'2007-09-30' AS Date), CAST(25.332652 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df72a425-eaa2-440e-bcef-282e4cfb33e1', 177, CAST(N'2007-10-31' AS Date), CAST(24.894065 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b1e8642-314a-4e89-a508-5d69e8673b13', 177, CAST(N'2007-11-30' AS Date), CAST(24.474236 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0505b81c-8ca1-43fc-83f3-0b7896f21f79', 177, CAST(N'2007-12-31' AS Date), CAST(24.581590 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ee551fae-8436-4744-81cc-03890b1b1428', 177, CAST(N'2008-01-31' AS Date), CAST(24.486196 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7a181623-1c61-40eb-94b8-fe0713fd49d1', 177, CAST(N'2008-02-29' AS Date), CAST(24.527405 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16cb060c-4ad3-43e0-9bea-47da28cd0235', 177, CAST(N'2008-03-31' AS Date), CAST(23.747714 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e222362f-7022-48ca-92aa-18940ebd6b87', 177, CAST(N'2008-04-30' AS Date), CAST(23.503021 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9ed5a14f-9b80-4602-8f6e-d20e19c02374', 177, CAST(N'2008-05-31' AS Date), CAST(23.716870 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'de5af7d3-04fb-42c5-a315-e39d09428adf', 177, CAST(N'2008-06-30' AS Date), CAST(23.654993 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'925e286e-fb68-4e14-81e0-b10c98514b1e', 177, CAST(N'2008-07-31' AS Date), CAST(23.368661 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f488c008-fec1-4415-a82b-ab8c5aac89ab', 177, CAST(N'2008-08-31' AS Date), CAST(24.183832 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0655bb2-0c18-4cfd-b4a4-8d333fb84c6e', 177, CAST(N'2008-09-30' AS Date), CAST(25.268803 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a29db748-e80c-4cc3-8833-316a850b8819', 177, CAST(N'2008-10-31' AS Date), CAST(26.372571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e0892ec7-ad80-49f0-92be-4863b07ee5d4', 177, CAST(N'2008-11-30' AS Date), CAST(27.274805 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'26bf76a2-0f42-480d-a2ec-fad6595fe476', 177, CAST(N'2008-12-31' AS Date), CAST(28.070565 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c1e9beb-167b-4362-902f-bd900f403cd6', 177, CAST(N'2009-01-31' AS Date), CAST(31.523029 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f84b1d4c-71cf-49bb-bcfd-5695bbd33897', 177, CAST(N'2009-02-28' AS Date), CAST(35.750863 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f1d52daf-2e6c-4b57-b3a5-e97c3427b425', 177, CAST(N'2009-03-31' AS Date), CAST(34.705273 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ec10502-c0e4-41b1-bc46-d9685a9dd017', 177, CAST(N'2009-04-30' AS Date), CAST(33.560241 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7231dc08-f5be-42f7-b16b-f60879927f6f', 177, CAST(N'2009-05-31' AS Date), CAST(31.982069 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9e73706c-0d5d-42a8-9073-d99efbd090b9', 177, CAST(N'2009-06-30' AS Date), CAST(31.052854 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'402e40b4-5074-4268-b240-59ff2d6539de', 177, CAST(N'2009-07-31' AS Date), CAST(31.516703 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c06b4e6-3c5b-443c-ba09-365134d20def', 177, CAST(N'2009-08-31' AS Date), CAST(31.665291 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da95ab90-f51d-424f-9999-b3375cc92158', 177, CAST(N'2009-09-30' AS Date), CAST(30.786152 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cb52c38d-8bcd-43e9-84dd-5e00685863a7', 177, CAST(N'2009-10-31' AS Date), CAST(29.495439 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'18744c5f-64c5-41ce-a3b2-e78df7e40364', 177, CAST(N'2009-11-30' AS Date), CAST(28.985637 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f43dc74-b319-451c-9267-9f23149add53', 177, CAST(N'2009-12-31' AS Date), CAST(29.964830 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'64fec393-0e9e-40b9-9b01-1577b547601c', 177, CAST(N'2010-01-31' AS Date), CAST(29.921697 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a752b5db-4828-4a5d-8934-9c6552b126bf', 177, CAST(N'2010-02-28' AS Date), CAST(30.161175 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'141ddb05-ed79-4d3e-86ac-eb84ece7ac76', 177, CAST(N'2010-03-31' AS Date), CAST(29.567827 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4d7e8697-6456-410c-8714-503c8c5b2e75', 177, CAST(N'2010-04-30' AS Date), CAST(29.182062 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f0679260-fe57-44ee-b305-b60368af41f1', 177, CAST(N'2010-05-31' AS Date), CAST(30.408620 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c6b016be-4a5c-4114-9f19-8f147a359295', 177, CAST(N'2010-06-30' AS Date), CAST(31.268003 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dc1b2e55-4be7-474a-b88f-d6e88ec23585', 177, CAST(N'2010-07-31' AS Date), CAST(30.645382 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3fd03543-8659-44e8-9503-0903c0367a0f', 177, CAST(N'2010-08-31' AS Date), CAST(30.366281 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'60a7cfd5-1841-4626-ab9c-8a36a330b60f', 177, CAST(N'2010-09-30' AS Date), CAST(30.815110 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85106505-0426-4eea-8a4f-b1734f6afda7', 177, CAST(N'2010-10-31' AS Date), CAST(30.319032 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'34fa84e9-2e85-4613-bfa8-8c8c3182cf9d', 177, CAST(N'2010-11-30' AS Date), CAST(30.946334 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b7dada23-3dab-4916-81c4-3f4a45f72dd8', 177, CAST(N'2010-12-31' AS Date), CAST(30.833828 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'975945d3-62a0-4aef-bf14-8f2ce3091813', 177, CAST(N'2011-01-31' AS Date), CAST(30.179439 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f372566f-3870-43c7-a3ea-f35183bc7014', 177, CAST(N'2011-02-28' AS Date), CAST(29.284807 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf3d46bd-4442-4149-8e9d-aa759cace148', 177, CAST(N'2011-03-31' AS Date), CAST(28.423700 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c35d6cc-454d-49b4-b73e-8b31e90429dc', 177, CAST(N'2011-04-30' AS Date), CAST(28.074920 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bcac1be3-9070-4dcc-96f1-da8e297b19a6', 177, CAST(N'2011-05-31' AS Date), CAST(27.917116 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ba75aff-de0a-45a6-9f0f-fc29ab7cc976', 177, CAST(N'2011-06-30' AS Date), CAST(27.993597 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6652c7f-c710-4ea0-8435-9a9bf0f4c58e', 177, CAST(N'2011-07-31' AS Date), CAST(27.897126 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f4ec9a66-937c-420b-a401-8663f4c4631a', 177, CAST(N'2011-08-31' AS Date), CAST(28.752152 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21480c47-d94b-4883-98b7-0a5f01e30973', 177, CAST(N'2011-09-30' AS Date), CAST(30.588460 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'320454f2-649d-4bb7-ac99-27d419e66873', 177, CAST(N'2011-10-31' AS Date), CAST(31.318797 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'04dea416-c46e-49f1-aa74-7e7f938812f6', 177, CAST(N'2011-11-30' AS Date), CAST(30.859829 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2806f320-6250-4c03-b9f0-179a37a76ac9', 177, CAST(N'2011-12-31' AS Date), CAST(31.497584 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4a6c339-c286-4f88-8a3b-2d24627b6ffd', 177, CAST(N'2012-01-31' AS Date), CAST(31.413848 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0b1713a8-4511-4ad9-beb5-886bc1af42e7', 177, CAST(N'2012-02-29' AS Date), CAST(29.832072 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fa28af17-9f7a-4f73-aa0c-8f40e92fb2e5', 177, CAST(N'2012-03-31' AS Date), CAST(29.339442 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'79974a2c-7b5a-4cf3-ba64-036a981f955a', 177, CAST(N'2012-04-30' AS Date), CAST(29.467496 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0e3f8c1b-bce5-49f1-86c2-0f1030051909', 177, CAST(N'2012-05-31' AS Date), CAST(30.774761 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d4bc462-2a2f-48ca-aa38-acd7407039fc', 177, CAST(N'2012-06-30' AS Date), CAST(32.855237 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ce0b20f-99c2-46da-a2dd-60725b90b46c', 177, CAST(N'2012-07-31' AS Date), CAST(32.476250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7dc51bee-661d-4b37-b9fd-eb2adcb9cd49', 177, CAST(N'2012-08-31' AS Date), CAST(31.939558 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16c7459f-0dc7-4cc0-8116-3468680c20b4', 177, CAST(N'2012-09-30' AS Date), CAST(31.411810 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c69b00f-b2b7-4313-b80c-a8f710cfb76f', 177, CAST(N'2012-10-31' AS Date), CAST(31.121716 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c498a0b-3aa5-4418-91d7-5901b75a7cfa', 177, CAST(N'2012-11-30' AS Date), CAST(31.405317 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f73e0439-4f7a-4d13-9614-480a6fbe095a', 177, CAST(N'2012-12-31' AS Date), CAST(30.722605 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'afbe3dd3-91c9-446f-8739-751611d49b01', 177, CAST(N'2013-01-31' AS Date), CAST(30.236821 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'64f70098-71d9-4539-a3ae-b59c75b8b7ee', 177, CAST(N'2013-02-28' AS Date), CAST(30.169854 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a867a89b-e766-442b-9990-8f9a051f4c10', 177, CAST(N'2013-03-31' AS Date), CAST(30.809110 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7df02ad1-7860-4947-adef-1bd11b74a106', 177, CAST(N'2013-04-30' AS Date), CAST(31.341603 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'53a404ba-f2dd-4f23-9a34-b86de791057b', 177, CAST(N'2013-05-31' AS Date), CAST(31.309494 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e81ab69e-0f43-4dfe-b9e2-5d733541ccef', 177, CAST(N'2013-06-30' AS Date), CAST(32.295302 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'321b5308-6449-403f-b32a-c48d51d730ae', 177, CAST(N'2013-07-31' AS Date), CAST(32.770573 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c6003d8-1f49-4389-ab8e-dd225902c3b4', 177, CAST(N'2013-08-31' AS Date), CAST(32.991723 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ab0f732-0a78-4891-beec-ef8ff9845168', 177, CAST(N'2013-09-30' AS Date), CAST(32.598663 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'689450d0-4f21-4c5a-bb8b-e6a286c7ed11', 177, CAST(N'2013-10-31' AS Date), CAST(32.066015 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'14666a6d-c9da-44a1-b4fe-06ae61523165', 177, CAST(N'2013-11-30' AS Date), CAST(32.694810 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ffae5af3-c465-4be2-b478-23f8bde8f5dc', 177, CAST(N'2013-12-31' AS Date), CAST(32.862008 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f507c2f0-e8c2-435c-99e9-8e680b2da2b4', 177, CAST(N'2014-01-31' AS Date), CAST(33.659297 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f5d1df89-1bdf-48d2-9490-bddaed2895cc', 177, CAST(N'2014-02-28' AS Date), CAST(35.236450 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'19481f61-7190-49ca-9429-c6313df38d54', 177, CAST(N'2014-03-31' AS Date), CAST(36.183432 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'86c0773f-109c-417e-9c6e-0781150c24b3', 177, CAST(N'2014-04-30' AS Date), CAST(35.647742 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0b9ad6d-f94d-48b1-b36c-e03234e37e3d', 177, CAST(N'2014-05-31' AS Date), CAST(34.902584 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'668e575f-b802-4ac4-b0f1-b5866399763b', 177, CAST(N'2014-06-30' AS Date), CAST(34.395337 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02fa061b-a006-4233-9df8-07fdb0b04e00', 177, CAST(N'2014-07-31' AS Date), CAST(34.688655 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3fbf3206-4d17-4122-9e0f-400652ea54ce', 177, CAST(N'2014-08-31' AS Date), CAST(36.148942 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'51856f09-6f95-451a-8873-1e01a2daca9c', 177, CAST(N'2014-09-30' AS Date), CAST(37.917211 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e0caefeb-0673-4443-a0e7-86d2e0bea741', 177, CAST(N'2014-10-31' AS Date), CAST(40.618416 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f79eac86-d0fe-429c-b2a2-b087e1c21e63', 177, CAST(N'2014-11-30' AS Date), CAST(46.161420 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'78ace215-fd57-4607-a982-91b0061b4391', 177, CAST(N'2014-12-31' AS Date), CAST(56.157344 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bab58d9e-e753-4cdd-a2e8-1b3b638a45f1', 177, CAST(N'2015-01-31' AS Date), CAST(64.164871 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6c5068b-368b-4a79-b115-bb8c06ca3e2c', 177, CAST(N'2015-02-28' AS Date), CAST(64.639004 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'748afd54-4e63-4d4d-b523-dfcac5ccde99', 177, CAST(N'2015-03-31' AS Date), CAST(60.278965 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eeb32e57-271c-4361-ac80-7e3c736703ed', 177, CAST(N'2015-04-30' AS Date), CAST(53.128617 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c846a47-8653-4bb9-ba52-eec9b37abc40', 177, CAST(N'2015-05-31' AS Date), CAST(50.715074 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48837f32-67f1-4a3a-907e-f701e67833d7', 177, CAST(N'2015-06-30' AS Date), CAST(54.656780 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b680b8e1-6d22-4417-a91b-5d94eb17f58a', 177, CAST(N'2015-07-31' AS Date), CAST(57.128965 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'282391c6-efd6-43a4-8122-cb9cd0b6885a', 177, CAST(N'2015-08-31' AS Date), CAST(65.296271 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00c9553a-a6ff-4c80-999b-5c8eb25eeb7c', 177, CAST(N'2015-09-30' AS Date), CAST(66.762337 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'67f09c5a-dae4-4993-8dfa-0bb13a11f9af', 177, CAST(N'2015-10-31' AS Date), CAST(63.110719 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c3e0a3f-14c9-4d16-87b9-d6e33719a4f0', 177, CAST(N'2015-11-30' AS Date), CAST(65.090250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a051308-0535-41b8-9132-ddfb8381364d', 177, CAST(N'2015-12-31' AS Date), CAST(69.817900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ddd50086-6bd6-4310-bf1b-faabd74dea4e', 177, CAST(N'2016-01-31' AS Date), CAST(76.652373 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7103fa1-5648-4ef3-97a2-fa94a177d634', 177, CAST(N'2016-02-29' AS Date), CAST(77.201362 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae6c4d3e-ac1d-4ceb-865e-8bb8f4d93f70', 177, CAST(N'2016-03-31' AS Date), CAST(70.145223 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08f416b9-7101-4003-b60b-e363d341d930', 177, CAST(N'2016-04-30' AS Date), CAST(66.662880 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ee1cd07e-7a69-4499-aaa0-8162f9b030fe', 177, CAST(N'2016-05-31' AS Date), CAST(65.901432 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'62352b3e-6e66-4e5e-940d-d21ca27e27bd', 177, CAST(N'2016-06-30' AS Date), CAST(65.151632 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd1e7574e-1393-43ff-9cba-34942acdf97e', 177, CAST(N'2016-07-31' AS Date), CAST(64.331976 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'384000d7-c334-47f5-a76f-383ab10ca374', 177, CAST(N'2016-08-31' AS Date), CAST(64.873918 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0474213f-f74b-4a3d-8eab-37c5c65465d1', 177, CAST(N'2016-09-30' AS Date), CAST(64.653557 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2467791-b923-4702-a520-46c630d8eb25', 177, CAST(N'2016-10-31' AS Date), CAST(62.634576 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a10e360c-939d-42bb-939c-b2222f70e4b7', 177, CAST(N'2016-11-30' AS Date), CAST(64.622698 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17ec0b01-82cd-4e68-aaed-038b6f4e74e0', 177, CAST(N'2016-12-31' AS Date), CAST(61.999373 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f7c8f14-8c90-479d-9068-11c3f2e55c43', 177, CAST(N'2017-01-31' AS Date), CAST(59.859065 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ee79d6ea-9773-4c1a-82a3-c841268da527', 177, CAST(N'2017-02-28' AS Date), CAST(58.476534 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6828911c-dc4b-4203-8af9-becc24c5daac', 177, CAST(N'2017-03-31' AS Date), CAST(57.868139 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0b077adb-f38e-4117-823c-514c7d84e971', 177, CAST(N'2017-04-30' AS Date), CAST(56.574129 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6dce09e3-e7ad-4d24-acf2-02eeeb2af167', 177, CAST(N'2017-05-31' AS Date), CAST(57.097710 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13298040-9a92-4c0e-84d4-e115b461a570', 177, CAST(N'2017-06-30' AS Date), CAST(57.965097 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df6b1eb2-ef6b-4f75-9674-81263d9f4c01', 177, CAST(N'2017-07-31' AS Date), CAST(59.604200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27dea623-a00a-42b6-b343-5e8de1179547', 177, CAST(N'2017-08-31' AS Date), CAST(59.420468 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a21ba300-7dd3-4e63-b2a4-a238e65b8487', 177, CAST(N'2017-09-30' AS Date), CAST(57.637898 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8d624d9-da75-48ab-a9ae-6341fe7290eb', 177, CAST(N'2017-10-31' AS Date), CAST(57.754797 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'26ab0232-1fde-469b-9c32-2a797595972e', 177, CAST(N'2017-11-30' AS Date), CAST(58.954407 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ffb15c0f-6584-4d27-ab0f-3355d35e9d02', 177, CAST(N'2017-12-31' AS Date), CAST(58.570460 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'958bfe16-a3ad-4211-86f1-a72d8476e038', 177, CAST(N'2018-01-31' AS Date), CAST(56.665863 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2bf9ef0a-d538-4f98-9ffc-8d1326d37f3f', 177, CAST(N'2018-02-28' AS Date), CAST(56.853434 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d9d39ed-2fff-458a-86ec-e05f80db98ba', 177, CAST(N'2018-03-31' AS Date), CAST(57.031055 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a237c359-5c53-4953-8461-be033931a3e9', 177, CAST(N'2018-04-30' AS Date), CAST(60.790367 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9fb51618-a88a-4151-912f-b258cc9ad16b', 177, CAST(N'2018-05-31' AS Date), CAST(62.329561 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'92d1c448-cd7d-45a7-9c77-0db8f961ee84', 177, CAST(N'2018-06-30' AS Date), CAST(62.769243 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'98eec2f0-d015-4ef0-a4c8-5ace75a2e5d6', 177, CAST(N'2018-07-31' AS Date), CAST(62.856465 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c428cfce-b99e-4b05-a112-849e9ccb4154', 177, CAST(N'2018-08-31' AS Date), CAST(66.444490 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'97c264c4-ded0-4427-ae2d-9d81862fc9ae', 177, CAST(N'2018-09-30' AS Date), CAST(67.638770 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f40ce59b-be6d-4966-92a5-9bc01a7fef35', 177, CAST(N'2018-10-31' AS Date), CAST(65.872226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94b5d057-3b1e-4ed5-9327-63dffcee2525', 177, CAST(N'2018-11-30' AS Date), CAST(66.543107 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f823d6f-a330-40d3-90ef-5b9aacf7aaaa', 177, CAST(N'2018-12-31' AS Date), CAST(67.618687 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6d15ed1b-3bd4-424b-abb2-348a00bd2648', 177, CAST(N'2019-01-31' AS Date), CAST(66.735484 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4306604a-0b98-4c04-9546-9550e86a915e', 177, CAST(N'2019-02-28' AS Date), CAST(65.796420 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df1497ec-e7d6-4458-bf32-23e3c892e69a', 177, CAST(N'2019-03-31' AS Date), CAST(65.286129 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5697041b-7846-471e-8285-57a21166e7d4', 177, CAST(N'2019-04-30' AS Date), CAST(64.558909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'213ead9a-7df5-4405-95e6-454d1bcc1d48', 177, CAST(N'2019-05-31' AS Date), CAST(64.895081 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3628af1a-c9a2-4159-a59c-fa3cb384a37b', 177, CAST(N'2019-06-30' AS Date), CAST(64.123285 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e32c4285-f657-465b-a5ac-4ab539f61f8c', 177, CAST(N'2019-07-31' AS Date), CAST(63.251965 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a3fcf922-34a7-4be2-93aa-a760625cc3e1', 177, CAST(N'2019-08-31' AS Date), CAST(65.815248 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'286d0c77-995c-4dc7-a903-6782b5cfa7cc', 177, CAST(N'2019-09-30' AS Date), CAST(64.912503 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e6cc38de-1f8c-4c07-87e8-7b61506519c5', 177, CAST(N'2019-10-31' AS Date), CAST(64.293866 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43a008b7-8905-4711-8bb3-0fb2d444d80a', 177, CAST(N'2019-11-30' AS Date), CAST(63.850503 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3dd8bd58-2862-4d81-a4de-9d7525f9cc78', 177, CAST(N'2019-12-31' AS Date), CAST(62.856168 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dee82b51-ab83-4746-807b-aea4330c80d2', 177, CAST(N'2020-01-31' AS Date), CAST(61.902332 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'07cc5db9-93b3-41a6-a082-6929d4c5b6f1', 177, CAST(N'2020-02-29' AS Date), CAST(64.189053 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'80c65b99-d704-4088-813d-355dd96d77ef', 195, CAST(N'1990-01-31' AS Date), CAST(2.553190 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9a532645-32e6-40a4-b757-2f27a73122d0', 195, CAST(N'1990-02-28' AS Date), CAST(2.544868 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'37f45619-3b0b-41b6-8a09-b69b54f33c57', 195, CAST(N'1990-03-31' AS Date), CAST(2.615818 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41243aa6-6b36-411d-b4ee-fa17d8339974', 195, CAST(N'1990-04-30' AS Date), CAST(2.655160 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9cd8768b-170a-43bb-af43-55142a0aa9d4', 195, CAST(N'1990-05-31' AS Date), CAST(2.646782 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db0e98b5-cebc-45d6-b80e-9d1c4ab841de', 195, CAST(N'1990-06-30' AS Date), CAST(2.659238 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'015d02d9-40bc-494b-b759-52c0eb06030c', 195, CAST(N'1990-07-31' AS Date), CAST(2.625305 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd46409fc-dd64-4dda-be6d-08fad9246ba4', 195, CAST(N'1990-08-31' AS Date), CAST(2.573378 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'88f2d409-42e9-4665-82f1-7b361abd2167', 195, CAST(N'1990-09-30' AS Date), CAST(2.571158 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'009640f6-789f-4b42-8c86-08b786bacffb', 195, CAST(N'1990-10-31' AS Date), CAST(2.544523 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db10e144-6f70-4d77-ad6c-90338a0bec49', 195, CAST(N'1990-11-30' AS Date), CAST(2.524725 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30a577eb-b703-40a4-9d04-2bfceb3d1902', 195, CAST(N'1990-12-31' AS Date), CAST(2.539475 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ddb5f08-27b6-49ea-8b0c-8d76dc794500', 195, CAST(N'1991-01-31' AS Date), CAST(2.564262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8d5d79bd-1dba-4c22-ac6f-ab2f165a4ec9', 195, CAST(N'1991-02-28' AS Date), CAST(2.541237 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3ec7ebb2-0ed3-48d8-96eb-c9ff3874da1b', 195, CAST(N'1991-03-31' AS Date), CAST(2.663595 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d57f9ae-c08b-460b-9eb8-4e394a985415', 195, CAST(N'1991-04-30' AS Date), CAST(2.732477 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'422c0b2d-5274-462a-b555-2547c6c6bf46', 195, CAST(N'1991-05-31' AS Date), CAST(2.797455 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c4f940b-b09d-41ed-a098-9365220737d7', 195, CAST(N'1991-06-30' AS Date), CAST(2.862450 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'19cdbd9a-9cb8-4076-bbf4-ab8dfd59898e', 195, CAST(N'1991-07-31' AS Date), CAST(2.881909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e9e8f90c-eb80-47be-842d-90d70bec94c5', 195, CAST(N'1991-08-31' AS Date), CAST(2.870386 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43c976c1-87a4-4ec3-94e3-e76789013c3c', 195, CAST(N'1991-09-30' AS Date), CAST(2.831615 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5eaf5059-9c3a-4dbb-ad66-e0c17b2ecd5f', 195, CAST(N'1991-10-31' AS Date), CAST(2.831395 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'07e9cb7b-05c9-42b7-97ed-1a9f6f06c52f', 195, CAST(N'1991-11-30' AS Date), CAST(2.791605 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9a2a1092-4017-4dc8-8ddc-a5a3c1c7a817', 195, CAST(N'1991-12-31' AS Date), CAST(2.766475 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b40cc388-9b28-4db4-b053-21b403747425', 195, CAST(N'1992-01-31' AS Date), CAST(2.783119 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b669c292-dce4-4638-a388-51e9e5223fd4', 195, CAST(N'1992-02-29' AS Date), CAST(2.815632 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84d6132b-0baa-427a-a576-3e487a3379a0', 195, CAST(N'1992-03-31' AS Date), CAST(2.882955 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ebc612df-4102-4292-b8f6-36026328eea7', 195, CAST(N'1992-04-30' AS Date), CAST(2.878275 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23079802-7851-48e4-97a8-e712ceaa334f', 195, CAST(N'1992-05-31' AS Date), CAST(2.848250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b1cbbead-793f-49a2-9b9a-3857e930f9e1', 195, CAST(N'1992-06-30' AS Date), CAST(2.807682 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'25d75e1b-51b1-4389-9407-fd706b2f8550', 195, CAST(N'1992-07-31' AS Date), CAST(2.757717 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'99b3b581-e0f2-45e4-bc14-31ab85b6d36c', 195, CAST(N'1992-08-31' AS Date), CAST(2.762929 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e751df04-cccc-4d01-a621-fba14b3bd278', 195, CAST(N'1992-09-30' AS Date), CAST(2.803738 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'876d0255-fd12-4d99-8a43-cb1798cf9eb0', 195, CAST(N'1992-10-31' AS Date), CAST(2.892262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'83b41331-70bc-4bec-8482-a9b3b5bdfb2b', 195, CAST(N'1992-11-30' AS Date), CAST(2.995947 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f0418284-307b-4f3e-84c7-b6ff50730356', 195, CAST(N'1992-12-31' AS Date), CAST(3.013959 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f681adb8-2706-4f9c-80d5-2520318e8bef', 195, CAST(N'1993-01-31' AS Date), CAST(3.071263 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5510f1fe-7f03-44f4-8017-d28bec3aeae7', 195, CAST(N'1993-02-28' AS Date), CAST(3.120737 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'029f1855-78a9-4519-afed-aaaef329820f', 195, CAST(N'1993-03-31' AS Date), CAST(3.178957 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42b73d0b-07de-4086-ac66-6bba0e06c3d4', 195, CAST(N'1993-04-30' AS Date), CAST(3.171786 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c283612-b562-4a86-83c2-53426344d765', 195, CAST(N'1993-05-31' AS Date), CAST(3.178725 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1715994a-edad-4622-85ed-321f496458dd', 195, CAST(N'1993-06-30' AS Date), CAST(3.240841 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8eec2584-ada1-471d-894a-1c2734f6e041', 195, CAST(N'1993-07-31' AS Date), CAST(3.351833 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a75e7dc-03ff-4b6e-b12c-4493bf966f18', 195, CAST(N'1993-08-31' AS Date), CAST(3.366045 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48ba7129-f6a2-4b20-9154-004aca2232f0', 195, CAST(N'1993-09-30' AS Date), CAST(3.413452 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61b2ccc4-3ef5-42ea-ac83-ebc898b66fb0', 195, CAST(N'1993-10-31' AS Date), CAST(3.392450 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e5988254-efc5-48c4-8f72-519e5ccdfbb0', 195, CAST(N'1993-11-30' AS Date), CAST(3.367975 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dae40b23-ad18-4a1f-921b-4325b64de54d', 195, CAST(N'1993-12-31' AS Date), CAST(3.378783 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'18767772-32e9-487e-b214-71a8b774da59', 195, CAST(N'1994-01-31' AS Date), CAST(3.410650 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'25ec0c39-16e0-4e37-a5bd-4710390d3773', 195, CAST(N'1994-02-28' AS Date), CAST(3.452026 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f1ca2c54-f14a-4060-9f7a-176254c36a28', 195, CAST(N'1994-03-31' AS Date), CAST(3.458565 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ffe4d421-9e47-4de8-88b0-d6cce40dc345', 195, CAST(N'1994-04-30' AS Date), CAST(3.578909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a0027ada-f367-4f93-a3cf-c9dacf0aee02', 195, CAST(N'1994-05-31' AS Date), CAST(3.634619 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f897b15a-44cd-4dcf-b9a0-c7da709dec70', 195, CAST(N'1994-06-30' AS Date), CAST(3.631750 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd6f8db0c-82a2-4679-a28b-a2b2e84c1153', 195, CAST(N'1994-07-31' AS Date), CAST(3.670450 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a5eefed-cfa0-4ea9-8e2c-348a2dc76f6a', 195, CAST(N'1994-08-31' AS Date), CAST(3.596783 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'40a7db4b-93a3-493e-8f83-33ccd1f2806c', 195, CAST(N'1994-09-30' AS Date), CAST(3.557048 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6db5c69e-ef4e-4538-a7c9-52c98a3f9b9e', 195, CAST(N'1994-10-31' AS Date), CAST(3.542000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76f19616-ec6a-4f50-8fba-bee5441450bf', 195, CAST(N'1994-11-30' AS Date), CAST(3.525575 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8665ac66-2d09-4f13-906e-20ed06c37ca3', 195, CAST(N'1994-12-31' AS Date), CAST(3.561443 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f899e7c4-5b4b-402f-922b-55128c3033b4', 195, CAST(N'1995-01-31' AS Date), CAST(3.540350 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd41f0ed6-7551-481b-b2d3-5dcfbfb019fb', 195, CAST(N'1995-02-28' AS Date), CAST(3.562947 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61133c2a-98df-4c4c-9afa-8ff8d3f5320a', 195, CAST(N'1995-03-31' AS Date), CAST(3.601261 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17f03392-ff49-45f5-8552-9d75b296f9aa', 195, CAST(N'1995-04-30' AS Date), CAST(3.603500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f3ab3bb-2a1a-4418-9204-0c71817c68c0', 195, CAST(N'1995-05-31' AS Date), CAST(3.657386 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b067a98-4a54-48aa-8e9c-143f233abd66', 195, CAST(N'1995-06-30' AS Date), CAST(3.662741 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'18d8d307-e682-4c2f-821e-ea14b6b2a69c', 195, CAST(N'1995-07-31' AS Date), CAST(3.640425 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b093ce1b-2527-494a-b538-ae1c5df89818', 195, CAST(N'1995-08-31' AS Date), CAST(3.640152 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fcea3190-a008-41e6-9207-b1f1d64f7efd', 195, CAST(N'1995-09-30' AS Date), CAST(3.661550 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c16ebfc4-409a-4984-a41d-0bef679aa5f1', 195, CAST(N'1995-10-31' AS Date), CAST(3.650190 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f34cfb53-f6e9-4557-9011-0accd3db358e', 195, CAST(N'1995-11-30' AS Date), CAST(3.647562 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e323d635-35f6-45db-96b8-150ba47b37cc', 195, CAST(N'1995-12-31' AS Date), CAST(3.663195 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be00924e-052e-42cd-976e-d9c5e5f33097', 195, CAST(N'1996-01-31' AS Date), CAST(3.641319 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f6d8d5d1-bcc4-4420-90ea-f19a99e87e72', 195, CAST(N'1996-02-29' AS Date), CAST(3.741960 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9438c0f0-153c-4e31-b0b4-3018b6341c2f', 195, CAST(N'1996-03-31' AS Date), CAST(3.929271 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed0045f2-8ea2-418d-8c08-4124b2e77091', 195, CAST(N'1996-04-30' AS Date), CAST(4.213014 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd214e84e-21d5-4c47-878e-4fb4b3015a08', 195, CAST(N'1996-05-31' AS Date), CAST(4.372932 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2c9ff3b2-caea-4e34-9c6d-09cf1c2b6235', 195, CAST(N'1996-06-30' AS Date), CAST(4.351900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff65999e-6125-4812-acee-0afd6e9ef35e', 195, CAST(N'1996-07-31' AS Date), CAST(4.396295 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9f0a656-201b-4c12-8df4-bc669c3b3e29', 195, CAST(N'1996-08-31' AS Date), CAST(4.528909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'19a1fda0-1cbd-4d18-a3d0-f4a9ece63b92', 195, CAST(N'1996-09-30' AS Date), CAST(4.503875 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00829ddf-7567-4bf5-be70-6fb30d4ee27e', 195, CAST(N'1996-10-31' AS Date), CAST(4.579909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'575ccb55-f2f8-4cc5-99bd-39c3eea47e85', 195, CAST(N'1996-11-30' AS Date), CAST(4.657737 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1843ef1c-2987-4664-a708-6c3ae5de9f7b', 195, CAST(N'1996-12-31' AS Date), CAST(4.687262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'036e3e69-caa6-4714-8014-f0da7b08273b', 195, CAST(N'1997-01-31' AS Date), CAST(4.640167 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a0adf348-48a0-4029-bd2e-e5571fee50a0', 195, CAST(N'1997-02-28' AS Date), CAST(4.455684 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b8485d28-50d2-483b-8272-1dda330ef2d9', 195, CAST(N'1997-03-31' AS Date), CAST(4.431924 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb84ab59-4172-4c4c-a0d2-769f820e62fa', 195, CAST(N'1997-04-30' AS Date), CAST(4.441727 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b3ca804-4557-49e6-a25b-bda1496be533', 195, CAST(N'1997-05-31' AS Date), CAST(4.466833 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16b38a64-41fa-4490-91b8-4c893db9e85b', 195, CAST(N'1997-06-30' AS Date), CAST(4.500548 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'223edc42-165c-429a-9c90-6a2eedca2891', 195, CAST(N'1997-07-31' AS Date), CAST(4.561136 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c53cf1a-bbb6-4f96-8764-a20fb3947b74', 195, CAST(N'1997-08-31' AS Date), CAST(4.685571 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'50c5d8f6-92ad-480b-af03-0516982f96e0', 195, CAST(N'1997-09-30' AS Date), CAST(4.689005 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1672c90-9bf3-4519-b8c8-5e372b5400cb', 195, CAST(N'1997-10-31' AS Date), CAST(4.714500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b5b11344-d673-4753-acc3-4586ff7c0ae6', 195, CAST(N'1997-11-30' AS Date), CAST(4.839361 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a4dd054-1120-4f10-a90a-d8ef2f47b20a', 195, CAST(N'1997-12-31' AS Date), CAST(4.870564 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a53954ea-ee9b-4df1-847a-0ac6dec1c4e3', 195, CAST(N'1998-01-31' AS Date), CAST(4.941650 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2856e06e-a447-4c8d-b9b5-eb09c36e367a', 195, CAST(N'1998-02-28' AS Date), CAST(4.933710 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4d130445-e660-4ee2-96a2-409f14a60813', 195, CAST(N'1998-03-31' AS Date), CAST(4.974591 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75046e48-bb20-43ea-8b39-2a551194b2b0', 195, CAST(N'1998-04-30' AS Date), CAST(5.045905 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb33965f-ea73-4084-9cac-722ef5adbfb2', 195, CAST(N'1998-05-31' AS Date), CAST(5.092730 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'98c5b8ec-7bad-4ae4-8cc3-a82fb306a20f', 195, CAST(N'1998-06-30' AS Date), CAST(5.391045 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2546e16b-e6a5-4db2-93f6-c5d2096f5a9c', 195, CAST(N'1998-07-31' AS Date), CAST(6.228483 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'182de826-15f0-475b-8dc3-5043781d207c', 195, CAST(N'1998-08-31' AS Date), CAST(6.319762 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'66b72fb5-fe69-40f5-89eb-17bc28064bb0', 195, CAST(N'1998-09-30' AS Date), CAST(6.096567 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'49448263-f084-4c2f-88cb-892f1f1f675b', 195, CAST(N'1998-10-31' AS Date), CAST(5.799124 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f005372b-42db-4cb6-a43d-743f13d0d1ca', 195, CAST(N'1998-11-30' AS Date), CAST(5.651132 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd7478144-f894-453e-ad96-75818a9b8b6e', 195, CAST(N'1998-12-31' AS Date), CAST(5.903045 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e3cb6576-6d2e-4051-93cb-295ec6cdc37b', 195, CAST(N'1999-01-31' AS Date), CAST(5.999601 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aa5eddbd-89d3-4970-bdd8-362c5fa50d7b', 195, CAST(N'1999-02-28' AS Date), CAST(6.113138 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75b62754-6561-4771-a41a-6e33bbb90e3e', 195, CAST(N'1999-03-31' AS Date), CAST(6.208126 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f4c1cca-88c0-44ff-a3f4-559ff5b89141', 195, CAST(N'1999-04-30' AS Date), CAST(6.117164 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'404eff7d-4d2d-47b8-8b59-fc5cffe780dd', 195, CAST(N'1999-05-31' AS Date), CAST(6.183899 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'32323b4d-dba0-4d21-8f53-c9896288bbd3', 195, CAST(N'1999-06-30' AS Date), CAST(6.085407 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7c32479-93fe-4ed0-b156-6838ded0d8d1', 195, CAST(N'1999-07-31' AS Date), CAST(6.114071 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'14b5dcab-42f9-4cfd-9e19-cde1f6dcac64', 195, CAST(N'1999-08-31' AS Date), CAST(6.126153 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5cd12b05-4274-48ff-8dd1-d358b8bb2e30', 195, CAST(N'1999-09-30' AS Date), CAST(6.056835 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'daf7d962-9fb3-4e84-a4d2-dea70c276414', 195, CAST(N'1999-10-31' AS Date), CAST(6.099666 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8af43d34-a7e3-464b-8a7a-244d9fdb2d18', 195, CAST(N'1999-11-30' AS Date), CAST(6.139332 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7670d24a-f58d-47b1-ac98-eeb693c87b6b', 195, CAST(N'1999-12-31' AS Date), CAST(6.145400 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd6e172fc-e514-4883-a806-ce2d08ed39ab', 195, CAST(N'2000-01-31' AS Date), CAST(6.125679 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7f452468-19a7-4f47-947c-300b94215ac7', 195, CAST(N'2000-02-29' AS Date), CAST(6.313828 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dff897d2-8822-4d8d-a7c4-13989d8b260b', 195, CAST(N'2000-03-31' AS Date), CAST(6.460387 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'63640e61-549f-4f0b-bd92-32c65204faa2', 195, CAST(N'2000-04-30' AS Date), CAST(6.631049 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eaac07c6-b1b7-4ae9-933a-35b05800f135', 195, CAST(N'2000-05-31' AS Date), CAST(7.007914 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8b5627ab-f2cc-42b8-a472-2410ab59a1e8', 195, CAST(N'2000-06-30' AS Date), CAST(6.917148 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e5878ac-72c9-4874-8a51-03bd8a2b3b9a', 195, CAST(N'2000-07-31' AS Date), CAST(6.877850 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2aa93539-ddbe-4d9f-98d2-f4948a1784a0', 195, CAST(N'2000-08-31' AS Date), CAST(6.948862 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d24c724-49ea-4403-ac51-b0b8f23ba214', 195, CAST(N'2000-09-30' AS Date), CAST(7.157991 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00b1982b-8822-4259-af5c-15323fd4ef90', 195, CAST(N'2000-10-31' AS Date), CAST(7.466933 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b7c97fa4-35b9-4dac-8e61-749f7aceb41f', 195, CAST(N'2000-11-30' AS Date), CAST(7.677679 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'902339c9-5894-48b7-a0e6-3661d28fc9b2', 195, CAST(N'2000-12-31' AS Date), CAST(7.630753 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b978449-5c46-4260-b05f-fa9af06dba05', 195, CAST(N'2001-01-31' AS Date), CAST(7.759485 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'66ba84fa-d6e4-426f-9293-64bd63833d7a', 195, CAST(N'2001-02-28' AS Date), CAST(7.809925 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3a979054-e224-4a6d-ab2f-964e2288819f', 195, CAST(N'2001-03-31' AS Date), CAST(7.883849 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e6595c0-3409-4519-95f7-a14d9cae53ab', 195, CAST(N'2001-04-30' AS Date), CAST(8.071338 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd98e7da6-c0a6-44da-910c-456b5f7fc937', 195, CAST(N'2001-05-31' AS Date), CAST(7.968109 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'79245613-2566-4681-92d6-7c03b81234b5', 195, CAST(N'2001-06-30' AS Date), CAST(8.052476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd53fc3a2-4d9e-4eb0-bb75-a95927d49379', 195, CAST(N'2001-07-31' AS Date), CAST(8.189282 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef2acf5a-416f-4334-b0dd-30a986158317', 195, CAST(N'2001-08-31' AS Date), CAST(8.305877 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'53584786-f9ee-4606-ba4c-209a52ee5f14', 195, CAST(N'2001-09-30' AS Date), CAST(8.629197 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'314a42ff-b960-4b85-8e5c-6cec47c3def9', 195, CAST(N'2001-10-31' AS Date), CAST(9.253881 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bd8e2b2f-b9dc-488e-b59c-0f66d619f224', 195, CAST(N'2001-11-30' AS Date), CAST(9.720244 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2dda6e71-4ea4-4a54-81bd-6d52ccb85535', 195, CAST(N'2001-12-31' AS Date), CAST(11.593838 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ccae082a-9896-4a42-b2a1-de088c48a120', 195, CAST(N'2002-01-31' AS Date), CAST(11.628977 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84ba53d6-66d2-4f1d-9197-0880f2642b1d', 195, CAST(N'2002-02-28' AS Date), CAST(11.473705 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'49ae1d67-2b6e-4683-a4ae-270da038f6d5', 195, CAST(N'2002-03-31' AS Date), CAST(11.479825 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dc712896-f1dc-4be9-b1d0-7a8cae6e53d0', 195, CAST(N'2002-04-30' AS Date), CAST(11.103136 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38adc987-d5e3-4582-9cdd-7888c1692f13', 195, CAST(N'2002-05-31' AS Date), CAST(10.177478 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'717778b9-1e47-495f-9b41-7bdc0d2c997a', 195, CAST(N'2002-06-30' AS Date), CAST(10.166710 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'adc83d6c-928a-4faf-8716-25419e96fced', 195, CAST(N'2002-07-31' AS Date), CAST(10.097230 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5007e131-f1ee-4d80-8d2c-3abbcfd86835', 195, CAST(N'2002-08-31' AS Date), CAST(10.567818 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c7681358-eec6-45bb-92bf-6132b80b2960', 195, CAST(N'2002-09-30' AS Date), CAST(10.597800 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'18b34e22-8e48-4c5b-93ff-56fd4c1459af', 195, CAST(N'2002-10-31' AS Date), CAST(10.330205 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75a25f11-2a1b-4fb2-9351-dc471f2416d7', 195, CAST(N'2002-11-30' AS Date), CAST(9.701963 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c786cc67-3d8b-462b-b5b4-1d028ec2510f', 195, CAST(N'2002-12-31' AS Date), CAST(8.965220 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e610990-9827-4ee9-aad5-caa07a79aa5e', 195, CAST(N'2003-01-31' AS Date), CAST(8.684389 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9d77d686-b422-4976-b08f-f84dc74e6422', 195, CAST(N'2003-02-28' AS Date), CAST(8.297115 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c73fe070-806c-4b7b-bfb0-2fe7ae1d84cd', 195, CAST(N'2003-03-31' AS Date), CAST(8.051258 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a384c72d-0df6-4a6e-bba2-4262cdafaa3c', 195, CAST(N'2003-04-30' AS Date), CAST(7.696850 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9479afd4-3088-4fea-ba6f-57a63ddbed64', 195, CAST(N'2003-05-31' AS Date), CAST(7.620194 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e367c05-bb80-4ec7-a83d-8115f2bee695', 195, CAST(N'2003-06-30' AS Date), CAST(7.866287 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1519798c-a71b-4045-bb21-0a10f007054a', 195, CAST(N'2003-07-31' AS Date), CAST(7.556355 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'24a6a38d-612e-4568-acc5-a5058f27ae87', 195, CAST(N'2003-08-31' AS Date), CAST(7.384306 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df195045-3c61-41f3-9e4d-45fb7387306e', 195, CAST(N'2003-09-30' AS Date), CAST(7.340247 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ea46a0c-afc2-4099-94ff-475f5989a186', 195, CAST(N'2003-10-31' AS Date), CAST(6.955929 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f58fcad8-1da4-4dbd-b43b-3aaba7a86806', 195, CAST(N'2003-11-30' AS Date), CAST(6.733013 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2caeecc6-87f8-4e87-9f05-e2ee20d048f0', 195, CAST(N'2003-12-31' AS Date), CAST(6.558887 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a0f49acd-d6ee-4541-b696-6f7a43d14c36', 195, CAST(N'2004-01-31' AS Date), CAST(6.919639 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5846c7ef-cb39-4ed6-b67e-8170fc2a5074', 195, CAST(N'2004-02-29' AS Date), CAST(6.770183 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3d5d8ee1-83dc-4729-afc1-77f93197e54e', 195, CAST(N'2004-03-31' AS Date), CAST(6.633148 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c998a6e-c5dc-449d-8323-00b5d8d459a0', 195, CAST(N'2004-04-30' AS Date), CAST(6.503613 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08bfdbe6-b2b1-457c-8fd0-4e31c0024759', 195, CAST(N'2004-05-31' AS Date), CAST(6.789974 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'15a1bef4-d76c-4f01-a478-53af73adaa33', 195, CAST(N'2004-06-30' AS Date), CAST(6.431527 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6fd4a7f2-ec1d-42b6-aa97-47def920987a', 195, CAST(N'2004-07-31' AS Date), CAST(6.119961 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8a10c36-e91b-4bac-93db-3848ef9ce7cc', 195, CAST(N'2004-08-31' AS Date), CAST(6.447506 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8e98b65a-43b3-4fc0-b611-7478f96bafd5', 195, CAST(N'2004-09-30' AS Date), CAST(6.520416 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ada432d-ed3a-4a9c-8637-0b01caf6c4f0', 195, CAST(N'2004-10-31' AS Date), CAST(6.391581 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4bb5e5b6-b8ce-4d8f-907a-5fa13476a119', 195, CAST(N'2004-11-30' AS Date), CAST(6.054240 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a525da4a-f360-42cd-96c3-b99044e71269', 195, CAST(N'2004-12-31' AS Date), CAST(5.723765 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76b36b18-08f4-425b-a44c-5d2469ee6b01', 195, CAST(N'2005-01-31' AS Date), CAST(5.903828 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5fbe6a2c-f0e7-4cb8-b066-927f3104bdeb', 195, CAST(N'2005-02-28' AS Date), CAST(6.024221 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aff58d94-22cd-4113-b35a-de10915b630f', 195, CAST(N'2005-03-31' AS Date), CAST(6.021465 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed659560-405d-41ab-9e51-bf13452400be', 195, CAST(N'2005-04-30' AS Date), CAST(6.160100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9ed81ee0-9358-44af-8113-0e2d31cefe45', 195, CAST(N'2005-05-31' AS Date), CAST(6.322665 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'585218e8-b27a-426d-b906-a2ab222828aa', 195, CAST(N'2005-06-30' AS Date), CAST(6.744517 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e044426c-6b43-4ecf-b895-884fbe8d4454', 195, CAST(N'2005-07-31' AS Date), CAST(6.713524 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cf143361-1184-4394-9563-11340c070b12', 195, CAST(N'2005-08-31' AS Date), CAST(6.463708 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e07efb97-8db5-47ad-84b7-b1e0a01fc6be', 195, CAST(N'2005-09-30' AS Date), CAST(6.360925 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9568458-d737-4605-993f-3fee1ad01d41', 195, CAST(N'2005-10-31' AS Date), CAST(6.565332 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'484f5fe0-face-4e48-8071-8b346da592c2', 195, CAST(N'2005-11-30' AS Date), CAST(6.660868 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b318ec17-d319-44a6-a8c2-70ecb5ef535b', 195, CAST(N'2005-12-31' AS Date), CAST(6.370222 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'067e06cd-ffa9-418f-bd4d-8bbbda5a032d', 195, CAST(N'2006-01-31' AS Date), CAST(6.094831 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'20a21511-9b35-4b96-8769-d7b6eb9297df', 195, CAST(N'2006-02-28' AS Date), CAST(6.098767 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6d499efe-f8be-47f6-bc7c-465cd6087807', 195, CAST(N'2006-03-31' AS Date), CAST(6.244222 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed4a7786-7e16-4f3a-a600-14540eaface0', 195, CAST(N'2006-04-30' AS Date), CAST(6.087572 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'692a8f38-54f0-4180-8029-9adf870d49b7', 195, CAST(N'2006-05-31' AS Date), CAST(6.297103 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7857ea4c-c7de-4b44-836e-43159088b3e1', 195, CAST(N'2006-06-30' AS Date), CAST(6.929487 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ae5b561-0b4f-4d5a-988e-0996cd23a89f', 195, CAST(N'2006-07-31' AS Date), CAST(7.085061 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4860266e-8d97-4c42-845e-6f9f156623f7', 195, CAST(N'2006-08-31' AS Date), CAST(6.948497 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fbda55a1-cfd6-4e55-a22f-280b5b5ccd4a', 195, CAST(N'2006-09-30' AS Date), CAST(7.423736 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f7a63cb-4894-44ef-a0e7-4d800edb98fa', 195, CAST(N'2006-10-31' AS Date), CAST(7.632488 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc9fa050-bf62-4d6f-a5c3-91c92ca9fa6b', 195, CAST(N'2006-11-30' AS Date), CAST(7.256657 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b951fbd4-7684-4b95-bfe1-4d30f0e193b3', 195, CAST(N'2006-12-31' AS Date), CAST(7.043958 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f7815629-938e-4dd2-81cc-d83c71f4fba3', 195, CAST(N'2007-01-31' AS Date), CAST(7.189148 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8a5dade-10f1-42fe-af3b-84cd89c0bfe8', 195, CAST(N'2007-02-28' AS Date), CAST(7.163558 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e00eff1b-b097-40ee-8137-3865512c079e', 195, CAST(N'2007-03-31' AS Date), CAST(7.344504 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42f534f4-969b-4416-83b1-5a1cacd37cd2', 195, CAST(N'2007-04-30' AS Date), CAST(7.120555 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9864d374-13f4-4188-a85c-c3dc83782fad', 195, CAST(N'2007-05-31' AS Date), CAST(7.025717 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9613378f-1ac1-49b6-9e4d-7327d51d6d3b', 195, CAST(N'2007-06-30' AS Date), CAST(7.159013 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9be2cf51-b41a-4c33-8f7d-9e200b5f6bf6', 195, CAST(N'2007-07-31' AS Date), CAST(6.973334 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4ce2ed95-d454-4799-b0b6-19be2a8d26b8', 195, CAST(N'2007-08-31' AS Date), CAST(7.229999 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff38cb8c-55a7-4016-87fc-666043bb0fb9', 195, CAST(N'2007-09-30' AS Date), CAST(7.102240 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4902807-5035-4ec1-87e2-7cf20c0a173b', 195, CAST(N'2007-10-31' AS Date), CAST(6.770355 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5cc80bad-b73b-443b-911d-1574d05c87a8', 195, CAST(N'2007-11-30' AS Date), CAST(6.684813 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'939b55ec-1df4-4a97-a827-86a41d0bfcce', 195, CAST(N'2007-12-31' AS Date), CAST(6.843444 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6da6b81e-0712-4fb6-a3cb-240457fd99fa', 195, CAST(N'2008-01-31' AS Date), CAST(6.963619 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e1e3baa9-25e3-4e6d-a377-8664242bf2fc', 195, CAST(N'2008-02-29' AS Date), CAST(7.656740 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3fd5fa6a-ebd5-43cd-8a96-adbc94819877', 195, CAST(N'2008-03-31' AS Date), CAST(7.954042 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b99eae6b-729b-4d2d-8505-d6bb4968ff7c', 195, CAST(N'2008-04-30' AS Date), CAST(7.783502 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'32572598-3a2a-4bc0-a987-7a3b01216ce5', 195, CAST(N'2008-05-31' AS Date), CAST(7.610234 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3decdc0f-ab09-4436-9cc7-9dcbc9ea4dff', 195, CAST(N'2008-06-30' AS Date), CAST(7.929115 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c40bf96e-cd71-4eca-a113-b09a01a576db', 195, CAST(N'2008-07-31' AS Date), CAST(7.650886 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b8b72e44-82eb-47f5-9733-e40df90a833e', 195, CAST(N'2008-08-31' AS Date), CAST(7.648229 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7139962a-725c-49f1-b9f0-6e2f022982e4', 195, CAST(N'2008-09-30' AS Date), CAST(8.068599 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'de098d47-21a9-4e98-944e-2ea7902854cf', 195, CAST(N'2008-10-31' AS Date), CAST(9.628889 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8462af7d-602c-455d-842d-25e179c809a9', 195, CAST(N'2008-11-30' AS Date), CAST(10.128513 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d36515d-e802-47f6-8faf-11159522f077', 195, CAST(N'2008-12-31' AS Date), CAST(9.926381 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'de43d939-94a1-42b4-abd2-fe76f31b0e9c', 195, CAST(N'2009-01-31' AS Date), CAST(9.854724 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b5f1f7d1-2786-47e9-8d7f-7e53584fe2e9', 195, CAST(N'2009-02-28' AS Date), CAST(9.983137 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85b6bb0f-933e-4fd4-9fe2-a103f5a27015', 195, CAST(N'2009-03-31' AS Date), CAST(9.959530 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e1d84165-22a7-45c2-8e32-8d8bab7673e9', 195, CAST(N'2009-04-30' AS Date), CAST(9.020596 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6beb3d50-2be3-45a1-8f45-99d209a13e9f', 195, CAST(N'2009-05-31' AS Date), CAST(8.366854 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e51987ff-4109-45ce-88a2-c73d9af692f5', 195, CAST(N'2009-06-30' AS Date), CAST(8.042074 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'88e2b4eb-559b-4176-a35c-6f714f142a26', 195, CAST(N'2009-07-31' AS Date), CAST(7.960549 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0b8cb47d-beb1-4c45-a987-280d88d8833a', 195, CAST(N'2009-08-31' AS Date), CAST(7.918986 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82a2ffa9-b02e-4c8d-b9be-95989cce887f', 195, CAST(N'2009-09-30' AS Date), CAST(7.503779 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8f8f733e-64bc-46b6-9061-ee137cb4d437', 195, CAST(N'2009-10-31' AS Date), CAST(7.475525 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a2637ec9-f841-40dd-832b-3ebab0a0596f', 195, CAST(N'2009-11-30' AS Date), CAST(7.529358 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bbc94588-d2dc-4471-87cc-de02689bbe9b', 195, CAST(N'2009-12-31' AS Date), CAST(7.507784 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cc4400ca-5b19-4fa2-9aa9-124d22e6210b', 195, CAST(N'2010-01-31' AS Date), CAST(7.459470 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'97446be3-c371-43b3-917c-e086692ec6b9', 195, CAST(N'2010-02-28' AS Date), CAST(7.683381 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca57c90a-dbc8-4d28-96ed-84737a2abde7', 195, CAST(N'2010-03-31' AS Date), CAST(7.419466 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e7361bd8-5e0a-40aa-ba10-563a9eff7dd2', 195, CAST(N'2010-04-30' AS Date), CAST(7.331546 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0fdb01e5-aee6-43c1-a878-8cc4979abc4f', 195, CAST(N'2010-05-31' AS Date), CAST(7.625187 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08e23413-c694-401e-8080-ca3927b07af3', 195, CAST(N'2010-06-30' AS Date), CAST(7.642654 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e945e754-a733-4b5d-a600-d123d81e3122', 195, CAST(N'2010-07-31' AS Date), CAST(7.554936 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'365517c7-8c90-4b5c-9768-cab6d8e1364b', 195, CAST(N'2010-08-31' AS Date), CAST(7.290627 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f516d023-2e4e-450e-b3ac-2de434373a3a', 195, CAST(N'2010-09-30' AS Date), CAST(7.137567 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f2cfef5a-9276-4754-ad04-51ddc5ea79da', 195, CAST(N'2010-10-31' AS Date), CAST(6.912860 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4536431-f94f-4cad-80f8-e1b9deacec99', 195, CAST(N'2010-11-30' AS Date), CAST(6.974275 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bec16db8-7c36-4b0e-9446-1ed4396063b5', 195, CAST(N'2010-12-31' AS Date), CAST(6.832986 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ce63871-f55d-46ab-a827-dbbcec37cd28', 195, CAST(N'2011-01-31' AS Date), CAST(6.905836 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1014e917-cf85-42c2-99ab-9de8425af0cb', 195, CAST(N'2011-02-28' AS Date), CAST(7.189739 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b1136719-cb42-4492-99f5-22afe4a81f39', 195, CAST(N'2011-03-31' AS Date), CAST(6.913167 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'72abbabb-60a5-4f4a-8074-10030525cec3', 195, CAST(N'2011-04-30' AS Date), CAST(6.722015 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'669b4b18-2f77-49ef-81ca-ce89eaefd8dc', 195, CAST(N'2011-05-31' AS Date), CAST(6.852274 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46ec8f70-24bc-4c2d-aba3-2605979a30b0', 195, CAST(N'2011-06-30' AS Date), CAST(6.791774 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'70501665-fe1a-436e-a046-6bcb4e801930', 195, CAST(N'2011-07-31' AS Date), CAST(6.778832 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'47b90526-3e89-4c2f-a006-27e404232e72', 195, CAST(N'2011-08-31' AS Date), CAST(7.091196 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8fb03d6-39e6-43bb-9e50-40b9645a2172', 195, CAST(N'2011-09-30' AS Date), CAST(7.517724 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff02004e-607e-439a-9ddf-ce5fee4ed773', 195, CAST(N'2011-10-31' AS Date), CAST(7.953589 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'405517b5-3894-4eb8-bb9f-798c0b614224', 195, CAST(N'2011-11-30' AS Date), CAST(8.144080 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'57584198-a715-469b-9483-d283116bfd08', 195, CAST(N'2011-12-31' AS Date), CAST(8.189135 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'14c53fb4-a0da-4777-840e-6aa2c0e06099', 195, CAST(N'2012-01-31' AS Date), CAST(8.023035 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a09bff03-3b51-4c6b-8cc0-e2e6753ea59e', 195, CAST(N'2012-02-29' AS Date), CAST(7.659488 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aee20f90-7bb6-4363-bbaa-2a19526cb6e7', 195, CAST(N'2012-03-31' AS Date), CAST(7.595706 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f12ab038-3f3c-4a1d-a853-2892c06af28a', 195, CAST(N'2012-04-30' AS Date), CAST(7.829427 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77ead58c-f4fa-4ca4-821b-3cc24bf7def5', 195, CAST(N'2012-05-31' AS Date), CAST(8.139506 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'59b669db-aa30-4edf-8c2d-581bb801e92b', 195, CAST(N'2012-06-30' AS Date), CAST(8.400602 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b67bfe38-2dbf-478e-9e4e-f2788ffa0ecb', 195, CAST(N'2012-07-31' AS Date), CAST(8.236783 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e3aa67dd-91b4-4a2d-bc6b-d5620b4ef773', 195, CAST(N'2012-08-31' AS Date), CAST(8.253498 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b3ec0c94-1289-4f46-8d6b-d6df17b0c69f', 195, CAST(N'2012-09-30' AS Date), CAST(8.271801 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'074b07f1-d0c3-4e69-9f6d-4ba139ae5dd0', 195, CAST(N'2012-10-31' AS Date), CAST(8.657898 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dc714902-6af0-4e7f-a631-255e92052e8c', 195, CAST(N'2012-11-30' AS Date), CAST(8.799808 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6a44d3ca-8ffc-4e92-ab74-32d6008685b2', 195, CAST(N'2012-12-31' AS Date), CAST(8.637363 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a3697d5c-725a-44e5-bdb3-1670f98b512d', 195, CAST(N'2013-01-31' AS Date), CAST(8.770423 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65083087-9b66-4746-81c6-5acdaeb7efd5', 195, CAST(N'2013-02-28' AS Date), CAST(8.872944 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'79b62ae9-906a-4138-8fe7-564b6452a283', 195, CAST(N'2013-03-31' AS Date), CAST(9.183267 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8931d65-ce1a-4308-9547-95c4144c4b8c', 195, CAST(N'2013-04-30' AS Date), CAST(9.104961 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'082ea0a5-5646-46d6-9e73-06643416a34c', 195, CAST(N'2013-05-31' AS Date), CAST(9.302934 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3c079e0-58ff-43b2-a4ce-23fd6c3bf824', 195, CAST(N'2013-06-30' AS Date), CAST(10.012434 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4430310-10a5-4d34-babb-ebd78d2e7ec5', 195, CAST(N'2013-07-31' AS Date), CAST(9.933268 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48d20f76-fa27-4599-8a53-23a9f35ea5c5', 195, CAST(N'2013-08-31' AS Date), CAST(10.046848 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09b05a1d-492d-4716-825e-24549395876b', 195, CAST(N'2013-09-30' AS Date), CAST(9.996085 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da6a4a81-26a4-4c92-8bd6-6ab5af69b4d7', 195, CAST(N'2013-10-31' AS Date), CAST(9.898840 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cd3a2075-5e8b-4e44-b1dd-7e5a01c6f5cd', 195, CAST(N'2013-11-30' AS Date), CAST(10.202414 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3cab0cfd-29ba-4227-8929-d1a3063a91c4', 195, CAST(N'2013-12-31' AS Date), CAST(10.351620 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42d88c9e-f5a3-4b3b-9895-620710f44c42', 195, CAST(N'2014-01-31' AS Date), CAST(10.834567 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3960e0df-729d-48f7-82b5-a799cb30aa73', 195, CAST(N'2014-02-28' AS Date), CAST(10.977079 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aeacfcb2-2e06-445a-a934-d64d5e040a2e', 195, CAST(N'2014-03-31' AS Date), CAST(10.748543 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec0e0766-2b11-45f9-9888-277fda01522b', 195, CAST(N'2014-04-30' AS Date), CAST(10.545976 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb062677-a53c-44fb-8148-6da81b1cec34', 195, CAST(N'2014-05-31' AS Date), CAST(10.405276 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e418b42-34ca-4185-82e2-85b0d7a14cfb', 195, CAST(N'2014-06-30' AS Date), CAST(10.666311 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd5a356e4-096b-4912-8660-3af1b0a63327', 195, CAST(N'2014-07-31' AS Date), CAST(10.657941 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce330706-f24b-4486-bf1f-e43bd06c2f13', 195, CAST(N'2014-08-31' AS Date), CAST(10.660175 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df03ac68-ae71-411f-8a0e-38d371510116', 195, CAST(N'2014-09-30' AS Date), CAST(10.965366 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4d13e6b7-79b6-4e82-9b40-2e10649c830a', 195, CAST(N'2014-10-31' AS Date), CAST(11.083512 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'06e4811d-dc4b-45ba-bd53-f2d15a0df0a8', 195, CAST(N'2014-11-30' AS Date), CAST(11.087478 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fa6caa02-b476-43b5-9912-e2fb54a6960c', 195, CAST(N'2014-12-31' AS Date), CAST(11.499216 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e099f1d7-4d6e-41e4-b27a-0823d562bf85', 195, CAST(N'2015-01-31' AS Date), CAST(11.545962 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cb7974d4-9da2-4d67-b2bb-85ece483b7f0', 195, CAST(N'2015-02-28' AS Date), CAST(11.589613 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd76f09b9-b822-4b35-9f59-998238af37ad', 195, CAST(N'2015-03-31' AS Date), CAST(12.076697 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd98f2587-e0f4-4d80-a243-a956a011f2dd', 195, CAST(N'2015-04-30' AS Date), CAST(11.988121 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e07cf1eb-0610-4a6c-96d0-d97430dadc05', 195, CAST(N'2015-05-31' AS Date), CAST(11.960248 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f6e1511d-20dd-4941-8977-d18cc54e2b12', 195, CAST(N'2015-06-30' AS Date), CAST(12.301468 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27337394-141f-4010-b31a-66417e2cf1d5', 195, CAST(N'2015-07-31' AS Date), CAST(12.443443 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2730e18-dcb7-4990-a04c-6fe5964652a1', 195, CAST(N'2015-08-31' AS Date), CAST(12.878743 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9fb3f4f2-0fd5-44e9-8dc8-aaf58336d88c', 195, CAST(N'2015-09-30' AS Date), CAST(13.642134 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2388cb6d-6e1a-4174-92c8-467d0a9f085d', 195, CAST(N'2015-10-31' AS Date), CAST(13.491612 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bae813b3-0c5d-40ec-900d-cefcec584d18', 195, CAST(N'2015-11-30' AS Date), CAST(14.143587 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ab27d14-a162-4258-9b2d-a2db7594761e', 195, CAST(N'2015-12-31' AS Date), CAST(15.023957 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8041bbc5-3c51-4ff8-8d65-cc5ee585947a', 195, CAST(N'2016-01-31' AS Date), CAST(16.261223 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9b6fbd3-af37-40b7-b1e7-ab1dea390b4a', 195, CAST(N'2016-02-29' AS Date), CAST(15.805408 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3ec6d16e-9a75-43d9-b9b6-8fc5b8951426', 195, CAST(N'2016-03-31' AS Date), CAST(15.396273 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2dc24219-0707-4835-b90c-6026c5fdd41d', 195, CAST(N'2016-04-30' AS Date), CAST(14.619942 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f9501ec-8e30-49e8-9af3-b971e9889004', 195, CAST(N'2016-05-31' AS Date), CAST(15.280083 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'11f33fa0-b9cf-46ca-a4ba-f479f32b5dbc', 195, CAST(N'2016-06-30' AS Date), CAST(15.100494 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42dffbdf-0a1b-4fed-834e-0b0579f1e6b5', 195, CAST(N'2016-07-31' AS Date), CAST(14.420304 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6ef12441-70b8-4090-b32f-6ce5a2f3c3a7', 195, CAST(N'2016-08-31' AS Date), CAST(13.764403 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'039b529b-6aca-4cf0-9777-931a636eae01', 195, CAST(N'2016-09-30' AS Date), CAST(14.122646 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5518c4c6-8b1c-42dc-a92f-1462f1d1965e', 195, CAST(N'2016-10-31' AS Date), CAST(13.923454 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e9cb4dd-e2e5-4437-be71-941b85f851c2', 195, CAST(N'2016-11-30' AS Date), CAST(13.987932 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f1ded4d-2f36-47be-9907-612ff1ad9090', 195, CAST(N'2016-12-31' AS Date), CAST(13.858981 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd1451199-407d-49d0-9ebe-3b13d372f9e2', 195, CAST(N'2017-01-31' AS Date), CAST(13.575329 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'189207ee-7050-49da-91d9-a14113dea9da', 195, CAST(N'2017-02-28' AS Date), CAST(13.175344 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc4267db-43f3-43e5-9570-cf5b8737bf8d', 195, CAST(N'2017-03-31' AS Date), CAST(12.904032 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e3edcd0a-6b73-47ea-a726-c8810fe5818e', 195, CAST(N'2017-04-30' AS Date), CAST(13.451366 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df40b861-a3d8-43f9-964c-da42d7238bf0', 195, CAST(N'2017-05-31' AS Date), CAST(13.250786 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8146d7ae-7369-4a9a-b10b-2e5fc427afbe', 195, CAST(N'2017-06-30' AS Date), CAST(12.891840 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'474f1f90-4cfe-4f80-bc02-56009000a0f6', 195, CAST(N'2017-07-31' AS Date), CAST(13.134058 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30cbfbd2-e73a-4ee1-a45e-1fb870bb4a99', 195, CAST(N'2017-08-31' AS Date), CAST(13.234528 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a97e0165-87c0-4704-abd4-c68a0a0c5c7e', 195, CAST(N'2017-09-30' AS Date), CAST(13.151921 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d111c0b-9a00-4123-a700-fa8207f4f717', 195, CAST(N'2017-10-31' AS Date), CAST(13.712619 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f93972c7-c287-4816-be9a-d85740ec4c02', 195, CAST(N'2017-11-30' AS Date), CAST(14.071005 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a2924a20-d0d3-4daf-815f-445f9e275987', 195, CAST(N'2017-12-31' AS Date), CAST(13.061209 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bdbcc63b-8c2c-4e9d-be74-31d5c729c982', 195, CAST(N'2018-01-31' AS Date), CAST(12.202221 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'57406a04-3088-48e0-95ee-6bfab0064317', 195, CAST(N'2018-02-28' AS Date), CAST(11.818993 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cdc7fe9c-9148-4893-b741-1995eeec2e8c', 195, CAST(N'2018-03-31' AS Date), CAST(11.847468 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'157b89c2-c27f-44e0-bed3-764a71586481', 195, CAST(N'2018-04-30' AS Date), CAST(12.105038 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be454fec-4459-45c8-aa77-cb2421c35f90', 195, CAST(N'2018-05-31' AS Date), CAST(12.522312 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce1c8fa5-7455-421e-aaae-131efd280b4f', 195, CAST(N'2018-06-30' AS Date), CAST(13.294842 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ae6ac85-0e0a-4a4c-923b-ece5184a24b8', 195, CAST(N'2018-07-31' AS Date), CAST(13.389214 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e174b43a-35f7-4bc4-8796-9613a89a04f6', 195, CAST(N'2018-08-31' AS Date), CAST(14.095344 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2353f85f-6c4a-40ee-97d8-b74c6c390915', 195, CAST(N'2018-09-30' AS Date), CAST(14.727902 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f5e32027-ca09-44a9-9165-d8088a8043ac', 195, CAST(N'2018-10-31' AS Date), CAST(14.529854 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8063d937-f5eb-4f42-a1ee-0d25611cf995', 195, CAST(N'2018-11-30' AS Date), CAST(14.102746 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2f40c57-628d-4c84-b01c-91ebc0536343', 195, CAST(N'2018-12-31' AS Date), CAST(14.279495 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1fb042fe-2bef-4718-a2ba-983632fca00f', 195, CAST(N'2019-01-31' AS Date), CAST(13.837076 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dec152b4-5970-431a-8ed1-f955c262efc3', 195, CAST(N'2019-02-28' AS Date), CAST(13.809594 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b6019e0-fe18-46a7-8325-798d5eb2c63f', 195, CAST(N'2019-03-31' AS Date), CAST(14.399924 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7bd3ee84-0cae-4b3e-84a1-7e3c46f0a33b', 195, CAST(N'2019-04-30' AS Date), CAST(14.143952 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd3c858de-04bc-4538-aab0-2adf5603b24a', 195, CAST(N'2019-05-31' AS Date), CAST(14.401992 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9f6f311-bbb1-4c00-b51e-3495647f5add', 195, CAST(N'2019-06-30' AS Date), CAST(14.577262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb559adf-d8d6-40ba-a692-bdd13e64dd78', 195, CAST(N'2019-07-31' AS Date), CAST(14.055142 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'545c105e-f465-4d2d-8910-9d309ba9a534', 195, CAST(N'2019-08-31' AS Date), CAST(15.158425 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'68991f13-fa16-4d50-b3fc-1220ebb45d35', 195, CAST(N'2019-09-30' AS Date), CAST(14.868408 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6a5c861f-cc3d-4fb6-9ba4-38ec14483171', 195, CAST(N'2019-10-31' AS Date), CAST(14.883262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'87155eaf-99c3-4549-85f4-8fb0cd50851d', 195, CAST(N'2019-11-30' AS Date), CAST(14.800316 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'71f128d8-5841-4877-90c4-08c80662e4cc', 195, CAST(N'2019-12-31' AS Date), CAST(14.395644 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0800057d-5e7b-44ed-91d2-c00e928c9049', 195, CAST(N'2020-01-31' AS Date), CAST(14.398037 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'930c3324-05c5-4a33-b4cd-a47510b126b5', 195, CAST(N'2020-02-29' AS Date), CAST(15.017937 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42f84314-52dc-42de-87f9-6c0f596091ab', 44, CAST(N'1990-01-31' AS Date), CAST(4.733900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c4335c0-978f-4ff2-b215-60f87a731207', 44, CAST(N'1990-02-28' AS Date), CAST(4.733900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec81bacd-c0b4-4a87-aea5-102eb20d244c', 44, CAST(N'1990-03-31' AS Date), CAST(4.733900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'caf69806-7450-497b-a494-7c864f566bc4', 44, CAST(N'1990-04-30' AS Date), CAST(4.733852 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7f543267-0d88-4499-af65-5b19d3338ff7', 44, CAST(N'1990-05-31' AS Date), CAST(4.733900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f7359ba3-0099-4374-b8ea-04ac515ef2ea', 44, CAST(N'1990-06-30' AS Date), CAST(4.733876 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d9246bd-cece-4269-b759-cea0a665518a', 44, CAST(N'1990-07-31' AS Date), CAST(4.733900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f03443c-92c6-48dd-b766-3d90fc92348f', 44, CAST(N'1990-08-31' AS Date), CAST(4.733900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'64644ad4-9a21-440a-9e85-4817b9cfc6e8', 44, CAST(N'1990-09-30' AS Date), CAST(4.734216 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'629dde9a-1724-4835-9172-5ce224763bcd', 44, CAST(N'1990-10-31' AS Date), CAST(4.733900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'22269c16-04b8-493c-829d-719dc97cd7db', 44, CAST(N'1990-11-30' AS Date), CAST(4.971358 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eeeae680-2017-454a-86b9-c9388d5e2a92', 44, CAST(N'1990-12-31' AS Date), CAST(5.235200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2360cc96-4619-4500-800e-e8ba9bb73d50', 44, CAST(N'1991-01-31' AS Date), CAST(5.235200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd94efe4f-1eea-46f7-a80c-2a8e7fa08ae3', 44, CAST(N'1991-02-28' AS Date), CAST(5.235200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84790a27-8049-46af-be2a-5b899a4d987c', 44, CAST(N'1991-03-31' AS Date), CAST(5.235200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09760d60-a877-40f4-9abe-2e1b98aa0410', 44, CAST(N'1991-04-30' AS Date), CAST(5.276719 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd94fc5c8-72b0-4d2b-a383-71711b0aa6eb', 44, CAST(N'1991-05-31' AS Date), CAST(5.325723 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d91a195-ec73-41e2-ac9a-5d11c06d597c', 44, CAST(N'1991-06-30' AS Date), CAST(5.366721 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca093c1d-ee1c-4a62-b4e1-6c08fcc1c7c7', 44, CAST(N'1991-07-31' AS Date), CAST(5.369309 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aab50119-4a25-4619-84df-886f17136dc6', 44, CAST(N'1991-08-31' AS Date), CAST(5.372491 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f30d684c-4827-4317-9b3d-961f0c2808f2', 44, CAST(N'1991-09-30' AS Date), CAST(5.386930 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4cde4503-d965-425c-8cc2-b906d913a4d6', 44, CAST(N'1991-10-31' AS Date), CAST(5.391690 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bca748b2-c13f-464a-bca3-fe6d0fd1189f', 44, CAST(N'1991-11-30' AS Date), CAST(5.399422 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7e23f8f5-449d-44df-8e83-3fa0d73421a4', 44, CAST(N'1991-12-31' AS Date), CAST(5.423152 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'87efa4dc-1ab0-4432-b040-f336a879275b', 44, CAST(N'1992-01-31' AS Date), CAST(5.461819 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8797c09d-8ef9-4233-aacc-4902cc7ab008', 44, CAST(N'1992-02-29' AS Date), CAST(5.477631 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'182627bb-98b8-4e34-94bb-fc0418844bc1', 44, CAST(N'1992-03-31' AS Date), CAST(5.487127 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d659714-4621-4456-b614-0c4ce43a9782', 44, CAST(N'1992-04-30' AS Date), CAST(5.509755 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'71eba66b-60b8-4808-acc1-3db21d3f7c2b', 44, CAST(N'1992-05-31' AS Date), CAST(5.518174 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2c16e81f-e8e8-4f57-b210-6e943791628e', 44, CAST(N'1992-06-30' AS Date), CAST(5.489300 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd39d0e2e-2656-4346-a2f3-eafa949a16c7', 44, CAST(N'1992-07-31' AS Date), CAST(5.456370 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f09195e-84ab-43ad-b0ea-dd75af2a65d8', 44, CAST(N'1992-08-31' AS Date), CAST(5.441700 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3533171c-54e2-48c4-a4f0-015da01c1c9f', 44, CAST(N'1992-09-30' AS Date), CAST(5.504755 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'300199b1-f706-4d61-bebc-bc76828a1d30', 44, CAST(N'1992-10-31' AS Date), CAST(5.548600 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'001b70a8-0862-4dee-addc-51877615fb9e', 44, CAST(N'1992-11-30' AS Date), CAST(5.613414 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd10e707c-e7a6-4dad-b136-4f94e6fe8778', 44, CAST(N'1992-12-31' AS Date), CAST(5.810628 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e46c393-76a2-4f75-aab4-2e6f0a7205a0', 44, CAST(N'1993-01-31' AS Date), CAST(5.779612 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3e2a23cd-821d-400a-9aaf-4108755420ac', 44, CAST(N'1993-02-28' AS Date), CAST(5.787433 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48a22b17-e28f-40a4-acef-86bbc1641354', 44, CAST(N'1993-03-31' AS Date), CAST(5.745461 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3a668654-b107-4648-9eb5-0b6a7dbb68c3', 44, CAST(N'1993-04-30' AS Date), CAST(5.720177 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'05c12a5a-584f-438f-8ace-322700a8be11', 44, CAST(N'1993-05-31' AS Date), CAST(5.739193 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'44aef5bc-4c90-4ff4-9b1d-a8631043c077', 44, CAST(N'1993-06-30' AS Date), CAST(5.750368 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'480778ad-4ab2-473f-89a6-5d1bbf037725', 44, CAST(N'1993-07-31' AS Date), CAST(5.775600 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c0cebb13-7156-48b7-8318-dc92bf0ef61d', 44, CAST(N'1993-08-31' AS Date), CAST(5.790623 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a0e77c9f-6b86-4416-b4b1-505afe977cf4', 44, CAST(N'1993-09-30' AS Date), CAST(5.801538 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0fea89c-d114-4fe4-89a2-66e34c89596c', 44, CAST(N'1993-10-31' AS Date), CAST(5.801300 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46135d3d-90e2-489c-b98a-9c4becc69312', 44, CAST(N'1993-11-30' AS Date), CAST(5.808580 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef710f3a-b3c6-4ecd-9db9-e2588fbc660c', 44, CAST(N'1993-12-31' AS Date), CAST(5.821009 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a574c5d5-d401-41af-805b-ae3842a49a2e', 44, CAST(N'1994-01-31' AS Date), CAST(8.721905 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'29acb969-aa66-4c69-a8eb-c53f2af969aa', 44, CAST(N'1994-02-28' AS Date), CAST(8.724869 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7979cf56-b2b2-45ff-aa53-d95f951c45fa', 44, CAST(N'1994-03-31' AS Date), CAST(8.724135 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6b38c1b2-3c57-4542-9a7a-65ac63523666', 44, CAST(N'1994-04-30' AS Date), CAST(8.725079 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'18fa5c87-c92a-4343-b818-82d507ea33db', 44, CAST(N'1994-05-31' AS Date), CAST(8.685909 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'03885831-b2dd-4d56-ba23-e9842143b62b', 44, CAST(N'1994-06-30' AS Date), CAST(8.683586 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc3bf0fd-c382-4ccc-ab13-86bd0949d641', 44, CAST(N'1994-07-31' AS Date), CAST(8.660505 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f50b228-bb47-4c14-b6dc-6785e7a71d41', 44, CAST(N'1994-08-31' AS Date), CAST(8.607226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f7f7132c-8957-4172-a023-661cd7442150', 44, CAST(N'1994-09-30' AS Date), CAST(8.558143 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2b7c7837-a329-4023-94fa-267035ba1e1e', 44, CAST(N'1994-10-31' AS Date), CAST(8.549170 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c8025d0a-d514-4a3a-9f30-6d3fe66607c7', 44, CAST(N'1994-11-30' AS Date), CAST(8.537020 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4cea371-7d87-4135-b0ca-f6eada0675dc', 44, CAST(N'1994-12-31' AS Date), CAST(8.503343 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6e0d8ce0-f6dc-4b0d-9677-0b7d3fcbac18', 44, CAST(N'1995-01-31' AS Date), CAST(8.460805 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'31bcacbd-4e46-4da2-8aa9-4672a91bae2b', 44, CAST(N'1995-02-28' AS Date), CAST(8.455268 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7d91eeaf-6fea-4ca1-874b-71375cf8eef3', 44, CAST(N'1995-03-31' AS Date), CAST(8.448291 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2c7ddc53-cc7e-4c54-b87c-b5635499e9ae', 44, CAST(N'1995-04-30' AS Date), CAST(8.442115 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'63ec9af9-2872-4e7e-998d-6bec6984de0c', 44, CAST(N'1995-05-31' AS Date), CAST(8.337000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bfa84375-8869-4dd1-9008-a3ddba43f0b7', 44, CAST(N'1995-06-30' AS Date), CAST(8.320595 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09cd8b47-1f4d-4f1b-bc35-6ce208d87435', 44, CAST(N'1995-07-31' AS Date), CAST(8.320745 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81a2a974-a379-4d74-ae6f-511fce2c96ae', 44, CAST(N'1995-08-31' AS Date), CAST(8.325274 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd930fe8a-d32e-4780-82fa-9beca680b64e', 44, CAST(N'1995-09-30' AS Date), CAST(8.337440 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a1026b8e-84b3-49b6-9062-2d799f51c12c', 44, CAST(N'1995-10-31' AS Date), CAST(8.335348 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'521cd96f-04c5-48a2-aa83-92c946fd4aa6', 44, CAST(N'1995-11-30' AS Date), CAST(8.333443 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f853c0f9-1d60-4924-996d-25cd80528f84', 44, CAST(N'1995-12-31' AS Date), CAST(8.335015 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'354ca6be-0e2b-409f-b388-759066167ed3', 44, CAST(N'1996-01-31' AS Date), CAST(8.338400 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b84b58f-74e1-44c4-afc2-06be0d76b01f', 44, CAST(N'1996-02-29' AS Date), CAST(8.333750 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2fb40afa-b064-4936-904a-58fb5b76cd80', 44, CAST(N'1996-03-31' AS Date), CAST(8.349543 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f9f61d8-643e-4879-9b79-262102716c88', 44, CAST(N'1996-04-30' AS Date), CAST(8.351450 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fbf15d73-0798-44a7-8d88-a3c0de08b43e', 44, CAST(N'1996-05-31' AS Date), CAST(8.347864 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b528340c-99a8-4574-85c3-5bde7c3ef70a', 44, CAST(N'1996-06-30' AS Date), CAST(8.342360 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'37aad1d9-9501-436d-9597-5c199f276986', 44, CAST(N'1996-07-31' AS Date), CAST(8.340932 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'007eea04-f040-46dc-a8e6-217cc2bdf246', 44, CAST(N'1996-08-31' AS Date), CAST(8.337923 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0a180ca2-d765-4f36-934a-9db559709917', 44, CAST(N'1996-09-30' AS Date), CAST(8.334110 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c764231f-0ceb-4561-860e-73ce3053a4b2', 44, CAST(N'1996-10-31' AS Date), CAST(8.329904 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff92e397-0369-4d78-b2d2-0e89b6cee4b9', 44, CAST(N'1996-11-30' AS Date), CAST(8.329395 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b1abec20-b136-444f-9033-d44d6109188f', 44, CAST(N'1996-12-31' AS Date), CAST(8.329014 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'251e6961-5a01-4675-980f-d93925e46e0a', 44, CAST(N'1997-01-31' AS Date), CAST(8.325967 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81dcc097-c61d-4664-bc56-b7e397c5fb6a', 44, CAST(N'1997-02-28' AS Date), CAST(8.322742 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e84eaf68-3818-42c4-88fe-32ecb2f6260b', 44, CAST(N'1997-03-31' AS Date), CAST(8.325752 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'68fb5173-b8b6-420b-9f59-4abae4e9e44c', 44, CAST(N'1997-04-30' AS Date), CAST(8.325659 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4bcdfcfa-ed6e-439e-a1cc-cfa3b5050577', 44, CAST(N'1997-05-31' AS Date), CAST(8.322852 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d4dc35d-807b-4396-b6e3-973174ffe16b', 44, CAST(N'1997-06-30' AS Date), CAST(8.322371 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd803c3c4-79ba-48ac-9b4b-82b92e381f2d', 44, CAST(N'1997-07-31' AS Date), CAST(8.316182 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae723c8e-f986-4c52-be82-9386e5040eea', 44, CAST(N'1997-08-31' AS Date), CAST(8.318681 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'320f544d-64f5-4b51-a0e5-c6b6aecf8bb1', 44, CAST(N'1997-09-30' AS Date), CAST(8.317070 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76df5fdb-49b2-478b-acfd-9daf76c94fc8', 44, CAST(N'1997-10-31' AS Date), CAST(8.313486 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb35ed4b-0ae9-4f53-adbb-0887cf3f2f29', 44, CAST(N'1997-11-30' AS Date), CAST(8.310894 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'73c5e7ab-2473-441f-b6f0-432c473dd3b1', 44, CAST(N'1997-12-31' AS Date), CAST(8.309900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b238a9c3-cf2f-494f-b9e9-3ee5460cf34e', 44, CAST(N'1998-01-31' AS Date), CAST(8.309445 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c030e18-79cb-4a5a-9fca-d3da8632a06a', 44, CAST(N'1998-02-28' AS Date), CAST(8.307174 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b3e0193d-6057-4c4a-8d53-e5208356b482', 44, CAST(N'1998-03-31' AS Date), CAST(8.307596 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'35402029-67bb-4147-9c71-74d9eb925d62', 44, CAST(N'1998-04-30' AS Date), CAST(8.305800 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'173600b8-ca35-40de-92a6-0a96ad6d4730', 44, CAST(N'1998-05-31' AS Date), CAST(8.308395 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4a50e922-2286-478c-8208-b4c0d03cf953', 44, CAST(N'1998-06-30' AS Date), CAST(8.310000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'41240cbd-d064-4840-aa29-5d975c6a4345', 44, CAST(N'1998-07-31' AS Date), CAST(8.310000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e700c46a-d990-4246-b65b-d9615e41b27f', 44, CAST(N'1998-08-31' AS Date), CAST(8.310000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dbd7c476-c5b3-406b-9274-9fdaf559b4c8', 44, CAST(N'1998-09-30' AS Date), CAST(8.305453 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'446e0007-d6ff-4c91-8185-835f6f90b2e6', 44, CAST(N'1998-10-31' AS Date), CAST(8.277800 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'11988cc5-b49e-4002-a266-6a93127a8c9a', 44, CAST(N'1998-11-30' AS Date), CAST(8.277821 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'759fcecb-f95a-448c-8cc2-6c8ccf1be9ef', 44, CAST(N'1998-12-31' AS Date), CAST(8.277950 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12d0ac40-5822-4553-a839-28639cb9df81', 44, CAST(N'1999-01-31' AS Date), CAST(8.277718 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e64e3e42-f66e-45be-a743-33047b6c3604', 44, CAST(N'1999-02-28' AS Date), CAST(8.278457 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'080a889c-05b4-4711-a23b-af5f865c5571', 44, CAST(N'1999-03-31' AS Date), CAST(8.278095 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'35210d83-5172-4467-98fd-c17118455dec', 44, CAST(N'1999-04-30' AS Date), CAST(8.277879 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'432d8814-39ca-4810-a10d-cea95f9cb1e0', 44, CAST(N'1999-05-31' AS Date), CAST(8.278512 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd69d2e0c-9755-4b69-85df-a29e04220e0c', 44, CAST(N'1999-06-30' AS Date), CAST(8.278157 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4adbbd6c-aa84-43a7-8ac2-41c6730ed9a1', 44, CAST(N'1999-07-31' AS Date), CAST(8.277751 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'026aaf4d-c0c7-4adf-9a8c-e364514378a6', 44, CAST(N'1999-08-31' AS Date), CAST(8.278422 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'972a2957-a057-4113-b5d7-8cb03925b3e3', 44, CAST(N'1999-09-30' AS Date), CAST(8.277978 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d7a0c9b-51df-436f-9e1c-4c463d37c228', 44, CAST(N'1999-10-31' AS Date), CAST(8.278471 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'227e471e-a921-490c-ad2c-12dbd03cb98c', 44, CAST(N'1999-11-30' AS Date), CAST(8.275926 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad27729b-9020-40f5-9bb7-a78e28bdd056', 44, CAST(N'1999-12-31' AS Date), CAST(8.277687 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d9c2def-e6bd-4b5c-ae8b-5b8f5cd69be7', 44, CAST(N'2000-01-31' AS Date), CAST(8.278341 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd50cbcdd-50a6-4a67-9241-185dd14680c6', 44, CAST(N'2000-02-29' AS Date), CAST(8.278250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1df2c0f7-51e8-4c75-9de5-f45f8aae3053', 44, CAST(N'2000-03-31' AS Date), CAST(8.279906 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd80fec82-2a50-4c11-aad6-1f96ff821a38', 44, CAST(N'2000-04-30' AS Date), CAST(8.279269 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02dd088f-b6aa-40d0-9b7f-c3db06d881be', 44, CAST(N'2000-05-31' AS Date), CAST(8.278698 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'80edb605-6233-4d92-b426-4338309695c0', 44, CAST(N'2000-06-30' AS Date), CAST(8.276523 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3a717333-52a0-4f7b-9cfe-1df0d80a5c78', 44, CAST(N'2000-07-31' AS Date), CAST(8.278215 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c476f9c8-24cf-4c06-af83-7a33950016d5', 44, CAST(N'2000-08-31' AS Date), CAST(8.278783 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65360c1f-b077-4c6a-8d3d-cab6f06ea560', 44, CAST(N'2000-09-30' AS Date), CAST(8.278191 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'042e5a26-5d78-487e-afe0-1ccf99e40dfc', 44, CAST(N'2000-10-31' AS Date), CAST(8.278310 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e9e286e9-897d-4ffb-a9a1-78f8209edab0', 44, CAST(N'2000-11-30' AS Date), CAST(8.279730 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91fb8c0f-c908-4646-bc45-8c37d9f55d9d', 44, CAST(N'2000-12-31' AS Date), CAST(8.279851 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5e93cae-7847-4a02-a8ee-cd534925da00', 44, CAST(N'2001-01-31' AS Date), CAST(8.279713 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cd094b43-877e-4b68-bc3b-f557f60658b3', 44, CAST(N'2001-02-28' AS Date), CAST(8.279118 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f9d82c36-333b-4b76-817d-9dfe46587ee4', 44, CAST(N'2001-03-31' AS Date), CAST(8.279947 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cd10eb25-1503-4459-ab2b-c79bbf492285', 44, CAST(N'2001-04-30' AS Date), CAST(8.279370 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8253105-94a0-4f2e-a430-4300f8cbd994', 44, CAST(N'2001-05-31' AS Date), CAST(8.279537 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b63291f-0340-492f-b20e-87d336df3802', 44, CAST(N'2001-06-30' AS Date), CAST(8.278629 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6a46ae6e-f3f1-49a4-88fb-43751b1368b6', 44, CAST(N'2001-07-31' AS Date), CAST(8.279216 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'40e05cd9-c05d-4f67-9cff-bbf5a14f6e1b', 44, CAST(N'2001-08-31' AS Date), CAST(8.279067 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5934b3e2-aa81-4f81-a63b-4be4767c2bdb', 44, CAST(N'2001-09-30' AS Date), CAST(8.278305 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1195af77-cc0d-459f-8558-5f7b878eb047', 44, CAST(N'2001-10-31' AS Date), CAST(8.279226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'023fb7cc-c012-490e-b051-5b31b46ef2a8', 44, CAST(N'2001-11-30' AS Date), CAST(8.276948 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6927b96c-d183-44c6-ab3f-1e604992af19', 44, CAST(N'2001-12-31' AS Date), CAST(8.276880 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c7705738-3792-40b2-81d5-e697516c33f1', 44, CAST(N'2002-01-31' AS Date), CAST(8.276655 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8f4cd30-285b-4f4c-994e-fb828e117824', 44, CAST(N'2002-02-28' AS Date), CAST(8.276685 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'234d2deb-3cb3-476c-9f7b-04c575c04065', 44, CAST(N'2002-03-31' AS Date), CAST(8.277015 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e2039d4d-c119-4300-9299-b5524f6dd76e', 44, CAST(N'2002-04-30' AS Date), CAST(8.277218 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'06ed415b-ee0e-474c-9109-d09e646bae63', 44, CAST(N'2002-05-31' AS Date), CAST(8.277074 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'20cedb6c-8793-4241-b76d-3a51d8c67f90', 44, CAST(N'2002-06-30' AS Date), CAST(8.276942 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bd523811-faee-4d13-9c4f-df3ba107b44c', 44, CAST(N'2002-07-31' AS Date), CAST(8.276855 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'57bd0ed9-d1ef-416c-81ac-78f3cac22e6a', 44, CAST(N'2002-08-31' AS Date), CAST(8.276723 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e2ab3ba6-ff78-406c-a70a-10d689717707', 44, CAST(N'2002-09-30' AS Date), CAST(8.275990 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c872c796-c535-4727-9299-4f7359dd360e', 44, CAST(N'2002-10-31' AS Date), CAST(8.277164 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1930350c-c301-49cb-890b-cfa7fd18b745', 44, CAST(N'2002-11-30' AS Date), CAST(8.277116 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'519bfdb2-0513-4d6e-b37a-607e86d55432', 44, CAST(N'2002-12-31' AS Date), CAST(8.277101 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'343a5f78-52dd-498a-9dc5-d8f8f6e87258', 44, CAST(N'2003-01-31' AS Date), CAST(8.277345 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'acb071aa-7a63-492a-87c5-f137dad0dff4', 44, CAST(N'2003-02-28' AS Date), CAST(8.278111 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6e15f5a-919d-4820-96b3-1980ec2c3cf6', 44, CAST(N'2003-03-31' AS Date), CAST(8.277300 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0e69ea41-3fc8-451b-bb92-2750e86212b2', 44, CAST(N'2003-04-30' AS Date), CAST(8.277193 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af3a7911-63b2-4a48-8006-9c80fb47d9bf', 44, CAST(N'2003-05-31' AS Date), CAST(8.276935 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2af101f2-86d9-4ea1-b843-e4ac788ea6b8', 44, CAST(N'2003-06-30' AS Date), CAST(8.277025 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9dfb313-be4e-4bea-a43f-e2205a67a48c', 44, CAST(N'2003-07-31' AS Date), CAST(8.277315 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a35acc52-c8ba-4538-81da-71ef74182ed8', 44, CAST(N'2003-08-31' AS Date), CAST(8.277069 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'acba918a-1406-4879-9ef5-b5155f5d2899', 44, CAST(N'2003-09-30' AS Date), CAST(8.277146 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3d259774-45dd-4843-99bd-8765f8e84cba', 44, CAST(N'2003-10-31' AS Date), CAST(8.276772 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7cd2b459-19dd-42a5-8e5f-a0fd1d20f68b', 44, CAST(N'2003-11-30' AS Date), CAST(8.276889 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc0ce7ff-a553-481b-bb1f-198157a55a9e', 44, CAST(N'2003-12-31' AS Date), CAST(8.277027 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dcba0966-69be-48b9-91af-b3d35df67e1a', 44, CAST(N'2004-01-31' AS Date), CAST(8.276966 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d74e48b-b2a3-4e03-b9db-38b8003f8c3b', 44, CAST(N'2004-02-29' AS Date), CAST(8.277118 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff29b056-2845-43ef-943d-aa10f5010697', 44, CAST(N'2004-03-31' AS Date), CAST(8.277055 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c802cd8a-10c5-4741-85d8-4cdd516bb79a', 44, CAST(N'2004-04-30' AS Date), CAST(8.276933 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b77ee44-92b2-4ceb-9fa1-80fc46a7b811', 44, CAST(N'2004-05-31' AS Date), CAST(8.277084 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77b92f2d-b3d4-4029-91f4-0c63fb18c9a3', 44, CAST(N'2004-06-30' AS Date), CAST(8.276670 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f687afc6-6a14-429c-a9dc-c57a360b6db5', 44, CAST(N'2004-07-31' AS Date), CAST(8.276723 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13efd721-7155-4fb5-a15d-09c77e735c90', 44, CAST(N'2004-08-31' AS Date), CAST(8.276822 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be477092-e55c-4247-b171-5675a155d85a', 44, CAST(N'2004-09-30' AS Date), CAST(8.240906 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5984fe67-8cdc-464c-b466-72201bb2f50f', 44, CAST(N'2004-10-31' AS Date), CAST(8.318109 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c2beec6-63d1-496f-b3fc-6d25f73a5d7e', 44, CAST(N'2004-11-30' AS Date), CAST(8.276501 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5608a2b8-b8b3-4e1d-979a-58ee7e9c5213', 44, CAST(N'2004-12-31' AS Date), CAST(8.237089 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e472dec4-1b96-41d2-b7c5-c11ddf2ce8cc', 44, CAST(N'2005-01-31' AS Date), CAST(8.276501 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'511fadd0-59b0-4fd5-9a68-d04d21f18428', 44, CAST(N'2005-02-28' AS Date), CAST(8.276501 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'95b5ccc2-233c-49b6-ad77-08c70cfb1b7b', 44, CAST(N'2005-03-31' AS Date), CAST(8.276501 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'67f27a61-21c9-429b-bd5b-e6da65d5c522', 44, CAST(N'2005-04-30' AS Date), CAST(8.276501 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1da9df7e-02e7-409a-9c81-38b86016eb4e', 44, CAST(N'2005-05-31' AS Date), CAST(8.276501 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4de0330e-24e6-41bf-8fda-d03bb2466c67', 44, CAST(N'2005-06-30' AS Date), CAST(8.276501 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aeb74676-439d-447a-8ccc-c5bdbdaa421f', 44, CAST(N'2005-07-31' AS Date), CAST(8.227208 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c83584b1-fef4-4bff-b64b-7783006e643c', 44, CAST(N'2005-08-31' AS Date), CAST(8.101104 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db658625-9d84-4350-afb1-cb94bda1dc8b', 44, CAST(N'2005-09-30' AS Date), CAST(8.091967 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'030d64f2-e814-42dc-9183-656ec3705269', 44, CAST(N'2005-10-31' AS Date), CAST(8.089357 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2cbdc706-e3fe-4586-87cd-894c431298d7', 44, CAST(N'2005-11-30' AS Date), CAST(8.083247 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7124ab09-1de0-4489-9cfe-ba12ccba2b20', 44, CAST(N'2005-12-31' AS Date), CAST(8.073841 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ebf35d60-f1aa-467f-8082-a5105a301133', 44, CAST(N'2006-01-31' AS Date), CAST(8.065878 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82d3f9f4-602d-432d-87f6-362a61d5034b', 44, CAST(N'2006-02-28' AS Date), CAST(8.053495 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0e310fd7-8f09-4862-bb18-2a95354f40b7', 44, CAST(N'2006-03-31' AS Date), CAST(8.037503 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09243fb8-a71d-4f5b-8e28-0a445349b436', 44, CAST(N'2006-04-30' AS Date), CAST(8.013472 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a85ef163-c945-4b6f-91ec-744a48c78a2e', 44, CAST(N'2006-05-31' AS Date), CAST(8.014644 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01db1b70-09d7-4b3c-b831-9c349f965cc0', 44, CAST(N'2006-06-30' AS Date), CAST(8.009830 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c1a0c46e-36a1-4a36-9aa7-83b9f1aaf63a', 44, CAST(N'2006-07-31' AS Date), CAST(7.989321 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e87ba777-b243-4d02-beaa-d0c62466c589', 44, CAST(N'2006-08-31' AS Date), CAST(7.975655 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ab22291-9050-4e8f-9083-250a91a4d57b', 44, CAST(N'2006-09-30' AS Date), CAST(7.936593 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cc17eb22-b7cb-4cbc-a471-49971b91d7c6', 44, CAST(N'2006-10-31' AS Date), CAST(7.903303 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'471be1be-ca1c-4c62-bdf8-e18cdceda7a3', 44, CAST(N'2006-11-30' AS Date), CAST(7.864865 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3526dae9-d96a-4034-881a-9dd70b6e90f2', 44, CAST(N'2006-12-31' AS Date), CAST(7.823381 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cc8fd48f-dbbe-41e1-a4f1-dffea84e15e7', 44, CAST(N'2007-01-31' AS Date), CAST(7.791313 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dddfdd46-3a6c-4e50-9948-d343c43abc16', 44, CAST(N'2007-02-28' AS Date), CAST(7.752734 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8b4381a1-edf6-42bb-84a6-66dec67a554b', 44, CAST(N'2007-03-31' AS Date), CAST(7.738871 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'214998ae-6e0e-4c96-a9ba-23db8b355cad', 44, CAST(N'2007-04-30' AS Date), CAST(7.726306 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'699c4c79-569b-44ab-b229-e8b698abc823', 44, CAST(N'2007-05-31' AS Date), CAST(7.682912 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb025d60-c1f1-46f5-80b3-5c6f23dd7dbf', 44, CAST(N'2007-06-30' AS Date), CAST(7.634071 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e962d63-ffc8-444c-8d52-b812433c3107', 44, CAST(N'2007-07-31' AS Date), CAST(7.575090 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46b3eee9-cdac-40df-8f29-0b5c26073133', 44, CAST(N'2007-08-31' AS Date), CAST(7.574280 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd3db4578-aa14-4c4e-9cf5-704d01fb4f1b', 44, CAST(N'2007-09-30' AS Date), CAST(7.524485 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75283092-b00f-4922-88fa-4e3f8faa29e7', 44, CAST(N'2007-10-31' AS Date), CAST(7.503548 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'05c0cf06-6646-4c68-864e-3bbb961fac49', 44, CAST(N'2007-11-30' AS Date), CAST(7.423750 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0ba2bed5-700f-46dd-a04b-5334479af7f2', 44, CAST(N'2007-12-31' AS Date), CAST(7.376020 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8bd98214-d013-462b-994c-2da8a0f8d483', 44, CAST(N'2008-01-31' AS Date), CAST(7.249022 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1843ead8-b8e4-4aac-89a8-27da281c46b2', 44, CAST(N'2008-02-29' AS Date), CAST(7.169757 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1719235f-9be4-41f8-b2b6-534117f54f98', 44, CAST(N'2008-03-31' AS Date), CAST(7.077886 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f3b6abe9-9c98-4ef0-b4ab-d7ffff4f52df', 44, CAST(N'2008-04-30' AS Date), CAST(6.998476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'de25fa4c-44d2-4cb1-b262-f3b791b442ca', 44, CAST(N'2008-05-31' AS Date), CAST(6.973730 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'edc71712-920c-4f5b-bb75-84c51663392e', 44, CAST(N'2008-06-30' AS Date), CAST(6.902831 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'51f0f6dd-31ab-42e9-bda2-f2d383940c9a', 44, CAST(N'2008-07-31' AS Date), CAST(6.836708 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'72e9a131-94ea-4482-982c-7b4b5881078f', 44, CAST(N'2008-08-31' AS Date), CAST(6.852848 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2c7a5a28-f93a-432e-80e7-a3c9615fbd4d', 44, CAST(N'2008-09-30' AS Date), CAST(6.836846 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1601eb57-61e3-4b8f-9aa9-7396bc45f6f0', 44, CAST(N'2008-10-31' AS Date), CAST(6.835910 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'183c47d0-96db-4c5a-9cbf-c2df17033641', 44, CAST(N'2008-11-30' AS Date), CAST(6.829043 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ab0f4194-aed1-4a77-a775-b63d35411cf9', 44, CAST(N'2008-12-31' AS Date), CAST(6.855309 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c4a01ed5-552c-4319-b064-3a576ffdc098', 44, CAST(N'2009-01-31' AS Date), CAST(6.835868 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'18c6dd0c-a66b-4c29-9c8e-ca12effeb4a3', 44, CAST(N'2009-02-28' AS Date), CAST(6.835980 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30df56e5-fd2c-4483-bcd8-91552c1a41cd', 44, CAST(N'2009-03-31' AS Date), CAST(6.836777 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a23a881a-6779-4bf1-a75e-8bf52be44acf', 44, CAST(N'2009-04-30' AS Date), CAST(6.831958 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'57e4ec26-a1b0-42db-bae5-7a6e0ba274c8', 44, CAST(N'2009-05-31' AS Date), CAST(6.824070 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2c819617-de18-4555-bdc5-6e74d37d8def', 44, CAST(N'2009-06-30' AS Date), CAST(6.833820 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65bc6f2b-4704-4fe3-8a65-562c73602e7b', 44, CAST(N'2009-07-31' AS Date), CAST(6.832476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38d6a2a3-9b7a-49f0-a45b-39e354f0f0c9', 44, CAST(N'2009-08-31' AS Date), CAST(6.832581 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94babbe6-2445-472c-8a58-abb9ec9c0c6c', 44, CAST(N'2009-09-30' AS Date), CAST(6.828620 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c118eac9-2944-488a-aa4c-45d5db12e262', 44, CAST(N'2009-10-31' AS Date), CAST(6.826845 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c1d0fc69-017d-441e-8816-cef0942c4803', 44, CAST(N'2009-11-30' AS Date), CAST(6.827647 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a91f68fa-9a82-4d42-a424-c986d756759e', 44, CAST(N'2009-12-31' AS Date), CAST(6.828029 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'99a4c4c0-df5a-46a8-ba85-ddd4096bf5e6', 44, CAST(N'2010-01-31' AS Date), CAST(6.827097 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5eb2dc30-7336-4db9-931a-ecea8cb34727', 44, CAST(N'2010-02-28' AS Date), CAST(6.829264 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7cc6a35f-db93-41a9-9ae1-ef326d6088a0', 44, CAST(N'2010-03-31' AS Date), CAST(6.826558 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c6f1192-8dc7-4ae6-a798-0cf44030ef83', 44, CAST(N'2010-04-30' AS Date), CAST(6.826047 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'60e560f3-9e9b-450f-aaea-3f41ad7385c9', 44, CAST(N'2010-05-31' AS Date), CAST(6.827277 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4e727d8-f9e8-4b17-a536-0cb58090493f', 44, CAST(N'2010-06-30' AS Date), CAST(6.820827 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'15c6a953-0592-4744-83a1-506029489b31', 44, CAST(N'2010-07-31' AS Date), CAST(6.776216 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6ff0cf08-5e16-44ee-9a97-6f683ed76b8d', 44, CAST(N'2010-08-31' AS Date), CAST(6.786952 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb9a5d6f-3be9-4af5-9ee7-49c07da4062d', 44, CAST(N'2010-09-30' AS Date), CAST(6.748917 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd258fa5b-baa0-4840-aff7-fe4b92f93f74', 44, CAST(N'2010-10-31' AS Date), CAST(6.670287 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9457ee3-3590-4401-ae62-e3d9df75a87a', 44, CAST(N'2010-11-30' AS Date), CAST(6.652460 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'812459a1-2d77-4793-838d-d712a9069fc8', 44, CAST(N'2010-12-31' AS Date), CAST(6.652348 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4180daf-5461-4d8b-8f04-54b237de2958', 44, CAST(N'2011-01-31' AS Date), CAST(6.597297 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f797fc1e-e6d6-4e62-bc21-9bbff4a67444', 44, CAST(N'2011-02-28' AS Date), CAST(6.577043 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'758ae858-3624-4225-b782-aa42aff41d59', 44, CAST(N'2011-03-31' AS Date), CAST(6.566572 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16b8b984-4836-4ff6-ad7e-23cad20648df', 44, CAST(N'2011-04-30' AS Date), CAST(6.526517 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'34781ac9-10cf-410f-8422-982a4e756c5f', 44, CAST(N'2011-05-31' AS Date), CAST(6.495716 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dd297f19-b376-4c51-ae4c-b1225b3e1517', 44, CAST(N'2011-06-30' AS Date), CAST(6.476267 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'902a6b22-6f7b-4fc7-9d0e-b7a6dcc2480a', 44, CAST(N'2011-07-31' AS Date), CAST(6.455281 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8a426f5-b3e9-4a39-a9ab-30252462e3fe', 44, CAST(N'2011-08-31' AS Date), CAST(6.405545 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13c45645-af09-4cbd-865a-13c77339f4fd', 44, CAST(N'2011-09-30' AS Date), CAST(6.389371 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ca2dbee-1935-4f1e-8abe-4ee861fbe4df', 44, CAST(N'2011-10-31' AS Date), CAST(6.371935 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6feb3b5e-1965-4da3-8150-ff057c9cff57', 44, CAST(N'2011-11-30' AS Date), CAST(6.356067 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b3df367-3875-41e1-a920-166309826d5e', 44, CAST(N'2011-12-31' AS Date), CAST(6.344497 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'58f3de62-ddbc-4882-9e14-789046be0008', 44, CAST(N'2012-01-31' AS Date), CAST(6.315044 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd57e6919-dbc3-40e5-bafb-bdf067ffb7e6', 44, CAST(N'2012-02-29' AS Date), CAST(6.300476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a6ccd40c-9431-4f96-adc9-8b2180ea02b4', 44, CAST(N'2012-03-31' AS Date), CAST(6.311163 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a23dcd2a-5738-4c0b-bb77-e927c9b06752', 44, CAST(N'2012-04-30' AS Date), CAST(6.303470 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2522aa47-e1db-460f-bdfd-eb044b31911f', 44, CAST(N'2012-05-31' AS Date), CAST(6.316919 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b26525bc-b78b-4314-8674-7c49b2b63ec5', 44, CAST(N'2012-06-30' AS Date), CAST(6.365433 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd58ffa17-ff93-423f-8ab9-970c7aa04512', 44, CAST(N'2012-07-31' AS Date), CAST(6.373606 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94a644f0-87f3-4c6d-a7fc-b7278d32b179', 44, CAST(N'2012-08-31' AS Date), CAST(6.361577 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed31cf8b-3033-4188-b32f-013c2cef1e3e', 44, CAST(N'2012-09-30' AS Date), CAST(6.324183 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec5504c6-75b7-45fe-92d1-eb50fa352dbe', 44, CAST(N'2012-10-31' AS Date), CAST(6.274832 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cfb3103f-6d74-4ab8-9909-312e27bf4d1d', 44, CAST(N'2012-11-30' AS Date), CAST(6.240017 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c2806f5-a0eb-498f-a4d7-2904eb36310a', 44, CAST(N'2012-12-31' AS Date), CAST(6.235480 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad598643-d6d5-4825-96cb-cd46f5f7814b', 44, CAST(N'2013-01-31' AS Date), CAST(6.224040 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'320ac5a0-9302-4f14-b393-83b2302df8da', 44, CAST(N'2013-02-28' AS Date), CAST(6.233512 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0e70b924-4923-480b-a82e-43d32600455b', 44, CAST(N'2013-03-31' AS Date), CAST(6.216287 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c50365f-5335-4b41-bbb9-3a8069451c90', 44, CAST(N'2013-04-30' AS Date), CAST(6.187123 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cc551816-8711-4555-84ae-47342a1e8b85', 44, CAST(N'2013-05-31' AS Date), CAST(6.142379 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3a9976be-0da8-464a-921c-ae68f30d0f84', 44, CAST(N'2013-06-30' AS Date), CAST(6.138663 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02c03eaa-43cb-4b2c-889e-bd3aa598f3e9', 44, CAST(N'2013-07-31' AS Date), CAST(6.138664 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b205df5-713b-4401-9ece-9c3b17518397', 44, CAST(N'2013-08-31' AS Date), CAST(6.122006 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3747d446-e474-4e3b-a32a-6158992ea236', 44, CAST(N'2013-09-30' AS Date), CAST(6.121690 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cd2c6fad-040d-4c1d-a7f5-73e9b0591ccc', 44, CAST(N'2013-10-31' AS Date), CAST(6.113055 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13744222-64d4-42f7-a08e-96ceb542cde4', 44, CAST(N'2013-11-30' AS Date), CAST(6.114147 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9a0e473-ad09-482f-96a0-6c1c5556473d', 44, CAST(N'2013-12-31' AS Date), CAST(6.082261 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16395393-c7a8-4666-9cbe-8f2524d13488', 44, CAST(N'2014-01-31' AS Date), CAST(6.074065 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f951e12b-7ef6-4436-b29c-1384dbaf851d', 44, CAST(N'2014-02-28' AS Date), CAST(6.075162 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd7fc27ec-57d1-44f1-8d8f-51a91adfee08', 44, CAST(N'2014-03-31' AS Date), CAST(6.169652 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0a2b863e-1c5e-4542-a089-a952b0a289a0', 44, CAST(N'2014-04-30' AS Date), CAST(6.223480 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5da1579d-942f-4f43-9eff-abfe48c4cc8e', 44, CAST(N'2014-05-31' AS Date), CAST(6.240068 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81c1c1de-7af2-4b14-8eb3-9c2c6be00c88', 44, CAST(N'2014-06-30' AS Date), CAST(6.234197 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2bd62aa6-6cca-496c-92e2-998010fe2549', 44, CAST(N'2014-07-31' AS Date), CAST(6.135827 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91e90001-b5d7-464e-88e6-12f1eea63b10', 44, CAST(N'2014-08-31' AS Date), CAST(6.157152 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb0465d3-6440-4526-aac1-af4da660d8bf', 44, CAST(N'2014-09-30' AS Date), CAST(6.139091 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a3eb457-f5ec-42bb-be13-54c60c31e7fd', 44, CAST(N'2014-10-31' AS Date), CAST(6.127435 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b8de955-413a-4586-a756-5f0a24fc267b', 44, CAST(N'2014-11-30' AS Date), CAST(6.125190 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46eb5bf7-cefe-4cb9-87e5-95fbc2d32874', 44, CAST(N'2014-12-31' AS Date), CAST(6.189887 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c42bc661-7fb4-4f67-9850-b36edf3fb39d', 44, CAST(N'2015-01-31' AS Date), CAST(6.217386 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9ad1e5f1-9512-4000-a934-69a56e9b2550', 44, CAST(N'2015-02-28' AS Date), CAST(6.250589 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'55916b59-e3ba-4e25-a645-27b1181420f4', 44, CAST(N'2015-03-31' AS Date), CAST(6.241610 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9a26c12-b728-4693-abd9-d91e67719ec3', 44, CAST(N'2015-04-30' AS Date), CAST(6.201223 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f507dd00-7312-40c8-8fbc-5c4667dbc522', 44, CAST(N'2015-05-31' AS Date), CAST(6.203340 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb3d647b-07b8-4c26-9396-6670afd4931f', 44, CAST(N'2015-06-30' AS Date), CAST(6.206197 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'740967a0-74a6-4e2a-a8ff-a4ccef4b177f', 44, CAST(N'2015-07-31' AS Date), CAST(6.208335 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f067567-798c-492b-bc28-20fedf3998eb', 44, CAST(N'2015-08-31' AS Date), CAST(6.326845 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'249347f6-72bf-4b51-8b8b-7234fbaa58ed', 44, CAST(N'2015-09-30' AS Date), CAST(6.368933 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f9160f9-f43f-4177-9cc5-7969f762c6ff', 44, CAST(N'2015-10-31' AS Date), CAST(6.350316 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08737613-245f-477f-8357-b20a449fa6a2', 44, CAST(N'2015-11-30' AS Date), CAST(6.368297 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aabb5e01-aa89-4c28-b958-d167fa1ebf3d', 44, CAST(N'2015-12-31' AS Date), CAST(6.451177 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eff98a44-9425-4f43-a84e-f6dd0cdc089d', 44, CAST(N'2016-01-31' AS Date), CAST(6.566271 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'29e81871-d43c-4c03-99e7-58486e2663c9', 44, CAST(N'2016-02-29' AS Date), CAST(6.550959 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9f1463b-f0bd-407d-98be-374efe9b0e4a', 44, CAST(N'2016-03-31' AS Date), CAST(6.505371 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b6f4a5e-33e5-4d8c-bddf-eee8a5a98da6', 44, CAST(N'2016-04-30' AS Date), CAST(6.477180 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12661167-9468-41a8-85ff-a90e0951b73b', 44, CAST(N'2016-05-31' AS Date), CAST(6.526400 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f940074c-0c15-496c-8cd9-98f4f0c6b2c2', 44, CAST(N'2016-06-30' AS Date), CAST(6.587600 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c8226502-2967-4018-9747-37302ba47a78', 44, CAST(N'2016-07-31' AS Date), CAST(6.676932 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fb131e7c-374e-4032-a152-f717eeaf547b', 44, CAST(N'2016-08-31' AS Date), CAST(6.649181 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca370b87-2f76-48a9-9ab0-01e5593406e9', 44, CAST(N'2016-09-30' AS Date), CAST(6.676762 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9928841c-ca7f-4ded-8d37-770cf8904a9d', 44, CAST(N'2016-10-31' AS Date), CAST(6.724935 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4be80968-0e9a-480a-aff8-d253db9df5db', 44, CAST(N'2016-11-30' AS Date), CAST(6.844860 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fb40a153-0dee-4ce2-9ec5-760be951ff4f', 44, CAST(N'2016-12-31' AS Date), CAST(6.924758 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e452928e-5ed4-414c-819c-9b61ef0b370c', 44, CAST(N'2017-01-31' AS Date), CAST(6.896765 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e6a77132-3afb-4935-93ef-86a754530bae', 44, CAST(N'2017-02-28' AS Date), CAST(6.872388 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'92dba4b0-0a35-4972-bbed-7ddcd13691dc', 44, CAST(N'2017-03-31' AS Date), CAST(6.894352 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6cc46130-3f06-4d4c-abbd-0cb17be1e858', 44, CAST(N'2017-04-30' AS Date), CAST(6.893129 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'40cfd486-72f1-4729-9eff-488109983d74', 44, CAST(N'2017-05-31' AS Date), CAST(6.882600 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'40596e70-0859-4658-b2df-7fbcb753b728', 44, CAST(N'2017-06-30' AS Date), CAST(6.809243 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'adb584d5-6cff-45fe-9328-57747fcad532', 44, CAST(N'2017-07-31' AS Date), CAST(6.771358 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76f1a5f5-e9f2-4704-a4c4-9866bb98fa1e', 44, CAST(N'2017-08-31' AS Date), CAST(6.659680 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2a70dddd-8509-4a3b-9e45-e54d7ca8c915', 44, CAST(N'2017-09-30' AS Date), CAST(6.568118 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4492ed07-dd78-40f5-8d0e-cc573e6864b0', 44, CAST(N'2017-10-31' AS Date), CAST(6.627632 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01e5f9cb-266d-432b-bd4c-2b13b30772d5', 44, CAST(N'2017-11-30' AS Date), CAST(6.623570 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c190232d-c39b-47b7-a37f-dc7f65613909', 44, CAST(N'2017-12-31' AS Date), CAST(6.589548 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'de09c4ad-ce5d-4b12-9ee2-771ffd21a912', 44, CAST(N'2018-01-31' AS Date), CAST(6.426539 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0249655a-b320-46df-be65-94a8e9c3fba9', 44, CAST(N'2018-02-28' AS Date), CAST(6.321657 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd73ae061-c7d4-4535-aef6-989a84f9cd1c', 44, CAST(N'2018-03-31' AS Date), CAST(6.325210 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84c516dc-4639-41cb-91bc-1bc69cde25cc', 44, CAST(N'2018-04-30' AS Date), CAST(6.305093 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ee27db06-8ce9-4ac7-a6a5-57e2d6543394', 44, CAST(N'2018-05-31' AS Date), CAST(6.374674 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'97e044fc-e26d-46ed-9f38-192f9f77b556', 44, CAST(N'2018-06-30' AS Date), CAST(6.466713 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'db1066b1-5b56-46e1-9c29-dcb061e61703', 44, CAST(N'2018-07-31' AS Date), CAST(6.721739 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd3e8d3f6-d083-458a-9474-db332a2285b7', 44, CAST(N'2018-08-31' AS Date), CAST(6.851623 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'76eaf244-ff6a-458e-8c90-38d981b27317', 44, CAST(N'2018-09-30' AS Date), CAST(6.860237 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2afcb659-12c5-450e-9e4f-62b203181320', 44, CAST(N'2018-10-31' AS Date), CAST(6.919797 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b12e54d8-f587-4c6b-a737-7d904723f0ec', 44, CAST(N'2018-11-30' AS Date), CAST(6.937675 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ab9665b6-6692-4da9-a5cc-b725d851d9e5', 44, CAST(N'2018-12-31' AS Date), CAST(6.892342 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'06d6789d-1e25-420c-ae52-56c2145db024', 44, CAST(N'2019-01-31' AS Date), CAST(6.791742 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'713744da-f9e5-4546-be9b-fe91a91a77c0', 44, CAST(N'2019-02-28' AS Date), CAST(6.741967 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'59490606-cd7f-41f0-b01a-2f428afb8c0d', 44, CAST(N'2019-03-31' AS Date), CAST(6.713879 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4bd34db3-3cf8-4210-b87a-0c8ba8984a78', 44, CAST(N'2019-04-30' AS Date), CAST(6.716045 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4a2cec2-9fb6-4ce3-b1f3-0306b744ca91', 44, CAST(N'2019-05-31' AS Date), CAST(6.852565 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f6d308f-2871-45f5-9d48-10ea8a4aaebd', 44, CAST(N'2019-06-30' AS Date), CAST(6.897927 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f98d363-2f05-4d28-9bf9-9b0c4403cb7f', 44, CAST(N'2019-07-31' AS Date), CAST(6.879839 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1182b0b8-4e01-47da-95c8-92b3dcd76663', 44, CAST(N'2019-08-31' AS Date), CAST(7.060600 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef1a2a80-3755-4a20-bf03-286083dd02fc', 44, CAST(N'2019-09-30' AS Date), CAST(7.115050 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'717bc00a-0c1e-4774-a067-f0d1f57e82a9', 44, CAST(N'2019-10-31' AS Date), CAST(7.095968 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b4178ed-8aab-4015-b49b-bc4ec0f794e7', 44, CAST(N'2019-11-30' AS Date), CAST(7.021350 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7fefc5cf-b473-4250-83af-30539bd7454a', 44, CAST(N'2019-12-31' AS Date), CAST(7.011116 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ebfd996-ff16-47e3-b53d-3454fcb15294', 44, CAST(N'2020-01-31' AS Date), CAST(6.924400 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02d7fd37-7f88-4f69-8b08-34ea8f8dc135', 44, CAST(N'2020-02-29' AS Date), CAST(6.995876 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17afaa8c-8125-4d5b-8301-1f06dc514d35', 29, CAST(N'2000-02-29' AS Date), CAST(1.775516 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd622a88a-0800-4251-9546-69d9081b9020', 29, CAST(N'2000-03-31' AS Date), CAST(1.742038 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f77ee58-aa6a-42f2-a36e-b2e6b7668985', 29, CAST(N'2000-04-30' AS Date), CAST(1.764930 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7adac02-e916-40b8-9c0c-05170187b83a', 29, CAST(N'2000-05-31' AS Date), CAST(1.822632 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f2375ecd-9b68-4952-b435-92f0b4d93275', 29, CAST(N'2000-06-30' AS Date), CAST(1.807150 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9854c982-3536-4ff8-8c46-d38b14961a91', 29, CAST(N'2000-07-31' AS Date), CAST(1.797644 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'88d7eb72-22d8-4bbb-a31b-6cbe924a6340', 29, CAST(N'2000-08-31' AS Date), CAST(1.806388 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6230698-47c1-4881-aabf-bfd6e6888a35', 29, CAST(N'2000-09-30' AS Date), CAST(1.835347 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43173462-d48a-4d37-b152-1611134aa436', 29, CAST(N'2000-10-31' AS Date), CAST(1.875608 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3250732c-d552-40a2-a77a-d086d99cb351', 29, CAST(N'2000-11-30' AS Date), CAST(1.943566 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f1d2b9d4-f293-4bef-8f90-8bd54fafb618', 29, CAST(N'2000-12-31' AS Date), CAST(1.963841 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'78250ccf-18b5-409b-89de-aee9b09c31e0', 29, CAST(N'2001-01-31' AS Date), CAST(1.955037 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd46a4748-2226-48dd-bc6c-ebe8e4a42210', 29, CAST(N'2001-02-28' AS Date), CAST(2.002876 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00d42158-0ed4-4930-b27c-1064f3f967d6', 29, CAST(N'2001-03-31' AS Date), CAST(2.088295 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b14e11c-73e7-443d-8e1f-a41137bb8367', 29, CAST(N'2001-04-30' AS Date), CAST(2.190432 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d0f9cd7-f1ce-4e74-b434-b13d0364394b', 29, CAST(N'2001-05-31' AS Date), CAST(2.286188 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'491ad932-fb12-4c50-a14b-9d79a6d830cd', 29, CAST(N'2001-06-30' AS Date), CAST(2.380849 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48db682d-ef80-4f69-928c-b907df91814d', 29, CAST(N'2001-07-31' AS Date), CAST(2.460499 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c1f64ad-288a-45a2-9e82-438b25fb6c1c', 29, CAST(N'2001-08-31' AS Date), CAST(2.508024 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'303b85a4-c1f0-4e90-b382-6e4651cd2e25', 29, CAST(N'2001-09-30' AS Date), CAST(2.661463 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c7e505b9-8447-49b7-b9f9-d645b280e26e', 29, CAST(N'2001-10-31' AS Date), CAST(2.738870 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'107afcae-5358-4614-9c2c-c58aa20c87f9', 29, CAST(N'2001-11-30' AS Date), CAST(2.552545 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'356aa4e7-7c3e-42e6-a878-4ed654b5acbf', 29, CAST(N'2001-12-31' AS Date), CAST(2.375398 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f741273-3fa4-40a5-abbf-6c6f91bb183e', 29, CAST(N'2002-01-31' AS Date), CAST(2.371507 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cebce8fb-2646-41b4-a4fa-2383b45b3482', 29, CAST(N'2002-02-28' AS Date), CAST(2.427110 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'39102265-3bad-453d-8e59-8f9ac1de6fb2', 29, CAST(N'2002-03-31' AS Date), CAST(2.347098 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd35d5089-9d76-48b8-ac6e-d4b6945174ce', 29, CAST(N'2002-04-30' AS Date), CAST(2.316975 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'908ccb2a-447c-4dad-b87f-27bd1c9ae83e', 29, CAST(N'2002-05-31' AS Date), CAST(2.463637 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'951308ec-b9af-4750-9eee-d3d2e6007275', 29, CAST(N'2002-06-30' AS Date), CAST(2.696918 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fafaffc0-c663-407b-8b5f-a0f1062787ef', 29, CAST(N'2002-07-31' AS Date), CAST(2.896250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2da1f8e8-a10f-497d-a444-b76ee15f2e45', 29, CAST(N'2002-08-31' AS Date), CAST(3.128889 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'113f4653-b9fe-4b6d-be78-3893a467ac8a', 29, CAST(N'2002-09-30' AS Date), CAST(3.274910 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4e610bf9-516e-49d8-a2ac-fd9f6aac0553', 29, CAST(N'2002-10-31' AS Date), CAST(3.795720 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9964bb52-3e00-483f-b25c-957c80f77a59', 29, CAST(N'2002-11-30' AS Date), CAST(3.583308 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'980e686d-f1a7-4b96-97bc-207958c0d9ec', 29, CAST(N'2002-12-31' AS Date), CAST(3.647370 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'447dde6f-6c2f-4adf-bca6-a36047136e18', 29, CAST(N'2003-01-31' AS Date), CAST(3.428419 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77f21cd3-12d5-4527-9b28-f400f9f3080d', 29, CAST(N'2003-02-28' AS Date), CAST(3.588532 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1922845a-91ae-48aa-9fc1-7acd1770facd', 29, CAST(N'2003-03-31' AS Date), CAST(3.488896 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e7ea0674-82c9-4b9b-a441-6b16316214a0', 29, CAST(N'2003-04-30' AS Date), CAST(3.181271 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48a3961e-fdc8-4ddf-9601-6393ee4eaad3', 29, CAST(N'2003-05-31' AS Date), CAST(2.959045 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'24c9e4d8-4b69-4a7e-bf49-e1cf134b4e8c', 29, CAST(N'2003-06-30' AS Date), CAST(2.892652 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bdf62fd4-9c86-42a4-9419-fcadfe2d58c8', 29, CAST(N'2003-07-31' AS Date), CAST(2.871462 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'706e5a47-9a82-422e-8072-bfa1a32f63dd', 29, CAST(N'2003-08-31' AS Date), CAST(2.999787 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ea601bd0-c7be-4ecc-a41a-80175e5545c8', 29, CAST(N'2003-09-30' AS Date), CAST(2.928815 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6b7ac341-e28e-44a1-ac95-fb63fceee76e', 29, CAST(N'2003-10-31' AS Date), CAST(2.858806 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5f3f5fb-e3a7-47eb-accb-97d5257e75e6', 29, CAST(N'2003-11-30' AS Date), CAST(2.906184 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17acd6d7-d610-4464-bd05-2c7e24cc33b3', 29, CAST(N'2003-12-31' AS Date), CAST(2.929444 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8dac25b-8abe-49bf-8e0b-02cbb3121f5f', 29, CAST(N'2004-01-31' AS Date), CAST(2.850528 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'944af6d0-a3bb-4447-b733-a618906a2457', 29, CAST(N'2004-02-29' AS Date), CAST(2.928781 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c799d59c-9893-4255-8036-0004dc2d58a5', 29, CAST(N'2004-03-31' AS Date), CAST(2.902375 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f79c713b-7990-4b34-bc92-1a9ca5d28458', 29, CAST(N'2004-04-30' AS Date), CAST(2.902667 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2bc9ea4-2ef5-406d-b9ec-88e30041af10', 29, CAST(N'2004-05-31' AS Date), CAST(3.081763 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1932adfe-a24f-4f82-8e69-cdb4ebc93dda', 29, CAST(N'2004-06-30' AS Date), CAST(3.130975 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a968b747-1248-4f09-8290-c61eff055de5', 29, CAST(N'2004-07-31' AS Date), CAST(3.038841 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'153e206e-1626-43d1-8b20-2c79098e2eaa', 29, CAST(N'2004-08-31' AS Date), CAST(3.006456 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7cd427a-97c4-478c-b78e-4656cb18db01', 29, CAST(N'2004-09-30' AS Date), CAST(2.881911 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'527dda3e-bbc1-4dab-80f9-7f158bd07d01', 29, CAST(N'2004-10-31' AS Date), CAST(2.738521 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a2836e7f-eb56-4923-b9a6-d12006818834', 29, CAST(N'2004-11-30' AS Date), CAST(2.795705 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c1f4c9e6-21d8-4f11-a592-214bb262c0a9', 29, CAST(N'2004-12-31' AS Date), CAST(2.712410 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7fb5afcb-6bfb-4fcf-9cca-05da1a8a2877', 29, CAST(N'2005-01-31' AS Date), CAST(2.698038 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'48855585-faa8-4909-a17b-fc35878ade79', 29, CAST(N'2005-02-28' AS Date), CAST(2.609021 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b2a0820-1f2a-41f7-b921-7f9ccb5ccc6c', 29, CAST(N'2005-03-31' AS Date), CAST(2.681095 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b3284347-27d8-43f5-9d4f-6571b1f66457', 29, CAST(N'2005-04-30' AS Date), CAST(2.586615 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'219a09f1-a50a-451b-aaa8-467476f626ec', 29, CAST(N'2005-05-31' AS Date), CAST(2.462781 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8862af5-c182-4505-9a16-346b951811f3', 29, CAST(N'2005-06-30' AS Date), CAST(2.419891 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4d268bc6-8176-4f7b-9a89-edcee26ddab3', 29, CAST(N'2005-07-31' AS Date), CAST(2.370313 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f5a8d9b4-c82f-4128-a156-74be7e8bc6c6', 29, CAST(N'2005-08-31' AS Date), CAST(2.276961 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aa26806a-b077-47c1-aadb-7e6fa6334ca2', 29, CAST(N'2005-09-30' AS Date), CAST(2.302369 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb15b0c5-3ec5-4ade-88f8-a609f26fb738', 29, CAST(N'2005-10-31' AS Date), CAST(2.252797 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01a003ef-1e23-450c-8116-6ec617d60a16', 29, CAST(N'2005-11-30' AS Date), CAST(2.212679 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'53d83e63-42dd-4cc9-a4ea-53c2a18f716b', 29, CAST(N'2005-12-31' AS Date), CAST(2.273409 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'905d50d7-5f30-44c3-a2a7-dabdf5a9ac6d', 29, CAST(N'2006-01-31' AS Date), CAST(2.278224 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4b9b9159-a4aa-4b5f-8942-f5b3a312a428', 29, CAST(N'2006-02-28' AS Date), CAST(2.164468 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7e4640a1-6f95-46b3-922d-58e12133a82f', 29, CAST(N'2006-03-31' AS Date), CAST(2.147589 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b045ebc6-546b-4fb2-b67e-76666405a89e', 29, CAST(N'2006-04-30' AS Date), CAST(2.130777 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fd3d350b-6ebf-4940-8b8b-16e599411810', 29, CAST(N'2006-05-31' AS Date), CAST(2.164998 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c58c6682-ff7c-4448-8d56-2ded0a9b1c97', 29, CAST(N'2006-06-30' AS Date), CAST(2.256837 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1dc71b99-b408-489e-9502-51abaa7a3ada', 29, CAST(N'2006-07-31' AS Date), CAST(2.185402 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5829d86-d856-49fb-9c76-bf724c357379', 29, CAST(N'2006-08-31' AS Date), CAST(2.158173 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b3b8ce4-5d00-4240-b567-e2fdfeeaf8f9', 29, CAST(N'2006-09-30' AS Date), CAST(2.164840 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3e29fed0-9fba-409d-8bd1-757fbcb75062', 29, CAST(N'2006-10-31' AS Date), CAST(2.147021 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fbe4b3fb-7fe4-4ceb-9499-bb948233aee4', 29, CAST(N'2006-11-30' AS Date), CAST(2.154340 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08c7dfe1-47b3-4977-a5a4-b519772049ba', 29, CAST(N'2006-12-31' AS Date), CAST(2.149204 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e117a602-e9cc-4759-9a35-a7f0b8476125', 29, CAST(N'2007-01-31' AS Date), CAST(2.139213 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dea51d10-2439-4811-a77b-86682a041168', 29, CAST(N'2007-02-28' AS Date), CAST(2.095424 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3e7b604-e28f-4198-bb73-3532785f1bfb', 29, CAST(N'2007-03-31' AS Date), CAST(2.092910 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'502e2b0c-f1a2-4554-bf5b-a2e0432165eb', 29, CAST(N'2007-04-30' AS Date), CAST(2.033722 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff9eaa83-7f32-4d9b-ad3e-edba13be7e65', 29, CAST(N'2007-05-31' AS Date), CAST(1.988591 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e352f71e-cd19-46a7-98ad-4ef36b3d137a', 29, CAST(N'2007-06-30' AS Date), CAST(1.931018 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f045ace5-5835-4a42-8a6e-15834aafb6db', 29, CAST(N'2007-07-31' AS Date), CAST(1.883679 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e5e3a3f1-5bdc-4c3a-ae7d-94833005c313', 29, CAST(N'2007-08-31' AS Date), CAST(1.965982 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6462788f-f612-49fd-acd8-1546361f08ae', 29, CAST(N'2007-09-30' AS Date), CAST(1.907458 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3741fca5-3ae4-4a07-9c86-b8d88f37f72b', 29, CAST(N'2007-10-31' AS Date), CAST(1.804311 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81f3e0f4-00c6-49a2-be2e-95b30360be76', 29, CAST(N'2007-11-30' AS Date), CAST(1.766636 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'152e8aac-590a-4762-b932-48a821aceabf', 29, CAST(N'2007-12-31' AS Date), CAST(1.785940 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5d87aab-9380-4edd-bac1-c8eb4460cdff', 29, CAST(N'2008-01-31' AS Date), CAST(1.775691 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b5f0bdc-ce36-4fe7-9fc6-f2b34a66eb9e', 29, CAST(N'2008-02-29' AS Date), CAST(1.733190 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9c8f45f-0073-4dff-9ec8-74bbba9aa3e3', 29, CAST(N'2008-03-31' AS Date), CAST(1.706776 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85e89fd0-1f5d-45a6-9dcf-75b2035f30c4', 29, CAST(N'2008-04-30' AS Date), CAST(1.689191 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd489f8fc-daeb-4f3e-8115-d9dc2acdc1ae', 29, CAST(N'2008-05-31' AS Date), CAST(1.661548 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ba841f7d-5b25-4e8e-87f5-8ad56200aaac', 29, CAST(N'2008-06-30' AS Date), CAST(1.619402 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30122157-57ca-4120-bf6e-dfc1c5dd5a07', 29, CAST(N'2008-07-31' AS Date), CAST(1.593409 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6f7d7aa0-cc02-43d8-99e0-516587f61994', 29, CAST(N'2008-08-31' AS Date), CAST(1.610736 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'53b298c0-9b2c-49b7-9bde-b43ee1fd2083', 29, CAST(N'2008-09-30' AS Date), CAST(1.784974 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af6ea009-ba92-41a7-b79a-a8d6afda6c05', 29, CAST(N'2008-10-31' AS Date), CAST(2.153286 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7e8718de-4574-4daf-981c-887c2a3bb08e', 29, CAST(N'2008-11-30' AS Date), CAST(2.258746 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e20486e8-863e-4f91-b363-b0afdc4ba644', 29, CAST(N'2008-12-31' AS Date), CAST(2.399435 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b3566edd-9c92-4e65-b581-a8951c914763', 29, CAST(N'2009-01-31' AS Date), CAST(2.312487 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23fcb0e1-0f71-4bb8-83a3-6ce1788c37a4', 29, CAST(N'2009-02-28' AS Date), CAST(2.316709 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'90caa3fe-e658-4d05-a205-011e85c5d7df', 29, CAST(N'2009-03-31' AS Date), CAST(2.318191 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'982318fd-ca88-46d0-84be-2a7c06e34732', 29, CAST(N'2009-04-30' AS Date), CAST(2.214705 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21d1729a-ead8-4119-8eb9-40dce3971c5c', 29, CAST(N'2009-05-31' AS Date), CAST(2.075732 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85818f2b-b1ee-4558-aafc-2bd33d302417', 29, CAST(N'2009-06-30' AS Date), CAST(1.955081 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2275ed9c-5350-4ca4-ab3c-ad6480898bbd', 29, CAST(N'2009-07-31' AS Date), CAST(1.932280 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3d22a4a0-cbcf-4a1d-99fc-192770e84439', 29, CAST(N'2009-08-31' AS Date), CAST(1.846379 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc831d98-2327-4150-9009-ab6abb56245e', 29, CAST(N'2009-09-30' AS Date), CAST(1.822227 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5087830c-30d5-4111-b7a0-075a4f5ea8c3', 29, CAST(N'2009-10-31' AS Date), CAST(1.739448 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd656a55e-2a8b-4f1e-a883-a063d372cfa1', 29, CAST(N'2009-11-30' AS Date), CAST(1.728998 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0ac5bc95-f8df-4d68-b8da-159827b2020c', 29, CAST(N'2009-12-31' AS Date), CAST(1.752810 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5daae716-570b-442e-9c27-3dcb7dadc256', 29, CAST(N'2010-01-31' AS Date), CAST(1.777926 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb904a55-f949-4c2d-80e7-93870ccb3152', 29, CAST(N'2010-02-28' AS Date), CAST(1.845119 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd73e2303-51da-4174-879c-36b655153666', 29, CAST(N'2010-03-31' AS Date), CAST(1.788047 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c43d0208-259a-4162-9f2a-27ca36e8036c', 29, CAST(N'2010-04-30' AS Date), CAST(1.761090 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a2ac05d5-0d03-4747-a200-5ba5f0a55a70', 29, CAST(N'2010-05-31' AS Date), CAST(1.808747 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0477865f-0dc6-441b-8fa3-6b47a7980603', 29, CAST(N'2010-06-30' AS Date), CAST(1.806767 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c43c22c-a004-4f02-8c48-de53462d8c93', 29, CAST(N'2010-07-31' AS Date), CAST(1.770602 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61ed7599-eabb-4b6c-bd59-e458782e61c9', 29, CAST(N'2010-08-31' AS Date), CAST(1.759787 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fe115d49-ffef-4aba-bd24-18c11ff97e0a', 29, CAST(N'2010-09-30' AS Date), CAST(1.720590 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33efd31e-ded3-4247-9998-bc2095aa09b7', 29, CAST(N'2010-10-31' AS Date), CAST(1.683139 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce42a3eb-6326-431f-af0a-80041bdfdc67', 29, CAST(N'2010-11-30' AS Date), CAST(1.712721 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'996e76a2-db30-49f4-97f8-3579cabeecfe', 29, CAST(N'2010-12-31' AS Date), CAST(1.696903 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e012372-f0c1-4e60-8883-e1ec5d0ec55e', 29, CAST(N'2011-01-31' AS Date), CAST(1.674648 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4b7421a-6b25-4d5f-9c02-9b39e2202e6d', 29, CAST(N'2011-02-28' AS Date), CAST(1.667763 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8d36e66b-81a9-427b-8ded-d062fc0c9a83', 29, CAST(N'2011-03-31' AS Date), CAST(1.657788 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3185567e-9858-43de-9f6b-b2498b40077c', 29, CAST(N'2011-04-30' AS Date), CAST(1.586077 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6ef07c48-a04c-4993-afed-428d6e31f26a', 29, CAST(N'2011-05-31' AS Date), CAST(1.612100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cda6ac46-bd9e-45f4-86d7-39a19cb0200f', 29, CAST(N'2011-06-30' AS Date), CAST(1.588200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46a3da83-bd2b-4d2b-a599-7efc91df6b0a', 29, CAST(N'2011-07-31' AS Date), CAST(1.562048 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5763cd4c-9dab-4459-ab10-22f3d5063c6e', 29, CAST(N'2011-08-31' AS Date), CAST(1.597924 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4a808c53-d849-47d5-a9ea-ce0a23cd8162', 29, CAST(N'2011-09-30' AS Date), CAST(1.738530 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fd0625c1-0d92-40fa-aafe-8be135b76773', 29, CAST(N'2011-10-31' AS Date), CAST(1.775123 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'93d9cbe6-14e1-485c-9f53-24d0a976675c', 29, CAST(N'2011-11-30' AS Date), CAST(1.785630 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d323c6c-13ca-46e2-b4b5-1e78f7977c9b', 29, CAST(N'2011-12-31' AS Date), CAST(1.837258 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'197d625e-f67c-4f7b-b3dd-5d461c09c618', 29, CAST(N'2012-01-31' AS Date), CAST(1.795145 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'028c3a8d-80f2-424a-b3c7-9e259272e449', 29, CAST(N'2012-02-29' AS Date), CAST(1.718283 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b00fd30-b673-4dab-a9a9-c4cee8bbe614', 29, CAST(N'2012-03-31' AS Date), CAST(1.790326 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'25b5c6e1-4fab-4d48-986f-b8d58718790f', 29, CAST(N'2012-04-30' AS Date), CAST(1.847630 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b182aac-56c9-47f8-91b5-601c3502d61a', 29, CAST(N'2012-05-31' AS Date), CAST(1.976155 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ead5c66-037e-4ddf-a107-43c3c09fea74', 29, CAST(N'2012-06-30' AS Date), CAST(2.047352 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ab8c444-ccae-40a0-b6bd-0448f655c0ea', 29, CAST(N'2012-07-31' AS Date), CAST(2.027210 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'74124bc3-b1c6-436c-b71e-1ae2c6b81cf6', 29, CAST(N'2012-08-31' AS Date), CAST(2.026892 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'52bd2c45-a6dc-4f42-a473-4a5e24007238', 29, CAST(N'2012-09-30' AS Date), CAST(2.026232 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82c06802-4daa-4572-a600-cb5c03a62c70', 29, CAST(N'2012-10-31' AS Date), CAST(2.030063 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27c45aba-98cf-47b5-931a-8c920c6c2316', 29, CAST(N'2012-11-30' AS Date), CAST(2.062640 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0be03ab1-2ec7-4d29-836b-1914f8340ef6', 29, CAST(N'2012-12-31' AS Date), CAST(2.081944 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5167fdb7-9e81-4b63-bd6a-54a5c3ca4c30', 29, CAST(N'2013-01-31' AS Date), CAST(2.033737 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e6424c7e-2338-4fd6-9ec9-6516e7d833d7', 29, CAST(N'2013-02-28' AS Date), CAST(1.973943 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a014b8cd-419c-4a4e-8f82-24d4f0c25de3', 29, CAST(N'2013-03-31' AS Date), CAST(1.983997 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f81d1c3e-df2e-431b-8bfb-7eb7788d06d7', 29, CAST(N'2013-04-30' AS Date), CAST(1.999470 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aa5084f9-001b-4421-8842-11b536372905', 29, CAST(N'2013-05-31' AS Date), CAST(2.031521 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd1ab51af-9874-465c-b0e6-73079f41684b', 29, CAST(N'2013-06-30' AS Date), CAST(2.169228 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b8be90b-251b-4c77-af49-32c4c92c9934', 29, CAST(N'2013-07-31' AS Date), CAST(2.250206 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be2682a9-e0a8-40aa-b52c-cc9971a44baf', 29, CAST(N'2013-08-31' AS Date), CAST(2.339890 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'316cd4ae-99ee-4bae-bbc0-d9b32079dc94', 29, CAST(N'2013-09-30' AS Date), CAST(2.276163 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2d55a52c-1e43-4e10-a1c4-24ab75817200', 29, CAST(N'2013-10-31' AS Date), CAST(2.189458 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8bef1047-9266-4b92-a781-2070b180ca91', 29, CAST(N'2013-11-30' AS Date), CAST(2.294228 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'701079d1-cd57-4a7d-9c0c-9aa6dd684b0a', 29, CAST(N'2013-12-31' AS Date), CAST(2.346360 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'56998687-6a1b-4194-94aa-7a0606139784', 29, CAST(N'2014-01-31' AS Date), CAST(2.378124 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8c7d0ec-1a97-4185-8f67-c459d66043ee', 29, CAST(N'2014-02-28' AS Date), CAST(2.384625 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e3514f4d-d63d-4527-a7f4-f4d781bb92cd', 29, CAST(N'2014-03-31' AS Date), CAST(2.326692 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c0b1c81-2c90-419f-b88f-88627832f48b', 29, CAST(N'2014-04-30' AS Date), CAST(2.235487 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cd814b48-66e6-411f-bd5c-57f7556e007d', 29, CAST(N'2014-05-31' AS Date), CAST(2.220821 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'32b613fc-40bc-4e50-8c27-246d601e19ad', 29, CAST(N'2014-06-30' AS Date), CAST(2.234645 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5515e44c-0624-4393-9a29-c445e4c97d6c', 29, CAST(N'2014-07-31' AS Date), CAST(2.222010 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b9cabaa9-d5a7-425a-8c64-250232b8a2d9', 29, CAST(N'2014-08-31' AS Date), CAST(2.266895 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8b06d42d-2f86-49b0-a5e3-b9004afec29d', 29, CAST(N'2014-09-30' AS Date), CAST(2.330582 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'346debd3-5214-4d23-a0e1-25dc3380c1d0', 29, CAST(N'2014-10-31' AS Date), CAST(2.447598 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'71ea8d0d-249f-423c-9a4f-1aabf637b272', 29, CAST(N'2014-11-30' AS Date), CAST(2.542185 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f0eb157-3587-45b1-9a59-d079b45569ac', 29, CAST(N'2014-12-31' AS Date), CAST(2.644742 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fa0f8f6c-781c-49e7-8ece-703088bb4466', 29, CAST(N'2015-01-31' AS Date), CAST(2.631586 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f0a4733a-6272-451f-913a-3a5e46ec87f8', 29, CAST(N'2015-02-28' AS Date), CAST(2.811530 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9311c273-277c-41a9-b2b2-c01ba062157d', 29, CAST(N'2015-03-31' AS Date), CAST(3.134935 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'22446f5c-d667-42b4-ad64-9402c245c7ad', 29, CAST(N'2015-04-30' AS Date), CAST(3.048238 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'241d5fcd-b337-44d3-8592-0a207388cf39', 29, CAST(N'2015-05-31' AS Date), CAST(3.050797 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'59045f4f-6eb0-41ae-8b1e-516d015c770d', 29, CAST(N'2015-06-30' AS Date), CAST(3.118290 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6d492a99-f6d3-40ba-9ab5-31569cef3f2c', 29, CAST(N'2015-07-31' AS Date), CAST(3.211782 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'781d3ee7-c89b-4076-ae75-dfaa0b9e5e81', 29, CAST(N'2015-08-31' AS Date), CAST(3.503963 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ee1fe9c4-de99-44c8-9914-d1634f13a3cc', 29, CAST(N'2015-09-30' AS Date), CAST(3.892370 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f6a67a0-b9ec-4e8e-906e-86942d1ab54a', 29, CAST(N'2015-10-31' AS Date), CAST(3.875292 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f751d665-51cb-4dce-9729-4996386840f2', 29, CAST(N'2015-11-30' AS Date), CAST(3.789263 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c46ff1f-f085-4ccf-9135-48e229a1be1f', 29, CAST(N'2015-12-31' AS Date), CAST(3.880719 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'433a9660-a6cf-4044-991d-2cb83b2954a9', 29, CAST(N'2016-01-31' AS Date), CAST(4.040887 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4b643b00-b52b-41c0-95c5-96f3e71efc39', 29, CAST(N'2016-02-29' AS Date), CAST(3.970655 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e5ec3f13-3f50-423b-a157-759c7d654bd7', 29, CAST(N'2016-03-31' AS Date), CAST(3.704590 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a0c75d4-7ec9-44b8-8afa-aa69b82933b9', 29, CAST(N'2016-04-30' AS Date), CAST(3.558302 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1388ec32-4396-48da-b072-b6a78cfb99c5', 29, CAST(N'2016-05-31' AS Date), CAST(3.535948 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a2f3de66-1d4b-4b7c-b262-c88c3e0051f4', 29, CAST(N'2016-06-30' AS Date), CAST(3.439767 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6698691e-a510-43bf-a167-616fdd06c19c', 29, CAST(N'2016-07-31' AS Date), CAST(3.272705 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a2921da-8bf3-4294-af85-ceaedbd45530', 29, CAST(N'2016-08-31' AS Date), CAST(3.211006 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4dc7d20d-a228-4cb2-87a6-d1b0affd2477', 29, CAST(N'2016-09-30' AS Date), CAST(3.257827 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e44e925a-d3fb-4e2f-bcce-fa7ecb774d9f', 29, CAST(N'2016-10-31' AS Date), CAST(3.194647 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12094434-f84e-4c6a-a9c5-5b24bb27358f', 29, CAST(N'2016-11-30' AS Date), CAST(3.347327 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3bc375f5-2f55-4e21-9f38-95153f31871b', 29, CAST(N'2016-12-31' AS Date), CAST(3.355205 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'926aef36-d3ca-4c92-b583-abdf2603790a', 29, CAST(N'2017-01-31' AS Date), CAST(3.196808 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a362f85b-1246-456b-b5d4-9ff8d965a895', 29, CAST(N'2017-02-28' AS Date), CAST(3.107309 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3031db61-59ed-4b01-8afe-1b44163aa4ce', 29, CAST(N'2017-03-31' AS Date), CAST(3.124476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'beca45ed-9a9c-4e95-946f-963538ff5c5b', 29, CAST(N'2017-04-30' AS Date), CAST(3.142976 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'788c7af0-c089-4849-8a1e-a47a15515ce1', 29, CAST(N'2017-05-31' AS Date), CAST(3.208031 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'32681833-fb5d-4409-b615-2f1d0be4695c', 29, CAST(N'2017-06-30' AS Date), CAST(3.296323 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fa48495b-ddaf-4d95-af6c-f8ed93ca0fca', 29, CAST(N'2017-07-31' AS Date), CAST(3.205584 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13d7d221-6f79-44d1-94e7-974378ea779e', 29, CAST(N'2017-08-31' AS Date), CAST(3.147495 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'20a9ef6a-bab5-4a81-baa2-74e890eeb773', 29, CAST(N'2017-09-30' AS Date), CAST(3.129587 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'874c74a8-ca07-424c-bf7c-77da621a42b3', 29, CAST(N'2017-10-31' AS Date), CAST(3.190512 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33c88f30-9498-4365-a8d8-31d8bd962215', 29, CAST(N'2017-11-30' AS Date), CAST(3.263590 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b773ebc8-0406-4b9f-ae9f-cee08980937f', 29, CAST(N'2017-12-31' AS Date), CAST(3.298130 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65d7a343-3e38-4de1-91b2-6ecef12d486b', 29, CAST(N'2018-01-31' AS Date), CAST(3.210334 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cdf5f48b-e2fb-484a-b393-957f7fa6ae9b', 29, CAST(N'2018-02-28' AS Date), CAST(3.248798 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f2269e2b-7864-4d90-969e-11fa61273120', 29, CAST(N'2018-03-31' AS Date), CAST(3.278062 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dd92a329-b204-4ad8-8b73-c51955e3803d', 29, CAST(N'2018-04-30' AS Date), CAST(3.407112 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd55e9e0c-7d90-4ecb-a3de-b3df792fb617', 29, CAST(N'2018-05-31' AS Date), CAST(3.633231 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'77982f28-50e9-4e48-94a3-0b8284514e4d', 29, CAST(N'2018-06-30' AS Date), CAST(3.770730 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da39999a-52d7-4423-90ed-5a42451c44b9', 29, CAST(N'2018-07-31' AS Date), CAST(3.820860 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b1724540-9f6f-4e08-845c-441bba6cff4e', 29, CAST(N'2018-08-31' AS Date), CAST(3.922482 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'62bb632e-0fc5-4899-8265-8b0e2ab42522', 29, CAST(N'2018-09-30' AS Date), CAST(4.098080 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd981ab4c-9034-43be-80ad-c9f454573bf8', 29, CAST(N'2018-10-31' AS Date), CAST(3.758348 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6ecda63f-7c23-45a7-83bf-44a6a2b6c4aa', 29, CAST(N'2018-11-30' AS Date), CAST(3.777802 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'03a357a4-14d8-4e85-8937-aca48607333d', 29, CAST(N'2018-12-31' AS Date), CAST(3.887502 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3fade2d2-6ca0-4a89-981f-d6b1ea0d8f04', 29, CAST(N'2019-01-31' AS Date), CAST(3.741373 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c723a1a-4594-4c9f-a750-f2472c396ea2', 29, CAST(N'2019-02-28' AS Date), CAST(3.720420 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'543c20bd-5260-46e1-a5da-0e924b0a6e50', 29, CAST(N'2019-03-31' AS Date), CAST(3.846953 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c47d2a93-9f63-4426-a275-d7f31ab1875f', 29, CAST(N'2019-04-30' AS Date), CAST(3.900388 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5996980b-10cd-4ca1-8888-d06edf66fb2c', 29, CAST(N'2019-05-31' AS Date), CAST(3.995403 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec8bf9b8-ccba-4b54-8057-3ea46bf34c3c', 29, CAST(N'2019-06-30' AS Date), CAST(3.862780 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5668cd1d-fbaf-4725-bd46-2e49e8176d18', 29, CAST(N'2019-07-31' AS Date), CAST(3.776097 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f688fde5-abb9-439a-8212-ebde9816cbc1', 29, CAST(N'2019-08-31' AS Date), CAST(4.016270 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4cdf55d5-897a-4ca1-b490-3e051e088ba0', 29, CAST(N'2019-09-30' AS Date), CAST(4.122225 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0105988a-32ee-4c46-9245-0b60709db106', 29, CAST(N'2019-10-31' AS Date), CAST(4.083163 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6233fe2e-70eb-4bbf-83de-5c895358bc15', 29, CAST(N'2019-11-30' AS Date), CAST(4.156911 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f6245383-1992-4187-a348-1753c18310e6', 29, CAST(N'2019-12-31' AS Date), CAST(4.106967 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fd9977d8-8e5e-4564-a020-e33e94017534', 29, CAST(N'2020-01-31' AS Date), CAST(4.141968 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'882f5e0b-50a5-4e60-be4e-48ddbf6352e7', 29, CAST(N'2020-02-29' AS Date), CAST(4.344575 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7e5c4331-7782-4cba-89f9-7464e9ee405d', 37, CAST(N'1990-01-31' AS Date), CAST(1.172038 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7e180bee-7124-4355-89f7-16122cce8736', 37, CAST(N'1990-02-28' AS Date), CAST(1.196479 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3677c9ba-584a-435e-948a-7e38b952c265', 37, CAST(N'1990-03-31' AS Date), CAST(1.179986 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8d280818-7fe0-4c8d-b4b7-76841e8c8397', 37, CAST(N'1990-04-30' AS Date), CAST(1.164095 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c0ad5825-51ac-4f18-9465-61a583688157', 37, CAST(N'1990-05-31' AS Date), CAST(1.174700 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aac2db97-2641-4d18-af07-32063c776cd7', 37, CAST(N'1990-06-30' AS Date), CAST(1.173048 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'021ecdd2-c92f-4e7a-aa4b-ec2a73384a03', 37, CAST(N'1990-07-31' AS Date), CAST(1.157029 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'03a143b2-7a36-4898-917b-d992ab1b619b', 37, CAST(N'1990-08-31' AS Date), CAST(1.144809 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6819fc50-ea94-44fa-b61d-4c108b243769', 37, CAST(N'1990-09-30' AS Date), CAST(1.158337 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'041daad7-f69a-4c47-9693-3ca4d428b1da', 37, CAST(N'1990-10-31' AS Date), CAST(1.160023 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0976423d-f22b-4750-8f9f-3f882035db31', 37, CAST(N'1990-11-30' AS Date), CAST(1.163480 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd3009e8f-cf53-4e33-83b0-dfa24015b950', 37, CAST(N'1990-12-31' AS Date), CAST(1.160265 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2fcc7bac-342b-4a6b-be5f-608c2427b3d7', 37, CAST(N'1991-01-31' AS Date), CAST(1.156033 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'efe19d30-f1fb-49f4-a411-1270c95c1272', 37, CAST(N'1991-02-28' AS Date), CAST(1.154895 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'770e2a3f-263e-4b21-892f-5c13a77b7431', 37, CAST(N'1991-03-31' AS Date), CAST(1.157157 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8f29b77b-275c-4f75-bd38-dbee95fa8f25', 37, CAST(N'1991-04-30' AS Date), CAST(1.153514 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd64fdf01-80ef-4668-868d-ff7fc00d355e', 37, CAST(N'1991-05-31' AS Date), CAST(1.149855 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2af51b5d-e4ad-49ff-8c4b-11d0fb336c4c', 37, CAST(N'1991-06-30' AS Date), CAST(1.143895 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad614f91-5833-41a3-bd8b-29484037e4f5', 37, CAST(N'1991-07-31' AS Date), CAST(1.149332 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ca69c8c-c9f8-4562-9457-366cded10c3c', 37, CAST(N'1991-08-31' AS Date), CAST(1.145150 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'723fa1df-1e33-4a92-a521-54b56a092d90', 37, CAST(N'1991-09-30' AS Date), CAST(1.136955 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85d194aa-2ba6-4606-a7a0-e1fea2bcc99d', 37, CAST(N'1991-10-31' AS Date), CAST(1.127941 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8e84c1ab-8b4f-48b7-8c3f-4c1e4d3b33e9', 37, CAST(N'1991-11-30' AS Date), CAST(1.130174 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'626b443f-2ef6-497a-9683-c9318b8ad225', 37, CAST(N'1991-12-31' AS Date), CAST(1.146652 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1513b572-3011-4770-9fd2-9da5800bebf4', 37, CAST(N'1992-01-31' AS Date), CAST(1.157057 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'167cafc8-b2b8-4155-a2b0-21bbd1fbc5b1', 37, CAST(N'1992-02-29' AS Date), CAST(1.182458 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3979b549-da44-4565-a556-c50968d50d48', 37, CAST(N'1992-03-31' AS Date), CAST(1.192836 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'67bd1d84-b954-4a92-81a5-2e770f014e67', 37, CAST(N'1992-04-30' AS Date), CAST(1.187432 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f33e794-b5d0-4fb1-9912-c3af0aed8458', 37, CAST(N'1992-05-31' AS Date), CAST(1.199075 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38e89b91-a021-4f6b-9267-16963545d904', 37, CAST(N'1992-06-30' AS Date), CAST(1.196045 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08d87b33-6c11-43c0-8e21-660fa2e353ab', 37, CAST(N'1992-07-31' AS Date), CAST(1.192404 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0719333-4f61-48df-8f67-ce5373408b1e', 37, CAST(N'1992-08-31' AS Date), CAST(1.190748 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cf12f036-b775-43c0-9d1c-3ee95bc8e795', 37, CAST(N'1992-09-30' AS Date), CAST(1.222476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5d33a76-0e27-4c15-b932-f629f35818bf', 37, CAST(N'1992-10-31' AS Date), CAST(1.245305 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'806eca04-a6e8-42b3-ad47-0e987acb75e5', 37, CAST(N'1992-11-30' AS Date), CAST(1.267432 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f2ab65f2-92d0-4ff6-996b-bacc92775fc3', 37, CAST(N'1992-12-31' AS Date), CAST(1.272468 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c9b19c3e-a593-4cf1-b8df-c85930fdb005', 37, CAST(N'1993-01-31' AS Date), CAST(1.277911 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'004e7d2b-b840-479b-90fd-5a2a01e990e9', 37, CAST(N'1993-02-28' AS Date), CAST(1.260226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2894a0c-25aa-4d6c-a51c-025dbe05f04b', 37, CAST(N'1993-03-31' AS Date), CAST(1.247074 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd87dff82-52ca-4648-8db1-994a1b59ea9d', 37, CAST(N'1993-04-30' AS Date), CAST(1.262055 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'269492c2-8c15-4d4b-86ed-b1b39ccb1c95', 37, CAST(N'1993-05-31' AS Date), CAST(1.269805 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5e2ff7e2-a628-43d5-9a99-bfa8b7a5e955', 37, CAST(N'1993-06-30' AS Date), CAST(1.278923 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'05842ac1-c041-4333-b7b4-f612cc8b02cf', 37, CAST(N'1993-07-31' AS Date), CAST(1.281967 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'94e4b0b3-83be-493b-8a78-5b517a2e7823', 37, CAST(N'1993-08-31' AS Date), CAST(1.308014 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e3a152dc-66b6-4b5d-acc6-96b503e0f2b0', 37, CAST(N'1993-09-30' AS Date), CAST(1.321476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c7dfd21-f93f-4a29-bbbb-441095b818e2', 37, CAST(N'1993-10-31' AS Date), CAST(1.326290 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4a2d58c2-4285-4743-87ca-fa0585c7f6ef', 37, CAST(N'1993-11-30' AS Date), CAST(1.317435 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e5291ec1-f97b-435a-9d21-7ed4e1a32854', 37, CAST(N'1993-12-31' AS Date), CAST(1.330761 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'663355e2-0a0f-4c1b-9a95-c93c643cfe5c', 37, CAST(N'1994-01-31' AS Date), CAST(1.317250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c69279d8-3442-4853-bc47-5b353d6e6092', 37, CAST(N'1994-02-28' AS Date), CAST(1.342426 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21c3c623-2c9e-40b8-849b-98cbe6d69260', 37, CAST(N'1994-03-31' AS Date), CAST(1.364439 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'22d3e57f-0287-4c1e-a3f1-ac78a01f757f', 37, CAST(N'1994-04-30' AS Date), CAST(1.382971 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ebe96a7-74ff-451f-806e-1ec1b922e274', 37, CAST(N'1994-05-31' AS Date), CAST(1.380838 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1222c9a9-f8a8-4f1d-b73b-967af9b7d414', 37, CAST(N'1994-06-30' AS Date), CAST(1.383632 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8d618bd9-2a66-4458-aabd-7be2bc8ee024', 37, CAST(N'1994-07-31' AS Date), CAST(1.382575 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e2a3168d-0408-439f-b045-55c2b3ab519f', 37, CAST(N'1994-08-31' AS Date), CAST(1.378317 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1235f1aa-dbcf-41fb-b057-437059fcb656', 37, CAST(N'1994-09-30' AS Date), CAST(1.354014 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c44012e3-1ef5-4f24-b00e-4d457aa0bbfc', 37, CAST(N'1994-10-31' AS Date), CAST(1.350270 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da3ee0db-6b4d-4586-9c6a-439a2bdbd96c', 37, CAST(N'1994-11-30' AS Date), CAST(1.364665 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'799e3de0-d388-4f52-87e3-2d7f460ec4f4', 37, CAST(N'1994-12-31' AS Date), CAST(1.389252 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'02f21708-f65c-4304-b94d-0ce7b6cf3f3b', 37, CAST(N'1995-01-31' AS Date), CAST(1.413225 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6846ab7e-22fa-4c50-926c-626327bb6a11', 37, CAST(N'1995-02-28' AS Date), CAST(1.400489 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8b3e1a2b-2fcf-4057-a1b3-21300e5170e8', 37, CAST(N'1995-03-31' AS Date), CAST(1.407696 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e9a9ecda-d753-4000-a394-7b0fc76e3195', 37, CAST(N'1995-04-30' AS Date), CAST(1.376200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dd33607d-73c2-4a16-ae21-d047a98cf7a5', 37, CAST(N'1995-05-31' AS Date), CAST(1.360873 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5844663c-d949-4f63-a3ca-9daa0944d03e', 37, CAST(N'1995-06-30' AS Date), CAST(1.377509 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'87960ee4-c440-4a5b-bfdb-76865e4065bc', 37, CAST(N'1995-07-31' AS Date), CAST(1.361170 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'55395503-fadf-4b61-8a20-a49d3e201594', 37, CAST(N'1995-08-31' AS Date), CAST(1.355217 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4c494364-25d3-4ffe-a980-5a597d68bf35', 37, CAST(N'1995-09-30' AS Date), CAST(1.350935 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7232bd67-4ea4-47f8-9dd2-0780f52c8cc0', 37, CAST(N'1995-10-31' AS Date), CAST(1.345819 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'607c99ee-90a3-4812-b9bf-e0f815ae4b3b', 37, CAST(N'1995-11-30' AS Date), CAST(1.353371 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2826ae2b-10a4-4bef-98af-5428caa74e61', 37, CAST(N'1995-12-31' AS Date), CAST(1.369300 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e3d4341-e649-46ec-9caf-6c4d1937d169', 37, CAST(N'1996-01-31' AS Date), CAST(1.366867 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7bcdff3d-d352-469e-96c5-6e78d9b4b6b8', 37, CAST(N'1996-02-29' AS Date), CAST(1.375220 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4da866a4-a5f1-4d61-848b-18a56c77a691', 37, CAST(N'1996-03-31' AS Date), CAST(1.365600 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c945e5f-77cc-4d5a-a95e-93a86706ce75', 37, CAST(N'1996-04-30' AS Date), CAST(1.359186 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f0e99dfe-9397-4d7f-bedc-12935598551f', 37, CAST(N'1996-05-31' AS Date), CAST(1.369250 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bb6cda57-b80c-4781-bb6c-ed7875f9275d', 37, CAST(N'1996-06-30' AS Date), CAST(1.365800 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'473d146a-5dcf-4dcb-b75e-80a0a1c0c7c7', 37, CAST(N'1996-07-31' AS Date), CAST(1.369732 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bdab5ce9-b659-4e6c-be93-ab3a5bf20a14', 37, CAST(N'1996-08-31' AS Date), CAST(1.372241 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fcbc879e-8c78-49c8-b072-aa4e59c71109', 37, CAST(N'1996-09-30' AS Date), CAST(1.369385 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a913a964-1a4f-42df-a423-4f6c8916d41b', 37, CAST(N'1996-10-31' AS Date), CAST(1.350836 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dfe9de5a-cc29-4caf-a6bd-3b0a9d0d260a', 37, CAST(N'1996-11-30' AS Date), CAST(1.338058 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'51f52b3b-9532-41ee-9b22-8fbc0f786b26', 37, CAST(N'1996-12-31' AS Date), CAST(1.362157 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af0ac1ba-20b1-42c0-8eb0-ea8c101e9ee7', 37, CAST(N'1997-01-31' AS Date), CAST(1.349438 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5c8a1bde-15f9-49f1-80e0-e99aff0ead51', 37, CAST(N'1997-02-28' AS Date), CAST(1.355584 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9e1ed06d-4fd2-46ec-9a1a-6e3c87ee32ef', 37, CAST(N'1997-03-31' AS Date), CAST(1.372476 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0bce938c-6c41-4a53-b81e-5ca3c98d3710', 37, CAST(N'1997-04-30' AS Date), CAST(1.394159 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82aea7ff-ac10-4899-9af4-3a6535fb96e0', 37, CAST(N'1997-05-31' AS Date), CAST(1.380400 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2a0ad725-4b95-4481-b9b0-521aff5b189b', 37, CAST(N'1997-06-30' AS Date), CAST(1.384271 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'31ff3554-1f15-423d-a7cf-6661f5f99e77', 37, CAST(N'1997-07-31' AS Date), CAST(1.377532 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d64f57f-98d4-404f-8d26-f9dde174be63', 37, CAST(N'1997-08-31' AS Date), CAST(1.390533 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1844eb18-242f-4b5d-a61b-ae7f08b65e46', 37, CAST(N'1997-09-30' AS Date), CAST(1.387162 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b7e24b91-b625-41ce-88d2-420094666c05', 37, CAST(N'1997-10-31' AS Date), CAST(1.386905 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'28375316-5a6e-4265-a95d-2b1b8f9872e3', 37, CAST(N'1997-11-30' AS Date), CAST(1.412822 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2039e1a4-91f2-42dc-9ac7-610d6ac566b3', 37, CAST(N'1997-12-31' AS Date), CAST(1.427091 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21f10485-d757-435f-b8c9-710e6b29dff0', 37, CAST(N'1998-01-31' AS Date), CAST(1.440945 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cf681357-4a21-4e69-b21f-b1df521274fc', 37, CAST(N'1998-02-28' AS Date), CAST(1.433411 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8380e6e-5034-4690-9d89-d828e6570a67', 37, CAST(N'1998-03-31' AS Date), CAST(1.416577 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'05e87739-bfa7-4c14-a0b8-ee5259f5a165', 37, CAST(N'1998-04-30' AS Date), CAST(1.429773 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4f30205e-8841-4f04-a3c5-195e916d1a73', 37, CAST(N'1998-05-31' AS Date), CAST(1.445220 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'adb6dd9f-04fc-41ff-9820-0b2b45e0bbed', 37, CAST(N'1998-06-30' AS Date), CAST(1.465509 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c3731b1-2198-4dbb-b8d7-1f6e3f7cca9d', 37, CAST(N'1998-07-31' AS Date), CAST(1.486896 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2c3f89cc-7a92-4193-803b-c853a4121790', 37, CAST(N'1998-08-31' AS Date), CAST(1.534638 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad5ae2f3-74dd-4339-847d-74d0eb0436f2', 37, CAST(N'1998-09-30' AS Date), CAST(1.521762 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'efd70351-ac11-4588-83b1-89d86b0c5789', 37, CAST(N'1998-10-31' AS Date), CAST(1.545176 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f996a7dd-d9d3-426b-95e8-f3fcc9292519', 37, CAST(N'1998-11-30' AS Date), CAST(1.540395 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8f1caf7c-6bb6-4fb4-ac70-e14a28d3f319', 37, CAST(N'1998-12-31' AS Date), CAST(1.543273 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'78c3e49d-7ecc-4bec-9798-0d1429bd51cd', 37, CAST(N'1999-01-31' AS Date), CAST(1.519191 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca661bff-1b5d-43c9-bc60-00b0cfdbf69b', 37, CAST(N'1999-02-28' AS Date), CAST(1.497080 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7128edef-1624-4cb3-9eee-b36f78e35bbe', 37, CAST(N'1999-03-31' AS Date), CAST(1.517513 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'efec85fb-8964-4592-900b-1f4721b26296', 37, CAST(N'1999-04-30' AS Date), CAST(1.487397 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'06e366b6-844f-46cc-bab1-7e8a417168a8', 37, CAST(N'1999-05-31' AS Date), CAST(1.461884 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'99295b83-6aa6-4db7-9357-4fe744b222df', 37, CAST(N'1999-06-30' AS Date), CAST(1.468989 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1784ff86-8204-4eb0-8551-1ccc98d43e68', 37, CAST(N'1999-07-31' AS Date), CAST(1.488504 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce3b2cef-1f63-4e45-8edc-636042e8078b', 37, CAST(N'1999-08-31' AS Date), CAST(1.492425 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'67373680-d414-4dc8-bd32-afed96f4f269', 37, CAST(N'1999-09-30' AS Date), CAST(1.476844 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'291327f6-814e-4ac8-af71-0d5db550fe34', 37, CAST(N'1999-10-31' AS Date), CAST(1.477495 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f590a681-51b6-4c9c-bbd5-88424ddacae3', 37, CAST(N'1999-11-30' AS Date), CAST(1.467613 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4edb0bd-57ff-426d-b861-316b7bcdb175', 37, CAST(N'1999-12-31' AS Date), CAST(1.473148 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df71178f-a3cf-4a2d-975f-a7bf5002455b', 37, CAST(N'2000-01-31' AS Date), CAST(1.449103 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cf41d23c-3821-4257-9a29-f92289dc46d3', 37, CAST(N'2000-02-29' AS Date), CAST(1.451445 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'720d78b9-c308-48ae-bea8-7a049dfb328b', 37, CAST(N'2000-03-31' AS Date), CAST(1.459971 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2fccc9f9-fa0d-4cf5-ae57-11467e9e80c2', 37, CAST(N'2000-04-30' AS Date), CAST(1.467191 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'60dfc5fe-27e8-4832-bb07-250b58961d2c', 37, CAST(N'2000-05-31' AS Date), CAST(1.493630 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'87df2d1d-cbeb-4900-b503-cd9d2981573b', 37, CAST(N'2000-06-30' AS Date), CAST(1.477324 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f140b0f5-8314-4780-89ee-abd3b0e7a7c7', 37, CAST(N'2000-07-31' AS Date), CAST(1.477323 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c0a74ffb-35d6-444c-bc0b-1ddae6aab45b', 37, CAST(N'2000-08-31' AS Date), CAST(1.482096 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'56d2b19f-6bea-4c04-8c17-f9df0fd6278e', 37, CAST(N'2000-09-30' AS Date), CAST(1.483830 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf3678c8-fa1e-4a4b-b07d-b0d6eede6066', 37, CAST(N'2000-10-31' AS Date), CAST(1.511148 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f2851fa-2090-4051-87a5-84b06ca411ac', 37, CAST(N'2000-11-30' AS Date), CAST(1.542419 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'209f76ba-464a-4da7-87b8-75fe467f4858', 37, CAST(N'2000-12-31' AS Date), CAST(1.523644 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27d4cdc7-9a70-449b-b010-9b7e92a7643f', 37, CAST(N'2001-01-31' AS Date), CAST(1.502790 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ba7104af-fdef-4425-b3d3-5bd0feca48de', 37, CAST(N'2001-02-28' AS Date), CAST(1.521525 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e54544e-3e21-4f89-880f-45809e8dbd58', 37, CAST(N'2001-03-31' AS Date), CAST(1.557447 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e7ac66bb-72e0-44bb-b2cc-593e6a30d267', 37, CAST(N'2001-04-30' AS Date), CAST(1.560287 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00d42b63-8582-4321-b7b4-a875f97b56ff', 37, CAST(N'2001-05-31' AS Date), CAST(1.541061 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f86dd67-e18a-4e6f-ad05-8a7f28d03210', 37, CAST(N'2001-06-30' AS Date), CAST(1.525522 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'272748c0-2ba0-4f26-8484-81080a44c291', 37, CAST(N'2001-07-31' AS Date), CAST(1.528286 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc58808d-1ef3-47b0-992b-5b53ee24210e', 37, CAST(N'2001-08-31' AS Date), CAST(1.538168 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'779fe74f-d8c3-47b0-80b9-b2bf970ab158', 37, CAST(N'2001-09-30' AS Date), CAST(1.565570 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8a1605bd-515c-4624-af75-187a2686b5a9', 37, CAST(N'2001-10-31' AS Date), CAST(1.570326 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1acbf735-c1df-46c4-8e38-801aff612598', 37, CAST(N'2001-11-30' AS Date), CAST(1.593486 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a4570e22-8e16-4363-9b07-df4bf353e37d', 37, CAST(N'2001-12-31' AS Date), CAST(1.577945 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'51224688-a62b-4365-b3f7-81df348cb412', 37, CAST(N'2002-01-31' AS Date), CAST(1.599830 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'babacab6-fb15-4106-b835-6800e81a0d51', 37, CAST(N'2002-02-28' AS Date), CAST(1.595465 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9afbc4f6-a780-4a2d-a66b-532623f789e0', 37, CAST(N'2002-03-31' AS Date), CAST(1.587240 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f38115fc-54a1-4856-ab69-53b95f7d1a5c', 37, CAST(N'2002-04-30' AS Date), CAST(1.582559 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b37870c5-4021-4cc6-b57d-ea257e87b8fc', 37, CAST(N'2002-05-31' AS Date), CAST(1.550626 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c6dbfb1-56a7-440d-a807-fa95d042e70d', 37, CAST(N'2002-06-30' AS Date), CAST(1.531700 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'156fd943-21ac-4de7-a26a-4617f1f47d1a', 37, CAST(N'2002-07-31' AS Date), CAST(1.541560 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce6ab56d-3e69-4078-b9f0-fe78aa1e83a4', 37, CAST(N'2002-08-31' AS Date), CAST(1.569850 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be1ea445-20e9-42d8-b395-087d67078eaf', 37, CAST(N'2002-09-30' AS Date), CAST(1.573600 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f2b64fe-db9e-42e4-bed9-0fe9f919be06', 37, CAST(N'2002-10-31' AS Date), CAST(1.579109 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f5697df7-0dda-4e14-83c1-f2a211c0eab9', 37, CAST(N'2002-11-30' AS Date), CAST(1.572621 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c59d5ea-9690-40e3-99cd-79b036990f0e', 37, CAST(N'2002-12-31' AS Date), CAST(1.560173 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce16e04c-1713-4f89-a4f6-32c1fcf10a4e', 37, CAST(N'2003-01-31' AS Date), CAST(1.542472 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'952f0d17-a5b1-4186-b280-06981e4afde6', 37, CAST(N'2003-02-28' AS Date), CAST(1.513742 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'298cac69-fa50-4b0e-8405-a977cf8d2be2', 37, CAST(N'2003-03-31' AS Date), CAST(1.477290 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d99e87d-ae3f-4e59-87a3-26de58997cbd', 37, CAST(N'2003-04-30' AS Date), CAST(1.457387 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec266556-923f-48cb-9eb6-7902c1928033', 37, CAST(N'2003-05-31' AS Date), CAST(1.387271 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef08e093-872b-447a-b6ea-0601e1c901fc', 37, CAST(N'2003-06-30' AS Date), CAST(1.351337 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef95e15d-e019-4807-8570-63928d6c320d', 37, CAST(N'2003-07-31' AS Date), CAST(1.376510 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c292f12e-7201-4c51-8326-5ff46b23f1c4', 37, CAST(N'2003-08-31' AS Date), CAST(1.397239 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c05193f1-721f-474f-84b5-9c1df26cee86', 37, CAST(N'2003-09-30' AS Date), CAST(1.366563 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d86a035-5369-4211-a64f-b445b45de1df', 37, CAST(N'2003-10-31' AS Date), CAST(1.323752 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4f4ad92f-a963-4222-aacc-6978ea78929d', 37, CAST(N'2003-11-30' AS Date), CAST(1.312813 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'034d1db4-4cdc-4f43-bdde-c0fd293dd071', 37, CAST(N'2003-12-31' AS Date), CAST(1.316735 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ce3f6209-a402-4bd1-b3b1-2d74e7146fe8', 37, CAST(N'2004-01-31' AS Date), CAST(1.296524 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'90fddb12-eb94-4eb6-8682-ac669e6ef2a7', 37, CAST(N'2004-02-29' AS Date), CAST(1.329614 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61b88d6b-dc10-4861-b1cb-4f2574696495', 37, CAST(N'2004-03-31' AS Date), CAST(1.329095 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8d407337-dbbd-4af8-a728-a1afd5ad3361', 37, CAST(N'2004-04-30' AS Date), CAST(1.333645 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb0b6786-a660-4fbc-bdef-6d935647fb5d', 37, CAST(N'2004-05-31' AS Date), CAST(1.376816 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd27eaf7f-d3d5-4f2b-b579-d2a245a9a7d9', 37, CAST(N'2004-06-30' AS Date), CAST(1.359575 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f4bef86b-49c8-4202-a2d7-6ba3b3784b18', 37, CAST(N'2004-07-31' AS Date), CAST(1.322492 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b2f92ac6-c9de-4929-9f3d-3818657cc4e0', 37, CAST(N'2004-08-31' AS Date), CAST(1.314455 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7e14824a-711e-481f-8b79-953568cbd978', 37, CAST(N'2004-09-30' AS Date), CAST(1.285831 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f552f73c-705d-4a98-a5c7-3da18fde9447', 37, CAST(N'2004-10-31' AS Date), CAST(1.249756 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a2599804-e193-4ad5-98c7-f141c390e2a4', 37, CAST(N'2004-11-30' AS Date), CAST(1.197132 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0fcfac5e-8f3a-4902-9e29-5ca8e376fe23', 37, CAST(N'2004-12-31' AS Date), CAST(1.214828 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0aef56a5-c9e9-46f8-a780-198ca90772ff', 37, CAST(N'2005-01-31' AS Date), CAST(1.212269 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'095ab08c-5f74-4541-944d-754e9524e3e5', 37, CAST(N'2005-02-28' AS Date), CAST(1.240262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17399927-426a-485f-9d51-7db2c95b4f5a', 37, CAST(N'2005-03-31' AS Date), CAST(1.217142 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f2dd493e-1007-4905-a6b9-b19c0a262314', 37, CAST(N'2005-04-30' AS Date), CAST(1.233393 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dde9e18c-a2d3-422d-b7e4-eaa92a9cdb6b', 37, CAST(N'2005-05-31' AS Date), CAST(1.256516 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'802e8591-89b2-4660-972a-6b4129920751', 37, CAST(N'2005-06-30' AS Date), CAST(1.241442 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dbf51573-10f3-490d-9fa1-b3e802856a99', 37, CAST(N'2005-07-31' AS Date), CAST(1.223678 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df92b85d-2ce2-4b96-8043-b7597b94a47c', 37, CAST(N'2005-08-31' AS Date), CAST(1.206167 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'89b8d4bc-c330-48c9-9832-42db383961d1', 37, CAST(N'2005-09-30' AS Date), CAST(1.179692 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e6cfe89c-a5f4-4fe2-9e88-8d8e6c374017', 37, CAST(N'2005-10-31' AS Date), CAST(1.176994 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd6425f0a-8bf8-40c1-9050-60a3d83e40c4', 37, CAST(N'2005-11-30' AS Date), CAST(1.182113 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2846dccd-7747-4e63-b431-418a9d0a53d0', 37, CAST(N'2005-12-31' AS Date), CAST(1.161478 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9409f664-52ae-4afe-870b-a242547d23fe', 37, CAST(N'2006-01-31' AS Date), CAST(1.158395 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af0910f3-2af4-421b-b613-1f483529efb0', 37, CAST(N'2006-02-28' AS Date), CAST(1.149512 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dc4bf8ed-5a9b-4962-b99b-04c3ed9716d9', 37, CAST(N'2006-03-31' AS Date), CAST(1.155641 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'820d3b38-0cc9-4bc2-8f03-9ce2ca426a8f', 37, CAST(N'2006-04-30' AS Date), CAST(1.145552 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'73771b3d-9023-4f8e-a6db-f815c29bc371', 37, CAST(N'2006-05-31' AS Date), CAST(1.110111 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30173560-6b69-4fd2-8e67-62bc94b12655', 37, CAST(N'2006-06-30' AS Date), CAST(1.115585 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c69bab41-ac8a-494d-874b-14b158aecce1', 37, CAST(N'2006-07-31' AS Date), CAST(1.126819 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'38b9bb69-68fc-4442-a3b6-62f78e19f930', 37, CAST(N'2006-08-31' AS Date), CAST(1.120851 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'84ab5412-2714-426f-a4d9-1d1b9068f967', 37, CAST(N'2006-09-30' AS Date), CAST(1.115647 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'16d71f12-d0d8-48c7-a525-2af2f9c488e7', 37, CAST(N'2006-10-31' AS Date), CAST(1.127132 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e886094c-64bd-4ebc-8d70-072e66e1964e', 37, CAST(N'2006-11-30' AS Date), CAST(1.135290 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'da48dca5-210c-42bd-817e-f9ed52124c2f', 37, CAST(N'2006-12-31' AS Date), CAST(1.152790 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a990be2e-d873-4c6b-9ef6-d360ab83e7d4', 37, CAST(N'2007-01-31' AS Date), CAST(1.174581 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a763b722-85a5-4798-ac2c-a8ed2ea48dd3', 37, CAST(N'2007-02-28' AS Date), CAST(1.171395 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'61212d22-3f08-4c3b-b3f2-f2e7d8f61f9c', 37, CAST(N'2007-03-31' AS Date), CAST(1.169610 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c95b077-fa35-4f5e-a95f-43c83c4aa5fa', 37, CAST(N'2007-04-30' AS Date), CAST(1.137809 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46ed3f56-4d17-4961-93da-989a5938c235', 37, CAST(N'2007-05-31' AS Date), CAST(1.097463 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff9645c0-106e-4ed4-9f9f-7e2e8ffd4cd8', 37, CAST(N'2007-06-30' AS Date), CAST(1.065762 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'25e6a764-ed31-4afe-9e5c-1ca1c5041deb', 37, CAST(N'2007-07-31' AS Date), CAST(1.050608 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'73f0a45c-9cd4-41c1-b84d-723f473adad8', 37, CAST(N'2007-08-31' AS Date), CAST(1.059001 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4115fbb9-2616-484b-83ea-f452c838136d', 37, CAST(N'2007-09-30' AS Date), CAST(1.029265 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd079a5c1-79cd-40d1-9945-82e5bd2576a7', 37, CAST(N'2007-10-31' AS Date), CAST(0.977884 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'221f9008-b356-4d5f-bdec-0c92ca638334', 37, CAST(N'2007-11-30' AS Date), CAST(0.963178 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0e92c477-d1b7-4fac-8cdf-3d9829c7d2bf', 37, CAST(N'2007-12-31' AS Date), CAST(1.002198 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eb4558c1-eead-46fb-b0f7-5277f2b0e73a', 37, CAST(N'2008-01-31' AS Date), CAST(1.010260 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0e25eefb-70b6-4801-a674-4ba45dbfe695', 37, CAST(N'2008-02-29' AS Date), CAST(1.002507 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ba6a649a-b3e5-4ab8-8df0-61da97be8443', 37, CAST(N'2008-03-31' AS Date), CAST(0.999266 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'58e8a900-af62-4bca-a934-d5566ace6d34', 37, CAST(N'2008-04-30' AS Date), CAST(1.014231 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'73e7d096-2ab5-4421-a9aa-35c3c1e5a96b', 37, CAST(N'2008-05-31' AS Date), CAST(1.001610 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd93ce3d1-54c5-4f20-9720-2e177e5d3e31', 37, CAST(N'2008-06-30' AS Date), CAST(1.015182 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef42541f-9d5c-4ad5-aba4-4d423c0a53e2', 37, CAST(N'2008-07-31' AS Date), CAST(1.012794 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fa5602b4-116a-490f-ad85-dd8c85624e5e', 37, CAST(N'2008-08-31' AS Date), CAST(1.050551 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6759458f-0dc2-40c5-8b21-dfc03748a61b', 37, CAST(N'2008-09-30' AS Date), CAST(1.059300 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1f79e626-599d-4b9a-ba17-16ab1b21f14d', 37, CAST(N'2008-10-31' AS Date), CAST(1.169414 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4f864c6b-682a-432a-8886-884661133c42', 37, CAST(N'2008-11-30' AS Date), CAST(1.219287 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'252d082d-a53b-4dd0-a763-88652ad38b94', 37, CAST(N'2008-12-31' AS Date), CAST(1.232423 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b9581bc4-bd06-4a33-b094-af2f6404e623', 37, CAST(N'2009-01-31' AS Date), CAST(1.226128 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3d72f107-97cd-47ef-892f-832461a49ca6', 37, CAST(N'2009-02-28' AS Date), CAST(1.241680 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91bd2eb0-773a-4b4a-b032-da247abad8e9', 37, CAST(N'2009-03-31' AS Date), CAST(1.263078 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9110fbb5-07e9-41a2-ab4d-507450e533af', 37, CAST(N'2009-04-30' AS Date), CAST(1.226930 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'098513bc-2f21-4f60-8a70-c84f3dfdf01c', 37, CAST(N'2009-05-31' AS Date), CAST(1.153850 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'47c0cb77-78db-45d5-9d7b-fb9b9468c7f1', 37, CAST(N'2009-06-30' AS Date), CAST(1.122953 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5838053-dfe7-466e-b254-d73a7493065f', 37, CAST(N'2009-07-31' AS Date), CAST(1.127676 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27f37cc8-2592-422e-8b0e-07b5812c25bb', 37, CAST(N'2009-08-31' AS Date), CAST(1.087500 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9461f3e7-a576-422d-baf7-a03e2a3073a4', 37, CAST(N'2009-09-30' AS Date), CAST(1.082688 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2290896a-4414-464e-b40c-538c057d41dd', 37, CAST(N'2009-10-31' AS Date), CAST(1.054311 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5ff0eda7-7920-4c44-89c9-1e647fd6cc9d', 37, CAST(N'2009-11-30' AS Date), CAST(1.062397 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'10204dc4-6521-41ec-8d92-57b2b3cae2ef', 37, CAST(N'2009-12-31' AS Date), CAST(1.055430 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf7aa0c0-c791-4258-a5a4-cf40887e2d89', 37, CAST(N'2010-01-31' AS Date), CAST(1.044317 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'86b75f87-8f9e-4c85-9428-8d7cdb2b4f0c', 37, CAST(N'2010-02-28' AS Date), CAST(1.056517 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0e99ece-25d4-4bfd-826d-b30d7087d181', 37, CAST(N'2010-03-31' AS Date), CAST(1.024045 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81a1822d-acd0-4a90-a597-6bd6aa58c8b7', 37, CAST(N'2010-04-30' AS Date), CAST(1.005573 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a96ef61f-b48e-47e7-ab8a-5f1a9864db42', 37, CAST(N'2010-05-31' AS Date), CAST(1.040187 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0b3dadff-b114-42b1-9455-8f9f55206cc4', 37, CAST(N'2010-06-30' AS Date), CAST(1.038043 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6f769f89-fb6e-490b-9acc-1fb81d3d4f1a', 37, CAST(N'2010-07-31' AS Date), CAST(1.045316 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c6ca4277-90e2-49c1-8038-1a44373d342a', 37, CAST(N'2010-08-31' AS Date), CAST(1.039928 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'687b20d5-7181-44f0-8bad-d4b0a627242f', 37, CAST(N'2010-09-30' AS Date), CAST(1.034654 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'295f30ae-bf73-4046-8ece-533fe38f36e2', 37, CAST(N'2010-10-31' AS Date), CAST(1.018262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'760b583b-4e69-44ef-b308-02d0e0679e46', 37, CAST(N'2010-11-30' AS Date), CAST(1.012469 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a8a606b6-a55c-4152-9d21-01dec1554c93', 37, CAST(N'2010-12-31' AS Date), CAST(1.008591 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'279c88b2-93fc-4c83-978e-0586761d69b4', 37, CAST(N'2011-01-31' AS Date), CAST(0.994014 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b9f0794-8438-425b-a357-5e67feac22e4', 37, CAST(N'2011-02-28' AS Date), CAST(0.988058 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b150488e-3d48-4148-94dc-e684744f774c', 37, CAST(N'2011-03-31' AS Date), CAST(0.976999 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ed714aa7-86f2-4ebb-9ea6-8026d50270e7', 37, CAST(N'2011-04-30' AS Date), CAST(0.958619 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'19076f93-aecf-4c3e-8c32-b963d22b51ee', 37, CAST(N'2011-05-31' AS Date), CAST(0.967739 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd674206b-2b75-4155-981b-eee7320f803d', 37, CAST(N'2011-06-30' AS Date), CAST(0.978707 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c0461909-1942-4556-ac74-5ae442c66481', 37, CAST(N'2011-07-31' AS Date), CAST(0.955871 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'54b4e513-f1db-4487-bcb5-c51d5a38ef9c', 37, CAST(N'2011-08-31' AS Date), CAST(0.982234 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'de06ae2d-b695-49ee-8668-03c8480d3846', 37, CAST(N'2011-09-30' AS Date), CAST(0.999486 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca6c48fd-f595-4f90-b28d-a6d8ba6adf15', 37, CAST(N'2011-10-31' AS Date), CAST(1.023479 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'42fb44b7-9bce-4644-8a35-76e86ce2e25d', 37, CAST(N'2011-11-30' AS Date), CAST(1.024830 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9fa18516-b3ee-4540-9013-fc9a65b5fc9e', 37, CAST(N'2011-12-31' AS Date), CAST(1.023589 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13a587f5-63bd-4181-a718-875a6dc5f24c', 37, CAST(N'2012-01-31' AS Date), CAST(1.016364 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a7b8ec5-6f6c-444c-aef4-6f0561501bc4', 37, CAST(N'2012-02-29' AS Date), CAST(0.997757 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2cb45223-735b-4ecc-b06d-b17829eb1362', 37, CAST(N'2012-03-31' AS Date), CAST(0.993162 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2f0945d5-10b3-4f8b-a7a8-a1e21188579c', 37, CAST(N'2012-04-30' AS Date), CAST(0.994276 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0870600e-17f1-4b53-b6f0-fdb496ad78b3', 37, CAST(N'2012-05-31' AS Date), CAST(1.009397 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c9a31b7-b336-4102-9408-fb57f1c090dd', 37, CAST(N'2012-06-30' AS Date), CAST(1.027839 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'35922b81-a4eb-4166-b8a3-49b528ae592a', 37, CAST(N'2012-07-31' AS Date), CAST(1.014016 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2b4599f3-cb38-4a29-a634-4a67d7df4337', 37, CAST(N'2012-08-31' AS Date), CAST(0.993440 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a0c1adcd-3514-4d26-949a-e60cf5e1dc59', 37, CAST(N'2012-09-30' AS Date), CAST(0.979022 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'32e4ad46-034d-474b-99a9-bbd3440ad3e7', 37, CAST(N'2012-10-31' AS Date), CAST(0.986016 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'084203e9-6d44-41ab-b26a-eeb8684eb7d5', 37, CAST(N'2012-11-30' AS Date), CAST(0.997657 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7cb71afa-1b77-4c9b-a35b-ef4b85328b05', 37, CAST(N'2012-12-31' AS Date), CAST(0.990504 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'988070fd-566e-43ec-9030-885c89e83d8f', 37, CAST(N'2013-01-31' AS Date), CAST(0.992235 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'57d6cba9-7b8b-4a83-bfa6-e141546f9f53', 37, CAST(N'2013-02-28' AS Date), CAST(1.008024 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2e8352d0-ae35-465b-a2b5-ab9cd003f19b', 37, CAST(N'2013-03-31' AS Date), CAST(1.024300 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b4998d7-f31f-4ddc-bf0c-0ebd1482d3aa', 37, CAST(N'2013-04-30' AS Date), CAST(1.018646 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a4bc9c05-ec9b-470b-9bdf-84961953e4bf', 37, CAST(N'2013-05-31' AS Date), CAST(1.019315 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'237bc897-bb0f-4acf-9ad8-ae4a1363bd96', 37, CAST(N'2013-06-30' AS Date), CAST(1.031804 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'366f08da-b4ef-4ce1-bc15-738a324e7028', 37, CAST(N'2013-07-31' AS Date), CAST(1.041515 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b93c788f-c5e6-4640-abe6-7f1645241b51', 37, CAST(N'2013-08-31' AS Date), CAST(1.039314 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2567608-fd64-4c12-bf01-022141593334', 37, CAST(N'2013-09-30' AS Date), CAST(1.036557 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ffeb69ec-7c3c-432f-a96b-80c1796a7c38', 37, CAST(N'2013-10-31' AS Date), CAST(1.035523 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'43585a9b-6c71-4755-8d2b-52c971874db7', 37, CAST(N'2013-11-30' AS Date), CAST(1.048196 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'930cb2a2-bb18-4754-b84c-a26abce5f73d', 37, CAST(N'2013-12-31' AS Date), CAST(1.063922 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff8a6dc7-f678-4180-966f-66b2a5d03818', 37, CAST(N'2014-01-31' AS Date), CAST(1.090421 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ccecab4f-7c78-4fb1-affb-555d79c723c2', 37, CAST(N'2014-02-28' AS Date), CAST(1.105618 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'05376f83-5113-4924-9745-bb110f37c66f', 37, CAST(N'2014-03-31' AS Date), CAST(1.110703 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'547c4cce-ddb0-4bb5-ab77-9f701b0a320a', 37, CAST(N'2014-04-30' AS Date), CAST(1.099749 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'26b174c7-a9c1-46e3-aa30-9c8a924ce478', 37, CAST(N'2014-05-31' AS Date), CAST(1.089521 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12f662cd-a9ec-4585-b9d5-783b2f539b3d', 37, CAST(N'2014-06-30' AS Date), CAST(1.082865 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7276f964-46f7-465c-8df2-165b836cfb39', 37, CAST(N'2014-07-31' AS Date), CAST(1.072690 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6fcda284-c3a8-4815-8a96-ec7b393b899d', 37, CAST(N'2014-08-31' AS Date), CAST(1.092226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9402396-ff42-40f4-a87d-631787d6514f', 37, CAST(N'2014-09-30' AS Date), CAST(1.099751 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'146b1f0b-48c8-4153-850b-c0f35cebacea', 37, CAST(N'2014-10-31' AS Date), CAST(1.122052 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fc376790-2dbe-4833-abd6-72414262c938', 37, CAST(N'2014-11-30' AS Date), CAST(1.131759 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2f65cd7-fd31-457d-9b06-62b444a2af6c', 37, CAST(N'2014-12-31' AS Date), CAST(1.154144 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be11796a-8efc-4178-8a95-35a37c1304ca', 37, CAST(N'2015-01-31' AS Date), CAST(1.209900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c8f00588-a289-4c5e-94ee-aac4a08c4546', 37, CAST(N'2015-02-28' AS Date), CAST(1.251616 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c80293de-5f62-4c64-b89b-925612707c34', 37, CAST(N'2015-03-31' AS Date), CAST(1.261494 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'49aa64e6-ff5a-4462-9ae3-515de50d7490', 37, CAST(N'2015-04-30' AS Date), CAST(1.236370 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e6b3691d-f2d8-4dc1-8290-a25aeb0d0a41', 37, CAST(N'2015-05-31' AS Date), CAST(1.217718 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bc176a05-0cca-46fe-8666-315795a00fb0', 37, CAST(N'2015-06-30' AS Date), CAST(1.235682 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a88349f-ae56-424b-83ad-512dc57f561b', 37, CAST(N'2015-07-31' AS Date), CAST(1.282527 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'085c4a53-3ce3-409c-8518-04f1cdb96d30', 37, CAST(N'2015-08-31' AS Date), CAST(1.314185 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6328eeec-710d-48a8-bfec-208366713b73', 37, CAST(N'2015-09-30' AS Date), CAST(1.326162 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fdcb5176-a797-48c9-b9a5-889d28edf144', 37, CAST(N'2015-10-31' AS Date), CAST(1.307006 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ab41d25-154a-4842-a1e5-852d776904b2', 37, CAST(N'2015-11-30' AS Date), CAST(1.328105 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c6cbd577-656b-40bc-bc6c-f1d28002bcce', 37, CAST(N'2015-12-31' AS Date), CAST(1.370132 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f49563cf-d965-42f4-a930-f5b2fa401ad8', 37, CAST(N'2016-01-31' AS Date), CAST(1.417969 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'54d8e54c-dda1-40e6-95c0-6dfad3c16411', 37, CAST(N'2016-02-29' AS Date), CAST(1.380447 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5708296c-7e94-4f41-b7f9-300ac97c9a88', 37, CAST(N'2016-03-31' AS Date), CAST(1.323890 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6ca7ac0d-c101-4c3e-91fc-cde056f554ad', 37, CAST(N'2016-04-30' AS Date), CAST(1.283905 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0131bbb-3791-4f77-ad1b-2eebce2f1585', 37, CAST(N'2016-05-31' AS Date), CAST(1.293075 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bd3f3824-ca88-44b3-acbe-708bcfc16e3d', 37, CAST(N'2016-06-30' AS Date), CAST(1.290092 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2df570ad-18dc-49cb-bfc1-af527927368c', 37, CAST(N'2016-07-31' AS Date), CAST(1.303180 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8cee375-0b82-4fe0-9d37-6af292301a11', 37, CAST(N'2016-08-31' AS Date), CAST(1.299560 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be1d271a-dac9-4da8-8c8a-db0f1ed65611', 37, CAST(N'2016-09-30' AS Date), CAST(1.310526 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c970953c-978f-4575-8519-16a2b5c4a155', 37, CAST(N'2016-10-31' AS Date), CAST(1.324308 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b516234d-2996-45e7-b989-1bfba96d08de', 37, CAST(N'2016-11-30' AS Date), CAST(1.345756 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e6357448-a6a4-4050-b161-33904eae72a3', 37, CAST(N'2016-12-31' AS Date), CAST(1.334768 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'31f0a622-fabb-4992-90e7-20c389049772', 37, CAST(N'2017-01-31' AS Date), CAST(1.321192 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bddab2d9-c2af-4233-9f45-24be64434c44', 37, CAST(N'2017-02-28' AS Date), CAST(1.309965 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8d8fbf5b-87ee-4b8f-aa1d-4d790e878ef6', 37, CAST(N'2017-03-31' AS Date), CAST(1.338878 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a7a70528-545a-4fed-a52c-89948b63700f', 37, CAST(N'2017-04-30' AS Date), CAST(1.344386 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d1d66d3-37d0-48f6-bbc2-eb6a913c4bec', 37, CAST(N'2017-05-31' AS Date), CAST(1.359535 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'45c0cb4a-068f-4d75-a338-6e60ed35b873', 37, CAST(N'2017-06-30' AS Date), CAST(1.331711 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c0c8a40-29ef-480d-a0f6-36d47baf1e7a', 37, CAST(N'2017-07-31' AS Date), CAST(1.269651 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7b5763c7-b839-4436-b880-bb01aa5a2929', 37, CAST(N'2017-08-31' AS Date), CAST(1.260876 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a13a78ca-0c88-4c51-81ce-f38a524b8dba', 37, CAST(N'2017-09-30' AS Date), CAST(1.228998 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a2209a24-e754-4c8a-83b9-36777d189ac6', 37, CAST(N'2017-10-31' AS Date), CAST(1.260598 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd2481bac-344d-4724-be8a-32672512a063', 37, CAST(N'2017-11-30' AS Date), CAST(1.275853 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'98cb979a-6f7c-4a39-a73c-fe2f7a946d97', 37, CAST(N'2017-12-31' AS Date), CAST(1.275719 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9236119a-eb0c-44a3-b35f-af603c2f28cf', 37, CAST(N'2018-01-31' AS Date), CAST(1.243433 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8a94f66-a0c5-4f7f-b247-c0a846beb61d', 37, CAST(N'2018-02-28' AS Date), CAST(1.257634 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'23556437-a8e6-4b4f-8785-a600fe71c862', 37, CAST(N'2018-03-31' AS Date), CAST(1.292903 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0b9059ac-4eb7-4718-bbbb-357cbc966aac', 37, CAST(N'2018-04-30' AS Date), CAST(1.274482 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7bb7c1d9-963c-47cb-89a3-42de594b7df2', 37, CAST(N'2018-05-31' AS Date), CAST(1.287227 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5054f92a-3b29-4966-b83c-8733c022cadf', 37, CAST(N'2018-06-30' AS Date), CAST(1.312379 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b48b42b7-85f6-4d11-a9b4-e198ca99cac8', 37, CAST(N'2018-07-31' AS Date), CAST(1.313303 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e05607f4-007f-4358-9c55-282d03e084c1', 37, CAST(N'2018-08-31' AS Date), CAST(1.304956 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'47acf0f8-95a2-4bc9-b16a-ea7c8dfbbc0e', 37, CAST(N'2018-09-30' AS Date), CAST(1.303321 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'15dd02d2-f700-4b8c-9f7d-d3f2904b8e39', 37, CAST(N'2018-10-31' AS Date), CAST(1.302096 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7bd22033-b34d-4d32-ac87-7b95c50c2bfb', 37, CAST(N'2018-11-30' AS Date), CAST(1.319734 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c69aa46a-0f7b-44aa-989b-1d14b5dea541', 37, CAST(N'2018-12-31' AS Date), CAST(1.345234 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'147b64af-1939-4d62-9b40-8a5b38e1719b', 37, CAST(N'2019-01-31' AS Date), CAST(1.330202 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'88196a6d-861b-4661-896b-59d3492d4a49', 37, CAST(N'2019-02-28' AS Date), CAST(1.320638 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c1208d3-1659-47bf-9dfa-c9ee47c8b47d', 37, CAST(N'2019-03-31' AS Date), CAST(1.337235 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7960891c-a7f6-47e5-b235-ed06825cea32', 37, CAST(N'2019-04-30' AS Date), CAST(1.338409 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c91ce50-2d5f-410e-b646-97af72d49aaf', 37, CAST(N'2019-05-31' AS Date), CAST(1.345505 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7aae6b30-afa7-47b3-a920-1963ed8ea4ad', 37, CAST(N'2019-06-30' AS Date), CAST(1.330281 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'67a7172a-2b9b-4020-b59d-223c91918c72', 37, CAST(N'2019-07-31' AS Date), CAST(1.310256 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c8230ed6-98b9-46b8-bd50-4f86a6246a5f', 37, CAST(N'2019-08-31' AS Date), CAST(1.327759 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b8c18111-8a92-4977-886e-cf1b54ab94e2', 37, CAST(N'2019-09-30' AS Date), CAST(1.324762 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'34fdb811-ab96-4c73-9ba2-65715087b671', 37, CAST(N'2019-10-31' AS Date), CAST(1.318787 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c64fdea1-372b-43c8-bb2a-8bfe8c85391f', 37, CAST(N'2019-11-30' AS Date), CAST(1.323737 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7fc8536e-40af-496f-bdd8-0932618ee04d', 37, CAST(N'2019-12-31' AS Date), CAST(1.317169 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21596d77-4472-4621-9766-ae72befe5dfe', 37, CAST(N'2020-01-31' AS Date), CAST(1.307925 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2eca779f-d5b0-411d-b4e6-10f23cbb489f', 37, CAST(N'2020-02-29' AS Date), CAST(1.328071 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fe92d2be-3b5c-4c2d-b20c-eea097108750', 190, CAST(N'1990-01-31' AS Date), CAST(1.887262 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'509a1e64-6cfe-4bc6-85dc-9d825ee64fd7', 190, CAST(N'1990-02-28' AS Date), CAST(1.864105 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6da84542-4647-410c-9a83-5e81bb0e463c', 190, CAST(N'1990-03-31' AS Date), CAST(1.877705 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4d40874f-9faf-4c66-ae72-ea90ff6575d4', 190, CAST(N'1990-04-30' AS Date), CAST(1.878310 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f6a4af02-7262-4573-83ce-27abdb5382bb', 190, CAST(N'1990-05-31' AS Date), CAST(1.858882 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13133eba-aef7-492e-b08f-f0a3712d727d', 190, CAST(N'1990-06-30' AS Date), CAST(1.847114 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ff7ce97-969f-4846-a4e5-a006634c775d', 190, CAST(N'1990-07-31' AS Date), CAST(1.819324 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'17068fe7-bd64-40a1-95e3-f58e30996d12', 190, CAST(N'1990-08-31' AS Date), CAST(1.790522 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c8678ce3-30c1-4292-a13e-e84669033484', 190, CAST(N'1990-09-30' AS Date), CAST(1.767121 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5303fd3-56b1-4668-ae2d-1db4e52bb926', 190, CAST(N'1990-10-31' AS Date), CAST(1.725705 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eafb64d0-40dd-4eac-96a6-43f626b790ab', 190, CAST(N'1990-11-30' AS Date), CAST(1.709975 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'50921416-1312-4fdc-8e9f-f747399b3264', 190, CAST(N'1990-12-31' AS Date), CAST(1.727475 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd9788c57-6e31-4d01-8858-2167550ebcc9', 190, CAST(N'1991-01-31' AS Date), CAST(1.745452 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'74e0052f-b0ce-41b1-83ec-514bbe0dca02', 190, CAST(N'1991-02-28' AS Date), CAST(1.717974 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2553eedc-e5db-4403-8e7f-712b38d67522', 190, CAST(N'1991-03-31' AS Date), CAST(1.758938 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a4992a07-d231-4e5a-9a2e-6a6fa95cc04a', 190, CAST(N'1991-04-30' AS Date), CAST(1.768841 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9067db6e-2dd6-4d06-8ddb-ea56fbd6d0e9', 190, CAST(N'1991-05-31' AS Date), CAST(1.768795 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6c93af84-8e63-4d04-80d0-6ad4466f80b3', 190, CAST(N'1991-06-30' AS Date), CAST(1.778200 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'864442b0-ee09-41e1-ab41-9c8e59661673', 190, CAST(N'1991-07-31' AS Date), CAST(1.755464 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'00ef5974-7ad1-447a-abc8-3c2608bcec37', 190, CAST(N'1991-08-31' AS Date), CAST(1.726900 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'07f5598e-d3fc-4292-8d2a-5127a75ddf88', 190, CAST(N'1991-09-30' AS Date), CAST(1.700225 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd598289f-9ee6-4bdd-8980-65f97ae8c01e', 190, CAST(N'1991-10-31' AS Date), CAST(1.694014 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4cc4b008-65a4-4e87-96db-6fefd543074f', 190, CAST(N'1991-11-30' AS Date), CAST(1.670863 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ecffb1e-7731-4e7b-9d59-ff5b812bbd5c', 190, CAST(N'1991-12-31' AS Date), CAST(1.645310 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'22eed71f-e6ce-4695-a476-db7924db23ef', 190, CAST(N'1992-01-31' AS Date), CAST(1.633748 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d54f50f-0eda-4fe2-bd1e-02c5b49321a1', 190, CAST(N'1992-02-29' AS Date), CAST(1.636095 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9fcd7aa5-80f8-4459-ae39-013431eec8d2', 190, CAST(N'1992-03-31' AS Date), CAST(1.660127 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3d367320-f408-4b16-9264-cee9e1dedd12', 190, CAST(N'1992-04-30' AS Date), CAST(1.656714 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e09a5ca5-9f43-4cda-96e4-ba78acefae0f', 190, CAST(N'1992-05-31' AS Date), CAST(1.640825 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a5bcab4f-c645-45d7-a2cd-8823fc224ab1', 190, CAST(N'1992-06-30' AS Date), CAST(1.624009 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'52c614bf-e80c-4366-ad97-351fd428d341', 190, CAST(N'1992-07-31' AS Date), CAST(1.614226 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bd492a67-398b-459b-a7b9-000ce528d9ed', 190, CAST(N'1992-08-31' AS Date), CAST(1.607662 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'71b28700-dcbd-4c81-a02f-fd01f99c562b', 190, CAST(N'1992-09-30' AS Date), CAST(1.598767 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1bfb936f-ab87-421a-bb97-173ca6b4becf', 190, CAST(N'1992-10-31' AS Date), CAST(1.608057 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'45a961a6-5028-45f3-a09e-92aacd28d200', 190, CAST(N'1992-11-30' AS Date), CAST(1.633789 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13493e8a-6763-4d87-ac65-8a0f248f270e', 190, CAST(N'1992-12-31' AS Date), CAST(1.639659 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4937011a-7909-4ee8-8908-539fe908c1da', 190, CAST(N'1993-01-31' AS Date), CAST(1.652695 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ae6918fc-923e-45dd-a739-1304024934e0', 190, CAST(N'1993-02-28' AS Date), CAST(1.646342 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81430747-d404-403f-a6af-1fb0e823de02', 190, CAST(N'1993-03-31' AS Date), CAST(1.644557 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'63817e08-89b2-483f-90f5-63ed5df5f79e', 190, CAST(N'1993-04-30' AS Date), CAST(1.622791 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'57a818c9-038b-4912-a935-6360c6a8a8ec', 190, CAST(N'1993-05-31' AS Date), CAST(1.613605 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d2d9401-a679-42d4-82db-f2db69a8240e', 190, CAST(N'1993-06-30' AS Date), CAST(1.617509 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f53a2725-df61-4259-a7a5-994148e8c562', 190, CAST(N'1993-07-31' AS Date), CAST(1.620562 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6e7bc7d4-3f98-4607-81f5-ad80cf262a7e', 190, CAST(N'1993-08-31' AS Date), CAST(1.609968 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'afb0c648-b2cd-4d06-81f2-78e6d0dfba3d', 190, CAST(N'1993-09-30' AS Date), CAST(1.597186 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'09261076-f68b-43ca-a7c8-8d7faacfb450', 190, CAST(N'1993-10-31' AS Date), CAST(1.573515 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'29b9403d-deba-4232-a194-d71f183c52fb', 190, CAST(N'1993-11-30' AS Date), CAST(1.595015 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'12a93978-e253-4a72-8049-c34758a9e66e', 190, CAST(N'1993-12-31' AS Date), CAST(1.597543 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5217a317-9686-47f5-92bc-bf994d82eeca', 190, CAST(N'1994-01-31' AS Date), CAST(1.603700 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0fd09a42-4de8-40b5-a637-bbe307140e3a', 190, CAST(N'1994-02-28' AS Date), CAST(1.587295 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'edb96bed-46e0-4959-88ee-ba312f94478e', 190, CAST(N'1994-03-31' AS Date), CAST(1.581948 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd6af13a9-f0ff-40ee-a49b-52bc3a8cca35', 190, CAST(N'1994-04-30' AS Date), CAST(1.562762 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'15b5cd00-6d11-4da9-86a6-079e40c2082e', 190, CAST(N'1994-05-31' AS Date), CAST(1.546405 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7314d933-d617-4583-a46b-dc6fbb2f4518', 190, CAST(N'1994-06-30' AS Date), CAST(1.530973 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ad33311c-5b83-4f14-ade4-04aac725e155', 190, CAST(N'1994-07-31' AS Date), CAST(1.513705 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f6adc846-4a9c-4eca-b295-7134d5aa2413', 190, CAST(N'1994-08-31' AS Date), CAST(1.504465 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b9729b5-6d58-4a17-a1fd-c4010ae4545b', 190, CAST(N'1994-09-30' AS Date), CAST(1.488486 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6bd882f5-e145-4138-9606-dc9fa61a3116', 190, CAST(N'1994-10-31' AS Date), CAST(1.476080 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'490e27f8-4a62-4703-81f6-c80431da5e11', 190, CAST(N'1994-11-30' AS Date), CAST(1.468230 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6b670a22-be71-4f89-8350-849f0d66f60b', 190, CAST(N'1994-12-31' AS Date), CAST(1.465710 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'66cde1e6-ab7d-4bab-bdaf-90ef9c1a2cd4', 190, CAST(N'1995-01-31' AS Date), CAST(1.453150 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b193d9d0-69b5-4ff6-b246-c4ab701addb3', 190, CAST(N'1995-02-28' AS Date), CAST(1.454147 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d64107b-d132-4fb0-8ee0-4badf8859542', 190, CAST(N'1995-03-31' AS Date), CAST(1.421643 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'49ce54cb-5ace-407f-a0d5-720c3ba0653b', 190, CAST(N'1995-04-30' AS Date), CAST(1.398595 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'40613901-29cd-48de-9a69-71460714a570', 190, CAST(N'1995-05-31' AS Date), CAST(1.394695 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3a0ff67f-e994-490f-aa3b-41f5255143ed', 190, CAST(N'1995-06-30' AS Date), CAST(1.395295 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0dfd3592-28aa-4962-872e-894ee02bfa84', 190, CAST(N'1995-07-31' AS Date), CAST(1.398380 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'30fe8694-4ca7-4f1b-bc47-f7cf9c0a5dfb', 190, CAST(N'1995-08-31' AS Date), CAST(1.411604 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ef2cc495-efc2-45d1-b849-ea6a1a6d5f7d', 190, CAST(N'1995-09-30' AS Date), CAST(1.433085 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8836f02-d24a-4087-8a15-cb61597c7431', 190, CAST(N'1995-10-31' AS Date), CAST(1.423124 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'49b16988-8292-4778-aa46-9ea4696f0327', 190, CAST(N'1995-11-30' AS Date), CAST(1.412800 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6070ab06-1bad-4460-8dce-966ed3fb8230', 190, CAST(N'1995-12-31' AS Date), CAST(1.414830 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dcb71595-427d-4f71-83d2-7ef99aea2b32', 190, CAST(N'1996-01-31' AS Date), CAST(1.421124 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf9ecbbc-5d52-4e78-81db-3f79e1d62398', 190, CAST(N'1996-02-29' AS Date), CAST(1.411545 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd6185920-5a8f-4788-820b-dc257eb34961', 190, CAST(N'1996-03-31' AS Date), CAST(1.409533 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'553092bb-652f-4a9b-a8f9-7c09585317ec', 190, CAST(N'1996-04-30' AS Date), CAST(1.408450 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'46f2ac99-c9ae-400b-a172-aba204bce88b', 190, CAST(N'1996-05-31' AS Date), CAST(1.407350 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eec1a2fe-265d-4846-b0d0-1e9044ceb67d', 190, CAST(N'1996-06-30' AS Date), CAST(1.409025 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d17e71a-4d5b-4a7c-8b5f-877c6c229260', 190, CAST(N'1996-07-31' AS Date), CAST(1.416023 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1b116385-52d4-4b5b-b3a0-ab3496fc3f2e', 190, CAST(N'1996-08-31' AS Date), CAST(1.412364 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b708fbb4-d723-49ed-83d3-37a20352c32f', 190, CAST(N'1996-09-30' AS Date), CAST(1.408585 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ace1618-e01f-4f43-9112-bc3d0b4fd5af', 190, CAST(N'1996-10-31' AS Date), CAST(1.412445 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0a990319-af92-478d-921a-ff51e80e8e42', 190, CAST(N'1996-11-30' AS Date), CAST(1.402547 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2316a5b-2e81-48a3-b64e-b48dc39654ca', 190, CAST(N'1996-12-31' AS Date), CAST(1.399943 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'93240a2c-1f62-4df1-85ff-3410b4e40d3f', 190, CAST(N'1997-01-31' AS Date), CAST(1.406062 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1068b349-289d-4946-92d6-19c9f26114b0', 190, CAST(N'1997-02-28' AS Date), CAST(1.419347 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'874b1949-53fe-457f-b7c8-2fa526510866', 190, CAST(N'1997-03-31' AS Date), CAST(1.437810 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fd9aaf8f-d4ca-40ec-8e81-4826ba9c55b4', 190, CAST(N'1997-04-30' AS Date), CAST(1.441700 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ff2d27b6-9c2e-49f9-950d-8cec9a8a5d4c', 190, CAST(N'1997-05-31' AS Date), CAST(1.436771 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'47486adf-f7ae-4a94-846d-1eb43ef277d3', 190, CAST(N'1997-06-30' AS Date), CAST(1.427100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9dc4aad9-4cae-4ba8-baa7-1f4e285629f8', 190, CAST(N'1997-07-31' AS Date), CAST(1.452082 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7dfa655d-7589-44f3-b6a9-57e67dbdaf39', 190, CAST(N'1997-08-31' AS Date), CAST(1.497714 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3dc98ed4-17b0-476a-9dec-9d9a7e1b4f36', 190, CAST(N'1997-09-30' AS Date), CAST(1.516357 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0d87b70f-91e3-4883-9121-2196e29f9453', 190, CAST(N'1997-10-31' AS Date), CAST(1.559745 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'586e3e0c-71c4-40f2-8d11-00329494a260', 190, CAST(N'1997-11-30' AS Date), CAST(1.581972 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2096654b-78b4-4b6e-b5ba-1acf5b6dee47', 190, CAST(N'1997-12-31' AS Date), CAST(1.651841 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f4f40972-90d4-406b-802e-a303d1f43d52', 190, CAST(N'1998-01-31' AS Date), CAST(1.747725 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e8028704-2b1b-4790-9d53-94a26f0784fe', 190, CAST(N'1998-02-28' AS Date), CAST(1.650868 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'719276fb-15a9-463b-85f0-ea105228ba23', 190, CAST(N'1998-03-31' AS Date), CAST(1.618750 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b361a6e7-575b-4550-8a6c-1a4c032cc119', 190, CAST(N'1998-04-30' AS Date), CAST(1.600673 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'98a01036-a030-4562-b34c-aee6089f64f7', 190, CAST(N'1998-05-31' AS Date), CAST(1.637400 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1db59998-932f-4877-9cda-d7e3c9d78abd', 190, CAST(N'1998-06-30' AS Date), CAST(1.694127 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4fe26fb-7c3c-4bcb-88e9-350c24a53fcd', 190, CAST(N'1998-07-31' AS Date), CAST(1.708522 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'08056dd2-6196-4edd-828b-5dd49c84e04c', 190, CAST(N'1998-08-31' AS Date), CAST(1.757100 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4136d09d-12db-478e-8847-ec5eeb8f8f01', 190, CAST(N'1998-09-30' AS Date), CAST(1.722910 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'533352a3-c251-4ab9-ba08-71f12b14352a', 190, CAST(N'1998-10-31' AS Date), CAST(1.637843 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c8a606fb-3caa-4d77-a1e6-3acd43f6c18c', 190, CAST(N'1998-11-30' AS Date), CAST(1.637763 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a797e41b-6432-430c-9db2-6314b5163cca', 190, CAST(N'1998-12-31' AS Date), CAST(1.651473 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'544bf3e3-c307-44c0-a3b5-746a380b1540', 190, CAST(N'1999-01-31' AS Date), CAST(1.679339 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1da59639-d628-415d-a0de-dd9a692f1167', 190, CAST(N'1999-02-28' AS Date), CAST(1.699688 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e1e46997-6406-4eed-b1f3-609c74e93350', 190, CAST(N'1999-03-31' AS Date), CAST(1.729005 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bec0a3fa-3cf8-4679-8756-086651b67074', 190, CAST(N'1999-04-30' AS Date), CAST(1.712284 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'04edbe04-cba6-43aa-b6ed-f031e70fc449', 190, CAST(N'1999-05-31' AS Date), CAST(1.712089 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3f5cdb05-6e5d-4111-b70f-23c0a5281da3', 190, CAST(N'1999-06-30' AS Date), CAST(1.710848 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'306fd450-c525-407a-9e71-aa69e3ef898e', 190, CAST(N'1999-07-31' AS Date), CAST(1.695901 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e1df565c-63c5-4455-adac-65221cb07762', 190, CAST(N'1999-08-31' AS Date), CAST(1.678432 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'148f0583-948f-4dc6-bc82-6ff21c613364', 190, CAST(N'1999-09-30' AS Date), CAST(1.696372 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4c6012e7-5300-4ae4-b72f-026fcb44cd4e', 190, CAST(N'1999-10-31' AS Date), CAST(1.675241 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f0a953bb-c111-471b-be6b-a73c1d89f1d9', 190, CAST(N'1999-11-30' AS Date), CAST(1.669991 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5063a344-2d43-4994-b8ce-0e0624fadf4f', 190, CAST(N'1999-12-31' AS Date), CAST(1.674728 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a219b636-eddd-4702-99bc-d26481177180', 190, CAST(N'2000-01-31' AS Date), CAST(1.675579 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4c0c111d-9d50-40bc-bfc8-da8b65641477', 190, CAST(N'2000-02-29' AS Date), CAST(1.701885 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1a81b7d3-1037-40ae-a552-247ff8e312d6', 190, CAST(N'2000-03-31' AS Date), CAST(1.715271 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bcfa9866-26b3-44c8-9f4f-cd237f268f4e', 190, CAST(N'2000-04-30' AS Date), CAST(1.708564 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b64ce60d-139c-40f8-a568-6b33363bc7bd', 190, CAST(N'2000-05-31' AS Date), CAST(1.727148 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4bd5406a-1114-483f-b987-efd5444ab352', 190, CAST(N'2000-06-30' AS Date), CAST(1.727721 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2ba7625a-7791-495a-a152-6cfa298d3bd0', 190, CAST(N'2000-07-31' AS Date), CAST(1.739618 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'100b842f-27e9-4ebb-a20a-dfd132f893dd', 190, CAST(N'2000-08-31' AS Date), CAST(1.720121 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5112f852-51fe-438e-b867-86e4c73e7577', 190, CAST(N'2000-09-30' AS Date), CAST(1.738292 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e7a096ec-3de1-49b5-b776-128919fe10a4', 190, CAST(N'2000-10-31' AS Date), CAST(1.751357 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e4ecf91a-8416-4e8b-ac76-6a8794bbfdf5', 190, CAST(N'2000-11-30' AS Date), CAST(1.748077 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'95f9a5c2-541e-45cb-8502-31653196c9bc', 190, CAST(N'2000-12-31' AS Date), CAST(1.735707 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'df373f6f-f7ae-4d6f-a4f4-82cef31e0621', 190, CAST(N'2001-01-31' AS Date), CAST(1.736737 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0f405174-ec8e-4465-aa2d-0667cf9a8892', 190, CAST(N'2001-02-28' AS Date), CAST(1.742685 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'49926c13-539b-41ee-8ca1-7b56f460fb2c', 190, CAST(N'2001-03-31' AS Date), CAST(1.771057 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'727eee73-ca31-4c32-8d3c-806b79756072', 190, CAST(N'2001-04-30' AS Date), CAST(1.810521 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8e1fc9c2-d224-4288-8820-54721e49eab4', 190, CAST(N'2001-05-31' AS Date), CAST(1.813850 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'36d33ff7-a28d-4ea5-bca0-1d9b51120cd5', 190, CAST(N'2001-06-30' AS Date), CAST(1.815993 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1357df19-5268-4aac-b7e8-a732954bf91e', 190, CAST(N'2001-07-31' AS Date), CAST(1.823595 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c351ad5-f075-4ba0-b09d-2ed6a2cd8fe6', 190, CAST(N'2001-08-31' AS Date), CAST(1.762728 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ff070e4-f40f-42ad-9a2e-629e7a521c0e', 190, CAST(N'2001-09-30' AS Date), CAST(1.747232 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5a41fd2-cbc3-4080-98ef-1a1ee17409ac', 190, CAST(N'2001-10-31' AS Date), CAST(1.807339 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4c662a77-54e0-4e60-bffd-6228cd6222f1', 190, CAST(N'2001-11-30' AS Date), CAST(1.828642 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a904eb2c-c471-4563-99d2-b4956ab59564', 190, CAST(N'2001-12-31' AS Date), CAST(1.836662 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c3268e9-c346-45ba-8714-77f34bcf63d6', 190, CAST(N'2002-01-31' AS Date), CAST(1.839861 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7ea26ff0-f67d-411a-b63f-771b94739733', 190, CAST(N'2002-02-28' AS Date), CAST(1.830710 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8d6a2aa4-3f9a-4c25-839d-ee53c3765534', 190, CAST(N'2002-03-31' AS Date), CAST(1.829510 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'83285452-45bf-4398-83df-fa6dbc6f089d', 190, CAST(N'2002-04-30' AS Date), CAST(1.829864 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'028aacd1-5c4b-41e3-88c3-8c4c4b39cbca', 190, CAST(N'2002-05-31' AS Date), CAST(1.800439 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a134e5de-6985-4c0f-aa9b-8ae021dedcdc', 190, CAST(N'2002-06-30' AS Date), CAST(1.783371 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7278c16f-e601-4b82-9cca-fba0cbf6cf45', 190, CAST(N'2002-07-31' AS Date), CAST(1.752280 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fd664a1a-1620-49e6-a7b0-0fcfa6bee144', 190, CAST(N'2002-08-31' AS Date), CAST(1.755870 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ac053292-2026-4e4e-b0f0-84acc4c59d20', 190, CAST(N'2002-09-30' AS Date), CAST(1.765942 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9589457c-0763-4c08-932d-c8eb8a5d7ae6', 190, CAST(N'2002-10-31' AS Date), CAST(1.784555 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1503609a-983c-4bee-ad13-69f741cc087c', 190, CAST(N'2002-11-30' AS Date), CAST(1.764195 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'27cbcccf-98d8-4c21-ad8b-720a3c4f7916', 190, CAST(N'2002-12-31' AS Date), CAST(1.756230 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'90304921-6638-4ca1-8a8a-328b3b77adc3', 190, CAST(N'2003-01-31' AS Date), CAST(1.735797 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c612216-dd12-4fc7-9bec-4757af61559c', 190, CAST(N'2003-02-28' AS Date), CAST(1.745598 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'732c452d-962b-498a-8b69-79e605479a26', 190, CAST(N'2003-03-31' AS Date), CAST(1.751326 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd8771bff-ed37-46b8-8913-fd50240abeb5', 190, CAST(N'2003-04-30' AS Date), CAST(1.777665 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'71b787c2-520d-4374-8534-5cf01173fd0d', 190, CAST(N'2003-05-31' AS Date), CAST(1.736564 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'34172357-4232-4dc1-9ccb-52f2214bbe72', 190, CAST(N'2003-06-30' AS Date), CAST(1.733893 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e15b3b90-8632-4f34-91bc-3fe7e462be11', 190, CAST(N'2003-07-31' AS Date), CAST(1.753006 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'20087218-3a7e-46bc-909a-d4bd1b9bfd07', 190, CAST(N'2003-08-31' AS Date), CAST(1.752955 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ffb1e9f8-632f-43b5-84c7-8a89e2a4bda6', 190, CAST(N'2003-09-30' AS Date), CAST(1.746545 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c3c592f-a1af-49cc-ac77-761bf7faf891', 190, CAST(N'2003-10-31' AS Date), CAST(1.732934 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'59520503-146f-48e3-8b3c-9b79a1de2edc', 190, CAST(N'2003-11-30' AS Date), CAST(1.728772 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'18f6357a-e72c-40cb-9f82-b13f0635cbf7', 190, CAST(N'2003-12-31' AS Date), CAST(1.712218 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'169f1b1e-5122-4113-aab4-bed5a5816280', 190, CAST(N'2004-01-31' AS Date), CAST(1.697323 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'01467387-e436-4c98-9130-331348417343', 190, CAST(N'2004-02-29' AS Date), CAST(1.687310 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'145529a0-9d96-48da-bb6b-3cf540239e37', 190, CAST(N'2004-03-31' AS Date), CAST(1.700552 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b6e1d05f-4b3a-46e6-abcf-589b001e7c31', 190, CAST(N'2004-04-30' AS Date), CAST(1.683515 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'05c5cb11-1fbd-48a6-a3d4-ca36c5c2029b', 190, CAST(N'2004-05-31' AS Date), CAST(1.710479 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1f858c48-fc15-46f3-8a64-d9581bffee0a', 190, CAST(N'2004-06-30' AS Date), CAST(1.712705 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd7159a8b-37ff-45e7-9854-c58e959566d8', 190, CAST(N'2004-07-31' AS Date), CAST(1.712381 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aedd893b-9fe2-4d13-9b97-99f20a9574ce', 190, CAST(N'2004-08-31' AS Date), CAST(1.715311 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f29116c0-005e-4ea3-a510-30005a714d0e', 190, CAST(N'2004-09-30' AS Date), CAST(1.695898 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1c82f1a6-9b8f-4e69-a326-b2904057043f', 190, CAST(N'2004-10-31' AS Date), CAST(1.678285 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3ac274eb-ecfc-4829-a484-4a91a269190f', 190, CAST(N'2004-11-30' AS Date), CAST(1.651420 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cc5f1af9-cf78-4034-99b5-ad39451f5eef', 190, CAST(N'2004-12-31' AS Date), CAST(1.636091 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'188b00d0-ca0d-4b40-96be-a2ad383ae314', 190, CAST(N'2005-01-31' AS Date), CAST(1.622459 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'116c935c-ab12-4e80-ab96-4d2c1921455b', 190, CAST(N'2005-02-28' AS Date), CAST(1.639448 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cecd2702-aab4-4b6c-b08b-4348b845c276', 190, CAST(N'2005-03-31' AS Date), CAST(1.630547 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a4168332-aec6-409d-88a3-20a03087b1d8', 190, CAST(N'2005-04-30' AS Date), CAST(1.652220 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5508d676-e229-418e-a44a-e53bf2436d0e', 190, CAST(N'2005-05-31' AS Date), CAST(1.651079 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'af9363c0-8c56-436a-baf2-410681bc2edf', 190, CAST(N'2005-06-30' AS Date), CAST(1.671603 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1d9c5802-f1d0-42c9-8f01-69f480066211', 190, CAST(N'2005-07-31' AS Date), CAST(1.682934 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9a3cc6e3-ab24-4b0e-99d3-32a6939dbc54', 190, CAST(N'2005-08-31' AS Date), CAST(1.661773 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'70bd86cb-a2be-49b9-91a7-8becb6e599ca', 190, CAST(N'2005-09-30' AS Date), CAST(1.680805 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f09209e0-4a4a-4bd0-bed4-caeb4bdefa36', 190, CAST(N'2005-10-31' AS Date), CAST(1.690800 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6f585aef-4043-4e8a-8cd2-f218991ce561', 190, CAST(N'2005-11-30' AS Date), CAST(1.698552 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3ed1d58f-375f-4fd2-9273-dcd0b653f325', 190, CAST(N'2005-12-31' AS Date), CAST(1.674599 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1e69045f-7a4c-452e-afb5-a77b2fddb480', 190, CAST(N'2006-01-31' AS Date), CAST(1.634965 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7bfaee97-2cfa-4142-9339-39e4c20f7de2', 190, CAST(N'2006-02-28' AS Date), CAST(1.629575 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'93a65e94-69bc-469a-8ca3-8be2d32494e9', 190, CAST(N'2006-03-31' AS Date), CAST(1.621886 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'664d0e0a-534b-4ff5-b728-679fcc27e7b7', 190, CAST(N'2006-04-30' AS Date), CAST(1.602797 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fa8ca056-0456-4f6c-b200-2f77b52d4a97', 190, CAST(N'2006-05-31' AS Date), CAST(1.576290 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7d3d7f65-4f26-4c9f-b2bf-b8ccc33d63a7', 190, CAST(N'2006-06-30' AS Date), CAST(1.592450 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'60c85f28-bbc3-4096-8e1f-4f7c5d3193b7', 190, CAST(N'2006-07-31' AS Date), CAST(1.583792 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b4e62cd-a925-4428-b5e9-4281ef20674a', 190, CAST(N'2006-08-31' AS Date), CAST(1.576348 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f28406dd-a944-4a09-8209-cb3aa4f6efa7', 190, CAST(N'2006-09-30' AS Date), CAST(1.579201 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'70874ac6-d14f-4891-99cd-7df0104f2425', 190, CAST(N'2006-10-31' AS Date), CAST(1.578746 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0c53569b-a4be-4c8b-b930-1d12d94c0d94', 190, CAST(N'2006-11-30' AS Date), CAST(1.556641 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4ab37de5-d953-4ef2-9580-365e689b9a2d', 190, CAST(N'2006-12-31' AS Date), CAST(1.540747 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec51dfc2-d048-4d78-a30e-c870a938f98b', 190, CAST(N'2007-01-31' AS Date), CAST(1.537587 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85235147-e7e4-4e28-93ad-06f1881a3f27', 190, CAST(N'2007-02-28' AS Date), CAST(1.533530 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7c538a47-ea55-4537-8f95-b5d61e0781e0', 190, CAST(N'2007-03-31' AS Date), CAST(1.524922 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ec77297-1b7c-4a1a-af88-6d3da9795d39', 190, CAST(N'2007-04-30' AS Date), CAST(1.515043 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd0f2265d-33e7-45c6-b7e6-7c2a1fc9fb3d', 190, CAST(N'2007-05-31' AS Date), CAST(1.524086 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be42b280-b707-491e-b054-31fc6f49e5a9', 190, CAST(N'2007-06-30' AS Date), CAST(1.536521 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c887d882-a67d-49c3-88e6-6b2c643120c6', 190, CAST(N'2007-07-31' AS Date), CAST(1.516649 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f161191c-e139-4587-8d04-967403a5f7d3', 190, CAST(N'2007-08-31' AS Date), CAST(1.522783 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'91b9b30b-226f-43e2-a813-393883fc4fbf', 190, CAST(N'2007-09-30' AS Date), CAST(1.511798 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b4c0b7a1-8328-410c-a11f-00981994c32a', 190, CAST(N'2007-10-31' AS Date), CAST(1.466311 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8aac25ce-bc7d-491e-b0ec-b79653db7dc7', 190, CAST(N'2007-11-30' AS Date), CAST(1.447202 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1ac716de-dbdc-45d9-bf5d-5bab34999f33', 190, CAST(N'2007-12-31' AS Date), CAST(1.449698 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bcc681ea-7b1e-431b-8ba0-eed36048e051', 190, CAST(N'2008-01-31' AS Date), CAST(1.432445 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e72e5fb2-9dd6-4c44-a597-b63eafb07bdf', 190, CAST(N'2008-02-29' AS Date), CAST(1.412945 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'81f20786-3120-438c-b947-d16cd5993af5', 190, CAST(N'2008-03-31' AS Date), CAST(1.385177 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b7368931-c065-4692-ac12-d0811b892cff', 190, CAST(N'2008-04-30' AS Date), CAST(1.364540 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd4d8197b-a456-4d3b-a435-f2ec1e3eadac', 190, CAST(N'2008-05-31' AS Date), CAST(1.365735 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b90003c8-8e86-4934-98d7-6ba39c8e7aa8', 190, CAST(N'2008-06-30' AS Date), CAST(1.368408 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd3423966-e250-4d6b-88d7-c82b6daa9913', 190, CAST(N'2008-07-31' AS Date), CAST(1.359234 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'51b97390-4aa9-470f-b089-c6f5aeaad008', 190, CAST(N'2008-08-31' AS Date), CAST(1.402045 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'21344daf-cfa3-4b69-bab0-582e5fbf88de', 190, CAST(N'2008-09-30' AS Date), CAST(1.430668 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8ee735ce-7266-4e89-8098-76869285feef', 190, CAST(N'2008-10-31' AS Date), CAST(1.473385 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bd8ee78b-78fd-475d-8141-d73471cc9c41', 190, CAST(N'2008-11-30' AS Date), CAST(1.505120 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c0ed2c26-ed4f-4037-b3e1-3e853ef65d10', 190, CAST(N'2008-12-31' AS Date), CAST(1.477515 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'07cffaad-ae6e-4659-a78c-a561c6092e62', 190, CAST(N'2009-01-31' AS Date), CAST(1.484715 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'383247cf-d4b1-41f9-8bfa-72bb41254a4d', 190, CAST(N'2009-02-28' AS Date), CAST(1.516236 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7d4deb40-8261-4af1-8bb6-bbc743d65103', 190, CAST(N'2009-03-31' AS Date), CAST(1.533398 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'52eae4ef-cd8d-4cfd-97a9-2a1086f78257', 190, CAST(N'2009-04-30' AS Date), CAST(1.505675 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'534550ba-03fb-4de0-892a-356a5e342f7a', 190, CAST(N'2009-05-31' AS Date), CAST(1.461474 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'82faf249-13dd-49b7-97de-94da9ba0a5e4', 190, CAST(N'2009-06-30' AS Date), CAST(1.452756 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'45ca139c-485f-4ff5-927a-898a52090dec', 190, CAST(N'2009-07-31' AS Date), CAST(1.450483 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b53a1e7-7ac7-4e51-8f66-22f508f4ba28', 190, CAST(N'2009-08-31' AS Date), CAST(1.441699 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ea067e44-18b7-4961-833a-e890873436a2', 190, CAST(N'2009-09-30' AS Date), CAST(1.423898 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2a6c0e39-4fd3-4f87-ad4e-993491ebce1e', 190, CAST(N'2009-10-31' AS Date), CAST(1.398623 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf44cc28-59a4-4191-9c68-e0d064def06a', 190, CAST(N'2009-11-30' AS Date), CAST(1.389782 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'60b89023-6059-4bd4-b6d1-366c7877b138', 190, CAST(N'2009-12-31' AS Date), CAST(1.396510 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ee61f62b-80bb-4d93-80e6-24af2179dcf1', 190, CAST(N'2010-01-31' AS Date), CAST(1.397847 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c04908f6-ec60-4294-924b-f46555eb3321', 190, CAST(N'2010-02-28' AS Date), CAST(1.412701 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'090f9768-42f0-433d-b21a-adbfc6f7f353', 190, CAST(N'2010-03-31' AS Date), CAST(1.399805 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'103237a7-6887-436e-82d9-59913f35a2b7', 190, CAST(N'2010-04-30' AS Date), CAST(1.383173 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8c1bd4c8-603a-4d1c-a4b4-5ab227b78d6b', 190, CAST(N'2010-05-31' AS Date), CAST(1.392864 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dc583a05-1586-4dfc-b6d0-9d31136a8a2c', 190, CAST(N'2010-06-30' AS Date), CAST(1.398130 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65880af8-e308-480f-85a8-935364b38fea', 190, CAST(N'2010-07-31' AS Date), CAST(1.377957 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bdb9d951-5944-400e-b02b-3fd51902ed43', 190, CAST(N'2010-08-31' AS Date), CAST(1.355561 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9d85ea2c-8a69-4518-84e6-79be34080699', 190, CAST(N'2010-09-30' AS Date), CAST(1.335700 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'33216b27-943c-444e-a9ba-46af2290a053', 190, CAST(N'2010-10-31' AS Date), CAST(1.303264 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'614e9720-7a94-47ce-bfbb-0e210109194a', 190, CAST(N'2010-11-30' AS Date), CAST(1.298237 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5026afa7-c191-40c1-bdc8-5819e34a2ed8', 190, CAST(N'2010-12-31' AS Date), CAST(1.306864 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'66714141-b3b4-43e9-bebb-ffda73ff9ee8', 190, CAST(N'2011-01-31' AS Date), CAST(1.286826 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4fb99d4f-7112-45af-b14f-9ef78138e15c', 190, CAST(N'2011-02-28' AS Date), CAST(1.276240 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7d9b6228-c0a4-4706-ab86-31c38e3b573b', 190, CAST(N'2011-03-31' AS Date), CAST(1.267967 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8368b0a0-ceb8-4ed4-8bc1-63166b934e9e', 190, CAST(N'2011-04-30' AS Date), CAST(1.247453 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ab9d52d2-d625-4451-a02c-c0003e3937e3', 190, CAST(N'2011-05-31' AS Date), CAST(1.238117 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e92ece31-24d8-44f3-bb46-2dca5e7c205a', 190, CAST(N'2011-06-30' AS Date), CAST(1.234529 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec2a9a56-340a-4fd0-94a7-f296867a159a', 190, CAST(N'2011-07-31' AS Date), CAST(1.217020 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'37f31047-ebcf-4df6-86df-e2878f619ead', 190, CAST(N'2011-08-31' AS Date), CAST(1.209246 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f272e732-afe4-4189-a907-bc98e3d11b51', 190, CAST(N'2011-09-30' AS Date), CAST(1.249882 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c2d2d6da-5d56-44c3-b251-6f246dedb03f', 190, CAST(N'2011-10-31' AS Date), CAST(1.278092 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8f69a62d-b18d-4da7-8a95-515b49ead191', 190, CAST(N'2011-11-30' AS Date), CAST(1.289995 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e962d72d-464d-4967-93e2-6ced8739b314', 190, CAST(N'2011-12-31' AS Date), CAST(1.295515 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd58bd06e-8185-44be-9d88-78b300b58b80', 190, CAST(N'2012-01-31' AS Date), CAST(1.280826 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2c3ac653-2a9c-4139-a705-623a33a5ae4f', 190, CAST(N'2012-02-29' AS Date), CAST(1.254112 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c3eb1058-08bc-4a47-b2a6-170a04ef774d', 190, CAST(N'2012-03-31' AS Date), CAST(1.257851 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'85602d6a-2248-4821-aa98-5ec8925ef203', 190, CAST(N'2012-04-30' AS Date), CAST(1.251431 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'658d424b-1218-4537-b14d-001bc9107a73', 190, CAST(N'2012-05-31' AS Date), CAST(1.261465 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5b6dfda-9328-4869-92e9-0154a46bd8e3', 190, CAST(N'2012-06-30' AS Date), CAST(1.279366 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'461d0736-e328-4788-8db3-4fac469a3aa2', 190, CAST(N'2012-07-31' AS Date), CAST(1.261236 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5b9545d5-f692-45ae-aa6a-166655fb0df5', 190, CAST(N'2012-08-31' AS Date), CAST(1.247981 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'79e7e598-0d9a-4f5e-bac9-01db6332fcd2', 190, CAST(N'2012-09-30' AS Date), CAST(1.231712 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8b20eb38-a527-43b4-9807-595a29c4036d', 190, CAST(N'2012-10-31' AS Date), CAST(1.224166 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'480d0f4a-81c8-4648-98da-3acbad1dbf6e', 190, CAST(N'2012-11-30' AS Date), CAST(1.223795 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'78227e4e-d6a5-4487-aa11-6fa1bd3a9369', 190, CAST(N'2012-12-31' AS Date), CAST(1.220635 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8f848f3f-27f4-429d-94ec-aac3f8502dbd', 190, CAST(N'2013-01-31' AS Date), CAST(1.227655 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'34133682-a104-4784-9c7d-78be3a7b300e', 190, CAST(N'2013-02-28' AS Date), CAST(1.238407 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b03aa547-9930-4038-99b0-68c856ffa4f1', 190, CAST(N'2013-03-31' AS Date), CAST(1.245920 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f18255b-c8f4-4a82-9b03-cb466aec1182', 190, CAST(N'2013-04-30' AS Date), CAST(1.238292 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'280bd5ea-23ec-4677-a065-36acbbb6128f', 190, CAST(N'2013-05-31' AS Date), CAST(1.247971 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b8eef5c6-8a20-43f7-b312-ee1e0134a10e', 190, CAST(N'2013-06-30' AS Date), CAST(1.260241 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'cfdea7f6-fedc-4184-b952-904f153f8e41', 190, CAST(N'2013-07-31' AS Date), CAST(1.268214 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'1abfa7e3-5b4b-4b9c-b968-a2ed3db30be7', 190, CAST(N'2013-08-31' AS Date), CAST(1.271684 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2cfc5c92-c699-45ed-9a75-2b86c50bdb08', 190, CAST(N'2013-09-30' AS Date), CAST(1.263994 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ec883eec-84e3-4e20-9b2b-4354f69edcaa', 190, CAST(N'2013-10-31' AS Date), CAST(1.243325 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'11ea0d7e-964b-4376-a493-fedf32c86d53', 190, CAST(N'2013-11-30' AS Date), CAST(1.247552 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'194248b9-bc30-4429-b829-48384b065321', 190, CAST(N'2013-12-31' AS Date), CAST(1.259219 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'80123b9f-9783-4ef2-9e84-d1d4e2a8c1a2', 190, CAST(N'2014-01-31' AS Date), CAST(1.271681 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6da880f3-0530-4fa6-a1e2-4c73fa3d1347', 190, CAST(N'2014-02-28' AS Date), CAST(1.266721 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'dc21b558-a0bb-420c-8536-bc34d7d55ae8', 190, CAST(N'2014-03-31' AS Date), CAST(1.267392 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0257d2fd-4644-4aee-8517-3703e10d27be', 190, CAST(N'2014-04-30' AS Date), CAST(1.254843 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9b78b629-5d54-499e-8510-408658222adb', 190, CAST(N'2014-05-31' AS Date), CAST(1.251770 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bdf0d77b-dca9-4341-b3d0-e164293639db', 190, CAST(N'2014-06-30' AS Date), CAST(1.251362 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f6ddfe4f-0b7c-46b2-b60c-ada605bc8d16', 190, CAST(N'2014-07-31' AS Date), CAST(1.242752 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5d50d898-f412-4804-a872-e9d3e96fabe4', 190, CAST(N'2014-08-31' AS Date), CAST(1.248490 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'fbfa5d3d-a791-4c3f-9901-0f2726f50c51', 190, CAST(N'2014-09-30' AS Date), CAST(1.262839 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'789c6d65-1dcb-454f-a615-0c5dc1da9f2d', 190, CAST(N'2014-10-31' AS Date), CAST(1.275214 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b189b5a0-e9c3-45a5-b54b-b99f27d734e7', 190, CAST(N'2014-11-30' AS Date), CAST(1.295346 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'635f59f9-4414-4768-8da6-7ef11233f2c2', 190, CAST(N'2014-12-31' AS Date), CAST(1.316106 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0dfe6c8c-cb85-4445-b9dd-74f3c3883281', 190, CAST(N'2015-01-31' AS Date), CAST(1.337068 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'6d81f438-811b-446e-94f3-a13fe0e2401f', 190, CAST(N'2015-02-28' AS Date), CAST(1.355238 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e9ed1f08-a5dc-4ecb-8699-a0bec310a6a8', 190, CAST(N'2015-03-31' AS Date), CAST(1.377001 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4e9e3179-0284-48c0-927f-081f1f25a9d1', 190, CAST(N'2015-04-30' AS Date), CAST(1.350090 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5e77886e-1d71-4022-932f-5e003881abef', 190, CAST(N'2015-05-31' AS Date), CAST(1.333487 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8cb9c70-7c9f-4a27-ab6a-d1535ac9532e', 190, CAST(N'2015-06-30' AS Date), CAST(1.345810 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e9e2d1a4-73d6-4ac5-9ada-af5653dccb26', 190, CAST(N'2015-07-31' AS Date), CAST(1.359939 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'be14d3b3-28b3-4802-a024-2fd5a107fcaf', 190, CAST(N'2015-08-31' AS Date), CAST(1.396330 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'13092f84-3797-4a59-8736-b3991779e4d5', 190, CAST(N'2015-09-30' AS Date), CAST(1.415097 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'742ed08e-9eed-415e-a9a3-452521dab561', 190, CAST(N'2015-10-31' AS Date), CAST(1.401805 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f3e2cca-c59d-40af-b5da-9e0185700652', 190, CAST(N'2015-11-30' AS Date), CAST(1.414547 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3b544da5-99b0-43e2-811e-85e8e5bfc3fb', 190, CAST(N'2015-12-31' AS Date), CAST(1.407972 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f02fb3d-ec27-4003-aa28-c01d97ed782c', 190, CAST(N'2016-01-31' AS Date), CAST(1.431853 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'65e967c7-5b11-4499-a27a-6f2eb3c8395f', 190, CAST(N'2016-02-29' AS Date), CAST(1.405742 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd1722291-1a7a-421f-8c14-5fd1a77fe18f', 190, CAST(N'2016-03-31' AS Date), CAST(1.373657 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aebf1b7b-beb0-47f7-beed-3093bb9cbd3e', 190, CAST(N'2016-04-30' AS Date), CAST(1.350612 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bf4963b8-2dac-48ad-a026-5e3c17047986', 190, CAST(N'2016-05-31' AS Date), CAST(1.369245 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd1f36f44-42c3-4815-a202-431bae5a1bba', 190, CAST(N'2016-06-30' AS Date), CAST(1.354510 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8b07d378-cd29-4393-b805-0bd5ec1d1a86', 190, CAST(N'2016-07-31' AS Date), CAST(1.350309 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9c4bcb8d-9393-4f50-9c7d-44798d4166e5', 190, CAST(N'2016-08-31' AS Date), CAST(1.347273 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'c5a5fe7d-26fe-4f3c-85e4-fcf8ec57018f', 190, CAST(N'2016-09-30' AS Date), CAST(1.360170 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'ca165de9-50bf-49c2-aff6-de91a4299013', 190, CAST(N'2016-10-31' AS Date), CAST(1.383265 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7856d860-304c-40d4-a046-f521b50ea975', 190, CAST(N'2016-11-30' AS Date), CAST(1.411898 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5291151d-e166-4c97-a111-4e3d242735b4', 190, CAST(N'2016-12-31' AS Date), CAST(1.436412 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5431b458-fc8c-4435-b997-0f5f012d0585', 190, CAST(N'2017-01-31' AS Date), CAST(1.429805 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'aa94fed8-a585-410b-bfa8-3da50cc10da6', 190, CAST(N'2017-02-28' AS Date), CAST(1.413731 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'eda7563c-dd3a-4b83-9ffa-289c717d63ef', 190, CAST(N'2017-03-31' AS Date), CAST(1.405301 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5188f20e-96b8-4af4-beb8-89f332c7121b', 190, CAST(N'2017-04-30' AS Date), CAST(1.398628 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'bdfdbd88-f322-4bf5-9226-6963af2afc98', 190, CAST(N'2017-05-31' AS Date), CAST(1.394891 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'0bb9b142-d2a0-48e5-816a-24f606b29afe', 190, CAST(N'2017-06-30' AS Date), CAST(1.383778 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5f3ebff3-7c9f-4f19-b7bb-700630d41856', 190, CAST(N'2017-07-31' AS Date), CAST(1.370843 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a9c439f6-c5fa-419c-920e-03adaff2f2ff', 190, CAST(N'2017-08-31' AS Date), CAST(1.360658 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f6830045-8cc2-448a-a802-9f965524a499', 190, CAST(N'2017-09-30' AS Date), CAST(1.349618 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'95318625-2d4c-4e48-aca6-0f7aed519101', 190, CAST(N'2017-10-31' AS Date), CAST(1.360135 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2b5c7131-2a52-4fea-afee-13ce77cba6f4', 190, CAST(N'2017-11-30' AS Date), CAST(1.355848 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'5a069b74-57c2-4d2d-8e7e-ed04632bdb3f', 190, CAST(N'2017-12-31' AS Date), CAST(1.345859 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9f8af51a-9b09-4d48-ae48-bab43f53fe97', 190, CAST(N'2018-01-31' AS Date), CAST(1.321651 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'a463b194-bb63-48ca-9906-05b68995f115', 190, CAST(N'2018-02-28' AS Date), CAST(1.319897 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'615528f1-e354-4957-bdd2-ddf7e830cfe0', 190, CAST(N'2018-03-31' AS Date), CAST(1.315337 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'80cc1bbd-bf6b-4525-864f-e9f879622421', 190, CAST(N'2018-04-30' AS Date), CAST(1.315836 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'efab54a5-175b-48dd-a119-68c207a2989f', 190, CAST(N'2018-05-31' AS Date), CAST(1.338980 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'9067370c-6695-44cb-90b1-ef8d9e864e1f', 190, CAST(N'2018-06-30' AS Date), CAST(1.348166 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8829b37f-282a-4fff-83f1-7f102a7b7fd9', 190, CAST(N'2018-07-31' AS Date), CAST(1.362918 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7714c21c-4e90-46d1-ae02-1e7a2ba998fa', 190, CAST(N'2018-08-31' AS Date), CAST(1.368856 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'244590ca-cce0-4417-854d-e8b5a24cd3a0', 190, CAST(N'2018-09-30' AS Date), CAST(1.371156 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3c05e5c3-a8e9-411b-9890-b16e85f8dc75', 190, CAST(N'2018-10-31' AS Date), CAST(1.379485 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'abe5d2f1-5409-4588-861b-99658b2d8f89', 190, CAST(N'2018-11-30' AS Date), CAST(1.375167 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'd31c88c1-8e26-43ed-9849-5501ae7df4a6', 190, CAST(N'2018-12-31' AS Date), CAST(1.371084 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'4651f96e-ce4f-4de5-9732-79183332a01f', 190, CAST(N'2019-01-31' AS Date), CAST(1.356441 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'3461b940-1ea0-4a0b-96aa-eda4346e50bc', 190, CAST(N'2019-02-28' AS Date), CAST(1.353951 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'312eb562-a673-4207-8c27-fc4fcfc20551', 190, CAST(N'2019-03-31' AS Date), CAST(1.354554 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'b1a2dbea-9940-4c9d-be18-f74a3d7aaf41', 190, CAST(N'2019-04-30' AS Date), CAST(1.356193 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'7e5696d7-7561-4e4a-ad81-79bdcb0961e1', 190, CAST(N'2019-05-31' AS Date), CAST(1.370412 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8d423ad9-def5-4d60-bf86-01956cf7d78f', 190, CAST(N'2019-06-30' AS Date), CAST(1.362506 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'108fa27b-9e60-4d02-b59e-fc9d9d44b8f8', 190, CAST(N'2019-07-31' AS Date), CAST(1.361502 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'75205f64-79b7-4f55-85b1-08da854247eb', 190, CAST(N'2019-08-31' AS Date), CAST(1.384439 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f2b6e1b9-ec0f-43b3-834e-6a0d74d6f6a5', 190, CAST(N'2019-09-30' AS Date), CAST(1.379538 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'e61f16da-1d6e-47a9-b9e0-8500f5c0c1f0', 190, CAST(N'2019-10-31' AS Date), CAST(1.370251 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'8fd32fa8-ab17-438b-804b-76b37b778148', 190, CAST(N'2019-11-30' AS Date), CAST(1.361670 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'712322a1-752d-46fd-a95b-51a984f7b3ef', 190, CAST(N'2019-12-31' AS Date), CAST(1.356504 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'2146d748-2aaf-4f16-9bc7-d30169067926', 190, CAST(N'2020-01-31' AS Date), CAST(1.350979 AS Decimal(18, 6)))
GO
INSERT [dbo].[ExchangeRate] ([ExchangeRateId], [CurrencyId], [Date], [Rate]) VALUES (N'f8a48d8b-4e45-449f-8cee-8fb207dce757', 190, CAST(N'2020-02-29' AS Date), CAST(1.388870 AS Decimal(18, 6)))
GO