import { Component } from "@angular/core"

@Component({
  selector: "first",
  templateUrl: "first.component.html"
})
export class FirstComponent {

  private kolekcja = [];

  private obiekt = { Imie: "", Nazwisko: "", Stypendium: 0 };
  private trybEdycji = false;
  private showDodajOsobe = false;
  private sStypendium = 0;

  usunObiekt(o) {
  this.kolekcja.pop();
  }
  edytujObiekt(o) {
    this.trybEdycji = true;
    this.obiekt = o;
  }
  dodaj(obiekt) {
    this.kolekcja.push(Object.assign({}, this.obiekt))
  }
  zatwierdz() {
    this.obiekt = { Imie: "", Nazwisko: "", Stypendium: 0 };
    this.trybEdycji = false;
  }
  dodajOsobeShow() {
    if (this.trybEdycji == false)
      this.obiekt = { Imie: "", Nazwisko: "", Stypendium: 0 };
    if (this.showDodajOsobe == false)
      this.showDodajOsobe = true;
    else
      this.showDodajOsobe = false

  }
  sumaStypendium() {
    this.sStypendium += this.kolekcja.length;
  }
}
