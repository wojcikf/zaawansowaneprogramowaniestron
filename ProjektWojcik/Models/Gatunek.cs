using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik
{
    public class Gatunek
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public Gatunek(int Id, string Nazwa) {

            this.Id = Id;
            this.Nazwa = Nazwa;

        }

        
    }
}
