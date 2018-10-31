using ProjektWojcik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik.Infrastructure
{
    public class KsiazkaRepo : Repo<Ksiazka>
    {
        KsiegarniaKontekst _db;

        public KsiazkaRepo(KsiegarniaKontekst db)
        {
            _db = db;
        }
        public IUnitOfWork UnitOfWork => _db;

        public IEnumerable<Ksiazka> GetAll()
        {
            return _db.Ksiazki.ToList();
        }
        public Ksiazka FindById(int id)
        {
            return _db.Ksiazki.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(Ksiazka ksiazka)
        {
            _db.Ksiazki.Add(ksiazka);
        }

        public void Update(Ksiazka ksiazka)
        {
            _db.Update(ksiazka);
        }

        public void Delete(int id)
        {
            var ksiazka = _db.Ksiazki.Find(id);
            _db.Ksiazki.Remove(ksiazka);
        }
    }
}
