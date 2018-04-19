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

namespace FitnessClub
{
    /// <summary>
    /// image source: http://www.truegritness.com/wp-content/uploads/2014/12/TG-BKG-IRON-GYM-SM-DARK.jpg
    /// Interaction logic for MembershipSignUp.xaml
    /// User gets to the Membership Registration page after entering in information in the Membership Sales Page. Can navigate back to the Membership Sales and Main Menu pages.
    /// </summary>
    public partial class MembershipSignUp : Window
    {
        public MembershipSignUp()
        {
            InitializeComponent();
        }

        private void btnMainMenu1_Click(object sender, RoutedEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales winMemberSales = new MembershipSales();
            winMemberSales.Show();
            this.Close();
        }

        private void btnRegister1_Click(object sender, RoutedEventArgs e)
        {
            // Initalize input variables
            string strFirstName = txtFirstName.Text;
            string strLastName = txtLastName.Text;
            string strGender = cboGender.Text;
            DateTime? datBirthday = dtDatePicker.SelectedDate;
            string strEmail = txtEmail.Text;
            string strPhone = txtPhone.Text;
            string strGoal = cboFitnessGoals.Text;
            string strCreditNum = txtCreditCardNum.Text;
            string strCreditType = txtCreditCardType.Text;
            string strSecurityCode = txtSecurityCode.Text;
            string strBillingAddress = txtBillingAddress.Text;
            string strCity = txtCity.Text;
            string strState = cboState.Text;
            string strZip = txtZip.Text;


            //Provide validation for all fields

            //Make sure all fields required are filled out
            bool isFNameEmpty = txtFirstName.Text.Length == 0;
            bool isLNameEmpty = txtLastName.Text.Length == 0;
            bool isCreditCardEmpty = txtCreditCardNum.Text.Length == 0;
            bool isCreditTypeEmpty = txtCreditCardType.Text.Length == 0;
            bool isPhoneEmpty = txtPhone.Text.Length == 0;
            bool isEmailEmpty = txtEmail.Text.Length == 0;
            bool isBirthdaySelected = dtDatePicker.SelectedDate == null;
            bool isGenderSelected = cboGender.SelectedIndex == -1;
           // bool isPhoneNum = Int64.TryParse(strPhone, out long lngPhone);

            #region check if required fields are empty
            // Display proper error messages for empty values
            if (isFNameEmpty)
            {
                MessageBox.Show("Please enter a first name.");
                return;
            }
            if (isLNameEmpty)
            {
                MessageBox.Show("Please enter a last name.");
                return;
            }
            if (isCreditCardEmpty)
            {
                MessageBox.Show("Please enter a credit card number.");
                return;
            }
            if (isCreditTypeEmpty)
            {
                MessageBox.Show("Please enter a credit card type.");
                return;
            }
            if (isPhoneEmpty)
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }
            if (isEmailEmpty)
            {
                MessageBox.Show("Please enter an email address");
                return;
            }
            if (isBirthdaySelected)
            {
                MessageBox.Show("Please select a date");
                return;
            }
            if (isGenderSelected)
            {
                MessageBox.Show("Please select a gender.");
                return;
            }
            #endregion
            #region Specific validation for fields
            // Provide valdiation for fields that require more validation
            //Phone number

            //Weight
            //Credit Card
            //Security code
            //Expiration date
            //Zip code
            #endregion
        }
    }
}