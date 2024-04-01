using System.Text.RegularExpressions;
using UserRegistrationService;

namespace userregistrationservice;

public class UserRegistrationService
{
    public List<User> Users { get; set; } = [];

    public void RegisterUser(User user)
    {

    }

    public bool RegisterUserName(string inputValue)
    {
        // Define a regular expression pattern for alphanumeric characters only
        string pattern = "^[a-zA-Z0-9]+$";

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

    public void RegisterPassword(string password)
    {
        
    }

    public void RegisterEmail(string email)
    {
        
    }
}
