using UserRegistrationService;

namespace userregistrationservice.tests;

[TestClass]
public class EmailTests
{
    [DataTestMethod]
    [DataRow("Some@Email.com")] // Variations of valid email format
    [DataRow("Another@Valid1Mail.com")]
    [DataRow("JunkMail!@fromSweden.se")]
    [DataRow("Person@FromWork?.NO")]
    public void ValidateInputForEmailRegistration_ShouldThrowExceptionsForInvalidInputAndReturnsTrueForValidInput(string validEmailFormat)
    {
        // Arrange
        UserRegistrationService service = new UserRegistrationService();
        string notInEmailFormat = "NotInEmailFormat";  // Invalid
        string? nullString = null;                      // Invalid

        // Act and Assert

        // Assert if exception is thrown when input not in email format
        Assert.ThrowsException<ArgumentException>(() => service.ValidateEmail(notInEmailFormat), "Invalid email format");

        // Assert if exception is thrown when input is null
        Assert.ThrowsException<ArgumentException>(() => service.ValidatePassword(nullString), "No input value");

        // Assert if method returns true on validation success
        Assert.IsTrue(service.ValidateEmail(validEmailFormat));
    }
}