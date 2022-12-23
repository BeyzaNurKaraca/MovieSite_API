using MovieSite.Core;
using MovieSite.DTO;
using MovieSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Repos.Abstract
{
    public interface IMovieRepos:IBaseRepository<Movie>
    {
        List<MovieList> GetMovieList();
    }
}
