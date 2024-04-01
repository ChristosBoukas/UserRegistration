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
        string numericCharactersWithinRange = "Character12345";

        // Act and Assert

        // Check if exception is thrown when string exceeding character limit
        Assert.ThrowsException<ArgumentException>(() => service.RegisterUserName(numericValuesExceedingCharLimit), "Invalid number of characters");

        // Check if exception is thrown when string concceeding character limit
        Assert.ThrowsException<ArgumentException>(() => service.RegisterUserName(numericValuesConceedingCharLimit), "Invalid number of characters");

        // Check if exception is thrown when string contains special characters
        Assert.ThrowsException<ArgumentException>(() => service.RegisterUserName(specialCharacters), "Contains special characters");

        // Checks if method returns true if validation succeeds
        Assert.IsTrue(service.RegisterUserName(numericCharactersWithinRange));
    }
}