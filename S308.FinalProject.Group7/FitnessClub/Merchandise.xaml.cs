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
    /// Interaction logic for Merchandise.xaml
    /// User can get to the Merchandise page from the Main Menu to when the user wants to purchase goods at the gym. 
    /// </summary>
    public partial class Merchandise : Window
    {
        List<Merchandise> merchList;
        public Merchandise()
        {
            InitializeComponent();

            InitializeComponent();
            //1. Initialize list
            merchList = new List<Merchandise>();
            Files calFiles = new Files();

            //2. Set file location and timestamp for method
            string strFileLocation = @"..\..\..\Data\MerchInfo";
            string isTimestamp = DateTime.Now.Ticks.ToString();

            //3. Grab file location with extension
            string LoadedFilePath = calFiles.GetFilePath(strFileLocation, "json", false);

            //4. Read in data
            System.IO.StreamReader reader = new System.IO.StreamReader(LoadedFilePath);
            string jsonData = reader.ReadToEnd();
            reader.Close();

            //5. Deseralize it to a list
            merchList = JsonConvert.DeserializeObject<List<PriceInformation>>(jsonData);

            //6. Add membership to the combo box
            //AddComboItems();

        }







        private void btnMainMenu1_Click(object sender, RoutedEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        private void btnProceedCheckOut_Click(object sender, RoutedEventArgs e)
        {
            CheckOut winCheckOut = new FitnessClub.CheckOut();
            winCheckOut.Show();
            this.Close();
        }
    }
}

