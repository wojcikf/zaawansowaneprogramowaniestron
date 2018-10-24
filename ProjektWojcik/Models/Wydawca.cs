using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik
{
    public class Wydawca
    {

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public IEnumerable<Ksiazka> Ksiazki {get;set;}

    }
}
