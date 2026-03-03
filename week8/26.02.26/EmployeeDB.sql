CREATE DATABASE EmployeeDB;
use EmployeeDB;

drop table address;
drop table employee;

CREATE TABLE Address(
AddressID int primary key Identity(1,1),
Street varchar (255) NULL,
City varchar (100) null,
State varchar (100) null,
PostalCode varchar(20) null
);


CREATE TABLE EMPLOYEE(
EmployeeID int primary key identity(1,1) NOT NULL,
FirstName varchar(100) NULL,
LastName varchar(100) NULL,
Email varchar (100) NULL,
AddressID int null
Foreign key (AddressID) references Address(AddressID)  
);

Insert into Address values ('1234 Elm Street','Springfield','Ilinos','62704');
Insert into Address values ('1234 Oak Street','Denmark','Albinus','34567');
Insert into Address values ('123 Patia','BBSR','India','92504');
Insert into Address values ('12 Panvel','Mumbai','India','627021');

SELECT * FROM Address;

Insert into EMPLOYEE values ('Jash','Dhawan','jasdham@ex.com',1);
Insert into EMPLOYEE values ('Jane','Doe','janedoe@ex.com',2);
Insert into EMPLOYEE values ('Jashwanti','Sadhu','jashwanti@ex.com',3);
Insert into EMPLOYEE values ('Deepali','borkar','deepbor@ex.com',4);

Select * from employee;

--DROP PROCEDURE CreateEmployeeWithAddress;
--GO

--PROCEDURE
create procedure [dbo].[CreateEmployeeWithAddress]
@FirstName varchar(100),
@LastName varchar(100),
@Email varchar(100),
@Street varchar(255),
@City varchar(100),
@State varchar(100),
@PostalCode varchar(20)
AS 
BEGIN
DECLARE @AddressID int;
--insert into address table and get the addresssID
Insert into address (Street, City, State, PostalCode) values (@Street, @City, @State, @PostalCode);
Set @AddressID=SCOPE_IDENTITY();
--insert into employee table with the new addresid
insert into EMPLOYEE(FirstName,LastName,Email,AddressID) values (@FirstName, @Lastname, @Email,@AddressID);
end;
go

--PROCEDURE
CREATE PROCEDURE [dbo].[DeleteEmployee]
@EmployeeID INT
AS
BEGIN
DECLARE @AddressID INT;
--Start transaction
BEGIN TRANSACTION;
--Get the AddressID for rollback purposes
SELECT @AddressID = AddressID FROM Employee WHERE EmployeeID = @EmployeeID;
--Delete the Employee record
DELETE FROM Employee WHERE EmployeeID = @EmployeeID;
--Delete the Address record
DELETE FROM Address WHERE AddressID = @AddressID;
--Commit transaction
COMMIT TRANSACTION;
END;
GO

--POCEDURE
CREATE PROCEDURE [dbo].[GetAllEmployees]
AS
BEGIN
SELECT e.EmployeeID, e.FirstName, e.LastName, e.Email, a.Street,a.City, a.State, a. PostalCode
FROM Employee e
INNER JOIN Address a ON e.AddressID = a. AddressID;
END;
GO

DROP PROCEDURE UpdateEmployeelWithAddress;
GO

--PROCEDURE
CREATE PROCEDURE [dbo].[UpdateEmployeelWithAddress]
@EmployeeID INT,
@FirstName VARCHAR(100),
@LastName VARCHAR(100),
@Email VARCHAR(100),
@Street VARCHAR(255),
@City VARCHAR(100),
@State VARCHAR(100),
@PostalCode VARCHAR(28),
@AddressID INT
AS
BEGIN
--Update Address table
UPDATE Address
SET Street = @Street, City = @City, State = @State, PostalCode = @PostalCode
WHERE AddressID = @AddressID;
--Update Employee table
UPDATE Employee
SET FirstName = @FirstName, LastName = @LastName, Email= @Email, AddressID = @AddressID
WHERE EmployeeID = @EmployeeID
END;
Go

--PROCEDURE
CREATE PROCEDURE [dbo].[GetEmployeeByID]
@EmployeeID INT
AS
BEGIN

SELECT e.EmployeeID,e.FirstName,e.LastName,e.Email,a.Street,a.City,a.State,a.PostalCode
FROM Employee e
INNER JOIN Address a 
ON e.AddressID = a.AddressID
WHERE e.EmployeeID = @EmployeeID;
END;
GO

-- Create Employee
EXEC dbo.CreateEmployeeWithAddress
    @FirstName = 'Aman',
    @LastName = 'Verma',
    @Email = 'aman@example.com',
    @Street = '45 Sector 17',
    @City = 'Chandigarh',
    @State = 'Punjab',
    @PostalCode = '160017';
GO

-- Get All Employees
EXEC dbo.GetAllEmployees;
GO

-- Get Employee By ID
EXEC dbo.GetEmployeeByID 
    @EmployeeID = 1;
GO

-- Update Employee
EXEC dbo.UpdateEmployeelWithAddress
    @EmployeeID = 1,
    @FirstName = 'Rahul',
    @LastName = 'Sharma',
    @Email = 'rahul@example.com',
    @Street = 'New Street 45',
    @City = 'Delhi',
    @State = 'Delhi',
    @PostalCode = '110001',
    @AddressID = 1;
GO

-- Delete Employee
EXEC dbo.DeleteEmployee 
    @EmployeeID = 1;
GO