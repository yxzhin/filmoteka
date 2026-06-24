# Filmoteka – Web aplikacija (React + .NET Web API)

> **Verzija zadatka:** 2.0 – React + .NET 9 Web API
> **Prethodna verzija:** C# Console App sa EF Core + SQLite

---

## Cilj

Nadograditi Filmoteka projekat u punopravnu web aplikaciju sa odvojenim backendom (REST API) i frontendom (React SPA). Backend i frontend su **zasebni projekti** koji komuniciraju kroz HTTP.

---

## Tehnologije – **obavezno koristiti tačno ove verzije**

### Backend

| Tehnologija | Verzija | Napomena |
| --- | --- | --- |
| .NET | **9.0** | `dotnet new webapi` |
| ASP.NET Core Web API | 9.0 | Minimal API ili Controller-based (videti ispod) |
| Entity Framework Core | **9.x** | `Microsoft.EntityFrameworkCore` |
| SQL Server | **LocalDB / SQL Server Express 2022** | Connection string ispod |
| Swashbuckle (Swagger) | **7.x** | `Swashbuckle.AspNetCore` |

### Frontend

| Tehnologija | Verzija | Napomena |
| --- | --- | --- |
| Node.js | **22 LTS** | Proveriti sa `node -v` |
| React | **18.x** | |
| TypeScript | **5.x** | Obavezno, ne JS |
| Vite | **5.x** | `npm create vite@latest` |
| React Router | **6.x** | Rutiranje između stranica |
| Axios | **1.x** | HTTP pozivi ka API-ju |

---

## Struktura projekta (folder layout)

```bash
filmoteka/
├── backend/
│   └── Filmoteka.API/
│       ├── Controllers/
│       ├── Data/
│       ├── Models/
│       ├── DTOs/
│       ├── Program.cs
│       └── Filmoteka.API.csproj
└── frontend/
    └── filmoteka-client/
        ├── src/
        │   ├── api/
        │   ├── components/
        │   ├── pages/
        │   ├── types/
        │   └── App.tsx
        ├── package.json
        └── vite.config.ts
```

> **Važno:** Oba foldera (`backend/` i `frontend/`) su u istom Git repozitorijumu.

---

## Baza podataka

### Pokretanje (SQL Server LocalDB)

---

## Pokretanje aplikacije

### Backend

```bash
cd filmoteka/backend/Filmoteka.API
dotnet run
# API radi na: http://localhost:5000
# Swagger UI: http://localhost:5000/swagger
```

### Frontend

```bash
cd filmoteka/frontend/filmoteka-client
npm run dev
# React radi na: http://localhost:5173
```

---

## Swagger

Kada pokreneš backend i odeš na `http://localhost:5000/swagger`, videćeš sve endpointe i možeš ih testirati direktno iz browsera — **bez Postmana**. Ovo je korisno za testiranje API-ja pre nego što povežeš frontend.

---

## Pitanja?

Ako negde zapneš, proveri:

1. Da li CORS radi – u browseru (F12 → Network) ne sme da bude CORS greška
2. Swagger – testirati endpoint pre nego što kreneš sa frontendom
3. Port – backend mora biti na `5000`, frontend na `5173` (Vite default)
