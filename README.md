# filmsCrud

with &lt;3 by @yxzhin ^^

## tehnicki zahtevi

Tehnologije:
ASP.NET Core MVC – osnovni framework za aplikaciju
Entity Framework Core – ORM za rad sa bazom podataka
SQL Server ili SQLite – baza podataka

Tabele u bazi podataka:
Film – Naziv, žanr, režiser… (proizvoljno je dodati još polja)
Žanr – Naziv
Režiser – Naziv… (proizvoljno je dodati još polja)
Napomena: jedan film može sadržati više režisera i jedan režiser može imati više filmova

Aplikacija treba da sadrži sledeću funkcionalnost:
CRUD operacije za Filmove (potrebne podatke za žanr i režisera uneti ručno ili kroz seed)
Stranica za pregled svih dostupnih filmova (kartice ili tabelarni prikaz)
Paginacija prilikom pregleda svih filmova

## pokretanje

```bash
docker compose up -d --build
```

- ASP.NET MVC: <http://localhost:8080>
- PostgreSQL:   <http://localhost:5432>
- pgAdmin:      <http://localhost:5050>
