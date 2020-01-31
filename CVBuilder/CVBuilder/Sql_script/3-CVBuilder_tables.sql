use CVBuilder
go

create schema cvbuilder
go

create table cvbuilder.Users
(
	--UserID integer identity(1,1),
	Id nvarchar(128),
	Email nvarchar(100) not null,
	Password nvarchar(100) not null,
	Name nvarchar(100),
	LastName nvarchar(100),
	Profession nvarchar(50),
	Photo varbinary(max),
	MimeType nvarchar(25),
	Address nvarchar(100),
	City nvarchar(100),
	PostalCode integer,
	AreaCodeLP smallint,
	LinePhone integer,
	AreaCodeMP smallint,
	MobilePhone integer,
	Country nvarchar(100),
	constraint PK_Users primary key clustered (Id)
)
go

create table cvbuilder.Templates
(
	TemplateID integer identity(1,1),
	Name nvarchar(100) not null,
	PreviewPath nvarchar(max) not null,
	constraint PK_Templates primary key clustered (TemplateID)
)
go

insert into cvbuilder.Templates (Name, PreviewPath)
values ('Classic','/img/templates/classic.png'),('Elegant','/img/templates/elegant.png'),('Modern','/img/templates/modern.png')
go

create table cvbuilder.Curriculum
(
	CurriculumID integer identity(1,1),
	ID_User nvarchar(128) not null,
	ID_Template integer not null,
	StudiesIsVisible bit not null,
	WorkExperiencesIsVisible bit not null,
	CertificatesIsVisible bit not null,
	LanguagesIsVisible bit not null,
	SkillsIsVisible bit not null,
	InterestsIsVisible bit not null,
	PersonalReferencesIsVisible bit not null,
	CustomSectionsIsVisible bit not null,
	constraint PK_Curriculum primary key clustered (CurriculumID),
	constraint FK_Curriculum_Users foreign key (ID_User) references dbo.AspNetUsers (Id),
	constraint FK_Curriculum_Templates foreign key (ID_Template) references cvbuilder.Templates (TemplateID)
)
go

create table cvbuilder.PersonalDetails
(
	PersonalDetailsID integer identity(1,1),
	Name nvarchar(100) not null,
	LastName nvarchar(100) not null,
	Email nvarchar(100) not null,
	Profession nvarchar(100),
	Photo varbinary(max),
	MimeType nvarchar(25),
	Address nvarchar(100),
	City nvarchar(100),
	PostalCode integer,
	AreaCodeLP smallint,
	LinePhone integer,
	AreaCodeMP smallint,
	MobilePhone integer,
	Country nvarchar(100),
	Summary nvarchar(300) not null,
	SummaryCustomTitle nvarchar(50),
	SummaryIsVisible bit not null,
	WebPageUrl nvarchar(300),
	LinkedInUrl nvarchar(300),
	GithubUrl nvarchar(300),
	FacebookUrl nvarchar(300),
	TwitterUrl nvarchar(300),
	ID_Curriculum integer not null,
	constraint PK_PersonalDetails primary key clustered (PersonalDetailsID),
	constraint FK_PersonalDetails_Curriculum foreign key (ID_Curriculum) references cvbuilder.Curriculum (CurriculumID)
)
go

create table cvbuilder.Studies
(
	StudyID integer identity(1,1),
	Title nvarchar(100) not null,
	Institute nvarchar(100) not null,
	City nvarchar(100) not null,
	StartMonth nvarchar(50) not null,
	StartYear integer,
	EndMonth nvarchar(50) not null,
	EndYear integer,
	Description nvarchar(300),
	IsVisible bit not null,
	ID_Curriculum integer not null,
	constraint PK_Studies primary key clustered (StudyID),
	constraint FK_Studies_Curriculum foreign key (ID_Curriculum) references cvbuilder.Curriculum (CurriculumID)
)
go

create table cvbuilder.WorkExperiences
(
	WorkExperienceID integer identity(1,1),
	Job nvarchar(100) not null,
	City nvarchar(100) not null,
	Company nvarchar(100) not null,
	StartMonth nvarchar(50) not null,
	StartYear integer,
	EndMonth nvarchar(50) not null,
	EndYear integer,
	Description nvarchar(300),
	IsVisible bit not null,
	ID_Curriculum integer not null,
	constraint PK_WorkExperiences primary key clustered (WorkExperienceID),
	constraint FK_WorkExperiences_Curriculum foreign key (ID_Curriculum) references cvbuilder.Curriculum (CurriculumID)
)
go

create table cvbuilder.Certificates
(
	CertificateID integer identity(1,1),
	Name nvarchar(100) not null,
	Institute nvarchar(100) not null,
	OnlineMode bit not null,
	InProgress bit not null,
	Year integer,
	Description nvarchar(300),
	IsVisible bit not null,
	ID_Curriculum integer not null,
	constraint PK_Certificates primary key clustered (CertificateID),
	constraint FK_Certificates_Curriculum foreign key (ID_Curriculum) references cvbuilder.Curriculum (CurriculumID)
)
go

create table cvbuilder.Languages
(
	LanguageID integer identity(1,1),
	Name nvarchar(100) not null,
	Level nvarchar(50) not null,
	IsVisible bit not null,
	ID_Curriculum integer not null,
	constraint PK_Languages primary key clustered (LanguageID),
	constraint FK_Languages_Curriculum foreign key (ID_Curriculum) references cvbuilder.Curriculum (CurriculumID)
)
go

create table cvbuilder.Skills
(
	SkillID integer identity(1,1),
	Name nvarchar(100) not null,
	Level nvarchar(50) not null,
	IsVisible bit not null,
	ID_Curriculum integer not null,
	constraint PK_Skills primary key clustered (SkillID),
	constraint FK_Skills_Curriculum foreign key (ID_Curriculum) references cvbuilder.Curriculum (CurriculumID)
)
go

create table cvbuilder.Interests
(
	InterestID integer identity(1,1),
	Name nvarchar(100) not null,
	IsVisible bit not null,
	ID_Curriculum integer not null,
	constraint PK_Interests primary key clustered (InterestID),
	constraint FK_Interests_Curriculum foreign key (ID_Curriculum) references cvbuilder.Curriculum (CurriculumID)
)
go

create table cvbuilder.PersonalReferences
(
	PersonalReferenceID integer identity(1,1),
	Company nvarchar(100) not null,
	ContactPerson nvarchar(200) not null,
	AreaCode smallint,
	Telephone integer,
	Email nvarchar(100) not null,
	IsVisible bit not null,
	ID_Curriculum integer not null,
	constraint PK_PersonalReferences primary key clustered (PersonalReferenceID),
	constraint FK_PersonalReferences_Curriculum foreign key (ID_Curriculum) references cvbuilder.Curriculum (CurriculumID)
)
go

create table cvbuilder.CustomSections
(
	CustomSectionID integer identity(1,1),
	SectionName nvarchar(100) not null,
	Description nvarchar(max) not null,
	IsVisible bit not null,
	ID_Curriculum integer not null,
	constraint PK_CustomSections primary key clustered (CustomSectionID),
	constraint FK_CustomSections_Curriculum foreign key (ID_Curriculum) references cvbuilder.Curriculum (CurriculumID)
)
go
