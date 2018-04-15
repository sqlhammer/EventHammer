--https://www.red-gate.com/simple-talk/sql/t-sql-programming/consuming-json-strings-in-sql-server/
CREATE FUNCTION Stage.parseJSON ( @JSON NVARCHAR(MAX))
RETURNS @hierarchy TABLE
(
	element_id INT IDENTITY(1, 1) NOT NULL /* internal surrogate primary key gives the order of parsing and the list order */
	,sequenceNo [INT] NULL /* the place in the sequence for the element */
	,parent_ID INT /* if the element has a parent then it is in this column. The document is the ultimate parent, so you can get the structure from recursing from the document */
	,Object_ID INT /* each list or object has an object id. This ties all elements to a parent. Lists are treated as objects here */
	,NAME NVARCHAR(2000)/* the name of the object */
	,StringValue NVARCHAR(MAX) NOT NULL /*the string representation of the value of the element. */
	,ValueType VARCHAR(10) NOT NULL /* the declared type of the value represented as a string in StringValue*/
)
AS
BEGIN
	DECLARE
		@FirstObject INT --the index of the first open bracket found in the JSON string
		,@OpenDelimiter INT --the index of the next open bracket found in the JSON string
		,@NextOpenDelimiter INT --the index of subsequent open bracket found in the JSON string
		,@NextCloseDelimiter INT --the index of subsequent close bracket found in the JSON string
		,@Type NVARCHAR(10) --whether it denotes an object or an array
		,@NextCloseDelimiterChar CHAR(1) --either a '}' or a ']'
		,@Contents NVARCHAR(MAX) --the unparsed contents of the bracketed expression
		,@Start INT --index of the start of the token that you are parsing
		,@end INT --index of the end of the token that you are parsing
		,@param INT --the parameter at the end of the next Object/Array token
		,@EndOfName INT --the index of the start of the parameter at end of Object/Array token
		,@token NVARCHAR(200) --either a string or object
		,@value NVARCHAR(MAX) -- the value as a string
		,@SequenceNo INT -- the sequence number within a list
		,@name NVARCHAR(200) --the name as a string
		,@parent_ID INT --the next parent ID to allocate
		,@lenJSON INT --the current length of the JSON String
		,@characters NCHAR(36) --used to convert hex to decimal
		,@result BIGINT --the value of the hex symbol being parsed
		,@index SMALLINT --used for parsing the hex value
		,@Escape INT; --the index of the next escape character


	DECLARE @Strings TABLE /* in this temporary table we keep all strings, even the names of the elements, since they are 'escaped' in a different way, and may contain, unescaped, brackets denoting objects or lists. These are replaced in the JSON string by tokens representing the string */
	( String_ID INT IDENTITY(1, 1), StringValue NVARCHAR(MAX));


	SELECT --initialise the characters to convert hex to ascii
		@characters = N'0123456789abcdefghijklmnopqrstuvwxyz'
		,@SequenceNo = 0 --set the sequence no. to something sensible.
		/* firstly we process all strings. This is done because [{} and ] aren't escaped in strings, which complicates an iterative parse. */
		,@parent_ID = 0;


	WHILE 1 = 1 --forever until there is nothing more to do
	BEGIN
		SELECT @Start = PATINDEX('%[^a-zA-Z]["]%', @JSON COLLATE SQL_Latin1_General_CP850_BIN); --next delimited string


		IF @Start = 0
			BREAK; --no more so drop through the WHILE loop


		IF SUBSTRING(@JSON, @Start + 1, 1) = '"'
		BEGIN --Delimited Name
			SET @Start = @Start + 1;
			SET @end = PATINDEX(
								   '%[^\]["]%'
								   ,RIGHT(@JSON, LEN(@JSON + '|') - @Start)COLLATE SQL_Latin1_General_CP850_BIN
							   );
		END;


		IF @end = 0 --no end delimiter to last string
			BREAK; --no more


		SELECT @token = SUBSTRING(@JSON, @Start + 1, @end - 1);


		--now put in the escaped control characters
		SELECT @token = REPLACE(@token, FromString, ToString)
		FROM
		(
			SELECT
				'\"' AS FromString
				,'"' AS ToString
			UNION ALL
			SELECT
				'\\'
				,'\'
			UNION ALL
			SELECT
				'\/'
				,'/'
			UNION ALL
			SELECT
				'\b'
				,CHAR(08)
			UNION ALL
			SELECT
				'\f'
				,CHAR(12)
			UNION ALL
			SELECT
				'\n'
				,CHAR(10)
			UNION ALL
			SELECT
				'\r'
				,CHAR(13)
			UNION ALL
			SELECT
				'\t'
				,CHAR(09)
		) substitutions;


		SELECT
			@result = 0
			,@Escape = 1;


		--Begin to take out any hex escape codes
		WHILE @Escape > 0
		BEGIN
			SELECT
				@index = 0
				--find the next hex escape sequence
				,@Escape = PATINDEX('%\x[0-9a-f][0-9a-f][0-9a-f][0-9a-f]%', @token COLLATE SQL_Latin1_General_CP850_BIN);


			IF @Escape > 0 --if there is one
			BEGIN
				WHILE @index < 4 --there are always four digits to a \x sequence   
				BEGIN
					SELECT --determine its value
						@result = @result + POWER(16, @index)
								  * ( CHARINDEX(SUBSTRING(@token, @Escape + 2 + 3 - @index, 1), @characters) - 1 )
						,@index = @index + 1;
				END;


				-- and replace the hex sequence by its unicode value
				SELECT @token = STUFF(@token, @Escape, 6, NCHAR(@result));
			END;
		END;


		--now store the string away 
		INSERT INTO @Strings ( StringValue )
		SELECT @token;


		-- and replace the string with a token
		SELECT @JSON = STUFF(@JSON, @Start, @end + 1, '@string' + CONVERT(NVARCHAR(5), @@IDENTITY));
	END;


	-- all strings are now removed. Now we find the first leaf.  
	WHILE 1 = 1 --forever until there is nothing more to do
	BEGIN
		SELECT @parent_ID = @parent_ID + 1;


		--find the first object or list by looking for the open bracket
		SELECT @FirstObject = PATINDEX('%[{[[]%', @JSON COLLATE SQL_Latin1_General_CP850_BIN); --object or array


		IF @FirstObject = 0
			BREAK;


		IF ( SUBSTRING(@JSON, @FirstObject, 1) = '{' )
			SELECT
				@NextCloseDelimiterChar = '}'
				,@Type = 'object';
		ELSE
			SELECT
				@NextCloseDelimiterChar = ']'
				,@Type = 'array';


		SELECT @OpenDelimiter = @FirstObject;


		WHILE 1 = 1 --find the innermost object or list...
		BEGIN
			SELECT @lenJSON = LEN(@JSON + '|') - 1;


			--find the matching close-delimiter proceeding after the open-delimiter
			SELECT @NextCloseDelimiter = CHARINDEX(@NextCloseDelimiterChar, @JSON, @OpenDelimiter + 1);


			--is there an intervening open-delimiter of either type
			SELECT
				@NextOpenDelimiter = PATINDEX(
												 '%[{[[]%'
												 ,RIGHT(@JSON, @lenJSON - @OpenDelimiter)COLLATE SQL_Latin1_General_CP850_BIN
											 ); --object


			IF @NextOpenDelimiter = 0
				BREAK;


			SELECT @NextOpenDelimiter = @NextOpenDelimiter + @OpenDelimiter;


			IF @NextCloseDelimiter < @NextOpenDelimiter
				BREAK;


			IF SUBSTRING(@JSON, @NextOpenDelimiter, 1) = '{'
				SELECT
					@NextCloseDelimiterChar = '}'
					,@Type = 'object';
			ELSE
				SELECT
					@NextCloseDelimiterChar = ']'
					,@Type = 'array';


			SELECT @OpenDelimiter = @NextOpenDelimiter;
		END;


		---and parse out the list or name/value pairs
		SELECT @Contents = SUBSTRING(@JSON, @OpenDelimiter + 1, @NextCloseDelimiter - @OpenDelimiter - 1);


		SELECT
			@JSON = STUFF(
							 @JSON
							 ,@OpenDelimiter
							 ,@NextCloseDelimiter - @OpenDelimiter + 1
							 ,'@' + @Type + CONVERT(NVARCHAR(5), @parent_ID)
						 );


		WHILE ( PATINDEX('%[A-Za-z0-9@+.e]%', @Contents COLLATE SQL_Latin1_General_CP850_BIN)) <> 0
		BEGIN
			IF @Type = 'Object' --it will be a 0-n list containing a string followed by a string, number,boolean, or null
			BEGIN
				SELECT
					@SequenceNo = 0
					,@end = CHARINDEX(':', ' ' + @Contents); --if there is anything, it will be a string-based name.


				SELECT @Start = PATINDEX('%[^A-Za-z@][@]%', ' ' + @Contents COLLATE SQL_Latin1_General_CP850_BIN); --AAAAAAAA


				SELECT
					@token = SUBSTRING(' ' + @Contents, @Start + 1, @end - @Start - 1)
					,@EndOfName = PATINDEX('%[0-9]%', @token COLLATE SQL_Latin1_General_CP850_BIN)
					,@param = RIGHT(@token, LEN(@token) - @EndOfName + 1);


				SELECT
					@token = LEFT(@token, @EndOfName - 1)
					,@Contents = RIGHT(' ' + @Contents, LEN(' ' + @Contents + '|') - @end - 1);


				SELECT @name = StringValue
				FROM @Strings
				WHERE String_ID = @param; --fetch the name
			END;
			ELSE
				SELECT
					@name = NULL
					,@SequenceNo = @SequenceNo + 1;


			SELECT @end = CHARINDEX(',', @Contents); -- a string-token, object-token, list-token, number,boolean, or null


			IF @end = 0
				--HR Engineering notation bugfix start
				IF ISNUMERIC(@Contents) = 1
					SELECT @end = LEN(@Contents);
				ELSE
					--HR Engineering notation bugfix end 
					SELECT
						@end = PATINDEX(
										   '%[A-Za-z0-9@+.e][^A-Za-z0-9@+.e]%'
										   ,@Contents + ' ' COLLATE SQL_Latin1_General_CP850_BIN
									   ) + 1;


			SELECT
				@Start = PATINDEX(
									 '%[^A-Za-z0-9@+.e][A-Za-z0-9@+.e]%'
									 ,' ' + @Contents COLLATE SQL_Latin1_General_CP850_BIN
								 );


			--select @start,@end, LEN(@contents+'|'), @contents  
			SELECT
				@value = RTRIM(SUBSTRING(@Contents, @Start, @end - @Start))
				,@Contents = RIGHT(@Contents + ' ', LEN(@Contents + '|') - @end);


			IF SUBSTRING(@value, 1, 7) = '@object'
				INSERT INTO @hierarchy ( NAME, sequenceNo, parent_ID, StringValue, Object_ID, ValueType )
				SELECT
					@name
					,@SequenceNo
					,@parent_ID
					,SUBSTRING(@value, 8, 5)
					,SUBSTRING(@value, 8, 5)
					,'object';
			ELSE IF SUBSTRING(@value, 1, 6) = '@array'
				INSERT INTO @hierarchy ( NAME, sequenceNo, parent_ID, StringValue, Object_ID, ValueType )
				SELECT
					@name
					,@SequenceNo
					,@parent_ID
					,SUBSTRING(@value, 7, 5)
					,SUBSTRING(@value, 7, 5)
					,'array';
			ELSE IF SUBSTRING(@value, 1, 7) = '@string'
				INSERT INTO @hierarchy ( NAME, sequenceNo, parent_ID, StringValue, ValueType )
				SELECT
					@name
					,@SequenceNo
					,@parent_ID
					,StringValue
					,'string'
				FROM @Strings
				WHERE String_ID = SUBSTRING(@value, 8, 5);
			ELSE IF @value IN ( 'true', 'false' )
				INSERT INTO @hierarchy ( NAME, sequenceNo, parent_ID, StringValue, ValueType )
				SELECT
					@name
					,@SequenceNo
					,@parent_ID
					,@value
					,'boolean';
			ELSE IF @value = 'null'
				INSERT INTO @hierarchy ( NAME, sequenceNo, parent_ID, StringValue, ValueType )
				SELECT
					@name
					,@SequenceNo
					,@parent_ID
					,@value
					,'null';
			ELSE IF PATINDEX('%[^0-9]%', @value COLLATE SQL_Latin1_General_CP850_BIN) > 0
				INSERT INTO @hierarchy ( NAME, sequenceNo, parent_ID, StringValue, ValueType )
				SELECT
					@name
					,@SequenceNo
					,@parent_ID
					,@value
					,'real';
			ELSE
				INSERT INTO @hierarchy ( NAME, sequenceNo, parent_ID, StringValue, ValueType )
				SELECT
					@name
					,@SequenceNo
					,@parent_ID
					,@value
					,'int';


			IF @Contents = ' '
				SELECT @SequenceNo = 0;
		END;
	END;


	INSERT INTO @hierarchy ( NAME, sequenceNo, parent_ID, StringValue, Object_ID, ValueType )
	SELECT
		'-'
		,1
		,NULL
		,''
		,@parent_ID - 1
		,@Type;


	--
	RETURN;
END;
GO