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
            DateTime dataTime = new DateTime(2042, 12, 24, 1, 42, 0);
            DateTime duration = dataTime.Date;
            //Arrange
            MovieEntity movieEnt = new MovieEntity
            {
                Id= 1,
                Title = "Avengers",
                Description = "The avengers asemble",
                Gross = 150.9f,
                Duration = duration
            };
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
                ImagePath ="C://",
                Movies=new List<MovieEntity> { movieEnt}
            };

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();

            var filmMock = new Mock<IFilmFranchiseRepository>();

            var dbContext = new Mock<FilmFranchiseDbContext>();
            
            //dbContext.Setup(f => f.FilmFranchises=filmFranchiseEntity);

            filmMock.Setup(f => f.CreateFranchise(filmFranchiseEntity));
            IFilmFranchiseRepository respons = filmMock.Object;
            respons.SaveChangesAsync();
            MovieService _movieService = new MovieService(respons, mapper);
            MovieModel movie = new MovieModel
            {
                Title = "Avengers",
                Description =  "The avengers asemble",
                Gross=  150.9f,
                Duration= duration
            };
            //Act
            var result = await _movieService.CreateMovieAsync(1, movie);
            //Assert
            Assert.Equal(result.FilmFranchiseId, filmFranchiseEntity.Id);

            //Assert.ThrowsAsync<NotFoundElementException>(async () => await _movieService.CreateMovieAsync(0, movie));
        }
    }
}
