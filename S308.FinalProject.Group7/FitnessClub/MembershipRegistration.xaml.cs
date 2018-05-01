using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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

namespace FitnessClub
{
    /// <summary>
    /// image source: http://www.truegritness.com/wp-content/uploads/2014/12/TG-BKG-IRON-GYM-SM-DARK.jpg
    /// Interaction logic for MembershipSignUp.xaml
    /// User gets to the Membership Registration page after entering in information in the Membership Sales Page. Can navigate back to the Membership Sales and Main Menu pages.
    /// </summary>
    public partial class MembershipSignUp : Window
    {
        public CustomerPaymentInfo InfoFromPrevWindow { get; set; }

        List<Member> memberlist;

        public MembershipSignUp()
        {

            InitializeComponent();
            Clear();
            imgCard.Visibility = Visibility.Hidden;
            lblCreditType.Content = "";

            //1. Initialize list
            memberlist = new List<Member>();
            Files calFiles = new Files();

            //2. Set file location and timestamp for method
            string strFilePath = @"..\..\..\Data\Members";
            string isTimestamp = DateTime.Now.Ticks.ToString();

            //3. Grab file location with extension
            string LoadedFilePath = calFiles.GetFilePath(strFilePath, "json", false);

            //4. Read in data
            System.IO.StreamReader reader = new System.IO.StreamReader(LoadedFilePath);
            string jsonData = reader.ReadToEnd();
            reader.Close();

            //5. Deseralize it to a list
            memberlist = JsonConvert.DeserializeObject<List<Member>>(jsonData);

            // default blank member info for the default constructor
            InfoFromPrevWindow = new CustomerPaymentInfo();
        }
        public MembershipSignUp(CustomerPaymentInfo info)
        {
            //don't forget this line when overriding the constructor for a window
            InitializeComponent();

            //assigning the property from the member info class that was passed into this overridden constructor
            InfoFromPrevWindow = info;

            //do something with the information that was passed in
            //DoSomethingWithInfo();
        }



        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //1. Intialize variables
            string strFirstName = txtFirstName.Text;
            string strLastName = txtLastName.Text;
            string strGender = cboGender.Text;
            string strEmailAddress = txtEmail.Text;
            string strPhoneNumber = txtPhone.Text;
            string strWeight = txtWeight.Text;
            string strAge = txtAge.Text;
            string strFitnessGoal = cboGender.Text;

            //2. Check to see if required fields are filled
            bool isFirstNameEmpty = txtFirstName.Text.Length == 0;
            bool isLastNameEmpty = txtLastName.Text.Length == 0;
            bool isGenderSelected = cboGender.SelectedIndex == -1;
            bool isEmailEmpty = txtEmail.Text.Length == 0;
            bool isPhoneEmpty = txtPhone.Text.Length == 0;

            //2.1 Validation for blank required fields
            if (isFirstNameEmpty || isLastNameEmpty || isGenderSelected || isEmailEmpty || isPhoneEmpty)
            {
                MessageBox.Show("Please fill out the First Name, Last Name, Gender, Email Address, and Phone Number fields.");
                return;
            }

            //3 Check if Age and Weight are valid numbers
            byte bytAgeNum;
            int intWeight;

            if (strAge.Length > 0)
            {
                bool isAgeNum = Byte.TryParse(strAge, out bytAgeNum) == false;
                if (isAgeNum)
                {
                    txtAge.Text = "";
                    MessageBox.Show("Please enter a valid number for Age.");
                    return;
                }
            }

            if (strWeight.Length > 0)
            {
                bool isWeightNum = Int32.TryParse(strWeight, out intWeight) == false;
                if (isWeightNum)
                {
                    txtWeight.Text = "";
                    MessageBox.Show("Please enter a valid number Weight.");
                    return;
                }
            }
            //4 Validate email address
            //4.1 Set variables to "@" and "." spaces for parse tests
            bool hasSymbol = strEmailAddress.Contains("@") == true;
            bool hasPeriod = strEmailAddress.Contains(".") == true;

            if (!(hasPeriod) || !(hasSymbol))
            {
                txtEmail.Text = "";
                MessageBox.Show("Please enter a valid email address");
                return;
            }


            int intSymbol = strEmailAddress.IndexOf("@");
            int intPeriod = strEmailAddress.IndexOf(".");
            string strUserName = strEmailAddress.Substring(0, intSymbol);
            string strPeriod = strEmailAddress.Substring(intSymbol + 1, intPeriod - intSymbol - 1);
            string strDomain = strEmailAddress.Substring(intPeriod + 1);

            //4.2 Test if email meets criteria based on specifications in instructions
            if (strUserName.Length < 1 || strPeriod.Length < 1 || strDomain.Length < 2)
            {
                txtEmail.Text = "";
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            //5 Check if phone number is valid
            //5.1 check if number is formatted correctly
            bool hasTwoHyphens = (strPhoneNumber.IndexOf("-") == 3) && (strPhoneNumber.LastIndexOf("-") == 7);

            if (hasTwoHyphens)
            {
                int intAreaCode, intMiddleNum, intLastNum;
                int intFirstHyphen = strPhoneNumber.IndexOf("-");
                int intSecondHyphen = strPhoneNumber.LastIndexOf("-");
                string strAreaCode = strPhoneNumber.Substring(0, intFirstHyphen);
                string strMiddleNum = strPhoneNumber.Substring(intFirstHyphen + 1, intSecondHyphen - intFirstHyphen - 1);
                string strLastNum = strPhoneNumber.Substring(intSecondHyphen + 1);

                bool isAreaCodeNum = Int32.TryParse(strAreaCode, out intAreaCode);
                bool isMiddleNum = Int32.TryParse(strMiddleNum, out intMiddleNum);
                bool isLastNum = Int32.TryParse(strLastNum, out intLastNum);

                if (strAreaCode.Length != 3 || strMiddleNum.Length != 3 || strLastNum.Length != 4 || strPhoneNumber.Length != 12 || !isAreaCodeNum || !isMiddleNum || !isLastNum)
                {
                    txtPhone.Text = "";
                    MessageBox.Show("Please enter a valid phone number.");
                    return;
                }

            }
            else
            {
                txtPhone.Text = "";
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }

            //Credid Card information
            //1. Initalize variables and assign it to values in text boxes
            string strCreditCardNumber = txtCreditCardNumber.Text;
            string strCreditCardType = "";
            string strExpYear = cboYear.Text;
            string strExpMonth = cboMonth.Text;
            string strBillingAddress = txtBillingAddress.Text;
            string strCity = txtCity.Text;
            string strState = cboState.Text;
            string strZipCode = txtZip.Text;
            int intZipCode = 0;

            //2. Initialize isNull variables to see if all fields were filled out
            bool isCreditNumEmpty = strCreditCardNumber.Length == 0;
            bool isExpYear = cboYear.SelectedIndex == -1;
            bool isExpMonth = cboMonth.SelectedIndex == -1;
            bool isAddressEmpty = strBillingAddress.Length == 0;
            bool isCityEmpty = strCity.Length == 0;
            bool isStateSelected = cboState.SelectedIndex == -1;
            bool isZipEmpty = strZipCode.Length == 0;
            bool isZipNum = Int32.TryParse(strZipCode, out intZipCode);

            //3. Test if fields are empty
            if (isCreditNumEmpty || isExpYear || isExpMonth || isAddressEmpty || isCityEmpty || isStateSelected || isZipEmpty)
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            //4. Test Validity in Credit Card Information
            //4.1 Set testing variables for credit card validity
            Member calCardNum = new Member();

            //4.2 Test if a number is entered
            bool isNum = calCardNum.CardNumValid(strCreditCardNumber);

            if (isNum == false)
            {
                txtCreditCardNumber.Text = "";
                MessageBox.Show("Credit card number not valid.");
                return;
            }

            //4.3 Test if number is a proper length
            bool isCreditLength = calCardNum.CheckCreditLength(strCreditCardNumber);

            if (isCreditLength == false)
            {
                txtCreditCardNumber.Text = "";
                MessageBox.Show("Credit card number not valid");
                return;
            }

            //4.5 Pass credit card number through Luhn algorthim
            bool isLuhnValid = calCardNum.Luhn(strCreditCardNumber);

            if (isLuhnValid == false)
            {
                txtCreditCardNumber.Text = "";
                MessageBox.Show("Credit card number not valid");
                return;
            }

            //4.6 Check if credit card is expired
            int intExpMonth = Convert.ToInt32(strExpMonth);
            int intExpYear = Convert.ToInt32(strExpYear);

            bool isCreditCardExpired = calCardNum.isExpired(intExpMonth, intExpYear);

            if (isCreditCardExpired == false)
            {
                cboYear.SelectedIndex = -1;
                cboMonth.SelectedIndex = -1;
                MessageBox.Show("Expiration date not valid.");
                return;
            }
            //4.6 Return card type
            strCreditCardType = calCardNum.CardType(strCreditCardNumber);

            //4.7 Perform logic to display proper credit card image
            switch (strCreditCardType)
            {
                case "AMEX":
                    imgCard.Source = new BitmapImage(new Uri(@"/CardLogos/american_express_logo.png", UriKind.Relative));
                    imgCard.Stretch = Stretch.Fill;
                    break;
                case "Discover":
                    imgCard.Source = new BitmapImage(new Uri(@"CardLogos/discover_logo.png", UriKind.Relative));
                    imgCard.Stretch = Stretch.Fill;
                    break;
                case "MasterCard":
                    imgCard.Source = new BitmapImage(new Uri(@"/CardLogos/mastercard_logo.png", UriKind.Relative));
                    imgCard.Stretch = Stretch.Fill;
                    break;
                case "Visa":
                    imgCard.Source = new BitmapImage(new Uri(@"/CardLogos/visa_logo.png", UriKind.Relative));
                    imgCard.Stretch = Stretch.Fill;
                    break;
            }
            //Check is zipcode is valid
            if (isZipNum == false)
            {
                txtZip.Text = "";
                MessageBox.Show("Please enter a valid zipcode.");
                return;
            }
            imgCard.Visibility = Visibility.Visible;
            txtCreditCardNumber.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            lblCreditType.Content = strCreditCardType;

            //Reveal create customer button
            btnCreate.Foreground = Brushes.White;
            btnCreate.BorderBrush = Brushes.White;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //1. Read in file again in local scope in order to update file

            //1.1 Initialize list
            memberlist = new List<Member>();
            Files calFiles = new Files();

            //1.2. Set file location and timestamp for method
            string strFilePath = @"..\..\..\Data\Members";
            string isTimestamp = DateTime.Now.Ticks.ToString();

            //1.3. Grab file location with extension
            string LoadedFilePath = calFiles.GetFilePath(strFilePath, "json", false);

            //1.4. Read in data
            System.IO.StreamReader reader = new System.IO.StreamReader(LoadedFilePath);
            string jsonData = reader.ReadToEnd();
            reader.Close();

            //1.5. Deseralize it to a list
            memberlist = JsonConvert.DeserializeObject<List<Member>>(jsonData);

            //add new member
            Member memberNew = new Member(txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), cboGender.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim(), txtWeight.Text.Trim(), txtAge.Text.Trim(), cboFitnessGoals.Text.Trim(), InfoFromPrevWindow.MembershipType, InfoFromPrevWindow.StartDate, InfoFromPrevWindow.EndDate, InfoFromPrevWindow.MembershipPrice, InfoFromPrevWindow.AdditionalFeatures, InfoFromPrevWindow.TotalPrice, txtCreditCardNumber.Text.Trim(), lblCreditType.Content.ToString(), txtBillingAddress.Text.Trim(), txtCity.Text.Trim(), txtZip.Text.Trim());

            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to save the following member?"
              + Environment.NewLine + Environment.NewLine + memberNew.ToString()
            , "Create New Member"
            , MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                memberlist.Add(memberNew);

                AppendToFile(memberNew);

                Clear();

                string updateJsonData = JsonConvert.SerializeObject(memberlist);
                System.IO.File.WriteAllText(LoadedFilePath, updateJsonData);

                MessageBox.Show("Export completed!" + Environment.NewLine + "File Created: " + strFilePath);

                //Hide create customer button
                btnCreate.Foreground = Brushes.Black;
                btnCreate.BorderBrush = Brushes.Black;
            }
        }
        private void AppendToFile(Member memberNew)
        {
            //define strings
            string strFilePath = @"..\..\..\Data\Members";
            string strLine;

            //append customer to JSON file
            try
            {
                StreamWriter writer = new StreamWriter(strFilePath, true);
                strLine = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}", memberNew.Fullname, memberNew.FirstName, memberNew.LastName, memberNew.Gender,
                                                                                                                                     memberNew.EmailAddress, memberNew.PhoneNumber, memberNew.Weight,
                                                                                                                                     memberNew.Age, memberNew.FitnessGoal, InfoFromPrevWindow.MembershipType,
                                                                                                                                     InfoFromPrevWindow.StartDate, InfoFromPrevWindow.EndDate, InfoFromPrevWindow.MembershipPrice,
                                                                                                                                     InfoFromPrevWindow.AdditionalFeatures, InfoFromPrevWindow.TotalPrice, memberNew.CreditCardNumber,
                                                                                                                                     memberNew.CreditCardType, memberNew.BillingAddress, memberNew.City, memberNew.Zip);
                writer.WriteLine(strLine);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in append file: " + ex.Message);
                return;
            }
        }
        private void Clear()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtWeight.Text = "";
            txtAge.Text = "";
            txtEmail.Text = "";
            cboFitnessGoals.SelectedIndex = -1;
            cboGender.SelectedIndex = -1;
            lblCreditType.Content = "";
            imgCard.Visibility = Visibility.Hidden;
            txtBillingAddress.Text = "";
            txtCity.Text = "";
            txtCreditCardNumber.Text = "";
            cboYear.SelectedIndex = -1;
            cboMonth.SelectedIndex = -1;
            cboState.SelectedIndex = -1;
            txtZip.Text = "";

            //Hide create customer button
            btnCreate.Foreground = Brushes.Black;
            btnCreate.BorderBrush = Brushes.Black;
        }

        #region Navigation controls
        private void txbMemSales_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MembershipSales winMemberSales = new MembershipSales();
            winMemberSales.Show();
            this.Close();
        }
        
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }
        #endregion


       

    }
}