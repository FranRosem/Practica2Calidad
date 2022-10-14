using AutoMapper;
using FilmFranchiseAPI.Controllers;
using FilmFranchiseAPI.Data;
using FilmFranchiseAPI.Data.Entities;
using FilmFranchiseAPI.Exceptions;
using FilmFranchiseAPI.Models;
using FilmFranchiseAPI.Models.Security;
using FilmFranchiseAPI.Services;
using FilmFranchiseAPI.Services.Security;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTesting.ControllersUT
{
    public class FilmFranchiseControllerShould
    {
        [Fact]
        public async Task GetFranchisesAsync()
        {
            var oneFilmFranchiseModel = new FilmFranchiseModel()
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
            var twoFilmFranchiseModel = new FilmFranchiseModel()
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
            var FilmFranchisesEnumerable = new List<FilmFranchiseModel>() { oneFilmFranchiseModel, twoFilmFranchiseModel } as IEnumerable<FilmFranchiseModel>;


            var franchiseServiceMock = new Mock<IFilmFranchiseService>();
            franchiseServiceMock.Setup(f => f.GetFranchisesAsync("asc","id")).ReturnsAsync(FilmFranchisesEnumerable);
            var fileService = new FileService();

            var franchiseController = new FilmFranchisesController(franchiseServiceMock.Object, fileService);

            var result = await franchiseController.GetFranchisesAsync("asc", "id");
            var okResult = result.Result as OkObjectResult;
            var franchisesList = okResult.Value as List<FilmFranchiseModel>;
            
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotEmpty(franchisesList);
            Assert.Contains(franchisesList, franchise => franchise.Id == oneFilmFranchiseModel.Id);
        }

        [Fact]
        public async Task NotFoundGetFranchisesAsync()
        {
            var oneFilmFranchiseModel = new FilmFranchiseModel()
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

            var FilmFranchisesEnumerable = new List<FilmFranchiseModel>() { } as IEnumerable<FilmFranchiseModel>;


            var franchiseServiceMock = new Mock<IFilmFranchiseService>();
            var notFoundElement = new NotFoundElementException($"Film Franchise with id:{oneFilmFranchiseModel.Id} does not exists.");
            franchiseServiceMock.Setup(f => f.GetFranchisesAsync("asc", "id")).ThrowsAsync(notFoundElement);
            var fileService = new FileService();

            var franchiseController = new FilmFranchisesController(franchiseServiceMock.Object, fileService);

            var result = await franchiseController.GetFranchisesAsync("asc", "id");
            var badResult = result.Result as NotFoundObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal(404, badResult.StatusCode);
        }
    }
}
