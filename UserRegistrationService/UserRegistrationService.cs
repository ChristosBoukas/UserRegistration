using System.Text.RegularExpressions;
using UserRegistrationService;

namespace userregistrationservice;

public class UserRegistrationService
{
    public List<User> Users { get; set; } = [];

    /// <summary>
	/// Validates parameters, upon verification creates a new user and adds it to users list.
	/// </summary>
	/// <param name="username"></param>
	/// <param name="password"></param>
	/// <param name="email"></param>
    /// <returns>A message string on success, throws exception on fail</returns>
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

    /// <summary>
    /// Validates the input value is in correct format (e.g only alphanumerical characters between 5-20 long).
    /// </summary>
    /// <param name="inputValue"></param>
    ///<returns>Bool (True) on success, throws exception on fail</returns>
    public bool ValidateUsername(string inputValue)
    {
        // Define a regular expression pattern for alphanumeric characters only
        string pattern = "^[a-zA-Z0-9]+$";

        // Check if the inputValue length is not null
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

    /// <summary>
    /// Validates the input value is a unique username compared to Username properti in Users list objects. Comparison is case-insensitive.
    /// </summary>
    /// <param name="inputValue"></param>
    ///<returns>Bool (True) on success, throws exception on fail</returns>
    public bool ValidateUniqueUsername(string inputValue)
    {
        User? uniqueUser = Users.FirstOrDefault(u => u.Username.Equals(inputValue, StringComparison.OrdinalIgnoreCase));
        if (uniqueUser is not null)
        { 
            throw new ArgumentException("Username is not unique.");
        }
        return true;
    }

    /// <summary>
    /// Validates the input value is in correct format (e.g contains at least one special character and is between 8-20 long).
    /// </summary>
    /// <param name="inputValue"></param>
    ///<returns>Bool (True) on success, throws exception on fail</returns>
    public bool ValidatePassword(string inputValue)
    {
        // Define a regular expression pattern for alphanumeric characters
        string alphanumericPattern = "^[a-zA-Z0-9]+$";
        // Define a regular expression pattern for special characters
        string specialCharacterPattern = "[^a-zA-Z0-9]";

        // Check if the inputValue length is not null
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

    /// <summary>
    /// Validates the input value is in correct email format (e.g user@example.com).
    /// </summary>
    /// <param name="inputValue"></param>
    ///<returns>Bool (True) on success, throws exception on fail</returns>
    public bool ValidateEmail(string inputValue)
    {
        // Check if the inputValue length is not null
        if (inputValue is null)
        {
            throw new ArgumentException("No input value");
        }

        // Define a regular expression pattern for email format
        string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";

        // Check if the inputValue matches the email pattern
        if (!Regex.IsMatch(inputValue, emailPattern))
        {
            throw new ArgumentException("Invalid email format");
        }

        // Email is valid
        return true;
    }
}
