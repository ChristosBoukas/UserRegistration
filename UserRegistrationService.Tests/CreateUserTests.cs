using System.Threading.Tasks;
using System.Xml.Linq;
using UserRegistrationService;

namespace userregistrationservice.tests;

[TestClass]
public class CreateUserTests
{
    [TestMethod]
    public void CreateAndAddNewValidUser_ShouldAddNewUserToUserListAndReturnConfirmationMessage()
    { 
        // Arrange
        UserRegistrationService service = new UserRegistrationService();

        // Act
        string confirmationMessage = service.CreateUser("ValidUsername", "ValidPass!", "Valid@gmail.com");

        // Assert that a user has been added to the service.Users list
        Assert.AreEqual(1, service.Users.Count);

        // Assert that correct information has been stored to the users list
        Assert.AreEqual("ValidUsername", service.Users[0].Username);
        Assert.AreEqual("ValidPass!", service.Users[0].Password);
        Assert.AreEqual("Valid@gmail.com", service.Users[0].Email);

        // Assert that confirmation message is received
        Assert.AreEqual("User ValidUsername added successfully", confirmationMessage);
    }

    [TestMethod]
    public void TryToAddInvalidUserWithDuplicateUsername_ShouldThrowExceptionAndKeepOriginalValuesInUsersList()
    {
        // Arrange
        UserRegistrationService service = new UserRegistrationService();
        service.CreateUser("Username", "OGPassword!", "OGEmail@gmail.com");

        // Store the original user details
        string originalUsername = service.Users[0].Username;
        string originalPassword = service.Users[0].Password;
        string originalEmail = service.Users[0].Email;

        // Act create new non-unique user and Assert that exception is thrown when username is not unique
        Assert.ThrowsException<ArgumentException>(() => service.CreateUser("Username", "NewPassword!", "NewEmail@gmail.com"), "Username is not unique.");

        // Assert that new user has not been added to the service.Users list
        Assert.AreEqual(1, service.Users.Count);

        // Assert that the original user remains the same in the service.Users lists (e.g that the properties are not overwritten)
        Assert.AreEqual(originalUsername, service.Users[0].Username);
        Assert.AreEqual(originalPassword, service.Users[0].Password);
        Assert.AreEqual(originalEmail, service.Users[0].Email);
    }
}