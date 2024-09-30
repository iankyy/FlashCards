using Backend.Helpers;
using FluentAssertions;
using System.Security.Cryptography;

namespace Backend.Tests
{
    public class PasswordHasherTests
    {
        const int HashSize = 32;
        const int Iterations = 100_000;

        [Fact]
        public void Hash_Returns_Password_Success()
        {
            // Arrange
            byte[] salt = RandomNumberGenerator.GetBytes(1);
            string inputPassword = "123456";
            string expectedHash = Hash(inputPassword, salt);

            // Act 
            string hashedPassword = PasswordHasher.Hash(inputPassword, salt);

            // Assert
            hashedPassword.Should().NotBe(inputPassword);
            hashedPassword.Should().Be(expectedHash);

        }

        private string Hash( string password, byte[] salt)
        {

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }

        [Fact]
        public void HashSize_Is_32()
        {
            PasswordHasher.HashSize.Should().Be(32);
        }

        [Fact]
        public void Iterations_Is_100_000()
        {
            PasswordHasher.Iterations.Should().Be(100_000);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Hash_Throws_Exception_On_Invalid_Password(string invalidPassword)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(1);

            var hashAction = () => PasswordHasher.Hash(invalidPassword, salt);

            hashAction.Should().Throw<ArgumentException>().WithParameterName("password");
        }

        [Fact]
        public void Hash_Throws_Exception_On_Empty_Salt()
        {
            byte[] empty = new byte[0];

            var hashAction = () => PasswordHasher.Hash("Bald", empty);

            hashAction.Should().Throw<ArgumentException>().WithParameterName("salt");
        }

        [Fact]
        public void Hash_Throws_Exception_On_Null_Salt()
        {
            byte[] empty = default!;

            var hashAction = () => PasswordHasher.Hash("Bald", empty);

            hashAction.Should().Throw<ArgumentException>().WithParameterName("salt");
        }


    }
}


//[Fact]
//public void VerifyPassword_ShouldHashSuccess()
//{
//    string password = "123456";
//    string hashedPassword = "hashedPassword123-saltValue";


//    var mock = new Mock<IPasswordHasherHelper>();

//    mock.Setup(m => m.VerifyPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

//    var _passwordHasherHelper = mock.Object;

//    bool verifiedPassword = _passwordHasherHelper.VerifyPassword(password, hashedPassword);

//    verifiedPassword.Should().BeTrue();

//}
