using FilmFranchiseAPI.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Xunit;

namespace XUnitTesting.ServicesUT
{
    public class FileServiceShould
    {
        [Fact]
        public void ValidateUploadFileWhenFileLenghtIsGreaterThan0()
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
            var fileService = new FileService();
            Directory.SetCurrentDirectory(pathOfAPI);
            var exception = Record.Exception(() => fileService.UploadFile(file));

            Assert.Null(exception);
        }
        [Fact]
        public void ValidateUploadFileWhenFileLenghtIsLessThan0()
        {
            var positionOfBin = Directory.GetCurrentDirectory().IndexOf("bin");
            var positionOfFolderProyect = Directory.GetCurrentDirectory().IndexOf("XUnitTesting");

            var baseFileRoute = Directory.GetCurrentDirectory().Substring(0, positionOfBin - 1);
            var baseProyectRoute = Directory.GetCurrentDirectory().Substring(0, positionOfFolderProyect - 1);

            var pathOfImage = Path.Combine(baseFileRoute, "Images", "test_image.png");
            var pathOfAPI = Path.Combine(baseProyectRoute, "FilmFranchiseAPI");

            var stream = File.OpenRead(pathOfImage);
            var file = new FormFile(stream, 0, 0, null, Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/png"
            };
            var fileService = new FileService();
            Directory.SetCurrentDirectory(pathOfAPI);

            var imagePath = fileService.UploadFile(file);

            Assert.True(imagePath == string.Empty, "File was saved with lenght 0, which is not allowed!");
        }
    }
}
