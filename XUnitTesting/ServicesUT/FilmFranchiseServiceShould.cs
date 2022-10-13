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
    }
}
