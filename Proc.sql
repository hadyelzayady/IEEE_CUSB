use MahmoudMorsy
delimiter //
create PROCEDURE  SearchVoluntByNameWithHistory (IN name varchar(45) )
begin
select * From Volunteer where Name Like CONCAT('%',name,'%');
end//

create PROCEDURE InsertNewVolunteer (IN Name varchar(45),IN Gender char(1),IN National_ID char(14),IN Birthdate date,IN Mobile CHAR(11),IN Job_Title varchar(45),IN Activity_Status int,IN Responsibility_Description varchar(45),IN Mail varchar(45),IN College varchar(45),IN University varchar(45),IN Department varchar(45),IN Graduation_Year YEAR(4),IN Committee_ID int,IN Helping_Comm_ID int )
begin
INSERT INTO Volunteer Values(Name, Gender, National_ID, Birthdate, Mobile, Job_Title, Activity_Status, Responsibility_Description, Mail, College, University, Department, Graduation_Year, Committee_ID, Committee_Season, Helping_Comm_ID);
end