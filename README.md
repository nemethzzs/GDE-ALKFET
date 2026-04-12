# Hotel DevOps Project

Ez a projekt egy egyszeru szallodai foglalasi rendszer backend + DevOps alapokkal.

## Projekt celja

A cel egy modern, kontenerizalt alkalmazas letrehozasa, amely:

- REST API-n keresztul kezeli a szobakat es foglalasokat
- MongoDB adatbazist hasznal
- Dockerben futtathato
- Kesobb Kubernetes + ArgoCD kornyezetben deployolhato

## Hasznalt technologiak

- Backend: ASP.NET Core Web API (.NET 8)
- Adatbazis: MongoDB
- Kontenerizacio: Docker, Docker Compose
- API dokumentacio: Swagger (OpenAPI)

## Funkcionalitas

A rendszer kepes:

- Szobak lekerdezesere
- Foglalasok listazasara
- Uj foglalas letrehozasara
- Foglalas torlesere

## API vegpontok

| Method | Endpoint | Leiras |
|--------|---------|--------|
| GET | /api/hotel/szobak | Szobak listazasa |
| GET | /api/hotel/foglalasok | Foglalasok listazasa |
| POST | /api/hotel/foglal | Uj foglalas |
| DELETE | /api/hotel/torles | Foglalas torlese |

## Futtatas lokalisan

### Backend inditasa

cd backend
dotnet run

Swagger elerheto:
http://localhost:5005/swagger

## Docker futtatas

A projekt tartalmaz docker-compose.yml fajlt:

docker compose up --build

Ez elinditja:
- MongoDB
- Backend API

Swagger:
http://localhost:5000/swagger

## Projekt struktura

OOP-szalloda/
│
├-- backend/
│   ├-- Controllers/
│   ├-- Models/
│   ├-- Services/
│   └-- Program.cs
│
├-- docker/
│   └-- backend/
│       └-- Dockerfile
│
├-- docker-compose.yml

## Fejlesztesi workflow

- main → stabil verzio
- Dev → aktiv fejlesztes

Minden uj fejlesztes a Dev branch-be kerul.

