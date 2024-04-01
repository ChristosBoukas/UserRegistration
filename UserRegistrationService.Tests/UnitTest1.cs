using UserRegistrationService;

namespace userregistrationservice.tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void ValidateInputForUsernameRegistration_ShouldThrowExceptionsForInvalidInputAndReturnsTrueForValidInput()
    {
        // Arrange variations of strings
        UserRegistrationService service = new UserRegistrationService();
        string numericValuesExceedingCharLimit = "OnlyAlphaNumericChars0123456789";
        string numericValuesConceedingCharLimit = "cl12";
        string specialCharacters = "SpecialCharacters#!£€{";
        string nullString = null;
        string numericCharactersWithinRange = "Character12345";

        // Act and Assert

        // Check if exception is thrown when string exceeding character limit
        Assert.ThrowsException<ArgumentException>(() => service.ValidateUserName(numericValuesExceedingCharLimit), "Invalid number of characters");

        // Check if exception is thrown when string concceeding character limit
        Assert.ThrowsException<ArgumentException>(() => service.ValidateUserName(numericValuesConceedingCharLimit), "Invalid number of characters");

        // Check if exception is thrown when string contains special characters
        Assert.ThrowsException<ArgumentException>(() => service.ValidateUserName(specialCharacters), "Contains special characters");

        // Check if exception is thrown when string is null
        Assert.ThrowsException<ArgumentException>(() => service.ValidateUserName(null), "No input value");

        // Checks if method returns true if validation succeeds
        Assert.IsTrue(service.ValidateUserName(numericCharactersWithinRange));
    }

    [TestMethod]
    public void CreateUser()
    {
        UserRegistrationService service = new UserRegistrationService();
        User user = new User();

    }
}