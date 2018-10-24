using ProjektWojcik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik.Infrastructure
{
   public interface Repo<T>
    {
        IUnitOfWork UnitOfWork { get; }
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Insert(T value);
        void Update(T value);
        void Delete(int id);

    }
}
