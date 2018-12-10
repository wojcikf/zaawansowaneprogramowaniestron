import { Component } from "@angular/core"

@Component({
  selector: "first",
  templateUrl: "first.component.html"
})
export class FirstComponent {

  private kolekcja = [
    { nazwa: "Ala", wartosc: 12 },
    { nazwa: "Ola", wartosc: 23 },
    { nazwa: "Tomek", wartosc: 32 },
  ];

  private obiekt = { nazwa: "", wartosc: 0 };
  private trybEdycji = false;
  dodajObiekt() {

  usunObiekt(o) {
  this.kolekcja.pop();
  }
  edytujObiekt(o) {
    this.trybEdycji = true;
    this.obiekt = o;
  }
  dodaj(obiekt) {
    this.kolekcja.push(Object.assign({},this.obiekt))
  }
  zatwierdz() {
    this.obiekt = { nazwa: "", wartosc: 0 };
    this.trybEdycji = false;
  }
}
