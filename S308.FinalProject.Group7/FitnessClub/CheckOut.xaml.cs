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
    /// Interaction logic for CheckOut.xaml
    /// users can input payment data and get to the merchandise window
    /// </summary>
    public partial class CheckOut : Window
    {
        public CheckOut()
        {
            InitializeComponent();
        }

        private void btnConfirmCheckOut_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
