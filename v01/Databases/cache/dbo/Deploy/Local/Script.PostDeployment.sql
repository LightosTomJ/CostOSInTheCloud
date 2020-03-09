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


:r ..\..\Data\Country.sql
:r ..\..\Data\Currency.sql
:r ..\..\Data\ExchangeRate.sql
:r ..\..\Data\MaterialGenre.sql
:r ..\..\Data\MaterialCategory.sql
:r ..\..\Data\Material.sql
:r ..\..\Data\MaterialIndexRate.sql
:r ..\..\Data\Inflation.sql