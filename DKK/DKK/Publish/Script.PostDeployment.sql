﻿
--Load static tables
PRINT 'Loading Event.Division...'
:r .\..\Schemas\Event\Data\Division.sql

PRINT 'Loading Event.Rank...'
:r .\..\Schemas\Event\Data\Rank.sql

PRINT 'Loading Event.MatchType...'
:r .\..\Schemas\Event\Data\MatchType.sql

PRINT 'Loading Event.EventType...'
:r .\..\Schemas\Event\Data\EventType.sql

PRINT 'Loading Facility.MartialArtType...'
:r .\..\Schemas\Facility\Data\MartialArtType.sql

PRINT 'Loading Person.Title...'
:r .\..\Schemas\Person\Data\Title.sql

PRINT 'Loading Person.Person...'
:r .\..\Schemas\Person\Data\Person.sql

--PRINT 'Loading Stage.Registration...'
--:r .\..\Schemas\Stage\Data\Registration.sql

--PRINT 'Loading Stage.CalderaFormEntry...'
--:r .\..\Schemas\Stage\Data\CalderaFormEntry.sql

PRINT 'Loading Facility.FacilityType...'
:r .\..\Schemas\Facility\Data\FacilityType.sql

--This must go after the Person table so the ownerids can be set.
PRINT 'Loading Facility.Facility...'
:r .\..\Schemas\Facility\Data\Facility.sql

PRINT 'Loading Facility.Dojo...'
:r .\..\Schemas\Facility\Data\Dojo.sql

--PRINT 'Loading Event.Event...'
--:r .\..\Schemas\Event\Data\Event.sql

--PRINT 'Executing SQLAgentJob-Load-Registration-Data.sql...'
--:r .\..\SQLAgentJobs\SQLAgentJob-Load-Registration-Data.sql

