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
using System.IO;
using static FitnessClub.PriceInformation;

namespace FitnessClub
{
    /// <summary>
    /// image source: http://www.truegritness.com/wp-content/uploads/2014/12/TG-BKG-IRON-GYM-SM-DARK.jpg
    /// Interaction logic for MembershipSales.xaml
    /// Users can navigate to the Membership Sales page from the Main Menu. Once the user enters in information, can proceed to the registration page. 
    /// </summary>
    public partial class MembershipSales : Window
    {
        List<PriceInformation> priceList;
        public MembershipSales()
        {
            InitializeComponent();
            //1. Initialize list
            priceList = new List<PriceInformation>();
            Files calFiles = new Files();

            //2. Set file location and timestamp for method
            string strFileLocation = @"..\..\..\Data\Prices";
            string isTimestamp = DateTime.Now.Ticks.ToString();

            //3. Grab file location with extension
            string LoadedFilePath = calFiles.GetFilePath(strFileLocation, "json", false);

            //4. Read in data
            System.IO.StreamReader reader = new System.IO.StreamReader(LoadedFilePath);
            string jsonData = reader.ReadToEnd();
            reader.Close();

            //5. Deseralize it to a list
            priceList = JsonConvert.DeserializeObject<List<PriceInformation>>(jsonData);

            //6. Add membership to the combo box
            AddComboItems();
        }


        #region navigating between windows
        private void txbMemReg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MembershipSignUp winMemberReg = new MembershipSignUp();
            winMemberReg.Show();
            this.Close();
        }
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }
        #endregion
        public void btnSaveQuota_Click(object sender, RoutedEventArgs e)
        {

            //7. Initalize variables that must be prefaced before further validation
            DatePicker dtStartDate = dtStart;
            
            //8. Validate that a combobox item was selected
            if (cboMembershipType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Membership Plan.");
                return;
            }

            //9. Grab the boolean to see if a date has been selected
            bool isDateNull = isStartDateSelect(dtStartDate);
            
            //10. Check if a date has been select
            if (isDateNull == false)
            {
                MessageBox.Show("Please select a valid start date.");
                return;
            }

            //11. Once date is selected, declare variables that will calculate the end date
            DateTime dtToday = DateTime.Today;
            DateTime dtConvertStartDate = ConvertPickerToDate(dtStartDate);
            DateTime dtConvertedEndDate = dtToday;

            //12. Determine if a user picked an date in the past
            if (dtConvertStartDate < dtToday)
            {
                MessageBox.Show("Please select a valid start date.");
                return;
            }

            //13. Determine the end date based on the drop down selected
            if ((cboMembershipType.SelectedIndex == 1 || cboMembershipType.SelectedIndex == 3 || cboMembershipType.SelectedIndex == 5))
            {
                dtConvertedEndDate = dtConvertStartDate.AddMonths(1);
            }
            else
            {
                dtConvertedEndDate = dtConvertStartDate.AddYears(1);
            }

            //9. Set selected item to string for query
            string strMembershipSelection = cboMembershipType.SelectedItem.ToString();

            //10. Query corresponding price from drop down menu
            var priceQuery =
                from p in priceList
                where (p.Membership.Trim() == strMembershipSelection.Trim())
                select p.Price;

            //11. Convert list to string
            string strMembershipPrice = String.Join(",", priceQuery);

            //13. Convert price to double for subtotal calculation
            double dblMembershipPrice = Convert.ToDouble(strMembershipPrice);
            double dblSubCost = GetAdditionalFeatureCost(lstFeatures, cboMembershipType);
            double dblTotalCost = dblSubCost + dblMembershipPrice;

            //14. String formula for output text box
            string strOutput = Environment.NewLine+"Membership Price:".PadRight(30) + dblMembershipPrice.ToString("C2") + Environment.NewLine + Environment.NewLine + "Addtional Feature Costs:".PadRight(30) + dblSubCost.ToString("C2") + Environment.NewLine + "________________________________________"+ Environment.NewLine + "Total Cost:".PadRight(30) + dblTotalCost.ToString("C2");

            //15. Split datetime for enddate
            string strConvertedEndDate = dtConvertedEndDate.ToString();
            int strSpace = strConvertedEndDate.IndexOf(" ");
            string strSubConvertedEndDate = strConvertedEndDate.Substring(0, strSpace);

            //16. Set additional features to string
            string strFeatures = lstFeatures.SelectedItems.ToString();

            //17. Set output to corresponding text boxes
            txtFeatures.Text = strFeatures;
            txtPrice.Text = dblMembershipPrice.ToString("C2");
            txtMemberQuotaOutput.Text = strOutput;
            txtEndDate.Text = strSubConvertedEndDate;
            txtMemberQuotaOutput.Text = strOutput;
            txtTotalPrice.Text = dblTotalCost.ToString("C2");

            //create some info to send to the next window
            CustomerPaymentInfo info = new CustomerPaymentInfo(cboMembershipType.Text.Trim(), dtStart.Text.Trim(), txtEndDate.Text.Trim(), txtFeatures.Text.Trim(), txtPrice.Text.Trim(), txtTotalPrice.Text.Trim());

            MessageBoxResult messageBoxResult = MessageBox.Show("Create new member?"
                + Environment.NewLine + Environment.NewLine + info
                , "Membership Quota"
                , MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                //instantiate the next window and use the overridden constructor that allows sending information in as an argument
                MembershipSignUp next = new MembershipSignUp(info);
                next.Show();
                this.Close();
            }
        }
        
        //Function that adds Prices.json data to combo-box
        public void AddComboItems()
        { foreach (var i in priceList)
                if(i.Availability == "Yes")
                cboMembershipType.Items.Add(i.Membership.ToString()); }
        
        //Calculates additional features (locker/personal training)
        public double GetAdditionalFeatureCost(ListBox lstbox, ComboBox cbo2)
        {
            double personalTraining = 5;
            double lockerRental = 1;
            double totalPrice = 0;
            byte totalMonths = 0;

            if (lstbox.SelectedIndex != -1)
            {
                if (lstbox.SelectedItems.Count > 1)
                {
                    totalPrice += personalTraining + lockerRental;
                }
                else if (lstbox.SelectedIndex == 1)
                {
                    totalPrice += lockerRental;
                }
                else
                {
                    totalPrice += personalTraining;
                }
            }
            else
            {
                totalPrice = 0;
            }

            if(cbo2.SelectedIndex == 0 || cbo2.SelectedIndex == 2 || cbo2.SelectedIndex == 4)
            {
                totalMonths = 12;
            }
            else
            {
                totalMonths = 1;
            }
            totalPrice *= totalMonths;
            return totalPrice;
        }

        public DateTime ConvertPickerToDate(DatePicker dStart)
        {
            string start = Convert.ToString(dStart);
            int StartMonth, StartDay, StartYear, StartFirstSlash, StartSecondSlash;
            string strStartMonth, strStartDay, strStartYear;

            // Parse strings to prepare for date calculations
            StartFirstSlash = start.IndexOf("/");
            StartSecondSlash = start.LastIndexOf("/");

            strStartMonth = start.Substring(0, StartFirstSlash);
            strStartDay = start.Substring(StartFirstSlash + 1, StartSecondSlash - 2);
            strStartYear = start.Substring(StartSecondSlash + 1, 4);

            //Convert parsed dates to int for further calculations
            Int32.TryParse(strStartMonth, out StartMonth);
            Int32.TryParse(strStartDay, out StartDay);
            Int32.TryParse(strStartYear, out StartYear);

            //Put parsed integers back into dates
            DateTime datConvertedStart = new DateTime(StartYear, StartMonth, StartDay);

            return datConvertedStart;
        }

        bool isStartDateSelect(DatePicker dStart)
        {
            bool isSelected = false;
            string strStart = Convert.ToString(dStart);
            if (strStart.Length == 0)
            {
                isSelected = false;
            }
            else
            {
                isSelected = true;
            }
                
            return isSelected;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtEndDate.Text = "";
            txtMemberQuotaOutput.Text = "";
            txtPrice.Text = "";
            cboMembershipType.SelectedIndex = -1;
            lstFeatures.SelectedIndex = -1;
        }
    }
}
    
