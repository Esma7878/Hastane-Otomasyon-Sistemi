
create procedure kayitOl
@kullanıcıAdı varchar(50),
@sifre varchar(50)
as
begin
insert into tbl_login(kullanıcıAdı,sifre) values(@kullanıcıAdı,@sifre)
end