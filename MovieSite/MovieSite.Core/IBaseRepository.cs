using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Core
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Query();
        T Find(int id);
        List<T> List();
        bool Update(T ent);
        bool Delete(int id);
        bool Create(T ent);
        DbSet<T> Set();
      
     
    }
}
