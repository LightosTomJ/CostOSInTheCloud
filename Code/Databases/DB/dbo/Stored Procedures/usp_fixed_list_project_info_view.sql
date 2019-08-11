

CREATE PROCEDURE dbo.usp_fixed_list_project_info_view 
@epsCode nvarchar(max) ='',
@groupCodeToUse varchar(255)  = '1' 
      AS
      SET NOCOUNT ON;
      BEGIN
      
declare @databases table
(
    PK   int IDENTITY(1,1), 
    Name    varchar(255)
)

INSERT INTO @databases (Name)

SELECT u.DBNAME FROM PROJECTINFO p join PROJECTURL u on u.PROJECTINFOID= p.PROJECTINFOID where DBSRV=3 AND p.EPSCODE like @epsCode+'%'


declare @result table
(
    PK   int IDENTITY(1,1), 
    DatabaseName    varchar(255),
    ProjectName varchar(255),
    HasGroupCode bit,
    projectType varchar(max),
    projectCode varchar(max),
    projectTitle varchar(max),
    editorid varchar(max)
)


Declare @maxPK int;
Select @maxPK = MAX(PK) From @databases
Declare @pk int;
Set @pk = 1;
      DECLARE @sql2 nvarchar(1000);
    DECLARE @dbName varchar(255);
    DECLARE @prjName nvarchar(MAX);
    DECLARE @out_param nvarchar(MAX);
    DECLARE @sql NVARCHAR(1000);
    DECLARE @out_param2 int;
    DECLARE @groupCodeCount int;
    DECLARE @hasgroupCode bit;
    
    DECLARE @projectType varchar(max);
    DECLARE @projectCode varchar(max);
    DECLARE @projectTitle varchar(max);
    DECLARE @editorid varchar(max);
    
    

While @pk <= @maxPK
Begin
       set @dbName = (SELECT name FROM @databases WHERE PK = @pk);
      
       
         set @projectType =  (SELECT u.TYPE FROM PROJECTINFO p join PROJECTURL u on u.PROJECTINFOID= p.PROJECTINFOID where ( DBSRV=3 AND DBNAME=@dbName) );
       set @projectCode = (SELECT p.CODE FROM PROJECTINFO p join PROJECTURL u on u.PROJECTINFOID= p.PROJECTINFOID where  ( DBSRV=3   AND DBNAME=@dbName));
       set @projectTitle = (SELECT p.TITLE FROM PROJECTINFO p join PROJECTURL u on u.PROJECTINFOID= p.PROJECTINFOID where  ( DBSRV=3   AND DBNAME=@dbName));
       set @editorid = (SELECT u.EDITORID FROM PROJECTINFO p join PROJECTURL u on u.PROJECTINFOID= p.PROJECTINFOID where  ( DBSRV=3   AND DBNAME=@dbName));
       
      
       set @sql = '(SELECT @out_param = cast(PVAL as nvarchar(MAX)) FROM '+@dbName+'.[dbo].[PRJPROP] WHERE PKEY LIKE ''project.name'')';
         
         IF @groupCodeToUse like '1'
         BEGIN
            set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT GROUPCODE as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where GROUPCODE IS NOT NULL AND GROUPCODE != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY GROUPCODE ) subQuery )';
         END 
         IF @groupCodeToUse like '2'
         BEGIN
            set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT GEKCODE as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where GEKCODE IS NOT NULL AND GEKCODE != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY GEKCODE ) subQuery )'; 
         END 
         IF @groupCodeToUse like '3'
         BEGIN
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT EXTRACODE1 as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where EXTRACODE1 IS NOT NULL AND EXTRACODE1 != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY EXTRACODE1 ) subQuery )';
         
         END 
         IF @groupCodeToUse like '4'
         BEGIN
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT EXTRACODE2 as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where EXTRACODE2 IS NOT NULL AND EXTRACODE2 != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY EXTRACODE2 ) subQuery )';
         
         END 
         IF @groupCodeToUse like '5'
         BEGIN
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT EXTRACODE3 as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where EXTRACODE3 IS NOT NULL AND EXTRACODE3 != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY EXTRACODE3 ) subQuery )';
         
         END 
         IF @groupCodeToUse like '6'
         BEGIN
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT EXTRACODE4 as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where EXTRACODE4 IS NOT NULL AND EXTRACODE4 != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY EXTRACODE4 ) subQuery )';
         
         END 
         IF @groupCodeToUse like '7'
         BEGIN
         
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT EXTRACODE5 as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where EXTRACODE5 IS NOT NULL AND EXTRACODE3 != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY EXTRACODE5 ) subQuery )';
         END 
         IF @groupCodeToUse like '8'
         BEGIN
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT EXTRACODE6 as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where EXTRACODE6 IS NOT NULL AND EXTRACODE6 != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY EXTRACODE6 ) subQuery )';
         
         END 
         IF @groupCodeToUse like '9'
         BEGIN
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT EXTRACODE7 as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where EXTRACODE7 IS NOT NULL AND EXTRACODE7 != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY EXTRACODE7 ) subQuery )';
         
         END 
         IF @groupCodeToUse like '10'
         BEGIN
         
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT EXTRACODE10 as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where EXTRACODE10 IS NOT NULL AND EXTRACODE10 != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY EXTRACODE10 ) subQuery )';
         END 
         
         IF @groupCodeToUse like '-1'
         BEGIN
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT WBSCODE as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where WBSCODE IS NOT NULL AND WBSCODE != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY WBSCODE ) subQuery )';
         
         END 
         
         IF @groupCodeToUse like '-2'
         
         
         BEGIN
         set @sql2 = ' (SELECT @out_param2 = COUNT(*) FROM (SELECT WBSCODE2 as extraCode2 FROM '+@dbName+'.[dbo].[BOQITEM] where WBSCODE2 IS NOT NULL AND WBSCODE2 != '+ CHAR(39)+''+ CHAR(39)+' GROUP BY WBSCODE2 ) subQuery )';
         
         END 
         
         
         EXEC sp_executesql @sql2,
                              N'@out_param2 nvarchar(MAX) OUTPUT',
                              @out_param2=@groupCodeCount OUTPUT
       EXEC sp_executesql @sql,
                   N'@out_param nvarchar(MAX) OUTPUT',
                     @out_param=@prjName OUTPUT
            
            IF (@groupCodeCount=0)
                  SET @hasgroupCode=0;
            ELSE
                  SET @hasgroupCode=1;
            
    INSERT INTO @result (DatabaseName, ProjectName ,HasGroupCode ,projectType,projectCode,projectTitle,editorid) 
       values (@dbName, @prjName,@hasgroupCode,@projectType,@projectCode,@projectTitle,@editorid);

    Select @pk = @pk + 1;
End

Select *
    From @result
    END
