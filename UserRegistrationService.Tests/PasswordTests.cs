using UserRegistrationService;

namespace userregistrationservice.tests;

[TestClass]
public class PasswordTests
{
    [TestMethod]
    public void ValidateInputForPasswordRegistration_ShouldThrowExceptionsForInvalidInputAndReturnsTrueForValidInput()
    {
        // Arrange variations of strings
        UserRegistrationService service = new UserRegistrationService();
        string passwordExceedingCharLimit = "InputExceedingLimit!@$£";  // Invalid
        string passwordConceedingCharLimit = "cl![";                    // Invalid
        string onlyNumericCharacters = "OnlyNumericCharacters";         // Invalid
        string nullString = null;                                       // Invalid
        string validPasswordWithinRange = "Character123![}";            // Valid

        // Act and Assert

        // Assert if exception is thrown when string exceeding character limit
        Assert.ThrowsException<ArgumentException>(() => service.ValidatePassword(passwordExceedingCharLimit), "Invalid number of characters");

        // Assert if exception is thrown when string concceeding character limit
        Assert.ThrowsException<ArgumentException>(() => service.ValidatePassword(passwordConceedingCharLimit), "Invalid number of characters");

        // Assert if exception is thrown when string contains special characters
        Assert.ThrowsException<ArgumentException>(() => service.ValidatePassword(onlyNumericCharacters), "Password must contain at least one special character");

        // Assert if exception is thrown when string is null
        Assert.ThrowsException<ArgumentException>(() => service.ValidatePassword(null), "No input value");

        // Assert if method returns true on validation success
        Assert.IsTrue(service.ValidatePassword(validPasswordWithinRange));
    }

    [DataTestMethod]
    [DataRow("1234567(","123456(")] // string of 8 and 7 characters
    [DataRow("!1234567", "!123456")] // string of 8 and 7 characters
    [DataRow("1234567891234567890!", "123456789g1234h678901!")] // string of 20 and 21 characters
    [DataRow("Thisis20Character!!s","!1234567f901e34567890")] // string of 20 and 21 characters
    public void ValidateInputForPasswordRegistration_EdgeTests_ShouldReturnTrueWithinRangeAndThrowExceptionOutOfRange(string withinRange, string outOfRange)
    {
        // Arrange
        UserRegistrationService service = new UserRegistrationService();

        // Act and Assert

        // Assert when password is within range
        Assert.IsTrue(service.ValidatePassword(withinRange));

        // Assert when password is out of range
        Assert.ThrowsException<ArgumentException>(() => service.ValidatePassword(outOfRange), "Invalid number of characters");
    }
}