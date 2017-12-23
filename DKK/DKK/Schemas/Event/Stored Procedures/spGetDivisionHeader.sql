CREATE PROCEDURE Event.spGetDivisionHeader
	@EventId INT
	,@MatchTypeName NVARCHAR(30) = NULL
	,@IsSpecialConsideration BIT = NULL
AS
DECLARE @sql NVARCHAR(4000)
DECLARE @params NVARCHAR(4000)

SELECT @sql = N'SELECT dh.MatchDisplayId
	  ,dh.SubDivisionId
	  ,dh.MinimumWeight_lb
	  ,dh.MaximumWeight_lb
	  ,dh.WeightClass
	  ,dh.Gender
	  ,dh.MinimumBelt
	  ,dh.MaximumBelt
	  ,dh.MinimumAge
	  ,dh.MaximumAge 
	  ,dh.MatchTypeName
FROM [Event].[vwDivisionHeader] dh
WHERE dh.EventId = @EventId
'
	,@params = N'@EventId INT'

IF @MatchTypeName IS NOT NULL
BEGIN
	SELECT @sql = @sql + '	AND dh.MatchTypeName = @MatchTypeName
'
		,@params = @params + N',@MatchTypeName NVARCHAR(30)'
END

IF @IsSpecialConsideration IS NOT NULL
BEGIN
	SELECT @sql = @sql + '	AND dh.IsSpecialConsideration = @IsSpecialConsideration
'
		,@params = @params + N',@IsSpecialConsideration BIT'
END

IF @MatchTypeName IS NOT NULL AND @IsSpecialConsideration IS NOT NULL
BEGIN
	PRINT @sql;
	EXEC sp_executesql @sql, @params, @EventId = @EventId, @MatchTypeName = @MatchTypeName, @IsSpecialConsideration = @IsSpecialConsideration
	RETURN;
END
IF @MatchTypeName IS NOT NULL
BEGIN
	PRINT @sql;
	EXEC sp_executesql @sql, @params, @EventId = @EventId, @MatchTypeName = @MatchTypeName
	RETURN;
END

PRINT @sql;
EXEC sp_executesql @sql, @params, @EventId = @EventId

GO
