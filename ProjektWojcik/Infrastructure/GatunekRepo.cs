using ProjektWojcik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik.Infrastructure
{
    public class GatunekRepo
    {
        KsiegarniaKontekst _db;

        public GatunekRepo(KsiegarniaKontekst db)
        {
            _db = db;
        }
        public IUnitOfWork UnitOfWork() => _db;

        public IEnumerable<Gatunek> GetAll()
        {
            return _db.Gatunki.ToList();
        }
        public Gatunek FindById(int id)
        {
            return _db.Gatunki.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(Gatunek gatunek)
        {
            _db.Gatunki.Add(gatunek);
        }

        public void Update(Gatunek gatunek)
        {
            _db.Update(gatunek);
        }

        public void Delete(int id)
        {
            var gatunek = _db.Gatunki.Find(id);
            _db.Gatunki.Remove(gatunek);
        }
    }
}
