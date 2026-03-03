create database DikshaEmployeedb
use DikshaEmployeedb

drop table Employeetb

create table Employeetb(
EmpId int primary key,
EmpName varchar(20),
EmpDesg varchar(50),
EmpDOJ datetime,
EmpSal int,
EmpDept int
)

insert into Employeetb values
(101,'Krishna','ProjManager','2010-08-07',45000,10),
(102,'Kumari','Manager','2010-08-06',50000,20),
(103,'Amit','Manager','2010-09-07',44000,30)

create Proc SP_DelRec
as
begin
Delete emptb where empno=105
end

--drop proc SPEmp_Insert

create proc sp_DelRecP @Pempno int
as
begin
Delete emptb where empno=@Pempno
end

create proc SPEmp_Insert(@PEmpId int,
@PEmpName varchar(20),@PEmpDesg varchar(50)
,@PEmpDOJ datetime,@PEmpSal int,
@PEmpDept int)
as
Begin
insert into Employeetb values(@PEmpId,
@PEmpName,@PEmpDesg,@PEmpDOJ,@PEmpSal,
@PEmpDept)
end

drop proc SPEmp_Update

create proc SPEmp_Update(@PEmpId int,
@PEmpName varchar(20),@PEmpDesg varchar(50),
@PEmpDOJ datetime,@PEmpSal int,@PEmpDept int)
as
begin
update Employeetb set EmpName=@PEmpName,
EmpDesg=@PEmpDesg,EmpDOJ=@PEmpDOJ,
EmpSal=@PEmpSal,EmpDept=@PEmpDept 
where EmpId=@PEmpId
end

--drop proc SPEmp_Del

create proc SPEmp_Del @PEmpId int
as
begin
Delete Employeetb where EmpId=@PEmpId
end

create proc SPGetSal (@PEmpId int,
@PEmpSal int output)
as begin
Select @PEmpSal=Empsal from Employeetb 
where EmpId=@PEmpId
End

--drop proc SPGetSal

create proc SPGetData @PEmpId int,
@PEmpName varchar(50)Output,
@PEmpDesig varchar(50)Output,
@PEmpDOJ datetime Output,@PEmpSal int Output,
@PEmpDept int Output 
as Begin
select @PEmpName=EmpName,@PEmpDesig=EmpDesg,
@PEmpDOJ=EmpDOJ,@PEmpSal=EmpSal,
@PEmpDept=EmpDept from Employeetb 
where EmpId=@PEmpId
end

--drop proc SPGetData



