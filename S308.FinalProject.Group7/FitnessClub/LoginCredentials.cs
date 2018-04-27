namespace FitnessClub
{
    public class LoginCredentials
    {
        public string username { get; set; }
        public string password { get; set; }

        public LoginCredentials()
        {

        }

        public LoginCredentials(string strUserName, string strPassword)
        {
            username = strUserName;
            password = strPassword;
        }
    }
}
