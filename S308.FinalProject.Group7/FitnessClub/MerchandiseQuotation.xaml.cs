using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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
        List<MerchandiseInfo> merchList;
        public Merchandise()
        {
            InitializeComponent();
            //1. Load Json File
            GetDataSetFromFile();
        }
        private void GetDataSetFromFile()
        {
            //2. Create new list to hold merch info
            List<MerchandiseInfo> lstMember = new List<MerchandiseInfo>();
            //3. createe string to hold file path
            string strFilePath = @"..\..\..\Data\MerchInfo.json";

            try
            {
               //4.use system.oi.file to read the entire data file
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();
               //5. serialize the json data to a list of customers
                merchList = JsonConvert.DeserializeObject<List<MerchandiseInfo>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Merchandise from file: " + ex.Message);
            }

            //6. add combobox items
            AddComboItems();
        }
        //7. add merchandise to combobox
        public void AddComboItems()
        {
            foreach (var i in merchList)
                if (i.InStock == "Yes")
                    cboMerchandise.Items.Add(i.MerchItem.ToString());

        }

        #region Helper Functions
        //8. Naviage to Main Menu Window
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        //9. Clear Contents
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cboMerchandise.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            cboSize.Text = "";
            txtShoppingCart.Text = "";
        }
        #endregion

        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //10. declare variables
            int intQty;
            string strShoppingCart;
            double dblTotalPrice;
            string strSize;

    
            //11. validate user enters in merch
            if (cboMerchandise.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose an item from our merchandise selection.");
                return;
            }
            if (cboSize.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a size.");
                return;
            }
            //12. validate user enters in a valid number for quantity
            if (!int.TryParse(txtQty.Text, out intQty))
            {
               
                MessageBox.Show("Please enter a valid number for quantity.");
                return;
            }
            //13. validate user enters in a valid number for quantity and does not leave it blank
            if (intQty <0 && txtQty.Text == "")
            {
                MessageBox.Show("Please enter a valid amount for quantity.");
                return;
            }

            //14. Set selected item to string for query
            string strMerchSelection = cboMerchandise.SelectedItem.ToString();

            //15. get price from drop down
            var priceQuery =
                from p in merchList
               where (p.MerchItem.Trim() == strMerchSelection.Trim())
                select p.MerchPrice;

            //16. Convert query list to string
            string strMerchPrice = String.Join(",", priceQuery);

            //17. convert output for total price calculation and display in shopping cart
            double dblMerchPrice = Convert.ToDouble(strMerchPrice);
            intQty = Convert.ToInt32(txtQty.Text);
            strSize = Convert.ToString(cboSize.Text);

            //18. calculate total price
            dblTotalPrice = dblMerchPrice * intQty;

            //19. shopping cart
           strShoppingCart = Environment.NewLine + "Item:".PadRight(15) + strMerchSelection.ToString() +Environment.NewLine +Environment.NewLine+ "Quantity:".PadRight(15) + intQty.ToString()+ Environment.NewLine+ Environment.NewLine+ "Size:".PadRight(15) + strSize.ToString() + Environment.NewLine + "_____________________________________" + Environment.NewLine + Environment.NewLine+"Total Price:".PadRight(15) + dblTotalPrice.ToString("C2");

            //20. set shopping cart output
            txtShoppingCart.Text = strShoppingCart;

            //21. Set merch output to corresponding text boxes
            txtPrice.Text = dblMerchPrice.ToString("C2");
            txtQty.Text = intQty.ToString();
            cboSize.Text = strSize.ToString();



        }

       

    }
}

