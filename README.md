🏨 Hotel Management Application
📌 Projekt áttekintés

A projekt célja egy full-stack webalkalmazás megvalósítása volt, amely bemutatja a modern fejlesztési és üzemeltetési eszközök használatát, beleértve a konténerizációt, CI/CD folyamatokat és Kubernetes alapú futtatást.

👨‍💻 Fejlesztési feladatok megoszlása
Magyar Zsolt János

A projekt során én raktam le a rendszer alapjait.

Megvalósítottam a teljes frontend és backend alkalmazást, ahol az Angular alapú felhasználói felület kommunikál az ASP.NET alapú REST API-val.

A rendszer képes:

foglalások létrehozására
foglalások listázására
foglalások törlésére

Kialakítottam a kezdeti Docker környezetet is, ahol:

külön konténerben fut a frontend
külön konténerben fut a backend
külön konténerben fut a MongoDB

A docker-compose segítségével a teljes rendszer egyetlen paranccsal indíthatóvá vált.

Ez az architektúra biztos alapot nyújtott a későbbi CI/CD és DevOps bővítésekhez.

Németh Zoltán Zsolt

A projektben a DevOps és CI részért voltam felelős.

A meglévő Docker alapokra építve kialakítottam egy GitHub Actions alapú CI pipeline-t, amely minden dev és main branch-re történő push esetén:

buildeli a frontend és backend Docker image-eket
feltölti azokat a GitHub Container Registry-be (GHCR)

A docker-compose konfigurációt is átalakítottam:

megszüntettem a lokális buildet
a rendszer már a registry-ből húzza az image-eket

Ennek eredményeként a teljes alkalmazás:

reprodukálható módon futtatható
deployment-kész állapotba került
CI/CD szemlélet szerint működik

A frontend production buildként NGINX segítségével kerül kiszolgálásra, míg a backend külön konténerben API-ként fut.

Vörös Attila Hunor

A projekt során a backend adatkezelési részével foglalkoztam.

Megvalósítottam a MongoDB perzisztens működését Docker volume használatával, amely biztosítja, hogy az adatok megmaradjanak a konténerek újraindítása után is.

Kialakítottam a seed logikát is:

az adatbázis automatikusan feltöltődik egy előre definiált szoba listával
a folyamat csak akkor fut le, ha az adatbázis üres
ezáltal elkerülhető a duplikáció
Emellett alap validációk is beépítésre kerültek, például a duplikált foglalások kiszűrésére.

Ennek eredményeként a rendszer:

stabilan működik
konzisztens adatállapotot biztosít
újraindítás után is ugyanabból az állapotból folytatódik
Erdélyi Péter István

A projekt Kubernetes alapú futtatásához elkészítettem a teljes deploy környezetet.

Létrehoztam a szükséges Kubernetes manifest fájlokat, amelyek külön kezelik:

a frontend működését
a backend működését
a hozzájuk tartozó service-eket

A backend konfigurációját úgy alakítottam ki, hogy a MongoDB-hez klaszteren belüli DNS névvel csatlakozzon.

Az adatbázis telepítése modern módon történt:

MongoDB Helm chart segítségével került telepítésre
nem manuális installációval

A teljes rendszer egy lokális Kubernetes klaszteren (Minikube) került tesztelésre.

🚀 Futtatás (Docker Compose)
git clone https://github.com/nemethzzs/GDE-ALKFET.git
cd GDE-ALKFET
docker compose up -d
☸️ Kubernetes futtatás
kubectl apply -f k8s/app/
📌 Összegzés

A projekt egy teljesen működő, konténerizált webalkalmazás, amely:

full-stack architektúrát valósít meg
Docker alapú futtatást biztosít
CI/CD pipeline-t használ
Kubernetes környezetben is deployolható
