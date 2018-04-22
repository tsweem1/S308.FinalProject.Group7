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
            Clear();
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
                MessageBox.Show("Please fill out the First Name, Last Name, Gender, Emaill Address, and Phone Number fields.");
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
        }

        #region Navigation controls
        private void txbMemSales_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MembershipSales winMemberSales = new MembershipSales();
            winMemberSales.Show();
            this.Close();
        }
        private void txbPaymentInfo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CustomerPayment winCustomerPayment = new CustomerPayment();
            winCustomerPayment.Show();
            this.Close();
        }
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }
        #endregion


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
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

    }
}