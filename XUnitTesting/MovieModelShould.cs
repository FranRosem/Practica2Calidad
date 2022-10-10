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
    }
}
