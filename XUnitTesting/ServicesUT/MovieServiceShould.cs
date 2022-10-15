using AutoMapper;
using FilmFranchiseAPI.Data;
using FilmFranchiseAPI.Data.Entities;
using FilmFranchiseAPI.Data.Repository;
using FilmFranchiseAPI.Exceptions;
using FilmFranchiseAPI.Models;
using FilmFranchiseAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTesting.ServicesUT
{
    public class MovieServiceShould
    {
        
        [Fact]
        public void TestValidateFranchiseAsync()
        {
            var filmFranchiseEntity = new FilmFranchiseEntity()
            {
                Id = 1,
                Franchise = "Marvel",
                FilmProductor = "Disney",
                FilmProducer = "Kevin Feige",
                FirstMovieYear = 2010,
                LastMovieYear = 2022,
                Description = "SuperHeros Movies",
                MovieCount = 22,
            };
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();

            var filmFranchiseRepositoryMock = new Mock<IFilmFranchiseRepository>();
            filmFranchiseRepositoryMock.Setup(f => f.CreateFranchise(filmFranchiseEntity));
            filmFranchiseRepositoryMock.Setup(f => f.SaveChangesAsync()).ReturnsAsync(true);

           

            MovieService movieService = new MovieService(filmFranchiseRepositoryMock.Object, mapper);
            
            Assert.ThrowsAsync<NotFoundElementException>(async () => await movieService.ValidateFranchiseAsync(5));

        }
        [Fact]
        public  async void ValidateCreateMovieAsync()
        {
            var filmFranchiseEntity = new FilmFranchiseEntity()
            {
                Id = 1,
                Franchise = "Marvel",
                FilmProductor = "Disney",
                FilmProducer = "Kevin Feige",
                FirstMovieYear = 2010,
                LastMovieYear = 2022,
                Description = "SuperHeros Movies",
                MovieCount = 22,
            };
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();


            var filmFranchiseRepositoryMock = new Mock<IFilmFranchiseRepository>();
            filmFranchiseRepositoryMock.Setup(f => f.CreateFranchise(filmFranchiseEntity));
            filmFranchiseRepositoryMock.Setup(f => f.GetFranchiseAsync(1, false));
            var responsMock = filmFranchiseRepositoryMock.Object;
            filmFranchiseRepositoryMock.Setup(f => f.SaveChangesAsync()).ReturnsAsync(true);
            responsMock.CreateFranchise(filmFranchiseEntity);
            if(await responsMock.SaveChangesAsync())
            {
                var respons = responsMock.GetFranchiseAsync(1, false);



                MovieService _movieService = new MovieService(responsMock, mapper);

                DateTime dataTime = new DateTime(2042, 12, 24, 1, 42, 0);
                DateTime duration = dataTime.Date;

                MovieModel movie = new MovieModel
                {
                    Title = "Avengers",
                    Description = "The avengers asemble",
                    Gross = 150.9f,
                    Duration = duration,
                    Id = 1
                };
                //Act
                await _movieService.CreateMovieAsync(1, movie);
                var responsGet = await _movieService.GetMovieAsync(1, 1);
                //Assert
                Assert.Equal(movie.Id, responsGet.Id);
            }
            
        }
    }
}
