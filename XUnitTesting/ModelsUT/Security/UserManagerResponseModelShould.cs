using FilmFranchiseAPI.Models.Security;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTesting.ModelsUT.Security
{
    public class UserManagerResponseModelShould
    {
        [Fact]
        public void ValidateUserManagerResponseModelSetAndGetToken()
        {
            var userManager = new UserManagerResponse();
            string token = "This is a test token";

            userManager.Token = token;
            bool tokenWasSaved = userManager.Token == token;

            Assert.True(tokenWasSaved, "Token was not saved correctly.");
        }
        [Fact]
        public void ValidateUserManagerResponseModelSetAndGetIsSucces()
        {
            var userManager = new UserManagerResponse();
            bool isSuccess = true;

            userManager.IsSuccess = isSuccess;
            bool isSuccessWasSaved = userManager.IsSuccess == isSuccess;

            Assert.True(isSuccessWasSaved, "IsSuccess was not saved correctly.");
        }
        [Fact]
        public void ValidateUserManagerResponseModelSetAndGetErrors()
        {
            var userManager = new UserManagerResponse();
            string error1 = "This is the test error 1";
            string error2 = "This is the test error 2";
            var errors = new List<string>() { error1, error2 } as IEnumerable<string>;


            userManager.Errors = errors;
            bool errorsWereSaved = userManager.Errors == errors;

            Assert.True(errorsWereSaved, "Errors were not saved correctly.");
        }
        [Fact]
        public void ValidateUserManagerResponseModelSetAndGetExpireDate()
        {
            var userManager = new UserManagerResponse();
            DateTime dateTime = new DateTime(2012, 12, 25, 10, 30, 50);

            userManager.ExpireDate = dateTime;
            bool expireDateWasSaved = userManager.ExpireDate == dateTime;

            Assert.True(expireDateWasSaved, "ExpireDate was not saved correctly.");
        }
    }
}
