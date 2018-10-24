using ProjektWojcik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik.Infrastructure
{
    public class AutorRepo : Repo <Autor>
    {
        KsiegarniaKontekst _db;

        public AutorRepo(KsiegarniaKontekst db) {
            _db = db;
        }
        public IUnitOfWork UnitOfWork => _db;
        
        public IEnumerable<Autor> GetAll() {
            return _db.Autorzy.ToList();
        }
        public Autor FindById(int id) {
            return _db.Autorzy.SingleOrDefault(x => x.Id == id);   
        }

        public void Insert(Autor autor) {
            _db.Autorzy.Add(autor);
        }

        public void Update(Autor autor) {
            _db.Update(autor);
        }

        public void Delete(int id) {
            var autor = _db.Gatunki.Find(id);
            _db.Gatunki.Remove(autor);
        }
    }
}
