namespace userregistrationservice.tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void RegisterName()
    {
        // Arrange
        UserRegistrationService service = new UserRegistrationService();
        string inputValue = "inputValue";

        // Act
        bool registerSuccesfull = service.RegisterUserName(inputValue);

        // Assert
        Assert.IsTrue(registerSuccesfull);

    }
}