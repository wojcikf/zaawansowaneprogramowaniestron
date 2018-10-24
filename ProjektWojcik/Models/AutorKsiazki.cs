using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik
{
    public class AutorKsiazki
    {
        public int IdAutora { get; set; }

        public Autor Autor { get; set; }
        public int IdKsiazki { get; set; }
        public Ksiazka Ksiazka { get; set; }

        
    }
}
