CREATE TABLE [Times] (
    [TimeID]        INTEGER PRIMARY KEY,
    [OtherTime]     nvarchar(20) NOT NULL );
CREATE TABLE [State] (
    [StateID]       INTEGER PRIMARY KEY,
    [StateName]     nvarchar(50) NOT NULL );
CREATE TABLE [SpecMins] (
    [Id]            INTEGER PRIMARY KEY,
    [SpecID]        integer NOT NULL,
    [MinsID]	    integer NOT NULL,
    [MinsPriority]  smallint NOT NULL,
    FOREIGN KEY ([SpecID])	REFERENCES [Spec]([SpecID]),
    FOREIGN KEY ([MinsID])	REFERENCES [Mins]([MinsID]) );
CREATE TABLE [SpecImgs] (
    [Id]	        INTEGER PRIMARY KEY,
	[SpecID]		integer NOT NULL,
	[ImagePathID]	integer NOT NULL,
	[ImageName]     nvarchar(50) NOT NULL,
	[ImagePriority]	smallint NOT NULL,
	[CommentID]     integer NOT NULL,
	FOREIGN KEY ([SpecID])	    REFERENCES [Spec]([SpecID]),
	FOREIGN KEY ([ImagePathID]) REFERENCES [ImgsPaths]([ImagePathID]),
	FOREIGN KEY ([CommentID])	REFERENCES [Comment]([CommentID]) );
CREATE TABLE [Spec] (
	[SpecID]	    INTEGER PRIMARY KEY,
	[UserSpecID]	nvarchar(25),
	[minID]	        char(6),
	[Height]	    float,
	[Length]	    float,
	[Width]	        float,
	[Units]	        bit NOT NULL DEFAULT 0,
	[Weight]	    float,
	[WeightUnits]	bit NOT NULL DEFAULT 0,
	[Appraisal]	    numeric,
	[Rating]	    numeric,
	[Transparency]	numeric,
	[Crystallization]	numeric,
	[Repaired]	    bit NOT NULL DEFAULT 0,
	[Artificial]	bit NOT NULL DEFAULT 0,
	[CommentID]	    integer,
    FOREIGN KEY ([CommentID])   REFERENCES [Comment]([CommentID]) );
CREATE TABLE [OpenHours] (
	[Id]	        INTEGER PRIMARY KEY,
	[AvailableID]	integer,
	[FromTime]	    smallint,
	[ToTime]	    smallint,
	[DaysID]	    INTEGER,
    FOREIGN KEY ([AvailableID]) REFERENCES [Availability]([AvailableID]),
    FOREIGN KEY ([DaysID])      REFERENCES [Days]([DaysID]) );
CREATE TABLE [MyMinsCompatibleVersions] (
	[Id]            INTEGER PRIMARY KEY,
	[MyMinsMajor]   integer NOT NULL,
	[MyMinsMinor]   integer NOT NULL,
	[MyMinsBuild]   integer NOT NULL );
CREATE TABLE [MinsTypes] (
	[MinsTypeID]	INTEGER PRIMARY KEY,
	[MinsTypeName]	nvarchar(50) NOT NULL );
CREATE TABLE [MinsRelations] (
	[Id]	        INTEGER PRIMARY KEY,
	[MinslID]	    integer,
	[RelatedMinsID]	integer,
    FOREIGN KEY ([MinslID])         REFERENCES [Mins]([MinsID]),
    FOREIGN KEY ([RelatedMinsID])   REFERENCES [Mins]([MinsID]) );
CREATE TABLE [Mins] (
	[MinsID]	    INTEGER PRIMARY KEY,
	[MindatID]	    integer,
	[MinsName]	    nvarchar(50) NOT NULL,
	[MinsTypeID]	INTEGER DEFAULT 4,
	[CommentID]	    INTEGER,
    FOREIGN KEY ([MinsTypeID])  REFERENCES [MinsTypes]([MinsTypeID]),
    FOREIGN KEY ([CommentID])   REFERENCES [Comment]([CommentID]) );
CREATE TABLE [ImgsPaths] (
	[ImagePathID]	INTEGER PRIMARY KEY,
	[ImagePath]	    nvarchar NOT NULL );
CREATE TABLE [Exposure] (
	[ExposureID]	INTEGER PRIMARY KEY,
	[ContactID]	    INTEGER,
	[ExposureName]	nvarchar(50),
	[ExposureDay]	smallint,
	[ExposureMonth]	smallint,
	[ExposureYear]	smallint,
	[TimeID]	    INTEGER,
    FOREIGN KEY ([ContactID])   REFERENCES [Contact]([ContactID]),
    FOREIGN KEY ([TimeID])      REFERENCES [Times]([TimeID]) );
CREATE TABLE [Days] (
	[DaysID]	INTEGER PRIMARY KEY,
	[Saturday]	bit NOT NULL,
	[Sunday]	bit NOT NULL,
	[Monday]	bit NOT NULL,
	[Tuesday]	bit NOT NULL,
	[Wednesday]	bit NOT NULL,
	[Thursday]	bit NOT NULL,
	[Friday]	bit NOT NULL );
CREATE TABLE [County] (
	[CountyID]	    INTEGER PRIMARY KEY,
	[CountyName]	nvarchar(50) NOT NULL );
CREATE TABLE [Country] (
	[CountryID]	    INTEGER PRIMARY KEY,
	[CountryName]	nvarchar(50) NOT NULL );
CREATE TABLE [ContactType] (
	[ContactTypeID]	    INTEGER PRIMARY KEY,
	[ContactTypeName]	nvarchar(25) NOT NULL );
CREATE TABLE [ContactImgs] (
	[Id]	        INTEGER PRIMARY KEY,
	[ContactID]	    integer NOT NULL,
	[ImagePathID]	integer NOT NULL,
	[ImageName]	    nvarchar(50) NOT NULL,
	[ImagePriority]	smallint NOT NULL,
	[CommentID]	    integer,
    FOREIGN KEY ([ContactID])   REFERENCES [Contact]([ContactID]),
    FOREIGN KEY ([ImagePathID]) REFERENCES [ImgsPaths]([ImagePathID]),
    FOREIGN KEY ([CommentID])   REFERENCES [Comment]([CommentID]) );
CREATE TABLE [Contact] (
	[ContactID]	    INTEGER PRIMARY KEY,
	[ContactName]	nvarchar(50),
	[ContactTypeID]	INTEGER DEFAULT 1,
	[Address]	    nvarchar(50),
	[CityID]	    INTEGER,
	[CountyID]	    INTEGER,
	[StateID]	    INTEGER,
	[CountryID]	    INTEGER,
	[GPSlat]	    float,
	[GPSlon]	    float,
	[Phone]	        integer,
	[Email]	        nvarchar(75),
	[Web]	        nvarchar(150),
	[CommentID]	    INTEGER,
	[AvailableID]	INTEGER,
	[MindatID]	    integer,
    FOREIGN KEY ([ContactTypeID])   REFERENCES [ContactType]([ContactTypeID]),
    FOREIGN KEY ([CityID])          REFERENCES [City]([CityID]),
    FOREIGN KEY ([CountyID])        REFERENCES [County]([CountyID]),
    FOREIGN KEY ([StateID])         REFERENCES [State]([StateID]),
    FOREIGN KEY ([CountryID])       REFERENCES [Country]([CountryID]),
    FOREIGN KEY ([CommentID])       REFERENCES [Comment]([CommentID]),
    FOREIGN KEY ([AvailableID])     REFERENCES [Availability]([AvailableID]) );
CREATE TABLE [Comment] (
	[CommentID]	    INTEGER PRIMARY KEY,
	[Comment]	    nvarchar NOT NULL );
CREATE TABLE [City] (
	[CityID]	    INTEGER PRIMARY KEY,
	[CityName]	    nvarchar(50) NOT NULL );
CREATE TABLE [Availability] (
	[AvailableID]	INTEGER PRIMARY KEY,
	[FromDay]	    smallint,
	[FromMonth]	    smallint,
	[FromYear]	    smallint,
	[FromTimeID]	INTEGER,
	[ToDay]	        smallint,
	[ToMonth]	    smallint,
	[ToYear]	    smallint,
	[ToTimeID]	    INTEGER,
    FOREIGN KEY ([FromTimeID])  REFERENCES [Times]([TimeID]),
    FOREIGN KEY ([ToTimeID])    REFERENCES [Times]([TimeID]) );
CREATE TABLE [Acquisition] (
	[Id]	        INTEGER PRIMARY KEY,
	[SpecID]	    integer NOT NULL,
	[FromContactID]	INTEGER,
	[ToContactID]	INTEGER,
	[AcquireDay]	smallint,
	[AcquireMonth]	smallint,
	[AcquireYear]	smallint,
	[TimeID]	    INTEGER,
	[AcquireTypeID]	INTEGER,
	[AcquirePrice]	numeric,
	[ExposureID]	INTEGER,
    FOREIGN KEY ([SpecID])          REFERENCES [Spec]([SpecID]),
    FOREIGN KEY ([FromContactID])   REFERENCES [Contact]([ContactID]),
    FOREIGN KEY ([ToContactID])     REFERENCES [Contact]([ContactID]),
    FOREIGN KEY ([TimeID])          REFERENCES [Times]([TimeID]),
    FOREIGN KEY ([AcquireTypeID])   REFERENCES [AcquireType]([AcquireTypeID]),
    FOREIGN KEY ([ExposureID])      REFERENCES [Exposure]([ExposureID]) );
CREATE TABLE [AcquireType] (
    [AcquireTypeID]     INTEGER PRIMARY KEY,
    [AcquireTypeName]   nvarchar(50) );
INSERT INTO [MinsTypes] VALUES (1,'Variety');
INSERT INTO [MinsTypes] VALUES (2,'IMA');
INSERT INTO [MinsTypes] VALUES (3,'Synonym');
INSERT INTO [MinsTypes] VALUES (4,'Mixture');
INSERT INTO [MinsTypes] VALUES (5,'Series');
INSERT INTO [MinsTypes] VALUES (6,'Group');
INSERT INTO [Mins] VALUES (1,NULL,'<unidentified>',4,NULL);
INSERT INTO [ContactType] VALUES (1,'Locale');
INSERT INTO [ContactType] VALUES (2,'Dealer');
INSERT INTO [ContactType] VALUES (3,'Shop');
INSERT INTO [ContactType] VALUES (4,'Person');
INSERT INTO [ContactType] VALUES (5,'Club');
INSERT INTO [ContactType] VALUES (6,'Organizaton');
INSERT INTO [Spec] VALUES (1,'1',NULL,NULL,NULL,NULL,0,NULL,0,NULL,NULL,NULL,NULL,0,0,NULL);
INSERT INTO [Contact] VALUES (1,'Self',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
INSERT INTO [MyMinsCompatibleVersions] VALUES (1,1,0,0);