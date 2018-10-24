using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik.Models
{
   public interface IUnitOfWork
    {
        int SaveChanges();
    }

}
