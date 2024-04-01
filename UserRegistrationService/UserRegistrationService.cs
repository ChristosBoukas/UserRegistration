using System.Text.RegularExpressions;
using UserRegistrationService;

namespace userregistrationservice;

public class UserRegistrationService
{
    public List<User> Users { get; set; } = [];

    public void CreateUser(string userName, string password, string email)
    {
        ValidateUserName(userName);
        ValidatePassword(password);
        ValidateEmail(email);

        // If all validations pass, create and add the user
        User user = new User
        {
            UserName = userName,
            Password = password,
            Email = email
        };

        Users.Add(user);
    }

    public bool ValidateUserName(string inputValue)
    {
        // Define a regular expression pattern for alphanumeric characters only
        string pattern = "^[a-zA-Z0-9]+$";

        // Check if the inputValue length is within the valid range
        if (inputValue is null)
        {
            throw new ArgumentException("No input value");
        }

        // Check if the inputValue length is within the valid range
        if (inputValue.Length < 5 || inputValue.Length > 20)
        {
            throw new ArgumentException("Invalid number of characters");
        }

        // Check if the inputValue contains only alphanumeric characters
        if (!Regex.IsMatch(inputValue, pattern))
        {
            throw new ArgumentException("Contains special characters");
        }

        // Username is valid
        return true;
    }

    public bool ValidatePassword(string password)
    {
        return true;
    }

    public bool ValidateEmail(string email)
    {
        return true;
    }
}
