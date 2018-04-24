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

            //7. Initalize variables
            DatePicker dtStartDate = dtStart;
            DatePicker dtEndDate = dtEnd;
            int SubCost = GetAdditionalFeatureCost(lstFeatures, cboMembershipType);
            int TimeFrame;

            //8. Validate that a combobox item was selected
            if (cboMembershipType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Membership Plan.");
                return;
            }

            int dateDifference = GetDateDifference(dtStartDate, dtEndDate);
            if ((dtStartDate == dtEndDate) || dateDifference < 0)
            {
                MessageBox.Show("Please select a month or year date range."+"  "+dateDifference.ToString());
                return;
            }
            else if ((cboMembershipType.SelectedIndex == 0 || cboMembershipType.SelectedIndex == 2 || cboMembershipType.SelectedIndex == 4)&& dateDifference < 27)
            {
                MessageBox.Show("For a month's membership, please select a valid date range." + "  " + dateDifference.ToString());
                return;
            }
            else if((cboMembershipType.SelectedIndex == 1 || cboMembershipType.SelectedIndex == 3|| cboMembershipType.SelectedIndex == 5) && dateDifference != 0)
            {
                MessageBox.Show("For a year's membership, please select a valid date range." + "  " + dateDifference.ToString());
                return;
            }
            else
            {
                if((dateDifference == 31 || dateDifference == 30 || dateDifference == 29) && (cboMembershipType.SelectedIndex == 0 || cboMembershipType.SelectedIndex == 2 || cboMembershipType.SelectedIndex == 4))
                {
                    MessageBox.Show(dateDifference.ToString());
                    TimeFrame = 1;
                }
                if((cboMembershipType.SelectedIndex == 1 || cboMembershipType.SelectedIndex == 3 || cboMembershipType.SelectedIndex == 5) && dateDifference == 0)
                {
                    MessageBox.Show(dateDifference.ToString());
                    TimeFrame = 12;
                }
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

            //12. Set price text output equal to string
            txtPrice.Text = strMembershipPrice;
        }
        
        //Function that adds Prices.json data to combo-box
        public void AddComboItems() { foreach (var i in priceList) cboMembershipType.Items.Add(i.Membership.ToString()); }

        //Calculates additional features (locker/personal training)
        public int GetAdditionalFeatureCost(ListBox lstbox, ComboBox cbo2)
        {
            int personalTraining = 5;
            int lockerRental = 1;
            int totalPrice = 0;
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
                totalMonths = 1;
            }
            else
            {
                totalMonths = 12;
            }
            totalPrice *= totalMonths;
            return totalPrice;
        }

        public int GetDateDifference(DatePicker dStart, DatePicker dEnd)
        {
            string start = Convert.ToString(dStart);
            string end = Convert.ToString(dEnd);
            int StartMonth, StartDay, StartYear, EndMonth, EndDay, EndYear, StartFirstSlash, StartSecondSlash, EndFirstSlash, EndSecondSlash;
            string strStartMonth, strStartDay, strStartYear, strEndMonth, strEndDay, strEndYear;

            // Parse strings to prepare for date calculations
            StartFirstSlash = start.IndexOf("/");
            StartSecondSlash = start.LastIndexOf("/");

            strStartMonth = start.Substring(0, StartFirstSlash);
            strStartDay = start.Substring(StartFirstSlash + 1, StartSecondSlash - 2);
            strStartYear = start.Substring(StartSecondSlash + 1, 4);

            EndFirstSlash = start.IndexOf("/");
            EndSecondSlash = start.LastIndexOf("/");

            strEndMonth = end.Substring(0, EndFirstSlash);
            strEndDay = end.Substring(EndFirstSlash + 1, EndSecondSlash - 2);
            strEndYear = start.Substring(EndSecondSlash + 1, 4);

            //Convert parsed dates to int for further calculations
            Int32.TryParse(strStartMonth, out StartMonth);
            Int32.TryParse(strStartDay, out StartDay);
            Int32.TryParse(strStartYear, out StartYear);

            Int32.TryParse(strEndMonth, out EndMonth);
            Int32.TryParse(strEndDay, out EndDay);
            Int32.TryParse(strEndYear, out EndYear);

            //Put parsed integers back into dates
            DateTime datConvertedStart = new DateTime(StartYear, StartMonth, StartDay);
            DateTime datConvertedEnd = new DateTime(EndYear, EndMonth, EndDay);
            TimeSpan tspInterval5 = datConvertedEnd.Subtract(datConvertedStart);

            int convert = int.Parse(tspInterval5.Days.ToString());

            return convert;
        }
    }
}
    
