# README.md - használati útmutató

## Projekt áttekintés

A projekt célja egy full-stack webalkalmazás megvalósítása volt, amely bemutatja a modern fejlesztési és üzemeltetési eszközök használatát, beleértve a konténerizációt, CI/CD folyamatokat és Kubernetes alapú futtatást.

---

# Fejlesztési feladatok megoszlása

## Magyar Zsolt János

A projekt során a rendszer alapjainak kialakítása történt meg.

Megvalósításra került:
- Angular alapú frontend
- ASP.NET alapú REST API backend
- Alap funkcionalitás:
  - foglalások létrehozása
  - foglalások listázása
  - foglalások törlése

Docker környezet:
- külön konténerben frontend
- külön konténerben backend
- külön konténerben MongoDB

## Németh Zoltán Zsolt

DevOps és CI/CD feladatok:

- GitHub Actions pipeline kialakása
- Automatikus build minden push esetén
- Docker image-ek feltöltése GHCR-be

Fejlesztések:
- docker-compose átalakítása registry alapú működésre
- reprodukálható deployment
- production-ready környezet

## Vörös Attila Hunor

Backend adatkezelés:

- MongoDB perzisztencia Docker volume használatával
- Seed logika:
  - automatikus szoba létrehozás (50 db)
  - csak üres adatbázis esetén fut le
- Validációk:
  - duplikált foglalások kiszűrése

Eredmény:
- stabil működés
- konzisztens adatállapot
- újraindítás után is megmaradó adatok

## Erdélyi Péter István

Kubernetes környezet:

- teljes deploy konfiguráció elkészítése
- külön kezelve:
  - frontend
  - backend
  - service-ek

MongoDB:
- Helm chart alapú telepítés

Tesztelés:
- Minikube környezetben

---

# Futtatás

## Docker Compose

```bash
git clone https://github.com/nemethzzs/GDE-ALKFET.git
cd GDE-ALKFET
docker compose up -d
```

## Kubernetes

```bash
kubectl apply -f k8s/app/
```

---

# User Guide

## Forráskód elérése

GitHub repository:
https://github.com/nemethzzs/GDE-ALKFET

Klónozás:
```bash
git clone https://github.com/nemethzzs/GDE-ALKFET.git
cd GDE-ALKFET
```

## Az alkalmazás célja

A rendszer egy egyszerű szállodai foglalási alkalmazás, amely lehetővé teszi:

- szobák megtekintését  
- foglalások létrehozását  
- foglalások törlését  

## Futtatás Docker Compose segítségével

```bash
docker compose pull
docker compose up
```

## Elérés

- Frontend: http://localhost:4200  
- Backend: http://localhost:5000  

## Futtatás Kubernetes környezetben

```bash
kubectl apply -f k8s/app/namespace.yaml
kubectl apply -f k8s/app/
kubectl get pods -n hotel-app
kubectl get svc -n hotel-app
```

## Fő funkciók

### Foglalások megtekintése
- „Foglalások betöltése” gomb
- lista megjelenik

### Új foglalás
1. Szoba kiválasztása  
2. Név megadása  
3. Dátum kiválasztása  
4. „Foglalás” gomb  

### Foglalás törlése
- „Törlés” gomb  
- megerősítés után törlés  

## Adatkezelés

- MongoDB adatbázis  
- Docker volume biztosítja a perzisztenciát  

## Seed működés

- 50 szoba automatikusan létrejön  
- csak üres adatbázis esetén fut le  

## Rendszer működése

- Angular frontend → HTTP hívások  
- ASP.NET backend → API logika  
- MongoDB → adat tárolás  
- Docker/Kubernetes → futtatás  

## Összegzés

A rendszer:

- konténerizált  
- Kubernetes kompatibilis  
- CI pipeline-nal automatizált  
- egyszerűen telepíthető és használható  
