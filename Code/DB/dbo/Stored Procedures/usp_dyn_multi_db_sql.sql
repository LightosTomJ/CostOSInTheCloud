

CREATE PROCEDURE dbo.usp_dyn_multi_db_sql 
@ListOfProjects nvarchar(max),
@wbs1 bit = 0,
@wbs2 bit =0 ,
@groupCode1 bit =0 ,
@groupCode2 bit =0 ,
@groupCode3 bit =0,
@groupCode4 bit =0 ,
@groupCode5 bit =0,
@groupCode6 bit =0 ,
@groupCode7 bit =0,
@groupCode8 bit =0,
@groupCode9 bit =0,
@ResultSqlQuery nvarchar(max) ='' OUTPUT 



	AS
	SET NOCOUNT ON;
	DECLARE @CurrentProjectId nvarchar(max)
	DECLARE @TotalCount INT;
	DECLARE @Counter INT;
	DECLARE @ResultString nvarchar(max);
	DECLARE @Temp nvarchar(max);

	
	SET @Counter = 0;
	SET @ResultString = '';
	SET @TotalCount = 0;
	SET @TotalCount = ( SELECT count(*) FROM dbo.ufn_split_string(@ListOfProjects) ) ;
		WHILE @Counter < @TotalCount
			BEGIN
				SET	@CurrentProjectId =  ( SELECT CAST(ColumnData AS BigInt)FROM dbo.ufn_split_string(@ListOfProjects) where row = @Counter )
				
				--PRINT @CurrentProjectName
				
				IF @Counter <> 0
				BEGIN
				SET @ResultString = @ResultString + +' UNION ALL ' 
				END
							
				
				EXECUTE  dbo.usp_dyn_find_boq_item_sql @PrjId = @CurrentProjectId ,
				@wbs1 = @wbs1,
				@wbs2 = @wbs2 ,
				@groupCode1 =@groupCode1 ,
				@groupCode2 =@groupCode2 ,
				@groupCode3 =@groupCode3 ,
				@groupCode4 =@groupCode4,
				@groupCode5 =@groupCode5 ,
				@groupCode6 =@groupCode6,
				@groupCode7 =@groupCode7,
				@groupCode8 =@groupCode8,
				@groupCode9 =@groupCode9, 
				@SqlQuery = @Temp OUTPUT;

				
				SET @ResultString = @ResultString + ' (' + @Temp  +') '
				
				SET  @Counter = @Counter+1 

			END
			SET @ResultSqlQuery = @ResultString
			
			RETURN
			--EXECUTE sp_executesql @ResultString

			

