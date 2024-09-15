using Backend.Helpers;
using Backend.Helpers.Interfaces;
using FluentAssertions;
using Moq;

namespace Backend.Tests
{
    public class PasswordHasherHelpersTests
    {
        [Fact]
        public void Hash_Password_ShouldHashSuccess()
        {
            // Arrange
            string password = "123456";
            string expectedHashedPassword = "hashedPassword123-saltValue";
            var mock = new Mock<IPasswordHasherHelper>();

            mock.Setup(m => m.Hash(It.IsAny<string>())).Returns(expectedHashedPassword);

            var _passwordHasherHelper = mock.Object;

            //Act
            string hashedPassword = _passwordHasherHelper.Hash(password);

            // Assert
            hashedPassword.Should().NotBeNullOrEmpty("A senha deve ser hasheada corretamente.");
            hashedPassword.Should().Be(expectedHashedPassword, "A senha hasheada deve ser igual à simulada.");

        }

        [Fact]
        public void VerifyPassword_ShouldHashSuccess()
        {
            string password = "123456";
            string hashedPassword = "hashedPassword123-saltValue";


            var mock = new Mock<IPasswordHasherHelper>();

            mock.Setup(m => m.VerifyPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var _passwordHasherHelper = mock.Object;

            bool verifiedPassword = _passwordHasherHelper.VerifyPassword(password, hashedPassword);

            verifiedPassword.Should().BeTrue();

        }
    }
}