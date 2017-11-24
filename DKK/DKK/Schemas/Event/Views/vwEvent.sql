CREATE VIEW [Event].[vwEvent]
AS
SELECT e.EventId
	  ,e.Name EventName
	  ,e.Date
	  ,et.EventTypeId
	  ,et.Name EventTypeName
FROM [Event].[Event] e
INNER JOIN [Event].[EventType] et ON et.EventTypeId = e.EventTypeId