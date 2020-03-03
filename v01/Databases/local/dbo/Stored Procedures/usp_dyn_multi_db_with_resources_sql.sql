

CREATE PROCEDURE dbo.usp_dyn_multi_db_with_resources_sql 
@ListOfProjects nvarchar(max),
@LineItemMaterials bit = 0 ,
@LineItemEquipment bit = 0 ,
@LineItemLabor bit = 0 ,
@LineItemSubcontructor bit = 0 ,
@LineItemConsumable bit = 0,
@Materials bit = 0 ,
@Equipment bit = 0 ,
@Labor bit = 0 ,
@Subcontructor bit = 0 ,
@Consumable bit = 0,
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
				SET	@CurrentProjectId =  ( SELECT CAST(ColumnData AS BigInt) FROM dbo.ufn_split_string(@ListOfProjects) where row = @Counter )
				
				--PRINT @CurrentProjectName
				
				IF @Counter <> 0
				BEGIN
				SET @ResultString = @ResultString + +' UNION ALL ' 
				END
							
				
				EXECUTE  dbo.usp_dyn_boq_with_resources 
				@PrjId = @CurrentProjectId ,
				@Materials =@Materials,
				@Equipment =@Equipment ,
				@Labor =@Labor,
				@Subcontructor =@Subcontructor,
				@Consumable =@Consumable,
				@SqlQuery = @Temp OUTPUT;

		
				SET @ResultString = @ResultString + ' (' + @Temp  +') '
				
				SET  @Counter = @Counter+1 

			END
			SET @ResultSqlQuery = @ResultString
			
			RETURN
			--EXECUTE sp_executesql @ResultString	