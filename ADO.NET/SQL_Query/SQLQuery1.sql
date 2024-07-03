CREATE DATABASE Academy

USE Academy

CREATE TABLE Academies
(
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100),
)
CREATE TABLE Groups
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    AcademyId INT FOREIGN KEY REFERENCES Academies(Id)
)


CREATE TABLE Students
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
	Surname NVARCHAR(100),
	Age INT,
    [Grant] DECIMAL(5,2),
    GroupId INT FOREIGN KEY REFERENCES Groups(Id)
)

SELECT S.Id,S.Name,S.Surname,S.Age,S.[Grant],G.Name 'Group Name' FROM Students S
INNER JOIN Groups G
ON S.GroupId = G.Id

