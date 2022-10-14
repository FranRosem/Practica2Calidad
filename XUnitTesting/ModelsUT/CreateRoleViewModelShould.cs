using FilmFranchiseAPI.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTesting
{
    public class CreateRoleViewModelShould
    {   
        [Fact]
        public void NameRoleValidation()
        {
            //Arrange
            CreateRoleViewModel rol=new CreateRoleViewModel();
            rol.Name = "Admin";

            //Act
            var getName=rol.Name;
            //Assert
            Assert.IsType<string>(getName);

        }
        [Fact]
        public void NormalizedNameValidation()
        {
            //Arrange
            CreateRoleViewModel rol = new CreateRoleViewModel();
            rol.Name = "Admin";
            rol.NormalizedName = rol.Name.ToUpper();
            //Act
            var getNameNormalized = rol.NormalizedName;
            //Assert
            Assert.Equal(getNameNormalized,rol.Name.ToUpper());
        }
    }
}
