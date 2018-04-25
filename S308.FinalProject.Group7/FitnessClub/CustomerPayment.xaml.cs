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
    /// Interaction logic for CustomerPayment.xaml
    /// </summary>
    public partial class CustomerPayment : Window
    {
        public CustomerPayment()
        {
            InitializeComponent();

            imgCard.Visibility = Visibility.Hidden;
            lblCreditType.Content = "";
           
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //1. Initalize variables and assign it to values in text boxes
            string strCreditCardNumber = txtCreditCardNumber.Text;
            string strCreditCardType = "";
            string strExpYear = cboYear.Text;
            string strExpMonth = cboMonth.Text;
            string strBillingAddress = txtBillingAddress.Text;
            string strCity = txtCity.Text;
            string strState = cboState.Text;
            string strZipCode = txtZip.Text;
            string strExistUser = cboExistingMember.Text;
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
            CreditCard calCardNum = new CreditCard();

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

            if(isCreditCardExpired == false)
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
                        imgCard.Width = 22;
                        imgCard.Height = 22;
                        break;
                    case "Discover":
                        imgCard.Source = new BitmapImage(new Uri(@"CardLogos/discover_logo.png", UriKind.Relative));
                        imgCard.Width = 32;
                        imgCard.Height = 22;
                        break;
                    case "MasterCard":
                        imgCard.Source = new BitmapImage(new Uri(@"/CardLogos/mastercard_logo.png", UriKind.Relative));
                        imgCard.Width = 40;
                        imgCard.Height = 25;
                        break;
                    case "VISA":
                        imgCard.Source = new BitmapImage(new Uri(@"/CardLogos/visa_logo.png", UriKind.Relative));
                        imgCard.Width = 35;
                        imgCard.Height = 22;
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
                Clear();
                MessageBox.Show("Registration was a success!");
              
        }
        #region Clear Contents
        //Clear contents function
        private void Clear()
        {
            lblCreditType.Content = "";
            imgCard.Visibility = Visibility.Hidden;
            txtBillingAddress.Text = "";
            txtCity.Text = "";
            txtCreditCardNumber.Text = "";
            cboYear.SelectedIndex=-1;
            cboMonth.SelectedIndex = -1;
            cboState.SelectedIndex = -1;
            txtZip.Text = "";
        }

        
        //Clear contents button
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        #endregion


        #region Navigation features
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }
        private void txbMemSales_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MembershipSales winMemberSales = new MembershipSales();
            winMemberSales.Show();
            this.Close();
        }
        #endregion
    }
}
