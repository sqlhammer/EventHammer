CREATE TYPE [Event].[ttScore] AS TABLE
(
    ScoreId int null,
	EventId int not null,
	MatchId int not null,
	MatchTypeId int not null,
	CompetitorId int not null,
	ScoreJudge1 decimal (3,1) null,
	ScoreJudge2 decimal (3,1) null,
	ScoreJudge3 decimal (3,1) null,
	ScoreJudge4 decimal (3,1) null,
	ScoreJudge5 decimal (3,1) null,
	Ranked tinyint not null,
	IsDisqualified bit not null
);
