

CREATE Function dbo.ufn_split_string 
(
    @List Varchar(max)
)
RETURNS @Table TABLE (ColumnData  nvarchar(max),Row INT )
AS
BEGIN
 DECLARE @row int;
 SET @row =0;
    IF RIGHT(@List, 1) <> ','
    SELECT @List = @List + ','

    DECLARE @Pos    BIGINT,
            @OldPos BIGINT
    SELECT  @Pos    = 1,
            @OldPos = 1

    WHILE   @Pos < LEN(@List)
        BEGIN
            SELECT  @Pos = CHARINDEX(',', @List, @OldPos)
            INSERT INTO @Table VALUES( (SELECT  LTRIM(RTRIM(SUBSTRING(@List, @OldPos, @Pos - @OldPos))) Col001) ,@row );
			SET @row =@row +1
            SELECT  @OldPos = @Pos + 1
        END

    RETURN
END