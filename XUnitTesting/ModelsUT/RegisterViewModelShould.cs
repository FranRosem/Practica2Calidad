using FilmFranchiseAPI.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTesting
{
    public class RegisterViewModelShould
    {
        [Fact]
        public void ValidateEmailSet()
        {
            //Arrange
            RegisterViewModel register= new RegisterViewModel();
            register.Email = "miky14n@gmail.com";
            //Act
            var getMail = register.Email;
            //Assert
            Assert.Contains("@", getMail);
        }

        [Fact]
        public void ValidatePassword()
        {
            //Arrange
            RegisterViewModel register = new RegisterViewModel();
            register.Password = "contrasena123";
            //Act
            var getPassword = register.Password;
            //Assert
            
            Assert.Equal(13, getPassword.Length);
        }

        [Fact]
        public void ValidateConfirmPassword()
        {
            //Arrange
            RegisterViewModel register = new RegisterViewModel();
            register.Password = "contrasena123";
            register.ConfirmPassword = "contrasena123";
            //Act
            var getPassword = register.Password;
            var confirmPassword = register.ConfirmPassword;
            //Assert

            Assert.Contains(getPassword,confirmPassword);
        }
    }
}
