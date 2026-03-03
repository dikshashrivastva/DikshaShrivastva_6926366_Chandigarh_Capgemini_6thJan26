-- Create Database
CREATE DATABASE LibraryDB;
USE LibraryDB;

-- Authors Table
CREATE TABLE Authors (
    AuthorId INT PRIMARY KEY IDENTITY(1,1),
    AuthorName NVARCHAR(100) NOT NULL
);

-- Books Table
CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200),
    AuthorId INT FOREIGN KEY REFERENCES Authors(AuthorId),
    PublishedYear INT
);

-- Members Table
CREATE TABLE Members (
    MemberId INT PRIMARY KEY IDENTITY(1,1),
    MemberName NVARCHAR(100),
    Email NVARCHAR(100)
);

-- BorrowRecords Table
CREATE TABLE BorrowRecords (
    RecordId INT PRIMARY KEY IDENTITY(1,1),
    MemberId INT FOREIGN KEY REFERENCES Members(MemberId),
    BookId INT FOREIGN KEY REFERENCES Books(BookId),
    BorrowDate DATE,
    ReturnDate DATE
);


-- Insert Authors
INSERT INTO Authors (AuthorName) VALUES ('J.K. Rowling'), ('George Orwell'), ('Jane Austen');

-- Insert Books
INSERT INTO Books (Title, AuthorId, PublishedYear) VALUES
('Harry Potter', 1, 1997),
('1984', 2, 1949),
('Pride and Prejudice', 3, 1813);

-- Insert Members
INSERT INTO Members (MemberName, Email) VALUES
('Alice Johnson', 'alice@library.com'),
('Bob Smith', 'bob@library.com');

-- Insert BorrowRecords
INSERT INTO BorrowRecords (MemberId, BookId, BorrowDate, ReturnDate) VALUES
(1, 1, '2026-01-01', '2026-01-15'),
(2, 2, '2026-02-01', NULL);

--PROCEDURE
CREATE PROCEDURE InsertBook
@Title nvarchar(200),
@AuthorId int,
@PublishedYear int
AS
BEGIN
INSERT INTO Books(Title,AuthorId,PublishedYear)
VALUES(@Title,@AuthorId,@PublishedYear)
END

--PROCEDURE
CREATE PROCEDURE GetBooks
AS
BEGIN
SELECT * FROM Books
END

--PROCEDURE
CREATE PROCEDURE UpdateBook
@BookId int,
@Title varchar(200),
@AuthorId int,
@PublishedYear int
AS
BEGIN
Update Books 
SET Title=@Title,AuthorId=@AuthorId,PublishedYear=@PublishedYear
WHERE BookId=@BookId
END

--PROCEDURE
CREATE PROCEDURE DeleteBook
@BookId INT
AS
BEGIN
DELETE FROM Books
WHERE BookId=@BookId
END