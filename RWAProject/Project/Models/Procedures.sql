create database RWAProject	
go
use RWAProject
go

create table UserRWA 
(
	IDUserRWA int primary key identity,
	Email nvarchar(100),
	UserName nvarchar(20),
	UserPass nvarchar(20)
)
go

create proc CreateUser
	@Email nvarchar(100),
	@UserName nvarchar(20),
	@UserPass nvarchar(20)
as
begin
	set nocount on
	if exists(select IDUserRWA from UserRWA where Email = @Email)
	begin
		select 0
	end
	else
	begin
		insert into UserRwa values(@Email, @UserName, @UserPass)
		select SCOPE_IDENTITY()
	end
end
go

create proc CheckUser
	@Email nvarchar(100),
	@UserPass nvarchar(20)
as
begin
	set nocount on
	if exists (select IDUserRWA from UserRWA where Email = @Email and UserPass = @UserPass)
	begin
		select 1
	end
	else
	begin
		select 0
	end
end
go

use AdventureWorksOBP
go

create proc GetCountries
as
	select * from Drzava
go

create proc GetCountryID
	@buyerID int
as
select d.IDDrzava
	from Kupac as k
	inner join Grad as g on g.IDGrad = k.GradID
	inner join Drzava as d on d.IDDrzava = g.DrzavaID
	where k.IDKupac = @buyerID
go

create proc GetCityID
	@buyerID int
as
select GradID
	from Kupac
	where IDKupac = @buyerID
go

create proc GetCities
	@countryID int
as
	select * from Grad
	where DrzavaID = @countryID
go

create proc DeleteCity
	@IDCity int
as
	delete from Grad
	where IDGrad = @IDCity
go

create proc InsertCity
	@Name nvarchar(50),
	@countryID int
as
	insert into Grad values (@Name, @countryID)
go

create proc GetBuyer
	@IDBuyer int
as
	select k.IDKupac as IDKupac, k.Ime as Ime, k.Prezime as Prezime, k.Email as Email, g.Naziv as Naziv_Grada, d.Naziv as Naziv_Drzave
	from Kupac as k
	inner join Grad as g on g.IDGrad = k.GradID
	inner join Drzava as d on d.IDDrzava = g.DrzavaID
	where k.IDKupac = @IDBuyer
go

create proc GetBuyers
as
	select top 10 k.IDKupac as IDKupac, k.Ime as Ime, k.Prezime as Prezime, k.Email as Email, g.Naziv as Naziv_Grada, d.Naziv as Naziv_Drzave
	from Kupac as k
	inner join Grad as g on g.IDGrad = k.GradID
	inner join Drzava as d on d.IDDrzava = g.DrzavaID
	order by k.IDKupac
go

create proc GetBuyersByCity
	@CityID int
as
	select top 10 k.IDKupac as IDKupac, k.Ime as Ime, k.Prezime as Prezime, k.Email as Email, g.Naziv as Naziv_Grada, d.Naziv as Naziv_Drzave
	from Kupac as k
	inner join Grad as g on g.IDGrad = k.GradID
	inner join Drzava as d on d.IDDrzava = g.DrzavaID
	where k.GradID = @CityID
	order by k.IDKupac
go

create proc GetBillsByBuyer
	@buyerID int
as
	select * from Racun
	where KupacID = @buyerID
go

create proc GetBillDetails
	@IDBill int
as
	select s.IDStavka as ID, p.Naziv as Proizvod, pk.Naziv as Potkategorija, k.Naziv as Kategorija
	from Racun as r
	inner join Stavka as s on s.RacunID = r.IDRacun
	inner join Proizvod as p on p.IDProizvod = s.ProizvodID
	inner join Potkategorija as pk on pk.IDPotkategorija = p.PotkategorijaID
	inner join Kategorija as k on k.IDKategorija = pk.KategorijaID
	where r.IDRacun = @IDBill
go