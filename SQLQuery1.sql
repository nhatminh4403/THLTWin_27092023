use QuanLySinhVien
go

create table Student
(
	StudentId nvarchar(50) primary key not null,
	FullName nvarchar (100),
	AverageScore float,
	FacultyID int,
	foreign key(FacultyID) references Faculty
)

create table Faculty
(
	FacultyID int primary key not null,
	FacultyName nvarchar(200)
)

insert into Faculty(FacultyID,FacultyName)
values 
	(1,N'Công nghệ thông tin'),(2,N'Ngôn Ngữ Anh'),(3,N'Quản trị kinh doanh');

insert into Student(StudentId,FullName,AverageScore,FacultyID)
values
	('1611061916',N'Nguyễn Trần Hoàng Lan',4.5,1),
	('1711060596',N'Phạm Trần Nhật Minh',6,1),
	('1711061004',N'Nguyễn Quốc An',6,3);
