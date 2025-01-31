﻿/*
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

:r ..\..\Data\Equipment.sql
:r ..\..\Data\Labor.sql
:r ..\..\Data\Materials.sql
:r ..\..\Data\Subcontractor.sql
:r ..\..\Data\ProjectEPS.sql
:r ..\..\Data\ProjectInfo.sql
:r ..\..\Data\ProjectURL.sql