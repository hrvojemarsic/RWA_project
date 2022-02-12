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

create proc UpdateBuyer
	@IDBuyer int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Tel nvarchar(25),
	@CityID int
as
begin
	update Kupac set Ime = @FirstName, Prezime = @LastName, Email = @Email, Telefon = @Tel, GradID = @CityID
	where IDKupac = @IDBuyer
end
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

create proc GetCategories
as
	select * from Kategorija
go

create proc GetCategory
	@IDCategory int
as
	select * from Kategorija where IDKategorija = @IDCategory
go

create proc CreateCategory
	@Name nvarchar(50)
as
	insert into Kategorija values (@Name)
go

create proc UpdateCategory
	@IDCategory int,
	@Name nvarchar(50)
as
begin
	update Kategorija set Naziv = @Name
	where IDKategorija = @IDCategory
end
go

create proc DeleteCategory
	@IDCategory int
as
begin
	delete from Kategorija
	where IDKategorija = @IDCategory
end
go

create proc GetSubCategories
as
	select * from Potkategorija
go

create proc GetSubCategory
	@IDSubCategory int
as
begin
	select * from Potkategorija
	where IDPotkategorija = @IDSubCategory
end
go

create proc CreateSubCategory
	@categoryID int,
	@name nvarchar(50)
as
begin
	insert into Potkategorija values (@categoryID, @name)
end
go

create proc UpdateSubCategory
	@IDSubCategory int,
	@categoryID int,
	@name nvarchar(50)
as
begin
	update Potkategorija
	set KategorijaID = @categoryID, Naziv = @name
	where  IDPotkategorija = @IDSubCategory
end
go

create proc DeleteSubCategory
	@IDSubCategory int
as
begin
	delete from Potkategorija
	where IDPotkategorija = @IDSubCategory
end
go

create proc GetProducts
as
begin
	select * from Proizvod
end
go

create proc GetProduct
	@IDProduct int
as
begin
	select * from Proizvod
	where IDProizvod = @IDProduct
end
go

create proc CreateProduct
	@Name nvarchar(50),
	@ProductNumber nvarchar(25),
	@Color nvarchar(15),
	@MinQuantityAtLager smallint,
	@PriceWithoutPDV money,
	@SubcategoryID int
as
begin
	insert into Proizvod
	values (@Name, @ProductNumber, @Color, @MinQuantityAtLager, @PriceWithoutPDV, @SubcategoryID)
end
go

create proc UpdateProduct
	@IDProduct int,
	@Name nvarchar(50),
	@ProductNumber nvarchar(25),
	@Color nvarchar(15),
	@MinQuantityAtLager smallint,
	@PriceWithoutPDV money,
	@SubcategoryID int
as
begin
	update Proizvod
	set Naziv = @Name, BrojProizvoda = @ProductNumber, Boja = @Color, MinimalnaKolicinaNaSkladistu = @MinQuantityAtLager, CijenaBezPDV = @PriceWithoutPDV, PotkategorijaID = @SubcategoryID
	where IDProizvod = @IDProduct
end
go

create proc DeleteProduct
	@IDProduct int
as
begin
	delete from Proizvod
	where IDProizvod = @IDProduct
end
go

create proc GetKupci
as
begin
	select * from Kupac
end
go

create proc GetKupac
	@IDBuyer int
as
begin
	select * from Kupac
	where IDKupac = @IDBuyer
end
go

create proc InsertKupac
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Tel nvarchar(25),
	@CityID int
as
begin
	insert into Kupac
	values (@FirstName, @LastName, @Email, @Tel, @CityID)
end
go

create proc DeleteKupac
	@IDBuyer int
as
begin
	delete from Kupac
	where IDKupac = @IDBuyer
end
go