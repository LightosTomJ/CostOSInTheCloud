

CREATE PROCEDURE dbo.usp_dyn_multibase_with_layouts 
@ListOfProjectsToSelect nvarchar(max),
@wbs1Flag bit = 0,
@wbs2Flag bit =0 ,
@groupCode1Flag bit =0 ,
@groupCode2Flag bit =0 ,
@groupCode3Flag bit =0,
@groupCode4Flag bit =0 ,
@groupCode5Flag bit =0,
@groupCode6Flag bit =0 ,
@groupCode7Flag bit =0,
@groupCode8Flag bit =0,
@groupCode9Flag bit =0,
@ResultSqlQueryWithLayout nvarchar(max) ='' OUTPUT 
AS
SET NOCOUNT ON;
DECLARE @temp1 varchar(max)
DECLARE @res nvarchar(max)
DECLARE @sub nvarchar(max)
DECLARE @fields nvarchar(max)
DECLARE @temp2 nvarchar(max)
DECLARE @tempIndex INT


SET @temp1= @ListOfProjectsToSelect
     EXEC dbo.usp_dyn_multi_db_sql @ListOfProjects = @temp1,
@wbs1 =@wbs1Flag,
@wbs2 =@wbs2Flag,
@groupCode1 =@groupCode1Flag,
@groupCode2 =@groupCode2Flag,
@groupCode3 =@groupCode3Flag ,
@groupCode4 =@groupCode4Flag,
@groupCode5 =@groupCode5Flag,
@groupCode6 =@groupCode6Flag ,
@groupCode7 =@groupCode7Flag,
@groupCode8 =@groupCode8Flag,
@groupCode9 =@groupCode9Flag,
@ResultSqlQuery = @res OUTPUT

--EXECUTE sp_executesql @res
--parse the results


DECLARE @displayName VARCHAR(max);
DECLARE @hibernateName VARCHAR(max);
DECLARE @columnName VARCHAR(max);
DECLARE @fieldName VARCHAR(max);

DECLARE my_Cursor CURSOR LOCAL FAST_FORWARD FOR ( SELECT [NAME], [DISPLAYNAME], [FIELDNAME], [COLUMNNAME]
	FROM FIELDCUSTOM INNER JOIN [BOQITEMMETADATA] on [FIELDCUSTOM].[NAME] = [BOQITEMMETADATA].[FIELDKEY] WHERE [FIELDCUSTOM].[DISPLAYNAME] IS NOT NULL);
OPEN my_Cursor ;
FETCH NEXT FROM my_Cursor into @HibernateName,@DisplayName,@fieldName,@columnName ;

WHILE @@FETCH_STATUS = 0 
 
BEGIN
DECLARE @Temp nvarchar(max)
SET @Temp = @DisplayName
SET @temp2 = dbo.unf_remove_non_alphanum_characters(@Temp)
--SET @tempIndex = 0 

SET @res  = replace(@res , 'AS '+@fieldName , 'AS '+@temp2)

FETCH NEXT FROM my_Cursor into @HibernateName,@DisplayName,@fieldName,@columnName ;

END
 
CLOSE my_Cursor;
DEALLOCATE my_Cursor;
SET @ResultSqlQueryWithLayout = @res
