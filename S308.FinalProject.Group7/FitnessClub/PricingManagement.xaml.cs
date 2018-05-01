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
using Newtonsoft.Json.Linq;

namespace FitnessClub
{
    /// <summary>
    /// image source: http://www.truegritness.com/wp-content/uploads/2014/12/TG-BKG-IRON-GYM-SM-DARK.jpg
    /// Interaction logic for PricingManagement.xaml
    /// User can get to the Pricing Management page from the Main Menu.
    /// </summary>
    public partial class PricingManagement : Window
    {
        List<PriceInformation> priceList;

        public PricingManagement()
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

        public void btnTypeCheck_Click(object sender, RoutedEventArgs e)

        {
            //7. Validate user selected membership type
            if (iscboMembershipSelected(cboMembershipTypeInfo) == false)
            {
                MessageBox.Show("Please select a membership type from the drop down menu.");
                return;
            }
            //8.Write queries to get avaliability and price information for selected membership type
            string strMembershipSelection = cboMembershipTypeInfo.SelectedItem.ToString();

            //8.1 get avaliability
            var avaliabilityQuery =
                from p in priceList
                where (p.Membership.Trim() == strMembershipSelection.Trim())
                select p.Availability;

            //8.2 get price
            var priceQuery =
                from p in priceList
                where (p.Membership.Trim() == strMembershipSelection.Trim())
                select p.Price;

            //9.Convert query lists to string
            string strAvaliability = String.Join(",", avaliabilityQuery);
            string strPrice = String.Join(",", priceQuery);

            string strOutput = Environment.NewLine + "Membership Type:".PadRight(25) + strMembershipSelection + Environment.NewLine + Environment.NewLine + "Avaliability:".PadRight(25) + strAvaliability + Environment.NewLine + Environment.NewLine + "Price:".PadRight(25) + strPrice;

            //10. Output data in text box for user's review
            txtMemberData.Text = strOutput;
        }

        #region Helper Functions
        //11. Clear contents
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        //12. Function that clears contents
        public void Clear()
        {
            txtMemberData.Text = "";
            txtUpdatePrice.Text = "";
            cboMembershipTypeInfo.SelectedIndex = -1;
            cboUpdateAvailability.SelectedIndex = -1;
        }

        //13. Function that checks if combobox is selected
        bool iscboMembershipSelected(ComboBox cbo)
        {
            if (cbo.SelectedIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //14. Function that adds Prices.json data to combo-box
        public void AddComboItems() { foreach (var i in priceList) cboMembershipTypeInfo.Items.Add(i.Membership.ToString()); }

        //15. Function that navigates back to Main Menu
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }
        #endregion

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //15. Read in file again in local scope in order to update file

            //15.1 Initialize list
            priceList = new List<PriceInformation>();
            Files calFiles = new Files();

            //15.2. Set file location and timestamp for method
            string strFileLocation = @"..\..\..\Data\Prices";
            string isTimestamp = DateTime.Now.Ticks.ToString();

            //15.3. Grab file location with extension
            string LoadedFilePath = calFiles.GetFilePath(strFileLocation, "json", false);

            //15.4. Read in data
            System.IO.StreamReader reader = new System.IO.StreamReader(LoadedFilePath);
            string jsonData = reader.ReadToEnd();
            reader.Close();

            //15.5. Deseralize it to a list
            priceList = JsonConvert.DeserializeObject<List<PriceInformation>>(jsonData);
            if (iscboMembershipSelected(cboMembershipTypeInfo) == false)
            {
                MessageBox.Show("Please select a membership type from the drop-down menu.");
                return;
            }

            //16. Declare variables to update the pricing data
            string strUpdatePrice = txtUpdatePrice.Text;
            string strMembership = cboMembershipTypeInfo.SelectedItem.ToString();
            bool isUpdateAvaliability = cboUpdateAvailability.SelectedIndex == -1;
            bool isUpdatePrice = strUpdatePrice.Length == 0;
            double dblUpdatePrice;

            //17. Check if price has been entered
            if (isUpdatePrice == true)
            {
                txtUpdatePrice.Text = "";
                MessageBox.Show("Please enter a price to complete membership update.");
                return;
            }

            //18. Validate price is an actual number

            if (!Double.TryParse(strUpdatePrice, out dblUpdatePrice))
            {
                txtUpdatePrice.Text = "";
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            //19. Get avaliability for update
            var avaliabilityQuery =
                from p in priceList
                where (p.Membership.Trim() == strMembership.Trim())
                select p.Availability;

            //20. Get price for update
            var priceQuery =
                from p in priceList
                where (p.Membership.Trim() == strMembership.Trim())
                select p.Price;

            //21.Convert query lists to string
            string strAvaliability = String.Join(",", avaliabilityQuery);
            string strPrice = String.Join(",", priceQuery);

            //22. Set selected combobox items
            ComboBoxItem cbiSelected = (ComboBoxItem)cboUpdateAvailability.SelectedItem;
            string strUpdateAvaliability = cbiSelected.Content.ToString();

            //23. Instanciate PriceInformation
            PriceInformation priceUpdate = new PriceInformation(strMembership, strUpdatePrice, strUpdateAvaliability);

            //24. Get the price to update to
            PriceInformation priceUp =
                (from p in priceList
                 where p.Membership == strMembership
                 select p).FirstOrDefault();

            //25. Get avaliability to update to
            PriceInformation avalUp =
                (from p in priceList
                 where p.Membership == strMembership
                 select p).FirstOrDefault();

            //26. Set query results equal to update output
            priceUp.Price = strUpdatePrice;
            avalUp.Availability = strUpdateAvaliability;

            //27. Confirm if user wants to continue with update
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to update the " + " " + strMembership + " " + "membership's avaliability?"
               , "Update " + strMembership + "?"
               , MessageBoxButton.YesNo);

            //28. Rewrite file to update pricing information
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                string updateJsonData = JsonConvert.SerializeObject(priceList);
                System.IO.File.WriteAllText(LoadedFilePath, updateJsonData);
            }

            //29. Refresh output in txtMemberData.Text

            string strOutput = "";
            if (isUpdatePrice == true)
            {
                strOutput = Environment.NewLine + "Membership Type:".PadRight(25) + strMembership + Environment.NewLine + Environment.NewLine + "Avaliability:".PadRight(25) + avalUp.Availability.ToString() + Environment.NewLine + Environment.NewLine + "Price:".PadRight(25) + strPrice.ToString();
            }

            else
            {
                strOutput = Environment.NewLine + "Membership Type:".PadRight(25) + strMembership + Environment.NewLine + Environment.NewLine + "Avaliability:".PadRight(25) + avalUp.Availability.ToString() + Environment.NewLine + Environment.NewLine + "Price:".PadRight(25) + priceUp.Price.ToString();
            }

            //30. Refresh txtMemberData.Text
            txtMemberData.Text = strOutput;

            //31. Show success message
            MessageBox.Show("Membership update successful!");

            //32. Clear Contents
            Clear();
        }
    }
    }

