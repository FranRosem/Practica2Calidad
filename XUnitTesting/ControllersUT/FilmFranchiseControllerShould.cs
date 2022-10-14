using AutoMapper;
using FilmFranchiseAPI.Controllers;
using FilmFranchiseAPI.Data;
using FilmFranchiseAPI.Data.Entities;
using FilmFranchiseAPI.Exceptions;
using FilmFranchiseAPI.Models;
using FilmFranchiseAPI.Models.Security;
using FilmFranchiseAPI.Services;
using FilmFranchiseAPI.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTesting.ControllersUT
{
    public class FilmFranchiseControllerShould
    {
        private HashSet<string> _allowedSortValues = new HashSet<string>
        {
            "id",
            "name",
            "year"
        };

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

        [Fact]
        public async Task BadRequestGetFranchisesAsync()
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

            var FilmFranchisesEnumerable = new List<FilmFranchiseModel>() { oneFilmFranchiseModel } as IEnumerable<FilmFranchiseModel>;

            string orderBy = "center";
            var franchiseServiceMock = new Mock<IFilmFranchiseService>();
            var invalidElement = new InvalidElementOperationException($"Invalid orderBy value: {orderBy}. The allowed values for querys are: {string.Join(',', _allowedSortValues)}");
            franchiseServiceMock.Setup(f => f.GetFranchisesAsync("asc", orderBy)).ThrowsAsync(invalidElement);
            var fileService = new FileService();

            var franchiseController = new FilmFranchisesController(franchiseServiceMock.Object, fileService);

            var result = await franchiseController.GetFranchisesAsync("asc", orderBy);
            var badResult = result.Result as BadRequestObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal(400, badResult.StatusCode);
        }

        [Fact]
        public async Task ErrorGetFranchisesAsync()
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

            var exception = new Exception("Something happend.");
            var franchiseServiceMock = new Mock<IFilmFranchiseService>();
            franchiseServiceMock.Setup(f => f.GetFranchisesAsync("asc", "id")).Throws(exception);
            var fileService = new FileService();

            var franchiseController = new FilmFranchisesController(franchiseServiceMock.Object, fileService);

            var result = await franchiseController.GetFranchisesAsync("asc", "id");
            var badResult = result.Result as ObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal(500, badResult.StatusCode);
        }

        [Fact]
        public async Task GetFranchiseAsync()
        {
            var filmFranchiseModel = new FilmFranchiseModel()
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

            var franchiseServiceMock = new Mock<IFilmFranchiseService>();
            franchiseServiceMock.Setup(f => f.GetFranchiseAsync(1, true)).ReturnsAsync(filmFranchiseModel);
            var fileService = new FileService();

            var franchiseController = new FilmFranchisesController(franchiseServiceMock.Object, fileService);

            var result = await franchiseController.GetFranchiseAsync(1, "");
            var okResult = result.Result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task NotFoundGetFranchiseAsync()
        {
            var filmFranchiseModel = new FilmFranchiseModel()
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

            var franchiseServiceMock = new Mock<IFilmFranchiseService>();
            var notFoundElement = new NotFoundElementException($"Film Franchise with id:{filmFranchiseModel.Id} does not exists.");
            franchiseServiceMock.Setup(f => f.GetFranchiseAsync(1, false)).ThrowsAsync(notFoundElement);
            var fileService = new FileService();

            var franchiseController = new FilmFranchisesController(franchiseServiceMock.Object, fileService);

            var result = await franchiseController.GetFranchiseAsync(1, "false");
            var badResult = result.Result as NotFoundObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal(404, badResult.StatusCode);
        }

        [Fact]
        public async Task ErrorGetFranchiseAsync()
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

            var exception = new Exception("Something happend.");
            var franchiseServiceMock = new Mock<IFilmFranchiseService>();
            franchiseServiceMock.Setup(f => f.GetFranchiseAsync(1, false)).Throws(exception);
            var fileService = new FileService();

            var franchiseController = new FilmFranchisesController(franchiseServiceMock.Object, fileService);

            var result = await franchiseController.GetFranchiseAsync(1, "false");
            var badResult = result.Result as ObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal(500, badResult.StatusCode);
        }
        
        [Fact]
        public async Task CreateFranchiseForm()
        {
            var positionOfBin = Directory.GetCurrentDirectory().IndexOf("bin");
            var positionOfFolderProyect = Directory.GetCurrentDirectory().IndexOf("XUnitTesting");

            var baseFileRoute = Directory.GetCurrentDirectory().Substring(0, positionOfBin - 1);
            var baseProyectRoute = Directory.GetCurrentDirectory().Substring(0, positionOfFolderProyect - 1);

            var pathOfImage = Path.Combine(baseFileRoute, "Images", "test_image.png");
            var pathOfAPI = Path.Combine(baseProyectRoute, "FilmFranchiseAPI");

            var stream = File.OpenRead(pathOfImage);
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/png"
            };
            var actualDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(pathOfAPI);
            Directory.SetCurrentDirectory(actualDirectory);
            var fileService = new FileService();
            var imagePath = fileService.UploadFile(file);


            var filmFranchiseFormModel = new FilmFranchiseFormModel()
            {
                Id = 1,
                Franchise = "Marvel",
                FilmProductor = "Disney",
                FilmProducer = "Kevin Feige",
                FirstMovieYear = 2010,
                LastMovieYear = 2022,
                Description = "SuperHeros Movies",
                MovieCount = 22,
                Image = file,
                ImagePath = imagePath
            };

            var franchiseServiceMock = new Mock<IFilmFranchiseService>();
            franchiseServiceMock.Setup(f => f.CreateFranchiseAsync(filmFranchiseFormModel)).ReturnsAsync(filmFranchiseFormModel);

            var franchiseController = new FilmFranchisesController(franchiseServiceMock.Object, fileService);

            var result = await franchiseController.CreateFranchiseFormAsync(filmFranchiseFormModel);
            var okResult = result.Result as ObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(201, okResult.StatusCode);
        }

        [Fact]
        public async Task BadRequestCreateFranchiseForm()
        {
            var filmFranchiseFormModel = new FilmFranchiseFormModel()
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

            var franchiseServiceMock = new Mock<IFilmFranchiseService>();
            franchiseServiceMock.Setup(f => f.CreateFranchiseAsync(filmFranchiseFormModel)).ReturnsAsync(filmFranchiseFormModel);

            var fileService = new FileService();
            var franchiseController = new FilmFranchisesController(franchiseServiceMock.Object, fileService);
            franchiseController.ModelState.AddModelError("", "");

            var result = await franchiseController.CreateFranchiseFormAsync(filmFranchiseFormModel);
            var badResult = result.Result as BadRequestObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal(400, badResult.StatusCode);
        }
    }
}
