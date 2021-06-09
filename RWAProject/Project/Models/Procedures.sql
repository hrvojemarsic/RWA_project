create proc GetCountries
as
	select * from Drzava
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