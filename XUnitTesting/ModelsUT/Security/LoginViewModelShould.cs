using FilmFranchiseAPI.Models.Security;
using Xunit;

namespace XUnitTesting.ModelsUT.Security
{
    public class LoginViewModelShould
    {
        [Fact]
        public void ValidateLoginViewModelSetAndGetEmail()
        {
            var loginModel = new LoginViewModel();
            loginModel.Email = "testEmail@ucb.edu.bo";
            Assert.True(loginModel.Email == "testEmail@ucb.edu.bo", "The Email field was not saved.");
        }

        [Fact]
        public void ValidateLoginViewModelSetAndGetPassword()
        {
            var loginModel = new LoginViewModel();
            loginModel.Password = "test_password123";
            Assert.True(loginModel.Password == "test_password123", "The Password field was not saved.");
        }
    }
}
