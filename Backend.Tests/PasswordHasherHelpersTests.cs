using Backend.Helpers.Interfaces;
using Moq;

namespace Backend.Tests
{

    public class PasswordHasherHelpersTests
    {

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
