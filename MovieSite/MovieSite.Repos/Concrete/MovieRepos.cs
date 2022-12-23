using Microsoft.EntityFrameworkCore;
using MovieSite.Core;
using MovieSite.DAL;
using MovieSite.DTO;
using MovieSite.Entity;
using MovieSite.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Repos.Concrete
{
    public class MovieRepos : BaseRepository<Movie>, IMovieRepos
    {
        public MovieRepos(Context db):base(db)
        {

        }

        public List<MovieList> GetMovieList()
        {
            return Set().Select(x => new MovieList
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Type = x.Type,
            }).ToList();
        }
    }
}
