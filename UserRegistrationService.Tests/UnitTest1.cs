namespace userregistrationservice.tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void RegisterName()
    {
        // Arrange
        UserRegistrationService service = new UserRegistrationService();
        string numericValuesExceedingLimit = "OnlyAlphaNumericChars0123456789";
        string numericValuesConceedingLimit = "cl12";
        string specialCharacters = "SpecialCharacters#!£€{";
        string numericCharactersWithinRange = "Character12345";

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => service.RegisterUserName(numericValuesExceedingLimit), "Invalid number of characters");
        Assert.ThrowsException<ArgumentException>(() => service.RegisterUserName(numericValuesConceedingLimit), "Invalid number of characters");
        Assert.ThrowsException<ArgumentException>(() => service.RegisterUserName(specialCharacters), "Contains special characters");
        Assert.IsTrue(service.RegisterUserName(numericCharactersWithinRange));
    }
}