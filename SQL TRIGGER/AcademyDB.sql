CREATE DATABASE AcademyDB

USE AcademyDB

CREATE TABLE Academies
(
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100),
)
CREATE TABLE Groups
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    IsDeleted BIT NOT NULL DEFAULT 0,
    AcademyId INT FOREIGN KEY REFERENCES Academies(Id)
)


CREATE TABLE Students
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
	Surname NVARCHAR(100),
	Age INT,
    Adulthood BIT,
    GroupId INT FOREIGN KEY REFERENCES Groups(Id)
)

CREATE TABLE DeletedStudents
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
	Surname NVARCHAR(100),
    GroupId INT
)

CREATE TABLE DeletedGroups
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    AcademyId INT
)

CREATE VIEW VW_SHOW_ACADEMY
AS
SELECT * FROM Academies

SELECT * FROM VW_SHOW_ACADEMY



CREATE VIEW VW_SHOW_GROUP
AS
SELECT * FROM Groups

SELECT * FROM VW_SHOW_GROUP



CREATE VIEW VW_SHOW_STUDENT
AS
SELECT * FROM Students

SELECT * FROM VW_SHOW_STUDENT


CREATE PROCEDURE SP_GET_GROUP_BY_NAME @name NVARCHAR(100)
AS
SELECT * FROM Groups G
WHERE  G.Name LIKE '%' + @name + '%'


CREATE PROCEDURE SP_GET_ALL_STUDENTS_BIGGER_AGE @age INT
AS
SELECT * FROM Students S
WHERE S.Age > @age


CREATE PROCEDURE SP_GET_ALL_STUDENTS_SMALLER_AGE @age INT
AS
SELECT * FROM Students S
WHERE S.Age < @age



CREATE TRIGGER TR_ADD_TO_DELETED_STUDENTS
ON Students
AFTER DELETE
AS
BEGIN
    INSERT INTO DeletedStudents (Name, Surname, GroupId)
    SELECT Name, Surname, GroupId FROM deleted;
END;

CREATE TRIGGER TR_MODIFY_ISDELETED
ON Groups
INSTEAD OF DELETE
AS
BEGIN
    UPDATE Groups
    SET IsDeleted = 1
    WHERE Id IN (SELECT Id FROM deleted);
END;


CREATE TRIGGER TR_UPDATE_ADULTHOOD
ON Students
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE Students
    SET Adulthood = CASE WHEN Age >= 18 THEN 1 ELSE 0 END
    WHERE Id IN (SELECT Id FROM inserted);
END;

CREATE FUNCTION FN_GET_STUDENTS_BY_GROUPID (@GroupId INT)
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM Students
    WHERE GroupId = @GroupId
)


CREATE FUNCTION FN_GET_GROUPS_BY_ACADEMYID (@AcademyId INT)
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM Groups
    WHERE AcademyId = @AcademyId
)

INSERT INTO Academies (Name) VALUES ('Code Academy');
INSERT INTO Academies (Name) VALUES ('Other Academy');


INSERT INTO Groups (Name, AcademyId) VALUES ('PB201', 1);
INSERT INTO Groups (Name, AcademyId) VALUES ('PB203', 1);
INSERT INTO Groups (Name, AcademyId) VALUES ('SALAM1', 2);
INSERT INTO Groups (Name, AcademyId) VALUES ('SALAM2', 2);
INSERT INTO Groups (Name, AcademyId) VALUES ('PB205', 1);


INSERT INTO Students (Name, Surname, Age, Adulthood, GroupId) VALUES ('John', 'Doe', 17, 0, 1);
INSERT INTO Students (Name, Surname, Age, Adulthood, GroupId) VALUES ('Jane', 'Smith', 19, 1, 5);
INSERT INTO Students (Name, Surname, Age, Adulthood, GroupId) VALUES ('Alice', 'Johnson', 20, 1, 2);
INSERT INTO Students (Name, Surname, Age, Adulthood, GroupId) VALUES ('Bob', 'Brown', 16, 0, 2);
INSERT INTO Students (Name, Surname, Age, Adulthood, GroupId) VALUES ('Charlie', 'Davis', 18, 1, 3);
INSERT INTO Students (Name, Surname, Age, Adulthood, GroupId) VALUES ('David', 'Miller', 15, 0, 4);

SELECT * FROM VW_SHOW_ACADEMY;
SELECT * FROM VW_SHOW_GROUP;
SELECT * FROM VW_SHOW_STUDENT;

EXEC SP_GET_GROUP_BY_NAME 'PB';
EXEC SP_GET_ALL_STUDENTS_BIGGER_AGE 18;
EXEC SP_GET_ALL_STUDENTS_SMALLER_AGE 18;

SELECT * FROM FN_GET_STUDENTS_BY_GROUPID(1);
SELECT * FROM FN_GET_GROUPS_BY_ACADEMYID(1);

DELETE FROM Students WHERE Id = 1;
SELECT * FROM DeletedStudents;

DELETE FROM Groups WHERE Id = 1;
SELECT * FROM Groups WHERE Id = 1;

UPDATE Students 
SET Age = 18 
WHERE Id = 4;
SELECT * FROM Students WHERE Id = 4;
