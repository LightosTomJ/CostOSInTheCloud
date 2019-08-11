
Create Function dbo.unf_remove_non_alphanum_characters(@Temp VarChar(max))
Returns VarChar(max)
AS
Begin

    Declare @KeepValues as varchar(50)
    Set @KeepValues = '%[^a-z]%'
    While PATINDEX(@KeepValues, @Temp) > 0
        Set @Temp = Stuff(@Temp, PATINDEX(@KeepValues, @Temp), 1, '')

    Return @Temp
End
