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
            // Load Json File
            GetDataSetFromFile();
        }
        private void GetDataSetFromFile()
        {
            List<MerchandiseInfo> lstMember = new List<MerchandiseInfo>();
            string strFilePath = @"..\..\..\Data\MerchInfo.json";

            try
            {
               //use system.oi.file to read the entire data file
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();
                                //serialize the json data to a list of customers
                merchList = JsonConvert.DeserializeObject<List<MerchandiseInfo>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Merchandise from file: " + ex.Message);
            }

            //add combobox items
            AddComboItems();
        }
        //add merchandise to combobox
        public void AddComboItems()
        {
            foreach (var i in merchList)
                if (i.InStock == "Yes")
                    cboMerchandise.Items.Add(i.MerchItem.ToString());

        }


        private void btnMainMenu1_Click(object sender, RoutedEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
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
            //declare variables
            int intQty;
            string strShoppingCart;
            double dblTotalPrice;
            string strSize;

    
            //validate user enters in merch
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
            //validate user enters in a valid number for quantity
            if (!int.TryParse(txtQty.Text, out intQty))
            {
               
                MessageBox.Show("Please enter a valid number for quantity.");
                return;
            }
            //validate user enters in a valid number for quantity and does not leave it blank
            if (intQty <0 && txtQty.Text == "")
            {
                MessageBox.Show("Please enter a valid amount for quantity.");
                return;
            }

            //Set selected item to string for query
            string strMerchSelection = cboMerchandise.SelectedItem.ToString();

            //get price from drop down
            var priceQuery =
                from p in merchList
               where (p.MerchItem.Trim() == strMerchSelection.Trim())
                select p.MerchPrice;

            //Convert query list to string
            string strMerchPrice = String.Join(",", priceQuery);

            //convert output for total price calculation and display in shopping cart
            double dblMerchPrice = Convert.ToDouble(strMerchPrice);
            intQty = Convert.ToInt32(txtQty.Text);
            strSize = Convert.ToString(cboSize.Text);

            //calculate total price
            dblTotalPrice = dblMerchPrice * intQty;

            //shopping cart
           strShoppingCart = Environment.NewLine + "Item:".PadRight(15) + strMerchSelection.ToString() +Environment.NewLine +Environment.NewLine+ "Quantity:".PadRight(15) + intQty.ToString()+ Environment.NewLine+ Environment.NewLine+ "Size:".PadRight(15) + strSize.ToString() + Environment.NewLine + "_____________________________________" + Environment.NewLine + Environment.NewLine+"Total Price:".PadRight(15) + dblTotalPrice.ToString("C2");

            //set shopping cart output
            txtShoppingCart.Text = strShoppingCart;
            // Set merch output to corresponding text boxes
            txtPrice.Text = dblMerchPrice.ToString("C2");
            txtQty.Text = intQty.ToString();
            cboSize.Text = strSize.ToString();



        }

       

    }
}

