Create database MyDb;

CREATE TABLE Projects (
    GID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    CreateDate Date NOT NULL,
    IsOpened bit default 0,
    FinishDate Date );

insert into Projects (gid,CreateDate, IsOpened) VALUES
('C4EB6A5B-7FE9-4A15-B0F8-5A83AC23626E', SYSDATETIME(), Cast(1 as bit)),
('19E5F0F7-CEF6-4E67-A06B-A387E306FF76', SYSDATETIME(), Cast(1 as bit)),
('00BCDAAB-DFED-4A62-97FA-62C3B1F311FE', SYSDATETIME(), Cast(1 as bit)),
('AB4C9784-8364-48D9-AD02-AD9250244C96', SYSDATETIME(), Cast(1 as bit))
	
CREATE TABLE Employees (
  GID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
  Name varchar (50) Not Null,
  SecondName varchar(50)
)

Insert into Employees (gid, Name, SecondName) values 
('76E01F32-5F50-428A-A6D8-B1FD285AD984','Иван', 'Иванович'),
('DB411777-CCA0-4FCE-966A-6FEB08786A75', 'Пётр', 'Петрович'),
('8543D8EF-2D77-47D8-8F10-1E3E816F7BA5', 'Николай', 'Николаевич'),
('26225826-2233-4211-808E-0F8040B50863', 'Антон', 'Валерьевич')

CREATE TABLE EmployeePositions (
   GID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
   Caption varchar(50) 
)

insert into EmployeePositions (gid, Caption) values 
('E6A0A52D-7C5A-408F-8BB3-2A42A4366937','Project manager'),
('4F052ADB-28B7-4BC2-97C9-9D5069306465','Manager'),
('2AABA79D-3854-4A39-89E2-5557B8A23F63','Developer'),
('51758C39-0328-4BC5-9553-ED86DC9774F3','QA'),
('FC9E238F-37A5-4CEB-9928-76B6F75F54F7','Team lead')

CREATE TABLE ProjectToEmployeeToEmployeePosition
(
   GID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
   ProjectGID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Projects(GID),
   EmployeeGID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Employees(GID),
   EmployeePositionGID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES EmployeePositions(GID)
)
select * from ProjectToEmployeeToEmployeePosition

insert into ProjectToEmployeeToEmployeePosition (gid, ProjectGID, EmployeeGID, EmployeePositionGID) values
(newid(),'19E5F0F7-CEF6-4E67-A06B-A387E306FF76','76E01F32-5F50-428A-A6D8-B1FD285AD984','51758C39-0328-4BC5-9553-ED86DC9774F3'),
(newid(),'19E5F0F7-CEF6-4E67-A06B-A387E306FF76','DB411777-CCA0-4FCE-966A-6FEB08786A75','51758C39-0328-4BC5-9553-ED86DC9774F3'),
(newid(),'C4EB6A5B-7FE9-4A15-B0F8-5A83AC23626E','26225826-2233-4211-808E-0F8040B50863','2AABA79D-3854-4A39-89E2-5557B8A23F63'),
(newid(),'C4EB6A5B-7FE9-4A15-B0F8-5A83AC23626E','76E01F32-5F50-428A-A6D8-B1FD285AD984','4F052ADB-28B7-4BC2-97C9-9D5069306465'),
(newid(),'C4EB6A5B-7FE9-4A15-B0F8-5A83AC23626E','DB411777-CCA0-4FCE-966A-6FEB08786A75','2AABA79D-3854-4A39-89E2-5557B8A23F63'),
(newid(),'C4EB6A5B-7FE9-4A15-B0F8-5A83AC23626E','8543D8EF-2D77-47D8-8F10-1E3E816F7BA5','51758C39-0328-4BC5-9553-ED86DC9774F3'),
(newid(),'19E5F0F7-CEF6-4E67-A06B-A387E306FF76','26225826-2233-4211-808E-0F8040B50863','2AABA79D-3854-4A39-89E2-5557B8A23F63'),
(newid(),'19E5F0F7-CEF6-4E67-A06B-A387E306FF76','8543D8EF-2D77-47D8-8F10-1E3E816F7BA5','51758C39-0328-4BC5-9553-ED86DC9774F3'),
(newid(),'00BCDAAB-DFED-4A62-97FA-62C3B1F311FE','76E01F32-5F50-428A-A6D8-B1FD285AD984','4F052ADB-28B7-4BC2-97C9-9D5069306465'),
(newid(),'00BCDAAB-DFED-4A62-97FA-62C3B1F311FE','8543D8EF-2D77-47D8-8F10-1E3E816F7BA5','FC9E238F-37A5-4CEB-9928-76B6F75F54F7'),
(newid(),'AB4C9784-8364-48D9-AD02-AD9250244C96','76E01F32-5F50-428A-A6D8-B1FD285AD984','4F052ADB-28B7-4BC2-97C9-9D5069306465'),
(newid(),'AB4C9784-8364-48D9-AD02-AD9250244C96','DB411777-CCA0-4FCE-966A-6FEB08786A75','2AABA79D-3854-4A39-89E2-5557B8A23F63'),
(newid(),'AB4C9784-8364-48D9-AD02-AD9250244C96','8543D8EF-2D77-47D8-8F10-1E3E816F7BA5','51758C39-0328-4BC5-9553-ED86DC9774F3'),
(newid(),'AB4C9784-8364-48D9-AD02-AD9250244C96','26225826-2233-4211-808E-0F8040B50863','FC9E238F-37A5-4CEB-9928-76B6F75F54F7')


CREATE TABLE TaskStates (
  GID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
  Caption varchar (255)
)

insert into TaskStates (gid, Caption) values 
('651A3BDD-EAE1-401D-8E4B-8754C63B3612','Открыта'),
('3C4FB116-05A1-48DA-A48F-F7284438DF01','Выполнена'),
('13229F04-1C24-478D-BB00-92652952C974','Требует доработки'),
('292F04E7-0BCA-4119-82D2-CA0D9D63311F','Принята(закрыта)')

CREATE TABLE ProjectTasks (
  GID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
  ProjectToEmployeeToPositionGID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ProjectToEmployeeToEmployeePosition(GID),
  TaskCaption varchar (255),
  TaskStateGID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TaskStates(GID),
  DeadLine Date,
  FinishDate Date,
  AcceptorGID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Employees(GID)
)


insert into ProjectTasks (GID,ProjectToEmployeeToPositionGID ,TaskCaption, TaskStateGID, DeadLine) values 
(newid(),'2D95A4BC-CF9B-4105-859D-19D94B85BA2A','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191015'),
(newid(),'2287DFC1-21CF-402E-A1DC-2378CF216A2E','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191015'),
(newid(),'2D95A4BC-CF9B-4105-859D-19D94B85BA2A','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191125'),
(newid(),'2287DFC1-21CF-402E-A1DC-2378CF216A2E','Do smth','3C4FB116-05A1-48DA-A48F-F7284438DF01','20191101'),
(newid(),'2287DFC1-21CF-402E-A1DC-2378CF216A2E','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191129'),
(newid(),'93A88242-E821-4414-917A-2E25E571353B','Do smth','13229F04-1C24-478D-BB00-92652952C974','20191101'),
(newid(),'13A73642-1199-4276-817F-41C3797D1A9D','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191125'),
(newid(),'160D940C-C67B-4C5D-9008-45E265840A9B','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191125'),
(newid(),'160D940C-C67B-4C5D-9008-45E265840A9B','Do smth','292F04E7-0BCA-4119-82D2-CA0D9D63311F','20191101'),
(newid(),'2F9784DC-1AFC-4C33-8C09-50591B51B999','Do smth','292F04E7-0BCA-4119-82D2-CA0D9D63311F','20191125'),
(newid(),'ACA4480F-07D4-4C4F-A260-590E232A4117','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191125'),	
(newid(),'ACA4480F-07D4-4C4F-A260-590E232A4117','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191127'),
(newid(),'191DDBEB-E4D8-4EEB-A64E-67D199E2CB99','Do smth','13229F04-1C24-478D-BB00-92652952C974','20191101'),
(newid(),'F9714FF6-D9FD-4402-BCC2-7A1C1E0E768F','Do smth','13229F04-1C24-478D-BB00-92652952C974','20191125'),
(newid(),'3F6DCB79-6092-43DA-9DA1-7D98EC9ACC86','Do smth','3C4FB116-05A1-48DA-A48F-F7284438DF01','20191125'),
(newid(),'1775FBFA-CB02-45B5-B7E8-87C5E4604168','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191125'),
(newid(),'CB3E795D-2B42-478A-ACBA-0CAE57260C3F','Do smth','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191125')



--1
select ep.Caption, Count(ep.Caption) from EmployeePositions ep 
inner join ProjectToEmployeeToEmployeePosition peep on ep.gid = peep.EmployeePositionGID
group by ep.Caption


--2
select ep.Caption from EmployeePositions ep 
where ep.GID not in (select EmployeePositionGID from ProjectToEmployeeToEmployeePosition)

--3
select p.gid, ep.Caption, Count (*) from Projects p 
inner join ProjectToEmployeeToEmployeePosition peep on p.gid = peep.ProjectGID
inner join EmployeePositions ep on ep.GID =peep.EmployeePositionGID
group by p.GID, ep.Caption
order by p.GID

--4

select peep.ProjectGID,
(Cast (Count(peep.ProjectGID) as float) / Cast (Count(Distinct peep.EmployeeGID) as float)) as TaskPerEmployee
from ProjectToEmployeeToEmployeePosition peep 
Inner join ProjectTasks pt on pt.ProjectToEmployeeToPositionGID = peep.GID
group by peep.ProjectGID

--5
select DATEDIFF(day, CreateDate, finishdate ) from Projects

--6
select e.GID, e.Name, Count(e.Name) as TaskCount 
from Employees e
Left join ProjectToEmployeeToEmployeePosition peep on peep.EmployeeGID = e.GID
inner join ProjectTasks pt on pt.ProjectToEmployeeToPositionGID = peep.GID
where pt.TaskStateGID != '292F04E7-0BCA-4119-82D2-CA0D9D63311F' 
Group by e.GID, e.Name
Having Count(e.Name) = (select TOP 1 Count(e1.Name) from Employees e1
					Left join ProjectToEmployeeToEmployeePosition peep1 on peep1.EmployeeGID = e1.GID
					inner join ProjectTasks pt1 on pt1.ProjectToEmployeeToPositionGID = peep1.GID
					where pt1.TaskStateGID != '292F04E7-0BCA-4119-82D2-CA0D9D63311F'
					group by e1.Name
					order by Count(e1.Name) )  
order by e.Name

--7 
select e.GID,e.Name,e.SecondName, Count(e.Name) as TaskCount 
from Employees e
Left join ProjectToEmployeeToEmployeePosition peep on peep.EmployeeGID = e.GID
inner join ProjectTasks pt on pt.ProjectToEmployeeToPositionGID = peep.GID
where pt.TaskStateGID != '292F04E7-0BCA-4119-82D2-CA0D9D63311F' AND pt.DeadLine < SYSDATETIME()
Group by e.GID, e.Name,e.SecondName
Having Count(e.Name) = (select TOP 1 Count(e1.Name) from Employees e1
					Left join ProjectToEmployeeToEmployeePosition peep1 on peep1.EmployeeGID = e1.GID
					inner join ProjectTasks pt1 on pt1.ProjectToEmployeeToPositionGID = peep1.GID
					where pt1.TaskStateGID != '292F04E7-0BCA-4119-82D2-CA0D9D63311F' AND pt1.DeadLine < SYSDATETIME()
					group by e1.Name
					order by Count(e1.Name) Desc )  
order by e.Name


--8
update ProjectTasks set DeadLine = DATEADD(day,5 , DeadLine)
where DeadLine < SYSDATETIME()

--9
select p.GID, Count (p.Gid) from Projects p 
inner join ProjectToEmployeeToEmployeePosition peep on peep.ProjectGID = p.GID
left join ProjectTasks pt on pt.ProjectToEmployeeToPositionGID = peep.GID
where pt.TaskStateGID = '651A3BDD-EAE1-401D-8E4B-8754C63B3612'
Group by p.GID	

--10
update Projects set IsOpened=cast(0 as bit), FinishDate ='20191102' where gid =''

select p.GID, pt.FinishDate from Projects p
inner join ProjectToEmployeeToEmployeePosition pte on pte.ProjectGID = p.gid
inner join ProjectTasks pt on pt.ProjectToEmployeeToPositionGID = pte.gid and pt.TaskStateGID = '292F04E7-0BCA-4119-82D2-CA0D9D63311F'
left join ProjectTasks pt1 on pt1.ProjectToEmployeeToPositionGID = pte.gid and pt1.TaskStateGID <> '292F04E7-0BCA-4119-82D2-CA0D9D63311F'
where pt1.GID is null
order by pt.FinishDate


update Projects set Projects.IsOpened = cast(0 as bit), Projects.FinishDate = temp.finishdate 
from 
(select p.GID, pt.FinishDate from Projects p
inner join ProjectToEmployeeToEmployeePosition pte on pte.ProjectGID = p.gid
inner join ProjectTasks pt on pt.ProjectToEmployeeToPositionGID = pte.gid and pt.TaskStateGID = '292F04E7-0BCA-4119-82D2-CA0D9D63311F'
left join ProjectTasks pt1 on pt1.ProjectToEmployeeToPositionGID = pte.gid and pt1.TaskStateGID <> '292F04E7-0BCA-4119-82D2-CA0D9D63311F'
where pt1.GID is null
order by pt.FinishDate) as temp
where Projects.gid = temp.GID

--11
insert into Employees (gid,Name, SecondName) values ('17A9D7F4-A9F2-4E40-91E2-2BC4CCD424A2','Сотрудник','без незакрытых задач')
insert into ProjectToEmployeeToEmployeePosition (gid, ProjectGID, EmployeeGID, EmployeePositionGID) values (newid(),'C4EB6A5B-7FE9-4A15-B0F8-5A83AC23626E','17A9D7F4-A9F2-4E40-91E2-2BC4CCD424A2','4F052ADB-28B7-4BC2-97C9-9D5069306465')

select * from Employees e 
inner join ProjectToEmployeeToEmployeePosition  peep on peep.EmployeeGID = e.GID
Left join ProjectTasks pt on peep.GID=pt.ProjectToEmployeeToPositionGID
Where ( pt.TaskStateGID is NULL OR pt.TaskStateGID = '292F04E7-0BCA-4119-82D2-CA0D9D63311F')
 AND  not exists (select pt1.TaskStateGID from ProjectToEmployeeToEmployeePosition peep1
				  left join ProjectTasks pt1 on pt1.ProjectToEmployeeToPositionGID = peep.GID
			      where peep1.gid = e.GID AND (pt1.TaskStateGID = '651A3BDD-EAE1-401D-8E4B-8754C63B3612'
										    	OR pt1.TaskStateGID = '3C4FB116-05A1-48DA-A48F-F7284438DF01'
										    	OR pt1.TaskStateGID = '13229F04-1C24-478D-BB00-92652952C974'))

	
--12
select peep.EmployeeGID, peep.GID, Count(pt.GID) as TaskCount from ProjectToEmployeeToEmployeePosition peep 
left join ProjectTasks pt on pt.ProjectToEmployeeToPositionGID = peep.GID
where peep.ProjectGID = 'C4EB6A5B-7FE9-4A15-B0F8-5A83AC23626E'
group by peep.EmployeeGID,peep.GID
order by Count(pt.GID) 

insert into ProjectTasks (gid,ProjectToEmployeeToPositionGID,TaskCaption,TaskStateGID,DeadLine)
values (newid(),'','New task','651A3BDD-EAE1-401D-8E4B-8754C63B3612','20191202')





