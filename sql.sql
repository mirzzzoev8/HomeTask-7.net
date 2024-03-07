create table Employees
(
	Id serial primary key,
	FirstName varchar,
	LastName varchar,
	DepartmentId int references Departments(Id),
	Position varchar,
	Hiredate date
	
);
drop table Departments

create table Departments
(
	Id serial primary key,
	Name varchar
);

create table Salaries
(
	Id serial primary key,
	EmployeeId int references Employees(Id),
	Amount decimal,
	Data date
);