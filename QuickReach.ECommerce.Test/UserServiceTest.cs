using Moq;
using Xunit;

namespace QuickReach.ECommerce.Test
{
    public class UserServiceTest
    {
        [Fact]
        public void RegisterUser_WithValidUser_CallsRepositorySave()
        {
            // Arrange

            var mockLoginManager = new Mock<ILoginManager>();

            mockLoginManager.Setup((lm) =>
                   lm.Validate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var mockUserRepository = new Mock<IUserRepository>();
            var sut = new UserService(mockLoginManager.Object, mockUserRepository.Object);

            var user = new User
            {
                Username = "dreyes@blastasia.com",
                Password = "Bla$t123"
            };
            // Act
            sut.RegisterUser(user);
            // Assert
            mockUserRepository.Verify((r) => r.Save(user), Times.Once);
        }

        [Fact]
        public void RegisterUser_WithInvalidPassword_ThrowsInvalidUser()
        {
            //Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var mockLoginManager = new Mock<ILoginManager>();
            mockLoginManager.Setup((lm) =>
                    lm.Validate(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<InvalidFormatPasswordException>();

            var user = new User
            {
                Username = "dreyes@blastasia.com",
                Password = "Blast123"
            };
            var sut = new UserService(mockLoginManager.Object,
                mockUserRepository.Object);

            Assert.Throws<InvalidFormatPasswordException>(
                () => sut.RegisterUser(user));

            mockUserRepository.Verify((r) =>
                r.Save(user), Times.Never);

        }
    }
}
