using FilmFranchiseAPI.Models;
using System;
using System.Collections.Generic;
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
            var movie = new MovieModel();
            int movieId = 1;
            movie.Id = movieId;
            //Act
            var getValue=movie.Id;
            //Assert
            Assert.Equal(movieId, getValue);
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
            DateTime duration = new DateTime(0, 0, 1, 20, 32, 0);
            movie.Duration = duration;
            //Act
            var getValue = movie.Duration;
            Console.WriteLine(getValue);
            //Assert
            Assert.IsType<DateTime?>(getValue);
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
