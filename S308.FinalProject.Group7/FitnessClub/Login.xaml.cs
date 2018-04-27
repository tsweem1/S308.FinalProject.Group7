using System;
using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using System.Linq;

namespace FitnessClub
{
    /// <summary>
    /// image source: https://images.springer.com/sgw/books/medium/9781137346612.jpg
    /// Interaction logic for Login.xaml
    /// Before accessing the other pages, user must enter in login information. once logged in, the user will be taken to the main menu page
    /// </summary>
    public partial class Login : Window
    {
        List<LoginCredentials> loginCredential;
        public Login()
        {
            
            InitializeComponent();
            //1. Initialize list
            loginCredential = new List<LoginCredentials>();
            Files calFiles = new Files();

            //2. Set file location and timestamp for method
            string strFileLocation = @"..\..\..\Data\Login";
            string isTimestamp = DateTime.Now.Ticks.ToString();

            //3. Grab file location with extension
            string LoadedFilePath = calFiles.GetFilePath(strFileLocation, "json", false);

            //4. Read in data
            System.IO.StreamReader reader = new System.IO.StreamReader(LoadedFilePath);
            string jsonData = reader.ReadToEnd();
            reader.Close();

            //5. Deseralize it to a list
            loginCredential = JsonConvert.DeserializeObject<List<LoginCredentials>>(jsonData);

        }

        public void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            //6. Set Variables
            string strUserName = txtUsername.Text;
            string strPassWord = txtPassword.Text;

           //7. Check if username is filled out
           if(CheckUserName(strUserName) == false)
            {
                txtUsername.Text = "";
                MessageBox.Show("Username not in system.");
                return;
            }
           //8. Check if password matches user's password
            var passwordQuery =
                from c in loginCredential
                where (c.username.Trim() == strUserName.Trim())
                select c.password;

            //9. Convert user's password to string
            string strInputPassWord = String.Join(",", passwordQuery);

            //10. Check if input user matches the actual user name
            if(strInputPassWord != strPassWord)
            {
                txtPassword.Text = "";
                MessageBox.Show("Password is incorrect.");
                return;
            }

            //11. Send greeting message to user
            MessageBox.Show("Welcome"+" "+strUserName+"!");

            //12. Go to main menu
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        //13. Function to check if username is in the system
        public bool CheckUserName(string username)
        {
            bool isValid = false;
            int intCounter = 0;
            foreach (var i in loginCredential)
            {
                if (i.username == username)
                {
                    intCounter += 1;
                }
            }
            if (intCounter == 1)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }

}
    }

