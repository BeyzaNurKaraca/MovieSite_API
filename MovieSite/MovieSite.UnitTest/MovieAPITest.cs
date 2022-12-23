using AutoMapper;
using FakeItEasy;
using MovieSite.Controllers;
using MovieSite.Core;
using MovieSite.DAL;
using MovieSite.DTO;
using MovieSite.Entity;
using MovieSite.Repos.Abstract;
using MovieSite.UOW;

namespace MovieSite.UnitTest
{
    public class MovieAPITest
    {

        IMovieRepos _movieRepos;
        IMapper _mapper;
        IUnitOfWork _uow;
        Context _db;
        public MovieAPITest()
        {
            _movieRepos=A.Fake<IMovieRepos>();
            _mapper=A.Fake<IMapper>();  
            _uow=A.Fake<IUnitOfWork>(); 
         
        }

        [Fact]
        public async void MovieController_GetMovie_ReturnOK()
        {
            //Arrange
            var movies = A.Fake<ICollection<MovieList>>();
            var movie=A.Fake<List<MovieList>>();
            A.CallTo(()=>_mapper.Map<List<MovieList>>(movies)).Returns(movie);
            var controller = new MovieController(_db,_uow);

            //Act
            var filter =new PaginationFilter();
            var result =  _movieRepos.GetMovieList();

            //Assert
            var response = result.AsReadOnly();
        }

   

    }
}