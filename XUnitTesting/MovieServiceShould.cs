using AutoMapper;
using FilmFranchiseAPI.Data;
using FilmFranchiseAPI.Data.Entities;
using FilmFranchiseAPI.Data.Repository;
using FilmFranchiseAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace XUnitTesting
{
    public class MovieServiceShould
    {
        [Fact]
        public void TestValidateFranchiseAsync()
        {
            /*var movieEntity = new MovieEntity()
            {
                Id = 1,
                Title = "MARVEL ENT",
                Duration = new DateTime(2001, 3, 2),
                Gross = 99.9f,
                Description = "MARVEL",

            };
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var movieRepositoryMock = new Mock<FilmFranchiseRepository>();
            movieRepositoryMock.Setup(r => r.GetMovieAsync(1, 1)).ReturnsAsync(movieEntity);

            var MovieService = new MovieService(movieRepositoryMock.Object, mapper);
            var movie = await MovieService.GetMoviesAsync();
            Assert.Equal(1, movie.Id);*/
        }
    }
}
