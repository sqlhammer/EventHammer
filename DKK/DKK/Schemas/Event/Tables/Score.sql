CREATE TABLE Event.Score
(
	ScoreId int IDENTITY(1,1) not null CONSTRAINT pk_event_score_scoreid PRIMARY KEY CLUSTERED,
	EventId int not null CONSTRAINT fk_event_score_eventid FOREIGN KEY REFERENCES Event.Event(EventId),
	MatchId int not null CONSTRAINT fk_event_score_matchid FOREIGN KEY REFERENCES Event.Match(MatchId),
	MatchTypeId int not null CONSTRAINT fk_event_score_matchtypeid FOREIGN KEY REFERENCES Event.MatchType(MatchTypeId),
	CompetitorId int not null CONSTRAINT fk_event_score_competitorid FOREIGN KEY REFERENCES Person.Competitor(CompetitorId),
	ScoreJudge1 decimal (3,1) not null CONSTRAINT df_event_score_ScoreJudge1 default(0),
	ScoreJudge2 decimal (3,1) not null CONSTRAINT df_event_score_ScoreJudge2 default(0),
	ScoreJudge3 decimal (3,1) not null CONSTRAINT df_event_score_ScoreJudge3 default(0),
	ScoreJudge4 decimal (3,1) not null CONSTRAINT df_event_score_ScoreJudge4 default(0),
	ScoreJudge5 decimal (3,1) not null CONSTRAINT df_event_score_ScoreJudge5 default(0),
	Total AS ScoreJudge1 + ScoreJudge2 + ScoreJudge3 + ScoreJudge4 + ScoreJudge5,
	Ranked tinyint not null,
	IsDisqualified bit not null CONSTRAINT df_event_score_isdisqualified default(0),
	INDEX uq_event_resultscored_eventid_matchid_competitorid NONCLUSTERED (EventId,MatchId,CompetitorId)
)
;