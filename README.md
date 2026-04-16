Szálloda – Fullstack és DevOps Projekt
Projekt leírás

Ez a projekt egy egyszerű szállodai foglalási rendszer, amely modern, konténerizált fullstack alkalmazásként lett megvalósítva.

A rendszer lehetővé teszi:

szobák listázását
foglalások létrehozását
foglalások törlését

Az alkalmazás teljes egészében Docker alapú környezetben fut, CI pipeline-nal támogatva.

Technológiák
Frontend: Angular
Backend: ASP.NET (C#)
Adatbázis: MongoDB
Konténerizáció: Docker, Docker Compose
CI/CD: GitHub Actions
Container Registry: GitHub Container Registry (GHCR)
Orchestration: Kubernetes, ArgoCD
Architektúra

A rendszer három fő komponensből áll:

Frontend (Angular, NGINX-en keresztül kiszolgálva)
Backend (ASP.NET REST API)
MongoDB adatbázis (perzisztens tárolással)

A komponensek külön Docker konténerekben futnak, és docker-compose segítségével egyetlen paranccsal elindíthatók.

Telepítés
Repository klónozása
git clone https://github.com/nemethzzs/GDE-ALKFET.git
cd GDE-ALKFET
Indítás
docker compose pull
docker compose up
Elérés
Frontend: http://localhost:4200
Backend API: http://localhost:5000
CI pipeline

A projekt tartalmaz egy GitHub Actions alapú CI pipeline-t.

A pipeline:

automatikusan lefut minden dev branch-re történő push esetén
buildeli a backend és frontend Docker image-eket
feltölti az image-eket a GitHub Container Registry-be

Ez biztosítja a verziózott és reprodukálható build folyamatot.

Docker működés

A rendszer production jelleggel működik:

nincs lokális build futtatás
a docker-compose közvetlenül a registry-ből húzza az image-eket
a frontend buildelt állapotban, NGINX segítségével fut
a backend külön konténerben API-ként működik
Adatkezelés
MongoDB Docker volume használatával
az adatok nem vesznek el a konténer újraindítása után
Seed logika

A backend automatikusan feltölti az adatbázist szobákkal:

összesen 50 szoba kerül létrehozásra
a seed csak akkor fut le, ha az adatbázis üres
így elkerülhető a duplikáció és az adatvesztés
Funkciók
foglalás létrehozása
foglalás validáció
duplikált foglalás tiltása
foglalás törlés
egyszerű Angular felhasználói felület
A fejlesztésben résztvevő személyek
Vörös Attila Hunor
Magyar Zsolt János
Erdélyi Péter István
Németh Zoltán Zsolt
Felelősségi körök
Magyar Zsolt János – frontend és backend fejlesztés
Németh Zoltán Zsolt – CI pipeline, Docker, deployment, GitHub Container Registry integráció
Vörös Attila Hunor – MongoDB perzisztencia, seed logika
Erdélyi Péter István – Kubernetes és ArgoCD megvalósítás
Kisebb hibajavítások, kivételkezelések – közösen
Projekt cél

A cél egy teljes end-to-end rendszer létrehozása volt, amely lefedi:

az alkalmazás fejlesztését
a konténerizációt
a CI pipeline kialakítását
és a futtatható deploymentet
Összegzés

A projekt egy egyszerű üzleti logikát valósít meg, de modern fejlesztési és üzemeltetési eszközökkel.

A rendszer:

automatizált
reprodukálható
konténerizált
és könnyen telepíthető