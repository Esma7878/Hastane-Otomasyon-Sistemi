
create procedure kayitOl
@kullan�c�Ad� varchar(50),
@sifre varchar(50)
as
begin
insert into tbl_login(kullan�c�Ad�,sifre) values(@kullan�c�Ad�,@sifre)
end