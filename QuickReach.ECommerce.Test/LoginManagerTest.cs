using System;
using Xunit;

namespace QuickReach.ECommerce.Test
{
    public class LoginManagerTest
    {
        [Theory]
        [InlineData("Blast12", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("Blast123", false)]
        [InlineData("Bl@stxyz", false)]
        //[InlineData("Bla$t123", false)] This is valid
        [InlineData("bl@st123", false)]
        [InlineData("BL@ST123", false)]
        public void Validate_WithInvalidPassword_ShouldFail(string password, bool expected)
        {
            //Arrange
            var sut = new LoginManager();
            var username = "dreyes@gmail.com";
            //Act
            var actual = sut.Validate(username, password);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("dreyesyahoo", false)]
        [InlineData("dreyesyahoo@yacom", false)]
        [InlineData("dreyesyahoo@yahooc.om", false)]
        [InlineData("@a@@yahoo.com", false)]
        [InlineData("heh", false)]
        public void Validate_WithInvalidUsername_ShouldFail(string username, bool expected)
        {
            //Arrange
            var sut = new LoginManager();
            var password = "Bla$t123";
            //Act
            var actual = sut.Validate(username, password);
            //Assert
            Assert.Equal(expected, actual);
            
        }
        [Fact]
        public void Validate_WithValidUsernameAndPassword_ShouldPass()
        {
            //Arrange
            var sut = new LoginManager();
            var username = "dreyes@blastasia.com";
            var password = "Bla$t123";
            var expected = true;

            //Act
            var actual = sut.Validate(username, password);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
