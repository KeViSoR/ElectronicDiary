--create database SportSchoolVer4DB;
--use SportSchoolVer4DB;

create table Persons
(
	ID int identity(1,1) primary key,
	LastName nvarchar(30) not null check(LastName <> ''),
	FirstName nvarchar(30) not null check(FirstName <> ''),
	SurName nvarchar(20) not null check(SurName <> ''),
	DateOfBirth date not null,
	ReceiptDate date not null,
	PlaceOfStudyOrWork nvarchar(50) null, 
	TelNumber nvarchar(13) null, 
	Adress nvarchar(100) null, 
	Email nvarchar(50) null,
	Photo varbinary(max) null,
	AdditionalInfo nvarchar(max) null,
	CONSTRAINT UQ_Persons UNIQUE(LastName, FirstName, SurName, DateOfBirth)
)

create table Sport
(
	ID int identity(1,1) primary key,
	Name nvarchar(30) not null check(Name <> '') unique
)

create table SportCategories
(
	ID int identity(1,1) primary key,
	Name nvarchar(4) not null check(Name <> '') unique,
	Validity int not null
)

create table Departments
(
	ID int identity(1,1) primary key,
	Name nvarchar(30) not null check(Name <> '') unique,
	SportID int,
	ChiefID int,
	Logo varbinary(max) null,
	CONSTRAINT FK_Departments_To_Sport foreign key(SportID) references Sport(ID) on delete set null,
	CONSTRAINT FK_Departments_To_Persons foreign key(ChiefID) references Trainers(ID) on delete set null
)

create table Stages
(
	ID int identity(1,1) primary key,
	Name nvarchar(60) not null check(Name <> '')
)

create table Groups
(
	ID int identity(1,1) primary key,
	Name nvarchar(5) not null check(Name <> ''),
	DepartmentID int,
	TrainerID int,
	StageID int,
	CONSTRAINT UQ_Groups UNIQUE(Name, DepartmentID, TrainerID),
	CONSTRAINT FK_Groups_To_Departments foreign key(DepartmentID) references Departments(ID) on delete set null,
	CONSTRAINT FK_Groups_To_Persons foreign key(TrainerID) references Trainers(ID) on delete set null,
	CONSTRAINT FK_Groups_To_Stages foreign key(StageID) references Stages(ID) on delete set null
)

create table SportsmensGroup
(
	ID int identity(1,1) primary key,
	PersonsID int not null references Persons(ID),
	GroupID int,
	CONSTRAINT UQ_SportsmensGroup UNIQUE(PersonsID, GroupID),
	CONSTRAINT FK_SportsmensGroup_To_Persons foreign key(PersonsID) references Persons(ID) on delete CASCADE,
	CONSTRAINT FK_SportsmensGroup_To_Groups foreign key(GroupID) references Groups(ID) on delete set null
)

create table SportsmensSportCat
(
	ID int identity(1,1) primary key,
	PersonsID int not null,
	SportID int not null,
	SportCatID int,
	DateOfAssignmentSC date,
	CONSTRAINT UQ_SportsmensSportCat UNIQUE(PersonsID, SportID),
	CONSTRAINT FK_SportsmensSportCat_To_Persons foreign key(PersonsID) references Persons(ID) on delete CASCADE,
	CONSTRAINT FK_SportsmensSportCat_To_Sport foreign key(SportID) references Sport(ID) on delete CASCADE,
	CONSTRAINT FK_SportsmensSportCat_To_SportCategories foreign key(SportCatID) references SportCategories(ID) on delete set null
)

create table Trainers
(
	ID int identity(1,1) primary key,
	PersonsID int not null unique,
	TrainerLogin nvarchar(30) not null check(TrainerLogin <> '') unique,
	TrainerPassword nvarchar(30) not null check(TrainerPassword <> '') unique,
	IsAdmin bit not null default 0,
	CONSTRAINT FK_Trainers_To_Persons foreign key(PersonsID) references Persons(ID) on delete CASCADE
)



