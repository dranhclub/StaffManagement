drop database if exists HR
create database HR
go

use HR
go

drop table if exists Users;
drop table if exists Employee;
drop table if exists Position;
drop table if exists Department;
drop table if exists Absence;
drop table if exists Attendance;
drop table if exists General;
 
------------------Users table---------------------
create table Users(
	username nvarchar(20) primary key,
	password nvarchar(20) not null,
	privilege nvarchar(15) not null,
	eid int,

);

insert into Users values 
('admin', 'admin', 'admin', null);
go
  
go
------------------Employee table---------------------
create table Employee(
	id int identity(1,1) primary key,
	name nvarchar(30) not null,
	gender nvarchar(10) not null,
	id_number char(9) unique,
	photo nvarchar(40) default 'avatar.png',
	birth date,
	addr nvarchar(100),
	email varchar(40),
	phone varchar(13),
	married bit,
	department_id int,
	position_id int
);

create table Department(
	id int identity(1,1) primary key,
	name nvarchar(30) not null
);


create table Position(
	id int identity(1,1) primary key,
	name nvarchar(30) not null
);

alter table Employee add foreign key (department_id) references Department(id);
alter table Employee add foreign key (position_id) references Position(id);

insert into Department(name) values
('Technical Department'),
('Design department'),
('Accounting department');

insert into Position(name) values
('Official staff'),
('Probationary staff'),
('Collaborators'),
('Deputy'),
('Manager'),
('Accountant')

------------------Auto add, update, delete user trigger---------------------

alter table Users add foreign key (eid) references Employee(id);
go

create trigger auto_create_user on Employee for INSERT AS
insert into Users(username, password, privilege, eid) 
select i.id_number, i.id_number, 'employee', i.id
from inserted i
go

create trigger auto_update_user on Employee for UPDATE as
update Users 
set username = (select id_number from inserted)
where eid = (select id from inserted)
go

create trigger auto_delete_user on Employee for DELETE as
delete from Users 
where eid = (select id from inserted)
go

------------------Insert value into Employee table---------------------

insert into Employee(name, gender, id_number, birth, addr, email, phone, married, department_id, position_id) values
('James V Loomis', 'male', '000000001', '1/16/1979', '3340 Park Boulevard', 'elvis_howel9@yahoo.com', '0123456789', 1, 1, 1),
('Joe I Cruz', 'male', '000000002', '7/26/1991', '986 Hillcrest Drive', 'noemie.emar9@yahoo.com', '315-622-7377', 1, 1, 1),
('Phillip W Roman', 'male', '121452369', '8/26/1996', '4840 Round Table Drive', 'elvera_windl@gmail.com', '929-232-3354', 0, 1, 1),
('Danny D Hyden', 'male', '154789654', '11/20/1983', '682 Plainfield Avenue', 'susan_damor10@yahoo.com', '929-232-3354', 0, 1, 1),
('Linda D Herrington', 'female', '123474541', '3/13/1989', '3181 Charter Street', 'dawson_stam3@hotmail.com', '913-646-8508', 0, 1, 1),
('Johnnie M Shibata', 'female', '141589564', '2/7/1991', '3954 Freshour Circle', 'jarod.ankundi@yahoo.com', '210-608-5223', 0, 1, 1),
('Michael D Hoffman', 'male', '145412774', '11/18/1980', '2774 Crowfield Road', 'nestor2001@yahoo.com', '602-823-1270', 1, 1, 1),
('David A Hart', 'male', '151619879', '8/26/1976', '4940 Williams Avenue', 'kiel2012@yahoo.com', '619-200-1276', 1, 1, 1),

('Tracey K Martinez', 'male', '135145614', '7/26/1986', '4684 Elk Avenue', 'justen1976@yahoo.com', '517-202-9385', 0, 2, 1),
('Donald A Herndon', 'male', '154784156', '4/16/1990', '4037 Lena Lane', 'brandy1976@yahoo.com', '601-287-1948', 1, 2, 1),
('Erika C Hernandez', 'female', '154135498', '9/23/1997', '1987 Melody Lane', 'angus2009@gmail.com', '434-203-4983', 0, 2, 1),
('Erika C Hernandez', 'female', '195462388', '6/28/1983', '4290 Hog Camp Road', 'jeramy1977@gmail.com', '847-878-1068', 1, 2, 1),
('Kelly A Slusher', 'female', '145463285', '4/1/1974', '2318 Benedum Drive', 'jazmyne1972@gmail.com', '914-443-5240', 1, 2, 1),
('Shelly M Phillips', 'female', '142232178', '3/28/1988', '130 Carriage Lane', 'marcus_ledn@yahoo.com', '215-363-7710', 0, 2, 1),
('Benjamin L Loftin', 'male', '195989879', '10/23/1990', '4002 Rainbow Road', 'peter2005@gmail.com', '916-412-4941', 0, 2, 1),
('Patricia E Holtz', 'female', '145465465', '11/5/1980', '3010 Woodside Circle', 'ricky1991@yahoo.com', '407-929-1285', 1, 2, 1),

('Karen R Halverson', 'female', '154878786', '7/30/1988', '922 Pallet Street', 'demetris_doy@gmail.com', '914-442-5057', 1, 3, 1),
('Deena J Tull', 'female', '132305685', '1/31/1997', '2744 Maxwell Farm Road', 'armand1987@hotmail.com', '757-652-6978', 0, 3, 1),
('Leroy B King', 'male', '149630658', '6/17/1987', '151 Hope Street', 'cale.osinsk6@hotmail.com', '503-708-5674', 1, 3, 1),
('Robert D Ibarra', 'male', '105986745', '4/24/1983', '4562 Flynn Street', 'zackary.langwor@yahoo.com', '440-489-6315', 1, 3, 1),
('Felecia L Lake', 'female', '102356987', '11/15/1985', '4251 Tavern Place', 'eleazar.grim@yahoo.com', '970-200-0739', 1, 3, 1),
('Ronald N Brogden', 'male', '154695231', '7/15/1980', '1115 Hershell Hollow Road', 'ashlee.bin5@hotmail.com', '425-306-3271', 1, 3, 1),
('Celeste M Dodge', 'female', '136598765', '9/11/1989', '3214 Dovetail Estates', 'betsy.kemme4@gmail.com', '580-275-4750', 0, 3, 1),
('Ronda R Murdock', 'female', '123987987', '9/24/1993', '2850 College Avenue', 'luisa2007@gmail.com', '937-361-0924', 0, 3, 1),
('Richard R Selby', 'male', '154545603', '10/19/1981', '4928 Parkview Drive', 'sean.beaha5@hotmail.com', '213-393-3112', 1, 3, 1);


------------------Basic salary table---------------------
create table BasicSalary(
	eid int not null,
	y int not null,
	m int not null,
	basic_salary int not null,

	primary key (eid, y, m),
	foreign key (eid) references Employee(id)
);
insert into BasicSalary values
(1, 2022, 1, 2000),
(2, 2022, 1, 2000),
(3, 2022, 1, 2000),
(4, 2022, 1, 2000),
(5, 2022, 1, 2000),
(6, 2022, 1, 2000),
(7, 2022, 1, 2000),
(8, 2022, 1, 2000),
(9, 2022, 1, 2000),
(10, 2022, 1, 2000),
(11, 2022, 1, 2000),
(12, 2022, 1, 2000),
(13, 2022, 1, 2000),
(14, 2022, 1, 2000),
(15, 2022, 1, 2000),
(16, 2022, 1, 2000),
(17, 2022, 1, 2000),
(18, 2022, 1, 2000),
(19, 2022, 1, 2000),
(20, 2022, 1, 2000),
(21, 2022, 1, 2000),
(22, 2022, 1, 2000),
(23, 2022, 1, 2000),
(24, 2022, 1, 2000),
(25, 2022, 1, 2000),
(1, 2022, 2, 2000),
(2, 2022, 2, 2000),
(3, 2022, 2, 2000),
(4, 2022, 2, 2000),
(5, 2022, 2, 2000),
(6, 2022, 2, 2000),
(7, 2022, 2, 2000),
(8, 2022, 2, 2000),
(9, 2022, 2, 2000),
(10, 2022, 2, 2000),
(11, 2022, 2, 2000),
(12, 2022, 2, 2000),
(13, 2022, 2, 2000),
(14, 2022, 2, 2000),
(15, 2022, 2, 2000),
(16, 2022, 2, 2000),
(17, 2022, 2, 2000),
(18, 2022, 2, 2000),
(19, 2022, 2, 2000),
(20, 2022, 2, 2000),
(21, 2022, 2, 2000),
(22, 2022, 2, 2000),
(23, 2022, 2, 2000),
(24, 2022, 2, 2000),
(25, 2022, 2, 2000),
(1, 2022, 3, 2000),
(2, 2022, 3, 2000),
(3, 2022, 3, 2000),
(4, 2022, 3, 2000),
(5, 2022, 3, 2000),
(6, 2022, 3, 2000),
(7, 2022, 3, 2000),
(8, 2022, 3, 2000),
(9, 2022, 3, 2000),
(10, 2022, 3, 2000),
(11, 2022, 3, 2000),
(12, 2022, 3, 2000),
(13, 2022, 3, 2000),
(14, 2022, 3, 2000),
(15, 2022, 3, 2000),
(16, 2022, 3, 2000),
(17, 2022, 3, 2000),
(18, 2022, 3, 2000),
(19, 2022, 3, 2000),
(20, 2022, 3, 2000),
(21, 2022, 3, 2000),
(22, 2022, 3, 2000),
(23, 2022, 3, 2000),
(24, 2022, 3, 2000),
(25, 2022, 3, 2000);

------------------Absence table---------------------
create table Absence(
	eid int not null,
	date date not null,

	primary key (eid, date),
	foreign key (eid) references Employee(id)
);

insert into Absence(eid, date) values
(1, '2022/02/24'),
(1, '2022/02/26'),
(2, '2022/02/26'),
(2, '2022/03/06'),
(3, '2022/03/09'),
(5, '2022/03/04'),
(7, '2022/03/03'),
(14, '2022/03/02'),
(15, '2022/03/09'),
(22, '2022/03/01');

------------------Overtime table---------------------
create table Overtime(
	eid int not null,
	date date not null,

	primary key (eid, date),
	foreign key (eid) references Employee(id)
);

insert into Overtime(eid, date) values
(1, '2022/02/24'),
(1, '2022/02/26'),
(2, '2022/03/25'),
(8, '2022/03/06');

------------------General table---------------------
create table General(
	y int not null,
	m int not null,
	post_subsidy int not null default 100,	
	house_allowance int not null default 100,
	transport_allowance int not null default 100,
	attendance_bonus int not null default 100,
	overtime_rate int not null default 20,

	social_security int not null default 100,
	provident_fund int not null default 100,
	pension int not null default 100,
	injury_insurance int not null default 100,

	check (y >= 2022 and y <= 2023),
	check (m >= 1 and m <= 12),
	primary key (y, m)
);

insert into General(
	y, m, 
	post_subsidy, house_allowance, transport_allowance, attendance_bonus, overtime_rate,
	social_security, provident_fund, pension, injury_insurance) 
	values
	(2022, 1, 90, 90, 90, 90, 20, 50, 40, 30, 20),
	(2022, 2, 90, 90, 100, 100, 20, 51, 41, 31, 20),
	(2022, 3, 100, 100, 100, 100, 20, 52, 42, 32, 20);

go

------------------Allowances view---------------------
create view Allowance1 as
select 
	e.id, e.name, g.y, g.m,
	g.overtime_rate, g.attendance_bonus,
	g.house_allowance, g.post_subsidy, g.transport_allowance
from Employee e, General g
go

create view Allowance2 as
select a.*, count(date) as overtime_count from 
Allowance1 a left join Overtime ot
on a.id = ot.eid and a.y = year(ot.date) and a.m = month(ot.date)
group by id, name, y, m, overtime_rate, attendance_bonus, house_allowance, post_subsidy, transport_allowance
go

create view Allowance3 as
select a.*, count(date) as absence_count from 
Allowance2 a left join Absence ab 
on a.id = ab.eid and y=year(ab.date) and m=month(ab.date)
group by id, name, y, m, overtime_rate, attendance_bonus, house_allowance, post_subsidy, transport_allowance, overtime_count
go

create view Allowance4 as
select 
	id, name, y, m, 
	house_allowance, post_subsidy, transport_allowance,
	overtime_rate * overtime_count as overtime_pay,
	case when absence_count <= 3 then attendance_bonus else 0 end as attendance_bonus
from Allowance3
go

create view Allowance as
select id, name, y, m, house_allowance, post_subsidy, transport_allowance, overtime_pay, attendance_bonus,
house_allowance + post_subsidy + transport_allowance + overtime_pay + attendance_bonus as total
from Allowance4
go

------------------Deduction view---------------------
go
create view AbsenceCount as
select 
	e.id, year(ab.date) as y, month(ab.date) as m, count(ab.date) as absence_count
from Employee e left join Absence ab
on e.id = ab.eid
group by e.id, year(ab.date), month(ab.date)

go
create view Deduction1 as
select 
	e.id, b.y, b.m,
	g.social_security, g.provident_fund, g.pension, g.injury_insurance,
	b.basic_salary
from Employee e, General g, BasicSalary b
where e.id = b.eid and g.y = b.y and g.m = b.m

go
create view Deduction2 as
select d.*, 
	case 
		when ac.absence_count is null then 0 
		else ac.absence_count 
	end as absence_count
from Deduction1 d left join AbsenceCount ac
on ac.id = d.id and ac.y = d.y and ac.m = d.m

go
create view Deduction3 as
select 
	id, y, m, social_security, provident_fund, pension, injury_insurance,
	basic_salary / 30 * absence_count as absence
from Deduction2

go
create view Deduction as
select *, social_security + provident_fund + pension + injury_insurance + absence as total from Deduction3

------------------Payroll view---------------------
go
create view Payroll as
select a.id, a.y, a.m, b.basic_salary, a.total as allowance, d.total as deduction, 
	(b.basic_salary + a.total - d.total) as salary
from Allowance a, Deduction d, BasicSalary b
where a.id = d.id and a.y = d.y and a.m = d.m 
	and b.eid = a.id and b.y = a.y and b.m = a.m