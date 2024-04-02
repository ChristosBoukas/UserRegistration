using UserRegistrationService;

namespace userregistrationservice.tests;

[TestClass]
public class CreateUserTests
{
    [TestMethod]
    public void IsUniqueUsernameVerifyingUniqueUnexistingUsername_ShouldReturnTrue()
    {
        //Arrange
        UserRegistrationService userRegistration = new UserRegistrationService();

        //Act
        bool usernameIsUnique = userRegistration.ValidateUniqueUsername("newUniqueUsername");

        //Assert
        Assert.IsTrue(usernameIsUnique);
    }
}