use viettravelproapi;

select * from city;
insert into city(Name, Description, Pictures, TitleIntroduct, ContentIntroduct)
values (N'TP Hà Nội', N'TP Hà Nội', N'hanoi.jpg', N'TP Hà Nội', N'TP Hà Nội');

select * from evaluate;
insert into evaluate(NumberOfEvaluate, MediumStar)
values(0,0);

select * from dbo.[user];
INSERT INTO [dbo].[user]([Username],[Password],[Name],[DateOfBirth],[Sex],[Email],[PhoneNumber],[Address],[Role])
VALUES ('quangnam@gmail.com','QuangNam',N'Bùi Quang Nam','2001/10/10',N'Nam','quangnam@gmail.com','0362793528',N'Thanh Xuân - Hà Nội', 'User')
INSERT INTO [dbo].[user]([Username],[Password],[Name],[DateOfBirth],[Sex],[Email],[PhoneNumber],[Address],[Role])
VALUES ('thuylinh@gmail.com','ThuyLinh',N'Nguyễn Ngọc Thùy Linh','2002/10/10',N'Nữ','thuylinh@gmail.com','0367243558',N'Thanh Xuân - Hà Nội', 'User')

select * from hotel;
insert into hotel(Name, Address, PhoneNumber, Description, TitleIntroduct, ContentIntroduct)
values (N'Khách sạn Quảng Ninh 1', N'TP Quảng Ninh', '0398889898', N'Khách sạn Quảng Ninh 1', N'Khách sạn Quảng Ninh 1', N'Khách sạn Quảng Ninh 1');
insert into hotel(Name, Address, PhoneNumber, Description, TitleIntroduct, ContentIntroduct)
values (N'Khách sạn Quảng Ninh 2',N'TP Quảng Ninh', '0398888989', N'Khách sạn Quảng Ninh 2', N'Khách sạn Quảng Ninh 2', N'Khách sạn Quảng Ninh 2');


select * from timepackage;
insert into timepackage (Name, Description)
values (N'3N2D', N'Gói 3 ngày 2 đêm');
insert into timepackage (Name, Description)
values (N'4N3D', N'Gói 4 ngày 3 đêm');
insert into timepackage (Name, Description)
values (N'5N4D', N'Gói 5 ngày 4 đêm');

select * from tour;
insert into tour(Name, Address, Description, Pictures, TitleIntroduct, ContentIntroduct, CityId, EvaluateId)
values (N'TOUR HẠ LONG', N'HẠ LONG', N'TOUR HẠ LONG', N'halong.png', N'TOUR HẠ LONG', N'TOUR HẠ LONG', 1, 1);


select * from tourpackage;
insert into tourpackage(Name, StartTime, EndTime, Description, NumberOfAdult, NumberOfChildren
, TotalPrice, TourId, HotelId, TimePackageId)
values(N'Gói mặc định', '2023/12/12', '2023/12/15', N'Gói mặc định', 2, 0, 12000000.00, 1, 1, 1);

select * from ticket;
insert into ticket(BookingDate, Description, TourPackageId, UserId)
values ('2023/10/10', null, 4, 1);