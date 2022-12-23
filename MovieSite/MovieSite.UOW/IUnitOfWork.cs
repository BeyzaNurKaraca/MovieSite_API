using MovieSite.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.UOW
{
    public interface IUnitOfWork
    {
        IMovieRepos _movieRepos { get; }
  

        void Save();
    }
}
