using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using FilmFranchiseAPI.Data;
using FilmFranchiseAPI.Exceptions;
using Moq;
using Xunit;
using FilmFranchiseAPI.Models;
using FilmFranchiseAPI.Data.Repository;
using FilmFranchiseAPI.Data.Entities;
using FilmFranchiseAPI.Services;
using System.Threading.Tasks;

namespace XUnitTesting.ServicesUT
{
    public class FilmFranchiseServiceShould
    {
        [Fact]
        public async Task CreateFranchiseAsync()
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
            var filmFranchiseModel = mapper.Map<FilmFranchiseModel>(filmFranchiseEntity);

            var filmFranchiseRepositoryMock = new Mock<IFilmFranchiseRepository>();
            filmFranchiseRepositoryMock.Setup(f => f.CreateFranchise(filmFranchiseEntity));
            filmFranchiseRepositoryMock.Setup(f => f.SaveChangesAsync()).ReturnsAsync(true);

            var filmFranchiseService = new FilmFranchiseService(filmFranchiseRepositoryMock.Object, mapper);
            var filmFranchiseAdded = await filmFranchiseService.CreateFranchiseAsync(filmFranchiseModel);

            Assert.Equal(filmFranchiseAdded.Franchise, filmFranchiseModel.Franchise);
            Assert.Equal(filmFranchiseAdded.FilmProductor, filmFranchiseModel.FilmProductor);
            Assert.Equal(filmFranchiseAdded.FilmProducer, filmFranchiseModel.FilmProducer);
            Assert.Equal(filmFranchiseAdded.FirstMovieYear, filmFranchiseModel.FirstMovieYear);
        }
        [Fact]
        public void ErrorCreateFranchiseAsync()
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
            var filmFranchiseModel = mapper.Map<FilmFranchiseModel>(filmFranchiseEntity);

            var filmFranchiseRepositoryMock = new Mock<IFilmFranchiseRepository>();
            filmFranchiseRepositoryMock.Setup(f => f.CreateFranchise(filmFranchiseEntity));
            filmFranchiseRepositoryMock.Setup(f => f.SaveChangesAsync()).ReturnsAsync(false);

            var filmFranchiseService = new FilmFranchiseService(filmFranchiseRepositoryMock.Object, mapper);

            var exception = Assert.ThrowsAsync<Exception>(async () => await filmFranchiseService.CreateFranchiseAsync(filmFranchiseModel));
            Assert.Equal("Database Error.", exception.Result.Message);
        }


        [Fact]
        public async Task GetFranchiseAsync()
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
            var filmFranchiseModel = mapper.Map<FilmFranchiseModel>(filmFranchiseEntity);

            var filmFranchiseRepositoryMock = new Mock<IFilmFranchiseRepository>();
            filmFranchiseRepositoryMock.Setup(f => f.GetFranchiseAsync(1, false)).ReturnsAsync(filmFranchiseEntity);
            filmFranchiseRepositoryMock.Setup(f => f.SaveChangesAsync()).ReturnsAsync(true);

            var filmFranchiseService = new FilmFranchiseService(filmFranchiseRepositoryMock.Object, mapper);
            var filmFranchise = await filmFranchiseService.GetFranchiseAsync(1, false);
            Assert.Equal(filmFranchise.Id, filmFranchiseModel.Id);
            Assert.Equal(filmFranchise.Franchise, filmFranchiseModel.Franchise);
            Assert.Equal(filmFranchise.FilmProductor, filmFranchiseModel.FilmProductor);
            Assert.Equal(filmFranchise.FilmProducer, filmFranchiseModel.FilmProducer);
            Assert.Equal(filmFranchise.FirstMovieYear, filmFranchiseModel.FirstMovieYear);
        }

        [Fact]
        public void ErrorGetFranchiseAsync()
        {
            int filmFranchiseId = 1;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var filmFranchiseRepositoryMock = new Mock<IFilmFranchiseRepository>();
            var filmFranchiseService = new FilmFranchiseService(filmFranchiseRepositoryMock.Object, mapper);

            var exception = Assert.ThrowsAsync<NotFoundElementException>(async () => await filmFranchiseService.GetFranchiseAsync(1, false));
            Assert.Equal($"Film Franchise with id:{filmFranchiseId} does not exists.", exception.Result.Message);
        }

        [Fact]
        public async Task GetFranchisesAsync()
        {
            var oneFilmFranchiseEntity = new FilmFranchiseEntity()
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
            var twoFilmFranchiseEntity = new FilmFranchiseEntity()
            {
                Id = 2,
                Franchise = "DC",
                FilmProductor = "Warner Bros.",
                FilmProducer = "Dan Lin",
                FirstMovieYear = 2013,
                LastMovieYear = 2021,
                Description = "SuperHeros Movies",
                MovieCount = 8,
            };
            var FilmFranchisesEnumerable = new List<FilmFranchiseEntity>() { oneFilmFranchiseEntity, twoFilmFranchiseEntity } as IEnumerable<FilmFranchiseEntity>;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var filmFranchiseRepositoryMock = new Mock<IFilmFranchiseRepository>();
            var filmFranchiseService = new FilmFranchiseService(filmFranchiseRepositoryMock.Object, mapper);

            filmFranchiseRepositoryMock.Setup(f => f.GetFranchisesAsync("asc","id")).ReturnsAsync(FilmFranchisesEnumerable);
            filmFranchiseRepositoryMock.Setup(f => f.SaveChangesAsync()).ReturnsAsync(true);

            
            var filmFranchises = await filmFranchiseService.GetFranchisesAsync("asc", "id");
            Assert.NotEmpty(filmFranchises);
        }
    }
}
