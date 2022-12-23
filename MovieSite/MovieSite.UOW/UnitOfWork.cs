using MovieSite.DAL;
using MovieSite.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        Context _db;
        public IMovieRepos _movieRepos { get; private set; }

   

        public void Save()
        {
            _db.SaveChanges();
        }
        public UnitOfWork(IMovieRepos movieRepos,Context db)
        {
            _db = db;
            _movieRepos = movieRepos;
            
        }

    }
}
