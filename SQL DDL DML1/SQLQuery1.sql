CREATE DATABASE DepartmentDB

USE DepartmentDB

CREATE TABLE Departments(
	Id INT NOT NULL UNIQUE IDENTITY(1,1),
	Name NVARCHAR(150) NOT NULL,
	MaxEmployeeCount INT CHECK(MaxEmployeeCount >= 10 and MaxEmployeeCount <= 50)
)

CREATE TABLE Positions(
	Id INT NOT NULL UNIQUE IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Employees(
	Id INT NOT NULL UNIQUE IDENTITY(1,1),
	Name NVARCHAR(60) DEFAULT('Employee Name'),
	Surname NVARCHAR(70) DEFAULT('Employee Surname'),
	Salary DECIMAL(18,2) CHECK(Salary >= 500 and Salary <= 12000)
)

INSERT INTO Departments (Name, MaxEmployeeCount) VALUES ('HR', 25);

INSERT INTO Positions (Name) VALUES ('Manager');

INSERT INTO Positions (Name) VALUES (NULL); -- Fails as expected

INSERT INTO Employees (Name, Surname, Salary) VALUES ('John', 'Wick', 5000.00);

INSERT INTO Employees (Salary) VALUES (7000.00);

INSERT INTO Employees (Name, Surname, Salary) VALUES ('Johnny', 'Wicky', 200.00); -- Fails as expected

INSERT INTO Employees (Name, Surname, Salary) VALUES ('Jonathan', 'Wicked', 13000.00); -- Fails as expected



SELECT * FROM Departments
SELECT * FROM Positions
SELECT * FROM Employees