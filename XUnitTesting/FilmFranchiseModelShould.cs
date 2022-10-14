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
        [Fact]
        public void ValidateFilmFranchiseSetAndGetFilmProducer()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseModel();
            string ValidFilmFranchiseFilmProducer = "A Film Producer name";

            //Act
            ValidFilmFranchise.FilmProducer = ValidFilmFranchiseFilmProducer;
            bool idIsCorrect = ValidFilmFranchise.FilmProducer == ValidFilmFranchiseFilmProducer;

            //Assert
            Assert.True(idIsCorrect, $"The FilmProducer value: {ValidFilmFranchiseFilmProducer} is not the same as {ValidFilmFranchise.FilmProducer}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetFirstMovieYear()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseModel();
            int ValidFilmFranchiseFirstMovieYear = 2022;

            //Act
            ValidFilmFranchise.FirstMovieYear = ValidFilmFranchiseFirstMovieYear;
            bool idIsCorrect = ValidFilmFranchise.FirstMovieYear == ValidFilmFranchiseFirstMovieYear;

            //Assert
            Assert.True(idIsCorrect, $"The FirstMovieYear value: {ValidFilmFranchiseFirstMovieYear} is not the same as {ValidFilmFranchise.FirstMovieYear}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetLastMovieYear()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseModel();
            int ValidFilmFranchiseLastMovieYear = 2023;

            //Act
            ValidFilmFranchise.LastMovieYear = ValidFilmFranchiseLastMovieYear;
            bool idIsCorrect = ValidFilmFranchise.LastMovieYear == ValidFilmFranchiseLastMovieYear;

            //Assert
            Assert.True(idIsCorrect, $"The LastMovieYear value: {ValidFilmFranchiseLastMovieYear} is not the same as {ValidFilmFranchise.LastMovieYear}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetDescription()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseModel();
            string ValidFilmFranchiseDescription = "A description of a movie";

            //Act
            ValidFilmFranchise.Description = ValidFilmFranchiseDescription;
            bool idIsCorrect = ValidFilmFranchise.Description == ValidFilmFranchiseDescription;

            //Assert
            Assert.True(idIsCorrect, $"The Description value: {ValidFilmFranchiseDescription} is not the same as {ValidFilmFranchise.Description}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetMovieCount()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseModel();
            int ValidFilmFranchiseMovieCount = 8;

            //Act
            ValidFilmFranchise.MovieCount = ValidFilmFranchiseMovieCount;
            bool idIsCorrect = ValidFilmFranchise.MovieCount == ValidFilmFranchiseMovieCount;

            //Assert
            Assert.True(idIsCorrect, $"The MovieCount value: {ValidFilmFranchiseMovieCount} is not the same as {ValidFilmFranchise.MovieCount}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetImagePath()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseModel();
            string ValidFilmFranchiseImagePath = "C:/Test/image/route/here";

            //Act
            ValidFilmFranchise.ImagePath = ValidFilmFranchiseImagePath;
            bool idIsCorrect = ValidFilmFranchise.ImagePath == ValidFilmFranchiseImagePath;

            //Assert
            Assert.True(idIsCorrect, $"The ImagePath value: {ValidFilmFranchiseImagePath} is not the same as {ValidFilmFranchise.ImagePath}. It was not set correctly");
        }
    }
}
