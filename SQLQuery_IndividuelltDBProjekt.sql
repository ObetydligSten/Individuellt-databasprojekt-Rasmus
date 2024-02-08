create View vWNamnBefattningÅr
as
select 
	Concat(FirstName, ' ', Personals.LastName) as Namn,
	Befattning as Befattning,
	YearsService as ÅrPåPlats
from Personals
group by Concat(FirstName, ' ', Personals.LastName), Befattning, YearsService

--View all personal--
select * from vWNamnBefattningÅr



--Fyll i följande för att lägga till Personal--
insert into Personals values (
	/*FirstName*/ '',
	/*LastName*/ '',
	/*Befattning*/ '',
	/*År på plats*/ 0,
	/*Lön*/ 0
	);



create view vWStudentKursBetygLärareDatum
as select
	concat(Students.FirstName, ' ', Students.LastName) as StudentNamn,
	Kurss.KursName as Kurs,
	Grade as Betyg,
	Concat(Personals.FirstName, ' ', Personals.LastName) as LärareNamn,
	GradeSet as Betygsdatum
from Betygs
join Kurss on Betygs.KursId = Kurss.KursId
join Students on Betygs.StudentId = Students.StudentId
join Personals on Betygs.PersonalId = Personals.PersonalId
Group by Kurss.KursName, concat(Students.FirstName, ' ', Students.LastName),Grade,
Concat(Personals.FirstName, ' ', Personals.LastName),GradeSet


--Visa alla satta betyg och av vilken lärare--
select * from vWStudentKursBetygLärareDatum


create view vWSalaryAvgTot
as select 
	Befattning as Befattning,
	avg(Salary) as AverageSalary,
	sum(Salary) as TotalSalary
from Personals
group by befattning



--Se lön per avdelning och totalt--
select * from vWSalaryAvgTot



create proc spStudentInfo
@StudentId int
as
Begin
	select concat(FirstName, ' ', LastName), Class, PersonNr from Students
where StudentId = @StudentId
End


--Hämta en specifik student--
Exec spStudentInfo 1



--Transaction Set Grade on student--
Set Transaction Isolation level Read Uncommitted;
begin try
begin transaction
insert into Betygs (Grade, GradeSet, StudentId, PersonalId, KursId) values(
	/*Grade*/ 3,
	/*DayGraded*/ '2024-02-07',
	/*StudentId*/ 3,
	/*PersonalId*/ 4,
	/*KursId*/ 2
	);
commit transaction

Print 'Grade Set';
End try
Begin Catch
Rollback Transaction
Print 'No grade set';
End catch

select * from vWStudentKursBetygLärareDatum

--View all personal--
select * from vWNamnBefattningÅr

--Fyll i följande för att lägga till Personal--
insert into Personals values (
	/*FirstName*/ '',
	/*LastName*/ '',
	/*Befattning*/ '',
	/*År på plats*/ 0,
	/*Lön*/ 0
	);

--Visa alla satta betyg och av vilken lärare--
select * from vWStudentKursBetygLärareDatum

--Se lön per avdelning och totalt--
select * from vWSalaryAvgTot

--Hämta en specifik student--
Exec spStudentInfo 1