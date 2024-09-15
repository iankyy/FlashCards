using Backend.Helpers;
using FluentAssertions;

namespace Backend.Tests
{
    public class PasswordHasherHelpers
    {
        readonly PasswordHasherHelper _passwordHasherHelper;

        public PasswordHasherHelpers(PasswordHasherHelper passwordHasherHelper)
        {
            _passwordHasherHelper = passwordHasherHelper;
        }


        [Fact]
        public void Hash_Password_ShouldHashSuccess()
        {
            // Arrange
            string password = "123456";

            // TO DO
            Moq.Mock<PasswordHasherHelper> mock = new Moq.Mock<PasswordHasherHelper>();

            //Act
            string hashedPassword = _passwordHasherHelper.Hash(password);

            // Assert
            hashedPassword.Should().NotBeNullOrEmpty();

        }
    }
}