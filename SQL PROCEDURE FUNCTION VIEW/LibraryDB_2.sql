CREATE DATABASE LibraryDB

USE LibraryDB

CREATE TABLE Authors
(
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100),
    Surname NVARCHAR(100)
)
CREATE TABLE Books
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    PageCount INT CHECK(PageCount > 0),
    AuthorId INT FOREIGN KEY REFERENCES Authors(Id)
)

INSERT INTO Authors
VALUES
('Osamu', 'Dazai'),
('Albert', 'Camus'),
('Friedrich', 'Nietzsche'),
('George', 'Orwell'),
('Fyodor', 'Dostoevsky');


INSERT INTO Books
VALUES
('No Longer Human', 177, 1),
('The Setting Sun', 162, 1),
('The Stranger', 123, 2),
('Animal Farm', 112, 4),
('1984', 328, 4),
('The Plague', 308, 2),
('Beyond Good and Evil', 288, 3),
('Thus Spoke Zarathustra', 320, 3),
('Crime and Punishment', 430, 5),
('The Brothers Karamazov', 796, 5);
('The Fall', 147, 2),
('The Myth of Sisyphus', 212, 2),
('The Birth of Tragedy', 240, 3),
('The Idiot', 656, 5),
('Demons', 768, 5)

CREATE VIEW VW_BOOK_AUTHOR_DATA
AS
SELECT B.Id, B.Name, B.PageCount , CONCAT(A.Name, ' ', A.Surname) AS 'Author Fullname' FROM Books B
INNER JOIN Authors A
ON B.AuthorId = A.Id


SELECT * FROM VW_BOOK_AUTHOR_DATA

CREATE PROCEDURE SP_SELECT_NAME_OR_AUTHORNAME @Word NVARCHAR(100)
AS
SELECT * FROM VW_BOOK_AUTHOR_DATA
WHERE Name LIKE '%' + @Word + '%' OR [Author Fullname] LIKE '%' + @Word + '%';

EXEC SP_SELECT_NAME_OR_AUTHORNAME Dost


CREATE VIEW VW_AUTHOR_COMPARE
AS
SELECT A.Id, CONCAT(A.Name, ' ', A.Surname) AS 'Author Fullname', COUNT(B.Id) AS 'Books Count', MAX(B.PageCount) AS 'Max Page Count'  FROM Authors A
INNER JOIN Books B
ON A.Id = B.AuthorId
GROUP BY A.Id, CONCAT(A.Name, ' ', A.Surname)

SELECT * FROM VW_AUTHOR_COMPARE


