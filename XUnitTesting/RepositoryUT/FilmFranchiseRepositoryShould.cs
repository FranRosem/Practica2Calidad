using FilmFranchiseAPI.Data;
using FilmFranchiseAPI.Data.Entities;
using FilmFranchiseAPI.Data.Repository;
using FilmFranchiseAPI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace XUnitTesting.RopositoryUT
{
    public class FilmFranchiseRepositoryShould
    {
        [Fact]  
        public  void ValidateCreateFranchise()
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


            var filmFranchiseRepositoryMock = new Mock<IFilmFranchiseRepository>();
           // filmFranchiseRepositoryMock.Setup(f => f.GetFranchiseAsync(1, false)).ReturnsAsync(responsGet);
            var responsMock = filmFranchiseRepositoryMock.Object;
            filmFranchiseRepositoryMock.Setup(f => f.SaveChangesAsync()).ReturnsAsync(true);
            responsMock.CreateFranchise(filmFranchiseEntity);
            var respons =responsMock.GetFranchiseAsync(1, false);
            Assert.Equal(filmFranchiseEntity.Id, respons.Id);
        }
        [Fact]
        public async void ValidateGetsFranchisesAsync()
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
            var filmFranchiseEntity2 = new FilmFranchiseEntity()
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

            var filmFranchiseRepositoryMock = new Mock<IFilmFranchiseRepository>();
            
            var responsMock = filmFranchiseRepositoryMock.Object;
            filmFranchiseRepositoryMock.Setup(f => f.SaveChangesAsync()).ReturnsAsync(true);
            responsMock.CreateFranchise(filmFranchiseEntity);
            responsMock.CreateFranchise(filmFranchiseEntity2);
            var responsGets = await responsMock.GetFranchisesAsync("asc", "id");
            Assert.IsType<FilmFranchiseEntity[]>(responsGets);

        }/*
        [Fact]
        public async void ValidateCreateFranchise2()
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
            FilmFranchiseDbContext aux;
            var dbContext = new Mock<FilmFranchiseDbContext>();
            dbContext.Setup(x => x.Set<FilmFranchiseEntity>());
            FilmFranchiseRepository preub = new FilmFranchiseRepository(dbContext.Object);
            preub.CreateFranchise(filmFranchiseEntity);
            var idAux = await preub.GetFranchiseAsync(1, false);


            Assert.Equal(filmFranchiseEntity.Id, idAux.Id);
        }*/
    }
}

            