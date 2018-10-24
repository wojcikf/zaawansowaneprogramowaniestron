using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik
{
    public class Autor
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public IEnumerable<AutorKsiazki> Ksiazki { get; set; }


    }
}
