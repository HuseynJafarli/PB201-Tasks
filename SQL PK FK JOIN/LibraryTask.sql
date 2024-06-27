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
    CostPrice DECIMAL(18,2),
    SalePrice DECIMAL(18,2),
    AuthorId INT FOREIGN KEY REFERENCES Authors(Id)
)

CREATE TABLE Tags
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) NOT NULL
)

CREATE TABLE BookTags
(
    Id INT PRIMARY KEY IDENTITY,
    BookId INT FOREIGN KEY REFERENCES Books(Id),
    TagId INT FOREIGN KEY REFERENCES Tags(Id)
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
('No Longer Human', 177, 8.99, 12.99, 1),
('The Setting Sun', 162, 6.99, 10.99, 1),
('The Stranger', 123, 5.99, 11.99, 2),
('Animal Farm', 112, 5.99, 9.99, 4),
('1984', 328, 6.50, 14.99, 4),
('The Plague', 308, 9.99, 15.99, 2),
('Beyond Good and Evil', 288, 7.50, 13.99, 3),
('Thus Spoke Zarathustra', 320, 10.99, 17.99, 3),
('Crime and Punishment', 430, 11.99, 18.99, 5),
('The Brothers Karamazov', 796, 15.99, 24.99, 5);


INSERT INTO Tags
VALUES
('BestSeller'),
('Featured'),
('New');


INSERT INTO BookTags (BookId, TagId)
VALUES
(1, 1),
(1, 3),
(2, 1),
(3, 2),
(4, 3),
(5, 2),
(6, 1),
(7, 2),
(8, 3),
(9, 1),
(10, 3);


SELECT B.Id,CONCAT(A.Name, ' ', A.Surname) AuthorFullName, B.Name BookName,B.SalePrice BookPrice,B.PageCount,T.Name 'TagName' FROM Books B
INNER JOIN Authors A 
ON B.AuthorId = A.Id
INNER JOIN BookTags BT 
ON B.Id = BT.BookId
INNER JOIN Tags T 
ON BT.TagId = T.Id;
