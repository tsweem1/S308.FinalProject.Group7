namespace FitnessClub
{
    public class LoginCredentials
    {
        //1. Set Properties
        public string username { get; set; }
        public string password { get; set; }

        public LoginCredentials()
        {

        }
        //2. Create Constructor
        public LoginCredentials(string strUserName, string strPassword)
        {
            username = strUserName;
            password = strPassword;
        }
    }
}
