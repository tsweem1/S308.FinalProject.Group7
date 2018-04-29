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
            

            //3. Grab file location with extension
            string LoadedFilePath = calFiles.GetFilePath(strFileLocation, "json", false);

            //4. Read in data
            System.IO.StreamReader reader = new System.IO.StreamReader(LoadedFilePath);
            string jsonData = reader.ReadToEnd();
            reader.Close();

            //5. Deseralize it to a list
            merchList = JsonConvert.DeserializeObject<List<Merchandise>>(jsonData);

            //6. Add membership to the combo box
            AddComboItems();

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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cboMerchandise.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            cboSize.Text = "";
            txtShoppingCart.Text = "";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //declare variables and convert input
            int intQty;
            double dblPrice;
            string strShoppingCart;

            intQty = Convert.ToInt32(txtQty.Text);
            dblPrice = Convert.ToDouble(txtPrice.Text);
            
            //validate user input
            if (cboMerchandise.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Item.");
                return;
            }
            if (cboSize.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a size.");
                return;
            }

            string strMerchSelection = cboMerchandise.SelectedItem.ToString();

            //get merch
            var merchQuery =
                from m in merchList
                where (m.Item.Trim() == strMerchSelection.Trim())
                select m.Item;

            //Convert query lists to string
            string strMerchandise = String.Join(",", merchQuery);

            //total price
            dblPrice = dblPrice * intQty;

            //shopping cart
            strShoppingCart = Environment.NewLine + "Item:".PadRight(20) + "Quantity:".PadRight(20) + "Price:".PadRight(20) + "Size:".PadRight(20);

            //16. Set output to corresponding text boxes
            strShoppingCart = txtShoppingCart.Text;        


        }
        public void AddComboItems()
        {
            foreach (var i in merchList)
               
                    cboMerchandise.Items.Add(i.Item.ToString());

           
        
    }
    }
}

