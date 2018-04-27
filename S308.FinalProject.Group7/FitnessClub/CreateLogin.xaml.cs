using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Linq;

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for CreateLogin.xaml
    /// </summary>
    public partial class CreateLogin : Window
    {
        List<LoginCredentials> loginCredential;
        public CreateLogin()
        {
          
            InitializeComponent();
            //1. Import data
            Import();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            //2. Set variables equal to text output
            string strUsername = txtUsername.Text;
            string strPassword = txtPassword.Text;

            //2. Check if fields are filled out
            if (strUsername.Length == 0 || strPassword.Length == 0)
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }

            //3. Check if username already exists
            if (CheckUserName(strUsername) == false)
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                MessageBox.Show("Username already exists");
                return;
            }

            //4. Instanciate a new instance
            LoginCredentials loginUpdate = new LoginCredentials(strUsername.Trim(), strPassword.Trim());

            //5. Send message box message to allow user to continue
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to proceed with user authentication?"
                + Environment.NewLine 
                , "Create New User Login"
                , MessageBoxButton.YesNo);

            //6. If 'yes' is selected, append to file, clear contents
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                loginCredential.Add(loginUpdate);
                Append(loginUpdate);
                Clear();
                MessageBox.Show("New User Saved!");
            }
        }

        #region Helper functions
        //Clear contents button
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }


        // Check if username exists
        public bool CheckUserName(string username)
        {
            bool isValid = false;
            int intCounter = 0;
            foreach (var i in loginCredential)
            {
                if (i.username == username)
                {
                    intCounter += 1 ;
                }
            }
            if (intCounter >= 1)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }
        // Import function
        public void Import()
        {
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

        //Append new data to file
        public void Append(LoginCredentials loginUpdate)
        {
            string LoadedFilePath = @"..\..\..\Data\Login.json";
            try
            {
                string jsonData = JsonConvert.SerializeObject(loginCredential);
                System.IO.File.WriteAllText(LoadedFilePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in append file: " + ex.Message);
                return;
            }
        }

        //Clear contents
        private void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        //Mouse up to login screen
        private void txbLogin_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Login winLogin = new Login();
            winLogin.Show();
            this.Close();
        }
        #endregion

    }
}
