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
        [Fact]
        public void ValidateFilmFranchiseSetAndGetFranchise()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseModel();
            string ValidFilmFranchiseFranchise = "A Franchise name";

            //Act
            ValidFilmFranchise.Franchise = ValidFilmFranchiseFranchise;
            bool idIsCorrect = ValidFilmFranchise.Franchise == ValidFilmFranchiseFranchise;

            //Assert
            Assert.True(idIsCorrect, $"The Franchise value: {ValidFilmFranchiseFranchise} is not the same as {ValidFilmFranchise.Franchise}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetFilmProductor()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseModel();
            string ValidFilmFranchiseFilmProductor = "A Film Productor name";

            //Act
            ValidFilmFranchise.FilmProductor = ValidFilmFranchiseFilmProductor;
            bool idIsCorrect = ValidFilmFranchise.FilmProductor == ValidFilmFranchiseFilmProductor;

            //Assert
            Assert.True(idIsCorrect, $"The FilmProductor value: {ValidFilmFranchiseFilmProductor} is not the same as {ValidFilmFranchise.FilmProductor}. It was not set correctly");
        }
    }
}
