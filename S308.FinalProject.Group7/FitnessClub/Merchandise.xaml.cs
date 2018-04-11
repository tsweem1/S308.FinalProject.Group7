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
        public Merchandise()
        {
            InitializeComponent();
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
