using UserRegistrationService;

namespace userregistrationservice;

public class UserRegistrationService
{
    public List<User> Users { get; set; } = [];

    public void RegisterUser(User user)
    {

    }

    public bool RegisterUserName(string userName)
    {
        try
        {   
            return true;
        }
        catch (Exception ex)
        {

        }

        return false;
    }

    public void RegisterPassword(string password)
    {
        
    }

    public void RegisterEmail(string email)
    {
        
    }
}
