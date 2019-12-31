create view Event.vwScore
as
SELECT s.[ScoreId]
      ,s.[EventId]
      ,s.[MatchId]
	  ,m.DivisionId
	  ,m.SubDivisionId
      ,s.[MatchTypeId]
	  ,mt.Name [MatchTypeName]
      ,s.[CompetitorId]
	  ,p.DisplayName
      ,s.[ScoreJudge1]
      ,s.[ScoreJudge2]
      ,s.[ScoreJudge3]
      ,s.[ScoreJudge4]
      ,s.[ScoreJudge5]
      ,s.[Total] [Database_Total]
      ,s.[Ranked]
      ,s.[IsDisqualified]
FROM [Event].[Score] s
INNER JOIN event.[Match] m on m.MatchId = s.MatchId
INNER JOIN event.MatchType mt on mt.MatchTypeId = s.MatchTypeId
INNER JOIN event.MatchCompetitor mc on mc.CompetitorId = s.CompetitorId and mc.MatchId = s.MatchId
INNER JOIN person.Competitor c on c.CompetitorId = mc.CompetitorId
INNER JOIN person.person p on p.PersonId = c.PersonId
;
