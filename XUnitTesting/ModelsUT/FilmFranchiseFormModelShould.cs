using FilmFranchiseAPI.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Xunit;

namespace XUnitTesting.ModelsUT
{
    public class FilmFranchiseFormModelShould
    {
        [Fact]
        public void ValidateFilmFranchiseModelSetAndGetImage()
        {
            var positionOfBin = Directory.GetCurrentDirectory().IndexOf("bin");
            var baseFileRoute = Directory.GetCurrentDirectory().Substring(0, positionOfBin - 1);
            var pathOfImage = Path.Combine(baseFileRoute, "Images", "test_image.png");

            var stream = File.OpenRead(pathOfImage);
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/png"
            };
            var filmFranchiseForm = new FilmFranchiseFormModel();
            filmFranchiseForm.Image = file;

            var getImage = filmFranchiseForm.Image;
            bool setWasSuccessed = getImage == file;

            Assert.True(setWasSuccessed, "File was not saved.");
        }
    }
}
