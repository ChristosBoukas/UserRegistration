using UserRegistrationService;

namespace userregistrationservice.tests;

[TestClass]
public class UsernameTests
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
        Assert.ThrowsException<ArgumentException>(() => service.ValidateUsername(numericValuesExceedingCharLimit), "Invalid number of characters");

        // Check if exception is thrown when string concceeding character limit
        Assert.ThrowsException<ArgumentException>(() => service.ValidateUsername(numericValuesConceedingCharLimit), "Invalid number of characters");

        // Check if exception is thrown when string contains special characters
        Assert.ThrowsException<ArgumentException>(() => service.ValidateUsername(specialCharacters), "Contains special characters");

        // Check if exception is thrown when string is null
        Assert.ThrowsException<ArgumentException>(() => service.ValidateUsername(null), "No input value");

        // Checks if method returns true if validation succeeds
        Assert.IsTrue(service.ValidateUsername(numericCharactersWithinRange));
    }

    [DataTestMethod]
    [DataRow("12345", "1234")] // string of 5 and 4 characters
    [DataRow("InRa3", "Hej4")] // string of 5 and 4 characters
    [DataRow("12345678912345678901", "123456789123456789012")] // string of 20 and 21 characters
    [DataRow("Thisis20Charactersss", "Thisis21Characterssss")] // string of 20 and 21 characters
    public void ValidateInputForUsernameRegistration_EdgeTests_ShouldReturnTrue(string usernameInRange, string usernameOutOfRange)
    {
        // Arrange variations of strings
        UserRegistrationService service = new UserRegistrationService();

        // Act and Assert

        // Assert if method returns true on validation success (characters of 5 - 20 range)
        Assert.IsTrue(service.ValidateUsername(usernameInRange));

        // Assert when password is out of range (characters of 5 - 20 range)
        Assert.ThrowsException<ArgumentException>(() => service.ValidatePassword(usernameOutOfRange), "Invalid number of characters");



    }

        [TestMethod]
    public void ValidateIfUsernameIsUnique_UsernameIsNotTaken_ShouldReturnTrue()
    {
        //Arrange
        UserRegistrationService service = new UserRegistrationService();

        //Act
        bool usernameIsUnique = service.ValidateUniqueUsername("newUniqueUsername");

        //Assert
        Assert.IsTrue(usernameIsUnique);
    }

    [DataTestMethod]
    [DataRow("UniqueUsername")]
    [DataRow("uniqueUseRname")]
    [DataRow("unIqueUseRnamE")]
    [TestMethod]
    public void ValidateIfUsernameIsUnique_UsernameIsAlreadyTaken_ShouldReturnFalse(string username)
    {
        //Arrange
        UserRegistrationService service = new UserRegistrationService();
        service.Users.Add(new User() { Username = "uniqueUsername", Password = "password", Email = "email@email.com" });

        //Act and Assert
        Assert.ThrowsException<ArgumentException>(() => service.ValidateUniqueUsername($"{username}"), "Username is not unique.");
    }
}