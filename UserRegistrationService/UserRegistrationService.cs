using System.Text.RegularExpressions;
using UserRegistrationService;

namespace userregistrationservice;

public class UserRegistrationService
{
    public List<User> Users { get; set; } = [];

    public string CreateUser(string username, string password, string email)
    {
        ValidateUsername(username);
        ValidateUniqueUsername(username);
        ValidatePassword(password);
        ValidateEmail(email);

        // If all validations pass, create and add the user
        User user = new User
        {
            Username = username,
            Password = password,
            Email = email
        };

        Users.Add(user);
        return $"User {username} added successfully";
    }

    public bool ValidateUsername(string inputValue)
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

    public bool ValidateUniqueUsername(string username)
    {
        User? uniqueUser = Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (uniqueUser is not null)
        { 
            throw new ArgumentException("Username is not unique.");
        }
        return true;
    }

    public bool ValidatePassword(string inputValue)
    {
        // Define a regular expression pattern for alphanumeric characters
        string alphanumericPattern = "^[a-zA-Z0-9]+$";
        // Define a regular expression pattern for special characters
        string specialCharacterPattern = "[^a-zA-Z0-9]";

        // Check if the inputValue length is within the valid range
        if (inputValue is null)
        {
            throw new ArgumentException("No input value");
        }

        // Check if the inputValue length is within the valid range
        if (inputValue.Length < 8 || inputValue.Length > 20)
        {
            throw new ArgumentException("Invalid number of characters");
        }

        // Check if the inputValue contains at least one special character
        if (!Regex.IsMatch(inputValue, specialCharacterPattern))
        {
            throw new ArgumentException("Password must contain at least one special character");
        }

        // Check if the inputValue contains only alphanumeric characters
        if (Regex.IsMatch(inputValue, alphanumericPattern))
        {
            throw new ArgumentException("Password must contain at least one special character");
        }

        // Password is valid
        return true;
    }

    public bool ValidateEmail(string email)
    {
        return true;
    }
}
