using FilmFranchiseAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace XUnitTesting
{
    public class MovieModelShould
    {
        [Fact]
        public void ValidateMovieSetId()
        {
            //Arrange
            var movie = new MovieModel
            {
                Id = 1,
            };
            
            
            //Act
            var getValue=movie.Id;
            //Assert
            Assert.Equal(1, getValue);
        }

        [Fact]
        public void ValidateMovieSetTitle()
        {
            //Arrange
            MovieModel movie = new MovieModel();
            string title = "Avengers1";
            movie.Title =title;
            //Act
            var getValue=movie.Title;
            //Assert
           // Assert.Equal(movie.Title, title);
            Assert.Contains(getValue, movie.Title);
        }

        [Fact]
        public  void ValidateDuration()
        {
            //Arrange
            MovieModel movie = new MovieModel();
            DateTime dataTime = new DateTime(2042, 12, 24, 18, 42, 0);
            DateTime duration = dataTime.Date;
            movie.Duration = duration;
            //Act
            var getValue = movie.Duration;
            //Assert
            Assert.IsType<DateTime>(getValue);
        }
        [Fact]
        public void ValidateGross()
        {
            MovieModel movie = new MovieModel();
            movie.Gross = 1515.15f;

            Assert.IsType<float>(movie.Gross);
        }
        [Fact]
        public void ValidateDescription()
        {
            MovieModel movie = new MovieModel();
            movie.Description = "Los vengadores son los heroes mas poderosos del planeta";
            var getValue=movie.Description;
            Assert.IsType<String>(getValue);
            Assert.Contains( "heroes", getValue);
        }
        [Fact]
        public void ValidateImagePath()
        {
            MovieModel movie = new MovieModel();
            
            movie.ImagePath = "C:\\uNIVERSIDAD\\Preparacion y eva proyect\\dell.png";
            var listExtencionImage = new List<string>() {".png"};
            //Assert.Contains(".png", movie.ImagePath);
            foreach (string extencion in listExtencionImage)
            {
                Assert.Contains(extencion,movie.ImagePath);
            }
            //Assert.IsType<string>(movie.ImagePath);
        }
        [Fact]
        public void ValidateFilmFranchiseId()
        {
            MovieModel movie=new MovieModel();
            FilmFranchiseModel filmFranchise = new FilmFranchiseModel();
            filmFranchise.Id = 1;
            movie.FilmFranchiseId = filmFranchise.Id;

            Assert.Equal(filmFranchise.Id, movie.FilmFranchiseId);

        }

    }
}
