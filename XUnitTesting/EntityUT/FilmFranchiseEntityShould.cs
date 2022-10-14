using FilmFranchiseAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTesting.EntityUT
{
    public class FilmFranchiseEntityShould
    {
        [Fact]
        public void ValidateeSetAndGetId()
        {
            //Arrange
            var filmFranchiseEntity = new FilmFranchiseEntity();
            filmFranchiseEntity.Id = 1;

            //Act
            var getId = filmFranchiseEntity.Id;
            bool result = getId == 1;

            //Assert
            Assert.True(result, $"The id value: {getId} is not the same as {filmFranchiseEntity.Id}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetFranchise()
        {
            //Arrange
            var filmFranchiseEntity = new FilmFranchiseEntity();
            string ValidFilmFranchiseFranchise = "A Franchise name";

            //Act
            filmFranchiseEntity.Franchise = ValidFilmFranchiseFranchise;
            bool idIsCorrect = filmFranchiseEntity.Franchise == ValidFilmFranchiseFranchise;

            //Assert
            Assert.True(idIsCorrect, $"The Franchise value: {ValidFilmFranchiseFranchise} is not the same as {filmFranchiseEntity.Franchise}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetFilmProductor()
        {
            //Arrange
            var filmFranchiseEntity = new FilmFranchiseEntity();
            string ValidFilmFranchiseFilmProductor = "A Film Productor name";

            //Act
            filmFranchiseEntity.FilmProductor = ValidFilmFranchiseFilmProductor;
            bool idIsCorrect = filmFranchiseEntity.FilmProductor == ValidFilmFranchiseFilmProductor;

            //Assert
            Assert.True(idIsCorrect, $"The FilmProductor value: {ValidFilmFranchiseFilmProductor} is not the same as {filmFranchiseEntity.FilmProductor}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetFilmProducer()
        {
            //Arrange
            var filmFranchiseEntity = new FilmFranchiseEntity();
            string ValidFilmFranchiseFilmProducer = "A Film Producer name";

            //Act
            filmFranchiseEntity.FilmProducer = ValidFilmFranchiseFilmProducer;
            bool idIsCorrect = filmFranchiseEntity.FilmProducer == ValidFilmFranchiseFilmProducer;

            //Assert
            Assert.True(idIsCorrect, $"The FilmProducer value: {ValidFilmFranchiseFilmProducer} is not the same as {filmFranchiseEntity.FilmProducer}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetFirstMovieYear()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseEntity();
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
            var ValidFilmFranchise = new FilmFranchiseEntity();
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
            var ValidFilmFranchise = new FilmFranchiseEntity();
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
            var ValidFilmFranchise = new FilmFranchiseEntity();
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
            var ValidFilmFranchise = new FilmFranchiseEntity();
            string ValidFilmFranchiseImagePath = "C:/Test/image/route/here";

            //Act
            ValidFilmFranchise.ImagePath = ValidFilmFranchiseImagePath;
            bool idIsCorrect = ValidFilmFranchise.ImagePath == ValidFilmFranchiseImagePath;

            //Assert
            Assert.True(idIsCorrect, $"The ImagePath value: {ValidFilmFranchiseImagePath} is not the same as {ValidFilmFranchise.ImagePath}. It was not set correctly");
        }
        [Fact]
        public void ValidateFilmFranchiseSetAndGetMovies()
        {
            //Arrange
            var ValidFilmFranchise = new FilmFranchiseEntity();

            var movie = new MovieEntity
            {
                Id = 1,
                Title = "Titanic",
                Duration = new DateTime(2016, 12, 31, 5, 10, 20),
                Gross = 314.15f
            };
            var movie2 = new MovieEntity
            {
                Id = 1,
                Title = "Titanic",
                Duration = new DateTime(2016, 12, 31, 5, 10, 20),
                Gross = 314.15f
            };

            var FilmFranchisesEnumerable = new List<MovieEntity>() { movie, movie2 } ;

            //Act
            ValidFilmFranchise.Movies = FilmFranchisesEnumerable;
            bool idIsCorrect = ValidFilmFranchise.Movies == FilmFranchisesEnumerable;

            //Assert
            Assert.True(idIsCorrect, $"The id: {FilmFranchisesEnumerable} is not the same as {ValidFilmFranchise.Movies}. It was not set correctly");
        }
    }
}
