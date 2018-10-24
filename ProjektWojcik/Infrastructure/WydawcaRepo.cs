using ProjektWojcik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik.Infrastructure
{
    public class WydawcaRepo : Repo <Wydawca>
    {
        KsiegarniaKontekst _db;

        public WydawcaRepo(KsiegarniaKontekst db)
        {
            _db = db;
        }
        public IUnitOfWork UnitOfWork => _db;

        public IEnumerable<Wydawca> GetAll()
        {
            return _db.Wydawcy.ToList();
        }
        public Wydawca FindById(int id)
        {
            return _db.Wydawcy.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(Wydawca wydawca)
        {
            _db.Wydawcy.Add(wydawca);
        }

        public void Update(Wydawca wydawca)
        {
            _db.Update(wydawca);
        }

        public void Delete(int id)
        {
            var wydawca = _db.Wydawcy.Find(id);
            _db.Wydawcy.Remove(wydawca);
        }
    }
}
