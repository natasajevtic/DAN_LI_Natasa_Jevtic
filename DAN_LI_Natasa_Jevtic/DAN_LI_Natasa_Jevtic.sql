IF DB_ID('Medical_Institution') IS NULL
    create database Medical_Institution;
GO	
use Medical_Institution
--Deleting tables and views, if they exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblRequest')
	drop table tblRequest;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblPatient')
	drop table tblPatient;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblDoctor')
	drop table tblDoctor;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblUser')
	drop table tblUser;
IF EXISTS(select * FROM sys.views where name = 'vwRequest')
	drop view vwRequest;
IF EXISTS(select * FROM sys.views where name = 'vwPatient')
	drop view vwPatient;
IF EXISTS(select * FROM sys.views where name = 'vwDoctor')
	drop view vwDoctor;
IF EXISTS(select * FROM sys.views where name = 'vwUser')
	drop view vwUser;
--Creating a table of users
create table tblUser(
UserId int identity(1,1) PRIMARY KEY,
Name varchar(50) NOT NULL,
Surname varchar(50) NOT NULL,
JMBG varchar(13) NOT NULL CHECK(LEN(JMBG)=13 AND ISNUMERIC(JMBG)=1),
Username varchar(40) UNIQUE NOT NULL,
Password varchar(255) NOT NULL
);
--Creating a table of doctors
create table tblDoctor(
DoctorId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
BankAccountNumber varchar(18) UNIQUE NOT NULL,
);
--Creating a table of patients
create table tblPatient(
PatientId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
HealthInsuranceCardNumber varchar(11) UNIQUE NOT NULL,
DoctorId int FOREIGN KEY REFERENCES tblDoctor(DoctorId),
);
--Creating a table of requests
create table tblRequest(
RequestId int identity(1,1) PRIMARY KEY,
PostingDate date NOT NULL,
Reason varchar(250) NOT NULL,
PatientCompany varchar(100) NOT NULL,
EmergencyCase varchar(2) NOT NULL,
PatientId int FOREIGN KEY REFERENCES tblPatient(PatientId) NOT NULL
);
--Creating a view of users
GO
create view vwUser as
select *
from tblUser;
--Creating a view of doctors
GO
create view vwDoctor as
select d.*, u.Name, u.Surname, u.JMBG, u.Username, u.Password
from tblDoctor d
INNER JOIN tblUser u
ON d.UserId = u.UserId;
--Creating a view of patient
GO
create view vwPatient as
select p.*, u.Name, u.Surname, u.JMBG, u.Username, u.Password
from tblPatient p
INNER JOIN tblUser u
ON p.UserId = u.UserId;
--Creating a view of requests
GO
create view vwRequest as
select p.*, r.EmergencyCase, r.PatientCompany, r.PostingDate, r.Reason, u.Name, u.Surname
from tblRequest r
INNER JOIN tblPatient p
ON p.PatientId = r.RequestId
INNER JOIN tblUser u
ON u.UserId=p.UserId;



