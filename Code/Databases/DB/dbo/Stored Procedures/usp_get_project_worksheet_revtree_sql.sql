


CREATE PROCEDURE dbo.usp_get_project_worksheet_revtree_sql
@prjCode varchar( 255 ),
@ResultSqlQuery nvarchar(max) ='' OUTPUT 

AS
SET NOCOUNT ON;

declare @sqlQuery nvarchar( MAX );
declare @au_id varchar( 255 )

select @au_id = min( url.DBNAME )  from PROJECTURL url LEFT JOIN PROJECTINFO pi on pi.PROJECTINFOID =url.PROJECTINFOID WHERE url.DBSRV = 3 and pi.CODE like @prjCode;

IF @au_id IS NOT NULL 
begin
   set @sqlQuery = 'SELECT '''+@au_id +''' as DBNAME, w.CODE AS WSCODE, w.TITLE AS WSTITLE, 
                    COUNT(b.BOQITEMID) AS ITEMSINUSE, 
                    SUM(b.TOTALCOST) AS TOTALCOST, 
                               SUM(b.OFFPRICE) AS OFFEREDPRICE, 
                               SUM(b.MANHOURS) AS TOTALMANHOURS,
                               SUM(b.CUSCUMRATE1) AS CUSTOMCUM1,
                               SUM(b.CUSCUMRATE2) AS CUSTOMCUM2,
                               SUM(b.CUSCUMRATE3) AS CUSTOMCUM3,
                               SUM(b.CUSCUMRATE4) AS CUSTOMCUM4,
                               SUM(b.CUSCUMRATE5) AS CUSTOMCUM5,
                             SUM(b.CUSCUMRATE6) AS CUSTOMCUM6,
                               SUM(b.CUSCUMRATE7) AS CUSTOMCUM7,
                               SUM(b.CUSCUMRATE8) AS CUSTOMCUM8,
                               SUM(b.CUSCUMRATE9) AS CUSTOMCUM9,
                               SUM(b.CUSCUMRATE10) AS CUSTOMCUM10                                                        
                              from '+@au_id+'.dbo.WSREVISION as w LEFT JOIN '+@au_id+'.dbo.BOQITEM as b ON b.PUBLISHEDREVISIONCODE = w.CODE group by w.CODE, w.TITLE';
end

while @au_id is not null
begin
    --select * from PROJECTURL url LEFT JOIN PROJECTINFO pi on pi.PROJECTINFOID =url.PROJECTINFOID WHERE dbname = @au_id;
    --select * from authors where au_id = @au_id
       
       select @au_id = min( url.DBNAME )  from PROJECTURL url LEFT JOIN PROJECTINFO pi on pi.PROJECTINFOID =url.PROJECTINFOID WHERE url.DBSRV = 3 and pi.CODE like @prjCode AND DBNAME > @au_id;

       IF @au_id IS NOT NULL 
       BEGIN
              set @sqlQuery = @sqlQuery + ' union all SELECT '''+@au_id +''' as DBNAME, w.CODE AS WSCODE, w.TITLE AS WSTITLE, 
                                         COUNT(b.BOQITEMID) AS ITEMSINUSE, 
                        SUM(b.TOTALCOST) AS TOTALCOST, 
                                   SUM(b.OFFPRICE) AS OFFEREDPRICE, 
                                         SUM(b.MANHOURS) AS TOTALMANHOURS,
                                         SUM(b.CUSCUMRATE1) AS CUSTOMCUM1,
                                         SUM(b.CUSCUMRATE2) AS CUSTOMCUM2,
                                         SUM(b.CUSCUMRATE3) AS CUSTOMCUM3,
                                         SUM(b.CUSCUMRATE4) AS CUSTOMCUM4,
                                         SUM(b.CUSCUMRATE5) AS CUSTOMCUM5,
                                         SUM(b.CUSCUMRATE6) AS CUSTOMCUM6,
                                         SUM(b.CUSCUMRATE7) AS CUSTOMCUM7,
                                         SUM(b.CUSCUMRATE8) AS CUSTOMCUM8,
                                         SUM(b.CUSCUMRATE9) AS CUSTOMCUM9,
                                         SUM(b.CUSCUMRATE10) AS CUSTOMCUM10                                                       
                              from '+@au_id+'.dbo.WSREVISION as w LEFT JOIN '+@au_id+'.dbo.BOQITEM as b ON b.PUBLISHEDREVISIONCODE = w.CODE group by w.CODE, w.TITLE';
       END
end

IF  @sqlQuery IS not NULL 
begin
SET @sqlQuery = '
       SELECT * FROM (
       SELECT 
              CAST(pi.PROJECTINFOID AS VARCHAR(255)) as ID, 
              1 AS LEVEL, 
              pi.CODE AS PROJECTCODE,
              pi.TITLE AS PROJECTTITLE,  
              NULL AS REVISION,
              NULL AS DATABASENAME,
              NULL AS DEFAULTPROJECT,
              NULL AS ITEMSINUSE,
              NULL AS WSCODE,
              NULL AS WSREVISION,
              NULL AS TOTALCOST,
              NULL AS OFFEREDPRICE,
              NULL AS TOTALMANHOURS,
              NULL AS CUSTOMCUM1,
              NULL AS CUSTOMCUM2,
              NULL AS CUSTOMCUM3,
              NULL AS CUSTOMCUM4,
              NULL AS CUSTOMCUM5,
              NULL AS CUSTOMCUM6,
              NULL AS CUSTOMCUM7,
              NULL AS CUSTOMCUM8,
              NULL AS CUSTOMCUM9,
              NULL AS CUSTOMCUM10
       FROM PROJECTINFO as pi 
       UNION ALL
       SELECT 
              CAST(i.PROJECTINFOID AS VARCHAR(255))+''_''+CAST(u.PROJECTURLID AS VARCHAR(255)) as ID,
              2 AS LEVEL,
              i.CODE AS PROJECTCOCDE, 
              i.TITLE AS PROJECTTITLE,  
              u.RVSON AS REVISION,
              u.DBNAME AS DATABASENAME, 
              u.DEFREV AS DEFAULTPROJECT,
              NULL AS ITEMSINUSE,
              NULL AS WSCODE,
              NULL AS WSREVISION, 
              SUM(s.TOTALCOST) AS TOTALCOST,
              SUM(s.OFFEREDPRICE) AS OFFEREDPRICE,
              SUM(s.TOTALMANHOURS) AS TOTALMANHOURS,
              SUM(s.CUSTOMCUM1) AS CUSTOMCUM1,
              SUM(s.CUSTOMCUM2) AS CUSTOMCUM2,
              SUM(s.CUSTOMCUM3) AS CUSTOMCUM3,
              SUM(s.CUSTOMCUM4) AS CUSTOMCUM4,
              SUM(s.CUSTOMCUM5) AS CUSTOMCUM5,
              SUM(s.CUSTOMCUM6) AS CUSTOMCUM6,
              SUM(s.CUSTOMCUM7) AS CUSTOMCUM7,
              SUM(s.CUSTOMCUM8) AS CUSTOMCUM8,
              SUM(s.CUSTOMCUM9) AS CUSTOMCUM9,
              SUM(s.CUSTOMCUM10) AS CUSTOMCUM10

       FROM PROJECTURL u LEFT JOIN PROJECTINFO i ON u.PROJECTINFOID = i.PROJECTINFOID LEFT JOIN ('+@sqlQuery+') s ON u.DBNAME = s.DBNAME WHERE u.DBSRV = 3 GROUP BY i.PROJECTINFOID, u.PROJECTURLID, u.DEFREV, i.CODE, i.TITLE, u.RVSON, u.DBNAME
       UNION ALL
       SELECT 
              CAST(i.PROJECTINFOID AS VARCHAR(255))+''_''+CAST(u.PROJECTURLID AS VARCHAR(255))+''_''+s.WSCODE as ID,
              3 AS LEVEL,
              i.CODE AS PROJECTCOCDE, 
              i.TITLE AS PROJECTTITLE,  
              u.RVSON AS REVISION,
              u.DBNAME AS DATABASENAME, 
              u.DEFREV AS DEFAULTPROJECT,
              s.ITEMSINUSE AS ITEMSINUSE,
              s.WSCODE AS WSCODE,
              s.WSTITLE AS WSREVISION,
              s.TOTALCOST AS TOTALCOST,
              s.OFFEREDPRICE AS OFFEREDPRICE,
              s.TOTALMANHOURS AS TOTALMANHOURS,
              s.CUSTOMCUM1 AS CUSTOMCUM1,
              s.CUSTOMCUM2 AS CUSTOMCUM2,
              s.CUSTOMCUM3 AS CUSTOMCUM3,
              s.CUSTOMCUM4 AS CUSTOMCUM4,
              s.CUSTOMCUM5 AS CUSTOMCUM5,
              s.CUSTOMCUM6 AS CUSTOMCUM6,
              s.CUSTOMCUM7 AS CUSTOMCUM7,
              s.CUSTOMCUM8 AS CUSTOMCUM8,
              s.CUSTOMCUM9 AS CUSTOMCUM9,
              s.CUSTOMCUM10 AS CUSTOMCUM10
       FROM PROJECTURL u LEFT JOIN PROJECTINFO i ON u.PROJECTINFOID = i.PROJECTINFOID LEFT JOIN ('+@sqlQuery+') s ON u.DBNAME = s.DBNAME WHERE u.DBSRV = 3
       ) AS z WHERE z.PROJECTCODE in ('''+@prjCode+''')';

       SET @sqlQuery = '
           select
                (case WHEN k.LEVEL = 1 THEN k.PROJECTCODE+'' - ''+k.PROJECTTITLE ELSE '''' END) AS Project,
                (case WHEN k.LEVEL = 2 THEN k.PROJECTCODE+'' - ''+k.REVISION ELSE '''' END) AS Revision,
                (case WHEN k.LEVEL = 3 THEN k.WSCODE+'' - ''+k.WSREVISION ELSE '''' END) AS WorksheetRevision,
                (case WHEN k.DEFAULTPROJECT = 1 THEN ''Yes'' ELSE '''' END) As DefaultRevision,
                (case WHEN k.LEVEL = 3 THEN CAST (k.ITEMSINUSE AS VARCHAR(10)) ELSE '''' END) AS ItemsInUse,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.TOTALCOST ELSE NULL END) AS TotalWorksheetCost, 
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.OFFEREDPRICE ELSE NULL END) AS TotalWorksheetOfferPrice, 
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.TOTALMANHOURS ELSE NULL END) AS TotalWorksheetManhours,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM1 ELSE NULL END) AS TotalCumDecimal1,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM2 ELSE NULL END) AS TotalCumDecimal2,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM3 ELSE NULL END) AS TotalCumDecimal3,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM4 ELSE NULL END) AS TotalCumDecimal4,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM5 ELSE NULL END) AS TotalCumDecimal5,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM6 ELSE NULL END) AS TotalCumDecimal6,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM7 ELSE NULL END) AS TotalCumDecimal7,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM8 ELSE NULL END) AS TotalCumDecimal8,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM9 ELSE NULL END) AS TotalCumDecimal9,
                (case WHEN k.LEVEL = 3 OR k.LEVEL = 2 THEN k.CUSTOMCUM10 ELSE NULL END) AS TotalCumDecimal10

              FROM ('+@sqlQuery+') as k ORDER BY k.ID;';
end

IF @sqlQuery is NULL
begin

SET @sqlQuery  = 'select 
                (case WHEN k.LEVEL = 1 THEN k.PROJECTCODE+'+CHAR(39)+'-'+CHAR(39)+'+k.PROJECTTITLE ELSE '+CHAR(39)+''+CHAR(39)+' END) AS Project,
                (case WHEN k.LEVEL = 2 THEN k.PROJECTCODE+'+CHAR(39)+'-'+CHAR(39)+'+k.REVISION ELSE '+CHAR(39)+''+CHAR(39)+' END) AS Revision,
                (case WHEN k.LEVEL = 3 THEN k.WSCODE+'+CHAR(39)+'-'+CHAR(39)+'+k.WSREVISION ELSE '+CHAR(39)+''+CHAR(39)+' END) AS WorksheetRevision
                from (

SELECT * FROM (
SELECT 
       CAST(pi.PROJECTINFOID AS VARCHAR(255)) as ID, 
       1 AS LEVEL, 
       pi.CODE AS PROJECTCODE,
       pi.TITLE AS PROJECTTITLE,  
       NULL AS REVISION,
       NULL AS DATABASENAME,
       NULL AS WSCODE,
       NULL AS WSREVISION
FROM PROJECTINFO as pi 
UNION ALL
SELECT 
    CAST(i.PROJECTINFOID AS VARCHAR(255))+'+CHAR(39)+'_'+CHAR(39)+'+CAST(u.PROJECTURLID AS VARCHAR(255)) as ID,
    2 AS LEVEL,
    i.CODE AS PROJECTCOCDE, 
    i.TITLE AS PROJECTTITLE,  
       u.RVSON AS REVISION,
    u.DBNAME AS DATABASENAME, 
       NULL AS WSCODE,
       NULL AS WSREVISION 
FROM PROJECTURL u JOIN PROJECTINFO i ON u.PROJECTINFOID = i.PROJECTINFOID WHERE u.DBSRV = 3
) AS z WHERE z.PROJECTCODE in ('+CHAR(39)+@prjCode+CHAR(39)+')
) as k ORDER BY k.ID'
END

SET @ResultSqlQuery = @sqlQuery

RETURN


