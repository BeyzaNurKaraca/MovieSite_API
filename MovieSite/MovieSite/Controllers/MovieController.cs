using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSite.Core;
using MovieSite.DAL;
using MovieSite.DTO;
using MovieSite.Entity;
using MovieSite.Repos.Abstract;
using MovieSite.UOW;

namespace MovieSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
 
    public class MovieController : ControllerBase
    {
        private readonly Context _db;
        private readonly IUnitOfWork _uow;

        public MovieController(Context db, IUnitOfWork uow)
        {
            _db = db;
            _uow = uow;
        }

        //[HttpGet]
        //[Route("GetList")]
        //public IEnumerable<MovieList> GetList()
        //{
        //    return _uow._movieRepos.GetMovieList();
        //}

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _db.Movie
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalRecords = await _db.Movie.CountAsync();
            return Ok(new PagedResponse<List<Movie>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
        }

        [HttpPost]
        [Route("Create")]
        [Authorize]
        public Movie Create([FromBody] Movie movie)
        {
            _uow._movieRepos.Create(movie);
            _uow.Save();
            return movie;
        }
       
        [HttpPut]
        [Route("Update")]
        [Authorize]
        public Movie Update([FromBody] Movie movie)
        {
            _uow._movieRepos.Update(movie);
            _uow.Save();
            return movie;
        }

        //[HttpGet("{id}")]

        //[Authorize]

        //public Movie Find(int id)
        //{
        //    return _uow._movieRepos.Find(id);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            var movie = await _db.Movie.Where(x => x.Id == id).FirstOrDefaultAsync();
            return Ok(new Response<Movie>(movie));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public Movie Delete(int id)
        {
            var movie = _uow._movieRepos.Find(id);
            _uow._movieRepos.Delete(id);
            _uow.Save();
            return movie;
        }

       

       


    }

}
