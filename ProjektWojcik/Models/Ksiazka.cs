using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik
{
    public class Ksiazka
    {

        public int Id { get; set; }
        public string Tytul { get; set; }
        public int LiczbaStron { get; set; }
        public DateTime DataPublikacji { get; set; }
        Waluta CenaOryginalna { get; set; }
        public decimal AktulnaCena { get; set; }
        public decimal OryginalnaCena { get; set; }
        public int IdWydawcy { get; set; }
        public Wydawca Wydawca { get;set; }
        public IEnumerable<AutorKsiazki> Autorzy { get; set; }

    }
}
