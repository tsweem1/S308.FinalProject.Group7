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


        //Function that adds Prices.json data to combo-box
        public void AddComboItems() { foreach (var i in priceList) cboMembershipTypeInfo.Items.Add(i.Membership.ToString()); }
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        public void btnTypeCheck_Click(object sender, RoutedEventArgs e)
        {
            if(iscboMembershipSelected(cboMembershipTypeInfo) == false)
            {
                MessageBox.Show("Please select a membership type from the drop down menu.");
                return;
            }
            //7.Write queries to get avaliability and price information for selected membership type
            string strMembershipSelection = cboMembershipTypeInfo.SelectedItem.ToString();
            
            //7.1 get avaliability
            var avaliabilityQuery =
                from p in priceList
                where (p.Membership.Trim() == strMembershipSelection.Trim())
                select p.Availability;
            
            //7.2 get price
            var priceQuery =
                from p in priceList
                where (p.Membership.Trim() == strMembershipSelection.Trim())
                select p.Price;

            //8.Convert query lists to string
            string strAvaliability = String.Join(",", avaliabilityQuery);
            string strPrice = String.Join(",", priceQuery);

            string strOutput = Environment.NewLine + "Membership Type:".PadRight(25) + strMembershipSelection + Environment.NewLine + Environment.NewLine + "Avaliability:".PadRight(25) + strAvaliability + Environment.NewLine + Environment.NewLine + "Price:".PadRight(25) + strPrice;

            //9. Output data in text box for user's review
            txtMemberData.Text = strOutput;
        }

        private void btnUpdateType_Click(object sender, RoutedEventArgs e)
        {

            if (iscboMembershipSelected(cboMembershipTypeInfo) == false)
            {
                MessageBox.Show("Please select a membership type from the drop down menu.");
                return;
            }

            //10. Declare variables to update the pricing data
            string strUpdatePrice = txtUpdatePrice.Text;
            bool isUpdateAvaliability = cboUpdateAvailability.SelectedIndex == -1;
            bool isUpdatePrice = strUpdatePrice.Length == 0;
            double dblUpdatePrice;

            // 11. Validate that price is at NOT left blank
            if(isUpdatePrice == true)
            {
                txtUpdatePrice.Text = "";
                MessageBox.Show("Please enter a price to complete membership update.");
                return;
            }

            //11.1 Validate price is an actual number
            if(! Double.TryParse(strUpdatePrice, out dblUpdatePrice))
            {
                txtUpdatePrice.Text = "";
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            //12. Validate the cboUpdateAvailability is selected
            if(isUpdateAvaliability == true)
            {
                MessageBox.Show("Please select an option from the dropdown.");
                return;
            }
            string strUpdateAvaliability = cboUpdateAvailability.SelectedItem.ToString();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtMemberData.Text = "";
            txtUpdatePrice.Text = "";
            cboMembershipTypeInfo.SelectedIndex = -1;
            cboUpdateAvailability.SelectedIndex = -1;
        }

        bool iscboMembershipSelected(ComboBox cbo)
        {
            if(cbo.SelectedIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
