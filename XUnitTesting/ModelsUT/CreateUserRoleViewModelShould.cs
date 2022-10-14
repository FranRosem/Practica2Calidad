using FilmFranchiseAPI.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace XUnitTesting.ModelsUT
{
    public class CreateUserRoleViewModelShould
    {
        [Fact]
        public void ValidateRoleId()
        {
            //Arrange
            CreateUserRoleViewModel rolUser = new CreateUserRoleViewModel();
            rolUser.RoleId = string.Join("", (new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes("Admin"))).Select(x => x.ToString("X2")).ToArray()); ;

            //Act
            var getRolId=rolUser.RoleId;
            //Assert
            Assert.IsType<string>(getRolId);
            
        }

        [Fact]
        public void ValidateUserId()
        {
            //Arrange
            CreateUserRoleViewModel rolUser = new CreateUserRoleViewModel();
            int userId = 1;
            rolUser.RoleId = string.Join("", (new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(userId.ToString())).Select(x => x.ToString("X2")).ToArray())); ;

            //Act
            var getUserId = rolUser.UserId;
            //Assert
            Assert.Equal(getUserId,rolUser.UserId);

        }
    }
}
