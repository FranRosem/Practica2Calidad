using FilmFranchiseAPI.Models;
using Xunit;

namespace XUnitTesting
{
    public class FilmFranchiseModelShould
    {
        [Fact]
        public void ValidateFilmFranchiseSetAndGetId()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseModel();
            int ValidFilmFranchiseId = 1;

            //Act
            ValidFilmFranchise.Id = ValidFilmFranchiseId;
            bool idIsCorrect = ValidFilmFranchise.Id == ValidFilmFranchiseId;

            //Assert
            Assert.True(idIsCorrect, $"The id value: {ValidFilmFranchiseId} is not the same as {ValidFilmFranchise.Id}. It was not set correctly");
        }
    }
}
