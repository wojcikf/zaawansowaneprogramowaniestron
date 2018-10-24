using ProjektWojcik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik.Infrastructure
{
    public class AutorRepo
    {
        KsiegarniaKontekst _db;

        public AutorRepo(KsiegarniaKontekst db) {
            _db = db;
        }

        public IEnumerable<Autor> GetAll() {
            return _db.Autorzy.ToList();
        }
        public Autor FindById(int id) {
            return _db.Autorzy.SingleOrDefault(x => x.Id == id);   
        }

        public void Insert(Autor autor) {
            _db.Autorzy.Add(autor);
            _db.SaveChanges();
        }

        public void Update(Autor autor) {

        }

        public void Delete(int id) {
            var autor = _db.Autorzy.SingleOrDefault(x => x.Id == id);
            _db.Autorzy.Remove(autor);
            _db.SaveChanges();
        }
    }
}
