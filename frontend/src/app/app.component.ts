import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HttpClientModule, NgFor, NgIf, FormsModule],
  template: `
    <h1>Hotel app</h1>

    <button (click)="load()">Foglalások betöltése</button>

 <ul *ngIf="data">
  <li *ngFor="let f of data">
    Szoba: {{ f.szobaszam }} |
    Név: {{ f.vendegNev }} |
    Dátum: {{ f.datum }} |
    Ár: {{ f.ar }}

    <button (click)="torol(f)"> Törlés</button>
  </li>
</ul>

    <hr>

    <h3>Új foglalás</h3>

    <input placeholder="Szobaszám" [(ngModel)]="szobaszam">
    <input placeholder="Név" [(ngModel)]="nev">
    <input type="date" [(ngModel)]="datum">

    <button (click)="foglal()">Foglalás</button>
  `
})
export class AppComponent {

  data: any;

  szobaszam: number = 1;
  nev: string = '';
  datum: string = '';

  constructor(private http: HttpClient) {}

  load() {
    this.http.get('http://localhost:5000/api/hotel/foglalasok')
      .subscribe(res => this.data = res);
  }

foglal() {
  this.http.post('http://localhost:5000/api/hotel/foglal', {
    szobaszam: this.szobaszam,
    vendegNev: this.nev,
    datum: this.datum
  }).subscribe({
    next: () => {
      alert("Foglalás sikeres!");
      this.load();
    },
    error: err => {
      alert(err.error); 
    }
  });
}
torol(f: any) {

  if (!confirm("Biztos törlöd?")) return;

  const datum = new Date(f.datum).toISOString().split('T')[0];

  this.http.delete(
    `http://localhost:5000/api/hotel/torles?szobaszam=${f.szobaszam}&datum=${datum}`
  ).subscribe({
    next: () => {
      alert("Foglalás törölve!");
      this.load();
    },
    error: err => {
      console.error(err);
      alert("Hiba történt törléskor!");
    }
  });
}
  };
  