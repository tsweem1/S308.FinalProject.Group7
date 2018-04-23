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
            foreach (var i in priceList)
            {
                cboMembershipType.Items.Add(i.Membership);
            }
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
        private void btnSaveQuota_Click(object sender, RoutedEventArgs e)
        {
            var priceQuery =
                from p in priceList
                where (p.Membership.Trim() == cboMembershipType.Text.Trim())
                select p.Price;

            MessageBox.Show(priceQuery.ToString());

            //MessageBox.Show(output);
            //DatePicker help = dtStart;
            // MessageBox.Show(help.ToString());
        }

    }
}
