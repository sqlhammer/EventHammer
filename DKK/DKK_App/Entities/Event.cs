using System;

/*
Producing entities:

SELECT 'public ' + 
	CASE 
		WHEN tp.name LIKE '%char%' 
			THEN 'string' 
		WHEN tp.name LIKE '%int%'
			THEN 'int'
		WHEN tp.name LIKE '%numeric%'
			THEN 'decimal'
		WHEN tp.name LIKE '%decimal%'
			THEN 'decimal'
		WHEN tp.name LIKE '%bit%'
			THEN 'bool'
		WHEN tp.name LIKE '%date%'
			THEN 'DateTime'
		ELSE ''
	END + 
	' ' + c.name + ' { get; set; }'
FROM sys.tables t
INNER JOIN sys.columns c ON c.object_id = t.object_id
INNER JOIN sys.types tp ON tp.user_type_id = c.user_type_id
WHERE t.name = 'MatchCompetitor'
ORDER BY t.name, c.name
*/

namespace DKK_App.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public EventType EventType { get; set; }
    }
}
